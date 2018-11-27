using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// 所有配置
    /// </summary>
    class AllSettingClass
    {
        private static Dictionary<string, string> appSettings; //程序配置项和值
        private static CommandConfigClass commandConfigFile; //命令配置
        private static AppConfigClass appConfigFile; //程序自身的配置

        static AllSettingClass()
        {
            GetAppSettings();
        }

        /// <summary>
        /// 读取命令配置
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ReadCommandSettings()
        {
            var filePath = GetConfigFilePath();
            commandConfigFile = new CommandConfigClass(filePath);
            Dictionary<string, string> commandSettings = commandConfigFile.ReadAllCommandConfigs();
            return commandSettings;
        }

        /// <summary>
        /// 读取程序配置
        /// </summary>
        /// <returns></returns>
        private static void GetAppSettings()
        {
            var filePath = GetConfigFilePath();
            appConfigFile = new AppConfigClass(filePath);
            appSettings = appConfigFile.ReadAllAppConfigs();
        }

        /// <summary>
        /// 获取配置文件路径
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFilePath()
        {
            string filePath = string.Format(@"{0}\{1}", Application.StartupPath, "config.xml");
            return filePath;
        }

        /// <summary>
        /// 写入所有配置
        /// </summary>
        /// <param name="shortNameAndCommands"></param>
        public static void WriteAllSetting(Dictionary<string, string> shortNameAndCommands)
        {
            if (commandConfigFile != null)
            {
                commandConfigFile.WriteAllCommandConfigs(shortNameAndCommands);
            }

            if (appConfigFile != null)
            {
                appConfigFile.WriteAllAppConfigs(appSettings);
            }
        }

        /// <summary>
        /// 获取配置中的布尔值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetSettingBooleanValueFor(string key)
        {
            string settingStringValue = GetSettingStringValueFor(key);
            return "true".Equals(settingStringValue);
        }

        /// <summary>
        /// 获取配置中的字符串值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSettingStringValueFor(string key)
        {
            //不包含对应配置项
            if (!appSettings.ContainsKey(key))
            {
                return string.Empty;
            }
            string xmlValue = appSettings[key];
            return xmlValue;
        }

        /// <summary>
        /// 修改配置中的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void ChangeSettingValueFor(string key, string value)
        {
            appSettings[key] = value;
        }

    }
}
