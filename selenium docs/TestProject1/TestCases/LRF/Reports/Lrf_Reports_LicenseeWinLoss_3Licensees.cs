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
    public class Lrf_Reports_LicenseeWinLoss_3Licensees : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Lrf_UILeftMenu Lrf_UILeftMenu = new Lrf_UILeftMenu();
        public Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
        public Lrf_UIReports_LicenseeWinLoss Lrf_UIReports_LicenseeWinLoss = new Lrf_UIReports_LicenseeWinLoss();
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
        public string DataFileName = "Lrf_Reports_LicenseeWinLoss_MANSION88.xml";
        public string strPathDataFile = "Data\\LRF\\Reports\\Licensee Win Loss\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "LRF\\Reports\\Licensee Win Loss\\";
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
 			
        	//MANSION88
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_MANSION88_TC001: Verify that opening the Licensee Win Loss report page without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_MANSION88_TC001: Verify that opening the Licensee Win Loss report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the LRF site","info");
        	Lrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee mansion88)","info");
        	Control.click(selenium,Lrf_UIMain.btnMansion88,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the Licensee Win Loss report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_LicenseeWinLoss,timeoutSecond,fCommon);
        	selenium.WaitForPageToLoad("50000");
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC002: Verify that submitting the report with specific date time without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC002: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific date range (Ex. Current Week)","info");
        	Control.select(selenium,Lrf_UIReports_LicenseeWinLoss.ddlDate,"Current Week",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC003: Verify that submitting the report with specific Currency time without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC003: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency (Ex. USD)","info");
        	Control.select(selenium,Lrf_UIReports_LicenseeWinLoss.ddlCurrency,"USD",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC004: Verify that submitting the report by Monthly without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC004: Verify that submitting the report by Monthly without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to Monthly report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoReportByMonthly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC005: Verify that submitting the report by No Draws filter without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC005: Verify that submitting the report by Draw filter without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoDrawFilterNoDraws,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC006: Verify that submitting the report by No Draws filter for Turnover Only without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC006: Verify that submitting the report by Draw filter for Turnover Only without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter for Turnover Only report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoDrawFilterNoDrawsForTurnoverOnly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC007: Verify that submitting the report by SportBook only without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC007: Verify that submitting the report by SportBook only without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck All product","info");
        	Control.Uncheck(selenium,Lrf_UIReports_LicenseeWinLoss.chkAll,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Check SportBook ","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.chkSB,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC008: Verify that drill-down from Main to Licensee without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC008: Verify that drill-down from Main to Licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Currency link to drill down","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.lnkDrillDownToAgentList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC009: Verify that drill-down from Licensee to Member without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC009: Verify that drill-down from Licensee to Member without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on SystemID link to drill down","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.lnkDrillDownToMemberList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC011: Verify that user can export betlist to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC011: Verify that user can export betlist to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.icoBetListExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Bet list is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_MANSION88_TC012: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_MANSION88_TC012: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//12BET
        	//Lrf_Reports_LicenseeWinLoss_12bet_12bet_TC001: Verify that opening the Licensee Win Loss report page without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_12bet_TC001: Verify that opening the Licensee Win Loss report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.select(selenium,Lrf_UIMain.ddlLicensee,"12Bet",timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the Licensee Win Loss report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_LicenseeWinLoss,timeoutSecond,fCommon);
        	selenium.WaitForPageToLoad("50000");
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC002: Verify that submitting the report with specific date time without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC002: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific date range (Ex. Current Week)","info");
        	Control.select(selenium,Lrf_UIReports_LicenseeWinLoss.ddlDate,"Current Week",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC003: Verify that submitting the report with specific Currency time without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC003: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency (Ex. USD)","info");
        	Control.select(selenium,Lrf_UIReports_LicenseeWinLoss.ddlCurrency,"USD",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC004: Verify that submitting the report by Monthly without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC004: Verify that submitting the report by Monthly without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to Monthly report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoReportByMonthly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC005: Verify that submitting the report by No Draws filter without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC005: Verify that submitting the report by Draw filter without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoDrawFilterNoDraws,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC006: Verify that submitting the report by No Draws filter for Turnover Only without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC006: Verify that submitting the report by Draw filter for Turnover Only without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter for Turnover Only report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoDrawFilterNoDrawsForTurnoverOnly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC007: Verify that submitting the report by SportBook only without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC007: Verify that submitting the report by SportBook only without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck All product","info");
        	Control.Uncheck(selenium,Lrf_UIReports_LicenseeWinLoss.chkAll,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Check SportBook ","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.chkSB,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC008: Verify that drill-down from Main to Licensee without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC008: Verify that drill-down from Main to Licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Currency link to drill down","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.lnkDrillDownToAgentList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC009: Verify that drill-down from Licensee to Member without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC009: Verify that drill-down from Licensee to Member without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on SystemID link to drill down","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.lnkDrillDownToMemberList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC010: Verify that user can open betlist without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC010: Verify that user can open betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on member link to open betlist","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.lnkOpenBetList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Bet list is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC011: Verify that user can export betlist to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC011: Verify that user can export betlist to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.icoBetListExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Bet list is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_12bet_TC012: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_12bet_TC012: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
                	
        	
        	
        	
        	//asiabet88
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_asiabet88_TC001: Verify that opening the Licensee Win Loss report page without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_asiabet88_TC001: Verify that opening the Licensee Win Loss report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Open a Licensee to test (Ex. Licensee asiabet88)","info");
        	Control.select(selenium,Lrf_UIMain.ddlLicensee,"asiabet88",timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	CommonFunc.writeLogReport("Step 3. Navigate to the Licensee Win Loss report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_LicenseeWinLoss,timeoutSecond,fCommon);
        	selenium.WaitForPageToLoad("50000");
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.frmMain,timeoutSecond,fCommon);
        	
        	
      	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC002: Verify that submitting the report with specific date time without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC002: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific date range (Ex. Current Week)","info");
        	Control.select(selenium,Lrf_UIReports_LicenseeWinLoss.ddlDate,"Current Week",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC003: Verify that submitting the report with specific Currency time without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC003: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency (Ex. USD)","info");
        	Control.select(selenium,Lrf_UIReports_LicenseeWinLoss.ddlCurrency,"USD",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC004: Verify that submitting the report by Monthly without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC004: Verify that submitting the report by Monthly without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to Monthly report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoReportByMonthly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC005: Verify that submitting the report by No Draws filter without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC005: Verify that submitting the report by Draw filter without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoDrawFilterNoDraws,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC006: Verify that submitting the report by No Draws filter for Turnover Only without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC006: Verify that submitting the report by Draw filter for Turnover Only without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter for Turnover Only report mode","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.rdoDrawFilterNoDrawsForTurnoverOnly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC007: Verify that submitting the report by SportBook only without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC007: Verify that submitting the report by SportBook only without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck All product","info");
        	Control.Uncheck(selenium,Lrf_UIReports_LicenseeWinLoss.chkAll,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Check SportBook ","info");
        	Control.Check(selenium,Lrf_UIReports_LicenseeWinLoss.chkSB,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC008: Verify that drill-down from Main to Licensee without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC008: Verify that drill-down from Main to Licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Currency link to drill down","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.lnkDrillDownToAgentList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC009: Verify that drill-down from Licensee to Member without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC009: Verify that drill-down from Licensee to Member without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on SystemID link to drill down","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.lnkDrillDownToMemberList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	        	
              	        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC011: Verify that user can export betlist to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC011: Verify that user can export betlist to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.icoBetListExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Bet list is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_Reports_LicenseeWinLoss_asiabet88_TC012: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_LicenseeWinLoss_asiabet88_TC012: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,Lrf_UIReports_LicenseeWinLoss.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_LicenseeWinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	Lrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}