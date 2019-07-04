package com.github.danhumphrey.thirtyfour.ui.test.table;

import static org.junit.jupiter.api.Assertions.fail;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.table.ColumnHeaderCellFinder;
import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

import static org.hamcrest.core.StringStartsWith.startsWith;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.core.IsEqual.equalTo;

public class ColumnHeaderCellFinderTests extends BaseTestSuite {
	
	@Test
	public void testInvalidFindColumnHeaderThrowsNoSuchElementException() {
		WebDriver driver = getDriver();
		String invalidColumn = "dudhuidhiudh";
		ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder(invalidColumn, "First Test Product", "Subtotal");
		try {
			WebElement tableElement = driver.findElement(By.className("cart"));
			finder.findCell(tableElement);
		}catch(NoSuchElementException ex) {
			String exMessage ="Unable to find column with header text " + invalidColumn;
			assertThat(ex.getMessage(),  startsWith(exMessage));
			return;
		}
		fail("Expected NoSuchElementException to be thrown when we provide an invalid find column header");
		
	}
	
	@Test
	public void testInvalidReturnColumnHeaderThrowsNoSuchElementException() {
		WebDriver driver = getDriver();
		String invalidColumn = "dudhuidhiudh";
		
		ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder("Product", "First Test Product", invalidColumn);
		try {
			WebElement tableElement = driver.findElement(By.className("cart"));
			finder.findCell(tableElement);
		}catch(NoSuchElementException ex) {
			String exMessage = "Unable to find column with header text " + invalidColumn;
			assertThat(ex.getMessage(), startsWith(exMessage));
			return;
		}
		fail("Expected NoSuchElementException to be thrown when we provide an invalid return column header");
		
	}
	
	@Test
	public void testInvalidFindValueThrowsNoSuchElementException() {
		WebDriver driver = getDriver();
		String invalidValue = "dudhuidhiudh";
		
		ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder("Product", invalidValue, "Subtotal");
		try {
			WebElement tableElement = driver.findElement(By.className("cart"));
			finder.findCell(tableElement);
		}catch(NoSuchElementException ex) {
			String exMessage = "Unable to find cell with text " + invalidValue;
			assertThat(ex.getMessage(), startsWith(exMessage));
			return;
		}
		fail("Expected NoSuchElementException to be thrown when we provide an invalid find value");
	}
	
	@Test
	public void testFindCellReturnsCorrectWebElement() {
		WebDriver driver = getDriver();
		
		ColumnHeaderCellFinder finder = new ColumnHeaderCellFinder("Product", "First Test Product", "Subtotal");
		WebElement tableElement = driver.findElement(By.className("cart"));
		WebElement cell = finder.findCell(tableElement);
	
		assertThat(cell.getText(), equalTo("$9.99"));
	}
}
