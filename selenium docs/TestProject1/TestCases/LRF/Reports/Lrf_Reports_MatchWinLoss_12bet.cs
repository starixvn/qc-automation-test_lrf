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
    public class Lrf_Reports_MatchWinLoss_12bet : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Lrf_UILeftMenu Lrf_UILeftMenu = new Lrf_UILeftMenu();
        public Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
        public Lrf_UIReports_MatchWinLoss Lrf_UIReports_MatchWinLoss = new Lrf_UIReports_MatchWinLoss();
        public Lrf_UIMain Lrf_UIMain = new Lrf_UIMain();
        //public Lrf_UIReports_MatchWinLoss Lrf_UIReports_MatchWinLoss = new Lrf_UIReports_MatchWinLoss();
        public Lrf_Initialize Lrf_Initialize = new Lrf_Initialize();
        //**********************************************************************************************
        //private StringBuilder verificationErrors;

        public string browser;
        public string url;
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
        public string DataFileName = "Lrf_Reports_MatchWinLoss.xml";
        public string strPathDataFile = "Data\\LRF\\Reports\\Match Win Loss\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "LRF\\Reports\\Match Win Loss\\";
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
            //Lrf_Reports_MatchWinLoss_12bet_TC001: Verify that opening the Match Win Loss report page without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC001: Verify that opening the Match Win Loss report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the LRF site","info");
        	Lrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,Lrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the Match Win Loss report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_MatchWinLoss,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_MatchWinLoss_12bet_TC002: Verify that submitting the report by All product without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC002: Verify that submitting the report by All product without error","name");
        	CommonFunc.writeLogReport("Step 1. Check All product","info");
        	Control.Check(selenium,Lrf_UIReports_MatchWinLoss.chkAllProduct,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_MatchWinLoss_12bet_TC003: Verify that submitting the report with specific Currency time without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC003: Verify that submitting the report with specific Currency time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency (Ex. CNY)","info");
        	Control.select(selenium,Lrf_UIReports_MatchWinLoss.ddlCurrency,"CNY",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_MatchWinLoss_12bet_TC004: Verify that the report is submitted when uncheck Convert to EUR without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC004: Verify that the report is submitted when uncheck Convert to EUR without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck Convert to EUR","info");
        	Control.Uncheck(selenium,Lrf_UIReports_MatchWinLoss.chkConvertTo,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_MatchWinLoss_12bet_TC006: Verify that user can expand Match to view bettype without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC006: Verify that user can expand Match to view bettype without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on any match to expand bettype","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.lnkExpandMatch,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.lnkOpenBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_MatchWinLoss_12bet_TC007: Verify that user can open betlist without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC007: Verify that user can open betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on any bettype to open betlist","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.lnkOpenBetList,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	CommonFunc.writeLogReport("VP. Bet list is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.tblBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_MatchWinLoss_12bet_TC008: Verify that user can export betlist to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC008: Verify that user can export betlist to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.icoExportBetList,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.tblBetList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Post-condition: close the popup","info");
        	selenium.ChooseCancelOnNextConfirmation();
        	
        	
        	
        	
        	//Lrf_Reports_MatchWinLoss_12bet_TC009: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_MatchWinLoss_12bet_TC009: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Back to main page","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.icoBack,timeoutSecond,fCommon);
           	Thread.Sleep(3000);
           	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_MatchWinLoss.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_MatchWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	Lrf_Common.Logout(selenium,timeoutSecond,fCommon);

        }
    }
}