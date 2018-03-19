using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyFour.UI.Window
{

    public interface IWindowSwitcher
    {
        void SwitchWindow(IWebDriver driver);
    }
}
