using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_LicenseeWinLoss
{
    public string lblTitle = "//*[@id='header-title']";
    public string lblDate = "//td[contains(text(),'Date:')]";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblFrom = "//td[contains(text(),'From:')]";
    public string lblTo = "//td[contains(text(),'To:')]";
    public string lblReportBy = "//td[contains(text(),'Report by:')]";
    public string lblReportByDaily = "//td[contains(text(),'Daily')]";
    public string lblReportByMonthly = "//td[contains(text(),'Monthly')]";
    public string lblDrawFilter = "//td[contains(text(),'Draw filter:')]";
    public string lblDrawFilterNormal = "//td[contains(text(),'Normal')]";
    public string lblDrawFilterNoDraws = "//td[contains(text(),'No Draws')]";
    public string lblDrawFilterNoDrawsForTurnoverOnly = "//td[contains(text(),'No Draws For Turnover Only')]";
    public string lblExcludeTestData = "//td[contains(text(),'Exclude Test Data:')]";
    public string lblExcludeTestDataYes = "//td[contains(text(),'Yes')]";
    public string lblExcludeTestDataNo = "//td[contains(text(),'No')]";
    
    public string ddlCurrency = "//*[@id='CurrencyId']";

    public string chkAllProduct = "ALLProducts";
    public string chkSBProduct = "//*[@data-product-code='SB' and @type='checkbox']";
    public string chkRacingProduct = "//*[@data-product-code='RB' and @type='checkbox']";
    public string chkNumberGameProduct = "//*[@data-product-code='NG' and @type='checkbox']";
    public string chkBAProduct = "//*[@data-product-code='BA' and @type='checkbox']";
    public string chkVSProduct = "//*[@data-product-code='VS' and @type='checkbox']";
    public string chkLCProduct = "//*[@data-product-code='LC' and @type='checkbox']";

    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//input[@value='Submit']";

//    public string txtFrom = "//*[@id='FromDate']";
//    public string btnSelectFromDate = "//*[@id='fdate_trigger']";
//    public string txtTo = "//*[@id='tdate']";
//    public string btnSelectToDate = "//*[@id='tdate_trigger']";

    public string rdoReportByDaily = "//input[@name='reportby' and @value='1']";
    public string rdoReportByMonthly = "//input[@name='reportby' and @value='2']";

    public string rdoDrawFilterNormal = "//input[@name='drawfilter' and @value='1']";
    public string rdoDrawFilterNoDraws = "//input[@name='drawfilter' and @value='2']";
    public string rdoDrawFilterNoDrawsForTurnoverOnly = "//input[@name='drawfilter' and @value='3']";

    public string rdoExcludeTestDataYes = "//input[@name='IsExcludedTestData' and @value='True']";
    public string rdoExcludeTestDataNo = "//input[@name='IsExcludedTestData' and @value='False']";
	public string tblReportContent = "//*[@id='data-content']";
	public string lnkDrillDownToAgentList = "//div[1]/div[1]/a";
	public string lnkDrillDownToMemberList = "//div[1]/div[2]/div/a";
	public string lnkOpenBetList = "//div[1]/div[3]/div/a";
	
	public string tblBetList = "//*[@id='page-content']";
	public string icoBetListExporttoExcel = "//*[@id='exporttoexcel']";
	public string lnkBacktoMain = "//*[@id='aBackToMain']";
	public string lnkBacktoLicensee = "//*[@id='aBackToAgent']";
	public string frmMain = "http://internal.006660.com/Report/CustomerWinloss?showsb=true&showrb=true&showng=true&showba=true&rdoExcludeTesting=true";
	public string btnCloseBetlist = "//div[@class='IBCWndCloseButton']";
	public string frmbody = "//*[@id='BodyContent']";
	
	//select date
	public string lnkToday = "//li[@presettype = 'Today']";
	public string lnkYesterday = "//li[@presettype = 'Yesterday']";
	public string lnkCurrentWeek = "//li[@presettype = 'Currentweek']";
	public string lnkLastWeek = "//li[@presettype = 'Lastweek']";
	public string lnkCurrentMonth = "//li[@presettype = 'Currentmonth']";
	public string lnkLastMonth = "//li[@presettype = 'Lastmonth']";
	public string lnkSinceLastMonth = "//li[@presettype = 'Sincelastmonth']";
	
}

