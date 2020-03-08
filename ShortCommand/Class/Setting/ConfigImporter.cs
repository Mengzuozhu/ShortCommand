using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShortCommand.Class.Command;
using ShortCommand.Class.Helper;
using ShortCommand.ViewForm;

namespace ShortCommand.Class.Setting
{
    /// <summary>配置导入</summary>
    public class ConfigImporter
    {
        /// <summary>
        ///   <para>Imports the config file.</para>
        /// </summary>
        /// <param name="commandTableHandler">The command table handler.</param>
        public static void ImportConfig(ShortCommandTableHandler commandTableHandler)
        {
            string filePath = FileAndDirectoryHelper.OpenXmlFileDialog();
            Dictionary<string, string> importCommandConfig = CommandConfigHandler.ReadCommandConfigFile(filePath);
            if (importCommandConfig == null || importCommandConfig.Count <= 0) return;

            List<CurrentAndImportCommand> sharedCommands = new List<CurrentAndImportCommand>();
            Dictionary<string, string> nameAndCommandCopy =
                new Dictionary<string, string>(commandTableHandler.UpdateNameAndCommandFromTable());
            foreach (var importPair in importCommandConfig)
            {
                string importCommand = importPair.Value;
                if (FileAndDirectoryHelper.IsInvalidPath(importCommand))
                {
                    continue;
                }

                string name = importPair.Key;
                if (nameAndCommandCopy.TryGetValue(name, out var currentCommand))
                {
                    if (currentCommand.Equals(importCommand)) continue;
                    sharedCommands.Add(new CurrentAndImportCommand(name, currentCommand, importCommand));
                }
                else
                {
                    nameAndCommandCopy[name] = importCommand;
                }
            }

            //有相同的快捷命令冲突
            if (sharedCommands.Count > 0)
            {
                ShowCommandCompareForm(sharedCommands, nameAndCommandCopy, commandTableHandler);
            }
            else if (!nameAndCommandCopy.SequenceEqual(commandTableHandler.ShortNameAndCommands))
            {
                commandTableHandler.UpdateShortNameAndCommands(nameAndCommandCopy);
            }
        }

        private static void ShowCommandCompareForm(List<CurrentAndImportCommand> sharedCommands,
            Dictionary<string, string> shortNameAndCommands, ShortCommandTableHandler commandTableHandler)
        {
            CommandCompareForm commandCompareForm = new CommandCompareForm(sharedCommands, shortNameAndCommands)
            {
                StartPosition = FormStartPosition.CenterScreen,
                UpdateNameAndCommandAction = commandTableHandler.UpdateShortNameAndCommands
            };
            commandCompareForm.ShowDialog();
        }

        public class CurrentAndImportCommand
        {
            public string Name { get; set; }
            public string CurrentCommand { get; set; }

            public string ImportCommand { get; set; }

            public CurrentAndImportCommand(string shortName, string currentCommand, string importCommand)
            {
                Name = shortName;
                CurrentCommand = currentCommand;
                ImportCommand = importCommand;
            }
        }
    }
}