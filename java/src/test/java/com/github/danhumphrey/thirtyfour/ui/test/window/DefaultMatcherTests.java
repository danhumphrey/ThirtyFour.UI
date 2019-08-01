package com.github.danhumphrey.thirtyfour.ui.test.window;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;
import com.github.danhumphrey.thirtyfour.ui.window.DefaultMatcher;

public class DefaultMatcherTests extends BaseTestSuite {
	
	@Test
	public void testExceptionThrownWhenNoPopupExists() throws Exception {
		
		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
		try {
			new DefaultMatcher().matchWindow(driver, 2000);
			Assertions.fail("Expected exception not thrown");
		} catch(Exception ex) {
		} finally {
			quitExtraDrivers(currentHandle);
		}
	}
	
	
	@Test
	public void testWindowSwitchesToCorrectWindow() throws Exception {
		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
		driver.findElement(By.linkText("Popup")).click();
		
		try {
			new DefaultMatcher().matchWindow(driver, 2000);
	        new WebDriverWait(driver, 2).until(ExpectedConditions.urlToBe("https://github.com/danhumphrey/ThirtyFour.UI"));
			
		} finally {
			quitExtraDrivers(currentHandle);
		}
    }
	
	@Test
	public void testWindowSwitchesToCorrectWindowWhenDelayed() throws Exception {
		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
		driver.findElement(By.linkText("Delayed Popup")).click();
		
		try {
			new DefaultMatcher().matchWindow(driver, 5000);
	        new WebDriverWait(driver, 2).until(ExpectedConditions.urlToBe("https://github.com/danhumphrey/ThirtyFour.UI"));
			
		} finally {
			quitExtraDrivers(currentHandle);
		}
    }
	
}
