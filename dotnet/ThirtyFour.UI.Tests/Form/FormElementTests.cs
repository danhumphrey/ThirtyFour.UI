using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Form;

namespace ThirtyFour.UI.Tests.Form
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
            var el = driver.FindElement(By.Id("rorange"));
            FormElement radio = new FormElementImpl(el);
            Assert.AreEqual("orange", radio.Value);

            var inputTextEl = driver.FindElement(By.Name("input-text"));
            FormElement inputText = new FormElementImpl(inputTextEl);
            Assert.AreEqual("initial input-text value", inputText.Value);
            inputTextEl.Clear();
            inputTextEl.SendKeys("new input-text value");
            Assert.AreEqual("new input-text value", inputText.Value);

            var inputHiddenEl = driver.FindElement(By.Name("input-hidden"));
            FormElement inputHidden = new FormElementImpl(inputHiddenEl);
            Assert.AreEqual("initial input-hidden value", inputHidden.Value);

        }

        [TestMethod]
        public void LabelTextWhenWrapped()
        {
            var el = driver.FindElement(By.Id("rorange"));
            FormElement radio = new FormElementImpl(el);
            Assert.AreEqual("Orange", radio.LabelText);
        }

        [TestMethod]
        public void LabelTextWithForAttribute()
        {
            var el = driver.FindElement(By.Id("rviolet"));
            FormElement radio = new FormElementImpl(el);
            Assert.AreEqual("Violet", radio.LabelText);
        }

    }
}
