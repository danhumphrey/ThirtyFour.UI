using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ThirtyFour.UI.Tests
{
    static class DriverFactory
    {
        public static IWebDriver BuildDriver(IDictionary<string, object> properties)
        {
            IWebDriver driverInstance;

            var browser = properties["browser"];

            switch (browser.ToString().ToLower())
            {
                case "chrome":
                    // chromedriver in path, or set ....
                    // System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"path/to/chromedriver");

                    var chromeService = ChromeDriverService.CreateDefaultService();
                    var chromeOptions = new ChromeOptions();
                    driverInstance = new ChromeDriver(chromeService, chromeOptions);
                    break;
                case "firefox":
                    // geckodriver in path, or set ....
                    // System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"path/to/geckodriver");

                    var firefoxService = FirefoxDriverService.CreateDefaultService();
                    var firefoxOptions = new FirefoxOptions();
                    driverInstance = new FirefoxDriver(firefoxService, firefoxOptions);
                    break;
                default:
                    throw new ArgumentException($"Invalid local browser parameter - '{browser}'");
            }

            driverInstance.Manage().Window.Maximize();
            driverInstance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Double.Parse(properties["implicitWaitSeconds"].ToString()));
            return driverInstance;
        }

       
    }
}
