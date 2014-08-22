using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWA_UITotalTransaction
	{
		public string fraTotalTransactionPage = "//*[@id='winlossFilter']";
		public string tblReportResult = "//*[@id='totalTransByDateGrid']";
		
		//date selection
		public string btnPreviousMonth = "//*[@id='btnPrevMonth']";
		public string btnNextMonth = "//*[@id='btnNextMonth']";
		public string ddlFromDay = "//*[@id='ddlFromDay']";
		public string ddlToDay = "//*[@id='ddlToDay']";
		
		//product selection
			
		public string chkAllProduct = "ALLProducts";
   	 	public string chkSBProduct = "//*[@data='SB' and @type='checkbox']";
    	public string chkRacingProduct = "//*[@data='RB' and @type='checkbox']";
   		public string chkNumberGameProduct = "//*[@data='NG' and @type='checkbox']";
    	public string chkBAProduct = "//*[@data='BA' and @type='checkbox']";
    	public string chkVSProduct = "//*[@data='VS' and @type='checkbox']";
    	public string chkLCProduct = "//*[@data='LC' and @type='checkbox']";
			
		//remain controls
		public string rdoDaily = "//*[@id='rdoGroupByDaily']";
		public string rdoMonthly = "//*[@id='rdoGroupByMonthly']";
		public string rdoReportbyAll = "//*[@id='rdoReportByAll']";
		public string rdoLiveReport = "//*[@id='rdoReportByLive']";
		public string rdoNonLiveReport = "//*[@id='rdoReportByNonLive']";
		public string ddlSportType = "//*[@id='ddlSport']";
		public string ddlBetType = "//*[@id='ddlBetType']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnReset = "//*[@id='btnReset']";
		public string btnExportExcel = "//*[@id='btnExportExcel']";
		public string lnkDrillDown = "//*[@id='totalTransByDateGrid']/tbody/tr[1]/td[1]/a";
		public string msgRequiredMessage = "//*[@id='msg']";
		
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
		
		
		
		
	}
}
