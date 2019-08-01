package com.github.danhumphrey.thirtyfour.ui.window;

import org.openqa.selenium.WebDriver;

/**
 * The BrowserWindow class provides an easy method for finding and switching to additional browser windows
 *
 */
public class BrowserWindow {

	private WebDriver driver;
	private String defaultHandle;
	
	final static long DEFAULT_TIMEOUT_IN_SECONDS = 10;

	
	/**
	 * Constructor
	 * 
	 * @param driver the <code>WebDriver</code> instance
	 * @throws Exception 
	 */
	public BrowserWindow(WebDriver driver) throws Exception {
		this(driver, new DefaultMatcher(), BrowserWindow.DEFAULT_TIMEOUT_IN_SECONDS);
	}
	
	/**
	 * Constructor
	 * 
	 * @param driver the <code>WebDriver</code> instance
	 * @param matcher a <Matcher> instance to match the window
	 * @param timeoutInMilliseconds The number of milliseconds before timing out
	 * @throws Exception if window cannot be found
	 */ 
	public BrowserWindow(WebDriver driver, Matcher matcher, long timeoutInMilliseconds) throws Exception {
		this.driver = driver;
		this.defaultHandle = driver.getWindowHandle();
		matcher.matchWindow(driver, timeoutInMilliseconds);
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
