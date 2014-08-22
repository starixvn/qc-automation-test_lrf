using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_RacingCommission
{
    public string lblTitle = "//div[text() = 'Racing Commission']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblFrom = "//span[text()='From:']";
    public string lblTo = "//span[text()='To:']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string icoExportBetlist = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='SubmitButton']";
    //public string btnToday = "//*[@id='dToday']";
    //public string btnYesterday = "//*[@id='dYesterday']";
    public string txtFrom = "//*[@id='fdate']";
    //public string btnSelectFrom = "//*[@id='fdate_trigger']";
    public string txtTo = "//*[@id='tdate']";
    //public string btnSelectTo = "//*[@id='tdate_trigger']";
    public string tblReportContent = "//*[@class='report-content ']";
    public string lnkOpenBetList = "//*[@id='data-content']/div[1]/div[2]/div/span[@class='downline-link bet-list-link']";
    public string icoBack = "//*[@id='page-content']/div[2]/div";
    public string tblBetList = "//*[@id='hor-minimalist-a']";
    public string frmMain = "//*[@id='BodyContent']";
    
    //select date
	public string lnkToday = "//li[@presettype = 'Today']";
	public string lnkYesterday = "//li[@presettype = 'Yesterday']";
	public string lnkCurrentWeek = "//li[@presettype = 'Currentweek']";
	public string lnkLastWeek = "//li[@presettype = 'Lastweek']";
	public string lnkCurrentMonth = "//li[@presettype = 'Currentmonth']";
	public string lnkLastMonth = "//li[@presettype = 'Lastmonth']";
	public string lnkSinceLastMonth = "//li[@presettype = 'Sincelastmonth']";
}

