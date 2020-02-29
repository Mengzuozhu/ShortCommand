namespace ShortCommand.ViewForm
{
    partial class SearchEngineForm
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
            this.rbtnBing = new System.Windows.Forms.RadioButton();
            this.txbSearchEngineUrl = new System.Windows.Forms.TextBox();
            this.rbtnCustom = new System.Windows.Forms.RadioButton();
            this.rbtnBaidu = new System.Windows.Forms.RadioButton();
            this.rbtnGoogle = new System.Windows.Forms.RadioButton();
            this.txbExplorerPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExplorerPath = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnBing);
            this.groupBox1.Controls.Add(this.txbSearchEngineUrl);
            this.groupBox1.Controls.Add(this.rbtnCustom);
            this.groupBox1.Controls.Add(this.rbtnBaidu);
            this.groupBox1.Controls.Add(this.rbtnGoogle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索引擎";
            // 
            // rbtnBing
            // 
            this.rbtnBing.AutoSize = true;
            this.rbtnBing.Location = new System.Drawing.Point(12, 64);
            this.rbtnBing.Name = "rbtnBing";
            this.rbtnBing.Size = new System.Drawing.Size(71, 16);
            this.rbtnBing.TabIndex = 2;
            this.rbtnBing.TabStop = true;
            this.rbtnBing.Text = "必应搜索";
            this.rbtnBing.UseVisualStyleBackColor = true;
            // 
            // txbSearchEngineUrl
            // 
            this.txbSearchEngineUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearchEngineUrl.Location = new System.Drawing.Point(12, 108);
            this.txbSearchEngineUrl.Name = "txbSearchEngineUrl";
            this.txbSearchEngineUrl.Size = new System.Drawing.Size(655, 21);
            this.txbSearchEngineUrl.TabIndex = 1;
            // 
            // rbtnCustom
            // 
            this.rbtnCustom.AutoSize = true;
            this.rbtnCustom.Location = new System.Drawing.Point(12, 86);
            this.rbtnCustom.Name = "rbtnCustom";
            this.rbtnCustom.Size = new System.Drawing.Size(353, 16);
            this.rbtnCustom.TabIndex = 0;
            this.rbtnCustom.TabStop = true;
            this.rbtnCustom.Text = "自定义搜索(例：https://www.google.com/search?q=${word})";
            this.rbtnCustom.UseVisualStyleBackColor = true;
            this.rbtnCustom.CheckedChanged += new System.EventHandler(this.rbtnCustom_CheckedChanged);
            // 
            // rbtnBaidu
            // 
            this.rbtnBaidu.AutoSize = true;
            this.rbtnBaidu.Location = new System.Drawing.Point(12, 42);
            this.rbtnBaidu.Name = "rbtnBaidu";
            this.rbtnBaidu.Size = new System.Drawing.Size(71, 16);
            this.rbtnBaidu.TabIndex = 0;
            this.rbtnBaidu.TabStop = true;
            this.rbtnBaidu.Text = "百度搜索";
            this.rbtnBaidu.UseVisualStyleBackColor = true;
            // 
            // rbtnGoogle
            // 
            this.rbtnGoogle.AutoSize = true;
            this.rbtnGoogle.Location = new System.Drawing.Point(12, 20);
            this.rbtnGoogle.Name = "rbtnGoogle";
            this.rbtnGoogle.Size = new System.Drawing.Size(71, 16);
            this.rbtnGoogle.TabIndex = 0;
            this.rbtnGoogle.TabStop = true;
            this.rbtnGoogle.Text = "谷歌搜索";
            this.rbtnGoogle.UseVisualStyleBackColor = true;
            // 
            // txbExplorerPath
            // 
            this.txbExplorerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbExplorerPath.Location = new System.Drawing.Point(12, 20);
            this.txbExplorerPath.Name = "txbExplorerPath";
            this.txbExplorerPath.Size = new System.Drawing.Size(574, 21);
            this.txbExplorerPath.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnExplorerPath);
            this.groupBox2.Controls.Add(this.txbExplorerPath);
            this.groupBox2.Location = new System.Drawing.Point(10, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "浏览器（若不存在，则使用默认浏览器）";
            // 
            // btnExplorerPath
            // 
            this.btnExplorerPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExplorerPath.Location = new System.Drawing.Point(592, 18);
            this.btnExplorerPath.Name = "btnExplorerPath";
            this.btnExplorerPath.Size = new System.Drawing.Size(75, 23);
            this.btnExplorerPath.TabIndex = 3;
            this.btnExplorerPath.Text = "浏览...";
            this.btnExplorerPath.UseVisualStyleBackColor = true;
            this.btnExplorerPath.Click += new System.EventHandler(this.btnExplorerPath_Click);
            // 
            // SearchEngineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 240);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchEngineForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "搜索引擎";
            this.Load += new System.EventHandler(this.SearchEngineForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnCustom;
        private System.Windows.Forms.RadioButton rbtnBaidu;
        private System.Windows.Forms.RadioButton rbtnGoogle;
        private System.Windows.Forms.TextBox txbSearchEngineUrl;
        private System.Windows.Forms.RadioButton rbtnBing;
        private System.Windows.Forms.TextBox txbExplorerPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExplorerPath;
    }
}