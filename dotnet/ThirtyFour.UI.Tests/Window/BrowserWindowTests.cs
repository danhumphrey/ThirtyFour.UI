﻿using System;
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
        public void DefaultHandleEqualsDriverHandleWhenNoPopupExists()
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
        public void DefaultHandleEqualsDriverHandleWhenPopupDoesExist()
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
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://github.com/danhumphrey/ThirtyFour.UI"));
        }
    }
}
