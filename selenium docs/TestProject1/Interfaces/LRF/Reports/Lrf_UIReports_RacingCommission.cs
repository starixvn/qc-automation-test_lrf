using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_RacingCommission
{
    public string lblTitle = "//div[text() = 'Racing Commission']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string lblFrom = "//span[text()='From:']";
    public string lblTo = "//span[text()='To:']";
    public string ddlType = "//*[@id='LicenseeType']";
    public string ddlCurrency = "//*[@id='CurrencyType']";
    public string chkConvertTo = "//*[@id='IsConvert']";
    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='submit-button']";
    public string btnToday = "//*[@id='dToday']";
    public string btnYesterday = "//*[@id='dYesterday']";
    public string txtFrom = "//*[@id='fdate']";
    public string btnSelectFrom = "//*[@id='fdate_trigger']";
    public string txtTo = "//*[@id='tdate']";
    public string btnSelectTo = "//*[@id='tdate_trigger']";
    public string tblReportContent = "//*[@id='content-container']";
    public string lnkOpenBetList = "//*[@id='tbl-rpt']/tbody/tr[4]//span[@class='downline-link']";
    public string icoBack = "//*[@id='page-content']/div[2]/div";
    public string tblBetList = "//*[@id='hor-minimalist-a']";
}

