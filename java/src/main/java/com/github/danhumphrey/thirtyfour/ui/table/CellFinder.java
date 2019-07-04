package com.github.danhumphrey.thirtyfour.ui.table;

import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;

/**
 * 
 * Basic strategy for finding cells within a table
 */
public interface CellFinder {
	/**
	 * Finds a specific table cell
	 * @param tableElement the element representing the html table
	 * @return an element representing the cell
	 * @throws NoSuchElementException if the cell cannot be found
	 */
	public WebElement findCell(WebElement tableElement) throws NoSuchElementException;
}