package com.github.danhumphrey.thirtyfour.ui.table;

import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

/**
 * Parsers a child element from a table cell
 *
 */
public class ChildElementCellParser implements CellParser<WebElement> {

	protected By childLocator;
	
	/**
	 * Constructor
	 * @param childLocator the locator used to find the child element
	 */
	public ChildElementCellParser(By childLocator) {
		this.childLocator = childLocator;
	}
		
	/**
	 * returns a child element from the cell
	 * @param cell the cell to parse
	 * @return WebElement the child element
	 */
	@Override
	public WebElement getValue(WebElement cell) {
		return cell.findElement(childLocator);
	}

}
