using System.Windows.Forms;

namespace ShortCommand.Class.Finder
{
    /// <summary>
    /// 查找器
    /// </summary>
    class FinderClass
    {
        private readonly DataGridView dgvCommandAndNames;
        private int nextRowIndex; //下一个行索引
        private int nextColumnIndex; ////下一个列索引
        private bool hasMatchedOneAtLeast; //至少找到一个匹配的
        private readonly Label lblMessage;
        private string currentFindText;
        private bool currentIsAllWordMatch;
        private bool currentIsIgnoreCase;

        public FinderClass(DataGridView dgvCommandAndNames, Label lblMessage)
        {
            this.dgvCommandAndNames = dgvCommandAndNames;
            this.lblMessage = lblMessage;
            ResetFindState();
        }

        /// <summary>
        /// 重置查找状态
        /// </summary>
        public void ResetFindState()
        {
            nextRowIndex = 0;
            nextColumnIndex = 0;
            hasMatchedOneAtLeast = false;
            lblMessage.Visible = false;
        }

        /// <summary>
        /// 查找下一个
        /// </summary>
        public void FindNext(string findText, bool isAllWordMatch, bool isIgnoreCase)
        {
            currentFindText = findText;
            dgvCommandAndNames.ClearSelection();
            if (string.IsNullOrEmpty(currentFindText))
            {
                return;
            }
            currentIsAllWordMatch = isAllWordMatch;
            currentIsIgnoreCase = isIgnoreCase; //忽略大小写
            string finalFindText = currentFindText;
            //忽略大小写，则全部使用大写来匹配
            if (isIgnoreCase)
            {
                finalFindText = finalFindText.ToUpper();
            }

            FindInEveryCell(finalFindText);
        }

        /// <summary>
        /// 在每个单元格中查找
        /// </summary>
        /// <param name="finalFindText"></param>
        private void FindInEveryCell(string finalFindText)
        {
            int rowCount = dgvCommandAndNames.RowCount - 1;
            int columnsCount = dgvCommandAndNames.ColumnCount;
            for (int rowIndex = nextRowIndex; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = nextColumnIndex; columnIndex < columnsCount; columnIndex++)
                {
                    DataGridViewCell cell = dgvCommandAndNames.Rows[rowIndex].Cells[columnIndex];
                    if (IsNotMatchCellValue(cell, finalFindText)) continue;

                    hasMatchedOneAtLeast = true;
                    cell.Selected = true;
                    dgvCommandAndNames.FirstDisplayedScrollingRowIndex = rowIndex;
                    UpdateNextIndex(rowIndex, columnIndex);
                    return;
                }

                //遍历完所有列，再从第0列开始
                nextColumnIndex = 0;
                //重新查找
                if (rowIndex == rowCount - 1)
                {
                    FindNewly();
                }
            }
        }

        /// <summary>
        /// 从头开始查找
        /// </summary>
        /// <param name="findText"></param>
        /// <param name="isAllWordMatch"></param>
        /// <param name="isIgnoreCase"></param>
        private void FindNewly()
        {
            nextRowIndex = 0;
            //至少有匹配的，才会重新查找，不然会死循环
            if (hasMatchedOneAtLeast)
            {
                FindNext(currentFindText, currentIsAllWordMatch, currentIsIgnoreCase);
            }
            else
            {
                lblMessage.Text = string.Format("无法找到：{0}", currentFindText);
                lblMessage.Visible = true;
            }
        }

        /// <summary>
        /// 单元格的值不匹配
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="isIgnoreCase"></param>
        /// <param name="isAllWordMatch"></param>
        /// <param name="finalFindText"></param>
        /// <returns></returns>
        private bool IsNotMatchCellValue(DataGridViewCell cell, string finalFindText)
        {
            string cellValue = cell.Value.ToString();
            if (currentIsIgnoreCase)
            {
                cellValue = cellValue.ToUpper();
            }

            //全词匹配
            if (currentIsAllWordMatch)
            {
                if (!cellValue.Equals(finalFindText)) return true;
            }
            else
            {
                if (!cellValue.Contains(finalFindText)) return true;
            }

            return false;
        }

        /// <summary>
        /// 更新下一个行列索引
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        private void UpdateNextIndex(int rowIndex, int columnIndex)
        {
            nextRowIndex = rowIndex;
            //下一个列索引已经超过总列数，则跳到下一行，类似进位
            if (columnIndex + 1 == dgvCommandAndNames.Columns.Count)
            {
                nextRowIndex++;
                nextColumnIndex = 0;
            }
            else
            {
                nextColumnIndex = columnIndex + 1;
            }
        }

    }
}
