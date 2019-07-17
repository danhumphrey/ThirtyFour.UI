package com.github.danhumphrey.thirtyfour.ui.form;

import org.openqa.selenium.WebElement;

/**
 * Represents an element with an on/off state
 *
 */
public abstract class BooleanElement extends FormElement {

	/**
	 * Constructor
	 * @param element the wrapped HTML element
	 */
	public BooleanElement(WebElement element) {
		super(element);
	}
	
	/**
	 * Gets the checked state of the element
	 * @return the boolean state of the element
	 */
	public boolean getChecked() {
		return this.element.isSelected();
	}
	
	/**
	 * Clicks the element irrespective of its current state
	 */
	public void click(){
		this.element.click();
	} 
	
}
