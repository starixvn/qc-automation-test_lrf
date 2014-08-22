/* TestcaseID  : TC_004
 *  Description : GoogleSearch: Verify the user can login Gmail successfully.
 *  Created by  : Dung Huynh
 *  Created Date: Aug-22-2011
 *  Steps:
 *   1. Open http:\\www.gmail.com web page
 *   2. Login with account 'logigearmail@gmail.com'/'logigear1'
 *   3. Click on SignIn button
 *  Expected Result:
 *       Verify user can user can user can login Gmail successfully.
 * */

package testcases.google;
import functions.*;

import org.testng.annotations.*;
import static org.testng.Assert.*;

public class Ex4_LoginGoogle extends ServerTestBase{

	// Login Google
	@Test
	public void LoginGoogle() 
	{
		Common.LoginGoogle(Common.strGmailUser, Common.strGMailPw);		
		assertTrue(selenium.isElementPresent(":r5"));
		selenium.click("link=Sign out");
		selenium.waitForPageToLoad("30000");
	}
}
