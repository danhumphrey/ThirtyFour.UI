package com.github.danhumphrey.thirtyfour.ui.table;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;

import com.github.danhumphrey.thirtyfour.ui.WrappedElement;

/**
 * The Table class provides helper methods for interacting with a HTML table
 *
 */
public class Table extends WrappedElement {

	/**
	 * Constructor
	 * 
	 * @param element the root element of the table
	 */
	public Table(WebElement element) {
		super(element);
	}
	
	/**
	 * Returns a list of the table header cells
	 * 
	 * @return a list of <code>WebElement</code> instances representing the <code>TH</code> elements
	 */
	public List<WebElement> getHeaderCells() {
		return this.element.findElements(By.tagName("th"));
	}
	
	/**
	 * Returns a list of the body rows 
	 * 
	 * @return a list of <code>WebElement</code> instances representing the <code>TR</code> elements
	 */
	public List<WebElement> getBodyRows() {
		return this.element.findElements(By.cssSelector("tbody tr"));
	}
	
	/**
	 * Returns a cell value as a String by correlating the table headers with a cell value. You can 
	 * also use the {@link Table#getCellValue(CellFinder, CellParser)} method for more control.
	 * 
	 * @param findColumn The column header used to identify the correct table row
	 * @param findValue The cell value used to identify the correct table row
	 * @param returnColumn The column header used to identify the return cell
	 * @return the value of the cell
	 * @throws NoSuchElementException if the column or row can't be found
	 * @see ColumnHeaderCellFinder
	 * 
	 */
	public String getCellValue(String findColumn, String findValue, String returnColumn) throws NoSuchElementException {
		CellFinder finder = new ColumnHeaderCellFinder(findColumn, findValue, returnColumn);
		return this.getCellValue(finder, new StringCellParser()); 
	}
	
	/**
	 * Returns a cell value by the data type specified in the generics cellParser. You can also 
	 * use the default {@link Table#getCellValue(String, String, String)} method to return a cell .
	 * 
	 * value as a String by correlating the table headers with a cell value.
	 * @param <T> the type returned by the cell parser
	 * @param cellFinder the strategy used to find the correct cell
	 * @param cellParser a generics cell parser used to extract the value from the cell
	 * @return the value of the cell
	 * @throws NoSuchElementException if the column or row can't be found
	 */
	public <T> T getCellValue(CellFinder cellFinder, CellParser<T> cellParser) throws NoSuchElementException{
		WebElement cell = cellFinder.findCell(this.element);
		return cellParser.getValue(cell);
	}	
}