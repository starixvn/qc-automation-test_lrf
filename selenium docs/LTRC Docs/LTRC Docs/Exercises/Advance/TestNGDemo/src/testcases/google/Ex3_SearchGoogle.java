/* TestcaseID  : TC_003
 *  Description : GoogleSearch: Verify  the user can search on google
 *  Created by  : Dung Huynh
 *  Created Date: Aug-22-2011
 *  Steps:
 *   1. Open http:\\www.Google.com web page
 *   2. Enter search phrase with 'Logigear'
 *   3. Click on Search button
 *  Expected Result:
 *       Verify user can user can search successfully.
 * */

package testcases.google;
import functions.*;

import org.testng.Reporter;
import org.testng.annotations.*;
import static org.testng.Assert.*;

public class Ex3_SearchGoogle extends ServerTestBase{
	@Test
	public void GoogleSearch() 
	{
		String strSearch    = "logigear";
		
        Common.SearchGoogle(strSearch);
		Reporter.log("Verify" + strSearch + "is searched suceesfully");
		assertTrue(selenium.isTextPresent("logigear"));
	}
}
