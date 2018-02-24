using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirtyFour.UI.Tests.Tests
{
    [TestClass]
    public class UnitTest1 : BaseTestSuite
    {
        protected override string Url
        {
            get {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "Resources", "index.html");
            }
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
