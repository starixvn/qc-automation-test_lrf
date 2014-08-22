using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWA_UILicenseeWinLoss
	{
		//Summary page
		public string fraLicenseeWinLossPage = "//*[@id='winlossFilter']";
		public string lnkDetails = "//a[contains(text(),'Details')]";
		public string lnkSummary ="//a[contains(text(),'Summary')]";
		public string tblReportResult = "//*[@id='winlossGrid']";
		public string ddlDateRange = "//*[@id='Date']";
		public string rdoExcludeYes = "//*[@id='Yes']";
		public string rdoExcludeNo = "//*[@id='No']";
		public string rdoReportDaily = "//*[@id='group-by-daily']";
		public string rdoReportMonthly = "//*[@id='group-by-monthly']";
		public string ddlCurrency = "//*[@id='ddlCurrency']";
		public string chkConverCurrency = "//*[@id='IsConvert']";
		public string rdoMYRconvert = "//*[@id='rdoMYR']";
		public string rdoEURconvert = "//*[@id='rdoEUR']";
		public string rdoUSDconvert = "//*[@id='rdoUSD']";
		public string txtFromDate = "//*[@id='FromDate']";
		public string btnFromDate = "//*[@id='fd-but-FromDate']";
		public string txtToDate = "//*[@id='ToDate']";
		public string btnToDate = "//*[@id='fd-but-ToDate']";
		public string rdoNormalType = "//*[@id='type-normal']";
		public string rdoNoDrawType = "//*[@id='type-nodraw']";
		public string rdoNoDraw4Turnover = "//*[@id='type-nodraw-for-turnover-only']";
		public string chkAllProduct = "//*[@id='Sport_0']";
		public string chkSportsbook = "//*[@id='Sport_1']";
		public string chkRacing = "//*[@id='Sport_2']";
		public string chkNumberGame = "//*[@id='Sport_3']";
		public string chkBA = "//*[@id='Sport_4']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnReset = "//*[@id='btnReset']";
		public string btnExportExcel = "//*[@id='btnExportExcel']";
		
		//select licensee to view report
		public string chkSelectAllLicensees = "//*[@id='chkLicAll']";
		public string chkAllBCHReseller = "//*[@id='chkReseller1']";
		public string chk12Bet = "//*[@id='chkRes1Lic1']";
		public string chkalog = "//*[@id='chkRes1Lic4']";
		public string chkasiabet88 = "//*[@id='chkRes1Lic2']";
		public string chkBodog = "//*[@id='chkRes1Lic14']";
		public string chkTLC = "//*[@id='chkRes1Lic6']";
		public string chkAllBoping = "//*[@id='chkReseller7']";
		public string chkSG8 = "//*[@id='chkRes7Lic16']";
		public string chkTycoon = "//*[@id='chkRes7Lic17']";
		public string chkAllCozni = "//*[@id='chkReseller5']";
		public string chkHAIFA = "//*[@id='chkRes5Lic12']";
		public string chkAllFDL = "//*[@id='chkReseller4']";
		public string chkIBC = "//*[@id='chkRes4Lic13']";
		public string chkAllLDL = "//*[@id='chkReseller2']";
		public string chkDELA = "//*[@id='chkRes2Lic7']";
		public string chkmansion88 = "//*[@id='chkRes2Lic3']";
		public string chkMayFair = "//*[@id='chkRes2Lic9']";
		public string chkSunGame = "//*[@id='chkRes2Lic8']";
		public string chkZzun88 = "//*[@id='chkRes2Lic10']";
		public string chkAllPIH = "//*[@id='chkReseller8']";
		public string chk18bb = "//*[@id='chkRes8Lic18']";
		public string chkAllStarlit = "//*[@id='chkReseller3']";
		public string chk12betStarlit = "//*[@id='chkRes3Lic1']";
		public string chkalogStarlit = "//*[@id='chkRes3Lic4']";
		public string chkasiabet88Starlit = "//*[@id='chkRes3Lic2']";
		public string chkbodogStarlit = "//*[@id='chkRes3Lic14']";
		public string chkDELAStarlit = "//*[@id='chkRes3Lic7']";
		public string chkTLCStarlit = "//*[@id='chkRes3Lic6']";
		public string chkZzun88Starlit = "//*[@id='chkRes3Lic10']";
		
		
		//details page
		public string ddlLicensee = "//*[@id='LicenseeId']";
		public string msgRequiredLicensee = "//div[contains(text(),'Please select a Licensee!')]";
		public string msgRequiredProduct = "//div[contains(text(),'Please choose at least ONE Product!')]";
	}
}
