using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UICustomerReports_CustomerTurnover
{
    public string lblTitle = "//*[@id='header-title']";
    public string lnkToday = "//a[text()='Today']";
    public string lnkYesterday = "//a[text()='Yesterday']";
    public string lnkCurrentweek = "//a[text()='Current week']";
    public string lnkLastweek = "//a[text()='Last week']";
    public string lnkCurrentmonth = "//a[text()='Current month']";
    public string lnkLastmonth = "//a[text()='Last month']";
    public string lnkSinceLastmonth = "//a[text()='Since last month']";
    
    public string txtUsername = "//*[@id='Username']";
    public string txtMiniOdds = "//*[@id='Odds']";
 	public string txtFromDate = "//*[@id='FromDate']";
 	public string btnFromdate = "//div[2]/img[@class='ui-daterangepicker-trigger']";
 	public string txtToDate = "//*[@id='ToDate']";
 	public string btnToDate = "//div[4]/img[@class='ui-daterangepicker-trigger']";
 	public string icoExporttoExcel = "//*[@id='ExportToExcel']";
 	public string ddlSportType = "//*[@id='SportId']";
 	public string ddlBetType = "//*[@id='Bettype']";
 	public string rdoReportbyDaily = "//*[@id='RadioDaily']";
 	public string rdoReportbyMonthly = "//*[@id='RadioMonthly']";
 	public string chkAllTicketFilter = "//*[@id='AllTicket']";
 	public string chkWinTicketFilter = "//*[@id='ShowWin']";
 	public string chkLossTicketFilter = "//*[@id='ShowLoss']";
 	public string chkDrawTicketFilter = "//*[@id='ShowDraw']";
 	public string frmMain = "//*[@id='CustomerTurnoverForm']";
 	public string tblReportContent = "//*[@class='report-content']";
 	public string btnSubmit = "//*[@id='SubmitButton']";
 	public string imgCheckUserName = "//*[@id='NullUsername' and @style='display: inline;']";
 	public string imgCheckMiniOdd = "//*[@id='NullOdds' and @style='display: inline;']";
 	
 	public string icoNote = "//*[@id='note-icon']";
	public string popNote = "//*[@id='note-wrapper']";
	public string icoCloseNote = "//*[@class='note-close']";
}

