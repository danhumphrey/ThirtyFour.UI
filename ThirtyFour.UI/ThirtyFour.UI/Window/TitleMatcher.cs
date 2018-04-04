using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// The TitleMatcher class matches and switches to the first popup window it finds which matches the provided title
    /// </summary>
    public class TitleMatcher : IMatcher
    {
        private string title;
        private double timeoutInSeconds;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">The title of the window to match</param>
        /// <param name="timeoutInSeconds">The number of seconds to keep trying to find the matching popup window</param>
        public TitleMatcher(string title, double timeoutInSeconds)
        {
            this.title = title;
            this.timeoutInSeconds = timeoutInSeconds;
        }

        /// <summary>
        /// Switches to the first popup window found which matches the provided title
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        public void MatchWindow(IWebDriver driver)
        {
            IReadOnlyCollection<String> windows = driver.WindowHandles;

            bool found = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(timeoutInSeconds), TimeSpan.FromMilliseconds(100), () => {
                foreach (String window in windows)
                {
                    driver.SwitchTo().Window(window);
                    Debug.Print(driver.Title);
                    if (driver.Title.Equals(this.title))
                    {
                        return true;
                    }
                }
                return false;
            });
            
            if(!found)
            {
                throw new Exception("Unable to find Window");
            }
        }
    }
}
