using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_LiveReport
{
    public string ddlCurrency = "//*[@id='CurrencyType']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string ddlDate = "//*[@id='ddlDate']";
    public string ddlFromDate = "//*[@id='fDay']";
    public string btnSelectFromDate = "//*[@id='fdate_trigger']";
    public string txtToDate = "//*[@id='tdate']";
    public string iconPreviousMonth = "//*[@id='month-picker']/a[1]/b";
    public string btnSelectToDate = "//*[@id='tdate_trigger']";
    public string frmMain = "//*[@id='criteria-container']";
    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='btnSubmit']";
	public string tblReportContent = "//*[@id='ReportContentPanel']";
	public string tblBetlist = "//*[@id='hor-minimalist-a']";
	public string lnkDrillDowntoNumberGame = "//*[@id='productdetailNG']/span[contains(text(),'Number Game')]";
	public string lnkDrillDowntoRacing = "//*[@id='productdetailRB']/span[contains(text(),'Racing')]";
	public string lnkDrillDowntoSportsbook = "//*[@id='productdetailSB']/span[contains(text(),'Sportsbook')]";
	public string lnkDrillDowntoTotal = "//*[@id='productdetailALL']/span[contains(text(),'Total')]";
	public string lnkViewHistoryReport = "//a[contains(text(),'View History Report')]";
    public string lnkBacktoCurrentReport = "//a[contains(text(),'Back To Current Report')]";
    public string lnkSoccer = "//span[contains(text(),'Soccer')]";
    public string lnkBasketball = "//span[contains(text(),'Basketball')]";
    public string lnkTennis = "//span[contains(text(),'Tennis')]";
    public string lnkBaseball = "//span[contains(text(),'Baseball')]";
    public string lnkBadminton = "//span[contains(text(),'Badminton')]";
    public string lnkGolf = "//span[contains(text(),'Golf')]";
    public string lnkMotorsports = "//span[contains(text(),'Motorsports')]";
    public string lnkBoxingMMA = "//span[contains(text(),'Boxing/MMA')]";
    public string lnkHandball = "//span[contains(text(),'Handball')]";
    public string lnkRugby = "//span[contains(text(),'Rugby')]";
    public string lnkNetball = "//span[contains(text(),'Netball')]";
    public string lnkMixParlay = "//span[contains(text(),'Mix Parlay')]";
    public string lnkSystemParlay = "//span[contains(text(),'System Parlay')]";
    public string lnkOutright = "//span[contains(text(),'Outright')]";
    public string lnkHorseRacing = "//span[contains(text(),'Horse Racing')]";
    public string lnkNumberGame = "//*[@id='detailcontent']//span[contains(text(),'Number Game')]";
    public string icoBack = "//div[@class='history-link']";
    public string lnkOpenBetList = "//tr[2]/td[1]/span[@class='downline-link']";
    public string tblDetailContent = "//*[@id='detailcontent']";
    public string tblMatchList = "//*[@id='PanelPage']/table";
	public string lnkResult = "//tr[1]/td[10]/div[@class='result-link']";
	public string popResult = "//td[contains(text(),'Status')]";
	public string icoCloseResultPopup = "//div[@title='Close']";
}

