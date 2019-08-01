package com.github.danhumphrey.thirtyfour.ui.window;

import java.util.Set;
import java.util.concurrent.Callable;

import org.openqa.selenium.WebDriver;

import com.github.danhumphrey.thirtyfour.ui.util.Utils;

/**
 * The DefaultMatcher matches the first other browser window it finds
 *
 */
public class DefaultMatcher implements Matcher {
	
	public class MatcherTask implements Callable<Boolean> {
	    
		private WebDriver driver;
		
		public MatcherTask(WebDriver driver) {
			this.driver = driver;
		}
		
		public Boolean call() throws InterruptedException {
	    	Set<String> handles = driver.getWindowHandles();
	    	for(String handle : handles) {
	    		
	    		if(!handle.equals(driver.getWindowHandle())) {
	    			driver.switchTo().window(handle);
	    			return true;
	    		}
	    	}
	    	return false;
	    }
	}
	
	@Override
	public void matchWindow(WebDriver driver, long timeoutInMilliseconds) throws Exception {
		
		boolean found = Utils.retryUntilTimeout(timeoutInMilliseconds, 100, new MatcherTask(driver));
		
		if (!found) {
            throw new Exception("Unable to find a new window");
        }
			
	}

}