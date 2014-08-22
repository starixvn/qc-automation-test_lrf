using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UICustomerReports_CustomerPendingFunds
{
    public string lblTitle = "//div[text() = 'Customer Pending Funds']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//*[@id='SubmitButton']";
	public string chkAllProduct = "ALLProducts";
    public string chkSBProduct = "//*[@data-product-code='SB' and @type='checkbox']";
    public string chkRacingProduct = "//*[@data-product-code='RB' and @type='checkbox']";
    public string chkNumberGameProduct = "//*[@data-product-code='NG' and @type='checkbox']";
    public string chkBAProduct = "//*[@data-product-code='BA' and @type='checkbox']";
    public string chkVSProduct = "//*[@data-product-code='VS' and @type='checkbox']";
    public string chkLCProduct = "//*[@data-product-code='LC' and @type='checkbox']";
	public string frmMain = "//*[@id='CustomerPendingFundsForm']";
	public string tblReportContent = "//*[@id='data-content']";
	public string lnkOpenBetList = "//*[@id='data-content']/div[1]/div[2]/div/a/span";
	public string popLRFNotify = "//div[@class='ui-dialog-content ui-widget-content']";
	public string icoClosePopup = "//span[text()='close']";
	public string icoNote = "//*[@id='note-icon']";
	public string popNote = "//*[@id='note-wrapper']";
	public string icoCloseNote = "//*[@class='note-close']";
	
    public string colNumberOrder = "//tr[@class='RptHeader']/td[text()='#']";
    public string colExternalID = "//tr[@class='RptHeader']/td[@columnname='nickname']";
    public string txtExternalID = "External ID";
    public string colSystemID = "//tr[@class='RptHeader']/td[@columnname='UserName']";
    public string txtSystemID = "System ID";
    public string colBetCounts = "//tr[@class='RptHeader']/td[@columnname='betcounts']";
    public string txtBetCounts = "Bet Counts";
    public string colOutstanding = "//tr[@class='RptHeader']/td[@columnname='outstanding' and text()='Pending Funds']";
}

