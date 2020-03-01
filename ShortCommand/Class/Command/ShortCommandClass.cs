using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ShortCommand.Class.Helper;
using ShortCommand.Class.Setting;

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
        private const string Word = "${word}";

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
            string command = GetCommandFormSetting(originalShortName);
            //对应的命令不存在
            if (string.IsNullOrEmpty(command))
            {
                return CommandNotInConfig(originalShortName);
            }

            //是目录或文件路径
            if (FileAndDirectoryHelper.IsDirectoryOrFilePath(command) &&
                FileAndDirectoryHelper.PathIsNotExists(command))
            {
                MessageBoxHelper.ShowErrorMessageBox($@"对应路径不存在：{command}");
                return string.Empty;
            }
            return IsWellFormedUriString(command) ? ConvertCommandWithQuote(command) : SimpleCommand(command);
        }

        private static string SimpleCommand(string command)
        {
            return $"start \"\" {command}";
        }

        private static string CommandNotInConfig(string originalShortName)
        {
            //输入是URL网址或文件路径，则直接打开
            if (IsWellFormedUriString(originalShortName) || FileAndDirectoryHelper.PathIsExists(originalShortName))
            {
                return ConvertCommandWithQuote(originalShortName);
            }

            return GetSearchCommand(originalShortName);
        }

        /// <summary>
        /// 从配置中获取命令
        /// </summary>
        /// <param name="originalShortName"></param>
        /// <returns></returns>
        public string GetCommandFormSetting(string originalShortName)
        {
            string upperShortName = originalShortName.ToUpper();
            return upperShortNameAndCommands.TryGetValue(upperShortName, out var command) ? command : string.Empty;
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
        /// 转换为带双引号的开始命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static string ConvertCommandWithQuote(string command)
        {
            string explorerPath = AppSettingValue.ExplorerPath;
            if (File.Exists(explorerPath) && IsWellFormedUriString(command))
            {
                return $"\"{explorerPath}\" \"{command}\"";
            }

            //转义路径的特殊符号（空格等），加上空标题和双引号
            //START ["title"] [/D path]
            return $"start \"\" \"{command}\"";
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
            var searchEngineUrl = AppSettingValue.SearchEngineUrl;
            if (searchEngineUrl.IsNullOrEmpty() || !searchEngineUrl.Contains(Word))
            {
                searchEngineUrl = AppSettingValue.GoogleSearchEngine;
            }

            string searchUrl = searchEngineUrl.Replace(Word, escapeShortName);
            return ConvertCommandWithQuote(searchUrl);
        }
    }
}