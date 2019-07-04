package com.github.danhumphrey.thirtyfour.ui.test.table;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.core.IsEqual.equalTo;

import java.util.List;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.table.Table;
import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class TableTests extends BaseTestSuite {

	
	@Test
	public void testGetHeaderCells() {
		WebDriver driver = getDriver();
		Table table = new Table(driver.findElement(By.className("cart")));
		List<WebElement> headercells = table.getHeaderCells();
		assertThat(headercells.size(), equalTo(4));
	}
	
	@Test
	public void testGetBodyRows() {
		WebDriver driver = getDriver();
		Table table = new Table(driver.findElement(By.className("cart")));
		List<WebElement> rows = table.getBodyRows();
		assertThat(rows.size(), equalTo(3));
	}
	
	@Test 
	public void testGetCellValue() {
		WebDriver driver = getDriver();
		Table table = new Table(driver.findElement(By.className("cart")));
		String value = table.getCellValue("Product", "First Test Product", "Subtotal");
		assertThat(value, equalTo("$9.99"));
	}
}
