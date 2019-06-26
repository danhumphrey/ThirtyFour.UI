using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Form;

namespace ThirtyFour.UI.Tests.Form
{
    [TestClass]
    public class BooleanElementTests : BaseTestSuite
    {
        public class BooleanElementImpl : BooleanElement
        {
            public BooleanElementImpl(IWebElement element) : base(element)
            {
            }
        }

        [TestMethod]
        public void IsCheckedPropertyWhenNotChecked()
        {
            var el = driver.FindElement(By.Id("rorange"));
            BooleanElement radio = new BooleanElementImpl(el);
            Assert.IsFalse(radio.IsChecked);
        }

        [TestMethod]
        public void IsCheckedPropertyWhenChecked()
        {
            var el = driver.FindElement(By.Id("rviolet"));
            BooleanElement radio = new BooleanElementImpl(el);
            Assert.IsTrue(radio.IsChecked);
        }
    }
}
