using System.Windows.Forms;

namespace ShortCommand.Class.Helper
{
    /// <summary>
    /// 窗口帮助类
    /// </summary>
    static class FormHelper
    {
        /// <summary>
        /// 窗口为空，或已经释放
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static bool IsNullOrDisposed(this Form form)
        {
            return form == null || form.IsDisposed;
        }

    }
}
