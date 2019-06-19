using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using ShortCommand.Class.Helper;

namespace ShortCommand.Class.Setting
{
    /// <summary>
    /// 程序配置值
    /// </summary>
    class AppSettingValue
    {
        private const string IsAutoStartupName = "IsAutoStartup";
        private const string IsTopmostName = "IsTopmost";
        private const string IsAutoHideFormName = "IsAutoHideForm";
        private const string SearchEngine = "SearchEngine";
        private const string Google = "google";
        private const string Baidu = "baidu";
        private const string BaiduSearchEngineUrl = "https://www.baidu.com/s?wd=";
        private const string GoogleSearchEngineUrl = "https://www.google.com/search?q=";

        /// <summary>
        /// 是否开机自启动
        /// </summary>
        public static bool IsAutoStartup
        {
            get { return AllSettingClass.GetSettingBooleanValueFor(IsAutoStartupName); }
            set { ChangeAutoStartUp(value); }
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
                if (isAutoStartup)
                {
                    registryKey.SetValue(programName, executablePath); //开启自启动
                }
                else
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
                AllSettingClass.ChangeSettingValueFor(IsAutoStartupName, isAutoStartup.BoolToString());
            }
        }

        /// <summary>
        /// 程序是否置顶
        /// </summary>
        public static bool IsTopmost
        {
            get { return AllSettingClass.GetSettingBooleanValueFor(IsTopmostName); }
            set { AllSettingClass.ChangeSettingValueFor(IsTopmostName, value.BoolToString()); }
        }

        /// <summary>
        /// 是否是谷歌搜索
        /// </summary>
        public static bool IsGoogleSearch
        {
            get
            {
                string searchEngine = AllSettingClass.GetSettingStringValueFor(SearchEngine).ToLower();
                return Google.Equals(searchEngine);
            }
            set { AllSettingClass.ChangeSettingValueFor(SearchEngine, value ? Google : Baidu); }
        }

        /// <summary>
        /// 命令输入框失去焦点后，是否自动隐藏主窗口
        /// </summary>
        public static bool IsAutoHideForm
        {
            get { return AllSettingClass.GetSettingBooleanValueFor(IsAutoHideFormName); }
            set { AllSettingClass.ChangeSettingValueFor(IsAutoHideFormName, value.BoolToString()); }
        }

        /// <summary>
        /// 搜索引擎URL
        /// </summary>
        public static string SearchEngineUrl
        {
            get { return IsGoogleSearch ? GoogleSearchEngineUrl : BaiduSearchEngineUrl; }
        }
    }
}