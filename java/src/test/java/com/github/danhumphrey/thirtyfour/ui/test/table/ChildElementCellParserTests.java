package com.github.danhumphrey.thirtyfour.ui.test.table;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.core.IsEqual.equalTo;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.table.ChildElementCellParser;
import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class ChildElementCellParserTests extends BaseTestSuite {
	@Test
	public void testParserReturnsCorrectElement() {
		WebDriver driver = getDriver();
		WebElement cell = driver.findElement(By.id("first-action-cell"));
		ChildElementCellParser parser = new ChildElementCellParser(By.tagName("button"));
		assertThat(parser.getValue(cell).getAttribute("id"), equalTo("first-button") );
	} 
}
