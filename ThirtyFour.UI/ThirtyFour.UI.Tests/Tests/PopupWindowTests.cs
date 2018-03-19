using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Tests
{
    [TestClass]
    public class PopupWindowTests : BaseTestSuite
    {

        [TestMethod]
        public void DriverEqualsCurrentDriver()
        {
            PopupWindow window = null;
            
            try
            {
                window = new PopupWindow(driver);
            }
            catch (Exception e)
            {
                Assert.AreEqual(driver, window.Driver);
            }
        }

        [TestMethod]
        public void DefaultHandleEqualsDriverHandleWhenNoPopupExists()
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
        public void DefaultHandleEqualsDriverHandleWhenPopupDoesExist()
        {
            PopupWindow window = null;

            string currentHandle = driver.CurrentWindowHandle;

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
        public void PopupWindowSwitcherSwitchesToCorrectWindowWhenNoSwitcherIsProvided()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            new PopupWindow(driver);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
