package com.github.danhumphrey.thirtyfour.ui.test;

import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Optional;
import java.util.Set;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.extension.AfterEachCallback;
import org.junit.jupiter.api.extension.ExtendWith;
import org.junit.jupiter.api.extension.ExtensionContext;
import org.junit.jupiter.api.parallel.Execution;
import org.junit.jupiter.api.parallel.ExecutionMode;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebDriverException;

@ExtendWith(BaseTestSuite.class)
@Execution(ExecutionMode.CONCURRENT)
public class BaseTestSuite implements AfterEachCallback {

	protected static ThreadLocal<WebDriver> driverInstance = new ThreadLocal<WebDriver>();

	protected WebDriver getDriver() {
		return driverInstance.get();
	}

	protected void quitExtraDrivers(String currentHandle) {
		WebDriver driver = getDriver();
		Set<String> handles = driver.getWindowHandles();
    	for(String handle : handles) {
    		
    		if(!handle.equals(currentHandle)) {
    			driver.switchTo().window(handle);
    			driver.quit();
    		}
    	}
	}
	
	@BeforeEach
	void setUp() throws Exception {
		URL url = getClass().getClassLoader().getResource("com/github/danhumphrey/thirtyfour/ui/test/index.html");
		WebDriver driver = DriverFactory.buildDriver();
		driver.get(url.toExternalForm());
		driverInstance.set(driver);
	}

	@Override
	public void afterEach(ExtensionContext context) throws Exception {
		
		Optional<Throwable> executionException = context.getExecutionException();
		if(executionException.isPresent()) {
			WebDriver driver = getDriver();
			String timeAndDate = new SimpleDateFormat("yyyy-dd-MM-HH-mm-s").format(new Date());
			if (driver instanceof TakesScreenshot) {
				TakesScreenshot screenshotTakingDriver = (TakesScreenshot) driver;
				File screenshotDirectory = new File(new File("target"), "screenshots");
				if (!screenshotDirectory.exists() || !screenshotDirectory.isDirectory()) {
					screenshotDirectory.mkdirs();
				}
				File screenshotFile = new File(screenshotDirectory, context.getDisplayName().replaceAll("[()]", "") + timeAndDate + ".png");
				try {
					Files.move(screenshotTakingDriver.getScreenshotAs(OutputType.FILE).toPath(), screenshotFile.toPath());
					context.publishReportEntry("Screenshot saved to "  + screenshotFile.toPath());
				} catch (WebDriverException | IOException e) {
					e.printStackTrace();
				}

			}
		}
		getDriver().quit();
	}

}
