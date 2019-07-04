package com.github.danhumphrey.thirtyfour.ui.table;

import org.openqa.selenium.WebElement;

/**
 * A generic strategy for parsing the value from a table cell
 *
 * @param <T> the type of the return value
 */
public interface CellParser<T> {
	/**
	 * 
	 * @param cell the cell to retrieve the value from
	 * @return T the generic typed value from the cell
	 */
	public T getValue(WebElement cell);
}
