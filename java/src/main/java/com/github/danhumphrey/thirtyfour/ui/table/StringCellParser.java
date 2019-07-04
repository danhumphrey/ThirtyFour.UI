package com.github.danhumphrey.thirtyfour.ui.table;

import org.openqa.selenium.WebElement;

/**
 * Parses a string value from a table cell
 *
 */
public class StringCellParser implements CellParser<String> {

	/**
	 * Gets a string value from a cell
	 * @param WebElement cell the cell to extract the value from
	 * @return String the cell text
	 */
	@Override
	public String getValue(WebElement cell) {
		return cell.getText();
	}
}