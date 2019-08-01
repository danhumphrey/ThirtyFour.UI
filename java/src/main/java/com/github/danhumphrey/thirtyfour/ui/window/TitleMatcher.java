package com.github.danhumphrey.thirtyfour.ui.window;

import java.util.Set;
import java.util.concurrent.Callable;

import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.util.Utils;

/**
 * The TitleMatcher matches the first browser window it finds with a matching title
 *
 */
public class TitleMatcher implements Matcher {
	
	private String title;
	
	/**
	 * Constructor
	 * @param title the title of the window you want to match
	 */
	public TitleMatcher(String title) {
		this.title = title;
	}
	
	public class MatcherTask implements Callable<Boolean> {
	    
		private WebDriver driver;
		
		public MatcherTask(WebDriver driver) {
			this.driver = driver;
		}
		
		public Boolean call() throws InterruptedException {
			
			String currentHandle = driver.getWindowHandle();
			
	    	Set<String> handles = driver.getWindowHandles();
	    	for(String handle : handles) {
	    		
	    		driver.switchTo().window(handle);
	    		if(driver.getTitle().equals(title)) {
	    			return true;
	    		}
	    		driver.switchTo().window(currentHandle);
	    	}
	    	return false;
	    }
	}
	
	@Override
	public void matchWindow(WebDriver driver, long timeoutInMilliseconds) throws Exception {
		
		boolean found = Utils.retryUntilTimeout(timeoutInMilliseconds, 100, new MatcherTask(driver));
		
		if (!found) {
            throw new Exception("Unable to find a matching window");
        }
			
	}

}