//<copyright file ="Pagination.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2020  All Rights Reserved
//</copyright>
//<author> EIEICHO\Ei Ei Cho </author>
//<date>12/24/2020</date>

namespace POS_Admin.Utilities
{
    using DAO.Common;
    using POS_Admin.Properties;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Pagination" />.
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// Defines the btnColor.
        /// </summary>
        //private Color btnColor = ColorTranslator.FromHtml("#1F62B0");
        private Color btnColor = Properties.Settings.Default.BackColor;

        /// <summary>
        /// Defines the totalPageCount, totalRecords.
        /// </summary>
        private int totalPageCount,
                    totalRecords;

        /// <summary>
        /// CalculateTotalPages.
        /// </summary>
        /// <param name="dtTarget">The dtTarget<see cref="DataTable"/>.</param>
        /// <param name="pageSize">.</param>
        /// <returns>.</returns>
        public int CalculateTotalPages(DataTable dtTarget, int pageSize)
        {
            totalRecords = dtTarget.Rows.Count;
            totalPageCount = totalRecords / pageSize;

            if (totalRecords % pageSize > 0)
                totalPageCount += 1;

            return totalPageCount;
        }

        /// <summary>
        /// PaginationButtonAction.
        /// </summary>
        /// <param name="targetDataTable">.</param>
        /// <param name="btnFirst">.</param>
        /// <param name="btnPrevious">.</param>
        /// <param name="btnNext">.</param>
        /// <param name="btnLast">.</param>
        /// <param name="currentPage">.</param>
        public void PaginationButtonAction(
            DataTable targetDataTable,
            Button btnFirst,
            Button btnPrevious,
            Button btnNext,
            Button btnLast,
            int currentPage)
        {
            int rowCount = targetDataTable.Rows.Count;
            if (currentPage == totalPageCount
                || rowCount == 0)
               // if (currentPage == totalPageCount
               //|| rowCount == 0)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
            if (currentPage <= 1)
            {
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
        }

        /// <summary>
        /// PaginationButtonPaint.
        /// </summary>
        /// <param name="btnFirst">.</param>
        /// <param name="btnPrevious">.</param>
        /// <param name="btnNext">.</param>
        /// <param name="btnLast">.</param>
        public void PaginationButtonPaint(
            Button btnFirst,
            Button btnPrevious,
            Button btnNext,
            Button btnLast)
        {
            if (btnFirst.Enabled == true)
            {
                btnFirst.ForeColor = Color.White;
                btnFirst.BackColor = btnColor;
            }
            else
            {
                btnFirst.ForeColor = Color.Black;
                btnFirst.BackColor = Color.DarkGray;
            }
            if (btnPrevious.Enabled == true)
            {
                btnPrevious.ForeColor = Color.White;
                btnPrevious.BackColor = btnColor;
            }
            else
            {
                btnPrevious.ForeColor = Color.Black;
                btnPrevious.BackColor = Color.DarkGray;
            }
            if (btnLast.Enabled == true)
            {
                btnLast.ForeColor = Color.White;
                btnLast.BackColor = btnColor;
            }
            else
            {
                btnLast.ForeColor = Color.Black;
                btnLast.BackColor = Color.DarkGray;
            }
            if (btnNext.Enabled == true)
            {
                btnNext.ForeColor = Color.White;
                btnNext.BackColor = btnColor;
            }
            else
            {
                btnNext.ForeColor = Color.Black;
                btnNext.BackColor = Color.DarkGray;
            }
        }
    }
}
