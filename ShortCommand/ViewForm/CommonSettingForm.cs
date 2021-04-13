using System;
using ShortCommand.Class.Setting;

namespace ShortCommand.ViewForm
{
    public partial class CommonSettingForm : PanelForm
    {
        public CommonSettingForm()
        {
            InitializeComponent();
        }

        private void CommonSettingForm_Load(object sender, EventArgs e)
        {
            ReadFormConfig();
            IsLoaded = true;
        }

        /// <inheritdoc />
        /// <summary>
        /// 初始化配置
        /// </summary>
        public override void ReadFormConfig()
        {
            IsAutoStartupMenuItem.Checked = AppSettingValue.IsAutoStartup;
            IsAutoHideFormMenuItem.Checked = AppSettingValue.IsAutoHideForm;
            EnableSpeechMenuItem.Checked = AppSettingValue.EnableSpeech;
        }

        /// <inheritdoc />
        public override void UpdateFormConfig()
        {
            if (!IsLoaded)
            {
                return;
            }
            if (AppSettingValue.IsAutoStartup != IsAutoStartupMenuItem.Checked)
            {
                AppSettingValue.IsAutoStartup = IsAutoStartupMenuItem.Checked;
            }

            AppSettingValue.IsAutoHideForm = IsAutoHideFormMenuItem.Checked;
            AppSettingValue.EnableSpeech = EnableSpeechMenuItem.Checked;
        }
    }
}