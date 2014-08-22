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

namespace SeleniumTests.OWA.Report
{
    [TestFixture]
    public class OWA_Report_TotalTransaction : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
       	public OWA_UIMainPage OWA_UIMainPage = new OWA_UIMainPage();
       	public OWA_UITotalTransaction OWA_UITotalTransaction = new OWA_UITotalTransaction();

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
        public string DataFileName = "OWA_OWA_Report_TotalTransaction.xml";
        public string strPathDataFile = "Data\\OWA\\Report\\TotalTransaction\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Report\\TotalTransaction\\";

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
        	//OWA_Report_TotalTransaction_TC001: Verify that there is no error when navigate to Total Transaction page"
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC001: Verify that there is no error when navigate to Total Transaction page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Total Transaction page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkTotalTrans,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Total Transaction page","info");
        	Control.checkControlExist(selenium,OWA_UITotalTransaction.fraTotalTransactionPage,timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWA_Report_TotalTransaction_TC002*******************************\\
        	//OWA_Report_TotalTransaction_TC002: Verify that user can submit to view report without error
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC002: Verify that user can submit to view report without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit","info");
        	Control.click(selenium,OWA_UITotalTransaction.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UITotalTransaction.tblReportResult,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	
        	
        	
        			//****************************OWA_Report_TotalTransaction_TC003*******************************\\
        	//OWA_Report_TotalTransaction_TC003: Verify that "All Licensees" option are unchecked if user unchecks one of licensees
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC003: Verify that 'All Licensees' option are unchecked if user unchecks one of licensees","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck any licensee","info");
        	Control.Uncheck(selenium,OWA_UITotalTransaction.chk12Bet,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	
        	CommonFunc.writeLogReport("VP. 'All Licensees' option is unchecked","info");
        	Control.verifyControlChecked(selenium,OWA_UITotalTransaction.chkSelectAllLicensees,false,timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWA_Report_TotalTransaction_TC004*******************************\\
        	//OWA_Report_TotalTransaction_TC004: Verify that "All Licensees" option are checked if user checks all of licensees
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC004:  Verify that 'All Licensees' option are checked if user checks all of licensees","name");
        	CommonFunc.writeLogReport("Step 1. Check licensee which is unchecked at TC003","info");
        	Control.Check(selenium,OWA_UITotalTransaction.chk12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. 'All Licensees' option is unchecked","info");
        	Control.verifyControlChecked(selenium,OWA_UITotalTransaction.chkSelectAllLicensees,true,timeoutSecond,fCommon);
        	
        	
        	
        			//****************************OWA_Report_TotalTransaction_TC005*******************************\\
        	//OWA_Report_TotalTransaction_TC005: Verify that sporttype is disabled when Sportbook is unchecked.
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC005: Verify that sporttype is disabled when Sportbook is unchecked","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck Sportbook option","info");
        	Control.Uncheck(selenium,OWA_UITotalTransaction.chkSBProduct,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Sporttype is disabled","info");
        	Control.verifyControlIsDisable(selenium,OWA_UITotalTransaction.ddlSportType,"disabled",timeoutSecond,fCommon);

			
        	
        			//****************************OWA_Report_TotalTransaction_TC006*******************************\\
        	//OWA_Report_TotalTransaction_TC006: Verify that sporttype is enable when Sportbook is checked.
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC006: Verify that sporttype is enable when Sportbook is checked","name");
        	CommonFunc.writeLogReport("Step 1. Check Sportbook option","info");
        	Control.Check(selenium,OWA_UITotalTransaction.chkSBProduct,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Sporttype is enable","info");
        	Control.verifyControlIsEnable(selenium,OWA_UITotalTransaction.ddlSportType,"disabled",timeoutSecond,fCommon);
        	
        	
        	
        	
        			//****************************OWA_Report_TotalTransaction_TC007*******************************\\
        	//OWA_Report_TotalTransaction_TC007: Verify that bettype is disabled when all products are unchecked.
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC007: Verify that bettype is disabled when all products are unchecked","name");
        	CommonFunc.writeLogReport("Step 1. UnCheck all products options","info");
        	Control.Uncheck(selenium,OWA_UITotalTransaction.chkAllProduct,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Sporttype is disable","info");
        	Control.verifyControlIsDisable(selenium,OWA_UITotalTransaction.ddlBetType,"disabled",timeoutSecond,fCommon);
        	
        	
        	
        			//****************************OWA_Report_TotalTransaction_TC008*******************************\\
        	//OWA_Report_TotalTransaction_TC008: Verify that a recommend message displays after submitting without selected any product
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC008: Verify that a recommend message displays after submitting without selected any product","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit","info");
        	Control.click(selenium,OWA_UITotalTransaction.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The required message displays","info");
        	Control.checkTextInControl(selenium,OWA_UITotalTransaction.msgRequiredMessage,"Please choose at least ONE Product!",timeoutSecond,fCommon);
        	
        	
        	
        			//****************************OWA_Report_TotalTransaction_TC009*******************************\\
        	//OWA_Report_TotalTransaction_TC009: Verify that a recommend message displays after submitting without selected any Licensee
        	CommonFunc.writeLogReport("OWA_Report_TotalTransaction_TC009: Verify that a recommend message displays after submitting without selected any Licensee","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck all licensees","info");
        	Control.Uncheck(selenium,OWA_UITotalTransaction.chkSelectAllLicensees,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWA_UITotalTransaction.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The required message displays","info");
        	Control.checkTextInControl(selenium,OWA_UITotalTransaction.msgRequiredMessage,"Please select a Licensee!",timeoutSecond,fCommon);
        	
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}