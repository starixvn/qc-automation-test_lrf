
/* TestcaseID  : TC_005
 *  Description : Verify  the site using data provider
 *  Created by  : Dung Huynh
 *  Created Date: Aug-18-2011
 *  Steps:
 *   1. Open web page from excel file
 *   
 *  Expected Result:
 *       Verify user can user can open site successfully.
 *       
 * */
package testcases.google;

import java.util.regex.Pattern;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;
import functions.*;

public class Ex5_DataDriven extends ServerTestBase{
	
	// Read data from excel file
	@DataProvider(name = "DP1")
	public static Object[][] createData1() throws Exception {
		Object[][] retObjArr = Common.getTableArray(Common.strExFileSite,
				Common.strSheetName, Common.strTableName);
		return (retObjArr);
	}

	// Test site using data provider
	@Test(dataProvider = "DP1")
	public void testsite(String site, String title) throws InterruptedException {
		Common.OpenSite(site);
		
		// Verify web site title is opened
		Assert.assertTrue(Pattern.compile(title).matcher(selenium.getTitle()).find()); 
	}
}
