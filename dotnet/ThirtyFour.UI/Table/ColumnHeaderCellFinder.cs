using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtyFour.UI.Table
{
    /// <summary>
    /// Finds a cell by correlating the table headers with a value to identify the correct table row
    /// </summary>
    public class ColumnHeaderCellFinder : ICellFinder
    {

        protected string findColumnHeader;
        protected string findValue;
        protected string returnColumnHeader;
        protected IWebElement tableElement;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="findColumnHeader">The header of the column used to find the correct table row</param>
        /// <param name="findValue">The value which identifes the correct table row (within the find column)</param>
        /// <param name="returnColumnHeader">The column header used to identify the correct cell</param>
        public ColumnHeaderCellFinder(string findColumnHeader, string findValue, string returnColumnHeader)
        {
            this.findColumnHeader = findColumnHeader;
            this.findValue = findValue;
            this.returnColumnHeader = returnColumnHeader;
        }


        /// <summary>
        /// Returns the zero based index/position of a column with the matching header
        /// </summary>
        /// <param name="columnHeader">The column header</param>
        /// <returns>The index of the column</returns>
        protected int GetColumnIndex(string columnHeader)
        {
            IReadOnlyCollection<IWebElement> headerCells = this.tableElement.FindElements(By.TagName("th"));
            for (int i = 0; i < headerCells.Count; i++)
            {
                if (headerCells.ElementAt(i).Text.Equals(columnHeader))
                {
                    return i;
                }
            }

            throw new NoSuchElementException(String.Format("Unable to find column with header text '{0}'", columnHeader));
        }

        /// <summary>
        /// Finds and returns a specific table cell
        /// </summary>
        /// <param name="tableElement">the element representing the html table</param>
        /// <returns>an element representing the tabel cell</returns>
        public IWebElement FindCell(IWebElement tableElement)
        {
            this.tableElement = tableElement;
            int findColumnIndex = this.GetColumnIndex(this.findColumnHeader);
            int returnColumnIndex = this.GetColumnIndex(this.returnColumnHeader);

            IReadOnlyCollection<IWebElement> rows = tableElement.FindElements(By.CssSelector("tbody tr"));
            foreach (IWebElement row in rows)
            {
                IReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("td"));
                if (cells.ElementAt(findColumnIndex).Text.Equals(this.findValue))
                {
                    return cells.ElementAt(returnColumnIndex);
                }
            }

            throw new NoSuchElementException(String.Format("Unable to find row containing find value '{0}'", findValue));
        }
    }
}
