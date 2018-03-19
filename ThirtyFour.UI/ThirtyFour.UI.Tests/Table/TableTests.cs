using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace ThirtyFour.UI.Tests.Tests.Table
{
    using Table = ThirtyFour.UI.Table.Table;

    [TestClass]
    public class TableTests : BaseTestSuite
    {
        [TestMethod]
        public void TestHeaderCells()
        {
            Table table = new Table(driver.FindElement(By.ClassName("cart")));
            Assert.AreEqual(4, table.HeaderCells.Count);
        }

        [TestMethod]
        public void TestBodyRows()
        {
            Table table = new Table(driver.FindElement(By.ClassName("cart")));
            Assert.AreEqual(3, table.BodyRows.Count);
        }

        [TestMethod]
        public void TestGetCellValue()
        {
            Table table = new Table(driver.FindElement(By.ClassName("cart")));
            String cellValue = table.GetCellValue("Product", "First Test Product", "Subtotal");
            Assert.AreEqual("$9.99", cellValue);
        }
    }
}
