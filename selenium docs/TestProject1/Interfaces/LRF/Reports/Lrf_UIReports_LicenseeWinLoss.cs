using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_LicenseeWinLoss
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
    
    public string ddlDate = "//*[@id='ddlDate']";
    public string txtDate = "//*[@id='fdate']";
    public string ddlCurrency = "//*[@id='ddlCurrency']";

    public string chkAll = "//*[@id='showall']";
    public string chkSB = "//*[@id='showsb']";
    public string chkRacing = "//*[@id='showrb']";
    public string chkNumberGame = "//*[@id='showng']";
    public string chkBA = "//*[@id='showba']";

    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='btnSubmit']";

    public string txtFrom = "//*[@id='fdate']";
    public string btnSelectFromDate = "//*[@id='fdate_trigger']";
    public string txtTo = "//*[@id='tdate']";
    public string btnSelectToDate = "//*[@id='tdate_trigger']";

    public string rdoReportByDaily = "//input[@name='rdoReportBy' and @value='1']";
    public string rdoReportByMonthly = "//input[@name='rdoReportBy' and @value='2']";

    public string rdoDrawFilterNormal = "//input[@name='rdofilter' and @value='1']";
    public string rdoDrawFilterNoDraws = "//input[@name='rdofilter' and @value='2']";
    public string rdoDrawFilterNoDrawsForTurnoverOnly = "//input[@name='rdofilter' and @value='3']";

    public string rdoExcludeTestDataYes = "//input[@name='rdoExcludeTesting' and @value='True']";
    public string rdoExcludeTestDataNo = "//input[@name='rdoExcludeTesting' and @value='False']";
	public string tblReportContent = "//*[@id='table_content']";
	public string lnkDrillDownToAgentList = "//tbody/tr[3]/td[3]/a";
	public string lnkDrillDownToMemberList = "//tbody/tr[3]/td[2]/a";
	public string lnkOpenBetList = "//tbody/tr[1]/td[2]/a";
	
	public string tblBetList = "//*[@id='page-content']";
	public string icoBetListExporttoExcel = "//div/div[2]/*[@id='exporttoexcel']";
	public string lnkBacktoMain = "//*[@id='aBackToMain']";
	public string lnkBacktoLicensee = "//*[@id='aBackToAgent']";
	public string frmMain = "//*[@id='criteria-container']";
	public string btnCloseBetlist = "//div[@class='IBCWndCloseButton']";
	
}

