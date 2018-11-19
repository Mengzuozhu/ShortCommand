using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ShortCommand.Class.Setting.SettingItems
{
    /// <summary>
    /// 开机自启动配置
    /// </summary>
    class AutoStartupClass
    {
        //自启动注册表路径
        private const string RegistryRunPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string IsAutoStartup = "IsAutoStartup";

        /// <summary>
        /// 获取开机自启动设置
        /// </summary>
        public static bool GetIsAutoStartup()
        {
            return AllSettingClass.GetSettingBooleanValueFor(IsAutoStartup);
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
                //当前用户的注册表
                RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(RegistryRunPath);
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
                ChangeIsAutoStartup(isAutoStartup);
            }
        }

        /// <summary>
        /// 修改开机自启动设置
        /// </summary>
        /// <param name="isAutoStartup"></param>
        private static void ChangeIsAutoStartup(bool isAutoStartup)
        {
            AllSettingClass.ChangeSettingValueFor(IsAutoStartup, AllSettingClass.BoolToString(isAutoStartup));
        }
    }
}
