
namespace ShortCommand.Class.Setting.SettingItems
{
    /// <summary>
    /// 搜索引擎配置
    /// </summary>
    class SearchEngineClass
    {
        private const string SearchEngine = "SearchEngine";
        private const string Google = "google";
        private const string Baidu = "baidu";
        private const string BaiduSearchEngineUrl = "https://www.baidu.com/s?wd=";
        private const string GoogleSearchEngineUrl = "https://www.google.com/search?q=";

        /// <summary>
        /// 获取搜索引擎配置
        /// </summary>
        /// <returns></returns>
        private static string GetSearchEngine()
        {
            return AllSettingClass.GetSettingStringValueFor(SearchEngine);
        }

        /// <summary>
        /// 获取搜索引擎URL
        /// </summary>
        /// <returns></returns>
        public static string GetSearchEngineUrl()
        {
            return IsGoogleSearch() ? GoogleSearchEngineUrl : BaiduSearchEngineUrl;
        }

        /// <summary>
        /// 是否谷歌搜索引擎
        /// </summary>
        /// <returns></returns>
        public static bool IsGoogleSearch()
        {
            string searchEngine = GetSearchEngine().ToLower();
            return Google.Equals(searchEngine);
        }

        /// <summary>
        /// 写入搜索引擎配置
        /// </summary>
        /// <param name="isGoogleSearch"></param>
        public static void WriteSearchEngine(bool isGoogleSearch)
        {
            AllSettingClass.ChangeSettingValueFor(SearchEngine, isGoogleSearch ? Google : Baidu);
        }

    }

}
