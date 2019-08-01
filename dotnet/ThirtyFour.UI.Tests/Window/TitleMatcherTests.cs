using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Window
{
    [TestClass]
    public class TitleMatcherTests : BaseTestSuite
    {

        [TestMethod]
        public void ExceptionThrownWhenNoMatchingTitle()
        {
            try
            {
                new TitleMatcher("shjksjd").MatchWindow(driver, 4);
                Assert.Fail("An exception should have been thrown");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Unable to find matching window", e.Message);
            }
        }

        [TestMethod]
        public void WindowSwitchedWhenMatchingTitle()
        {

            driver.FindElement(By.LinkText("Popup")).Click();
            new TitleMatcher(@"GitHub - danhumphrey/ThirtyFour.UI: A Selenium (element 34) WebDriver UI Library for C# and Java").MatchWindow(driver, 4);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }

        [TestMethod]
        public void WindowSwitchedWhenMatchingTitleOfDelayedWindow()
        {
            driver.FindElement(By.LinkText("Delayed Popup")).Click();
            new TitleMatcher(@"GitHub - danhumphrey/ThirtyFour.UI: A Selenium (element 34) WebDriver UI Library for C# and Java").MatchWindow(driver, 5);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
