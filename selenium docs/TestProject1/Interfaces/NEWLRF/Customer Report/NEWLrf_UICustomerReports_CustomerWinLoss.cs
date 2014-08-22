using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UICustomerReports_CustomerWinLoss
{
    public string lblTitle = "//div[text() = 'Customer Win Loss']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblFrom = "//span[text()='From:']";
    public string lblTo = "//span[text()='To:']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string txtFromDate = "//*[@id='FromDate']";
 	public string btnSelectFromDate = "//div[2]/img[@class='ui-daterangepicker-trigger']";
 	public string txtToDate = "//*[@id='ToDate']";
 	public string btnSelectToDate = "//div[4]/img[@class='ui-daterangepicker-trigger']";
    
    public string chkConvertTo = "IsConvert";
    public string icoExporttoExcel = "exporttoexcel";
    public string btnSubmit = "//*[@id='SubmitButton']";
    public string btnSubmitHistory = "//*[@id='SubmitHistoryButton']";
    public string lnkViewHistoryReport = "//*[@id='history-report-link']";
	public string lnkBackToCurrentReport = "//*[@id='current-report-link']";
	public string btnPreviousMonth = "//*[@id='DateControl']/a[1]/b";
	public string btnNextMonth = "//*[@id='DateControl']/a[2]/b";
	public string ddlFromDate = "//*[@id='MonthPickerFromDay']";
	public string ddlToDate = "//*[@id='MonthPickerToDay']";
    
    public string chkAllProduct = "ALLProducts";
    public string chkSBProduct = "//*[@data-product-code='SB' and @type='checkbox']";
    public string chkRacingProduct = "//*[@data-product-code='RB' and @type='checkbox']";
    public string chkNumberGameProduct = "//*[@data-product-code='NG' and @type='checkbox']";
    public string chkBAProduct = "//*[@data-product-code='BA' and @type='checkbox']";
    public string chkVSProduct = "//*[@data-product-code='VS' and @type='checkbox']";
    public string chkLCProduct = "//*[@data-product-code='LC' and @type='checkbox']";
    
    public string frmMain = "//*[@id='CustomerWinlossForm']";
    public string tblReportContent = "//*[@id='data-content']";
    public string lnkOpenBetList = "//*[@id='data-content']/div[1]/div[2]/div/a/span";
    public string btnBack = "//*[@id='page-content']/div[2]/div";
    
	public string icoNote = "//*[@id='note-icon']";
	public string popNote = "//*[@id='note-wrapper']";
	public string icoCloseNote = "//*[@class='note-close']";
	
	public string popLRFNotify = "//div[@class='ui-dialog-content ui-widget-content']";
	public string icoClosePopup = "//span[text()='close']";
	
    public string colNumberOrder = "//tr[@class='RptDoubleLineHeader headerrow']/td/p[text()='#']";
    public string colExternalID = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='External ID']";
    public string colSystemID = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='System ID']";
    public string colTurnover = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Turnover']";
    public string colMemberWinLoss = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Customer W/L']";
    public string colLicenseeWinLoss = "//tr[@class='RptDoubleLineHeader headerrow']/td[contains(text(),'Licensee W/L')]";
    public string colRacingRevenue = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Racing Revenue']";
    public string colAmtDueToRacing = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Amt Due To Racing']";
    public string colBACommission = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='BA Commission']";
    public string colAmtDueToBA = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Amt Due To BA']";
    
    //select date
	public string lnkToday = "//li[@presettype = 'Today']";
	public string lnkYesterday = "//li[@presettype = 'Yesterday']";
	public string lnkCurrentWeek = "//li[@presettype = 'Currentweek']";
	public string lnkLastWeek = "//li[@presettype = 'Lastweek']";
	public string lnkCurrentMonth = "//li[@presettype = 'Currentmonth']";
	public string lnkLastMonth = "//li[@presettype = 'Lastmonth']";
	public string lnkSinceLastMonth = "//li[@presettype = 'Sincelastmonth']";
}
}

