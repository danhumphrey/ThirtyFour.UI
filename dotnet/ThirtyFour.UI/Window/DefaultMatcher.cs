using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using ThirtyFour.UI.Util;

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
        /// <param name="timeoutInSeconds">The number of seconds to keep trying to find the matching popup window</param>
        public void MatchWindow(IWebDriver driver, double timeoutInSeconds)
        {
            bool found = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(timeoutInSeconds), TimeSpan.FromMilliseconds(100), () => {
                IReadOnlyCollection<String> windows = driver.WindowHandles;
                foreach (String window in windows)
                {
                    if (window != driver.CurrentWindowHandle)
                    {
                        driver.SwitchTo().Window(window);
                        return true;
                    }

                }
                return false;
            });

            if (!found)
            {
                throw new Exception("Unable to find a new Window");
            }
        }
    }
}
