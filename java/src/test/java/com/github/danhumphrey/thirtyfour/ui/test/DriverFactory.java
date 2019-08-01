package com.github.danhumphrey.thirtyfour.ui.test;

import java.net.MalformedURLException;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxOptions;

public class DriverFactory
{
	
    public static WebDriver buildDriver() throws MalformedURLException
    {
        WebDriver driver = null;

        switch (TestProperties.BROWSER)
        {
        	case "${browser}": // resource filtering not applied
        		driver = new ChromeDriver();
                break;
            case "chrome":
            	ChromeOptions chromeOptions = new ChromeOptions();
            	if(TestProperties.HEADLESS) {
            		chromeOptions.addArguments("headless");
            	}
                driver = new ChromeDriver(chromeOptions);
                break;
            case "firefox":
            	FirefoxOptions firefoxOptions = new FirefoxOptions();
            	if(TestProperties.HEADLESS) {
            		firefoxOptions.addArguments("--headless");
            	}
                driver = new FirefoxDriver(firefoxOptions);
                break;
            default:
                throw new IllegalArgumentException(String.format("Invalid browser - '%s'", TestProperties.BROWSER));
        }
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(2, TimeUnit.SECONDS);
        return driver;
    }
    
  
 
}