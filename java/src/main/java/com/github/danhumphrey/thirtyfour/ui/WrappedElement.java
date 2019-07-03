package com.github.danhumphrey.thirtyfour.ui;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.WrapsDriver;


/**
 * wraps a WebElement to provide specialized functionality
 * @author dhumphrey
 *
 */
public class WrappedElement {

	protected WebElement element;
	protected WebDriver driver;
	
	/**
	 * Constructor
	 * @param element the element to wrap
	 */
	public WrappedElement(WebElement element) {
		this.element = element;
		this.driver = ((WrapsDriver)this.element).getWrappedDriver();
	}

	/**
	 * returns the wrapped element
	 * @return the wrapped element
	 */
	public WebElement getElement() {
		return this.element;
	}
	
	/**
	 * returns the driver
	 * @return the driver instance used to locate this element
	 */
	public WebDriver getDriver() {
		return this.driver;
	}
	
	/**
	 * returns the parent of the wrapped element
	 * @return the parent WebElement or null if no parent element exists
	 */
	public WebElement getParentElement() {
		return this.getAncestorElement("*[1]");
	}
	
	/**
	 * return the ancestor of the wrapped element filtered by tagName
	 * @param tagName the name of the tag to filter by
	 * @return the ancestor WebElement or null if no matching parent element exists 
	 */
	public WebElement getAncestorElement(String tagName) {
		WebElement parent = null;
		List<WebElement> els = this.element.findElements(By.xpath("ancestor::" + tagName));
		if(els.size() > 0) {
			parent = els.get(0);
		}
		return parent;
	}
}
