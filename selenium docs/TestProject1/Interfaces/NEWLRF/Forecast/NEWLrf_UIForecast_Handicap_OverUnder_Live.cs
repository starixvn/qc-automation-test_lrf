using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIForecast_Handicap_OverUnder_Live
{
    public string lblTitle = "//*[@id='header-title']";
    public string lblType = "//*[@id='LicenseeCurrencyCriteria']/div[1]";
    public string lblCurrency = "//*[@id='LicenseeCurrencyCriteria']/div[2]";
    public string lblConvertTo = "//*[@id='lblIsConvert']";
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
    public string frmMain = "//*[@id='page-content']";
    public string tblDataContent = "//*[@id='data-content']";
    
    public string btnFullTimeDetail = "//*[@id='data-content']/table/tbody/tr[4]/td[2]/a";
    public string btnHalfTimeDetail = "//*[@id='data-content']/table/tbody/tr[5]/td[2]/a";
    public string popForecast = "//*[@id='data-content']";
    public string lnk10Score = "//*[@id='data-content']/table[2]/tbody/tr[1]/td[2]/a[5]";
    public string lnkBetList = "//*[@id='data-content']/table[2]/tbody/tr[4]/td/a[1]";
    public string lnkViewOverUnder = "//*[@id='data-content']/table[2]/tbody/tr[4]/td/a[2]";
    public string lnkViewHandicap = "//*[@id='data-content']/table[2]/tbody/tr[3]/td/a";
    public string btnCloseForecastpopup = "//div[@class='IBCWndCloseButton']";
}

