using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Form;

namespace ThirtyFour.UI.Tests.Form
{
    [TestClass]
    public class RadioButtonTests : BaseTestSuite
    {

        [TestMethod]
        public void SetCheckedChangesState()
        {
            var el = driver.FindElement(By.Id("rorange"));
            var radio = new RadioButton(el);
            radio.SetChecked();
            Assert.IsTrue(radio.IsChecked);
        }

        [TestMethod]
        public void GetGroupButtons()
        {
            var el = driver.FindElement(By.Id("rorange"));
            var radio = new RadioButton(el);
            var buttons = radio.GetGroupButtons();
        }

        [TestMethod]
        public void GetSelectedGroupButton()
        {
            var el = driver.FindElement(By.Id("rorange"));
            var radio = new RadioButton(el);
            var selectedRadioButton = radio.GetSelectedGroupButton();
            Assert.AreEqual("violet", selectedRadioButton.Value);
        }

        [TestMethod]
        public void GetGroupValue()
        {
            var radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));
            var radioViolet = new RadioButton(driver.FindElement(By.Id("rviolet")));
            Assert.AreEqual("violet", radioOrange.GetGroupValue());
            radioOrange.SetChecked();
            Assert.AreEqual("orange", radioViolet.GetGroupValue());
        }

        [TestMethod]
        public void SetCheckedByValueThrowsExceptionForInvalidValue()
        {
            var radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));

            string value = "sbhjsgbjs";

            try
            {
                radioOrange.SetCheckedByValue(value);
            }
            catch (NoSuchElementException ex)
            {
                var exMessage = "Unable to find radio button with value " + value;
                Assert.AreEqual(exMessage, ex.Message);
                return;
            }

            Assert.Fail("Expected NoSuchElementException not thrown");
        }

        [TestMethod]
        public void SetCheckedByValue()
        {
            var radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));
            var radioViolet = new RadioButton(driver.FindElement(By.Id("rviolet")));

            Assert.IsFalse(radioOrange.IsChecked);
            radioViolet.SetCheckedByValue("orange");
            Assert.IsTrue(radioOrange.IsChecked);
        }

        [TestMethod]
        public void SetCheckedByLabelThrowsExceptionForInvalidLabel()
        {
            var radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));

            string label = "sbhjsgbjs";

            try
            {
                radioOrange.SetCheckedByLabel(label);
            }
            catch (NoSuchElementException ex)
            {
                var exMessage = "Unable to find radio button with label " + label;
                Assert.AreEqual(exMessage, ex.Message);
                return;
            }

            Assert.Fail("Expected NoSuchElementException not thrown");
        }

        [TestMethod]
        public void SetCheckedByLabel()
        {
            var radioOrange = new RadioButton(driver.FindElement(By.Id("rorange")));
            var radioViolet = new RadioButton(driver.FindElement(By.Id("rviolet")));

            Assert.IsFalse(radioOrange.IsChecked);
            radioViolet.SetCheckedByLabel("Orange");
            Assert.IsTrue(radioOrange.IsChecked);
        }

    }
}
