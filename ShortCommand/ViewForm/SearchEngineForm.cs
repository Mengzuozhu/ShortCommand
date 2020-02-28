using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ShortCommand.Class.Setting;

namespace ShortCommand.ViewForm
{
    public partial class SearchEngineForm : PanelForm
    {
        private readonly Dictionary<string, RadioButton> searchEngineUrlMap;
        private string searchEngineUrl;

        public SearchEngineForm()
        {
            InitializeComponent();
            searchEngineUrlMap = new Dictionary<string, RadioButton>()
            {
                {AppSettingValue.GoogleSearchEngine, rbtnGoogle},
                {"https://www.baidu.com/s?wd=${word}", rbtnBaidu}
            };
        }

        private void SearchEngineForm_Load(object sender, EventArgs e)
        {
        }

        public override void ReadFormConfig()
        {
            searchEngineUrl = AppSettingValue.SearchEngineUrl;
            if (searchEngineUrlMap.TryGetValue(searchEngineUrl, out var radioButton))
            {
                radioButton.Checked = true;
            }
            else
            {
                rbtnCustom.Checked = true;
                txbSearchEngineUrl.Text = searchEngineUrl;
            }

            txbSearchEngineUrl.Enabled = rbtnCustom.Checked;
        }

        public override void UpdateFormConfig()
        {
            if (rbtnCustom.Checked)
            {
                searchEngineUrl = txbSearchEngineUrl.Text;
            }
            else
            {
                foreach (var keyValuePair in searchEngineUrlMap)
                {
                    if (keyValuePair.Value.Checked)
                    {
                        searchEngineUrl = keyValuePair.Key;
                        break;
                    }
                }
            }

            AppSettingValue.SearchEngineUrl = searchEngineUrl;
        }

        private void rbtnCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtnCustom.Checked)
            {
                txbSearchEngineUrl.Text = string.Empty;
            }

            txbSearchEngineUrl.Enabled = rbtnCustom.Checked;
        }
    }
}