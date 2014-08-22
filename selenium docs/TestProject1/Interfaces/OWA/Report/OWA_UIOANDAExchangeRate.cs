using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWA_UIOANDAExchangeRate
	{
		public string fraOANDAExchangeRatePage = "//*[@id='winlossFilter']";
		public string txtFromDate = "//*[@id='FromDate']";
		public string btnFromDate = "//*[@id='fd-but-FromDate']";
		public string txtToDate = "//*[@id='ToDate']";
		public string btnToDate = "//*[@id='fd-but-ToDate']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnExportExcel = "//*[@id='btnExportExcel']";
		public string tblReportResult = "//*[@id='exchangeRateGrid']";
	}
}
