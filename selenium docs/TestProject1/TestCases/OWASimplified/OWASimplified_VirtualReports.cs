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
    public class OWASimplified_VirtualSportsReport : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
       	public OWASimplified_UIMainPage OWASimplified_UIMainPage = new OWASimplified_UIMainPage();
       	public OWASimplified_UIVirtualSportsReport OWASimplified_UIVirtualSportsReport = new OWASimplified_UIVirtualSportsReport();

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
        public string DataFileName = "OWASimplified_VirtualSportsReport.xml";
        public string strPathDataFile = "Data\\OWASimplified\\Virtual Sports Report\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWASimplified\\Virtual Sports Report\\";

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
        	//OWASimplified_VirtualSportsReport_TC001: Verify that there is no error when navigate to Virtual Sports page"
        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC001: Verify that there is no error when navigate to Virtual Sports page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWASimplified_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Virtual Sports page","info");
        	Control.click(selenium,OWASimplified_UIMainPage.lnkVirtualSportsReport,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Virtual Sports page","info");
        	Control.checkControlExist(selenium,OWASimplified_UIVirtualSportsReport.fraMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWASimplified_VirtualSportsReport_TC002*******************************\\
        	//OWASimplified_VirtualSportsReport_TC002: Verify that user can submit to view report without error
        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC002: Verify that user can submit to view report without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIVirtualSportsReport.tblReportResult,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	
        	
        	
//        			//****************************OWASimplified_VirtualSportsReport_TC003*******************************\\
//        	//OWASimplified_VirtualSportsReport_TC003: Verify that "All Licensees" option are unchecked if user unchecks one of licensees
//        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC003: Verify that 'All Licensees' option are unchecked if user unchecks one of licensees","name");
//        	CommonFunc.writeLogReport("Step 1. Uncheck any Operators/Resellers","info");
//        	Control.Uncheck(selenium,OWASimplified_UIVirtualSportsReport.chkBCH12Bet,timeoutSecond,fCommon);
//        	Thread.Sleep(timeoutSecond);
//        	
//        	CommonFunc.writeLogReport("VP. 'All Operators/Resellers' option is unchecked","info");
//        	Control.verifyControlChecked(selenium,OWASimplified_UIVirtualSportsReport.chkSelectAllResellers,false,timeoutSecond,fCommon);
//        	
//        	
//        	
//        	
//        			//****************************OWASimplified_VirtualSportsReport_TC004*******************************\\
//        	//OWASimplified_VirtualSportsReport_TC004: Verify that "All Licensees" option are checked if user checks all of licensees
//        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC004:  Verify that 'All Licensees' option are checked if user checks all of licensees","name");
//        	CommonFunc.writeLogReport("Step 1. Check licensee which is unchecked at TC003","info");
//        	Control.Check(selenium,OWASimplified_UIVirtualSportsReport.chkBCH12Bet,timeoutSecond,fCommon);
//        	
//        	CommonFunc.writeLogReport("VP. 'All Licensees' option is unchecked","info");
//        	Control.verifyControlChecked(selenium,OWASimplified_UIVirtualSportsReport.chkSelectAllResellers,true,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWASimplified_VirtualSportsReport_TC005*******************************\\
        	//OWASimplified_VirtualSportsReport_TC005: Verify that a recommend message displays after submitting without selected any Licensee
        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC005: Verify that a recommend message displays after submitting without selected any Licensee","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck all Operators/Resellers","info");
        	Control.Uncheck(selenium,OWASimplified_UIVirtualSportsReport.chkSelectAllResellers,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The required message displays","info");
        	Control.checkTextInControl(selenium,OWASimplified_UIVirtualSportsReport.msgRequiredMessage,"Please select at least one item of Operators/Resellers!",timeoutSecond,fCommon);
        	
        	
//        	
//        			//****************************OWASimplified_VirtualSportsReport_TC006*******************************\\
//        	//OWASimplified_VirtualSportsReport_TC006: Verify that user drills down to date time in the report without error
//        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC006: Verify that user drills down to date time in the report without error","name");
//        	CommonFunc.writeLogReport("Step 1. Close require message popup","info");
//        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.btnCloseRequiredMessage,timeoutSecond,fCommon);
//        	
//        	CommonFunc.writeLogReport("Step 2. Check all Operators/Resellers","info");
//        	Control.Check(selenium,OWASimplified_UIVirtualSportsReport.chkSelectAllResellers,timeoutSecond,fCommon);
//        	
//        	CommonFunc.writeLogReport("Step 3. Click on Submit","info");
//        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.btnSubmit,timeoutSecond,fCommon);
//        	Thread.Sleep(timeoutSecond);
//        	
//        	CommonFunc.writeLogReport("Step 4. Click on any date time in the report to drill down","info");
//        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.lnkDrillDown,timeoutSecond,fCommon);
//        	
//        	CommonFunc.writeLogReport("VP. The drilling down page shows without error","info");
//        	Control.checkControlExist(selenium,OWASimplified_UIVirtualSportsReport.btnBack,timeoutSecond,fCommon);
        	
        	
        	
        			//****************************OWASimplified_VirtualSportsReport_TC007*******************************\\
        	//OWASimplified_VirtualSportsReport_TC007: Verify that user export to excel without error
        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC007: Verify that user export to excel without error","name");
       		CommonFunc.writeLogReport("Step 1. Check all Operators/Resellers","info");
        	Control.Check(selenium,OWASimplified_UIVirtualSportsReport.chkSelectAllResellers,timeoutSecond,fCommon);

        	CommonFunc.writeLogReport("Step 2. Click on Export excel icon","info");
        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.icoExportExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Close the popup","info");
        	Thread.Sleep(timeoutSecond);
        	selenium.ChooseCancelOnNextConfirmation();
        	
        	CommonFunc.writeLogReport("VP. The export function work without error","info");
        	Control.checkControlExist(selenium,OWASimplified_UIVirtualSportsReport.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWASimplified_VirtualSportsReport_TC008*******************************\\
        	//OWASimplified_VirtualSportsReport_TC008: Verify that "All Sports" option are unchecked if user unchecks one of Sports
        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC008: Verify that 'All Sports' option are unchecked if user unchecks one of Sports","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck any Sports","info");
        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.chkVirtualF1,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	
        	CommonFunc.writeLogReport("VP. 'All Sports option is unchecked","info");
        	Control.verifyControlChecked(selenium,OWASimplified_UIVirtualSportsReport.chkAllSports,false,timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWASimplified_VirtualSportsReport_TC009*******************************\\
        	//OWASimplified_VirtualSportsReport_TC009: Verify that "All Sports" option are checked if user checks all of Sports
        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC009:  Verify that 'All Licensees' option are checked if user checks all of Sports","name");
        	CommonFunc.writeLogReport("Step 1. Check licensee which is unchecked at TC008","info");
        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.chkVirtualF1,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. 'All Licensees' option is unchecked","info");
        	Control.verifyControlChecked(selenium,OWASimplified_UIVirtualSportsReport.chkAllSports,true,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWASimplified_VirtualSportsReport_TC010*******************************\\
        	//OWASimplified_VirtualSportsReport_TC010: Verify that a recommend message displays after submitting without selected any Sports
        	CommonFunc.writeLogReport("OWASimplified_VirtualSportsReport_TC010: Verify that a recommend message displays after submitting without selected any Sports","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck all Sports","info");
        	Control.Uncheck(selenium,OWASimplified_UIVirtualSportsReport.chkAllSports,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWASimplified_UIVirtualSportsReport.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The required message displays","info");
        	Control.checkTextInControl(selenium,OWASimplified_UIVirtualSportsReport.msgRequiredMessage,"Please select at least one item of Sports!",timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}