using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Collections.Generic;
using System.Linq;

namespace ThirtyFour.UI
{
    /// <summary>
    /// Wraps a WebElement to provide specialized functionality
    /// </summary>
    public class WrappedElement
    {
        private IWebElement element;
        private IWebDriver driver;
        private IWebElement parentElement;

        /// <summary>
        /// The wrapped WebElement
        /// </summary>
        public IWebElement Element
        {
            get
            {
                return element;
            }

            protected set
            {
                element = value;
            }
        }

        /// <summary>
        /// The driver instance used to locate the wrapped element
        /// </summary>
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            protected set
            {
                driver = value;
            }
        }

        /// <summary>
        /// The parent element or null if no parent exists
        /// </summary>
        public IWebElement ParentElement
        {
            get
            {
                return GetAncestorElement("*[1]");
            }

            protected set
            {
                parentElement = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The wrapped web element</param>
        public WrappedElement(IWebElement element)
        {
            Element = element;
            Driver = ((IWrapsDriver)element).WrappedDriver;

        }


        /// <summary>
        /// Returns the ancestor of the wrapped element filtered by tagName
        /// </summary>
        /// <param name="tagName">the name of the tage to filter by</param>
        /// <returns>IWebElement the mtaching parent element or null</returns>

        public IWebElement GetAncestorElement(string tagName)
        {
            IWebElement parent = null;
            IReadOnlyCollection<IWebElement> els = Element.FindElements(By.XPath("ancestor::" + tagName));
            if (els.Count > 0)
            {
                parent = els.ElementAt(0);
            }
            return parent;
        }
    }
}
