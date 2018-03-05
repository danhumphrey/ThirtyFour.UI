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
            var el = driver.FindElement(By.TagName("h1"));
            var wrappedEl = new WrappedElement(el);
            Assert.AreSame(el, wrappedEl.Element);

        }

        [TestMethod]
        public void DriverPropertyIsSameInstance()
        {
            var el = driver.FindElement(By.TagName("h1"));
            var wrappedEl = new WrappedElement(el);
            Assert.AreSame(this.driver, wrappedEl.Driver);
        }

        [TestMethod]
        public void ParentElementPropertyIsCorrectElement()
        {
            var el = driver.FindElement(By.TagName("h1"));
            var wrappedEl = new WrappedElement(el);
            Assert.AreEqual("test-body", wrappedEl.ParentElement.GetAttribute("id"));

            var el2 = driver.FindElement(By.ClassName("last"));
            var wrappedEl2 = new WrappedElement(el2);
            Assert.AreEqual("footer-id", wrappedEl2.ParentElement.GetAttribute("id"));
        }

        [TestMethod]
        public void GetAncestorElementReturnsCorrectElementFilteredByParentTagName()
        {
            var el = driver.FindElement(By.ClassName("last"));
            var wrappedEl = new WrappedElement(el);
            Assert.AreEqual("footer-id", wrappedEl.GetAncestorElement("footer").GetAttribute("id"));
           
        }

        [TestMethod]
        public void GetAncestorElementReturnsCorrectElementFilteredByAncestorTagName()
        {
            var el = driver.FindElement(By.ClassName("last"));
            var wrappedEl = new WrappedElement(el);
            Assert.AreEqual("test-body", wrappedEl.GetAncestorElement("body").GetAttribute("id"));
        }

        [TestMethod]
        public void GetAncestorElementReturnsNullWhenFilteredByInvalidTagName()
        {
            var el = driver.FindElement(By.ClassName("last"));
            var wrappedEl = new WrappedElement(el);
            Assert.IsNull(wrappedEl.GetAncestorElement("head"));
        }
    }
}
