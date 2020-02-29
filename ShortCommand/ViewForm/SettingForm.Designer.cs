namespace ShortCommand.ViewForm
{
    partial class SettingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.dgvCommandAndNames = new System.Windows.Forms.DataGridView();
            this.RowContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeFilePathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeFolderPathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearInvalidPath = new System.Windows.Forms.Button();
            this.chbShowRepeatedCommand = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grbCommand = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandAndNames)).BeginInit();
            this.RowContextMenuStrip.SuspendLayout();
            this.grbCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCommandAndNames
            // 
            this.dgvCommandAndNames.AllowDrop = true;
            this.dgvCommandAndNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCommandAndNames.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCommandAndNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandAndNames.Location = new System.Drawing.Point(3, 17);
            this.dgvCommandAndNames.Name = "dgvCommandAndNames";
            this.dgvCommandAndNames.RowTemplate.Height = 23;
            this.dgvCommandAndNames.Size = new System.Drawing.Size(598, 380);
            this.dgvCommandAndNames.TabIndex = 4;
            this.dgvCommandAndNames.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCommandAndNames_CellBeginEdit);
            this.dgvCommandAndNames.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommandAndNames_CellEndEdit);
            this.dgvCommandAndNames.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommandAndNames_RowHeaderMouseClick);
            this.dgvCommandAndNames.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCommandAndNames_RowsAdded);
            this.dgvCommandAndNames.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCommandAndNames_RowsRemoved);
            this.dgvCommandAndNames.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvCommandAndNames_DragDrop);
            this.dgvCommandAndNames.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvCommandAndNames_DragEnter);
            // 
            // RowContextMenuStrip
            // 
            this.RowContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteRowMenuItem,
            this.ChangeFilePathMenuItem,
            this.ChangeFolderPathMenuItem});
            this.RowContextMenuStrip.Name = "contextMenuStrip1";
            this.RowContextMenuStrip.Size = new System.Drawing.Size(161, 70);
            // 
            // DeleteRowMenuItem
            // 
            this.DeleteRowMenuItem.Name = "DeleteRowMenuItem";
            this.DeleteRowMenuItem.Size = new System.Drawing.Size(160, 22);
            this.DeleteRowMenuItem.Text = "删除该行";
            this.DeleteRowMenuItem.Click += new System.EventHandler(this.DeleteRowMenuItem_Click);
            // 
            // ChangeFilePathMenuItem
            // 
            this.ChangeFilePathMenuItem.Name = "ChangeFilePathMenuItem";
            this.ChangeFilePathMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ChangeFilePathMenuItem.Text = "修改文件路径";
            this.ChangeFilePathMenuItem.Click += new System.EventHandler(this.ChangeFilePathMenuItem_Click);
            // 
            // ChangeFolderPathMenuItem
            // 
            this.ChangeFolderPathMenuItem.Name = "ChangeFolderPathMenuItem";
            this.ChangeFolderPathMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ChangeFolderPathMenuItem.Text = "修改文件夹路径";
            this.ChangeFolderPathMenuItem.Click += new System.EventHandler(this.ChangeFolderPathMenuItem_Click);
            // 
            // btnClearInvalidPath
            // 
            this.btnClearInvalidPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearInvalidPath.Location = new System.Drawing.Point(502, 411);
            this.btnClearInvalidPath.Name = "btnClearInvalidPath";
            this.btnClearInvalidPath.Size = new System.Drawing.Size(96, 23);
            this.btnClearInvalidPath.TabIndex = 7;
            this.btnClearInvalidPath.Text = "清除无效路径";
            this.btnClearInvalidPath.UseVisualStyleBackColor = true;
            this.btnClearInvalidPath.Click += new System.EventHandler(this.btnClearInvalidPath_Click);
            // 
            // chbShowRepeatedCommand
            // 
            this.chbShowRepeatedCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbShowRepeatedCommand.AutoSize = true;
            this.chbShowRepeatedCommand.Location = new System.Drawing.Point(6, 415);
            this.chbShowRepeatedCommand.Name = "chbShowRepeatedCommand";
            this.chbShowRepeatedCommand.Size = new System.Drawing.Size(156, 16);
            this.chbShowRepeatedCommand.TabIndex = 8;
            this.chbShowRepeatedCommand.Text = "显示重复命令/路径/网址";
            this.chbShowRepeatedCommand.UseVisualStyleBackColor = true;
            this.chbShowRepeatedCommand.CheckedChanged += new System.EventHandler(this.chbShowRepeatedCommand_CheckedChanged);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(421, 411);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "提示：拖动文件（文件夹）到表格中，即可添加对应路径";
            // 
            // grbCommand
            // 
            this.grbCommand.Controls.Add(this.dgvCommandAndNames);
            this.grbCommand.Controls.Add(this.label1);
            this.grbCommand.Controls.Add(this.btnFind);
            this.grbCommand.Controls.Add(this.chbShowRepeatedCommand);
            this.grbCommand.Controls.Add(this.btnClearInvalidPath);
            this.grbCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCommand.Location = new System.Drawing.Point(10, 10);
            this.grbCommand.Name = "grbCommand";
            this.grbCommand.Size = new System.Drawing.Size(604, 446);
            this.grbCommand.TabIndex = 13;
            this.grbCommand.TabStop = false;
            this.grbCommand.Text = "命令配置";
            this.grbCommand.Resize += new System.EventHandler(this.grbCommand_Resize);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 458);
            this.Controls.Add(this.grbCommand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 2);
            this.Text = "命令配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandAndNames)).EndInit();
            this.RowContextMenuStrip.ResumeLayout(false);
            this.grbCommand.ResumeLayout(false);
            this.grbCommand.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCommandAndNames;
        private System.Windows.Forms.ContextMenuStrip RowContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteRowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeFilePathMenuItem;
        private System.Windows.Forms.Button btnClearInvalidPath;
        private System.Windows.Forms.CheckBox chbShowRepeatedCommand;
        private System.Windows.Forms.ToolStripMenuItem ChangeFolderPathMenuItem;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbCommand;
    }
}