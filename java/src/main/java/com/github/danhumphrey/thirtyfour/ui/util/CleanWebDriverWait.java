package com.github.danhumphrey.thirtyfour.ui.util;

import java.util.concurrent.TimeUnit;
import java.util.function.Function;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.WebDriverWait;

/**
 *
 * An extension of WebDriverWait which removes then re-applies the implicit wait on the <code>WebDriver</code> instance
 */
public class CleanWebDriverWait extends WebDriverWait {

	protected long implicitWaitInSeconds;
	protected WebDriver driver;
	
	/**
	 * Constructor
	 * @param driver the <code>WebDriver</code> instance
	 * @param timeOutInSeconds the number of seconds to wait before a timeout occurs
	 * @param implicitWaitInSeconds the implicit wait time in seconds
	 */
	public CleanWebDriverWait(WebDriver driver, long timeOutInSeconds, long implicitWaitInSeconds) {
		super(driver, timeOutInSeconds);
		this.implicitWaitInSeconds = implicitWaitInSeconds;
		this.driver = driver;
	}
	
	@Override
	public <V> V until(Function<? super WebDriver, V> condition) {
		this.driver.manage().timeouts().implicitlyWait(0, TimeUnit.SECONDS);
		try {
			return super.until(condition);
		} catch(Exception e) {
			throw e;
		} finally {
			this.driver.manage().timeouts().implicitlyWait(this.implicitWaitInSeconds, TimeUnit.SECONDS);
		}
	}
	
	

}
