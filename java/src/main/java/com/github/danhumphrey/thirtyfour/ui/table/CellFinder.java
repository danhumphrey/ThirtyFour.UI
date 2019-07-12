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
	 * @param tableElement the <code>WebElement</code> representing the HTML table
	 * @return a <code>WebElement</code> representing the <code>TD</code> table cell
	 * @throws NoSuchElementException if the cell cannot be found
	 */
	public WebElement findCell(WebElement tableElement) throws NoSuchElementException;
}