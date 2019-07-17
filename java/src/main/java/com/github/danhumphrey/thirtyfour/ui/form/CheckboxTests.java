package com.github.danhumphrey.thirtyfour.ui.form;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class CheckboxTests extends BaseTestSuite {

	@Test
	public void testGetCheckboxLabelWhenWrapped() {
		WebDriver driver = getDriver();
		Checkbox cbRed = new Checkbox(driver.findElement(By.id("cbred")));
		Assertions.assertEquals("Red", cbRed.getLabelText());
	}
	
	@Test
	public void testGetCheckboxLabelWithForAttribute() {
		WebDriver driver = getDriver();
		Checkbox cbGreen = new Checkbox(driver.findElement(By.id("cbgreen")));
		Assertions.assertEquals("Green", cbGreen.getLabelText());
	}
	
	@Test
	public void testGetCheckboxLabelWithNoAssociatedLabelReturnsEmptyString() {
		WebDriver driver = getDriver();
		Checkbox cbMaroon = new Checkbox(driver.findElement(By.id("cbmaroon")));
		Assertions.assertEquals("", cbMaroon.getLabelText());
	}
	
	@Test
	public void testGetValue() {
		WebDriver driver = getDriver();
		Checkbox cbRed = new Checkbox(driver.findElement(By.id("cbred")));
		Assertions.assertEquals("red", cbRed.getValue());
	}

	public void testGetCheckedFalse() {
		WebDriver driver = getDriver();
		Checkbox cbRed = new Checkbox(driver.findElement(By.id("cbred")));
		Assertions.assertFalse(cbRed.getChecked());
	}
	
	@Test
	public void testGetCheckedTrue() {
		WebDriver driver = getDriver();
		Checkbox cbGreen = new Checkbox(driver.findElement(By.id("cbgreen")));
		Assertions.assertTrue(cbGreen.getChecked());
	}
	
	@Test
	public void testSetCheckedTrue() {
		WebDriver driver = getDriver();
		Checkbox cbRed = new Checkbox(driver.findElement(By.id("cbred")));
		Assertions.assertFalse(cbRed.getChecked());
		cbRed.setChecked(true);
		Assertions.assertTrue(cbRed.getChecked());
	}

	
	@Test
	public void testSetCheckedFalse() {
		WebDriver driver = getDriver();
		Checkbox cbGreen = new Checkbox(driver.findElement(By.id("cbgreen")));
		Assertions.assertTrue(cbGreen.getChecked());
		cbGreen.setChecked(false);
		Assertions.assertFalse(cbGreen.getChecked());
	}
}
