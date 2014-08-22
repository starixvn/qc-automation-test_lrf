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
    public class OWASimplified_NumberGameReport : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
       	public OWASimplified_UIMainPage OWASimplified_UIMainPage = new OWASimplified_UIMainPage();
       	public OWASimplified_UINumberGameReport OWASimplified_UINumberGameReport = new OWASimplified_UINumberGameReport();

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
        public string DataFileName = "OWASimplified_NumberGameReport.xml";
        public string strPathDataFile = "Data\\OWASimplified\\NumberGame Report\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWASimplified\\NumberGame Report\\";

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
        	//OWASimplified_NumberGameReport_TC001: Verify that there is no error when navigate to Win Loss report page"
        	CommonFunc.writeLogReport("OWASimplified_NumberGameReport_TC001: Verify that there is no error when navigate to Win Loss report page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWASimplified_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Win Loss report page","info");
        	Control.click(selenium,OWASimplified_UIMainPage.lnkNumberGameReport,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Total Transaction page","info");
        	Control.checkControlExist(selenium,OWASimplified_UINumberGameReport.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//OWASimplified_NumberGameReport_TC002: Verify that submitting report with default selecting
        	CommonFunc.writeLogReport("OWASimplified_NumberGameReport_TC002: Verify that submitting report with default selecting","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit ","info");
        	Control.click(selenium,OWASimplified_UINumberGameReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UINumberGameReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWASimplified_NumberGameReport_TC003: Verify that user can submit after changing Date Range without error
        	CommonFunc.writeLogReport("OWASimplified_NumberGameReport_TC003: Verify that user can submit after changing Date Range without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Date Range (ex. Last Month) ","info");
        	Control.select(selenium,OWASimplified_UINumberGameReport.ddlDateRange,"Last Month",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UINumberGameReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UINumberGameReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWASimplified_NumberGameReport_TC004: Verify that user can submit after changing Report By 'chkBCH' without error
        	CommonFunc.writeLogReport("OWASimplified_NumberGameReport_TC004: Verify that user can submit after changing Report By 'chkBCH' without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Report By 'chkBCH' ","info");
        	Control.click(selenium,OWASimplified_UINumberGameReport.chkBCH,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UINumberGameReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UINumberGameReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWASimplified_NumberGameReport_TC005: Verify that user can export without error
        	CommonFunc.writeLogReport("OWASimplified_NumberGameReport_TC005: Verify that user can export without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Export to excel","info");
        	Control.click(selenium,OWASimplified_UINumberGameReport.icoExportExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report shows without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UINumberGameReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}