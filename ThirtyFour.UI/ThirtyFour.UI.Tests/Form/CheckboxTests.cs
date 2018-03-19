using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Form;

namespace ThirtyFour.UI.Tests.Tests.Form
{
    [TestClass]
    public class CheckboxTests : BaseTestSuite
    {

        [TestMethod]
        public void SetCheckedTrueUpdatesCheckedState()
        {
            var cbRed = new Checkbox(driver.FindElement(By.Id("cbred")));
            Assert.IsFalse(cbRed.IsChecked);
            cbRed.SetChecked(true);
            Assert.IsTrue(cbRed.IsChecked);
        }

        [TestMethod]
        public void SetCheckedFalseUpdatesCheckedState()
        {
            var cbGreen = new Checkbox(driver.FindElement(By.Id("cbgreen")));
            Assert.IsTrue(cbGreen.IsChecked);
            cbGreen.SetChecked(false);
            Assert.IsFalse(cbGreen.IsChecked);
        }

    }
}
