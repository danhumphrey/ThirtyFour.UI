package com.github.danhumphrey.thirtyfour.ui.table;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;

/**
 * 
 * Finds a row and cell by correlating the table headers and a cell value 
 */
public class ColumnHeaderCellFinder implements CellFinder {

	protected String findColumnHeader;
	protected String findColumnValue;
	protected String returnColumnHeader;
	
	protected WebElement tableElement;
	
	/**
	 * The default constructor
	 * 
	 * @param findColumnHeader The header of the column in which to look for the findColumnValue
	 * @param findColumnValue The value to be located within the find column - this identifies the correct row
	 * @param returnColumnHeader The header of the column to return
	 */
	public ColumnHeaderCellFinder(String findColumnHeader, String findColumnValue, String returnColumnHeader) {
		this.findColumnHeader = findColumnHeader;
		this.findColumnValue = findColumnValue;
		this.returnColumnHeader = returnColumnHeader;
	}
	
	/**
	 * Returns the zero based index/position of a column
	 * 
	 * @param columnHeader the header of the column to locate
	 * @return the position of the column if found
	 * @throws NoSuchElementException if the column can't be found
	 */
	protected int getColumnIndex(String columnHeader) throws NoSuchElementException {
		List<WebElement> headerCells = this.tableElement.findElements(By.tagName("th"));
		for(int i = 0; i < headerCells.size(); i++) {
			if(headerCells.get(i).getText().equals(columnHeader)) {
				return i;
			}
		}
		throw new NoSuchElementException(String.format("Unable to find column with header text %s", columnHeader));

	}
	
	@Override
	public WebElement findCell(WebElement tableElement) throws NoSuchElementException {
		
		this.tableElement = tableElement;
		int findColumnIndex = this.getColumnIndex(this.findColumnHeader);
		int returnColumnIndex = this.getColumnIndex(this.returnColumnHeader);
		
		List<WebElement> rows = tableElement.findElements(By.cssSelector("tbody tr"));
		for(WebElement row : rows) {
			List<WebElement> cells = row.findElements(By.tagName("td"));
			if(cells.get(findColumnIndex).getText().equals(this.findColumnValue)) {
				return cells.get(returnColumnIndex);
			}
		}
		
		throw new NoSuchElementException(String.format("Unable to find cell with text %s", findColumnValue));
	}

}
