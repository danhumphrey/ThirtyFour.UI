using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// The BrowserWindow class provides an easy method for finding and switching to additional browser windows
    /// </summary>
    public class BrowserWindow
    {
        const double DEFAULT_TIMEOUT_IN_SECONDS = 10;

        /// <summary>
        /// The driver instance
        /// </summary>
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// The default window handle
        /// </summary>
        public string DefaultHandle { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        public BrowserWindow(IWebDriver driver) : this(driver, new DefaultMatcher(), DEFAULT_TIMEOUT_IN_SECONDS)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        /// <param name="matcher">An instance of IMatcher</param>
        /// <param name="timeoutInSeconds">The number of seconds before timing out</param>
        public BrowserWindow(IWebDriver driver, IMatcher matcher, double timeoutInSeconds)
        {
            this.DefaultHandle = driver.CurrentWindowHandle;
            this.Driver = driver;
            matcher.MatchWindow(driver, timeoutInSeconds);
        }

    }
}
