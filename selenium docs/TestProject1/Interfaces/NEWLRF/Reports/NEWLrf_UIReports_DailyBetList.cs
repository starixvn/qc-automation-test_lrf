using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_DailyBetList
{
    public string lblTitle = "//div[text() = 'Daily Bet List']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblDate = "//span[text()='Date:']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string icoExporttoExcel = "//*[@id='Image1']";
    public string btnSubmit = "//*[@id='submit-button']";
    public string btnToday = "//*[@id='dToday']";
    public string btnYesterday = "//*[@id='dYesterday']";
    public string txtDate = "//*[@id='fdate']";
	public string btnSelectDate = "//*[@id='fdate_trigger']";
    public string frmMain = "//*[@id='criteria-container']";
    public string tblReportContent = "//*[@id='hor-minimalist-a']";
}

