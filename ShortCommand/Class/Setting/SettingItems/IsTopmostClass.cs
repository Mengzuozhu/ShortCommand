
namespace ShortCommand.Class.Setting.SettingItems
{
    /// <summary>
    /// 是否置顶配置
    /// </summary>
    class IsTopmostClass
    {
        private const string IsTopmost = "IsTopmost";

        /// <summary>
        /// 获取是否置顶配置
        /// </summary>
        public static bool GetIsTopmost()
        {
            return AllSettingClass.GetSettingBooleanValueFor(IsTopmost);
        }

        /// <summary>
        /// 修改是否置顶配置
        /// </summary>
        /// <param name="isTopmost"></param>
        public static void ChangeIsTopmost(bool isTopmost)
        {
            AllSettingClass.ChangeSettingValueFor(IsTopmost, AllSettingClass.BoolToString(isTopmost));
        }

    }
}
