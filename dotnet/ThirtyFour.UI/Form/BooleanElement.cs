﻿using OpenQA.Selenium;

namespace ThirtyFour.UI.Form
{
    public abstract class BooleanElement : FormElement
    {
        /// <summary>
        /// The checked state of the element
        /// </summary>
        public bool IsChecked => Element.Selected;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The wrapped element</param>
        protected BooleanElement(IWebElement element) : base(element) { }
    }
}
