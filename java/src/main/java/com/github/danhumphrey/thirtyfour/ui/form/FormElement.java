package com.github.danhumphrey.thirtyfour.ui.form;

import java.util.ArrayList;
import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.WrappedElement;

/**
 * Represents a form element with a label
 */
public abstract class FormElement extends WrappedElement {

	/**
	 * Constructor
	 * @param element the wrapped form element
	 */
	public FormElement(WebElement element) {
		super(element);
	}
	
	/**
	 * Gets the label text of the element
	 * @return the text of the label associated with the element or an empty string
	 */
	public String getLabelText() {
		
		List<WebElement> labels = new ArrayList<WebElement>();
		WebElement parentLabel = null;
		
		//attempt to find label using for=id
		String id = this.element.getAttribute("id");
		if(id != null) {
			labels = this.driver.findElements(By.cssSelector(String.format("label[for='%s']",id)));
		} 
		
		if(labels.size() == 0) { //attempt to find wrapped label element
			parentLabel = this.getAncestorElement("label");
		} else {
			parentLabel = labels.get(0);
		}
		
		return parentLabel == null ? "" : parentLabel.getText();
	}
	
	/**
	 * Gets the value attribute of the element
	 * @return the attribute value
	 */
	public String getValue() {
		return this.element.getAttribute("value");
	}
}