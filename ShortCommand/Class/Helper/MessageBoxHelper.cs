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
            ShowMessageBox(message, @"错误", MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示提示消息框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInfoMessageBox(string message)
        {
            ShowMessageBox(message, @"消息", MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示提示消息框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowWarningMessageBox(string message)
        {
            ShowMessageBox(message, @"消提示息", MessageBoxIcon.Warning);
        }

        private static void ShowMessageBox(string message, string caption, MessageBoxIcon messageBoxIcon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, messageBoxIcon, MessageBoxDefaultButton.Button1);
        }
    }
}