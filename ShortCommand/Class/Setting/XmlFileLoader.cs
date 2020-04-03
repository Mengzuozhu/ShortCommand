using System.Xml;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// XML文件
    /// </summary>
    public class XmlFileLoader
    {
        /// <summary>
        /// 加载XML文件（忽略注释）
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>XmlDocument.</returns>
        public static XmlDocument LoadXmlFile(string filePath)
        {
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreComments = true
            };
            XmlDocument xmlDoc = new XmlDocument();
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                xmlDoc.Load(reader);
            }

            return xmlDoc;
        }
    }
}