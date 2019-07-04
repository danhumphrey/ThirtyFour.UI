package com.github.danhumphrey.thirtyfour.ui.test.table;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.core.IsEqual.equalTo;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.table.StringCellParser;
import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class StringCellParserTests extends BaseTestSuite {

	@Test
	public void testStringCellParserReturnsCellValue() {
		WebDriver driver = getDriver();
		WebElement cell = driver.findElement(By.className("first-product"));
		StringCellParser parser = new StringCellParser();
		assertThat(parser.getValue(cell), equalTo("First Test Product"));
	}
	
}
