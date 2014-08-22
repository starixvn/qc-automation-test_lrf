using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UITotalBets_ToWinToNil
{
    public string lblTitle = "//div[text() = 'To win to nil']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyType";
    public string chkConvertTo = "IsConvert";
    public string btnSubmit = "//*[@id='submit-button']";
    public string colNumberOrder = "//th[text()='#']";
    public string colExternalID = "//th[text()='External ID']";
    public string colSystemID = "//th[text()='System ID']";
    public string colTransTime = "//th[text()='Trans.Time']";
    public string colChoice = "//th[text()='Choice']";
    public string colOdds = "//th[text()='Odds']";
    public string colStake = "//th[text()='Stake']";
    public string colStatus = "//th[text()='Status']";
    public string tblDataContent = "//*[@id='hor-minimalist-a']";
	public string frmMain = "//*[@id='page-content']";
    public string icoExportToExcel = "//input[@id='exporttoexcel' and @title='Export to Excel']";
}

