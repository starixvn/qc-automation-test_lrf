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


namespace SeleniumTests.OWA.Report
{
    [TestFixture]
    public class OWA_Report_Racing : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
       	public OWA_UIMainPage OWA_UIMainPage = new OWA_UIMainPage();
       	public OWA_UIRacing OWA_UIRacing = new OWA_UIRacing();

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
        public string DataFileName = "OWA_Report_Racing.xml";
        public string strPathDataFile = "Data\\OWA\\Report\\Racing\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Report\\Racing\\";

        public DateTime dateStartTime { get; set; }
        public DateTime dateEndTime { get; set; }
        private string strReportFileName = "";
        public string strDuration = "";
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();
        public OWA_Initialize OWA_Initialize = new OWA_Initialize();

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
            browser = OWA_Initialize.browser;
            port = OWA_Initialize.port;
            url = OWA_Initialize.url;
            server = OWA_Initialize.server;
            strAdminPassword = OWA_Initialize.strAdminPassword;
            strAdminUsername = OWA_Initialize.strAdminUserName;
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
        	//OWA_Report_Racing_TC001: Verify that there is no error when navigate to Racing report page"
        	CommonFunc.writeLogReport("OWA_TC001: Verify that there is no error when navigate to Racing report page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Racing report page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkRacing,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Racing report page","info");
        	Control.checkControlExist(selenium,OWA_UIRacing.fraRacingPage,timeoutSecond,fCommon);
        
        	
        	
        			//****************************OWA_Report_Racing_TC002*******************************\\
        	//OWA_Report_Racing_TC002: Verify that user cannot submit without selecting a Licensee
        	CommonFunc.writeLogReport("OWA_Report_Racing_TC002: Verify that user cannot submit without selecting a Licensee","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit","info");
        	Control.click(selenium,OWA_UIRacing.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkTextInControl(selenium,OWA_UIRacing.msgRequiredLicensee,"Please select a Licensee!",timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWA_Report_Racing_TC003*******************************\\
        	//OWA_Report_Racing_TC003: Verify that user can submit to view report without error
        	CommonFunc.writeLogReport("OWA_Report_Racing_TC003: Verify that user can submit to view report without error","name");
        	CommonFunc.writeLogReport("Step 1. Select any Licensee (ex. 12Bet (BCH)","info");
        	Control.select(selenium,OWA_UIRacing.ddlSelectLicensee,"12Bet",1,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWA_UIRacing.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UIRacing.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWA_Report_Racing_TC004*******************************\\
        	//OWA_Report_Racing_TC004: Verify that user can export the report without error
        	CommonFunc.writeLogReport("OWA_Report_Racing_TC004: Verify that user can export the report without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on export to excel","info");
        	Control.click(selenium,OWA_UIRacing.btnExportExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UIRacing.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWA_Report_Racing_TC005*******************************\\
        	//OWA_Report_Racing_TC005: Verify that user can open betlist without error
        	CommonFunc.writeLogReport("OWA_Report_Racing_TC005: Verify that user can open betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on betlist link","info");
        	Control.click(selenium,OWA_UIRacing.lnkBetlist,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The betlist is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UIRacing.popBetlist,timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWA_Report_Racing_TC006*******************************\\
        	//OWA_Report_Racing_TC006: Verify that user can close betlist without error
        	CommonFunc.writeLogReport("OWA_Report_Racing_TC006: Verify that user can close betlist without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on close betlist button","info");
        	Control.click(selenium,OWA_UIRacing.btnClose,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UIRacing.tblReportResult,timeoutSecond,fCommon);
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        	
        }
    }
}