using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Windows.Forms;
using ShortCommand.Class.Command;
using ShortCommand.Class.Display;
using ShortCommand.Class.Helper;
using ShortCommand.Class.HotKey;
using ShortCommand.Class.Setting;
using ShortCommand.Class.Speech;
using ShortCommand.ViewForm;

namespace ShortCommand
{
    public partial class MainForm : Form
    {
        private const int MaxShortNameItemsCount = 5; //下拉框历史命令上限
        private ShortCommandClass shortCommand; //快捷命令
        private ToolTipDisplayClass toolTipDisplay;
        private bool isAutoHideForm;
        private SettingPanelForm settingPanelForm;
        private SpeechRecognition speechRecognition;

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        #region 初始化

        /// <summary>
        /// 初始化程序
        /// </summary>
        private void InitForm()
        {
            shortCommand = new ShortCommandClass();
            ShowFormAndFocusInputBox();
            InitShortNameComboBox();
            AddAutoCompleteSource();
            cboShortName.DrawMode = DrawMode.OwnerDrawFixed;
            toolTipDisplay = new ToolTipDisplayClass(cboShortName, shortCommand);
            isAutoHideForm = AppSettingValue.IsAutoHideForm;
            cboShortName.LostFocus += OnLostFocus;
            ISpeechRecognitionStrategy recognitionStrategy =
                new DefaultSpeechRecognition(SpeechRecognizedHandler, shortCommand.GetShortNames());
            speechRecognition = new SpeechRecognition(recognitionStrategy);
            UpdateSpeechState();
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            if (isAutoHideForm && !ContainsFocus)
            {
                HideForm();
            }
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitShortNameComboBox()
        {
            cboShortName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboShortName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboShortName.TabIndex = 0;
        }

        /// <summary>
        /// 添加自动补全字符串资源
        /// </summary>
        private void AddAutoCompleteSource()
        {
            cboShortName.AutoCompleteCustomSource.Clear();
            cboShortName.AutoCompleteCustomSource.AddRange(shortCommand.GetShortNames());
        }

        #endregion

        #region 执行命令

        //按下回车键
        private void cboShortName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            RunCommand(cboShortName.Text);
        }

        public void RunCommand(string originalShortName)
        {
            toolTipDisplay.ShowToolTip(originalShortName);
            shortCommand.RunCommandByShortNameOf(originalShortName, BeginInvokeInsertShortName);
        }

        private void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            string recognizedName = e.Result.Text;
            bool updateEnabledSpeech = speechRecognition.UpdateEnabledSpeech(recognizedName);
            chbEnabledSpeech.Checked = updateEnabledSpeech;
            if (!updateEnabledSpeech || SpeechRecognition.IsOpenSpeechText(recognizedName))
            {
                return;
            }

            cboShortName.Text = recognizedName;
            RunCommand(recognizedName);
        }


        /// <summary>
        /// 异步执行插入简称
        /// </summary>
        private void BeginInvokeInsertShortName()
        {
            BeginInvoke(new Action(InsertShortNameToFirstItemOfCombobox));
        }

        /// <summary>
        /// 插入简称到下拉框首项
        /// </summary>
        private void InsertShortNameToFirstItemOfCombobox()
        {
            string currentCommand = cboShortName.Text;
            RemoveSameCommand(currentCommand);
            KeepShortNameItemsCount();

            cboShortName.Items.Insert(0, currentCommand);
            cboShortName.Text = currentCommand;
            cboShortName.SelectAll();
        }

        /// <summary>
        /// 保持简称下拉框子项的个数
        /// </summary>
        private void KeepShortNameItemsCount()
        {
            while (cboShortName.Items.Count >= MaxShortNameItemsCount)
            {
                cboShortName.Items.RemoveAt(cboShortName.Items.Count - 1);
            }
        }

        /// <summary>
        /// 移除相同的下拉框子项
        /// </summary>
        /// <param name="currentCommand"></param>
        private void RemoveSameCommand(string currentCommand)
        {
            for (int i = cboShortName.Items.Count - 1; i >= 0; i--)
            {
                if (cboShortName.Items[i].ToString().Equals(currentCommand))
                {
                    cboShortName.Items.RemoveAt(i);
                }
            }
        }

        #endregion

        #region 显示或最小化主程序快捷键

        private const int WmHotKey = 0x312; //快捷键
        private const int WmCreate = 0x1; //创建窗口
        private const int WmDestroy = 0x2; //销毁窗口
        private const int CtrlAndE = 0x9527; //快捷键编号

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);
            switch (message.Msg)
            {
                case WmHotKey:
                    if (message.WParam.ToInt32() == CtrlAndE)
                    {
                        ActivateOrHideForm();
                    }

                    break;
                //创建窗口
                case WmCreate:
                    RegisterKey();
                    break;
                //销毁窗口
                case WmDestroy:
                    UnRegisterKey();
                    break;
            }
        }

        /// <summary>
        /// 激活或隐藏主界面
        /// </summary>
        private void ActivateOrHideForm()
        {
            if (WindowState == FormWindowState.Normal)
            {
                HideForm();
            }
            else
            {
                ShowFormAndFocusInputBox();
            }
        }

        /// <summary>
        /// 隐藏窗口
        /// </summary>
        private void HideForm()
        {
            Visible = false;
            WindowState = FormWindowState.Minimized;
            ShowOrHideMenuItem.Text = @"显示";
        }

        /// <summary>
        /// 显示窗口，并为输入框获取焦点
        /// </summary>
        private void ShowFormAndFocusInputBox()
        {
            WindowState = FormWindowState.Normal;
            Visible = true;
            Activate();
            cboShortName.Focus();
            ShowOrHideMenuItem.Text = @"隐藏";
        }

        /// <summary>
        /// 注册热键
        /// </summary>
        private void RegisterKey()
        {
            SystemHotKey.RegisterKey(Handle, CtrlAndE, SystemHotKey.CombinationKeys.Ctrl, Keys.E);
        }

        /// <summary>
        /// 注销热键
        /// </summary>
        private void UnRegisterKey()
        {
            SystemHotKey.UnRegisterKey(Handle, CtrlAndE); //注销热键
        }

        #endregion

        #region 托盘功能

        //显示/隐藏
        private void ShowOrHideMenuItem_Click(object sender, EventArgs e)
        {
            ActivateOrHideForm();
            //            this.WindowState = this.WindowState == FormWindowState.Normal
            //                ? FormWindowState.Minimized
            //                : FormWindowState.Normal;
        }

        //退出
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            //直接关闭
            Dispose();
        }

        //点击托盘，激活程序
        private void appNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowFormAndFocusInputBox();
            }
        }

        #endregion

        #region 配置

        //配置窗口
        private void btnSettingForm_Click(object sender, EventArgs e)
        {
            if (settingPanelForm.IsNullOrDisposed())
            {
                settingPanelForm = new SettingPanelForm(shortCommand.ShortNameAndCommands);
                settingPanelForm.UpdateSettingsAction += UpdateSettings;
                settingPanelForm.Show();
            }
            else
            {
                settingPanelForm.Activate();
            }
        }

        /// <summary>
        /// 更新简称和命令
        /// </summary>
        /// <param name="inShortNameAndCommands"></param>
        private void UpdateSettings(Dictionary<string, string> inShortNameAndCommands)
        {
            isAutoHideForm = AppSettingValue.IsAutoHideForm;
            shortCommand.UpdateShortNameAndCommands(inShortNameAndCommands);

            speechRecognition.Phrases = shortCommand.GetShortNames();
            UpdateSpeechState();
            AddAutoCompleteSource();
        }

        private void UpdateSpeechState()
        {
            bool enableSpeech = AppSettingValue.EnableSpeech;
            speechRecognition.OpenOrClose(enableSpeech);
            chbEnabledSpeech.Checked = enableSpeech;
            chbEnabledSpeech.Visible = enableSpeech;
        }

        #endregion

        #region 主窗口事件

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; //取消关闭操作 表现为不关闭窗体
                HideForm(); //隐藏窗体
            }
            else
            {
                appNotifyIcon.Dispose();
            }
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            if (cboShortName.Bounds.Contains(MousePosition))
            {
                return;
            }

            toolTipDisplay.HideToolTip();
        }

        #endregion

        private void chbEnabledSpeech_CheckedChanged(object sender, EventArgs e)
        {
            speechRecognition.EnabledSpeech = chbEnabledSpeech.Checked;
        }
    }
}