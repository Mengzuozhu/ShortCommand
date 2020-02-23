using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        }

        /// <inheritdoc />
        /// <summary>
        /// 初始化配置
        /// </summary>
        public override void ReadFormConfig()
        {
            IsAutoStartupMenuItem.Checked = AppSettingValue.IsAutoStartup;
            IsTopmostMenuItem.Checked = AppSettingValue.IsTopmost;
            IsAutoHideFormMenuItem.Checked = AppSettingValue.IsAutoHideForm;
        }

        /// <inheritdoc />
        public override void UpdateFormConfig()
        {
            AppSettingValue.IsAutoStartup = IsAutoStartupMenuItem.Checked;
            AppSettingValue.IsTopmost = IsTopmostMenuItem.Checked;
            AppSettingValue.IsAutoHideForm = IsAutoHideFormMenuItem.Checked;
        }
    }
}