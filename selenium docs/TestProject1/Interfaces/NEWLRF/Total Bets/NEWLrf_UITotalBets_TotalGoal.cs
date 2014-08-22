using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UITotalBets_TotalGoal
{
    public string lblTitle = "//div[text() = 'Total Goal']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyId";
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
	

    public string colNumberOrder = "//tr[@class='RptHeader']/td[text()='#']";
    public string colHome = "//tr[@class='RptHeader']/td[text()='Home']";
    public string colAway = "//tr[@class='RptHeader']/td[text()='Away']";
    public string col01 = "//tr[@class='RptHeader']/td[text()='0-1']";
    public string col23 = "//tr[@class='RptHeader']/td[text()='2-3']";
    public string col46 = "//tr[@class='RptHeader']/td[text()='4-6']";
    public string col7Over = "//tr[@class='RptHeader']/td[text()='7Over']";
}

