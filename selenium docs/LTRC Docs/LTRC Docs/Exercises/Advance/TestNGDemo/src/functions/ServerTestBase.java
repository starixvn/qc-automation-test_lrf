package functions;

import org.openqa.selenium.server.SeleniumServer;
import org.testng.ITestContext;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;

import com.thoughtworks.selenium.DefaultSelenium;
import com.thoughtworks.selenium.HttpCommandProcessor;
import com.thoughtworks.selenium.Selenium;


public class ServerTestBase {
	public static Selenium selenium;
	SeleniumServer server;

	//Setup Selenium Server before execute a class
	@BeforeClass(alwaysRun = true)
	public void setupBeforeSuite(ITestContext context) {
		String seleniumHost = context.getCurrentXmlTest().getParameter(
				"selenium.host");
		String seleniumPort = context.getCurrentXmlTest().getParameter(
				"selenium.port");
		String seleniumBrowser = context.getCurrentXmlTest().getParameter(
				"selenium.browser");
		String seleniumUrl = context.getCurrentXmlTest().getParameter(
				"selenium.url");
		try {
			server = new SeleniumServer();
			server.start();
		} catch (Exception e) {
			throw new IllegalStateException("Can't start selenium server", e);
		}

		HttpCommandProcessor proc = new HttpCommandProcessor(seleniumHost,
				Integer.parseInt(seleniumPort), seleniumBrowser, seleniumUrl);
		selenium = new DefaultSelenium(proc);
		selenium.start();
	}
	
	//Stop Selenium Server after finish a class
	@AfterClass(alwaysRun = true)
	public void setupAfterSuite() {
		selenium.stop();
		server.stop();
	}
}
