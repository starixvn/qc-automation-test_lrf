using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_WinLossByProducts
{
    public string lblTitle = "//div[text() = 'Win Loss By Products']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblFrom = "//td[text()='From:']";
    public string lblTo = "//td[text()='To:']";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//*[@value='Submit']";
    //public string ddlDate = "//*[@id='ddlDate']";
    public string txtFrom = "//*[@id='FromDate']";
    public string txtTo = "//*[@id='ToDate']";
    public string chkAllProduct = "ALLProducts";
    public string chkSBProduct = "//*[@data-product-code='SB' and @type='checkbox']";
    public string chkRacingProduct = "//*[@data-product-code='RB' and @type='checkbox']";
    public string chkNumberGameProduct = "//*[@data-product-code='NG' and @type='checkbox']";
    public string chkBAProduct = "//*[@data-product-code='BA' and @type='checkbox']";
    public string chkVSProduct = "//*[@data-product-code='VS' and @type='checkbox']";
    public string chkLCProduct = "//*[@data-product-code='LC' and @type='checkbox']";
	public string rdoReportbyDaily = "//input[@value='1' and @name='reportby']";
	public string rdoReportbyMonthly = "//input[@value='2' and @name='reportby']";
	public string rdoDrawFilterNormal = "//input[@value='1' and @name='drawfilter']";
	public string rdoDrawFilterNoDraws = "//input[@value='2' and @name='drawfilter']";
	public string rdoDrawFilterNoDrawsForTurnoverOnly = "//input[@value='3' and @name='drawfilter']";
	public string rdoExcludeTestDataYes = "//input[@value='True' and @name='IsExcludedTestData']";
	public string rdoExcludeTestDataNo = "//input[@value='False' and @name='IsExcludedTestData']";
	public string tblReportContent = "//*[@class='data-content']";
	public string lnkDrillDowntoAgent = "//div[2]/div[1]/div[2]/a";
	public string lnkDrillDowntoMember = "//div[1]/div[1]/div[2]/div/a";
	public string lnkOpenBetList = "//div[1]/div[1]/div[2]/a";
	//public string lnkBetList = "//*[@id='hor-minimalist-a']";
	public string btnCloseBetList = "//span[@class='ui-icon ui-icon-closethick']";
	public string lnkBackToLicensee = "///*[@class='history-link' and contains(text(),'Licensee')]";
	public string lnkBackToMain = "//*[@id='aBackToMain']"; 
	public string frmMain = "//*[@id='winlossbyproduct']";
	public string tblBetList = "//*[@id='hor-minimalist-a']";
	public string icoExportBetList = "//*[@id='exporttoexcel']";
	//select date
	public string lnkToday = "//li[@presettype = 'Today']";
	public string lnkYesterday = "//li[@presettype = 'Yesterday']";
	public string lnkCurrentWeek = "//li[@presettype = 'Currentweek']";
	public string lnkLastWeek = "//li[@presettype = 'Lastweek']";
	public string lnkCurrentMonth = "//li[@presettype = 'Currentmonth']";
	public string lnkLastMonth = "//li[@presettype = 'Lastmonth']";
	public string lnkSinceLastMonth = "//li[@presettype = 'Sincelastmonth']";
}

