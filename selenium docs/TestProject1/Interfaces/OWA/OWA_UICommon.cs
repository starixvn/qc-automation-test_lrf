using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests
{
    public class OWA_UICommon
    {
        //currency list
		
		public string optAllcur = "//option[contains(text(),'All')]";
		public string optAUDcur = "//option[contains(text(),'AUD')]";
		public string optBNDcur = "//option[contains(text(),'BND')]";
		public string optCHFcur = "//option[contains(text(),'CHF')]";
		public string optCNYcur = "//option[contains(text(),'CNY')]";
		public string optCZKcur = "//option[contains(text(),'CZK')]";
		public string optDKKcur = "//option[contains(text(),'DKK')]";
		public string optEURcur = "//option[contains(text(),'EUR')]";
		public string optGBPcur = "//option[contains(text(),'GBP')]";
		public string optHKDcur = "//option[contains(text(),'HKD')]";
		public string optIDRcur = "//option[contains(text(),'IDR')]";
		public string optINHcur = "//option[contains(text(),'INH')]";
		public string optINRcur = "//option[contains(text(),'INR')]";
		public string optJPYcur = "//option[contains(text(),'JPY')]";
		public string optKRWcur = "//option[contains(text(),'KRW')]";
		public string optMXNcur = "//option[contains(text(),'MXN')]";
		public string optMYRcur = "//option[contains(text(),'MYR')]";
		public string optNOKcur = "//option[contains(text(),'NOK')]";
		public string optPLNcur = "//option[contains(text(),'PLN')]";
		public string optRONcur = "//option[contains(text(),'RON')]";
		public string optRUBcur = "//option[contains(text(),'RUB')]";
		public string optSEKcur = "//option[contains(text(),'SEK')]";
		public string optSGDcur = "//option[contains(text(),'SGD')]";
		public string optTHBcur = "//option[contains(text(),'THB')]";
		public string optTWDcur = "//option[contains(text(),'TWD')]";
		public string optUSDcur = "//option[contains(text(),'USD')]";
		public string optUUScur = "//option[contains(text(),'UUS')]";
		
		
		//select date from "drop down list"
		public string optDateRange = "//option[contains(text(),'Date Range')]";
		public string optToday = "//option[contains(text(),'Today')]";
		public string optYesterday = "//option[contains(text(),'Yesterday')]";
		public string optCurrentWeek = "//option[contains(text(),'Current Week')]";
		public string optLastWeek = "//option[contains(text(),'Last Week')]";
		public string optCurrentMonth = "//option[contains(text(),'Current Month')]";
		public string optLastMonth = "//option[contains(text(),'Last Month')]";
		public string optSinceLastMonth = "//option[contains(text(),'Since Last Month')]";
		
		
		//select licensee from "drop down list"
		public string optBHC12Bet = "//optgroup[1]/option[contains(text(),'12Bet')]";
		public string optBHCalog = "//optgroup[1]/option[contains(text(),'alog')]";
		public string optBHCasiabet88 = "//optgroup[1]/option[contains(text(),'asiabet88')]";
		public string optBHCBodog = "//optgroup[1]/option[contains(text(),'Bodog')]";
		public string optBHCIbobet = "//optgroup[1]/option[contains(text(),'Ibobet')]";
		public string optBHCMacaubet = "//optgroup[1]/option[contains(text(),'Macaubet')]";
		public string optBHCTLC = "//optgroup[1]/option[contains(text(),'TLC')]";
		
		public string optBopingTycoon = "//optgroup[2]/option[contains(text(),'Tycoon')]";
		public string optBopingVCasia = "//optgroup[2]/option[contains(text(),'VCasia')]";
		
		public string optCozniHAIFA = "//optgroup[3]/option[contains(text(),'HAIFA')]";
		
		public string optLDLDELA = "//optgroup[4]/option[contains(text(),'DELA')]";
		public string optLDLmansion88 = "//optgroup[4]/option[contains(text(),'mansion88')]";
		public string optLDLMayFair = "//optgroup[4]/option[contains(text(),'MayFair')]";
		public string optLDLSunGame = "//optgroup[4]/option[contains(text(),'SunGame')]";
		public string optLDLZzun88 = "//optgroup[4]/option[contains(text(),'Zzun88')]";
		
		public string optStarlit12Bet = "//optgroup[5]/option[contains(text(),'12Bet')]";
		public string optStarlitalog = "//optgroup[5]/option[contains(text(),'alog')]";
		public string optStarlitasiabet88 = "//optgroup[5]/option[contains(text(),'asiabet88')]";
		public string optStarlitBodog = "//optgroup[5]/option[contains(text(),'Bodog')]";
		public string optStarlitDELA = "//optgroup[5]/option[contains(text(),'DELA')]";
		public string optStarlitTLC = "//optgroup[5]/option[contains(text(),'TLC')]";
		public string optStarlitZzun88 = "//optgroup[5]/option[contains(text(),'Zzun88')]";
		
		//product selection
		public string chkAllProduct = "//*[@id='chkProductAll']";
		public string chkSportsBook = "//*[@id='chkProductSB']";
		public string chkRacing = "//*[@id='chkProductRB']";
		public string chkNumberGame = "//*[@id='chkProductNG']";
		public string chkBA = "//*[@id='chkProductBA']";
		
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
		public string rdoNormalType = "//*[@id='rdoDrawFilterNormal']";
		public string rdoNoDrawType = "//*[@id='rdoDrawFilterNodraw']";
		public string rdoNoDraw4Turnover = "//*[@id='rdoDrawFilterNodrawTurnoverOnly']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnReset = "//*[@id='btnReset']";
		public string btnExportExcel = "//*[@id='btnExportExcel']";
		
		//select licensee to view report
		public string chkSelectAllLicensees = "//*[@id='chkLicAll']";
		public string msgRequiredLicensee = "//div[contains(text(),'Please select a Licensee!')]";
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
//		public string chkAllStarlit = "//*[@id='chkReseller3']";
//		public string chk12betStarlit = "//*[@id='chkRes3Lic1']";
//		public string chkalogStarlit = "//*[@id='chkRes3Lic4']";
//		public string chkasiabet88Starlit = "//*[@id='chkRes3Lic2']";
//		public string chkbodogStarlit = "//*[@id='chkRes3Lic14']";
//		public string chkDELAStarlit = "//*[@id='chkRes3Lic7']";
//		public string chkTLCStarlit = "//*[@id='chkRes3Lic6']";
//		public string chkZzun88Starlit = "//*[@id='chkRes3Lic10']";
		public string chkIbobet = "//*[@id='chkRes7Lic20']";
		public string chkMacaubet = "//*[@id='chkRes7Lic19']";
		public string chkITCBet = "//*[@id='chkRes7Lic24']";
//		public string chkMayFairStarlit = "//*[@id='chkRes3Lic9']";
		
    }
}

