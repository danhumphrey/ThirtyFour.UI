using OpenQA.Selenium;

namespace ThirtyFour.UI.Table
{
    /// <summary>
    /// Basic strategy for fparsing and returning the value of cells found within a table
    /// </summary>
    public interface ICellParser<T>
    {
        /// <summary>
        /// Returns the value from the specific table cell element
        /// </summary>
        /// <param name="cell">The element representing the table cell table</param>
        /// <returns>The cell value</returns>
        T GetValue(IWebElement cell);
    }
}
