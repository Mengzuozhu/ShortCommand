using System.Text.RegularExpressions;

namespace ShortCommand.Class.Helper
{
    public class StringUtil
    {
        public static readonly Regex Regex = new Regex(@"[\u4e00-\u9fa5]");

        /// <summary>
        /// Determines whether the specified string contains chinese.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>
        ///   <c>true</c> if the specified string contains chinese; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsChinese(string str)
        {
            return Regex.IsMatch(str);
        }
    }
}