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
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.TablePanel = new System.Windows.Forms.Panel();
            this.dgvCommandAndNames = new System.Windows.Forms.DataGridView();
            this.RowContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeFilePathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeFolderPathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenuStrip = new System.Windows.Forms.MenuStrip();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchEngineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaiduSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoogleSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsAutoStartupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsTopmostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearInvalidPath = new System.Windows.Forms.Button();
            this.chbShowRepeatedCommand = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandAndNames)).BeginInit();
            this.RowContextMenuStrip.SuspendLayout();
            this.SettingMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(458, 453);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(539, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TablePanel
            // 
            this.TablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TablePanel.Controls.Add(this.dgvCommandAndNames);
            this.TablePanel.Location = new System.Drawing.Point(12, 27);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.Size = new System.Drawing.Size(602, 401);
            this.TablePanel.TabIndex = 3;
            this.TablePanel.SizeChanged += new System.EventHandler(this.TablePanel_SizeChanged);
            // 
            // dgvCommandAndNames
            // 
            this.dgvCommandAndNames.AllowDrop = true;
            this.dgvCommandAndNames.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCommandAndNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandAndNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommandAndNames.Location = new System.Drawing.Point(0, 0);
            this.dgvCommandAndNames.Name = "dgvCommandAndNames";
            this.dgvCommandAndNames.RowTemplate.Height = 23;
            this.dgvCommandAndNames.Size = new System.Drawing.Size(602, 401);
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
            // SettingMenuStrip
            // 
            this.SettingMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置ToolStripMenuItem});
            this.SettingMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.SettingMenuStrip.Name = "SettingMenuStrip";
            this.SettingMenuStrip.Size = new System.Drawing.Size(622, 25);
            this.SettingMenuStrip.TabIndex = 6;
            this.SettingMenuStrip.Text = "menuStrip1";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchEngineMenuItem,
            this.IsAutoStartupMenuItem,
            this.IsTopmostMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "设置";
            // 
            // SearchEngineMenuItem
            // 
            this.SearchEngineMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BaiduSearchMenuItem,
            this.GoogleSearchMenuItem});
            this.SearchEngineMenuItem.Name = "SearchEngineMenuItem";
            this.SearchEngineMenuItem.Size = new System.Drawing.Size(124, 22);
            this.SearchEngineMenuItem.Text = "搜索引擎";
            // 
            // BaiduSearchMenuItem
            // 
            this.BaiduSearchMenuItem.CheckOnClick = true;
            this.BaiduSearchMenuItem.Name = "BaiduSearchMenuItem";
            this.BaiduSearchMenuItem.Size = new System.Drawing.Size(100, 22);
            this.BaiduSearchMenuItem.Text = "百度";
            this.BaiduSearchMenuItem.Click += new System.EventHandler(this.BaiduSearchMenuItem_Click);
            // 
            // GoogleSearchMenuItem
            // 
            this.GoogleSearchMenuItem.CheckOnClick = true;
            this.GoogleSearchMenuItem.Name = "GoogleSearchMenuItem";
            this.GoogleSearchMenuItem.Size = new System.Drawing.Size(100, 22);
            this.GoogleSearchMenuItem.Text = "谷歌";
            this.GoogleSearchMenuItem.Click += new System.EventHandler(this.GoogleSearchMenuItem_Click);
            // 
            // IsAutoStartupMenuItem
            // 
            this.IsAutoStartupMenuItem.CheckOnClick = true;
            this.IsAutoStartupMenuItem.Name = "IsAutoStartupMenuItem";
            this.IsAutoStartupMenuItem.Size = new System.Drawing.Size(124, 22);
            this.IsAutoStartupMenuItem.Text = "开机启动";
            // 
            // IsTopmostMenuItem
            // 
            this.IsTopmostMenuItem.CheckOnClick = true;
            this.IsTopmostMenuItem.Name = "IsTopmostMenuItem";
            this.IsTopmostMenuItem.Size = new System.Drawing.Size(124, 22);
            this.IsTopmostMenuItem.Text = "置顶";
            // 
            // btnClearInvalidPath
            // 
            this.btnClearInvalidPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearInvalidPath.Location = new System.Drawing.Point(275, 453);
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
            this.chbShowRepeatedCommand.Location = new System.Drawing.Point(12, 457);
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
            this.btnFind.Location = new System.Drawing.Point(377, 453);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "提示：拖动文件（文件夹）到表格中，即可添加对应路径";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 488);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.chbShowRepeatedCommand);
            this.Controls.Add(this.btnClearInvalidPath);
            this.Controls.Add(this.SettingMenuStrip);
            this.Controls.Add(this.TablePanel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.SettingMenuStrip;
            this.Name = "SettingForm";
            this.Text = "快捷命令配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingForm_KeyDown);
            this.TablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandAndNames)).EndInit();
            this.RowContextMenuStrip.ResumeLayout(false);
            this.SettingMenuStrip.ResumeLayout(false);
            this.SettingMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel TablePanel;
        private System.Windows.Forms.DataGridView dgvCommandAndNames;
        private System.Windows.Forms.ContextMenuStrip RowContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteRowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeFilePathMenuItem;
        private System.Windows.Forms.MenuStrip SettingMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsAutoStartupMenuItem;
        private System.Windows.Forms.Button btnClearInvalidPath;
        private System.Windows.Forms.CheckBox chbShowRepeatedCommand;
        private System.Windows.Forms.ToolStripMenuItem ChangeFolderPathMenuItem;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ToolStripMenuItem IsTopmostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchEngineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BaiduSearchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoogleSearchMenuItem;
        private System.Windows.Forms.Label label1;
    }
}