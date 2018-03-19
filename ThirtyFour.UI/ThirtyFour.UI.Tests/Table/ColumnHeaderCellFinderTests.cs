using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Table;
using System;

namespace ThirtyFour.UI.Tests.Tests.Table
{
    [TestClass]
    public class ColumnHeaderCellFinderTests : BaseTestSuite
    {

        [TestMethod]
        public void InavlidFindColumnHeaderThrowsException()
        {
            string invalidColumn = "shdgydbhdiu";
            ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder(invalidColumn, "First Test Product", "Subtotal");
            try
            {
                IWebElement tableElement = this.driver.FindElement(By.ClassName("cart"));
                finder.FindCell(tableElement);
            }
            catch (NoSuchElementException ex)
            {
                string message = String.Format("Unable to find column with header text '{0}'", invalidColumn);
                Assert.AreEqual(message, ex.Message);
            }
        }

        [TestMethod]
        public void InavlidReturnColumnHeaderThrowsException()
        {
            string invalidColumn = "shdgydbhdiu";
            ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder("Product", "First Test Product", invalidColumn);
            try
            {
                IWebElement tableElement = this.driver.FindElement(By.ClassName("cart"));
                finder.FindCell(tableElement);
            }
            catch (NoSuchElementException ex)
            {
                string message = String.Format("Unable to find column with header text '{0}'", invalidColumn);
                Assert.AreEqual(message, ex.Message);
            }
        }

        [TestMethod]
        public void InavlidFindValueThrowsException()
        {
            string invalidValue = "shdgydbhdiu";
            ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder("Product", invalidValue, "Subtotal");
            try
            {
                IWebElement tableElement = this.driver.FindElement(By.ClassName("cart"));
                finder.FindCell(tableElement);
            }
            catch (NoSuchElementException ex)
            {
                string message = String.Format("Unable to find row containing find value '{0}'", invalidValue);
                Assert.AreEqual(message, ex.Message);
            }
        }

        [TestMethod]
        public void TestFindCellReturnsCorrectWebElement()
        {
            ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder("Product", "First Test Product", "Subtotal");
            IWebElement tableElement = this.driver.FindElement(By.ClassName("cart"));
            IWebElement cell = finder.FindCell(tableElement);
            Assert.AreEqual("$9.99", cell.Text);
        }
    }
}
