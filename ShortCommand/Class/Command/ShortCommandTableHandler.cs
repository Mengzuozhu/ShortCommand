﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ShortCommand.Class.Helper;

namespace ShortCommand.Class.Command
{
    /// <summary>
    /// 简命令表格
    /// </summary>
    public class ShortCommandTableHandler
    {
        public const string RealCommandName = "命令/路径/网址"; //真正的命令
        public const string ShortName = "快捷命令"; //快捷命令
        private DataTable distinctCommandTable; //包含唯一命令的表格
        private DataTable repeatedCommandTable; //包含重复命令的表格

        /// <summary>
        /// 简称和命令表格
        /// </summary>
        public DataTable ShortNameAndCommandsTable { get; set; }

        public Dictionary<string, string> ShortNameAndCommands { get; private set; }

        public ShortCommandTableHandler(Dictionary<string, string> shortNameAndCommands)
        {
            this.ShortNameAndCommands = shortNameAndCommands;
            InitTable();
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        public void InitTable()
        {
            ShortNameAndCommandsTable = new DataTable();
            ShortNameAndCommandsTable.Columns.Add(RealCommandName);
            ShortNameAndCommandsTable.Columns.Add(ShortName);

            ReplaceDataTable();
        }

        private void ReplaceDataTable()
        {
            ShortNameAndCommandsTable.Rows.Clear();
            foreach (var shortNameAndExePath in ShortNameAndCommands)
            {
                DataRow row = ShortNameAndCommandsTable.NewRow();
                row[RealCommandName] = shortNameAndExePath.Value;
                row[ShortName] = shortNameAndExePath.Key;
                ShortNameAndCommandsTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// 计算只包含重复命令的表格
        /// </summary>
        /// <returns></returns>
        public DataTable ComputeOnlyIncludeRepeatedCommandsTable()
        {
            repeatedCommandTable = ShortNameAndCommandsTable.Clone();
            distinctCommandTable = ShortNameAndCommandsTable.Clone();
            Dictionary<string, int> commandAndCount = GetCommandAndCount();

            foreach (DataRow dataRow in ShortNameAndCommandsTable.Rows)
            {
                string command = dataRow[RealCommandName].ToString();
                if (commandAndCount[command] > 1)
                {
                    repeatedCommandTable.ImportRow(dataRow);
                }
                else
                {
                    distinctCommandTable.ImportRow(dataRow);
                }
            }

            return repeatedCommandTable;
        }

        /// <summary>
        /// 获取命令和对应出现次数
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> GetCommandAndCount()
        {
            Dictionary<string, int> commandAndCount = new Dictionary<string, int>();
            foreach (DataRow dataRow in ShortNameAndCommandsTable.Rows)
            {
                string command = dataRow[RealCommandName].ToString();
                if (commandAndCount.ContainsKey(command))
                {
                    commandAndCount[command]++;
                }
                else
                {
                    commandAndCount[command] = 1;
                }
            }

            return commandAndCount;
        }

        /// <summary>
        /// 合并重复项和唯一项表格
        /// </summary>
        /// <returns></returns>
        public DataTable MergeRepeatedAndDistinctTable()
        {
            if (distinctCommandTable == null)
            {
                return ShortNameAndCommandsTable;
            }

            //重复项为空
            if (repeatedCommandTable.Rows.Count == 0)
            {
                ShortNameAndCommandsTable = distinctCommandTable;
                return ShortNameAndCommandsTable;
            }

            ShortNameAndCommandsTable = distinctCommandTable.Copy();
            ShortNameAndCommandsTable.Merge(repeatedCommandTable);
            return ShortNameAndCommandsTable;
        }

        /// <summary>
        /// 添加拖拽的文件路径到行
        /// </summary>
        /// <param name="filePaths"></param>
        public void AddDragFilesToRow(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                DataRow row = ShortNameAndCommandsTable.NewRow();
                row[RealCommandName] = filePath;
                SetDefaultShortNameForDragFile(filePath, row);
                ShortNameAndCommandsTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// 为拖拽文件设置默认快捷命令
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="row"></param>
        private void SetDefaultShortNameForDragFile(string filePath, DataRow row)
        {
            string fileName = Path.GetFileName(filePath);
            if (fileName == null) return;

            int i = 1;
            string newFileName = fileName;
            //若配置中存在同名快捷命令，则修改新增的文件名
            while (GetSameShortNameIgnoreCaseIndex(newFileName, -1) != -1)
            {
                newFileName = $"{fileName}({i++})";
            }

            //取拖拽文件的文件名作为默认快捷命令
            row[ShortName] = newFileName;
        }

        /// <summary>
        /// 清除无效路径
        /// </summary>
        public void ClearInvalidPath()
        {
            int invalidCount = 0;
            for (int i = ShortNameAndCommandsTable.Rows.Count - 1; i >= 0; i--)
            {
                string command = ShortNameAndCommandsTable.Rows[i][RealCommandName].ToString();
                //删除无效路径
                if (FileAndDirectoryHelper.IsInvalidPath(command))
                {
                    ShortNameAndCommandsTable.Rows.RemoveAt(i);
                    invalidCount++;
                }
            }

            MessageBoxHelper.ShowInfoMessageBox($"共清除{invalidCount}个无效路径。");
        }

        /// <summary>
        /// 更新简称和命令
        /// </summary>
        public Dictionary<string, string> UpdateNameAndCommandFromTable()
        {
            ShortNameAndCommands = new Dictionary<string, string>();
            for (int i = 0; i < ShortNameAndCommandsTable.Rows.Count; i++)
            {
                string shortName = ShortNameAndCommandsTable.Rows[i][ShortName].ToString();
                if (string.IsNullOrEmpty(shortName))
                {
                    continue;
                }

                string commandName = ShortNameAndCommandsTable.Rows[i][RealCommandName].ToString();
                ShortNameAndCommands[shortName] = commandName;
            }

            return ShortNameAndCommands;
        }

        /// <summary>
        /// 获取配置中相同快捷命令的行位置
        /// </summary>
        /// <param name="newShortName">新增的快捷命令</param>
        /// <param name="currentRowIndex">新增的快捷命令所在行索引，-1表示忽略该行索引</param>
        /// <returns></returns>
        public int GetSameShortNameIgnoreCaseIndex(string newShortName, int currentRowIndex)
        {
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase;
            for (int i = 0; i < ShortNameAndCommandsTable.Rows.Count; i++)
            {
                if (!ShortNameAndCommandsTable.Rows[i][ShortName].ToString()
                    .Equals(newShortName, stringComparison)) continue;

                if (i == currentRowIndex)
                {
                    continue;
                }

                return i;
            }

            return -1;
        }

        /// <summary>
        /// 修改文件路径
        /// </summary>
        /// <param name="selectRowIndex"></param>
        public void ChangeFilePath(int selectRowIndex)
        {
            string path = FileAndDirectoryHelper.OpenFileDialog(@"*.*|*.*");
            if (!string.IsNullOrEmpty(path))
            {
                ShortNameAndCommandsTable.Rows[selectRowIndex][RealCommandName] = path;
            }
        }

        /// <summary>
        /// 修改文件夹路径
        /// </summary>
        /// <param name="selectRowIndex"></param>
        public void ChangeFolderPath(int selectRowIndex)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            string path = folderBrowserDialog.SelectedPath;
            if (!string.IsNullOrEmpty(path))
            {
                ShortNameAndCommandsTable.Rows[selectRowIndex][RealCommandName] = path;
            }
        }

        public void UpdateShortNameAndCommands(Dictionary<string, string> newShortNameAndCommands)
        {
            ShortNameAndCommands = newShortNameAndCommands;
            ReplaceDataTable();
        }
    }
}