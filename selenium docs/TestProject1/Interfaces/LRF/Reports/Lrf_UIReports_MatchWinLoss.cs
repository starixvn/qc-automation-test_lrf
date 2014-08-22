using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_MatchWinLoss
{
    public string lblTitle = "//div[contains(text(),'Match Win Loss') and @class= 'content-title']";
    public string lblType = "//div[contains(text(),'Type')]";
    public string lblCurrency = "//div[contains(text(),'Currency')]";
    public string lblConvertTo = "//div/label[contains(text(),'Convert to EUR')]";
	public string lblDate = "//div[contains(text(),'Date')]";
	public string btnSelectDate = "//*[@id='imgDate']";
    public string ddlType = "//*[@id='DdlLicenseeType']";
    public string ddlCurrency = "//*[@id='DdlCurrencyType']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//*[@id='SubmitButton']";
	public string tblReportContent = "//*[@id='ContentMainContent']";
	public string icoBack = "//*[@id='page-content']/div[2]/div";
	public string frmMain = "//*[@id='MatchWinLossForm']";
	public string chkAllProduct = "//*[@id='ALLProducts']";
	public string chkSBProduct = "//*[@id='ShowSb']";
	public string chkRacingProduct = "//*[@id='ShowRb']";
	public string chkNumberGameProduct = "//*[@id='ShowNg']";
	public string chkBAProduct = "//*[@id='ShowBa']";
	public string lnkExpandMatch = "//tbody/tr[2]/td[2]/span";
	public string lnkOpenBetList = "//tbody/tr[3]/td[1]/span";
	public string tblBetList = "//*[@id='hor-minimalist-a']";
	public string icoExportBetList = "//*[@id='exporttoexcel']";
	
	
}

