using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThirtyFour.UI.Tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void TestTimeoutReturnsFalse()
        {
            bool result = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(1), () =>
            {
                Thread.Sleep(1000);
                return false;
            });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestSuccessReturnsTrue()
        {
            bool result = Utils.RetryUntilTimeout(TimeSpan.FromSeconds(1), () =>
            {
                return true;
            });

            Assert.IsTrue(result);
        }
    }
}
