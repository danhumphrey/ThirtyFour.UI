using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ThirtyFour.UI.Tests
{
    [TestClass]
    public abstract class BaseTestSuite
    {
        public TestContext TestContext { get; set; }

        static IWebDriver DRIVER_INSTANCE;
        protected IWebDriver driver;
        string windowHandle;

        protected string Url {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "Resources", "index.html");
            }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {

            var chromeService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            DRIVER_INSTANCE = new ChromeDriver(chromeService, chromeOptions);
            
        }

        public BaseTestSuite()
        {
            driver = DRIVER_INSTANCE;
            windowHandle = driver.CurrentWindowHandle;
        }

        [TestInitialize]
        public void TestSetup()
        {
            DRIVER_INSTANCE.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
        }

        [TestCleanup]
        public void TestCleanup()
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
                if (!Directory.Exists(TestContext.TestResultsDirectory))
                {
                    Directory.CreateDirectory(TestContext.TestResultsDirectory);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = TestContext.TestResultsDirectory + "\\Screenshot_" + TestContext.TestName + DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss") + ".png";
                screenShot.SaveAsFile((fileName), ScreenshotImageFormat.Png);
                TestContext.AddResultFile(fileName);
            }
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            DRIVER_INSTANCE.Quit();
        }
    }
}
