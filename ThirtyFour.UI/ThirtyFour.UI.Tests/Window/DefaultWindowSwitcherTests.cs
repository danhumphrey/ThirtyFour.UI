using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Tests.Window
{
    [TestClass]
    public class DefaultWindowSwitcherTests : BaseTestSuite
    {
        [TestMethod]
        public void ExceptionThrownWhenNoPopupWindowsExist()
        {
            try
            {
                new DefaultWindowSwitcher().SwitchWindow(driver);
                Assert.Fail("An exception should have been thrown");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Unable to find a new Window", e.Message);
            }
        }

        [TestMethod]
        public void DefaultWindowSwitcherSwitchesToCorrectWindow()
        {
            driver.FindElement(By.LinkText("Popup")).Click();
            new DefaultWindowSwitcher().SwitchWindow(driver);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
