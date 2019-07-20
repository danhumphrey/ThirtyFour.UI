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

        [TestMethod]
        public void TestFalseResultNotReturnedBeforeTimeout()
        {
            DateTime start = DateTime.UtcNow;

            bool result = Utils.RetryUntilTimeout(TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(100), () =>
            {
                Thread.Sleep(50);
                return false;
            });

            DateTime end = DateTime.UtcNow;
            TimeSpan diff = end.Subtract(start);

            Assert.IsTrue(diff.Milliseconds > 500);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestSuccessResultReturnedBeforeTimeout()
        {
            DateTime start = DateTime.UtcNow;

            bool result = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100), () =>
            {
                return true;
            });

            DateTime end = DateTime.UtcNow;
            TimeSpan diff = end.Subtract(start);

            Assert.IsTrue(diff.Milliseconds < 200);
            Assert.IsTrue(result);
        }
    }
}
