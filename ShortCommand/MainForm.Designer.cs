using System.Windows.Forms;

namespace ShortCommand
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSettingForm = new System.Windows.Forms.Button();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowOrHideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboShortName = new System.Windows.Forms.ComboBox();
            this.chbEnabledSpeech = new System.Windows.Forms.CheckBox();
            this.NotifyIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettingForm
            // 
            this.btnSettingForm.Location = new System.Drawing.Point(331, 46);
            this.btnSettingForm.Name = "btnSettingForm";
            this.btnSettingForm.Size = new System.Drawing.Size(75, 23);
            this.btnSettingForm.TabIndex = 1;
            this.btnSettingForm.Text = "配置";
            this.btnSettingForm.UseVisualStyleBackColor = true;
            this.btnSettingForm.Click += new System.EventHandler(this.btnSettingForm_Click);
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.ContextMenuStrip = this.NotifyIconMenuStrip;
            this.appNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("appNotifyIcon.Icon")));
            this.appNotifyIcon.Text = "快捷命令";
            this.appNotifyIcon.Visible = true;
            this.appNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.appNotifyIcon_MouseClick);
            // 
            // NotifyIconMenuStrip
            // 
            this.NotifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowOrHideMenuItem,
            this.ExitMenuItem});
            this.NotifyIconMenuStrip.Name = "contextMenuStrip1";
            this.NotifyIconMenuStrip.Size = new System.Drawing.Size(130, 48);
            // 
            // ShowOrHideMenuItem
            // 
            this.ShowOrHideMenuItem.Name = "ShowOrHideMenuItem";
            this.ShowOrHideMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ShowOrHideMenuItem.Text = "显示/隐藏";
            this.ShowOrHideMenuItem.Click += new System.EventHandler(this.ShowOrHideMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ExitMenuItem.Text = "退出";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // cboShortName
            // 
            this.cboShortName.Font = new System.Drawing.Font("宋体", 15F);
            this.cboShortName.FormattingEnabled = true;
            this.cboShortName.Location = new System.Drawing.Point(12, 12);
            this.cboShortName.Name = "cboShortName";
            this.cboShortName.Size = new System.Drawing.Size(394, 28);
            this.cboShortName.TabIndex = 5;
            this.cboShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboShortName_KeyDown);
            // 
            // chbEnabledSpeech
            // 
            this.chbEnabledSpeech.AutoSize = true;
            this.chbEnabledSpeech.Location = new System.Drawing.Point(13, 46);
            this.chbEnabledSpeech.Name = "chbEnabledSpeech";
            this.chbEnabledSpeech.Size = new System.Drawing.Size(96, 16);
            this.chbEnabledSpeech.TabIndex = 6;
            this.chbEnabledSpeech.Text = "语音识别模式";
            this.chbEnabledSpeech.UseVisualStyleBackColor = true;
            this.chbEnabledSpeech.CheckedChanged += new System.EventHandler(this.chbEnabledSpeech_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 82);
            this.Controls.Add(this.chbEnabledSpeech);
            this.Controls.Add(this.cboShortName);
            this.Controls.Add(this.btnSettingForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "快捷命令";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.NotifyIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettingForm;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowOrHideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ComboBox cboShortName;
        private CheckBox chbEnabledSpeech;
    }
}

