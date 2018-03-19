using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{

    public interface IMatcher
    {
        void MatchWindow(IWebDriver driver);
    }
}
