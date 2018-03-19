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
        /// The driver instance
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
        public PopupWindow(IWebDriver driver):this(driver, new DefaultWindowSwitcher())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">The IWebDriver instance</param>
        /// <param name="finder">An instance of IWindowSwitcher</param>
        public PopupWindow(IWebDriver driver, IWindowSwitcher finder)
        {
            this.DefaultHandle = driver.CurrentWindowHandle;
            this.Driver = driver;
            finder.SwitchWindow(driver);
        }

    }
}
