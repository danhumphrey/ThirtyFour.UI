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

        string windowHandle;

        public TestContext TestContext { get; set; }

        protected string Url
        {
            get
            {

                return Path.Combine(Path.GetDirectoryName(typeof(BaseTestSuite).GetTypeInfo().Assembly.GetName().CodeBase), "Resources", "index.html");
            }
        }

        public BaseTestSuite()
        {
            var chromeService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            driver = new ChromeDriver(chromeService, chromeOptions);
            windowHandle = driver.CurrentWindowHandle;
        }

        [TestInitialize]
        public void TestSetup()
        {
            

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
        }


        [TestCleanup]
        public void TearDown()
        {
            IReadOnlyCollection<String> windows = driver.WindowHandles;

            foreach (String handle in windows)
            {
                if (!handle.Equals(windowHandle))
                {
                    driver.SwitchTo().Window(handle);
                    driver.Close();
                    driver.SwitchTo().Window(windowHandle);
                }
            }

            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = Path.GetFullPath(Path.Combine("", "Screenshot_" + TestContext.TestName + DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss") + ".png"));
                screenShot.SaveAsFile((fileName), ScreenshotImageFormat.Png);
                // TestContext.AddResultFile(fileName); Missing in dotnet core https://github.com/Microsoft/testfx/issues/394
                TestContext.WriteLine($"Screenshot created {fileName}");


            }

            driver.Close();
            driver.Quit();
        }

    }
}
