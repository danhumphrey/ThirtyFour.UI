using OpenQA.Selenium;

namespace ThirtyFour.UI.Table
{
    public interface ICellParser<T>
    {
        T GetValue(IWebElement cell);
    }
}
