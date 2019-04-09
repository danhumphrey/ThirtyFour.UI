using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ThirtyFour.UI.Util
{
    /*
     * An extension of WebDriverWait which removes then re-applies the ImplicitWait property on the IWebDriver instance
     */
    public class CleanWebDriverWait : WebDriverWait
    {
        private IWebDriver driver;
        private TimeSpan implicitWait;

        public CleanWebDriverWait(IWebDriver driver, TimeSpan timeout, TimeSpan implicitWait) : base(driver, timeout)
        {
            this.Driver = driver;
            this.ImplicitWait = implicitWait;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }

        public TimeSpan ImplicitWait
        {
            get
            {
                return implicitWait;
            }

            set
            {
                implicitWait = value;
            }
        }

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
