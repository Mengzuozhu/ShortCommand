using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ShortCommand.Class.Helper;

namespace ShortCommand.ViewForm
{
    /// <summary>
    /// 总配置窗口
    /// </summary>
    public partial class SettingPanelForm : Form
    {
        private readonly Dictionary<string, string> shortNameAndCommands;
        private Dictionary<string, PanelForm> configForms;

        #region 窗口

        private Form currentForm;
        private PanelForm commonSettingForm;
        private PanelForm settingForm;
        private PanelForm searchEngineForm;

        #endregion

        public SettingPanelForm(Dictionary<string, string> shortNameAndCommands)
        {
            InitializeComponent();
            this.shortNameAndCommands = shortNameAndCommands;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void SettingPanelForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        #region 初始化

        /// <summary>
        /// 初始化窗口
        /// </summary>
        private void InitForm()
        {
            InitConfigForms();
            foreach (PanelForm configForm in configForms.Values)
            {
                configForm.Dock = DockStyle.Top;
                configForm.Parent = parentPanel;
            }

            trvFormList.ExpandAll();
            ShowCurrentForm(settingForm);
        }

        /// <summary>
        /// 初始化配置窗口
        /// </summary>
        private void InitConfigForms()
        {
            settingForm = new SettingForm(shortNameAndCommands);
            commonSettingForm = new CommonSettingForm();
            searchEngineForm = new SearchEngineForm();
            configForms = new Dictionary<string, PanelForm>
            {
                {"命令配置", settingForm},
                {"通用", commonSettingForm},
                {"搜索引擎", searchEngineForm}
            };
        }

        #endregion

        #region 显示对应窗口

        private void trvFormList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvFormList.SelectedNode = e.Node;
            string nodeText = e.Node.Text;
            if (configForms.ContainsKey(nodeText))
            {
                ShowCurrentForm(configForms[nodeText]);
            }
        }

        /// <summary>
        /// 显示当前窗口
        /// </summary>
        /// <param name="form"></param>
        private void ShowCurrentForm(Form form)
        {
            //隐藏上一次的窗口
            if (!currentForm.IsNullOrDisposed())
            {
                currentForm.Hide();
            }

            currentForm = form;
            currentForm.Show();
        }

        #endregion

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (PanelForm configForm in configForms.Values)
            {
                configForm?.UpdateFormConfig();
            }
            Close();
        }
    }
}