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
    public class NEWLrf_Reports_WinLossByProducts_12bet : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public NEWLrf_UILeftMenu NEWLrf_UILeftMenu = new NEWLrf_UILeftMenu();
        public NEWLrf_UITopMenu NEWLrf_UITopMenu = new NEWLrf_UITopMenu();
        public NEWLrf_UIReports_WinLossByProducts NEWLrf_UIReports_WinLossByProducts = new NEWLrf_UIReports_WinLossByProducts();
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
        public string DataFileName = "NEWLrf_Reports_WinLossByProducts_12bet.xml";
        public string strPathDataFile = "Data\\NEWLrf\\Reports\\Win Loss By Products\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "NEWLrf\\Reports\\Win Loss By Products\\";
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
 			//NEWLrf_Reports_WinLossByProducts_12bet_TC001: Verify that opening the Win Loss By Products report page without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC001: Verify that opening the Win Loss By Products report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the NEWLrf site","info");
        	NEWLrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,NEWLrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the Win Loss By Products report","info");
        	Control.click(selenium,NEWLrf_UILeftMenu.lnkReports_WinLossByProducts,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC002: Verify that submitting the report with specific date time without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC002: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific date range (Ex. Current Week)","info");
        	Control.select(selenium,NEWLrf_UIReports_WinLossByProducts.ddlDate,"Current Week",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC003: Verify that submitting the report with specific Currency time without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC003: Verify that submitting the report in specific date time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency (Ex. USD)","info");
        	Control.select(selenium,NEWLrf_UIReports_WinLossByProducts.ddlCurrency,"USD",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC004: Verify that submitting the report by Monthly without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC004: Verify that submitting the report by Monthly without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to Monthly report mode","info");
        	Control.Check(selenium,NEWLrf_UIReports_WinLossByProducts.rdoReportbyMonthly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC005: Verify that submitting the report by No Draws filter without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC005: Verify that submitting the report by Draw filter without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter report mode","info");
        	Control.Check(selenium,NEWLrf_UIReports_WinLossByProducts.rdoDrawFilterNoDraws,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC006: Verify that submitting the report by No Draws filter for Turnover Only without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC006: Verify that submitting the report by Draw filter for Turnover Only without error","name");
        	CommonFunc.writeLogReport("Step 1. Switch to No Draws filter for Turnover Only report mode","info");
        	Control.Check(selenium,NEWLrf_UIReports_WinLossByProducts.rdoDrawFilterNoDrawsForTurnoverOnly,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC007: Verify that submitting the report by SportBook only without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC007: Verify that submitting the report by SportBook only without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck All product","info");
        	Control.Uncheck(selenium,NEWLrf_UIReports_WinLossByProducts.chkAll,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Check SportBook ","info");
        	Control.Check(selenium,NEWLrf_UIReports_WinLossByProducts.chkSB,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC008: Verify that drill-down from Main to Licensee without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC008: Verify that drill-down from Main to Licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Currency link to drill down","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.lnkDrillDowntoAgent,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC009: Verify that drill-down from Licensee to Member without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC009: Verify that drill-down from Licensee to Member without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on SystemID link to drill down","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.lnkDrillDowntoMember,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC010: Verify that user can open betlist without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC010: Verify that user can open betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on member link to open betlist","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.lnkOpenBetList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Bet list is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC011: Verify that user can export betlist to excel without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC011: Verify that user can export betlist to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.icoExportBetList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Bet list is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblBetList,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("Post-condition: close betlist","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.btnCloseBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_Reports_WinLossByProducts_12bet_TC012: Verify that user can export report to excel without error
           	CommonFunc.writeLogReport("NEWLrf_Reports_WinLossByProducts_12bet_TC012: Verify that user can export report to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export excel icon","info");
        	Control.click(selenium,NEWLrf_UIReports_WinLossByProducts.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIReports_WinLossByProducts.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	NEWLrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}