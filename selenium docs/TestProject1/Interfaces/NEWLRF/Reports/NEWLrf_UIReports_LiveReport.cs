using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_LiveReport
{
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string txtFromDate = "//*[@id='FromDate']";
    public string btnSelectFromDate = "//*[@id='fdate_trigger']";
    public string txtToDate = "//*[@id='ToDate']";
    public string iconPreviousMonth = "//*[@id='month-picker']/a[1]/b";
    public string btnSelectToDate = "//*[@id='tdate_trigger']";
    public string frmMain = "//*[@id='BodyContent']";
    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//input[@value='Submit']";
	public string tblReportContent = "//*[@class='report-content']";
	public string tblBetlist = "//*[@id='hor-minimalist-a']";
	public string lnkDrillDowntoNumberGame = "//a[contains(text(),'Number Game') and @class ='product-detail-link']";
	public string lnkDrillDowntoRacing = "//a[contains(text(),'Racing') and @class ='product-detail-link']";
	public string lnkDrillDowntoSportsbook = "//a[contains(text(),'Sportsbook') and @class ='product-detail-link']";
	public string lnkDrillDowntoTotal = "//a[contains(text(),'Total') and @class ='product-detail-link']";
	public string lnkDrillDowntoLiveCasino = "//a[contains(text(),'Live Casino') and @class ='product-detail-link']";
	public string lnkViewHistoryReport = "//*[@id='switchreport']";
    public string lnkBacktoCurrentReport = "//a[contains(text(),'Back to current report')]";
    public string lnkSoccer = "//a[contains(text(),'Soccer') and @class='sport-detailt-link']";
    public string lnkBasketball = "//a[contains(text(),'Basketball') and @class='sport-detailt-link']";
    public string lnkTennis = "//a[contains(text(),'Tennis') and @class='sport-detailt-link']";
    public string lnkBaseball = "//a[contains(text(),'Baseball') and @class='sport-detailt-link']";
    public string lnkBadminton = "//a[contains(text(),'Badminton') and @class='sport-detailt-link']";
    public string lnkGolf = "//a[contains(text(),'Golf') and @class='sport-detailt-link']";
    public string lnkMotorsports = "//a[contains(text(),'Motorsports') and @class='sport-detailt-link']";
    public string lnkBoxingMMA = "//a[contains(text(),'Boxing/MMA') and @class='sport-detailt-link']";
    public string lnkHandball = "//a[contains(text(),'Handball') and @class='sport-detailt-link']";
    public string lnkRugby = "//a[contains(text(),'Rugby') and @class='sport-detailt-link']";
    public string lnkNetball = "//a[contains(text(),'Netball') and @class='sport-detailt-link']";
    public string lnkMixParlay = "//a[contains(text(),'Mix Parlay') and @class='sport-detailt-link']";
    public string lnkSystemParlay = "//a[contains(text(),'System Parlay') and @class='sport-detailt-link']";
    public string lnkOutright = "//a[contains(text(),'Outright') and @class='sport-detailt-link']]";
    public string lnkHorseRacing = "//a[contains(text(),'Horse Racing') and @class='sport-detailt-link']";
    public string lnkNumberGame = "//a[contains(text(),'Number Game') and @class='sport-detailt-link']";
    public string icoBack = "//div[@class='history-link']";
    public string lnkOpenBetList = "//div[2]/div[1]/div[1]/a[@class='match-detail-link']";
    public string tblDetailContent = "//*[@class='report-content']";
    public string tblMatchList = "//*[@class='data-content']";
	public string lnkResult = "//tr[1]/td[10]/div[@class='result-link']";
	public string popResult = "//*[@id='tbl-rpt' and @class='report-table tblResult']";
	public string icoCloseResultPopup = "//div[@title='Close']";
	
	//select date
	public string lnkToday = "//li[@presettype = 'Today']";
	public string lnkYesterday = "//li[@presettype = 'Yesterday']";
	public string lnkCurrentWeek = "//li[@presettype = 'Currentweek']";
	public string lnkLastWeek = "//li[@presettype = 'Lastweek']";
	public string lnkCurrentMonth = "//li[@presettype = 'Currentmonth']";
	public string lnkLastMonth = "//li[@presettype = 'Lastmonth']";
	public string lnkSinceLastMonth = "//li[@presettype = 'Sincelastmonth']";
}

