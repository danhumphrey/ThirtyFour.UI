package com.github.danhumphrey.thirtyfour.ui.test.window;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;
import com.github.danhumphrey.thirtyfour.ui.window.TitleMatcher;

public class TitleMatcherTests extends BaseTestSuite {

	@Test
	public void testExceptionThrownWhenNoMatchingTitle() {

		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();

		try {
			new TitleMatcher("shjksjd").matchWindow(driver, 1000);
			Assertions.fail("An exception should have been thrown");
		} catch (Exception e) {
			Assertions.assertEquals("Unable to find a matching window", e.getMessage());
		} finally {
			quitExtraDrivers(currentHandle);
		}
	}

	@Test
    public void WindowSwitchedWhenMatchingTitle() throws Exception
    {
    	WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();

		driver.findElement(By.linkText("Popup")).click();
		
		try {
	        new TitleMatcher("GitHub - danhumphrey/ThirtyFour.UI: A Selenium (element 34) WebDriver UI Library for C# and Java").matchWindow(driver, 1000);
	        Assertions.assertEquals("https://github.com/danhumphrey/ThirtyFour.UI", driver.getCurrentUrl());
		} finally {
			quitExtraDrivers(currentHandle);
		}
        
    }

	@Test
    public void testWindowSwitchedWhenMatchingTitleOfDelayedWindow() throws Exception
    {
    	WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
        driver.findElement(By.linkText("Delayed Popup")).click();
        
        try {
	        new TitleMatcher("GitHub - danhumphrey/ThirtyFour.UI: A Selenium (element 34) WebDriver UI Library for C# and Java").matchWindow(driver, 5000);
	        Assertions.assertEquals("https://github.com/danhumphrey/ThirtyFour.UI", driver.getCurrentUrl());
		} finally {
			quitExtraDrivers(currentHandle);
		}
    }
}
