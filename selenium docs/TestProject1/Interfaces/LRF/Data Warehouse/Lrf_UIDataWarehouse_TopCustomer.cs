using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIDataWarehouse_TopCustomer
{
    public string lblTitle = "//div[contains(text(),'Top Customer')]";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string ddlLicensee = "//*[@id='LicenseeList']";
    public string ddlCurrency = "//*[@id='DdlCurrencyType']";
    public string ddlInactiveSinceLast = "//*[@id='SelectReportBy']";
    public string ddlSportType = "//*[@id='SelectSport']";
    public string chkConvertTo = "//*[@id='IsConvertToEUR']";
    public string rdoBestWinLoss = "//*[@id='RadioBestWinLoss']";
    public string rdoWorstWinLoss = "//*[@id='RadioWorstWinLoss']";

    public string btnSubmit = "//*[@id='SubmitButton']";
    public string txtFromdate = "//*[@id='FromDate']";
    public string txtTodate = "//*[@id='ToDate']";
    public string txtBetCountMin = "//*[@id='BetCountMin']";
    public string txtMinTotalCustWinLoss = "//*[@id='WinLossTotalMin']";
    public string txtSystemID = "//*[@id='ExternalId']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string frmBody = "//*[@id='BodyContent']";
    public string tblReportContent = "//*[@id='TableContent']";

//    public string colNumberOrder = "//tr[@class='report-header']/td[contains(text(),'#')]";
//    public string colCustomer = "//tr[@class='report-header']/td[2]";
//    public string colCurrency = "//tr[@class='report-header']/td[3]";
//    public string colLicenseeFee = "//tr[@class='report-header']/td[text()='Licensee Fee']";
//    public string colLicenseeWinLoss = "//tr[@class='report-header']/td[7]";
//    public string colCustWinLoss = "//tr[@class='report-header']/td[6]";
//    public string colTurnover = "//tr[@class='report-header']/td[4]";
//    public string colBetCount = "//tr[@class='report-header']/td[5]";
//    public string colLastActivityDate = "//tr[@class='report-header']/td[8]";
    
}

