
namespace ShortCommand.Class.Helper
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    static class StringExtension
    {
        /// <summary>
        /// 字符串是否为null或空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
