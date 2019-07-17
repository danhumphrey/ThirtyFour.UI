package com.github.danhumphrey.thirtyfour.ui.form;

import java.util.ArrayList;
import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;

/**
 * The RadioBUtton class provides helper methods for interacting with a HTML radio button and other radio buttons in the same group
 */
public class RadioButton extends BooleanElement {

	/**
	 * Constructor
	 * @param element the wrapped radio button element 
	 */
	public RadioButton(WebElement element) {
		super(element);
	}
	
	/**
	 * Checks the radio button
	 */
	public void setChecked() {
		if(!this.element.isSelected()) {
			this.element.click();
		}
	}

	/**
	 * Gets a list of all radio buttons in the group
	 * @return a list of all buttons in the group
	 */
	public List<RadioButton> getGroupButtons() {
		List<RadioButton> buttons = new ArrayList<RadioButton>();
		String buttonName = this.element.getAttribute("name");
		if(buttonName == null) {
			buttons.add(this);
		} else {
			List<WebElement> allElements = this.driver.findElements(By.cssSelector((String.format("input[type='radio'][name='%s']",buttonName))));
			for(WebElement el : allElements) {
				buttons.add(new RadioButton(el));
			}
		}
		return buttons;
	}
	
	/**
	 * Gets the selected radio button from the the group
	 * @return the selected radio button or null none are selected
	 */
	public RadioButton getSelectedGroupButton() {
		List<RadioButton> buttons = this.getGroupButtons();
		for(RadioButton button :  buttons) {
			if(button.getChecked()) {
				return button;
			}
		}
		return null;
	}
	
	/**
	 * Gets the value of the selected radio button in the group
	 * @return the value of the selected radio button or an empty string
	 */
	public String getGroupValue() {
		
		RadioButton button = this.getSelectedGroupButton();
		if(button == null) {
			return "";
		}
		return button.getValue();
	}

	/**
	 * Checks a radio button in the same group which has a matching value
	 * @param value the value of the radio button
	 * @throws NoSuchElementException if a matching radio button cannot be found
	 */
	public void setCheckedByValue(String value) throws NoSuchElementException{
		List<RadioButton> buttons = this.getGroupButtons();
		for(RadioButton button :  buttons) {
			if(button.getValue().equals(value)) {
				button.setChecked();
				return;
			}
		}
		throw new NoSuchElementException("Unable to find radio button with value " + value);
	}

	/**
	 * Checks a radio button in the same group which has a matching value
	 * @param label the label of the radio button
	 * @throws NoSuchElementException if a matching radio button cannot be found
	 */
	public void setCheckedByLabel(String label) throws NoSuchElementException{
		List<RadioButton> buttons = this.getGroupButtons();
		for(RadioButton button :  buttons) {
			if(button.getLabelText().equals(label)) {
				button.setChecked();
				return;
			}
		}
		throw new NoSuchElementException("Unable to find Radio button with label " + label);
		
	}
}
