using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_MobileWinLoss
{
    public string btnPreviousMonth = "//*[@id='DateControl']/a[1]/b";
    public string btnNextMonth = "//*[@id='DateControl']/a[2]/b";
    public string ddlFromDate = "//*[@id='MonthPickerFromDay']";
    public string ddlToDate = "//*[@id='MonthPickerToDay']";
    public string chkExcludeTestData = "//*[@id='IsExcludeTest']";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string rdoDrawFilterNormal = "//*[@id='RadioNormal']";
    public string rdoDrawFilterNoDraws = "//*[@id='RadioNoDraws']";
    public string rdoNoDrawsForTurnoverOnly = "//*[@id='RadioNoDrawsForTurnoverOnly']";
    public string rdoSmartPhoneSite = "//*[@id='SmartPhoneSite']";
    public string rdoOthersSite = "//*[@id='OthersSite']";
    public string rdoWap = "//*[@id='WapSite']";
    public string chkAllProduct = "ALLProducts";
    public string chkSBProduct = "//*[@data-product-code='SB' and @type='checkbox']";
    public string chkRacingProduct = "//*[@data-product-code='RB' and @type='checkbox']";
    public string chkNumberGameProduct = "//*[@data-product-code='NG' and @type='checkbox']";
    public string chkBAProduct = "//*[@data-product-code='BA' and @type='checkbox']";
    public string chkVSProduct = "//*[@data-product-code='VS' and @type='checkbox']";
    public string chkLCProduct = "//*[@data-product-code='LC' and @type='checkbox']";
    
    public string frmMain = "//*[@id='MobileWinLossForm']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//*[@id='SubmitButton']";
	public string tblReportContent = "//*[@id='gview_ReportGrid']";
	public string lnkCurrency = "//*[@id='1']/td[5]/a";
	public string lnkSystemID = "//*[@id='1']/td[4]/a";
	public string lnkLicensee = "//li[contains(text(),'Licensee')]";
	public string lnkMain = "//li[contains(text(),'Main')]";
}

