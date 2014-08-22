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


namespace SeleniumTests.NEWLrf.Reports
{
    [TestFixture]
    public class NEWLrf_Reports_LastBetsMonitoring_12bet : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public NEWLrf_UILeftMenu NEWLrf_UILeftMenu = new NEWLrf_UILeftMenu();
        public NEWLrf_UITopMenu NEWLrf_UITopMenu = new NEWLrf_UITopMenu();
        public NEWLrf_UIReports_LastBetsMonitoring NEWLrf_UIReports_LastBetsMonitoring = new NEWLrf_UIReports_LastBetsMonitoring();
        public NEWLrf_UIMain NEWLrf_UIMain = new NEWLrf_UIMain();
        public NEWLrf_Initialize NEWLrf_Initialize = new NEWLrf_Initialize();
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
        public string DataFileName = "NEWLrf_Reports_LastBetsMonitoring.xml";
        public string strPathDataFile = "Data\\NEWLrf\\Reports\\Last Bets Monitoring\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "NEWLrf\\Reports\\Last Bets Monitoring\\";
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

            browser = NEWLrf_Initialize.browser;
            port = NEWLrf_Initialize.port;
            url = NEWLrf_Initialize.url;
            server = NEWLrf_Initialize.server;
            strAdminPassword = NEWLrf_Initialize.strAdminPassword;
            strAdminUsername = NEWLrf_Initialize.strAdminUserName;
            strCaptcha = NEWLrf_Initialize.strCaptcha;
            btnLicensee = NEWLrf_Initialize.btnLicensee;
            selenium = new DefaultSelenium(server, port, browser, url);
            selenium.Start();

            timeoutSecond = fCommon.timeoutSecond;
            strPathDataFile = fCommon.strRootFolder.Replace("/", "\\") + strPathDataFile;

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
            
        	//Licensee_12BET
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC001: Verify that opening the Last Bets Monitoring report page without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC001: Verify that opening the Last Bets Monitoring report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the NEWLrf site","info");
        	NEWLrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,NEWLrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	
        	        	
        
        	CommonFunc.writeLogReport("Step 3. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.select(selenium,NEWLrf_UIMain.ddlLicensee,"12Bet",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 4. Navigate to the Last Bets Monitoring report","info");
        	Control.click(selenium,NEWLrf_UILeftMenu.lnkReports_LastBetsMonitoring,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.tblSearchResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_TC002: Verify that changing Type of licensee without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_TC002: Verify that changing Type of licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Change type to Normal","info");
        	Control.select(selenium,NEWLrf_UIReports_LastBetsMonitoring.ddlType,"normal",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Waiting for page loading","info");
        	Control.waitForControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.icoLoading,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.tblSearchResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC002: Verify that viewing the report due to Handicap bettype without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC002: Verify that viewing the report due to Handicap bettype without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Handicap link","info");
        	Control.click(selenium,NEWLrf_UIReports_LastBetsMonitoring.lnkHandicap,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Waiting for page loading","info");
        	Control.waitForControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.icoLoading,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.tblSearchResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC003: Verify that viewing the report due to Over/Under bettype without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC003: Verify that viewing the report due to Over/Under bettype without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Over/Under link","info");
        	Control.click(selenium,NEWLrf_UIReports_LastBetsMonitoring.lnkOverUnder,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Waiting for page loading","info");
        	Control.waitForControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.icoLoading,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.tblSearchResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC004: Verify that viewing the report due to Others bettype without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC004: Verify that viewing the report due to Others bettype without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Others link","info");
        	Control.click(selenium,NEWLrf_UIReports_LastBetsMonitoring.lnkOthers,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Waiting for page loading","info");
        	Control.waitForControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.icoLoading,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.tblSearchResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC005: Verify that viewing the report due to 20 records mode without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC005: Verify that viewing the report due to 20 records mode without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on 20 button","info");
        	Control.click(selenium,NEWLrf_UIReports_LastBetsMonitoring.btn20,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Waiting for page loading","info");
        	Control.waitForControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.icoLoading,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.tblSearchResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC006: Verify that viewing the report due to 30 records mode without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC006: Verify that viewing the report due to 30 records mode without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on 30 button","info");
        	Control.click(selenium,NEWLrf_UIReports_LastBetsMonitoring.btn30,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Waiting for page loading","info");
        	Control.waitForControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.icoLoading,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_LastBetsMonitoring.tblSearchResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC007: Verify that All currency is unchecked after uncheck any another currency
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC007: Verify that All currency is unchecked after uncheck any another currency","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck any currency such as GBP","info");
        	Control.Uncheck(selenium,NEWLrf_UIReports_LastBetsMonitoring.chkINHCurrency,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. All currency is unchecked ","info");
        	Control.verifyControlChecked(selenium,NEWLrf_UIReports_LastBetsMonitoring.chkAllCurrency,false,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_Reports_LastBetsMonitoring_12BET_TC008: Verify that All level is unchecked after uncheck any another level
           	CommonFunc.writeLogReport("NEWLrf_Reports_LastBetsMonitoring_12BET_TC008: Verify that All level is unchecked after uncheck any another level","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck any level such as Level 10","info");
        	Control.Uncheck(selenium,NEWLrf_UIReports_LastBetsMonitoring.chkLevel10,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. All currency is unchecked ","info");
        	Control.verifyControlChecked(selenium,NEWLrf_UIReports_LastBetsMonitoring.chkAllLevel,false,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	NEWLrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}