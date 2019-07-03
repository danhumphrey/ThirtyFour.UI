package com.github.danhumphrey.thirtyfour.ui.test;

import static org.hamcrest.CoreMatchers.sameInstance;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.core.IsEqual.equalTo;

import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.WrappedElement;

public class WrappedElementTests extends BaseTestSuite {

	@Test
	public void testGetElementReturnsSameInstance() {
		WebDriver driver = getDriver();
		WebElement el = driver.findElement(By.id("cbred"));
		WrappedElement wEl = new WrappedElement(el);
		assertThat(wEl.getElement(), sameInstance(el));
	}
	
	@Test
	public void testGetDriverReturnsSameInstance() {
		WebDriver driver = getDriver();
		WebElement el = driver.findElement(By.id("cbred"));
		WrappedElement wEl = new WrappedElement(el);
		assertThat(wEl.getDriver(), sameInstance(driver));
	}
	
	@Test
	public void testGetParentElementReturnsCorrectElement() {
		WebDriver driver = getDriver();
		WebElement el = driver.findElement(By.id("cbred"));
		WrappedElement wEl = new WrappedElement(el);
		assertThat(wEl.getParentElement().getAttribute("id"), equalTo("cbredlabel"));
	}
	
	@Test
	public void testGetAncestorElementReturnsCorrectElementWhenFilteredByParentTagName() {
		WebDriver driver = getDriver();
		WebElement el = driver.findElement(By.id("cbred"));
		WrappedElement wEl = new WrappedElement(el);
		assertThat(wEl.getAncestorElement("label").getAttribute("id"), equalTo("cbredlabel"));
	}
	
	@Test
	public void testGetAncestorElementReturnsCorrectElementWhenFilteredByAncestorTagName() {
		WebDriver driver = getDriver();
		WebElement el = driver.findElement(By.id("cbred"));
		WrappedElement wEl = new WrappedElement(el);
		assertThat(wEl.getAncestorElement("body"), equalTo(driver.findElement(By.tagName("body"))));
	}
	
	@Test
	public void testGetAncestorElementReturnsNullWhenFilteredByInvalidTagName() {
		WebDriver driver = getDriver();
		WebElement el = driver.findElement(By.id("cbred"));
		WrappedElement wEl = new WrappedElement(el);
		assertThat(wEl.getAncestorElement("head"), equalTo(null));
	}
	

}
