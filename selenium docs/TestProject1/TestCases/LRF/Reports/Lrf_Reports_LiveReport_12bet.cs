using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;
using NUnit.Core;
using System.IO;
using System.ComponentModel;
using System.Xml;


namespace SeleniumTests.Lrf.Reports
{
    [TestFixture]
    public class Lrf_Reports_LiveReport_12bet : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Lrf_UILeftMenu Lrf_UILeftMenu = new Lrf_UILeftMenu();
        public Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
        public Lrf_UIReports_LiveReport Lrf_UIReports_LiveReport = new Lrf_UIReports_LiveReport();
        public Lrf_UIMain Lrf_UIMain = new Lrf_UIMain();
        public Lrf_Initialize Lrf_Initialize = new Lrf_Initialize();
        //**********************************************************************************************
        //private StringBuilder verificationErrors;

        public string browser;
        public string url;
        public string sevendaybefore = System.Convert.ToString(System.DateTime.Now);
        public string server;
        public string strAdminUsername;
        public string strAdminPassword;
        public string strCaptcha;
        public string btnLicensee;
        public int port;
        public int timeoutSecond;
        private string strTmpLinkReport = "";
        public string strLinkReportFile { get; set; }
        public int numOfPassed { get; set; }
        public int numOfFailed { get; set; }
        public int numOfError { get; set; }

        //*******YOU HAVE TO EDIT THE PATH AND NAME OF DATA FILE WHICH YOU LOAD DATA FROM (ex: "Handicap-OverUnder-Live.xml", Path: "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string DataFileName = "Lrf_Reports_LicenseeWinLoss_01.xml";
        public string strPathDataFile = "Data\\LRF\\Reports\\Live Report\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "LRF\\Reports\\Live Report\\";
        //******************************************************************************

        public DateTime dateStartTime { get; set; }
        public DateTime dateEndTime { get; set; }
        private string strReportFileName = "";

        public String GetClassName()
        {
            string strClassName = TypeDescriptor.GetClassName(this, true);
            int intIndexDot = strClassName.IndexOf(".");
            int intLength = strClassName.Length - (intIndexDot + 1);
            string tmpStrClassName = strClassName.Substring(intIndexDot + 1, intLength);
            return tmpStrClassName;
        }

        [SetUp]
        public void SetupTest()
        {

            dateStartTime = DateTime.Now.ToLocalTime();

            browser = Lrf_Initialize.browser;
            port = Lrf_Initialize.port;
            url = Lrf_Initialize.url;
            server = Lrf_Initialize.server;
            strAdminPassword = Lrf_Initialize.strAdminPassword;
            strAdminUsername = Lrf_Initialize.strAdminUserName;
            strCaptcha = Lrf_Initialize.strCaptcha;
            btnLicensee = Lrf_Initialize.btnLicensee;
            selenium = new DefaultSelenium(server, port, browser, url);
            selenium.Start();

            timeoutSecond = fCommon.timeoutSecond;

            strPathDataFile = fCommon.strRootFolder.Replace("/", "\\") + strPathDataFile;


            //verificationErrors = new StringBuilder();

            string CookiesDir = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            string[] cookies = Directory.GetFiles(CookiesDir, "*.txt");
            foreach (string cookie in cookies)
            {
                Routines.DeleteCacheIndexDat(cookie, false);
            }

            /***Create Folder to save Report**/
            strTmpLinkReport = strPathTestCase; strPathTestCase = fCommon.strPathFolderOfSummaryReportFile + strPathTestCase;
            Directory.CreateDirectory(strPathTestCase);
            //Create folder "Log" in the Root folder to save Report temp.
            Directory.CreateDirectory(fCommon.strCommonPathReportFile);
            /***********************************/

            strReportFileName = GetClassName() + "_" + dateStartTime.ToString().Replace("/", "-").ToString().Replace(":", "-").ToString() + ".html";
            //strPathTestCase + strReportFileName
            CommonFunc.writeHeaderReport(fCommon.strCommonPathReportFile + fCommon.strCommonReportFileName, GetClassName(), dateStartTime.ToString());
            selenium.Open(url);
            selenium.WindowMaximize();
            selenium.WindowFocus();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                dateEndTime = DateTime.Now.ToLocalTime();
                strDuration = CommonFunc.getDurationTime(dateStartTime, dateEndTime);
                CommonFunc.writeFinishReport(fCommon.strCommonPathReportFile + fCommon.strCommonReportFileName, strDuration, fCommon.numOfPassed, fCommon.numOfFailed, fCommon.numOfError, dateEndTime.ToString());
                File.Move(fCommon.strCommonPathReportFile + fCommon.strCommonReportFileName, strPathTestCase + strReportFileName);
                strLinkReportFile = strTmpLinkReport + strReportFileName;
                numOfPassed = fCommon.numOfPassed;
                numOfFailed = fCommon.numOfFailed;
                numOfError = fCommon.numOfError;
                selenium.Close();
                selenium.Stop();
            }
            catch (Exception)
            {
            }
        }
        /**********************************************************************************/
        /***************************DO NOT DELETE     END******************************/
        /**********************************************************************************/



        [Test]
        public void TestMethod()
        {
 			
        	//12BET
        	//Lrf_Reports_LiveReport_12bet_12bet_TC001: Verify that opening the Live Report report page without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_12bet_TC001: Verify that opening the Live Report report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the LRF site","info");
        	Lrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,Lrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the Live Report report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_LiveReport,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC002: Verify that submitting the report with specific date time without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC002: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific date range (Ex. Last Week)","info");
        	Control.select(selenium,Lrf_UIReports_LiveReport.ddlDate,"Last Week",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC003: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC003: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC004: Verify that user can open Number Game link
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC004: Verify that user can open Number Game link","name");
        	CommonFunc.writeLogReport("Step 1. Click on Number game link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkDrillDowntoNumberGame,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.lnkNumberGame,timeoutSecond,fCommon);
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC005: Verify that user can open Number Game betlist 
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC005: Verify that user can open Number Game betlist","name");
        	CommonFunc.writeLogReport("Step 1. Click on Number game detail link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkNumberGame,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC006: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC006: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC007: Verify that user can back from betlist without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC007: Verify that user can back from betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Back icon","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoBack,timeoutSecond,fCommon);

        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblDetailContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC008: Verify that user can open Racing link
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC008: Verify that user can open Racing link","name");
        	CommonFunc.writeLogReport("Step 1. Click on Racing link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkDrillDowntoRacing,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.lnkHorseRacing,timeoutSecond,fCommon);
        	
                	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC009: Verify that user can open Racing betlist 
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC009: Verify that user can open Racing betlist","name");
        	CommonFunc.writeLogReport("Step 1. Click on Racing detail link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkHorseRacing,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC010: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC010: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC011: Verify that user can back from betlist without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC011: Verify that user can back from betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Back icon","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoBack,timeoutSecond,fCommon);

        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblDetailContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC012: Verify that user can open Sportsbook link
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC012: Verify that user can open Sportsbook link","name");
        	CommonFunc.writeLogReport("Step 1. Click on Sportsbook link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkDrillDowntoSportsbook,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.lnkSoccer,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC013: Verify that user can open MixParlay betlist 
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC013: Verify that user can open MixParlay betlist","name");
        	CommonFunc.writeLogReport("Step 1. Click on MixParlay detail link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkMixParlay,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC014: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC014: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC015: Verify that user can back from betlist without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC015: Verify that user can back from betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Back icon","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoBack,timeoutSecond,fCommon);

        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblDetailContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC016: Verify that user can open Soccer matchlist  
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC016: Verify that user can open Soccer matchlist","name");
           	CommonFunc.writeLogReport("Step 1. Click on Soccer detail link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkSoccer,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblMatchList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC017: Verify that user can open Soccer betlist  
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC017: Verify that user can open Soccer betlist","name");
        	CommonFunc.writeLogReport("Step 1. Click on Soccer betlist link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkOpenBetList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC018: Verify that user can view result from betlist without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC018: Verify that user can view result from betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Result link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkResult,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.popResult,timeoutSecond,fCommon);
        	CommonFunc.writeLogReport("PostCondition: Close the Result popup","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.icoCloseResultPopup,timeoutSecond,fCommon);
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC019: Verify that user can back from betlist without error
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC019: Verify that user can back from betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to the Live Report report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_LiveReport,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Select a specific date range (Ex. Current Week)","info");
        	Control.select(selenium,Lrf_UIReports_LiveReport.ddlDate,"Current Week",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC020: Verify that user can open Total link
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC020: Verify that user can open Total link","name");
        	CommonFunc.writeLogReport("Step 1. Click on Total link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkDrillDowntoTotal,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.lnkHorseRacing,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC021: Verify that user can view under specific currency
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC021: Verify that user can view under specific currency","name");
        	CommonFunc.writeLogReport("Step 1. Select USD currency","info");
        	Control.select(selenium,Lrf_UIReports_LiveReport.ddlCurrency,"USD",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC022: Verify that user can view under specific currency without convert to EUR
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC022: Verify that user can view under specific currency without convert to EUR","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck convert to EUR","info");
        	Control.Uncheck(selenium,Lrf_UIReports_LiveReport.chkConvertTo,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC023: Verify that user can view History report
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC023: Verify that user can view History report","name");
        	CommonFunc.writeLogReport("Step 1. Click on view History report link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkViewHistoryReport,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("Step 2. Select Previous Month","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.iconPreviousMonth,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	//Lrf_Reports_LiveReport_12bet_TC024: Verify that user can back to current report
           	CommonFunc.writeLogReport("Lrf_Reports_LiveReport_12bet_TC024: Verify that user can back to current report","name");
        	CommonFunc.writeLogReport("Step 1. Click on back to current report link","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.lnkBacktoCurrentReport,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("Step 1. Select a specific date range (Ex. Yesterday)","info");
        	Control.select(selenium,Lrf_UIReports_LiveReport.ddlDate,"Yesterday",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LiveReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LiveReport.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	Lrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}