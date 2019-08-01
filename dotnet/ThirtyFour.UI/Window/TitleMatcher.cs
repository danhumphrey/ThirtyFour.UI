using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using ThirtyFour.UI.Util;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// The TitleMatcher class matches and switches to the first popup window it finds which matches the provided title
    /// </summary>
    public class TitleMatcher : IMatcher
    {
        private string title;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">The title of the window to match</param>
        public TitleMatcher(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// Switches to the first popup window found which matches the provided title
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        /// <param name="timeoutInSeconds">The number of seconds to keep trying to find the matching popup window</param>
        public void MatchWindow(IWebDriver driver, double timeoutInSeconds)
        {

            string currentWindowHandle = driver.CurrentWindowHandle;

            bool found = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(timeoutInSeconds), TimeSpan.FromMilliseconds(100), () => {
                IReadOnlyCollection<string> windows = driver.WindowHandles;

                foreach (String window in windows)
                {
                    driver.SwitchTo().Window(window);
                    if (driver.Title.Equals(this.title))
                    {
                        return true;
                    }
                    driver.SwitchTo().Window(currentWindowHandle);
                }
                return false;
            });

            if (!found)
            {
                throw new Exception("Unable to find Window");
            }
        }
    }
}
