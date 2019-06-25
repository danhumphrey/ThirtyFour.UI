using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ThirtyFour.UI.Tests
{
    public class BaseTestSuite
    {
        [ThreadStatic]
        protected static IWebDriver driver;

        [ThreadStatic]
        protected static string windowHandle;

        public TestContext TestContext { get; set; }

        protected string Url
        {
            get
            {

                return Path.Combine(Path.GetDirectoryName(typeof(BaseTestSuite).GetTypeInfo().Assembly.GetName().CodeBase), "Resources", "index.html");
            }
        }

        [TestInitialize]
        public void TestSetup()
        {
            driver = DriverFactory.BuildDriver(TestContext.Properties);
            windowHandle = driver.CurrentWindowHandle;
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
        }


        [TestCleanup]
        public void TearDown()
        {

            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = Path.GetFullPath(Path.Combine("", "Screenshot_" + TestContext.TestName + DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss") + ".png"));
                screenShot.SaveAsFile((fileName), ScreenshotImageFormat.Png);
                // TestContext.AddResultFile(fileName); Missing in dotnet core https://github.com/Microsoft/testfx/issues/394
                TestContext.WriteLine($"Screenshot created {fileName}");


            }

            driver.Quit();
        }

    }
}
