using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Window
{
    [TestClass]
    public class DefaultMatcherTests : BaseTestSuite
    {
        [TestMethod]
        public void ExceptionThrownWhenNoPopupWindowsExist()
        {
            try
            {
                new DefaultMatcher().MatchWindow(driver);
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
            new DefaultMatcher().MatchWindow(driver);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
