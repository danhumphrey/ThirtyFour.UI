using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ThirtyFour.UI.Form
{
    /// <summary>
    /// Represents a HTML radio button element
    /// </summary>
    public class RadioButton : BooleanElement
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The wrapped element</param>
        public RadioButton(IWebElement element) : base(element) { }


        /// <summary>
        /// Checks the radio button
        /// </summary>
        public void SetChecked()
        {
            if (!IsChecked)
            {
                Element.Click();
            }
        }

        /// <summary>
        /// Returns all radio buttons in the group    
        /// </summary>
        /// <returns>A ReadOnlyCollection of all buttons in the group</returns>
        public IReadOnlyCollection<RadioButton> GetGroupButtons()
        {
            var buttons = new List<RadioButton>();
            var buttonName = Element.GetAttribute("name");
            if (buttonName == null)
            {
                buttons.Add(this);

            }
            else
            {
                var buttonElements = Driver.FindElements(By.CssSelector(String.Format("input[type='radio'][name='{0}']", buttonName)));
                foreach (IWebElement el in buttonElements)
                {
                    buttons.Add(new RadioButton(el));
                }
            }
            return new ReadOnlyCollection<RadioButton>(buttons);
        }

        /// <summary>
        /// Gets the selected radio button from the the group
        /// </summary>
        /// <returns>the selected radio button</returns>
        public RadioButton GetSelectedGroupButton()
        {
            var buttons = GetGroupButtons();
            foreach (RadioButton button in buttons)
            {
                if (button.IsChecked)
                {
                    return button;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the value of the selected radio button in the same group
        /// </summary>
        /// <returns>The value of the selected radio button or an empty string</returns>
        public string GetGroupValue()
        {
            var button = GetSelectedGroupButton();
            if (button == null)
            {
                return "";
            }
            return button.Value;
        }

        /// <summary>
        /// Checks a radio button in the same group which has a matching value
        /// </summary>
        /// <param name="value">the value fo the radio button</param>
        public void SetCheckedByValue(string value)
        {
            var buttons = GetGroupButtons();
            foreach (RadioButton button in buttons)
            {
                if (button.Value.Equals(value))
                {
                    button.SetChecked();
                    return;
                }
            }
            throw new NoSuchElementException("Unable to find radio button with value " + value);
        }

        /// <summary>
        /// Checks a radio button in the same group which has a matching label
        /// </summary>
        /// <param name="label">the value fo the radio button</param>
        public void SetCheckedByLabel(string label)
        {
            var buttons = GetGroupButtons();
            foreach (RadioButton button in buttons)
            {
                if (button.LabelText.Equals(label))
                {
                    button.SetChecked();
                    return;
                }
            }
            throw new NoSuchElementException("Unable to find radio button with label " + label);
        }
    }
}
