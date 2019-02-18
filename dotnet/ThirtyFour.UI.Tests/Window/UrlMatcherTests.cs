using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Window
{
    [TestClass]
    public class UrlMatcherTests : BaseTestSuite
    {

        [TestMethod]
        public void ExceptionThrownWhenNoMatchingTitle()
        {
            try
            {
                new UrlMatcher("shjksjd").MatchWindow(driver, 4);
                Assert.Fail("An exception should have been thrown");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Unable to find Window", e.Message);
            }
        }

        [TestMethod]
        public void WindowSwitchedWhenMatchingTitle()
        {

            driver.FindElement(By.LinkText("Popup")).Click();
            new UrlMatcher(@"https://github.com/danhumphrey/ThirtyFour.UI").MatchWindow(driver, 4);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }

        [TestMethod]
        public void WindowSwitchedWhenMatchingTitleOfDelayedWindow()
        {
            driver.FindElement(By.LinkText("Delayed Popup")).Click();
            new UrlMatcher(@"https://github.com/danhumphrey/ThirtyFour.UI").MatchWindow(driver, 5);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
