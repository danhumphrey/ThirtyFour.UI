using OpenQA.Selenium;

namespace ThirtyFour.UI.Table
{
    /// <summary>
    /// Basic strategy api for finding cells within a table
    /// </summary>
    public interface ICellFinder
    {
        /// <summary>
        /// Finds and returns a specific table cell
        /// </summary>
        /// <param name="tableElement">The element representing the html table</param>
        /// <returns>The element representing the cell</returns>
        IWebElement FindCell(IWebElement tableElement);
    }
}
