package com.github.danhumphrey.thirtyfour.ui.form;

import org.openqa.selenium.WebElement;

/**
 * The Checkbox class provides helper methods for interacting with a HTML checkbox
 */
public class Checkbox extends BooleanElement {

	public Checkbox(WebElement element) {
		super(element);
	}

	/**
	 * Sets the checked state of the element
	 * @param onOrOff the boolean state of the element
	 */
	public void setChecked(boolean onOrOff) {
		if( (onOrOff && !getChecked()) || (!onOrOff && getChecked()) ) {
	        click();
	    }
	}
	
}
