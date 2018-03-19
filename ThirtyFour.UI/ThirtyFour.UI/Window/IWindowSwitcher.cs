using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{

    public interface IWindowSwitcher
    {
        void SwitchWindow(IWebDriver driver);
    }
}
