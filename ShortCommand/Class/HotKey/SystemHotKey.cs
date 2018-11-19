using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShortCommand.Class.HotKey
{
    /// <summary>
    /// 系统热键
    /// </summary>
    class SystemHotKey
    {
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">热键ID</param>
        /// <param name="combinationKeys">组合键</param>
        /// <param name="key">热键代码</param>
        /// <returns>注册是否成功</returns>
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, CombinationKeys combinationKeys, Keys key);

        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">热键ID</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// 组合键
        /// </summary>
        [Flags]
        public enum CombinationKeys
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKeyId">热键ID</param>
        /// <param name="combinationKeys">组合键</param>
        /// <param name="key">热键代码</param>
        public static bool RegisterKey(IntPtr hwnd, int hotKeyId, CombinationKeys combinationKeys, Keys key)
        {
            return RegisterHotKey(hwnd, hotKeyId, combinationKeys, key);
        }

        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKeyId">热键ID</param>
        public static void UnRegisterKey(IntPtr hwnd, int hotKeyId)
        {
            UnregisterHotKey(hwnd, hotKeyId);
        }
    }


}
