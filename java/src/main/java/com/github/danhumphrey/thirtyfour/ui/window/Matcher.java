package com.github.danhumphrey.thirtyfour.ui.window;

import org.openqa.selenium.WebDriver;

/**
 * A basic strategy for matching browser windows
 */
public interface Matcher {
	
	/**
	 * @param driver the <code>WebDriver</code> instance
	 * @param timeoutInSeconds The number of seconds to keep trying to find the matching popup window
	 * @throws Exception if a matching browser window cannot be found
	 */
	public void matchWindow(WebDriver driver, long timeoutInMilliseconds) throws Exception;
}
