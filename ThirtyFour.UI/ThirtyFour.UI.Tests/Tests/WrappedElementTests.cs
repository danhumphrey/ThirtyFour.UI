using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace ThirtyFour.UI.Tests.Tests
{
    [TestClass]
    public class WrappedElementTests : BaseTestSuite
    {
        [TestMethod]
        public void ElementPropertyIsSameInstance()
        {
            IWebElement el = driver.FindElement(By.TagName("h1"));
            WrappedElement wEl = new WrappedElement(el);
            Assert.AreSame(el, wEl.Element);

        }

        [TestMethod]
        public void DriverPropertyIsSameInstance()
        {
            IWebElement el = driver.FindElement(By.TagName("h1"));
            WrappedElement wEl = new WrappedElement(el);
            Assert.AreSame(this.driver, wEl.Driver);
        }

        [TestMethod]
        public void ParentElementPropertyIsCorrectElement()
        {
            IWebElement h1El = driver.FindElement(By.TagName("h1"));
            WrappedElement wH1El = new WrappedElement(h1El);
            Assert.AreEqual("testBody", wH1El.ParentElement.GetAttribute("id"));

            IWebElement pLastEl = driver.FindElement(By.ClassName("last"));
            WrappedElement wpLastEl = new WrappedElement(pLastEl);
            Assert.AreEqual("footer-id", wpLastEl.ParentElement.GetAttribute("id"));
        }

        [TestMethod]
        public void GetAncestorElementReturnsCorrectElementFilteredByParentTagName()
        {
            IWebElement el = driver.FindElement(By.ClassName("last"));
            WrappedElement wEl = new WrappedElement(el);
            Assert.AreEqual("footer-id", wEl.GetAncestorElement("footer").GetAttribute("id"));
        }

        [TestMethod]
        public void GetAncestorElementReturnsCorrectElementFilteredByAncestorTagName()
        {
            IWebElement el = driver.FindElement(By.ClassName("last"));
            WrappedElement wEl = new WrappedElement(el);
            Assert.AreEqual("testBody", wEl.GetAncestorElement("body").GetAttribute("id"));
        }

        [TestMethod]
        public void GetAncestorElementReturnsNullWhenFilteredByInvalidTagName()
        {
            IWebElement el = driver.FindElement(By.ClassName("last"));
            WrappedElement wEl = new WrappedElement(el);
            Assert.IsNull(wEl.GetAncestorElement("head"));
        }
    }
}
