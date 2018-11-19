using System.Xml;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// XML文件
    /// </summary>
    public class XmlFileClass
    {
        /// <summary>
        /// 加载XML文件（忽略注释）
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>XmlDocument.</returns>
        public static XmlDocument LoadXmlFile(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument(); //新建XML文件
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreComments = true //忽略注释
            };
            XmlReader reader = XmlReader.Create(filePath, settings);
            xmlDoc.Load(reader); //加载XML文件
            reader.Close(); //关闭读取器
            return xmlDoc;
        }

    }
}
