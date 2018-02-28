﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtyFour.UI.Form
{
    /// <summary>
    /// Represents a radio element
    /// </summary>
    public class RadioButton : FormElement
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
        /// The value of the element
        /// </summary>
        public string Value
        {
            get
            {
                return this.Element.GetAttribute("value");
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">The wrapped element</param>
        public RadioButton(IWebElement element) : base(element) { }

        /// <summary>
        /// Clicks the element irrespective of its current state
        /// </summary>
        public void Click()
        {
            this.Element.Click();
        }

        /// <summary>
        /// Checks the radio button
        /// </summary>
        public void SetChecked()
        {
            if (!this.IsChecked)
            {
                this.Click();
            }
        }

        /// <summary>
        /// Returns all radio buttons in the group    
        /// </summary>
        /// <returns>A ReadOnlyCollection of all buttons in the group</returns>
        public IReadOnlyCollection<RadioButton> GetGroupButtons()
        {
            IList<RadioButton> buttons = new List<RadioButton>();
            string buttonName = this.Element.GetAttribute("name");
            if (buttonName == null)
            {
                buttons.Add(this);

            }
            else
            {
                IReadOnlyCollection<IWebElement> buttonElements = this.Driver.FindElements(By.CssSelector(String.Format("input[type='radio'][name='{0}']", buttonName)));
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
            IReadOnlyCollection<RadioButton> buttons = this.GetGroupButtons();
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
            RadioButton button = this.GetSelectedGroupButton();
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
            IReadOnlyCollection<RadioButton> buttons = this.GetGroupButtons();
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
            IReadOnlyCollection<RadioButton> buttons = this.GetGroupButtons();
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
