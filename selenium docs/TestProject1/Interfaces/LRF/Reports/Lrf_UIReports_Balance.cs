using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_Balance
{
    public string lblTitle = "//div[text() = 'Balance']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblMonth = "//div[text()='Month:']";
    public string lblYear = "//div[text()='Year:']";
    public string lblTermDefinition = "//div[text()='Term Definition']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyType";
    public string chkConvertTo = "IsConvert";
    public string icoExporttoExcel = "exporttoexcel";
    public string btnSubmit = "submit-button";
    public string ddlMonth = "SelectedMonth";
    public string ddlYear = "SelectedYear";
    public string frmMain = "//*[@id='criteria-container']";
    public string tblReportContent = "//*[@id='tbl-rpt']";

    public string rowBalanceInformation = "//span[contains(text(),'Balance Information')]";
    public string colLicenseeWL = "//tr[@class='RptDoubleLineHeader headerrow']/td[contains(text(),'Licensee W/L')]";
    public string colBACommission = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='BA Commission']";
    public string colRacingRevenue = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Racing Revenue']";
    public string colAmtDueToBA = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Amt Due To BA']";
    public string colAmtDueToRacing = "//tr[@class='RptDoubleLineHeader headerrow']/td[text()='Amt Due To Racing']";
    public string rowMemberInformation = "//span[text()='Customer Information']";
    public string rowMemberOutstanding = "//td[text()='Customer Pending Funds']";
    public string rowTotalMemberActiveClosedSuspended = "//td[text()='Total Customer active/closed/suspended']";
}

