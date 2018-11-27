using System.Collections.Generic;
using System.Xml;
using ShortCommand.Class.Helper;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// 程序自身的配置
    /// </summary>
    class AppConfigClass
    {
        private const string AppSettings = "AppSettings";
        private readonly string filePath; //文件路径

        public AppConfigClass(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// 获取所有程序配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ReadAllAppConfigs()
        {
            Dictionary<string, string> configKeyAndValue = new Dictionary<string, string>();
            //文件不存在，或节点为空，则返回空字典
            if (FileAndDirectoryHelper.FileIsNotExists(filePath)) return configKeyAndValue;

            var xmlDoc = XmlFileClass.LoadXmlFile(filePath);
            XmlNodeList appSettingsNodes = xmlDoc.GetElementsByTagName(AppSettings);
            if (appSettingsNodes.Count < 1)
            {
                return configKeyAndValue;
            }

            foreach (XmlNode childNode in appSettingsNodes[0].ChildNodes)
            {
                if (childNode == null) continue;
                configKeyAndValue[childNode.Name] = childNode.InnerText;
            }

            return configKeyAndValue;
        }

        /// <summary>
        /// 写入所有程序配置
        /// </summary>
        /// <param name="configKeyAndValue"></param>
        public void WriteAllAppConfigs(Dictionary<string, string> configKeyAndValue)
        {
            //文件不存在，则返回
            if (FileAndDirectoryHelper.FileIsNotExists(filePath))
            {
                MessageBoxHelper.ShowErrorMessageBox(string.Format("配置文件不存在：{0}", filePath));
                return;
            }
            var xmlDoc = XmlFileClass.LoadXmlFile(filePath);
            XmlNodeList appSettingsNodes = xmlDoc.GetElementsByTagName(AppSettings);
            if (appSettingsNodes.Count < 1)
            {
                return;
            }

            foreach (var configs in configKeyAndValue)
            {
                string nodeName = configs.Key;
                XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(nodeName);
                string innerText = configs.Value;
                if (xmlNodeList.Count > 0)
                {
                    xmlNodeList[0].InnerText = innerText;
                }
                else
                {
                    //创建新的配置
                    XmlElement newNode = xmlDoc.CreateElement(nodeName);
                    newNode.InnerText = innerText;
                    appSettingsNodes[0].AppendChild(newNode);
                }
            }
            xmlDoc.Save(filePath);
        }

    }
}
