using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ShortCommand.Class.Helper;
using ShortCommand.Class.Setting;

namespace ShortCommand.ViewForm
{
    public partial class SearchEngineForm : PanelForm
    {
        private readonly Dictionary<string, RadioButton> searchEngineUrlMap;
        private string searchEngineUrl;
        private string lastCustomUrl;

        public SearchEngineForm()
        {
            InitializeComponent();
            searchEngineUrlMap = new Dictionary<string, RadioButton>()
            {
                {AppSettingValue.GoogleSearchEngine, rbtnGoogle},
                {"https://www.baidu.com/s?wd=${word}", rbtnBaidu},
                {"https://cn.bing.com/search?q=${word}", rbtnBing}
            };
        }

        private void SearchEngineForm_Load(object sender, EventArgs e)
        {
            ReadFormConfig();
            IsLoaded = true;
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
            txbExplorerPath.Text = AppSettingValue.ExplorerPath;
        }

        public override void UpdateFormConfig()
        {
            if (!IsLoaded)
            {
                return;
            }
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
            AppSettingValue.ExplorerPath = txbExplorerPath.Text;
        }

        private void rbtnCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCustom.Checked)
            {
                txbSearchEngineUrl.Text = lastCustomUrl;
            }
            else
            {
                lastCustomUrl = txbSearchEngineUrl.Text;
                txbSearchEngineUrl.Text = string.Empty;
            }

            txbSearchEngineUrl.Enabled = rbtnCustom.Checked;
        }

        private void btnExplorerPath_Click(object sender, EventArgs e)
        {
            string filePath = FileAndDirectoryHelper.OpenExeFileDialog();
            if (!filePath.IsNullOrEmpty())
            {
                txbExplorerPath.Text = filePath;
            }
        }
    }
}