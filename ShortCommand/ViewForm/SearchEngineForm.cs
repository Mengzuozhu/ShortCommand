using System;
using ShortCommand.Class.Setting;

namespace ShortCommand.ViewForm
{
    public partial class SearchEngineForm : PanelForm
    {
        public SearchEngineForm()
        {
            InitializeComponent();
        }

        private void SearchEngineForm_Load(object sender, EventArgs e)
        {
        }

        public override void ReadFormConfig()
        {
            rbtnGoogle.Checked = AppSettingValue.IsGoogleSearch;
            rbtnBaidu.Checked = !rbtnGoogle.Checked;
        }

        public override void UpdateFormConfig()
        {
            AppSettingValue.IsGoogleSearch = rbtnGoogle.Checked;
        }
    }
}