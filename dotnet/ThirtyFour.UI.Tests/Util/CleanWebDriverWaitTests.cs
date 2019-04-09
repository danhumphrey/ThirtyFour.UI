using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using ThirtyFour.UI.Util;

namespace ThirtyFour.UI.Tests.Util
{
    [TestClass]
    public class CleanWebDriverWaitTests : BaseTestSuite
    {
        [TestMethod]
        public void CleanWebDriverWaitResolvesBeforeImplicitWaitTime()
        {

            double iwDelay = 30;
            var iw = TimeSpan.FromSeconds(iwDelay);

            driver.Manage().Timeouts().ImplicitWait = iw;

            DateTime start = DateTime.UtcNow;

            driver.FindElement(By.LinkText("3 Second Delay")).Click();
            new CleanWebDriverWait(driver, TimeSpan.FromSeconds(4), iw).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("three-second-delay")));

            DateTime end = DateTime.UtcNow;
            TimeSpan diff = end.Subtract(start);

            Assert.IsTrue(diff.Seconds < iwDelay);

        }

        [TestMethod]
        public void CleanWebDriverWaitThrowsExceptionAfterTimeout()
        {
            double iwDelay = 10;
            var iw = TimeSpan.FromSeconds(iwDelay);
            driver.Manage().Timeouts().ImplicitWait = iw;

            try
            {
                new CleanWebDriverWait(driver, TimeSpan.FromSeconds(2), iw).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("A-Non-existent_Element_which-willNEVER-Exist2")));
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }

            Assert.Fail("Expected WebDriverTimeoutException not thrown");
        }
    }
}
