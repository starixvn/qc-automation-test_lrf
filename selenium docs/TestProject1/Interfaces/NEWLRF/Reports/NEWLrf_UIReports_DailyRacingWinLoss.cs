using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_DailyRacingWinLoss
{
	public string ddlType = "//*[@id='LicenseeType']";
	public string ddlCurrency = "//*[@id='CurrencyId']";
	public string chkConvertTo = "//*[@id='IsConvert']";
	public string txtDate = "//*[@id='Date']";
	//public string btnSelectDate = "//*[@id='fdate_trigger']";
	public string btnSubmit = "//*[@id='SubmitButton']";
	public string icoExporttoExcel = "//*[@id='ExportToExcel']";
	public string icoExportBetlist = "//*[@id='exporttoexcel']";
	public string frmMain = "//*[@id='ReportForm']";
	public string tblReportContent = "//*[@id='data-content']";
	public string lnkOpenBetList = "//*[@id='data-content']/div[2]/div[1]/div/span";
	public string icoBack = "//div[@class='history-link']";
	public string tblBetList = "//*[@id='hor-minimalist-a']";
	
}
