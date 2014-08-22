/*	TestcaseID: TC-006
 * 	Description: Test Yahoo Mail
 * 	Created by: Dung Huynh
 *  Created Date: Aug/22/2011
 * 	Steps:
 * 		1. Login Yahoo
 * 		2. Compose Mail
 * 		3. Logout Yahoo 
 * */

package testcases.yahoo;

// Import library
import org.testng.*;
import org.testng.annotations.*;
import static org.testng.Assert.*;
import functions.*;

public class Ex6_YahooMail extends ServerTestBase {

	// Read data from excel file
	@DataProvider(name = "DP1")
	public Object[][] createData1() throws Exception {
		Object[][] retObjArr = Common.getTableArray("src\\database\\data.xls",
				"datapool1", "testdata");
		return (retObjArr);
	}

	@DataProvider(name = "DP2")
	public Object[][] createData2() throws Exception {
		Object[][] retObjArr = Common.getTableArray("src\\database\\data.xls",
				"datapool1", "testmail");
		return (retObjArr);
	}

	// Login yahoo test case using parameter from data provider
	@Test(dataProvider = "DP1")
	public void LoginYahoo(String username, String password) throws Exception{
		Common.LoginYahoo(username, password);
		assertTrue(selenium.isTextPresent("Inbox*"));
		Reporter.log("Login Succeed");
	}

	// compose email
	@Test(dataProvider = "DP2")
	public void ComposeMail(String subject, String to, String content)
			throws InterruptedException {
		Reporter.log("Compose new message");
		Common.ComposeMessage(subject, to, content);
		
		Reporter.log("Verify the message is sent successfully");
		assertTrue(selenium.isTextPresent("Email Sent"));
		selenium.click("id=inbox-label");
		Thread.sleep(50000);
	}



	// Sign out of Yahoo Mail
	@Test(description = "Sign out Yahoo Mail")
	public void SignOut() {
		selenium.click("id=inbox-label");
		selenium.waitForCondition(
				"selenium.isElementPresent(\"link=Sign Out\")",
				"80000");
		selenium.click("link=Sign Out");
		selenium.waitForPageToLoad("80000");
	}
}
