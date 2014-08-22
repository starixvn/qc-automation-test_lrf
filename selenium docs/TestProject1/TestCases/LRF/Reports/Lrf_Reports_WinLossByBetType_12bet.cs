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
    public class Lrf_Reports_WinLossByBetType_12bet : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Lrf_UILeftMenu Lrf_UILeftMenu = new Lrf_UILeftMenu();
        public Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
        public Lrf_UIReports_WinLossByBetType Lrf_UIReports_WinLossByBetType = new Lrf_UIReports_WinLossByBetType();
        public Lrf_UIMain Lrf_UIMain = new Lrf_UIMain();
        //public Lrf_UIReports_WinLossByBetType Lrf_UIReports_WinLossByBetType = new Lrf_UIReports_WinLossByBetType();
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
        public string DataFileName = "Lrf_Reports_WinLossByBetType_12bet_01.xml";
        public string strPathDataFile = "Data\\LRF\\Reports\\Win Loss By Bet Type\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "LRF\\Reports\\Win Loss By Bet Type\\";
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
            //Lrf_Reports_WinLossByBetType_12bet_TC001: Verify that opening the Win Loss By Bet Type report page without error
           	CommonFunc.writeLogReport("Lrf_Reports_WinLossByBetType_12bet_TC001: Verify that opening the Win Loss By Bet Type report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the LRF site","info");
        	Lrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,Lrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the Win Loss By Bet Type report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_WinLossByBetType,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_WinLossByBetType.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_WinLossByBetType_12bet_TC002: Verify that submitting the report with specific Currency time without error
           	CommonFunc.writeLogReport("Lrf_Reports_WinLossByBetType_12bet_TC002: Verify that submitting the report with specific Currency time without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency (Ex. CNY)","info");
        	Control.select(selenium,Lrf_UIReports_WinLossByBetType.ddlCurrency,"CNY",timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_WinLossByBetType.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_WinLossByBetType.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_Reports_WinLossByBetType_12bet_TC003: Verify that the report is submitted when uncheck Convert to EUR without error
           	CommonFunc.writeLogReport("Lrf_Reports_WinLossByBetType_12bet_TC003: Verify that the report is submitted when uncheck Convert to EUR without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck Convert to EUR","info");
        	Control.Uncheck(selenium,Lrf_UIReports_WinLossByBetType.chkConvertTo,timeoutSecond,fCommon);
        	               
        	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
        	Control.click(selenium,Lrf_UIReports_WinLossByBetType.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_WinLossByBetType.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        

			//Lrf_Reports_WinLossByBetType_12bet_TC005: Verify that view Yesterday without error
           	CommonFunc.writeLogReport("Lrf_Reports_WinLossByBetType_12bet_TC005: Verify that view Yesterday without error","name");
        	CommonFunc.writeLogReport("Step 1. Click Yesterday ","info");
        	Control.click(selenium,Lrf_UIReports_WinLossByBetType.btnYesterday,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_WinLossByBetType.tblReportContent,timeoutSecond,fCommon);
        	        	
        	
        	
        	
			//Lrf_Reports_WinLossByBetType_12bet_TC006: Verify that Export to excel without error
           	CommonFunc.writeLogReport("Lrf_Reports_WinLossByBetType_12bet_TC006: Verify that Export to excel without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export to excel","info");
        	Control.click(selenium,Lrf_UIReports_WinLossByBetType.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_WinLossByBetType.tblReportContent,timeoutSecond,fCommon);
        	        	
        	
        	
        	
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	Lrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}