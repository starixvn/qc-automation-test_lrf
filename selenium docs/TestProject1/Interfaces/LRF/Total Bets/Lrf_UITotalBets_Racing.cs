using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UITotalBets_Racing
{
    public string lblTitle = "//div[text()='Racing']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyType";
    public string chkConvertTo = "IsConvert";
    public string btnSubmit = "//*[@id='submit-button']";
    public string btnRefresh = "//*[@id='CountDownRefresh']";
    public string btnDownTime = "//div[@class='btnDown']";
    public string opt15sec = "//*[@id='option0']";
	public string opt30sec = "//*[@id='option1']";
	public string opt45sec = "//*[@id='option2']";
	public string opt65sec = "//*[@id='option3']";
	public string opt75sec = "//*[@id='option4']";
	public string tblDataContent = "//*[@id='data-content']";
	public string frmMain = "//*[@id='page-content']";
    public string colRace = "//tr[@class='RptHeader']/td[@rowspan='3' and text()='Race ']";
    public string colRunnerNo = "//tr[@class='RptHeader']/td[@rowspan='3' and text()='Runner No']";
    public string colRunner = "//tr[@class='RptHeader']/td[@rowspan='3' and text()='Runner']";
    public string colTote = "//tr[@class='RptHeader']/td[@colspan='6' and text()='Tote']";
    public string colTote_Win = "//tr[@class='RptHeader']/td[@colspan='2' and text()='Win']";
    public string colTote_Place = "//tr[@class='RptHeader']/td[@colspan='2' and text()='Place']";
    public string colTote_WinPlace = "//tr[@class='RptHeader']/td[@colspan='2' and text()='Win Place']";
    public string colWinTotal = "//tr[@class='RptHeader02']/td[text()='Total'][1]";
    public string colWinRevenue = "//tr[@class='RptHeader02']/td[text()='Revenue'][2]";
    public string colPlaceTotal = "//tr[@class='RptHeader02']/td[text()='Total'][3]";
    public string colPlaceRevenue = "//tr[@class='RptHeader02']/td[4]";
    public string txtPlaceRevenue = "Revenue";
    public string colWinPlaceTotal = "//tr[@class='RptHeader02']/td[5]";
    public string txtWinPlaceTotal = "Total";
    public string colWinPlaceRevenue = "//tr[@class='RptHeader02']/td[6]";
    public string txtWinPlaceRevenue = "Revenue";
}

