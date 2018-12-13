using System;
using System.Drawing;
using System.Windows.Forms;
using ShortCommand.Class.Command;

namespace ShortCommand.Class.Display
{
    /// <summary>
    /// 提示框显示
    /// </summary>
    class ToolTipDisplayClass
    {
        private ToolTip toolTip;
        private readonly ComboBox cboShortName;
        private readonly ShortCommandClass shortCommand;

        public ToolTipDisplayClass(ComboBox cboShortName, ShortCommandClass shortCommand)
        {
            this.cboShortName = cboShortName;
            this.shortCommand = shortCommand;
            cboShortName.DrawItem += cboShortName_DrawItem;
            cboShortName.TextChanged += cboShortName_TextChanged;
            InitToolTip();
        }

        /// <summary>
        /// 初始化提示框
        /// </summary>
        private void InitToolTip()
        {
            toolTip = new ToolTip
            {
                AutoPopDelay = 2000,
                InitialDelay = 0,
                ReshowDelay = 0,
                ShowAlways = false,
                BackColor = Color.White,
            };
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="currentName"></param>
        public void ShowToolTip(string currentName)
        {
            string command = shortCommand.GetCommandFormSetting(currentName);
            if (string.IsNullOrEmpty(command))
            {
                toolTip.Hide(cboShortName);
            }
            else
            {
                toolTip.Show(command, cboShortName, cboShortName.Left, cboShortName.Top - 40);
            }
        }

        /// <summary>
        /// 隐藏提示框
        /// </summary>
        public void HideToolTip()
        {
            toolTip.Hide(cboShortName);
        }

        private void cboShortName_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            //获取当前列表项的文字
            string text = cboShortName.Items[e.Index].ToString();
            e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                ShowToolTip(text);
            }
        }

        private void cboShortName_TextChanged(object sender, EventArgs e)
        {
            ShowToolTip(cboShortName.Text);
        }

    }
}
