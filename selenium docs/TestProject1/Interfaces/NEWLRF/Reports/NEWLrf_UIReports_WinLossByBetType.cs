using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_WinLossByBetType
{
    public string lblTitle = "//div[text() = 'Win Loss By Bet Type']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblFrom = "//span[text()='From:']";
    public string lblTo = "//span[text()='To:']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//*[@id='SubmitButton']";
    //public string btnToday = "//*[@id='dToday']";
    //public string btnYesterday = "//*[@id='dYesterday']";
    public string txtFrom = "//*[@id='FromDate']";
    //public string btnSelectFromDate = "//*[@id='fdate_trigger']";
    public string txtTo = "//*[@id='ToDate']";
    //public string btnSelectToDate = "//*[@id='tdate_trigger']";
	public string tblReportContent = "//*[@id='data-content']";
	public string frmMain = "//*[@id='WinLossByBetTypeForm']";
	//select date
	public string lnkToday = "//li[@presettype = 'Today']";
	public string lnkYesterday = "//li[@presettype = 'Yesterday']";
	public string lnkCurrentWeek = "//li[@presettype = 'Currentweek']";
	public string lnkLastWeek = "//li[@presettype = 'Lastweek']";
	public string lnkCurrentMonth = "//li[@presettype = 'Currentmonth']";
	public string lnkLastMonth = "//li[@presettype = 'Lastmonth']";
	public string lnkSinceLastMonth = "//li[@presettype = 'Sincelastmonth']";

}

