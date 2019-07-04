using OpenQA.Selenium;

namespace ThirtyFour.UI.Table
{
    /// <summary>
    /// Parsers a child element from a table cell
    /// </summary>
    public class ChildElementCellParser : ICellParser<IWebElement>
    {
        protected By locator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="childLocator">the locator for the child element</param>
        public ChildElementCellParser(By childLocator)
        {
            locator = childLocator;
        }

        /// <summary>
        /// Returns a child element from a table cell
        /// </summary>
        /// <param name="cell">The cell to parse</param>
        /// <returns>The child of the cell</returns>
        public IWebElement GetValue(IWebElement cell)
        {
            return cell.FindElement(locator);
        }
    }
}
