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
        public void ValuePropertyReturnsCorrectValue()
        {
            IWebElement el = driver.FindElement(By.Id("rorange"));
            FormElement radio = new FormElementImpl(el);
            Assert.AreEqual("orange", radio.Value);

            IWebElement inputTextEl = driver.FindElement(By.Name("input-text"));
            FormElement inputText = new FormElementImpl(inputTextEl);
            Assert.AreEqual("initial input-text value", inputText.Value);
            inputTextEl.Clear();
            inputTextEl.SendKeys("new input-text value");
            Assert.AreEqual("new input-text value", inputText.Value);

            IWebElement inputHiddenEl = driver.FindElement(By.Name("input-hidden"));
            FormElement inputHidden = new FormElementImpl(inputHiddenEl);
            Assert.AreEqual("initial input-hidden value", inputHidden.Value);
            
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
