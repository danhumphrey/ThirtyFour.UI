using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// Basic strategy form matching popup windows
    /// </summary>
    public interface IMatcher
    {
        /// <summary>
        /// Switches to the matching popup window
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        void MatchWindow(IWebDriver driver);
    }
}
