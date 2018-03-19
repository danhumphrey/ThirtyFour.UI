using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace ThirtyFour.UI.Tests.Table
{
    using TableElement = ThirtyFour.UI.Table.TableElement;

    [TestClass]
    public class TableTests : BaseTestSuite
    {
        [TestMethod]
        public void TestHeaderCells()
        {
            TableElement table = new TableElement(driver.FindElement(By.ClassName("cart")));
            Assert.AreEqual(4, table.HeaderCells.Count);
        }

        [TestMethod]
        public void TestBodyRows()
        {
            TableElement table = new TableElement(driver.FindElement(By.ClassName("cart")));
            Assert.AreEqual(3, table.BodyRows.Count);
        }

        [TestMethod]
        public void TestGetCellValue()
        {
            TableElement table = new TableElement(driver.FindElement(By.ClassName("cart")));
            String cellValue = table.GetCellValue("Product", "First Test Product", "Subtotal");
            Assert.AreEqual("$9.99", cellValue);
        }
    }
}
