using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Window
{
    [TestClass]
    public class WindowTests : BaseTestSuite
    {

        [TestMethod]
        public void DriverEqualsCurrentDriver()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            Assert.AreEqual(driver, window.Driver);
        }

        [TestMethod]
        public void ExceptionThrownWhenNoPopupExists()
        {
            BrowserWindow window = null;
            string currentHandle = driver.CurrentWindowHandle;

            try
            {
                window = new BrowserWindow(driver);
                Assert.Fail();
            }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
            {
               
            }
        }

        [TestMethod]
        public void DefaultHandleNotEqualsDriverHandleWhenPopupDoesExist()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            Assert.AreNotEqual(driver.CurrentWindowHandle, window.DefaultHandle);
        }

        [TestMethod]
        public void WindowSwitchesToCorrectWindowWhenNoFinderIsProvided()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://github.com/danhumphrey/ThirtyFour.UI"));
        }
    }
}
