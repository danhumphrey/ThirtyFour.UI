using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyFour.UI
{
    /// <summary>
    /// Wraps a WebElement to provide specialized functionality
    /// </summary>
    public class WrappedElement
    {
        protected IWebElement element;
        protected IWebDriver driver;
        protected IWebElement parentElement;

        /// <summary>
        /// The wrapped WebElement
        /// </summary>
        public IWebElement Element
        {
            get
            {
                return element;
            }

            private set
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

            private set
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
                return this.GetAncestorElement("*[1]");
            }

            private set
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
            this.Element = element;
            this.Driver = ((IWrapsDriver)element).WrappedDriver;

        }


        /// <summary>
        /// Returns the ancestor of the wrapped element filtered by tagName
        /// </summary>
        /// <param name="tagName">the name of the tage to filter by</param>
        /// <returns>IWebElement the mtaching parent element or null</returns>

        public IWebElement GetAncestorElement(string tagName)
        {
            IWebElement parent = null;
            IReadOnlyCollection<IWebElement> els = this.Element.FindElements(By.XPath("ancestor::" + tagName));
            if (els.Count > 0)
            {
                parent = els.ElementAt(0);
            }
            return parent;
        }
    }
}
