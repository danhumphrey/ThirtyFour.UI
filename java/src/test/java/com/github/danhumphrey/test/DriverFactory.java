package com.github.danhumphrey.test;

import java.net.MalformedURLException;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

public class DriverFactory
{
	
    public static WebDriver buildDriver() throws MalformedURLException
    {
        WebDriver driver = null;

        switch (TestProperties.BROWSER)
        {
        	case "${browser}": // resource filtering not applied
            case "chrome":
                driver = new ChromeDriver();
                break;
            case "firefox":
                driver = new FirefoxDriver();
                break;
            default:
                throw new IllegalArgumentException(String.format("Invalid browser - '%s'", TestProperties.BROWSER));
        }
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(2, TimeUnit.SECONDS);
        return driver;
    }
    
  
 
}