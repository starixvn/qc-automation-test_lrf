using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_DailyRacingWinLoss
{
	public string ddlType = "//*[@id='LicenseeType']";
	public string ddlCurrency = "//*[@id='CurrencyType']";
	public string chkConvertTo = "//*[@id='IsConvert']";
	public string txtDate = "//*[@id='fdate']";
	public string btnSelectDate = "//*[@id='fdate_trigger']";
	public string btnSubmit = "//*[@id='submit-button']";
	public string icoExporttoExcel = "//*[@id='exporttoexcel']";
	public string frmMain = "//*[@id='criteria-container']";
	public string tblReportContent = "//*[@id='tbl-rpt2']";
	public string lnkOpenBetList = "//*[@id='tbl-rpt2']/tbody/tr[2]/td[1]/span";
	public string icoBack = "//div[@class='history-link']";
	public string tblBetList = "//*[@id='hor-minimalist-a']";
	
}
