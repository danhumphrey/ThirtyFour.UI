package com.github.danhumphrey.thirtyfour.ui.test.form;

import java.util.List;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.form.RadioButton;
import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class RadioButtonTests extends BaseTestSuite {

	@Test
	public void testGetLabelWhenWrapped() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		
		Assertions.assertEquals("Orange", rOrange.getLabelText());
	
	}
	
	@Test
	public void testGetLabelWithForAttribute() {
		WebDriver driver = getDriver();
		RadioButton rViolet = new RadioButton(driver.findElement(By.id("rviolet")));
		
		Assertions.assertEquals("Violet", rViolet.getLabelText());
	}
	
	@Test
	public void testGetLabelWithNoAssociatedLabelReturnsEmptyString() {
		WebDriver driver = getDriver();
		RadioButton rMaroon = new RadioButton(driver.findElement(By.id("rmaroon")));
		
		Assertions.assertEquals("", rMaroon.getLabelText());
	}
	
	@Test
	public void testGetValue() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		
		Assertions.assertEquals("orange", rOrange.getValue());
	}
	
	@Test
	public void testGetCheckedFalse() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		
		Assertions.assertFalse(rOrange.getChecked());
	}
	
	@Test
	public void testGetCheckedTrue() {
		WebDriver driver = getDriver();
		RadioButton rViolet = new RadioButton(driver.findElement(By.id("rviolet")));
		Assertions.assertTrue(rViolet.getChecked());
	}
	
	@Test
	public void testSetChecked() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		rOrange.setChecked();
		Assertions.assertTrue(rOrange.getChecked());
	}
	
	@Test
	public void testGetGroupButtons() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		List<RadioButton> groupButtons = rOrange.getGroupButtons();
		
		Assertions.assertEquals(3, groupButtons.size());
	}
	
	@Test
	public void testGetSelectedGroupButton() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		RadioButton selectedButton = rOrange.getSelectedGroupButton();
		
		Assertions.assertEquals("violet", selectedButton.getValue());
	}
	
	@Test
	public void testGetGroupValue() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		RadioButton rViolet = new RadioButton(driver.findElement(By.id("rviolet")));
		
		Assertions.assertEquals("violet", rOrange.getGroupValue());
	
		rOrange.setChecked();
		Assertions.assertEquals("orange", rViolet.getGroupValue());
	}
	
	@Test
	public void testSetCheckedByValueThrowsExceptionForInvalidValue() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		String value = "fhuifdbjdkhhd";
		try {
			rOrange.setCheckedByValue(value);
		}catch(NoSuchElementException ex) {
			String exMessage = "Unable to find radio button with value " + value;
			Assertions.assertTrue(exMessage.startsWith(exMessage));
			return;
		}
		
		Assertions.fail("Expected NoSuchElementException not thrown");
	}
	
	@Test
	public void testSetCheckedByValue() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		RadioButton rViolet = new RadioButton(driver.findElement(By.id("rviolet")));
		
		Assertions.assertFalse(rOrange.getChecked());
		rViolet.setCheckedByValue("orange");
		Assertions.assertTrue(rOrange.getChecked());
	}
	
	@Test
	public void testSetCheckedByLabelThrowsExceptionForInvalidLabel() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		String label = "fhuifdbjdkhhd";
		try {
			rOrange.setCheckedByLabel(label);
		}catch(NoSuchElementException ex) {
			String exMessage = "Unable to find Radio button with label " + label;
			Assertions.assertTrue(exMessage.startsWith(exMessage));
			return;
		}
		
		Assertions.fail("Expected NoSuchElementException not thrown");
	}
	
	@Test
	public void testSetCheckedByLabel() {
		WebDriver driver = getDriver();
		RadioButton rOrange = new RadioButton(driver.findElement(By.id("rorange")));
		RadioButton rViolet = new RadioButton(driver.findElement(By.id("rviolet")));
		
		Assertions.assertFalse(rOrange.getChecked());
		rViolet.setCheckedByLabel("Orange");
		Assertions.assertTrue(rOrange.getChecked());
	}
	
}
