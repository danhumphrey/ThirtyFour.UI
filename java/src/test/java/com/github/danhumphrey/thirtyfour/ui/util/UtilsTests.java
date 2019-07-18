package com.github.danhumphrey.thirtyfour.ui.util;

import java.util.Date;
import java.util.concurrent.Callable;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import com.github.danhumphrey.thirtyfour.ui.test.BaseTestSuite;

public class UtilsTests extends BaseTestSuite {

	public class TimeoutTask implements Callable<Boolean> {
	    int number;
	 
	    public Boolean call() {
	    	try {
				Thread.sleep(50);
			} catch (InterruptedException e) {
				
			}
            return false;
	    }
	}
	
	public class SuccessTask implements Callable<Boolean> {
	    int number;
	 
	    public Boolean call() {
	    	return true;
	    }
	}
	
	@Test
    public void testTimeoutReturnsFalse() throws Exception {
		boolean result = Utils.retryUntilTimeout(500, 100, new TimeoutTask());
        Assertions.assertFalse(result);
    }

    @Test
    public void testSuccessReturnsTrue() throws Exception {
    	boolean result = Utils.retryUntilTimeout(500, 100, new SuccessTask());
        Assertions.assertTrue(result);
    }
    
    @Test
    public void testFalseResultNotReturnedBeforeTimeout() throws Exception {
    	long start = new Date().getTime(); 
    	boolean result = Utils.retryUntilTimeout(500, 100, new TimeoutTask());
        long stop = new Date().getTime();
        long diff = stop - start;
        Assertions.assertTrue(diff > 500);
        Assertions.assertFalse(result);
    }
    
    @Test()
    public void testTrueResultReturnedBeforeTimeout() throws Exception {
    	long start = new Date().getTime(); 
    	boolean result = Utils.retryUntilTimeout(1000, 100, new SuccessTask());
        long stop = new Date().getTime();
        long diff = stop - start;
        
        System.out.println(diff);
        Assertions.assertTrue(diff < 200);
        Assertions.assertTrue(result);
    }
}
