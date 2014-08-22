using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UICustomerReports_CustomerTurnover
{
    public string lblTitle = "//*[@id='header-title']";
    public string ddlDateRange = "//*[@id='ddlDate']";
    public string txtUsername = "//*[@id='txtUserName' and @class='txtUserName']";
    public string txtMiniOdds = "//*[@id='txtMinimumodds']";
 	public string txtFromDate = "//*[@id='fdate']";
 	public string btnFromdate = "//*[@id='fdate_trigger']";
 	public string txtToDate = "//*[@id='tdate']";
 	public string btnToDate = "//*[@id='tdate_trigger']";
 	public string icoExporttoExcel = "//*[@id='exporttoexcel']";
 	public string ddlSportType = "//*[@id='ddlSport']";
 	public string ddlBetType = "//*[@id='ddlBetType']";
 	public string rdoReportbyDaily = "//input[@value = '1' and @name = 'rdoReportBy']";
 	public string rdoReportbyMonthly = "//input[@value = '2' and @name = 'rdoReportBy']";
 	public string chkAllTicketFilter = "//*[@id='ticket-filter-all']";
 	public string chkWinTicketFilter = "//*[@id='ticket-filter-win']";
 	public string chkLossTicketFilter = "//*[@id='ticket-filter-loss']";
 	public string chkDrawTicketFilter = "//*[@id='ticket-filter-draw']";
 	public string frmMain = "//*[@id='criteria-container']";
 	public string tblReportContent = "//*[@id='table-content']";
 	public string btnSubmit = "//*[@id='btnSubmit']";
 	public string imgCheckUserName = "//*[@id='imgCheckUserName' and @class='imgCheckError']";
 	public string imgCheckMiniOdd = "//*[@id='imgCheckOdds' and @class='imgCheckError']";
}

