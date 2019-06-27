using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
        public void HandleEqualsDriverHandleWhenNoPopupExists()
        {
            BrowserWindow window = null;
            string currentHandle = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Popup")).Click();

            try
            {
                window = new BrowserWindow(driver);
            }
            catch (Exception)
            {
                Assert.AreEqual(currentHandle, window.DefaultHandle);
            }
        }

        [TestMethod]
        public void HandleEqualsDriverHandleWhenPopupDoesExist()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            Assert.AreEqual(driver.CurrentWindowHandle, window.DefaultHandle);
        }

        [TestMethod]
        public void WindowSwitchesToCorrectWindowWhenNoFinderIsProvided()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            BrowserWindow window = new BrowserWindow(driver);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
