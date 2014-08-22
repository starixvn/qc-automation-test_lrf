using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UICustomerInformation_CustomerList
{
    public string lblTitle = "//div[text() = 'Customer List']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblUsername = "//div[text()='Username:']";
    public string lblBA = "//div[text()='BA:']";
    public string lblStatus = "//div[text()='Status:']";
    public string lblSpecialLevel = "//div[text()='Special Level:']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='DdlCurrencyType']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string btnSubmit = "//*[@id='SubmitButtonComm']";
    public string txtUsername = "//*[@id='txtUsername' and @class[contains(.,'text_f')]]";
    public string ddlStatus = "//*[@id='CustStatusOption']";
    public string ddlSpecialLevel = "//*[@id='special-level-list-search']";
    public string tblSearchResult = "//*[@id='tbl-container']";
    public string ddlBA = "//*[@id='BAFilterOption']";
    public string tblReportContent = "//*[@id='ContentMainContent']";
    public string frmMain = "//*[@id='BodyContent']";
    public string lnkEditBetSetting = "//*[@id='bet-setting-link']";
    public string lnkEditStatus = "//span[@title='Status']";
    public string btnOnOffBA = "//*[@id='aBA_1556883']";
    public string ddlEditSpecialLevel = "//*[@id='ddlSpecialLevel1556883']";
    public string lnkViewBetList = "//*[@id='bet-list-link']";
    public string lnkViewStatement = "//*[@id='statement-link']";
    public string lnkViewLogInfo = "//*[@id='login-info-link']";
    public string btnExitBetSetting = "//span[contains(text(),'close')]";
    public string btnCancelChangeStatus = "//*[@id='popup-close']";
    public string btnExitBetList = "//span[contains(text(),'close')]";
    public string popBetSetting = "//*[@id='tblBetSetting']";
    public string popChangeStatus = "//*[@id='update-cust-status-popup']";
    public string popBetList = "//*[@id='page-content']";
    public string popStatement = "//*[@id='page-content']";
    public string tblNoinfo = "//*[@id='NoInfo']";
    public string popLogInfo = "//div[@class='login_info_container']";
    public string btnExitStatement = "//span[contains(text(),'close')]";
    public string btnExitLogInfo = "//span[contains(text(),'close')]";
    
    
    

//    public string colNumberOrder = "//tr[@class='RptHeader']/td[text()='#']";
//    public string colExternalID = "//tr[@class='RptHeader']/td[text()='External ID']";
//    public string colSystemID = "//tr[@class='RptHeader']/td[text()='System ID']";
//    public string colAvailableFunds = "//tr[@class='RptHeader']/td[text()='Available Funds']";
//    public string colOutstanding = "//tr[@class='RptHeader']/td[text()='Pending Funds']";
//    public string colBetSetting = "//tr[@class='RptHeader']/td[text()='Bet Setting']";
//    public string colStatus = "//tr[@class='RptHeader']/td[text()='Status']";
//    public string colBAStatus = "//tr[@class='RptHeader']/td[text()='BA Status']";
//    public string colBetList = "//tr[@class='RptHeader']/td[text()='Bet List']";
//    public string colStatement = "//tr[@class='RptHeader']/td[text()='Statement']";
//    public string colLoginInfo = "//tr[@class='RptHeader']/td[text()='Login Info']";
}

