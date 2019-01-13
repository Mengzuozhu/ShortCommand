using System.Windows.Forms;

namespace ShortCommand.Class.Helper
{
    /// <summary>
    /// 消息框帮助类
    /// </summary>
    class MessageBoxHelper
    {
        /// <summary>
        /// 显示错误消息框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 显示提示消息框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInfoMessageBox(string message)
        {
            MessageBox.Show(message, @"消息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        
        /// <summary>
        /// 显示提示消息框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowWarningMessageBox(string message)
        {
            MessageBox.Show(message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

    }
}
