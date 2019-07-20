using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// The BrowserWindow class provides an easy method for finding and switching to additional browser windows
    /// </summary>
    public class BrowserWindow

    {

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
        public BrowserWindow(IWebDriver driver) : this(driver, new DefaultMatcher())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        /// <param name="matcher">An instance of IMatcher</param>
        public BrowserWindow(IWebDriver driver, IMatcher matcher)
        {
            this.DefaultHandle = driver.CurrentWindowHandle;
            this.Driver = driver;
            matcher.MatchWindow(driver, 10);
            this.DefaultHandle = driver.CurrentWindowHandle;
        }

    }
}
