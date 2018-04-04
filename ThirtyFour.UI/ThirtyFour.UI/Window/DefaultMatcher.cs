using System;
using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// The DefaultMatcher class matches and switches to the first popup window it finds
    /// </summary>
    public class DefaultMatcher : IMatcher
    {

        /// <summary>
        /// Switches to the first popup window found
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        public void MatchWindow(IWebDriver driver)
        {
            foreach (string handle in driver.WindowHandles)
            {
                if (handle != driver.CurrentWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    return;
                }
            }

            throw new Exception("Unable to find a new Window");
        }
    }
}
