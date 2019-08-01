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
            string currentHandle = driver.CurrentWindowHandle;

            try
            {
                new TitleMatcher("shjksjd").MatchWindow(driver, 4);
                Assert.Fail("An exception should have been thrown");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Unable to find matching window", e.Message);
            }
            finally
            {
                QuitExtraDrivers(currentHandle);
            }
        }

        [TestMethod]
        public void WindowSwitchedWhenMatchingTitle()
        {
            string currentHandle = driver.CurrentWindowHandle;

            try
            {

                driver.FindElement(By.LinkText("Popup")).Click();
                new TitleMatcher(@"GitHub - danhumphrey/ThirtyFour.UI: A Selenium (element 34) WebDriver UI Library for C# and Java").MatchWindow(driver, 4);
                Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
            }
            finally
            {
                QuitExtraDrivers(currentHandle);
            }
        }

        [TestMethod]
        public void WindowSwitchedWhenMatchingTitleOfDelayedWindow()
        {
            string currentHandle = driver.CurrentWindowHandle;

            try
            {
                driver.FindElement(By.LinkText("Delayed Popup")).Click();
                new TitleMatcher(@"GitHub - danhumphrey/ThirtyFour.UI: A Selenium (element 34) WebDriver UI Library for C# and Java").MatchWindow(driver, 5);
                Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
            }
            finally
            {
                QuitExtraDrivers(currentHandle);
            }
        }
    }
}
