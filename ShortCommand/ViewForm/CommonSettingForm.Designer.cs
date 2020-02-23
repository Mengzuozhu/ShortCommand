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
            this.IsAutoHideFormMenuItem = new System.Windows.Forms.CheckBox();
            this.IsTopmostMenuItem = new System.Windows.Forms.CheckBox();
            this.IsAutoStartupMenuItem = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IsAutoHideFormMenuItem);
            this.groupBox1.Controls.Add(this.IsTopmostMenuItem);
            this.groupBox1.Controls.Add(this.IsAutoStartupMenuItem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(304, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // IsAutoHideFormMenuItem
            // 
            this.IsAutoHideFormMenuItem.AutoSize = true;
            this.IsAutoHideFormMenuItem.Location = new System.Drawing.Point(19, 71);
            this.IsAutoHideFormMenuItem.Name = "IsAutoHideFormMenuItem";
            this.IsAutoHideFormMenuItem.Size = new System.Drawing.Size(108, 16);
            this.IsAutoHideFormMenuItem.TabIndex = 2;
            this.IsAutoHideFormMenuItem.Text = "主界面自动隐藏";
            this.IsAutoHideFormMenuItem.UseVisualStyleBackColor = true;
            // 
            // IsTopmostMenuItem
            // 
            this.IsTopmostMenuItem.AutoSize = true;
            this.IsTopmostMenuItem.Location = new System.Drawing.Point(19, 49);
            this.IsTopmostMenuItem.Name = "IsTopmostMenuItem";
            this.IsTopmostMenuItem.Size = new System.Drawing.Size(72, 16);
            this.IsTopmostMenuItem.TabIndex = 1;
            this.IsTopmostMenuItem.Text = "是否置顶";
            this.IsTopmostMenuItem.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(324, 142);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommonSettingForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "CommonSettingForm";
            this.Load += new System.EventHandler(this.CommonSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox IsAutoStartupMenuItem;
        private System.Windows.Forms.CheckBox IsAutoHideFormMenuItem;
        private System.Windows.Forms.CheckBox IsTopmostMenuItem;
    }
}