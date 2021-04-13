namespace ShortCommand.ViewForm
{
    partial class CommonSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EnableSpeechMenuItem = new System.Windows.Forms.CheckBox();
            this.IsAutoHideFormMenuItem = new System.Windows.Forms.CheckBox();
            this.IsAutoStartupMenuItem = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EnableSpeechMenuItem);
            this.groupBox1.Controls.Add(this.IsAutoHideFormMenuItem);
            this.groupBox1.Controls.Add(this.IsAutoStartupMenuItem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(524, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "常规";
            // 
            // EnableSpeechMenuItem
            // 
            this.EnableSpeechMenuItem.AutoSize = true;
            this.EnableSpeechMenuItem.Location = new System.Drawing.Point(19, 71);
            this.EnableSpeechMenuItem.Name = "EnableSpeechMenuItem";
            this.EnableSpeechMenuItem.Size = new System.Drawing.Size(120, 16);
            this.EnableSpeechMenuItem.TabIndex = 3;
            this.EnableSpeechMenuItem.Text = "开启语音识别功能";
            this.EnableSpeechMenuItem.UseVisualStyleBackColor = true;
            // 
            // IsAutoHideFormMenuItem
            // 
            this.IsAutoHideFormMenuItem.AutoSize = true;
            this.IsAutoHideFormMenuItem.Location = new System.Drawing.Point(19, 49);
            this.IsAutoHideFormMenuItem.Name = "IsAutoHideFormMenuItem";
            this.IsAutoHideFormMenuItem.Size = new System.Drawing.Size(156, 16);
            this.IsAutoHideFormMenuItem.TabIndex = 2;
            this.IsAutoHideFormMenuItem.Text = "主界面失焦后，自动隐藏";
            this.IsAutoHideFormMenuItem.UseVisualStyleBackColor = true;
            // 
            // IsAutoStartupMenuItem
            // 
            this.IsAutoStartupMenuItem.AutoSize = true;
            this.IsAutoStartupMenuItem.Location = new System.Drawing.Point(19, 27);
            this.IsAutoStartupMenuItem.Name = "IsAutoStartupMenuItem";
            this.IsAutoStartupMenuItem.Size = new System.Drawing.Size(72, 16);
            this.IsAutoStartupMenuItem.TabIndex = 0;
            this.IsAutoStartupMenuItem.Text = "开机启动";
            this.IsAutoStartupMenuItem.UseVisualStyleBackColor = true;
            // 
            // CommonSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 129);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommonSettingForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "通用";
            this.Load += new System.EventHandler(this.CommonSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox IsAutoStartupMenuItem;
        private System.Windows.Forms.CheckBox IsAutoHideFormMenuItem;
        private System.Windows.Forms.CheckBox EnableSpeechMenuItem;
    }
}