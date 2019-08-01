using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Window
{
    [TestClass]
    public class WindowTests : BaseTestSuite
    {
        private void QuitExtraDrivers(String currentHandle)
        {
            ReadOnlyCollection<String> handles = driver.WindowHandles;

            foreach (String handle in handles)
            {
                if (!handle.Equals(currentHandle))
                {
                    driver.SwitchTo().Window(handle);
                    driver.Quit();
                }
            }
        }

        [TestMethod]
        public void DriverEqualsCurrentDriver()
        {
            string currentHandle = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            Assert.AreEqual(driver, window.Driver);

            QuitExtraDrivers(currentHandle);
        }

        [TestMethod]
        public void ExceptionThrownWhenNoPopupExists()
        {
            string currentHandle = driver.CurrentWindowHandle;

            try
            {
                _ = new BrowserWindow(driver);
                Assert.Fail("Expected exception not thrown");
            }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
            {
               
            }
            finally {
                QuitExtraDrivers(currentHandle);
            }

        }

        [TestMethod]
        public void DefaultHandleNotEqualsDriverHandleWhenPopupDoesExist()
        {
            string currentHandle = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            Assert.AreNotEqual(driver.CurrentWindowHandle, window.DefaultHandle);

            QuitExtraDrivers(currentHandle);
        }

        [TestMethod]
        public void WindowSwitchesToCorrectWindowWhenNoMatcherIsProvided()
        {
            string currentHandle = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://github.com/danhumphrey/ThirtyFour.UI"));

            QuitExtraDrivers(currentHandle);
        }
    }
}
