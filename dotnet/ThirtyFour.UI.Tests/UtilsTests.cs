using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace ThirtyFour.UI.Tests
{
    [TestClass]
    public class UtilsTests
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
