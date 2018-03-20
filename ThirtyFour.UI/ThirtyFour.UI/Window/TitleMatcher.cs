using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ThirtyFour.UI.Window
{
    public class TitleMatcher : IMatcher
    {
        private string title;
        private double timeoutInSeconds;

        public TitleMatcher(string title, double timeoutInSeconds)
        {
            this.title = title;
            this.timeoutInSeconds = timeoutInSeconds;
        }

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
