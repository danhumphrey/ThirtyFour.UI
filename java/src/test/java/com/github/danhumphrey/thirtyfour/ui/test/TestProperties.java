package com.github.danhumphrey.thirtyfour.ui.test;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class TestProperties {

	public static final String BROWSER;
	public static final boolean HEADLESS;

	static {

		ClassLoader loader = Thread.currentThread().getContextClassLoader();
		Properties props = new Properties();
		try (InputStream resourceStream = loader.getResourceAsStream("test.properties")) {
			props.load(resourceStream);
		} catch (IOException e) {
			System.err.println("Unable to load test.properties");
			e.printStackTrace();
		}

		HEADLESS = Boolean.parseBoolean(props.getProperty("headless"));
		BROWSER = props.getProperty("browser");
	}

}