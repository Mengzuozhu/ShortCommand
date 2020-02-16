using System;
using System.Windows.Forms;
using ShortCommand.Class.Finder;

namespace ShortCommand.ViewForm
{
    /// <summary>
    /// 查找窗口
    /// </summary>
    public partial class FinderForm : Form
    {
        private readonly FinderClass finder; //查找器

        public FinderForm(DataGridView dgvCommandAndNames)
        {
            InitializeComponent();
            dgvCommandAndNames.RowsRemoved += OnRowsRemoved;
            finder = new FinderClass(dgvCommandAndNames, lblMessage);
        }

        private void FinderForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        /// <summary>
        /// 初始化窗口
        /// </summary>
        private void InitForm()
        {
            chbIsAllWordMatch.Checked = false;
        }

        //删除行时，重置查找状态
        private void OnRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            finder.ResetFindState();
        }

        //查找文本变化
        private void txbFindText_TextChanged(object sender, EventArgs e)
        {
            finder.ResetFindState();
        }

        //全词匹配勾选变化
        private void chbIsAllWordMatch_CheckedChanged(object sender, EventArgs e)
        {
            finder.ResetFindState();
        }

        //匹配大小写勾选变化
        private void chbIsMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            finder.ResetFindState();
        }

        private void txbFindText_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //回车键，查找下一个
                case Keys.Enter:
                    FindNext();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        //查找下一个
        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        /// <summary>
        /// 查找下一个
        /// </summary>
        private void FindNext()
        {
            bool isAllWordMatch = chbIsAllWordMatch.Checked;
            bool isIgnoreCase = !chbIsMatchCase.Checked; //忽略大小写
            finder.FindNext(txbFindText.Text, isAllWordMatch, isIgnoreCase);
        }

        private void FinderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
