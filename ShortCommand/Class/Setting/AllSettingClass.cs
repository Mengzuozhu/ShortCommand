using System;
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
        private static CommandConfigHandler commandConfigHandler; //命令配置
        private static AppConfigHandler appConfigHandler; //程序配置

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
            commandConfigHandler = new CommandConfigHandler(filePath);
            Dictionary<string, string> commandSettings = commandConfigHandler.ReadAllCommandConfigs();
            return commandSettings;
        }

        /// <summary>
        /// 读取程序配置
        /// </summary>
        /// <returns></returns>
        private static void GetAppSettings()
        {
            var filePath = GetConfigFilePath();
            appConfigHandler = new AppConfigHandler(filePath);
            appSettings = appConfigHandler.ReadAllAppConfigs();
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
        public static void WriteAllCommandConfigs(Dictionary<string, string> shortNameAndCommands)
        {
            commandConfigHandler?.WriteAllCommandConfigs(shortNameAndCommands);
        }

        public static void WriteAllAppConfigs()
        {
            appConfigHandler?.WriteAllAppConfigs(appSettings);
        }

        /// <summary>
        /// 获取配置中的布尔值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetSettingBooleanValueFor(string key)
        {
            return bool.TrueString.Equals(GetSettingStringValueFor(key), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 获取配置中的字符串值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSettingStringValueFor(string key)
        {
            return appSettings.ContainsKey(key) ? appSettings[key] : string.Empty;
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