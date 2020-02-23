using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ShortCommand.Class.Command;
using ShortCommand.Class.Helper;
using ShortCommand.Class.Setting;

namespace ShortCommand.ViewForm
{
    /// <summary>
    /// 配置窗口
    /// </summary>
    public partial class SettingForm : PanelForm
    {
        private int selectRowIndex = -1; //选择行的索引
        private object cellBeginEditValue; //单元格开始编辑的值
        private readonly ShortCommandTableClass shortCommandTable; //简命令表格
        private FinderForm finderForm; //查找窗口

        public SettingForm(Dictionary<string, string> shortNameAndCommands)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true; //使窗口支持快捷键
            shortCommandTable = new ShortCommandTableClass(shortNameAndCommands);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        #region 初始化

        /// <summary>
        /// 初始化窗口
        /// </summary>
        private void InitForm()
        {
//            MinimumSize = new Size(600, 500); //设置窗口最小尺寸
            InitDataGridView();
            ChangeColumnWidth();
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        private void InitDataGridView()
        {
            dgvCommandAndNames.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgvCommandAndNames.DataSource = shortCommandTable.ShortNameAndCommandsTable;
        }

        /// <summary>
        /// 改变表格列宽度
        /// </summary>
        private void ChangeColumnWidth()
        {
            int width = grbCommand.Width - dgvCommandAndNames.RowHeadersWidth - 10;
            int quarter = width / 4;

            dgvCommandAndNames.Columns[0].Width = width - quarter;
            dgvCommandAndNames.Columns[1].Width = quarter;
        }

        #endregion

        #region 容器大小变化

        private void grbCommand_Resize(object sender, EventArgs e)
        {
            ChangeColumnWidth();
        }

        #endregion

        #region 数据表操作

        //行表头菜单
        private void dgvCommandAndNames_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectRowIndex = e.RowIndex;
                RowContextMenuStrip.Show(MousePosition.X, MousePosition.Y);
            }
        }

        //移除行
        private void DeleteRowMenuItem_Click(object sender, EventArgs e)
        {
            if (selectRowIndex == -1 || selectRowIndex >= dgvCommandAndNames.Rows.Count - 1) return;

            dgvCommandAndNames.Rows.RemoveAt(selectRowIndex);
        }

        //修改文件路径
        private void ChangeFilePathMenuItem_Click(object sender, EventArgs e)
        {
            shortCommandTable.ChangeFilePath(selectRowIndex);
        }

        //修改文件夹路径
        private void ChangeFolderPathMenuItem_Click(object sender, EventArgs e)
        {
            shortCommandTable.ChangeFolderPath(selectRowIndex);
        }

        #endregion

        #region 拖拽文件或文件夹

        //拖拽中
        private void dgvCommandAndNames_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //拖拽完成
        private void dgvCommandAndNames_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            shortCommandTable.AddDragFilesToRow(filePaths);
            BeginEditLastRowShortName();
        }

        /// <summary>
        /// 开始编辑最后一行的简称
        /// </summary>
        private void BeginEditLastRowShortName()
        {
            int lastRowIndex = dgvCommandAndNames.RowCount - 2;
            dgvCommandAndNames.CurrentCell =
                dgvCommandAndNames.Rows[lastRowIndex].Cells[ShortCommandTableClass.ShortName];
            dgvCommandAndNames.BeginEdit(true);
        }

        #endregion

        #region 显示行号

        //添加行
        private void dgvCommandAndNames_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //从新添的行开始计算显示行号
            DisplayRowHeaderNumber(e.RowIndex);
        }

        //删除行
        private void dgvCommandAndNames_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //从删除的行开始计算显示行号
            DisplayRowHeaderNumber(e.RowIndex);
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        private void DisplayRowHeaderNumber(int beginRowIndex)
        {
            for (int i = beginRowIndex; i < dgvCommandAndNames.Rows.Count; i++)
            {
                dgvCommandAndNames.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        #endregion

        #region 单元格编辑

        //单元格开始编辑
        private void dgvCommandAndNames_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            //不是简称列
            if (columnIndex != 1) return;

            int rowIndex = e.RowIndex;
            cellBeginEditValue = dgvCommandAndNames.Rows[rowIndex].Cells[columnIndex].Value;
        }

        //单元格结束编辑
        private void dgvCommandAndNames_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckCellOfSameShortName(e);
        }

        /// <summary>
        /// 检查简称相同的单元格
        /// </summary>
        /// <param name="e"></param>
        private void CheckCellOfSameShortName(DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            //编辑的单元格不在简称列
            if (columnIndex != 1) return;

            int currentRowIndex = e.RowIndex;
            object value = dgvCommandAndNames.Rows[currentRowIndex].Cells[columnIndex].Value;
            if (value == null)
            {
                return;
            }

            string shortName = value.ToString();
            int sameCellRowIndex = shortCommandTable.GetSameShortNameIgnoreCaseIndex(shortName, currentRowIndex);
            if (sameCellRowIndex != -1)
            {
                dgvCommandAndNames.Rows[sameCellRowIndex].Selected = true;
                MessageBoxHelper.ShowWarningMessageBox(string.Format("编辑失败，因为忽略大小写的快捷命令已存在，在第{0}行！",
                    sameCellRowIndex + 1));
                //恢复编辑之前的值
                dgvCommandAndNames.Rows[currentRowIndex].Cells[columnIndex].Value = cellBeginEditValue;
            }
        }

        #endregion

        #region 查找

        //查找
        private void btnFind_Click(object sender, EventArgs e)
        {
            ShowFinderForm();
        }


        private void SettingForm_KeyDown(object sender, KeyEventArgs e)
        {
            //查找快捷键Ctrl+F
            if (e.Control && e.KeyCode == Keys.F)
            {
                ShowFinderForm();
            }
        }

        /// <summary>
        /// 显示查找窗口
        /// </summary>
        private void ShowFinderForm()
        {
            if (finderForm.IsNullOrDisposed())
            {
                finderForm = new FinderForm(dgvCommandAndNames)
                {
                    StartPosition = FormStartPosition.Manual
                };
                //居中显示在配置窗口中
                var x = Location.X + (Width - finderForm.Width) / 2;
                var y = Location.Y + (Height - finderForm.Height) / 2;
                finderForm.Location = new Point(x, y);
                finderForm.Show();
            }
            else
            {
                finderForm.Activate();
            }
        }

        #endregion

        //显示重复命令
        private void chbShowRepeatedCommand_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowRepeatedCommand.Checked)
            {
                dgvCommandAndNames.DataSource = shortCommandTable.ComputeOnlyIncludeRepeatedCommandsTable();
            }
            else
            {
                dgvCommandAndNames.DataSource = shortCommandTable.MergeRepeatedAndDistinctTable();
            }
        }

        //清除无效路径
        private void btnClearInvalidPath_Click(object sender, EventArgs e)
        {
            shortCommandTable.ClearInvalidPath();
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        public override void UpdateFormConfig()
        {
            //若当前显示的是重复项表格，则合并后再写入配置
            if (chbShowRepeatedCommand.Checked)
            {
                shortCommandTable.MergeRepeatedAndDistinctTable();
            }

            shortCommandTable.UpdateShortNameAndCommands();
            AllSettingClass.WriteAllCommandConfigs(GetShortNameAndCommands());
        }

        public Dictionary<string, string> GetShortNameAndCommands()
        {
            return shortCommandTable.ShortNameAndCommands;
        }

        //关闭
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finderForm.IsNullOrDisposed())
            {
                return;
            }

            finderForm.Dispose();
        }
    }
}