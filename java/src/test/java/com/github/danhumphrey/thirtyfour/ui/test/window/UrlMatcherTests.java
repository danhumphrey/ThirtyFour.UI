package com.github.danhumphrey.thirtyfour.ui.test.window;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;
import com.github.danhumphrey.thirtyfour.ui.window.TitleMatcher;
import com.github.danhumphrey.thirtyfour.ui.window.UrlMatcher;

public class UrlMatcherTests extends BaseTestSuite {

	@Test
	public void testExceptionThrownWhenNoMatchingUrl() {

		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();

		try {
			new UrlMatcher("shjksjd").matchWindow(driver, 1000);
			Assertions.fail("An exception should have been thrown");
		} catch (Exception e) {
			Assertions.assertEquals("Unable to find a matching window", e.getMessage());
		} finally {
			quitExtraDrivers(currentHandle);
		}
	}

	@Test
    public void WindowSwitchedWhenMatchingUrl() throws Exception
    {
    	WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();

		driver.findElement(By.linkText("Popup")).click();
		
		try {
	        new UrlMatcher("https://github.com/danhumphrey/ThirtyFour.UI").matchWindow(driver, 1000);
	        Assertions.assertEquals("https://github.com/danhumphrey/ThirtyFour.UI", driver.getCurrentUrl());
		} finally {
			quitExtraDrivers(currentHandle);
		}
        
    }

	@Test
    public void testWindowSwitchedWhenMatchingUrlOfDelayedWindow() throws Exception
    {
    	WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
        driver.findElement(By.linkText("Delayed Popup")).click();
        
        try {
	        new UrlMatcher("https://github.com/danhumphrey/ThirtyFour.UI").matchWindow(driver, 5000);
	        Assertions.assertEquals("https://github.com/danhumphrey/ThirtyFour.UI", driver.getCurrentUrl());
		} finally {
			quitExtraDrivers(currentHandle);
		}
    }
}
