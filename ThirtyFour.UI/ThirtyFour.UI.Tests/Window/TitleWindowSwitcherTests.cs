using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using ThirtyFour.UI.Window;

namespace ThirtyFour.UI.Tests.Window
{
    [TestClass]
    public class TitleWindowSwitcherTests : BaseTestSuite
    {
        public TitleMatcher TitleWindowSwitcher { get; private set; }

        [TestMethod]
        public void ExceptionThrownWhenNoMatchingTitle()
        {
            try
            {
                new TitleMatcher("shjksjd").MatchWindow(driver);
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
            new TitleMatcher(@"GitHub - danhumphrey/ThirtyFour.UI: A Selenium WebDriver (element 34) UI Library for .NET").MatchWindow(driver);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
