using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// 程序配置值
    /// </summary>
    class AppSettingValue
    {
        private const string IsAutoStartupName = "IsAutoStartup";
        private const string IsAutoHideFormName = "IsAutoHideForm";
        private const string SearchUrlName = "SearchUrl";
        private const string ExplorerPathName = "ExplorerPath";
        public const string GoogleSearchEngine = "https://www.google.com/search?q=${word}";

        /// <summary>
        /// 是否开机自启动
        /// </summary>
        public static bool IsAutoStartup
        {
            get => AllSettingClass.GetSettingBooleanValueFor(IsAutoStartupName);
            set => ChangeAutoStartUp(value);
        }

        /// <summary>  
        /// 更改是否开机自启动
        /// </summary>  
        /// <param name="isAutoStartup">是否开机自启动</param>  
        public static void ChangeAutoStartUp(bool isAutoStartup)
        {
            bool isSuccessful = true;
            string executablePath = Application.ExecutablePath; //可执行文件路径
            string programName = Path.GetFileNameWithoutExtension(executablePath); //程序名称
            try
            {
                const string registryRunPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
                //当前用户的注册表
                RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(registryRunPath);
                if (registryKey == null) return;
                object preValue = registryKey.GetValue(programName);
                //与之前的配置不一样，才会应用
                if (isAutoStartup && preValue == null)
                {
                    registryKey.SetValue(programName, executablePath); //开启自启动
                }
                else if (executablePath.Equals(preValue))
                {
                    registryKey.DeleteValue(programName, false); //关闭自启动
                }

                registryKey.Close();
            }
            catch (Exception e)
            {
                isSuccessful = false;
                MessageBox.Show(@"设置开机自启动异常：" + e.Message);
            }

            if (isSuccessful)
            {
                AllSettingClass.ChangeSettingValueFor(IsAutoStartupName, isAutoStartup.ToString().ToLower());
            }
        }

        /// <summary>
        /// 命令输入框失去焦点后，是否自动隐藏主窗口
        /// </summary>
        public static bool IsAutoHideForm
        {
            get => AllSettingClass.GetSettingBooleanValueFor(IsAutoHideFormName);
            set => AllSettingClass.ChangeSettingValueFor(IsAutoHideFormName, value.ToString().ToLower());
        }

        /// <summary>
        /// 搜索引擎URL
        /// </summary>
        public static string SearchEngineUrl
        {
            get => AllSettingClass.GetSettingStringValueFor(SearchUrlName);
            set => AllSettingClass.ChangeSettingValueFor(SearchUrlName, value);
        }

        public static string ExplorerPath
        {
            get => AllSettingClass.GetSettingStringValueFor(ExplorerPathName);
            set => AllSettingClass.ChangeSettingValueFor(ExplorerPathName, value);
        }
    }
}