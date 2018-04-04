using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
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
                new TitleMatcher("shjksjd", 10).MatchWindow(driver);
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
            new TitleMatcher(@"GitHub - danhumphrey/ThirtyFour.UI: A Selenium WebDriver (element 34) UI Library for .NET", 10).MatchWindow(driver);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
