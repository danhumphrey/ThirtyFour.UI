using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// The UrlMatcher class matches and switches to the first popup window it finds which matches the provided url
    /// </summary>
    public class UrlMatcher : IMatcher
    {
        private string url;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">The url of the window to match</param>
        public UrlMatcher(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Switches to the first popup window found which matches the provided url
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        /// <param name="timeoutInSeconds">The number of seconds to keep trying to find the matching popup window</param>
        public void MatchWindow(IWebDriver driver, double timeoutInSeconds)
        {
            bool found = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(timeoutInSeconds), TimeSpan.FromMilliseconds(100), () => {
                IReadOnlyCollection<String> windows = driver.WindowHandles;

                foreach (String window in windows)
                {
                    driver.SwitchTo().Window(window);
                    if (driver.Url.Equals(this.url))
                    {
                        return true;
                    }
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
