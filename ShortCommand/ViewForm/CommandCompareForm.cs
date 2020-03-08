using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ShortCommand.Class.Setting.ConfigImporter;

namespace ShortCommand.ViewForm
{
    public partial class CommandCompareForm : Form
    {
        private readonly List<CurrentAndImportCommand> sameCommandTable;
        private const int Ratio = 3;
        private const int CheckBoxSize = 60;
        private readonly Dictionary<string, string> shortNameAndCommands;
        public Action<Dictionary<string, string>> UpdateNameAndCommandAction { get; set; }

        public CommandCompareForm(List<CurrentAndImportCommand> sameCommandTable,
            Dictionary<string, string> shortNameAndCommands)
        {
            InitializeComponent();
            this.sameCommandTable = sameCommandTable;
            this.shortNameAndCommands = shortNameAndCommands;
        }

        private void CommandCompareForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            dgvCommandAndNames.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            DataGridViewRowCollection rows = dgvCommandAndNames.Rows;
            rows.Clear();
            for (var i = 0; i < sameCommandTable.Count; i++)
            {
                rows.Add();
                DataGridViewCellCollection cells = rows[i].Cells;
                CurrentAndImportCommand sharedCommand = sameCommandTable[i];
                cells[0].Value = true;
                cells[1].Value = sharedCommand.CurrentCommand;
                cells[2].Value = sharedCommand.Name;
                cells[3].Value = sharedCommand.ImportCommand;
                cells[4].Value = false;
            }
            dgvCommandAndNames.ClearSelection();
            ResizeHeader();
        }

        private void CommandCompareForm_Resize(object sender, EventArgs e)
        {
            ResizeHeader();
        }

        private void ResizeHeader()
        {
            int width = dgvCommandAndNames.Width - CheckBoxSize * Ratio;
            var split = width / Ratio;
            dgvCommandAndNames.Columns[0].Width = CheckBoxSize;
            dgvCommandAndNames.Columns[1].Width = split;
            dgvCommandAndNames.Columns[2].Width = split;
            dgvCommandAndNames.Columns[3].Width = split;
            dgvCommandAndNames.Columns[4].Width = CheckBoxSize;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Apply();
            Close();
        }

        private void Apply()
        {
            DataGridViewRowCollection rows = dgvCommandAndNames.Rows;
            //忽略最后的空行
            for (var i = 0; i < rows.Count - 1; i++)
            {
                var cells = rows[i].Cells;
                bool chooseCurrent = (bool) cells[0].EditedFormattedValue;
                string name = cells[2].EditedFormattedValue.ToString();
                shortNameAndCommands[name] = chooseCurrent
                    ? cells[1].EditedFormattedValue.ToString()
                    : cells[3].EditedFormattedValue.ToString();
            }

            UpdateNameAndCommandAction?.Invoke(shortNameAndCommands);
        }

        private void dgvCommandAndNames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            var rows = dgvCommandAndNames.Rows;
            //保证当前和导入版本只有一个可选中
            if (columnIndex == 0)
            {
                rows[rowIndex].Cells[4].Value = !(bool) rows[rowIndex].Cells[0].EditedFormattedValue;
            }
            else if (columnIndex == 4)
            {
                rows[rowIndex].Cells[0].Value = !(bool) rows[rowIndex].Cells[4].EditedFormattedValue;
            }
        }

        private void btnSelectCurrent_Click(object sender, EventArgs e)
        {
            SelectCurrent(true);
        }

        private void btnSelectImport_Click(object sender, EventArgs e)
        {
            SelectCurrent(false);
        }

        private void SelectCurrent(bool current)
        {
            DataGridViewRowCollection rows = dgvCommandAndNames.Rows;
            for (var i = 0; i < rows.Count - 1; i++)
            {
                rows[i].Cells[0].Value = current;
                rows[i].Cells[4].Value = !current;
            }
        }
    }
}