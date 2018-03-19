using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ThirtyFour.UI.Window
{
    public class TitleMatcher : IMatcher
    {
        private string title;

        public TitleMatcher(string title)
        {
            this.title = title;
        }

        public void MatchWindow(IWebDriver driver)
        {
            IReadOnlyCollection<String> windows = driver.WindowHandles;

            bool found = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(5), () => {
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
