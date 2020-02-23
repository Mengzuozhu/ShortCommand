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
    public partial class SearchEngineForm : PanelForm
    {
        public SearchEngineForm()
        {
            InitializeComponent();
        }

        private void SearchEngineForm_Load(object sender, EventArgs e)
        {
            ReadFormConfig();
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