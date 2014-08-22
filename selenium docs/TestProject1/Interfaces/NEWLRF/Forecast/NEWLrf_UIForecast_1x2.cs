using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIForecast_1x2
{
    public string lblTitle = "//*[@id='header-title']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='CurrencyId']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string btnSubmit = "//*[@id='submit-button']";
    public string btnRefresh = "//*[@id='CountDownRefresh']";
    public string btnDownTime = "//div[@class='btnDown']";
    public string opt15sec = "//*[@id='option0']";
	public string opt30sec = "//*[@id='option1']";
	public string opt45sec = "//*[@id='option2']";
	public string opt65sec = "//*[@id='option3']";
	public string opt75sec = "//*[@id='option4']";
	public string ddlLeague = "//*[@id='ddlLeague']";
	public string btnFullTimeForecast = "//*[@id='data-content']/table/tbody/tr[4]/td[2]/a";
	public string btnHalfTimeForecast = "//*[@id='data-content']/table/tbody/tr[5]/td[2]/a";
	public string tblDataContent = "//*[@id='data-content']";
	public string frmMain = "//*[@id='page-content']";
}

