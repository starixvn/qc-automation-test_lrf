using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWASimplified_UIWinLossReport
	{
		public string frmMain = "//*[@id='winlossFilter']";
		public string tblReportResult = "//*[@id='winlossGrid']";
		public string ddlLicensee = "//*[@id='ddlLicensee']";
		public string ddlCurrency = "//*[@id='ddlCurrency']";
		public string ddlDateRange = "//*[@id='Date']";
		public string ddlFromDate = "//*[@id='FromDate']";
		public string ddlToDate = "//*[@id='ToDate']";
		public string rdoDaily = "//*[@id='group-by-daily']";
		public string rdoMonthly = "//*[@id='group-by-monthly']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnReset = "//*[@id='btnReset']";
		public string icoExportExcel = "//*[@id='btnExportExcel']";
		public string msgRequiredMessage = "//*[@id='msgbox1']/div";
		public string btnBack = "//a[@class='btnBack']";
		public string rdoNormal = "//*[@id='type-normal']";
		public string rdoNoDraw = "//*[@id='type-nodraw']";
		public string rdoNoDraw4Turnover = "//*[@id='type-nodraw-for-turnover-only']";
		public string lnkCurrencyDrillDown = "//tr[2]/td[3]/a";
		public string lnkUnderline = "//tr[2]/td[2]/a";
		public string lnkOpenBetlist = "//tr[2]/td[2]/a";
		public string popBetlist = "//*[@id='dialog']/table";
		public string btnCloseBetlist= "//span[@class='ui-icon ui-icon-closethick']";
		
		
	}
}
