
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

        /// <summary>
        /// 布尔值转为字符串(true或false)
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string BoolToString(this bool b)
        {
            return b ? "true" : "false";
        }
    }
}
