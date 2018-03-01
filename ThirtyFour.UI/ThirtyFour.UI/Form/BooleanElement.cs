using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyFour.UI.Form
{
    public abstract class BooleanElement : FormElement
    {
        /// <summary>
        /// The checked state of the element
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return this.Element.Selected;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The wrapped element</param>
        public BooleanElement(IWebElement element) : base(element) { }
    }
}
