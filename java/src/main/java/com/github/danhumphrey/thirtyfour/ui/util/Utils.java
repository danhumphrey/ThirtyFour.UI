package com.github.danhumphrey.thirtyfour.ui.util;

import java.util.concurrent.Callable;

/**
 * Utils class
 */
public final class Utils {
	
	private Utils() {}
	
    /**
     * Retries a task every 'interval' milliseconds until 'timeout' or success
     * @param timeout the timeout in milliseconds
     * @param interval the interval in milliseconds
     * @param task the task to attempt
     * @return true if the task completed successfully or false otherwise
     * @throws Exception
     */ 
    public static boolean retryUntilTimeout(long timeout, long interval, Callable<Boolean> task) throws Exception
    {
        boolean success = false;
        long elapsed = 0;
        while ((!success) && (elapsed < timeout)) {
            Thread.sleep(interval);
            elapsed += interval;
            success = task.call();
        }
        return success;
    }

}