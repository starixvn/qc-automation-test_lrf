using System;
using System.Diagnostics;
using System.Net.Mime;
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

namespace SeleniumTests.OWASimplified
{
    [TestFixture]
    public class OWASimplified_WinLossReport : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
       	public OWASimplified_UIMainPage OWASimplified_UIMainPage = new OWASimplified_UIMainPage();
       	public OWASimplified_UIWinLossReport OWASimplified_UIWinLossReport = new OWASimplified_UIWinLossReport();

        //private StringBuilder verificationErrors;
        public string strAdminUsername;
        public string strAdminPassword;
        public string browser;
        public string url;
        public string server;
        public int port;
        public int timeoutSecond;
        private string strTmpLinkReport = "";
        public string strLinkReportFile { get; set; }
        public int numOfPassed { get; set; }
        public int numOfFailed { get; set; }
        public int numOfError { get; set; }

        //*******YOU HAVE TO EDIT THE PATH AND NAME OF DATA FILE WHICH YOU LOAD DATA FROM (ex: "Handicap-OverUnder-Live.xml", Path: "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string DataFileName = "OWASimplified_WinLossReport.xml";
        public string strPathDataFile = "Data\\OWASimplified\\WinLossReport\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWASimplified\\WinLossReport\\";

        public DateTime dateStartTime { get; set; }
        public DateTime dateEndTime { get; set; }
        private string strReportFileName = "";
        public string strDuration = "";
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();
        public OWASimplified_Initialize OWASimplified_Initialize = new OWASimplified_Initialize();

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
            browser = OWASimplified_Initialize.browser;
            port = OWASimplified_Initialize.port;
            url = OWASimplified_Initialize.url;
            server = OWASimplified_Initialize.server;
            strAdminPassword = OWASimplified_Initialize.strAdminPassword;
            strAdminUsername = OWASimplified_Initialize.strAdminUserName;
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


        [Test]
        public void TestMethod()
        {
        	//OWASimplified_WinLossReport_TC001: Verify that there is no error when navigate to Win Loss report page"
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC001: Verify that there is no error when navigate to Win Loss report page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWASimplified_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Win Loss report page","info");
        	Control.click(selenium,OWASimplified_UIMainPage.lnkWinLossReport,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Total Transaction page","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC002: Verify that require message shows when submit without selected Licensee
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC002: Verify that require message shows when submit without selected Licensee","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit without selected Licensee","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Required message shows and user can't see the currently report","info");
        	Control.checkTextInControl(selenium,OWASimplified_UIWinLossReport.msgRequiredMessage,"Please select a Licensee!",timeoutSecond,fCommon);
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC003: Verify that user can submit after selecting Licensee without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC003: Verify that user can submit after selecting Licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Select VCasia licensee","info");
        	Control.select(selenium,OWASimplified_UIWinLossReport.ddlLicensee,"VCasia",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC004: Verify that user can submit after changing to other Currency without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC004: Verify that user can submit after changing to other Currency without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Base Currency - EUR currency","info");
        	Control.select(selenium,OWASimplified_UIWinLossReport.ddlCurrency,"Base Currency-EUR",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC005: Verify that user can submit after changing to specific Currency (Ex. USD) without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC005: Verify that user can submit after changing to specific Currency (Ex. USD) without error","name");
        	CommonFunc.writeLogReport("Step 1. Select USD currency","info");
        	Control.select(selenium,OWASimplified_UIWinLossReport.ddlCurrency,"CNY",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC006: Verify that user can submit after changing Date Range without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC006: Verify that user can submit after changing Date Range without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Date Range (ex. Last Month) ","info");
        	Control.select(selenium,OWASimplified_UIWinLossReport.ddlDateRange,"Last Month",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC007: Verify that user can submit after changing Report By 'Monthly' without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC007: Verify that user can submit after changing Report By 'Monthly' without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Report By 'Monthly' ","info");
        	Control.Check(selenium,OWASimplified_UIWinLossReport.rdoMonthly,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC008: Verify that user can submit after changing Report Type 'No Draw' without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC008: Verify that user can submit after changing Report Type 'No Draw' without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Report Type 'No Draw' ","info");
        	Control.Check(selenium,OWASimplified_UIWinLossReport.rdoNoDraw,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC010: Verify that user can export without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC010: Verify that user can export without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Export","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.icoExportExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC009: Verify that user can submit after changing Report Type 'No Draw for Turnover only' without error
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC009: Verify that user can submit after changing Report Type 'No Draw for Turnover only' without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Report Type 'No Draw for Turnover only' ","info");
        	Control.Check(selenium,OWASimplified_UIWinLossReport.rdoNoDraw4Turnover,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWASimplified_WinLossReport_TC011: Verify that user can drill down to downline
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC011: Verify that user can drill down to downline","name");
        	CommonFunc.writeLogReport("Step 1. Click on currency link","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.lnkCurrencyDrillDown,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	        	
        	
        	
        	//OWASimplified_WinLossReport_TC013: Verify that user can open betlist
        	CommonFunc.writeLogReport("OWASimplified_WinLossReport_TC012: Verify that user can open betlist","name");
        	CommonFunc.writeLogReport("Step 1. Click on user link","info");
        	Control.click(selenium,OWASimplified_UIWinLossReport.lnkOpenBetlist,timeoutSecond,fCommon);
        	Thread.Sleep(3000);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIWinLossReport.popBetlist,timeoutSecond,fCommon);
        	//close betlist
        	Control.click(selenium,OWASimplified_UIWinLossReport.btnCloseBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}