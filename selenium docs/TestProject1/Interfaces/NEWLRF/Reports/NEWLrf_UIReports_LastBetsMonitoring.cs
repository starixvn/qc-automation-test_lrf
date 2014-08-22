using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_LastBetsMonitoring
{
    public string lblTitle = "//div[contains(text(),'Last Bets Monitoring')]";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//*[@id='filter_licensee_bettype']/li[1]";
    public string lblCurrency = "//*[@id='criteria-container']/table/tbody/tr/td[1]";
    public string ddlType = "//*[@id='ddlLicenseeType']";
    public string lnkAllBetTypes = "//li/a[contains(text(),'All Bet Types')]";
    public string lnkOverUnder = "//li/a[contains(text(),'Over / Under')]";
    public string lnkOthers = "//li/a[contains(text(),'Others')]";
    public string lnkHandicap = "//li/a[contains(text(),'Handicap')]";
    public string chkAllCurrency = "//span/input[@data-key='ALL']";
    public string chkMYRCurrency = "//span/input[@data-key='MYR']";
    public string chkUSDCurrency = "//span/input[@data-key='USD']";
    public string chkTHBCurrency = "//span/input[@data-key='THB']";
    public string chkEURCurrency = "//span/input[@data-key='EUR']";
    public string chkAUDCurrency = "//span/input[@data-key='AUD']";
    public string chkGBPCurrency = "//span/input[@data-key='GBP']";
    public string chkCNYCurrency = "//span/input[@data-key='CNY']";
    public string chkIDRCurrency = "//span/input[@data-key='IDR']";
    public string chkUUSCurrency = "//span/input[@data-key='UUS']";
    public string chkJPYCurrency = "//span/input[@data-key='JPY']";
    public string chkCHFCurrency = "//span/input[@data-key='CHF']";
    public string chkKRWCurrency = "//span/input[@data-key='KRW']";
    public string chkINHCurrency = "//span/input[@data-key='INH']";
    public string chkINRCurrency = "//span/input[@data-key='INR']";
    public string chkAllLevel = "//*[@id='SpecialLevelAll']";
    public string chkNoneLevel = "//span/input[@data-key='None']";
    public string chkLevel1 = "//span/input[@data-key='Level 1']";
    public string chkLevel2 = "//span/input[@data-key='Level 2']";
    public string chkLevel3 = "//span/input[@data-key='Level 3']";
    public string chkLevel4 = "//span/input[@data-key='Level 4']";
    public string chkLevel5 = "//span/input[@data-key='Level 5']";
    public string chkLevel6 = "//span/input[@data-key='Level 6']";
    public string chkLevel7 = "//span/input[@data-key='Level 7']";
	public string chkLevel8 = "//span/input[@data-key='Level 8']";
	public string chkLevel9 = "//span/input[@data-key='Level 9']";
    public string chkLevel10 = "//span/input[@data-key='Level 10']";
    
    public string btn10 = "//span/input[@value='10']";
    public string btn20 = "//span/input[@value='20']";
    public string btn30 = "//span/input[@value='30']";
    
    public string tblSearchResult = "//*[@id='hor-minimalist-a']";
    public string icoLoading = "//*[@id='div_loading']/img[@style='display: inline;']";
    
}

