using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_CancelledBets
{
    public string lblTitle = "//div[text() = 'Void/Rejected Bet List (Last 3 days)']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='CurrencyType']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string ddlExternalID = "//*[@id='custid']";
    public string frmMain = "//*[@id='criteria-container']";
    
    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='submit-button']";
	public string tblReportContent = "//*[@id='page-content']";
    
    public string colNumberOrder = "//tr[@id='tr-betlist-header']/th[text()='#']";
    public string colExternalID = "//tr[@id='tr-betlist-header']/th[text()='External ID']";
    public string colSystemID = "//tr[@id='tr-betlist-header']/th[text()='System ID']";
    public string colTransTime = "//tr[@id='tr-betlist-header']/th[text()='Trans.Time']";
    public string colChoice = "//tr[@id='tr-betlist-header']/th[text()='Choice']";
    public string colOdds = "//tr[@id='tr-betlist-header']/th[text()='Odds']";
    public string colStake = "//tr[@id='tr-betlist-header']/th[text()='Stake']";
    public string colStatus = "//tr[@id='tr-betlist-header']/th[text()='Status']";
}

