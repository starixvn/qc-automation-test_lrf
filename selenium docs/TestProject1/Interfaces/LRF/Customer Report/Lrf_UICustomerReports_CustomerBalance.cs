using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UICustomerReports_CustomerBalance
{
    public string lblTitle = "//*[@id='header-title']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//*[@id='CustomerTurnOverControl_lblType']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='ddlCurrency']";
	public string chkExcludeTestData = "//*[@id='rdoExcludeTesting']";
	public string ddlSelectTopCustomer = "//*[@id='ddlSelectTopCustomer']";
	public string ddlSortBy  = "//*[@id='ddlSortTurnOver']";
	
	public string ddlSelectMonth = "//*[@id='dllMonth']";
	public string ddlFromDate = "//*[@id='ddlFromDay']";
	public string ddlToDate = "//*[@id='ddlToDay']";
	
    public string icoExporttoExcel = "exporttoexcel";
    public string btnSubmit = "//*[@id='btnSubmit']";
    
	public string frmMain = "//*[@id='criteria-container']";
	public string tblReportContent = "//*[@id='table_content']";
	
    public string colNumberOrder = "//tr[@class='RptHeader']/td[text()='#']";
    public string colExternalID = "//tr[@class='RptHeader']/td[@columnname='nickname']";
    public string txtExternalID = "External ID";
    public string colSystemID = "//tr[@class='RptHeader']/td[@columnname='UserName']";
    public string txtSystemID = "System ID";
    public string colBetCounts = "//tr[@class='RptHeader']/td[@columnname='betcounts']";
    public string txtBetCounts = "Bet Counts";
    public string colOutstanding = "//tr[@class='RptHeader']/td[@columnname='outstanding' and text()='Pending Funds']";
}

