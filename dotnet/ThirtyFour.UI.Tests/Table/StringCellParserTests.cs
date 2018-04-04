using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Table;

namespace ThirtyFour.UI.Tests.Table
{
    [TestClass]
    public class StringCellParserTests : BaseTestSuite
    {

        [TestMethod]
        public void ParserGetValueReturnsCellValue()
        {
            IWebElement cell = driver.FindElement(By.ClassName("first-product"));
            ICellParser<string> parser = new StringCellParser();
            Assert.AreEqual("First Test Product", parser.GetValue(cell));
        }
    }
}
