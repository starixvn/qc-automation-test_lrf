using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_WinLossByProducts
{
    public string lblTitle = "//div[text() = 'Win Loss By Products']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblFrom = "//td[text()='From:']";
    public string lblTo = "//td[text()='To:']";
    public string ddlCurrency = "//*[@id='ddlCurrency']";
    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='btnSubmit']";
    public string ddlDate = "//*[@id='ddlDate']";
    public string txtFrom = "//*[@id='fdate']";
    public string txtTo = "//*[@id='tdate']";
    public string chkAll = "//*[@id='showall']";
    public string chkSB = "//*[@id='showsb']";
    public string chkRacing = "//*[@id='showrb']";
    public string chkNumberGame = "//*[@id='showng']";
	public string chkBA = "//*[@id='showba']";
	public string rdoReportbyDaily = "//input[@value='1' and @name='rdoReportBy']";
	public string rdoReportbyMonthly = "//input[@value='2' and @name='rdoReportBy']";
	public string rdoDrawFilterNormal = "//input[@value='1' and @name='rdofilter']";
	public string rdoDrawFilterNoDraws = "//input[@value='2' and @name='rdofilter']";
	public string rdoDrawFilterNoDrawsForTurnoverOnly = "//input[@value='3' and @name='rdofilter']";
	public string rdoExcludeTestDataYes = "//input[@value='True' and @name='rdoExcludeTesting']";
	public string rdoExcludeTestDataNo = "//input[@value='False' and @name='rdoExcludeTesting']";
	public string tblReportContent = "//*[@id='page-content']";
	public string lnkDrillDowntoAgent = "//td[2]/a";
	public string lnkDrillDowntoMember = "//td[2]/a";
	public string lnkOpenBetList = "//td[2]/a";
	public string lnkBetList = "//*[@id='hor-minimalist-a']";
	public string btnCloseBetList = "//div[@class='IBCWndCloseButton']";
	public string lnkBackToLicensee = "//*[@id='aBackToAgent']";
	public string lnkBackToMain = "//*[@id='aBackToMain']"; 
	public string frmMain = "//*[@id='criteria-container']";
	public string tblBetList = "//*[@id='hor-minimalist-a']";
	public string icoExportBetList = "//*[@id='exporttoexcel']";
}

