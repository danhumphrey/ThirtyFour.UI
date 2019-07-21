package com.github.danhumphrey.thirtyfour.ui.window;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;
import com.github.danhumphrey.thirtyfour.ui.test.window.BrowserWindow;

public class BrowserWindowTests extends BaseTestSuite {

	@Test
	public void testDriverEqualsCorrectDriver() {
		
		WebDriver driver = getDriver();
		
		driver.findElement(By.linkText("Popup")).click();
        BrowserWindow window = new BrowserWindow(driver);
        Assertions.assertEquals(driver, window.getDriver());
	}

	@Test
	public void testDefaultHandleEqualsDriverHandleWhenNoPopupExists() {
		
		WebDriver driver = getDriver();
		
		
        BrowserWindow window = new BrowserWindow(driver);
        Assertions.assertEquals(driver.getWindowHandle(), window.getDefaultHandle());
	}
}
