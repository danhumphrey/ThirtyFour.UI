package com.github.danhumphrey.thirtyfour.ui;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.WrapsDriver;


/**
 * The WrappedElement class wraps a <code>WebElement</code> to provide specialized functionality.
 *
 */
public class WrappedElement {

	protected WebElement element;
	protected WebDriver driver;
	
	/**
	 * Constructor
	 * 
	 * @param element the <code>WebElement</code> to wrap
	 */
	public WrappedElement(WebElement element) {
		this.element = element;
		this.driver = ((WrapsDriver)this.element).getWrappedDriver();
	}

	/**
	 * Returns the wrapped element
	 * 
	 * @return the wrapped <code>WebElement</code>
	 */
	public WebElement getElement() {
		return this.element;
	}
	
	/**
	 * Returns the driver
	 * 
	 * @return the <code>WebDriver</code> instance used to locate this element
	 */
	public WebDriver getDriver() {
		return this.driver;
	}
	
	/**
	 * Returns the parent of the wrapped element
	 * 
	 * @return the parent <code>WebElement</code> or <code>null</code> if no parent element exists
	 */
	public WebElement getParentElement() {
		return this.getAncestorElement("*[1]");
	}
	
	/**
	 * Return the ancestor of the wrapped element filtered by <code>tagName</code>
	 * @param tagName the name of the tag to filter by
	 * @return the ancestor <code>WebElement</code> or <code>null</code> if no matching ancestor element exists 
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
