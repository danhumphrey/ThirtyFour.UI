using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtyFour.UI.Form
{
    /// <summary>
    /// Represents a form element with a label
    /// </summary>
    public abstract class FormElement : WrappedElement
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The wrapped form element</param>
        public FormElement(IWebElement element) : base(element) { }

        /// <summary>
        /// The value of the element
        /// </summary>
        public string Value
        {
            get
            {
                return Element.GetAttribute("value");
            }
        }

        /// <summary>
        /// The label text of the element or an empty string if no associated label
        /// </summary>
        public string LabelText
        {
            get
            {
                IReadOnlyCollection<IWebElement> labels = null;
                IWebElement parentLabel = null;

                //attempt to find label using for=id
                string id = Element.GetAttribute("id");
                if (id != null)
                {
                    labels = Driver.FindElements(By.CssSelector(String.Format("label[for='{0}']", id)));
                }

                if (labels == null || labels.Count == 0) //attempt to find wrapped label element
                {
                    parentLabel = GetAncestorElement("label");
                }
                else
                {
                    parentLabel = labels.ElementAt(0);
                }

                return parentLabel == null ? "" : parentLabel.Text;
            }
        }
    }
}
