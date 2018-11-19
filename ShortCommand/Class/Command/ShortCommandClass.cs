using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortCommand.Class.Helper;
using ShortCommand.Class.Setting;
using ShortCommand.Class.Setting.SettingItems;

namespace ShortCommand.Class.Command
{
    /// <summary>
    /// 快捷命令
    /// </summary>
    class ShortCommandClass
    {
        /// <summary>
        /// 简称和命令
        /// </summary>
        public Dictionary<string, string> ShortNameAndCommands { get; set; }

        private Dictionary<string, string> upperShortNameAndCommands; //大写的简称和命令，用于忽略大小写

        public ShortCommandClass()
        {
            ShortNameAndCommands = AllSettingClass.ReadCommandSettings();
            UpdateShortNameAndCommands(ShortNameAndCommands);
        }

        /// <summary>
        /// 获取简称集合
        /// </summary>
        /// <returns></returns>
        public string[] GetShortNames()
        {
            return ShortNameAndCommands.Keys.ToArray();
        }

        /// <summary>
        /// 更新简称和命令
        /// </summary>
        public void UpdateShortNameAndCommands(Dictionary<string, string> inShortNameAndCommands)
        {
            ShortNameAndCommands = inShortNameAndCommands;
            upperShortNameAndCommands = new Dictionary<string, string>();
            foreach (var shortNameAndExePath in ShortNameAndCommands)
            {
                string upperShortName = shortNameAndExePath.Key.ToUpper();
                if (upperShortNameAndCommands.ContainsKey(upperShortName))
                {
                    continue;
                }
                upperShortNameAndCommands.Add(upperShortName, shortNameAndExePath.Value);
            }
        }

        /// <summary>
        /// 运行命令
        /// </summary>
        public void RunCommandByShortNameOf(string originalShortName, Action invokeInsertShortName)
        {
            if (originalShortName.IsNullOrEmpty())
            {
                return;
            }
            var command = GetCommand(originalShortName);
            if (command.IsNullOrEmpty())
            {
                return;
            }
            Task.Factory.StartNew(() =>
            {
                string errorInfo = WinCommandClass.RunCommandLineInCmdAndExitCmd(command);
                if (string.IsNullOrEmpty(errorInfo) && invokeInsertShortName != null)
                {
                    invokeInsertShortName();
                }
                else
                {
                    MessageBoxHelper.ShowErrorMessageBox(errorInfo);
                }
            });
        }

        /// <summary>
        /// 获取命令
        /// </summary>
        /// <param name="originalShortName">简称</param>
        /// <returns></returns>
        private string GetCommand(string originalShortName)
        {
            //简称是URL网址，直接打开网页
            if (IsWellFormedUriString(originalShortName))
            {
                return string.Format("start \"\" \"{0}\"", originalShortName);
            }

            string upperShortName = originalShortName.ToUpper();
            string command;
            //简称不存在，则搜索该简称
            if (!upperShortNameAndCommands.TryGetValue(upperShortName, out command))
            {

                return GetSearchCommand(originalShortName);
            }

            //满足URI格式
            if (IsWellFormedUriString(command))
            {
                //加上双引号
                return GetStartCommandWithQuote(command);
            }

            //是目录或文件路径
            if (FileAndDirectoryHelper.IsDirectoryOrFilePath(command))
            {
                //路径不存在
                if (FileAndDirectoryHelper.PathIsNotExists(command))
                {
                    MessageBoxHelper.ShowErrorMessageBox(string.Format(@"对应路径不存在：{0}", command));
                    return string.Empty;
                }

                //转义路径的特殊符号（空格等），加上空标题和双引号
                //START ["title"] [/D path]
                return GetStartCommandWithQuote(command);
            }

            return string.Format("start \"\" {0}", command);
        }

        /// <summary>
        /// 是格式正确的绝对URI
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static bool IsWellFormedUriString(string command)
        {
            return Uri.IsWellFormedUriString(command, UriKind.Absolute);
        }

        /// <summary>
        /// 获取带双引号的开始命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static string GetStartCommandWithQuote(string command)
        {
            return string.Format("start \"\" \"{0}\"", command);
        }

        /// <summary>
        /// 获取搜索命令
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        private static string GetSearchCommand(string shortName)
        {
            //对要搜索的字符串进行转义编码，因为URL中某些特殊字符不能直接使用
            string escapeShortName = Uri.EscapeDataString(shortName);
            var searchEngineUrl = SearchEngineClass.GetSearchEngineUrl();
            return string.Format("start \"\" \"{0}{1}\"", searchEngineUrl, escapeShortName);
        }

    }
}
