package functions;

import java.io.File;

import org.testng.Reporter;

import jxl.*;

public class Common extends ServerTestBase{
	
	//URLs
	static String strURLGoogle 		 = "http://www.google.com";
	static String strURLGMail  		 = "http://mail.google.com";
	public static String strURLYahoo = "http://mail.yahoo.com";
	
	// Account information
	public static String strGmailUser = "logigearmail@gmail.com";
	public static String strGMailPw   = "logigear1";
	
	// Database
	public static String strExFileSite = "src\\database\\data2.xls";
	public static String strSheetName  = "datapool1";
	public static String strTableName  = "testdata";

/*'*********************************************************************
Procedure:  getTableArray
Created By:		Dung.Huynh
Created Date:		Aug/22/2011
Last Modified By:	
Last Modified Date:	
@Description * Get table array from excel file
Parameter:
	xFilePath: The file path name
	sheetName: name of sheet
	tableName: name of table
Output: 
	Array value
	
*********************************************************************/
	public static String[][] getTableArray(String xlFilePath, String sheetName, String tableName) throws Exception{
        String[][] tabArray=null;
            int startRow, startCol, endRow, endCol, ci, cj;
            Workbook workbook = Workbook.getWorkbook(new File(xlFilePath));
            Sheet sheet       = workbook.getSheet(sheetName); 
            Cell tableStart   = sheet.findCell(tableName);
            startRow          = tableStart.getRow();
            startCol          = tableStart.getColumn();
            Cell tableEnd     = sheet.findCell(tableName, startCol+1,startRow+1, 100, 64000,  false);                

            endRow = tableEnd.getRow();
            endCol = tableEnd.getColumn();
            System.out.println("startRow=" + startRow +", endRow=" + endRow +", " +
                    "startCol=" + startCol +", endCol=" + endCol);
            tabArray = new String[endRow - startRow - 1][endCol - startCol - 1];
            ci = 0;

            for (int i = startRow + 1; i <endRow; i++, ci++){
                cj =0 ;
                for (int j = startCol + 1; j < endCol; j++, cj++){
                    tabArray[ci][cj] = sheet.getCell(j,i).getContents();
                }
            }

        return(tabArray);
    }
	/*'*********************************************************************
	Procedure:  SearchGoogle
	Created By:		Dung.Huynh
	Created Date:		Aug/22/2011
	Last Modified By:	
	Last Modified Date:	
	@Description * Search on Google
	Parameter:
		strSearch: The string is used to search on Google
		
	Output: void	
	*********************************************************************/
	public static void SearchGoogle(String strSearch)
	{	
		selenium.open(strURLGoogle);
		selenium.type("q", strSearch);
		selenium.click("btnG");
		
		selenium.windowMaximize();
		selenium.windowFocus();
	}
	
	/*'*********************************************************************
	Procedure:  LoginGoogle
	Created By:		Dung.Huynh
	Created Date:		Aug/22/2011
	Last Modified By:	
	Last Modified Date:	
	@Description * Login to Gmail
	Parameter:
		strUsername: Username
		strPassword: Password 
		
	Output: void	
	*********************************************************************/
	public static void LoginGoogle(String strUsername, String strPassword)
	{
		selenium.open(strURLGMail);
		selenium.windowMaximize();
		selenium.type("Email", strUsername);
		selenium.type("Passwd", strPassword);
		selenium.uncheck("PersistentCookie");
		selenium.click("signIn");
		selenium.waitForPageToLoad("40000");	
		selenium.clickAt("//div[@id=':ok']/div[1]/div", "");
	}
	

	/*'*********************************************************************
	Procedure:  OpenSite
	Created By:		Dung.Huynh
	Created Date:		Aug/22/2011
	Last Modified By:	
	Last Modified Date:	
	@Description * Open site
	Parameter:
		strSite: The url is used to open
				
	Output: void	
	*********************************************************************/
	public static void OpenSite(String strSite)
	{
		try
		{
			selenium.open(strSite);
			selenium.waitForPageToLoad("120000");
			selenium.windowMaximize();
			selenium.windowFocus();
		}
		catch (Exception e)
		{
			throw new IllegalStateException("Can't open site" + strSite, e);
		}
	}
	
	/*'*********************************************************************
	Procedure:  LoginYahoo
	Created By:		Dung.Huynh
	Created Date:		Aug/22/2011
	Last Modified By:	
	Last Modified Date:	
	@Description * Login to Yahoo Mail
	Parameter:
			strUser: Username
		    strPassword: Password 
	Output: void	
	*********************************************************************/
	public static void LoginYahoo(String strUser, String strPassword) throws Exception
	{
		try{
			Reporter.log("Step 1: Open Yahoo Mail");
			Common.OpenSite(Common.strURLYahoo);
			Reporter.log("Step 2: Enter Username and Password");
			selenium.type("username", strUser);
			selenium.type("passwd", strPassword);
			selenium.click(".save");
			selenium.waitForPageToLoad("85000");
		}catch (Exception e)
		{
			throw new IllegalStateException("Can't login yahoo mail", e);
		}
	}
	/*
	
	@DataProvider(name = "DP1")
	public static Object[][] createData1() throws Exception 
	{
		Object[][] retObjArr = getTableArray(strExFileSite, strSheetName, strTableName);
		return (retObjArr);
	}*/
	
	/*'*********************************************************************
	Procedure:  ComposeMessage
	Created By:		Dung.Huynh
	Created Date:		Aug/22/2011
	Last Modified By:	
	Last Modified Date:	
	@Description * Compose new message
	Parameter:
			strUser: Username
		    strPassword: Password 
	Output: void	
	*********************************************************************/
	public static void ComposeMessage (String subject, String to, String content)throws InterruptedException 
	{
		selenium.click("link=Compose Message");
		selenium.waitForCondition("selenium.isElementPresent(\"to\")", "100000");
		selenium.type("id=to-field", to);
		selenium.type("id=subject-field", subject);
		Thread.sleep(10000);
		
		Reporter.log("Click send button");
		selenium.click("link=Send");
		Thread.sleep(30000);
	}
}

