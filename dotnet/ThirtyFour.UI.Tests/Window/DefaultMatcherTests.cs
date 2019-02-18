﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                new DefaultMatcher().MatchWindow(driver, 4);
                Assert.Fail("An exception should have been thrown");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Unable to find a new Window", e.Message);
            }
        }

        [TestMethod]
        public void WindowSwitchedToCorrectWindow()
        {
      
            driver.FindElement(By.LinkText("Popup")).Click();
            new DefaultMatcher().MatchWindow(driver, 4);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }

        [TestMethod]
        public void WindowSwitchedWhenMatchingDelayedWindow()
        {
            driver.FindElement(By.LinkText("Delayed Popup")).Click();
            new DefaultMatcher().MatchWindow(driver, 5);
            Assert.AreEqual("https://github.com/danhumphrey/ThirtyFour.UI", driver.Url);
        }
    }
}
