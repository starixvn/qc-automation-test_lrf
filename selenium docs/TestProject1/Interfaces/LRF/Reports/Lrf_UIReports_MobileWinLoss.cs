using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_MobileWinLoss
{
    public string btnPreviousMonth = "//*[@id='DateControl']/a[1]/b";
    public string btnNextMonth = "//*[@id='DateControl']/a[2]/b";
    public string ddlFromDate = "//*[@id='MonthPickerFromDay']";
    public string ddlToDate = "//*[@id='MonthPickerToDay']";
    public string chkExcludeTestData = "//*[@id='IsExcludeTest']";
    public string ddlCurrency = "//*[@id='DdlCurrencyType']";
    public string rdoDrawFilterNormal = "//*[@id='RadioNormal']";
    public string rdoDrawFilterNoDraws = "//*[@id='RadioNoDraws']";
    public string rdoNoDrawsForTurnoverOnly = "//*[@id='RadioNoDrawsForTurnoverOnly']";
    public string chkAllSite = "//*[@id='cbbAllSite']";
    public string chkMobileSite = "//*[@id='cbbMobileSite']";
    public string chkOthersSite = "//*[@id='cbbOthersSite']";
    public string chkAllProduct = "//*[@id='ALLProducts']";
    public string chkSBProduct = "//*[@id='ShowSb']";
    public string chkRacingProduct = "//*[@id='ShowRb']";
    public string chkNumberGameProduct = "//*[@id='ShowNg']";
    public string chkBAProduct = "//*[@id='ShowBa']";
    
    public string frmMain = "//*[@id='MobileWinLossForm']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//*[@id='SubmitButton']";
	public string tblReportContent = "//*[@id='ContentMainContent']";
}

