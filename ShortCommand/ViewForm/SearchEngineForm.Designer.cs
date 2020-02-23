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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rbtnCustom = new System.Windows.Forms.RadioButton();
            this.rbtnBaidu = new System.Windows.Forms.RadioButton();
            this.rbtnGoogle = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.rbtnCustom);
            this.groupBox1.Controls.Add(this.rbtnBaidu);
            this.groupBox1.Controls.Add(this.rbtnGoogle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索引擎";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(456, 21);
            this.textBox1.TabIndex = 1;
            // 
            // rbtnCustom
            // 
            this.rbtnCustom.AutoSize = true;
            this.rbtnCustom.Location = new System.Drawing.Point(12, 64);
            this.rbtnCustom.Name = "rbtnCustom";
            this.rbtnCustom.Size = new System.Drawing.Size(83, 16);
            this.rbtnCustom.TabIndex = 0;
            this.rbtnCustom.TabStop = true;
            this.rbtnCustom.Text = "自定义搜索";
            this.rbtnCustom.UseVisualStyleBackColor = true;
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
            // SearchEngineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 144);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchEngineForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "SearchEngineForm";
            this.Load += new System.EventHandler(this.SearchEngineForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnCustom;
        private System.Windows.Forms.RadioButton rbtnBaidu;
        private System.Windows.Forms.RadioButton rbtnGoogle;
        private System.Windows.Forms.TextBox textBox1;
    }
}