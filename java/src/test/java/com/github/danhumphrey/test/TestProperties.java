package com.github.danhumphrey.test;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class TestProperties {

	public static final String BROWSER;

	static {

		ClassLoader loader = Thread.currentThread().getContextClassLoader();
		Properties props = new Properties();
		try (InputStream resourceStream = loader.getResourceAsStream("test.properties")) {
			props.load(resourceStream);
		} catch (IOException e) {
			System.err.println("Unable to load test.properties");
			e.printStackTrace();
		}

		BROWSER = props.getProperty("browser");

	}

}