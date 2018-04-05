using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Window
{
    [TestClass]
    public class PopupWindowTests : BaseTestSuite
    {

        [TestMethod]
        public void DriverEqualsCurrentDriver()
        {
            PopupWindow window = null;

            driver.FindElement(By.LinkText("Popup")).Click();
            window = new PopupWindow(driver);
            Assert.AreEqual(driver, window.Driver);
        }

        [TestMethod]
        public void HandleEqualsDriverHandleWhenNoPopupExists()
        {
            PopupWindow window = null;
            string currentHandle = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Popup")).Click();

            try
            {
                window = new PopupWindow(driver);
            }
            catch (Exception)
            {
                Assert.AreEqual(currentHandle, window.DefaultHandle);
            }
        }

        [TestMethod]
        public void HandleEqualsDriverHandleWhenPopupDoesExist()
        {
            PopupWindow window = null;
           
            driver.FindElement(By.LinkText("Popup")).Click();
            window = new PopupWindow(driver);
            Assert.AreEqual(driver.CurrentWindowHandle, window.DefaultHandle);
        }

        [TestMethod]
        public void PopupWindowSwitchesToCorrectWindowWhenNoFinderIsProvided()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            new PopupWindow(driver);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
