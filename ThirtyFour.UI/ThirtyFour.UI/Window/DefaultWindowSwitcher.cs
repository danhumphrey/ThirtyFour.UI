using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{
    public class DefaultWindowSwitcher : IWindowSwitcher
    {
        public void SwitchWindow(IWebDriver driver)
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
