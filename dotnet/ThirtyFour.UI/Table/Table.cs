using System.Collections.Generic;
using OpenQA.Selenium;

namespace ThirtyFour.UI.Table
{
    /// <summary>
    /// The Table class provides helper methods for interacting with a HTML table
    /// </summary>
    public class Table : WrappedElement
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The root element of the table</param>
        public Table(IWebElement element) : base(element)
        {
        }

        /// <summary>
        /// Returns all header cells
        /// </summary>
        public IReadOnlyCollection<IWebElement> HeaderCells
        {
            get
            {
                return Element.FindElements(By.TagName("th"));
            }
        }

        /// <summary>
        /// Returns the body rows
        /// </summary>
        public IReadOnlyCollection<IWebElement> BodyRows
        {
            get
            {
                return Element.FindElements(By.CssSelector("tbody tr"));
            }

        }
        /// <summary>
        /// Returns a cell value as a String by correlating the table headers with a cell value
        /// </summary>
        /// <param name="findColumn">The column header used to identify the correct table row</param>
        /// <param name="findValue">The cell value used to identify the correct table row</param>
        /// <param name="returnColumn">The column header used to identify the return cell</param>
        /// <returns>The value of the cell if found otherwise a NoSuchElementException will be thrown</returns>
        public string GetCellValue(string findColumn, string findValue, string returnColumn)
        {
            ICellFinder finder = new ColumnHeaderCellFinder(findColumn, findValue, returnColumn);
            return this.GetCellValue(finder, new StringCellParser());
        }

        /// <summary>
        /// Returns a cell value based on custom ICellFinder and ICellParser strategies
        /// </summary>
        /// <typeparam name="T">The data type for the generics cell parser</typeparam>
        /// <param name="cellFinder"></param>
        /// <param name="cellParser"></param>
        /// <returns></returns>
        public T GetCellValue<T>(ICellFinder cellFinder, ICellParser<T> cellParser)
        {
            IWebElement cell = cellFinder.FindCell(Element);
            return cellParser.GetValue(cell);
        }
    }
}
