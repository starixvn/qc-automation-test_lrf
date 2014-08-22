using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWA_UIRacing
	{
		public string fraRacingPage = "//*[@id='winlossFilter']";
		public string txtSelectDate = "//*[@id='QueryDate']";
		public string btnSelectDate = "//*[@id='fd-but-QueryDate']";
		public string ddlSelectLicensee = "//*[@id='LicenseeName']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnExportExcel = "//*[@id='btnExportExcel']";
		public string tblReportResult = "//*[@id='racingGrid']";
		public string msgRequiredLicensee = "//*[@id='msg']";
		public string lnkBetlist = "//tr[2]/td[1]/a/b";
		public string popBetlist = "//*[@id='dialog']";
		public string btnClose = "//a/span[text()='close']";
	}
}
