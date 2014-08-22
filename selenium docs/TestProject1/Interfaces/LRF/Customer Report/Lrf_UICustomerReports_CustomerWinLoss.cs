using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UICustomerReports_CustomerWinLoss
{
    public string lblTitle = "//div[text() = 'Customer Win Loss']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblFrom = "//span[text()='From:']";
    public string btnSelectFromDate = "//*[@id='fdate_trigger']";
    public string lblTo = "//span[text()='To:']";
    public string btnSelectToDate = "//*[@id='tdate_trigger']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyType";
    public string chkConvertTo = "IsConvert";
    public string icoExporttoExcel = "exporttoexcel";
    public string btnSubmit = "submit-button";
    public string btnToday = "dToday";
    public string btnYesterday = "dYesterday";
    public string lnkViewHistoryReport = "//a[text() = 'View History Report']";
	public string lnkBackToCurrentReport = "//a[text() = 'Back To Current Report']";
	public string btnPreviousMonth = "//*[@id='dateControl']/a[1]/b";
	public string btnNextMonth = "//*[@id='dateControl']/a[2]/b";
	public string ddlFromDate = "//*[@id='fDay']";
	public string ddlToDate = "//*[@id='tDay']";
    
    public string chkAllProduct = "showall";
    public string chkSBProduct = "showsb";
    public string chkRacingProduct = "showrb";
    public string chkNumberGameProduct = "showng";
    public string chkBAProduct = "showba";
    
    public string frmMain = "//*[@id='criteria-container']";
    public string tblReportContent = "//*[@id='content-container']";
    public string lnkOpenBetList = "//*[@id='tbl-rpt2']/tbody/tr[1]/td[2]/span";
    public string btnBack = "//*[@id='page-content']/div[2]/div";

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
    
}

