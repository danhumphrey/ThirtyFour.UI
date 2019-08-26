package com.github.danhumphrey.thirtyfour.ui.test.window;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;
import com.github.danhumphrey.thirtyfour.ui.window.BrowserWindow;

public class BrowserWindowTests extends BaseTestSuite {
	
	@Test
	public void testExceptionThrownWhenNoPopupExists() throws Exception {
		
		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
		try {
			new BrowserWindow(driver);
			Assertions.fail("Expected exception not thrown");
		} catch(Exception ex) {
		} finally {
			quitExtraDrivers(currentHandle);
		}
	}
	
	@Test
	public void testDriverEqualsCorrectDriver() throws Exception {
		
		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
		driver.findElement(By.linkText("Popup")).click();
		try {
			BrowserWindow window = new BrowserWindow(driver);
	        Assertions.assertEquals(driver, window.getDriver());
		} finally {
			quitExtraDrivers(currentHandle);
		}
	}
	
	@Test
    public void testDefaultHandleNotEqualsDriverHandleWhenPopupExists() throws Exception {
		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
        driver.findElement(By.linkText("Popup")).click();
        
        try {
        	BrowserWindow window = new BrowserWindow(driver);
            Assertions.assertNotEquals(driver.getWindowHandle(), window.getDefaultHandle());
            
        } finally {
        	quitExtraDrivers(currentHandle);
        }
        
    }
	
	@Test
	public void testWindowSwitchesToCorrectWindowWhenNoMatcherIsProvided() throws Exception {
		WebDriver driver = getDriver();
		String currentHandle = driver.getWindowHandle();
		
		driver.findElement(By.linkText("Popup")).click();
		
		try {
			new BrowserWindow(driver);
	        new WebDriverWait(driver, 2).until(ExpectedConditions.urlToBe("https://github.com/danhumphrey/ThirtyFour.UI"));
			
		} finally {
			quitExtraDrivers(currentHandle);
		}
    }
}
