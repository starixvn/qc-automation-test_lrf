using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWASimplified_UIVirtualSportsReport
	{
		public string fraMain = "//*[@id='winlossFilter']";
		public string tblReportResult = "//*[@id='scrollGridWrp']";
		
		//date selection
		public string btnPreviousMonth = "//*[@id='monPickrId']/a[1]/span";
		public string btnNextMonth = "//*[@id='monPickrId']/a[2]/span";
		public string ddlFromDay = "//*[@id='fromDay']";
		public string ddlToDay = "//*[@id='toDay']";
		
		//remain controls
		public string rdoDaily = "//*[@id='rdoGroupByDaily']";
		public string rdoMonthly = "//*[@id='rdoGroupByMonthly']";
		public string btnSubmit = "//*[@id='Submit']";
		public string btnReset = "//*[@id='btnReset']";
		public string btnExportExcel = "//*[@id='btnExportExcel']";
		public string lnkDrillDown = "//*[@id='totalTransByDateGrid']/tbody/tr[1]/td[1]/a";
		public string msgRequiredMessage = "//*[@id='msgbox1']";
		public string btnCloseRequiredMessage = "//a[@class='msgbox-close']";
		public string btnBack = "//a[@class='btnBack']";
		
		//select licensee to view report
		public string chkSelectAllResellers = "//*[@id='lichekrAllChk']";
		public string chkBoping = "//*[@id='licheckrLicPa7']";
		public string chkCozni = "//*[@id='licheckrLicPa5']";
		public string chkFDL = "//*[@id='licheckrLicPa4']";
		public string chkPIH = "//*[@id='licheckrLicPa8']";
		public string chkStarlit = "//*[@id='licheckrLicPa3']";
		public string chkBCH = "//*[@id='licheckrLicPa1']";
		public string chkBCH12Bet = "//input[@id='licheckrLic-1-1']";
		public string chkBCHalog = "//*[@id='licheckrLic-1-4']";
		public string chkasiabet88 = "//*[@id='licheckrLic-1-2']";
		public string chkBCHBodog = "//*[@id='licheckrLic-1-14']";
		public string chkBCHTLC = "//*[@id='licheckrLic-1-6']";
		public string chkLDL = "//*[@id='licheckrLicPa2']";
		public string chkLDLDELA = "//*[@id='licheckrLic-2-7']";
		public string chkLDLmansion88 = "//*[@id='licheckrLic-2-3']";
		public string chkLDLMayFair = "//*[@id='licheckrLic-2-9']";
		public string chkLDLSunGame = "//*[@id='licheckrLic-2-8']";
		public string chkZzun88 = "//*[@id='licheckrLic-2-10']";
		
		//sport options
		public string chkAllSports = "//*[@id='sportchekrAllChk']";
		public string chkVirtualCycling = "//*[@id='sportcheckrsportPa185']";
		public string chkVirtualF1 = "//*[@id='sportcheckrsportPa184']";
		public string chkVirtualGreyhound = "//*[@id='sportcheckrsportPa182']";
		public string chkVirtualHorsesRacing = "//*[@id='sportcheckrsportPa181']";
		public string chkVirtualSoccer = "//*[@id='sportcheckrsportPa180']";
		public string chkVirtualSpeedWay = "//*[@id='sportcheckrsportPa183']";
		public string chkVirtualTennis = "//*[@id='sportcheckrsportPa186']";
		
			
		
	}
}
