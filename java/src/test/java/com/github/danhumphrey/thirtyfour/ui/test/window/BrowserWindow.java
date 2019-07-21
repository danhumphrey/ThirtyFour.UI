package com.github.danhumphrey.thirtyfour.ui.test.window;

import org.openqa.selenium.WebDriver;

/**
 * The BrowserWindow class provides an easy method for finding and switching to additional browser windows
 *
 */
public class BrowserWindow {

	private WebDriver driver;
	private String defaultHandle;
	
	
	
	/**
	 * Constructor
	 * 
	 *  @param driver the <code>WebDriver</code> instance
	 */
	public BrowserWindow(WebDriver driver) {
		this.driver = driver;
		this.defaultHandle = driver.getWindowHandle();
	}
	
	/**
	 * @return the driver
	 */
	public WebDriver getDriver() {
		return driver;
	}
	
	/**
	 * @return the default window handle
	 */
	public String getDefaultHandle() {
		return defaultHandle;
	}

}
