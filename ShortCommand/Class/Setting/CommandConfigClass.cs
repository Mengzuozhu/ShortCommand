using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ShortCommand.Class.Helper;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// 命令配置
    /// </summary>
    public class CommandConfigClass
    {
        private const string ShortName = "ShortName";
        private const string Command = "Command";
        private const string CommandInfos = "CommandInfos";
        private const string PathInfos = "PathInfos";
        private const string CommandSettings = "CommandSettings";
        private const string CommandInfo = "CommandInfo"; //节点名称

        private readonly string filePath; //文件路径

        public CommandConfigClass(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// 获取所有命令配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ReadAllCommandConfigs()
        {
            Dictionary<string, string> configKeyAndValue = new Dictionary<string, string>();
            //文件不存在，或节点为空，则返回空字典
            if (FileAndDirectoryHelper.FileIsNotExists(filePath)) return configKeyAndValue;

            var xmlDoc = XmlFileClass.LoadXmlFile(filePath);
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(CommandInfo);
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                XmlNode currentNode = xmlNodeList[i];
                if (currentNode.Attributes == null) continue;
                XmlAttribute currentKey = currentNode.Attributes[ShortName];
                XmlAttribute currentValue = currentNode.Attributes[Command];
                if (currentKey == null || currentValue == null) continue;
                configKeyAndValue[currentKey.InnerText] = currentValue.InnerText;
            }
            return configKeyAndValue;
        }

        /// <summary>
        /// 写入所有命令配置
        /// </summary>
        /// <param name="configKeyAndValue"></param>
        public void WriteAllCommandConfigs(Dictionary<string, string> configKeyAndValue)
        {
            //文件不存在，则返回
            if (FileAndDirectoryHelper.FileIsNotExists(filePath))
            {
                MessageBox.Show(string.Format("配置文件不存在：{0}", filePath), @"错误");
                return;
            }
            var xmlDoc = XmlFileClass.LoadXmlFile(filePath);

            UpdateCommandInfos(configKeyAndValue, xmlDoc);
        }

        /// <summary>
        /// 更新命令信息
        /// </summary>
        /// <param name="configKeyAndValue"></param>
        /// <param name="xmlDoc"></param>
        private void UpdateCommandInfos(Dictionary<string, string> configKeyAndValue, XmlDocument xmlDoc)
        {
            bool isAddSuccessful = TryAddCommandAndPathInfosNode(xmlDoc);
            if (!isAddSuccessful)
            {
                return;
            }

            XmlNode commandInfosNode = xmlDoc.GetElementsByTagName(CommandInfos)[0];
            XmlNode pathInfosNode = xmlDoc.GetElementsByTagName(PathInfos)[0];

            foreach (var configs in configKeyAndValue)
            {
                string commandValue = configs.Value;
                XmlElement newNode = xmlDoc.CreateElement(CommandInfo);
                newNode.SetAttribute(Command, commandValue);
                newNode.SetAttribute(ShortName, configs.Key);
                //添加到路径信息
                if (File.Exists(commandValue) || Directory.Exists(commandValue))
                {
                    pathInfosNode.AppendChild(newNode);
                }
                else
                {
                    commandInfosNode.AppendChild(newNode);
                }
            }

            xmlDoc.Save(filePath);
        }

        /// <summary>
        /// 添加命令和路径信息节点
        /// </summary>
        /// <param name="xmlDoc"></param>
        private static bool TryAddCommandAndPathInfosNode(XmlDocument xmlDoc)
        {
            XmlNodeList commandSettingNodes = xmlDoc.GetElementsByTagName(CommandSettings);
            if (commandSettingNodes.Count < 1)
            {
                MessageBox.Show(string.Format("配置文件格式错误，{0}节点不存在", CommandSettings), @"错误");
                return false;
            }
            XmlNode commandSettingNode = commandSettingNodes[0];
            //移除之前的命令配置节点
            commandSettingNode.RemoveAll();
            //重新添加节点
            commandSettingNode.AppendChild(xmlDoc.CreateElement(CommandInfos));
            commandSettingNode.AppendChild(xmlDoc.CreateElement(PathInfos));
            return true;
        }

    }
}
