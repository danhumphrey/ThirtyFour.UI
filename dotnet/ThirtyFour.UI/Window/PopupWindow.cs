using OpenQA.Selenium;

namespace ThirtyFour.UI.Window
{
    /// <summary>
    /// The Window class provides an easy method for dealing with a popup window
    /// </summary>
    public class PopupWindow
    {
        private IWebDriver driver;
        private string defaultHandle;

        /// <summary>
        /// The driver instance
        /// </summary>
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            private set
            {
                driver = value;
            }
        }

        /// <summary>
        /// The default window handle
        /// </summary>
        public string DefaultHandle
        {
            get
            {
                return defaultHandle;
            }

            private set
            {
                defaultHandle = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        public PopupWindow(IWebDriver driver):this(driver, new DefaultMatcher())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        /// <param name="matcher">An instance of IMatcher</param>
        public PopupWindow(IWebDriver driver, IMatcher matcher)
        {
            this.DefaultHandle = driver.CurrentWindowHandle;
            this.Driver = driver;
            matcher.MatchWindow(driver, 10);
            this.DefaultHandle = driver.CurrentWindowHandle;
        }

    }
}
