using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWA_UICurrencyWinLoss
	{
		public string fraCurrencyWinLossPage = "//*[@id='winlossFilter']";
		public string ddlCurrency = "//*[@id='ddlCurrency']";
		public string tblReportResult = "//*[@id='currencyWinLossGrid']";
		
		//date selection
		public string ddlDateRange = "//*[@id='Date']";
		public string txtFromDate = "//*[@id='FromDate']";
		public string btnFromDate = "//*[@id='fd-but-FromDate']";
		public string txtToDate = "//*[@id='ToDate']";
		public string btnToDate = "//*[@id='fd-but-ToDate']";
		
		//product selection
		public string chkAllProduct = "//*[@id='ALLProducts']";
		public string chkSportsBook = "//*[@id='ProductOptions0']";
		public string chkRacing = "//*[@id='ProductOptions1']";
		public string chkNumberGame = "//*[@id='ProductOptions2']";
		public string chkBA = "//*[@id='ProductOptions3']";
		public string chkLC = "//*[@id='ProductOptions4']";
		public string chkVS = "//*[@id='ProductOptions5']";
		public string msgRequiredProduct = "//div[contains(text(),'Please choose at least ONE Product!')]";
		
		//other selections
		public string ddlSelectSportType = "//*[@id='ddlSport']";
		public string ddlSelectBetType = "//*[@id='ddlBetType']";
		public string rdoReportbyAll = "//*[@id='rdoReportByAll']";
		public string rdoLiveReport = "//*[@id='rdoReportByLive']";
		public string rdoNonLiveReport = "//*[@id='rdoReportByNonLive']";
		public string rdoExcludeYes = "//*[@id='ddlTestDataYes']";
		public string rdoExcludeNo = "//*[@id='ddlTestDataNo']";
		public string rdoMYRconvert = "//*[@id='rdoMYR']";
		public string rdoEURconvert = "//*[@id='rdoEUR']";
		public string rdoUSDconvert = "//*[@id='rdoUSD']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnReset = "//*[@id='btnReset']";
		public string btnExportExcel = "//*[@id='btnExportExcel']";
		
		//select licensee to view report
		public string chkSelectAllLicensees = "//*[@id='chkLicAll']";
		public string msgRequiredLicensee = "//div[contains(text(),'Please select a Licensee!')]";
		public string chkAllBCHReseller = "//*[@id='Reseller1']";
		public string chk12Bet = "//*[@id='chkRes1Lic1']";
		public string chkalog = "//*[@id='chkRes1Lic4']";
		public string chkasiabet88 = "//*[@id='chkRes1Lic2']";
		public string chkBodog = "//*[@id='chkRes1Lic14']";
		public string chkTLC = "//*[@id='chkRes1Lic6']";
		public string chkAllBoping = "//*[@id='Reseller7']";
		public string chkTycoon = "//*[@id='chkRes7Lic17']";
		public string chkAllCozni = "//*[@id='Reseller5']";
		public string chkHAIFA = "//*[@id='chkRes5Lic12']";
		public string chkAllFDL = "//*[@id='chkReseller4']";
		public string chkIBC = "//*[@id='chkRes4Lic13']";
		public string chkAllLDL = "//*[@id='Reseller2']";
		public string chkDELA = "//*[@id='chkRes2Lic7']";
		public string chkmansion88 = "//*[@id='chkRes2Lic3']";
		public string chkMayFair = "//*[@id='chkRes2Lic9']";
		public string chkSunGame = "//*[@id='chkRes2Lic8']";
		public string chkZzun88 = "//*[@id='chkRes2Lic10']";
		//public string chkAllPIH = "//*[@id='chkReseller8']";
		public string chk18bb = "//*[@id='chkRes8Lic18']";
		public string chkAllStarlit = "//*[@id='chkReseller3']";
		public string chk12betStarlit = "//*[@id='chkRes3Lic1']";
		public string chkalogStarlit = "//*[@id='chkRes3Lic4']";
		public string chkasiabet88Starlit = "//*[@id='chkRes3Lic2']";
		public string chkbodogStarlit = "//*[@id='chkRes3Lic14']";
		public string chkDELAStarlit = "//*[@id='chkRes3Lic7']";
		public string chkTLCStarlit = "//*[@id='chkRes3Lic6']";
		public string chkZzun88Starlit = "//*[@id='chkRes3Lic10']";
		public string chkMacaubet = "//*[@id='chkRes7Lic19']";
		public string chkMayFairStarlit = "//*[@id='chkRes3Lic9']";
		
	}
}
