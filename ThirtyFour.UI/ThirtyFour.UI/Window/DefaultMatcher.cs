using System;
using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{
    public class DefaultMatcher : IMatcher
    {
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
