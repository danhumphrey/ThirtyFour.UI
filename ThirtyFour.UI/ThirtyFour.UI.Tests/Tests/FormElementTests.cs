using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Form;

namespace ThirtyFour.UI.Tests.Tests
{
    [TestClass]
    public class FormElementTests : BaseTestSuite
    {
        public class FormElementImpl : FormElement
        {
            public FormElementImpl(IWebElement element) : base(element)
            {
            }
        }

        [TestMethod]
        public void LabelTextWhenWrapped()
        {
            IWebElement el = driver.FindElement(By.Id("rorange"));
            FormElement radio = new FormElementImpl(el);
            Assert.AreEqual("Orange", radio.LabelText);
        }

        [TestMethod]
        public void LabelTextWithForAttribute()
        {
            IWebElement el = driver.FindElement(By.Id("rviolet"));
            FormElement radio = new FormElementImpl(el);
            Assert.AreEqual("Violet", radio.LabelText);
        }

    }
}
