using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ThirtyFour.UI.Table;

namespace ThirtyFour.UI.Tests.Tests.Table
{
    [TestClass]
    public class ChildElementCellParserTests : BaseTestSuite
    {
        
        [TestMethod]
        public void ParserReturnsCorrectElement()
        {
            IWebElement cell = driver.FindElement(By.Id("first-action-cell"));
            ICellParser<IWebElement> parser = new ChildElementCellParser(By.TagName("button"));
            Assert.AreEqual("first-button", parser.GetValue(cell).GetAttribute("id"));
        }
    }
}
