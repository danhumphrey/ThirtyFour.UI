using System;
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
        /// <param name="timeoutInSeconds">The number of seconds to keep trying to find the matching popup window</param>
        void MatchWindow(IWebDriver driver, double timeoutInSeconds);
    }
}
