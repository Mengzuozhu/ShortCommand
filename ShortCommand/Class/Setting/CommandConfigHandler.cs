using System.Collections.Generic;
using System.Xml;
using ShortCommand.Class.Helper;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// 命令配置
    /// </summary>
    public class CommandConfigHandler
    {
        private const string Command = "Command";
        private const string CommandInfo = "CommandInfo";
        private const string CommandInfos = "CommandInfos";
        private const string CommandSettings = "CommandSettings";
        private const string PathInfos = "PathInfos";
        //节点名称
        private const string ShortName = "ShortName";
        //文件路径
        private readonly string filePath; 

        public CommandConfigHandler(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// 获取所有命令配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadCommandConfigFile(string path)
        {
            Dictionary<string, string> configKeyAndValue = new Dictionary<string, string>();
            if (FileAndDirectoryHelper.FileIsNotExists(path))
            {
                return configKeyAndValue;
            }

            var xmlDoc = XmlFileLoader.LoadXmlFile(path);
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(CommandInfo);
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                XmlAttributeCollection attributes = xmlNodeList[i].Attributes;
                if (attributes == null)
                {
                    continue;
                }

                XmlAttribute currentKey = attributes[ShortName];
                XmlAttribute currentValue = attributes[Command];
                if (currentKey != null && currentValue != null)
                {
                    configKeyAndValue[currentKey.InnerText] = currentValue.InnerText;
                }
            }

            return configKeyAndValue;
        }

        public Dictionary<string, string> ReadAllCommandConfigs()
        {
            return ReadCommandConfigFile(filePath);
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
                MessageBoxHelper.ShowErrorMessageBox($"配置文件不存在：{filePath}");
                return;
            }

            UpdateCommandInfos(configKeyAndValue, XmlFileLoader.LoadXmlFile(filePath));
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
                MessageBoxHelper.ShowErrorMessageBox($"配置文件格式错误，{CommandSettings}节点不存在");
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
                if (FileAndDirectoryHelper.PathIsExists(commandValue))
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
    }
}