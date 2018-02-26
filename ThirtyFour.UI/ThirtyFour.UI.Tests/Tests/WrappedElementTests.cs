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
            WrappedElement wrappedEl = new WrappedElement(el);
            Assert.AreSame(el, wrappedEl.Element);

        }

        [TestMethod]
        public void DriverPropertyIsSameInstance()
        {
            IWebElement el = driver.FindElement(By.TagName("h1"));
            WrappedElement wrappedEl = new WrappedElement(el);
            Assert.AreSame(this.driver, wrappedEl.Driver);
        }

        [TestMethod]
        public void ParentElementPropertyIsCorrectElement()
        {
            IWebElement el = driver.FindElement(By.TagName("h1"));
            WrappedElement wrappedEl = new WrappedElement(el);
            Assert.AreEqual("test-body", wrappedEl.ParentElement.GetAttribute("id"));

            IWebElement el2 = driver.FindElement(By.ClassName("last"));
            WrappedElement wrappedEl2 = new WrappedElement(el2);
            Assert.AreEqual("footer-id", wrappedEl2.ParentElement.GetAttribute("id"));
        }

        [TestMethod]
        public void GetAncestorElementReturnsCorrectElementFilteredByParentTagName()
        {
            IWebElement el = driver.FindElement(By.ClassName("last"));
            WrappedElement wrappedEl = new WrappedElement(el);
            Assert.AreEqual("footer-id", wrappedEl.GetAncestorElement("footer").GetAttribute("id"));
           
        }

        [TestMethod]
        public void GetAncestorElementReturnsCorrectElementFilteredByAncestorTagName()
        {
            IWebElement el = driver.FindElement(By.ClassName("last"));
            WrappedElement wrappedEl = new WrappedElement(el);
            Assert.AreEqual("test-body", wrappedEl.GetAncestorElement("body").GetAttribute("id"));
        }

        [TestMethod]
        public void GetAncestorElementReturnsNullWhenFilteredByInvalidTagName()
        {
            IWebElement el = driver.FindElement(By.ClassName("last"));
            WrappedElement wrappedEl = new WrappedElement(el);
            Assert.IsNull(wrappedEl.GetAncestorElement("head"));
        }
    }
}
