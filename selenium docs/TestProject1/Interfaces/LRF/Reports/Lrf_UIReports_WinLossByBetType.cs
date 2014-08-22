using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_WinLossByBetType
{
    public string lblTitle = "//div[text() = 'Win Loss By Bet Type']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblFrom = "//span[text()='From:']";
    public string lblTo = "//span[text()='To:']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='CurrencyType']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='submit-button']";
    public string btnToday = "//*[@id='dToday']";
    public string btnYesterday = "//*[@id='dYesterday']";
    public string txtFrom = "//*[@id='fdate']";
    public string btnSelectFromDate = "//*[@id='fdate_trigger']";
    public string txtTo = "//*[@id='tdate']";
    public string btnSelectToDate = "//*[@id='tdate_trigger']";
	public string tblReportContent = "//*[@id='tbl-rpt']";
	public string frmMain = "//*[@id='criteria-container']";

}

