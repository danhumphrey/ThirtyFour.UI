package com.github.danhumphrey.thirtyfour.ui.window;

import java.util.Set;
import java.util.concurrent.Callable;

import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.util.Utils;

/**
 * The UrlMatcher matches the first browser window it finds with a matching title
 *
 */
public class UrlMatcher implements Matcher {
	
	private String url;
	
	/**
	 * Constructor
	 * @param title the title of the window you want to match
	 */
	public UrlMatcher(String url) {
		this.url = url;
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
	    		if(driver.getCurrentUrl().equals(url)) {
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