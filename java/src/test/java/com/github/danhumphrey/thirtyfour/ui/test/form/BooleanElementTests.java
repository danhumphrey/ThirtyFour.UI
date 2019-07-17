package com.github.danhumphrey.thirtyfour.ui.test.form;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.form.BooleanElement;
import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class BooleanElementTests extends BaseTestSuite {

	public class BooleanElementImpl extends BooleanElement {
        public BooleanElementImpl(WebElement element) {
       	 super(element);
        }
    }
	
    @Test
    public void testGetCheckedWhenNotChecked() {
    	WebDriver driver = getDriver();
        WebElement el = driver.findElement(By.id("rorange"));
        BooleanElement radio = new BooleanElementImpl(el);
        Assertions.assertFalse(radio.getChecked());
    }

    @Test
    public void testGetCheckedWhenChecked() {
    	WebDriver driver = getDriver();
        WebElement el = driver.findElement(By.id("rviolet"));
        BooleanElement radio = new BooleanElementImpl(el);
        Assertions.assertTrue(radio.getChecked());
    }
       
}
