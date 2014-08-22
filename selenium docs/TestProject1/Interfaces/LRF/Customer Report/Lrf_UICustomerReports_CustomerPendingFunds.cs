using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UICustomerReports_CustomerPendingFunds
{
    public string lblTitle = "//div[text() = 'Customer Pending Funds']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyType";
    public string chkConvertTo = "IsConvert";
    public string icoExporttoExcel = "exporttoexcel";
    public string btnSubmit = "//*[@id='submit-button']";
	public string chkAllProduct = "//*[@id='showall']";
	public string chkSBProduct = "//*[@id='showsb']";
	public string chkRacingProduct = "//*[@id='showrb']";
	public string chkNumberGameProduct = "//*[@id='showng']";
	public string chkBAProduct = "//*[@id='showba']";
	public string frmMain = "//*[@id='criteria-container']";
	public string tblReportContent = "//*[@id='tbl-container']";
	public string lnkOpenBetList = "//*[@id='tbl-rpt2']/tbody/tr[1]/td[2]/span";
	
    public string colNumberOrder = "//tr[@class='RptHeader']/td[text()='#']";
    public string colExternalID = "//tr[@class='RptHeader']/td[@columnname='nickname']";
    public string txtExternalID = "External ID";
    public string colSystemID = "//tr[@class='RptHeader']/td[@columnname='UserName']";
    public string txtSystemID = "System ID";
    public string colBetCounts = "//tr[@class='RptHeader']/td[@columnname='betcounts']";
    public string txtBetCounts = "Bet Counts";
    public string colOutstanding = "//tr[@class='RptHeader']/td[@columnname='outstanding' and text()='Pending Funds']";
}

