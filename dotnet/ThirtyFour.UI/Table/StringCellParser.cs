using OpenQA.Selenium;

namespace ThirtyFour.UI.Table
{
    /// <summary>
    /// Parses a string value from a table cell
    /// </summary>
    public class StringCellParser : ICellParser<string>
    {
        /// <summary>
        /// Gets a string value from a table cell
        /// </summary>
        /// <param name="cell">the cell to extract the value from</param>
        /// <returns>The cell text</returns>
        public string GetValue(IWebElement cell)
        {
            return cell.Text;
        }
    }
}
