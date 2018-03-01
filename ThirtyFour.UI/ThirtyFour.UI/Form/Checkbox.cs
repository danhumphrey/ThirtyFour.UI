using OpenQA.Selenium;

namespace ThirtyFour.UI.Form
{
    public class Checkbox : BooleanElement
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The checkbox element to wrap</param>
        public Checkbox(IWebElement element) : base(element) { }

        /// <summary>
        /// Sets the checked state of the element
        /// </summary>
        /// <param name="onOrOff">the boolean state of the element</param>
        public void SetChecked(bool onOrOff)
        {
            if ((onOrOff && !this.IsChecked) || (!onOrOff && this.IsChecked))
            {
                this.Element.Click();
            }
        }

    }
}
