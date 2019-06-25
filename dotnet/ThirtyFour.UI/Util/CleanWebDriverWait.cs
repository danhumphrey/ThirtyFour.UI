using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ThirtyFour.UI.Util
{
    /// <summary>
    /// An extension of WebDriverWait which removes then re-applies the ImplicitWait property on the IWebDriver instance
    /// </summary>
    public class CleanWebDriverWait : WebDriverWait
    {
        public CleanWebDriverWait(IWebDriver driver, TimeSpan timeout, TimeSpan implicitWait) : base(driver, timeout)
        {
            this.Driver = driver;
            this.ImplicitWait = implicitWait;
        }

        public IWebDriver Driver { get; set; }

        public TimeSpan ImplicitWait { get; set; }

        public new TResult Until<TResult>(Func<IWebDriver, TResult> condition)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                var result = base.Until(condition);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            }

        }
    }
}
