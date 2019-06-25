using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirtyFour.UI.Util;

namespace ThirtyFour.UI.Tests.Util
{
    [TestClass]
    public class UtilsTests : BaseTestSuite
    {
        [TestMethod]
        public void TestTimeoutReturnsFalse()
        {
            bool result = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(500), () =>
            {
                Thread.Sleep(1000);
                return false;
            });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestSuccessReturnsTrue()
        {
            bool result = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(500), () =>
            {
                return true;
            });

            Assert.IsTrue(result);
        }

    }
}
