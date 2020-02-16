namespace ShortCommand.ViewForm
{
    partial class FinderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinderForm));
            this.txbFindText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btFindNext = new System.Windows.Forms.Button();
            this.chbIsAllWordMatch = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.chbIsMatchCase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txbFindText
            // 
            this.txbFindText.Font = new System.Drawing.Font("宋体", 10F);
            this.txbFindText.Location = new System.Drawing.Point(77, 6);
            this.txbFindText.Name = "txbFindText";
            this.txbFindText.Size = new System.Drawing.Size(291, 23);
            this.txbFindText.TabIndex = 0;
            this.txbFindText.TextChanged += new System.EventHandler(this.txbFindText_TextChanged);
            this.txbFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbFindText_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查找文本:";
            // 
            // btFindNext
            // 
            this.btFindNext.Font = new System.Drawing.Font("宋体", 9F);
            this.btFindNext.Location = new System.Drawing.Point(374, 6);
            this.btFindNext.Name = "btFindNext";
            this.btFindNext.Size = new System.Drawing.Size(85, 23);
            this.btFindNext.TabIndex = 2;
            this.btFindNext.Text = "查找下一个";
            this.btFindNext.UseVisualStyleBackColor = true;
            this.btFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // chbIsAllWordMatch
            // 
            this.chbIsAllWordMatch.AutoSize = true;
            this.chbIsAllWordMatch.Location = new System.Drawing.Point(77, 35);
            this.chbIsAllWordMatch.Name = "chbIsAllWordMatch";
            this.chbIsAllWordMatch.Size = new System.Drawing.Size(72, 16);
            this.chbIsAllWordMatch.TabIndex = 3;
            this.chbIsAllWordMatch.Text = "全词匹配";
            this.chbIsAllWordMatch.UseVisualStyleBackColor = true;
            this.chbIsAllWordMatch.CheckedChanged += new System.EventHandler(this.chbIsAllWordMatch_CheckedChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(75, 54);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 12);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "无法找到：";
            // 
            // chbIsMatchCase
            // 
            this.chbIsMatchCase.AutoSize = true;
            this.chbIsMatchCase.Location = new System.Drawing.Point(155, 35);
            this.chbIsMatchCase.Name = "chbIsMatchCase";
            this.chbIsMatchCase.Size = new System.Drawing.Size(84, 16);
            this.chbIsMatchCase.TabIndex = 5;
            this.chbIsMatchCase.Text = "匹配大小写";
            this.chbIsMatchCase.UseVisualStyleBackColor = true;
            this.chbIsMatchCase.CheckedChanged += new System.EventHandler(this.chbIsMatchCase_CheckedChanged);
            // 
            // FinderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 73);
            this.Controls.Add(this.chbIsMatchCase);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.chbIsAllWordMatch);
            this.Controls.Add(this.btFindNext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbFindText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FinderForm";
            this.Text = "查找";
            this.Load += new System.EventHandler(this.FinderForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FinderForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbFindText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFindNext;
        private System.Windows.Forms.CheckBox chbIsAllWordMatch;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox chbIsMatchCase;
    }
}