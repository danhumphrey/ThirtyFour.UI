using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using ThirtyFour.UI.Form;

namespace ThirtyFour.UI.Tests.Tests
{
    [TestClass]
    public class RadioTests : BaseTestSuite
    {
   
        [TestMethod]
        public void IsCheckedPropertyWhenNotChecked()
        {
            IWebElement el = driver.FindElement(By.Id("rorange"));
            RadioButton radio = new RadioButton(el);
            Assert.IsFalse(radio.IsChecked);
        }

        [TestMethod]
        public void IsCheckedPropertyWhenChecked()
        {
            IWebElement el = driver.FindElement(By.Id("rviolet"));
            RadioButton radio = new RadioButton(el);
            Assert.IsTrue(radio.IsChecked);
        }

        [TestMethod]
        public void SetCheckedChangesState()
        {
            IWebElement el = driver.FindElement(By.Id("rorange"));
            RadioButton radio = new RadioButton(el);
            radio.SetChecked();
            Assert.IsTrue(radio.IsChecked);
        }

        [TestMethod]
        public void GetGroupButtons()
        {
            IWebElement el = driver.FindElement(By.Id("rorange"));
            RadioButton radio = new RadioButton(el);
            IReadOnlyCollection<RadioButton> buttons = radio.GetGroupButtons();
        }

        [TestMethod]
        public void GetSelectedGroupButton()
        {
            IWebElement el = driver.FindElement(By.Id("rorange"));
            RadioButton radio = new RadioButton(el);
            RadioButton selectedRadioButton = radio.GetSelectedGroupButton();
            Assert.AreEqual("violet", selectedRadioButton.Value);
        }

        [TestMethod]
        public void GetGroupValue()
        {
            RadioButton radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));
            RadioButton radioViolet = new RadioButton(driver.FindElement(By.Id("rviolet")));
            Assert.AreEqual("violet", radioOrange.GetGroupValue());
            radioOrange.SetChecked();
            Assert.AreEqual("orange", radioViolet.GetGroupValue());
        }

        [TestMethod]
        public void SetCheckedByValueThrowsExceptionForInvalidValue()
        {
            RadioButton radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));

            string value = "sbhjsgbjs";

            try
            {
                radioOrange.SetCheckedByValue(value);
            }
            catch (NoSuchElementException ex)
            {
                string exMessage = "Unable to find radio button with value " + value;
                Assert.AreEqual(exMessage, ex.Message);
                return;
            }

            Assert.Fail("Expected NoSuchElementException not thrown");
        }

        [TestMethod]
        public void SetCheckedByValue()
        {
            RadioButton radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));
            RadioButton radioViolet = new RadioButton(driver.FindElement(By.Id("rviolet")));

            Assert.IsFalse(radioOrange.IsChecked);
            radioViolet.SetCheckedByValue("orange");
            Assert.IsTrue(radioOrange.IsChecked);
        }

        [TestMethod]
        public void SetCheckedByLabelThrowsExceptionForInvalidLabel()
        {
            RadioButton radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));

            string label = "sbhjsgbjs";

            try
            {
                radioOrange.SetCheckedByLabel(label);
            }
            catch (NoSuchElementException ex)
            {
                string exMessage = "Unable to find radio button with label " + label;
                Assert.AreEqual(exMessage, ex.Message);
                return;
            }

            Assert.Fail("Expected NoSuchElementException not thrown");
        }

        [TestMethod]
        public void SetCheckedByLabel()
        {
            RadioButton radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));
            RadioButton radioViolet = new RadioButton(driver.FindElement(By.Id("rviolet")));

            Assert.IsFalse(radioOrange.IsChecked);
            radioViolet.SetCheckedByLabel("Orange");
            Assert.IsTrue(radioOrange.IsChecked);
        }

    }
}
