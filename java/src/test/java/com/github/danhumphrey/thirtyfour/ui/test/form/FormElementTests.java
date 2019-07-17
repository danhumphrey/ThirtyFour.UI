package com.github.danhumphrey.thirtyfour.ui.test.form;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.form.FormElement;
import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class FormElementTests extends BaseTestSuite {

	 public class FormElementImpl extends FormElement {
         public FormElementImpl(WebElement element) {
        	 super(element);
         }
     }
	 

	@Test
    public void testGetValueReturnsCorrectValue() {
        WebDriver driver = getDriver();
        
		WebElement el = driver.findElement(By.id("rorange"));
        FormElement radio = new FormElementImpl(el);
        Assertions.assertEquals("orange", radio.getValue());

        WebElement inputTextEl = driver.findElement(By.name("input-text"));
        FormElement inputText = new FormElementImpl(inputTextEl);
        Assertions.assertEquals("initial input-text value", inputText.getValue());
        inputTextEl.clear();
        inputTextEl.sendKeys("new input-text value");
        Assertions.assertEquals("new input-text value", inputText.getValue());

        WebElement inputHiddenEl = driver.findElement(By.name("input-hidden"));
        FormElement inputHidden = new FormElementImpl(inputHiddenEl);
        Assertions.assertEquals("initial input-hidden value", inputHidden.getValue());

    }
	
	@Test
    public void testGetLabelTextWhenWrapped() {
		WebDriver driver = getDriver();
        WebElement el = driver.findElement(By.id("rorange"));
        FormElement radio = new FormElementImpl(el);
        Assertions.assertEquals("Orange", radio.getLabelText());
    }

	
    @Test
    public void testGetLabelTextWithForAttribute()
    {
    	WebDriver driver = getDriver();
        WebElement el = driver.findElement(By.id("rviolet"));
        FormElement radio = new FormElementImpl(el);
        Assertions.assertEquals("Violet", radio.getLabelText());
    }
	
}
