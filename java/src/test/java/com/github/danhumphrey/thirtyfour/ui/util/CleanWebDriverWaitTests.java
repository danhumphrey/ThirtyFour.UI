package com.github.danhumphrey.thirtyfour.ui.util;

import java.util.Date;
import java.util.concurrent.TimeUnit;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.TimeoutException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class CleanWebDriverWaitTests extends BaseTestSuite {

	@Test
    public void testCleanWebDriverWaitResolvesBeforeImplicitWaitTime() {
		WebDriver driver = getDriver();

        long iwDelay = 30;

        driver.manage().timeouts().implicitlyWait(iwDelay, TimeUnit.SECONDS);

        long start = new Date().getTime(); 

        driver.findElement(By.linkText("3 Second Delay")).click();
        new CleanWebDriverWait(driver, 4, iwDelay).until(ExpectedConditions.presenceOfElementLocated(By.className("three-second-delay")));

        long end = new Date().getTime();
        long diff = end - start;

        Assertions.assertTrue(diff < (iwDelay * 1000));

    }

    @Test
    public void testCleanWebDriverWaitThrowsExceptionAfterTimeout() {
    	WebDriver driver = getDriver();
    	
        long iwDelay = 10;
        driver.manage().timeouts().implicitlyWait(iwDelay, TimeUnit.SECONDS);

        try
        {
            new CleanWebDriverWait(driver, 2, iwDelay).until(ExpectedConditions.presenceOfElementLocated(By.className("A-Non-existent_Element_which-willNEVER-Exist2")));
        }
        catch (TimeoutException ex)
        {
            return;
        }

        Assertions.fail("Expected TimeoutException not thrown");
    }

}
