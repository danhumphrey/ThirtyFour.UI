using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirtyFour.UI.Form;

namespace ThirtyFour.UI.Tests.Tests
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
            IWebElement el = driver.FindElement(By.Id("rorange"));
            BooleanElement radio = new BooleanElementImpl(el);
            Assert.IsFalse(radio.IsChecked);
        }

        [TestMethod]
        public void IsCheckedPropertyWhenChecked()
        {
            IWebElement el = driver.FindElement(By.Id("rviolet"));
            BooleanElement radio = new BooleanElementImpl(el);
            Assert.IsTrue(radio.IsChecked);
        }
    }
}
