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


namespace SeleniumTests.NEWLrf.CustomerReports
{
    [TestFixture]
    public class NEWLrf_CustomerReports_CustomerBalance : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public NEWLrf_UILeftMenu NEWLrf_UILeftMenu = new NEWLrf_UILeftMenu();
        public NEWLrf_UITopMenu NEWLrf_UITopMenu = new NEWLrf_UITopMenu();
        public NEWLrf_UICustomerReports_CustomerBalance NEWLrf_UICustomerReports_CustomerBalance = new NEWLrf_UICustomerReports_CustomerBalance();
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
        public string DataFileName = "NEWLrf_CustomerReports_CustomerBalance.xml";
        public string strPathDataFile = "Data\\NEWLrf\\Customer Reports\\Customer Balance\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "NEWLrf\\Customer Reports\\Customer Balance\\";
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
           //NEWLrf_CustomerReports_CustomerBalance_TC001: Verify that opening the CustomerBalance report page without error
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC001: Verify that opening the CustomerBalance report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the NEWLrf site","info");
        	NEWLrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,NEWLrf_UIMain.btnMansion88,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the CustomerBalance report","info");
        	Control.click(selenium,NEWLrf_UILeftMenu.lnkReports_CustomerBalance,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
           	
        	
        	//NEWLrf_CustomerReports_CustomerBalance_TC002_1: Verify that submitting the report without selecting any product
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC002_1: Verify that submitting without selecting any product","name");
           	CommonFunc.writeLogReport("Step 1. Select normal type","info");
           	Control.Uncheck(selenium,NEWLrf_UICustomerReports_CustomerBalance.chkSB,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. LRF notification popup shows","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.popLRFNotify,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Pre-condition: Close the popup","info");
        	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.icoClosePopup,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_CustomerReports_CustomerBalance_TC002_2: Verify that opening/closing the note popup without error
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC002_2: Verify that opening/closing the note popup without error","name");
           	CommonFunc.writeLogReport("Step 1. Open note popup","info");
           	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.icoNote,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. Note popup is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.popNote,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Pre-condition: Close the popup","info");
        	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.icoCloseNote,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
           	//NEWLrf_CustomerReports_CustomerBalance_TC003: Verify that submitting the report of all products
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC003: Verify that submitting the report of all products","name");
           	CommonFunc.writeLogReport("Step 1. Select normal type","info");
           	Control.Check(selenium,NEWLrf_UICustomerReports_CustomerBalance.chkAllProduct,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. Report shows without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.tblReportContent,timeoutSecond,fCommon);
        	
           	
           	
        	
        	
        	
        	
        	//NEWLrf_CustomerReports_CustomerBalance_TC004: Verify that submitting the report base on specific currency without error
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC004: Verify that submitting the report base on specific currency without error","name");
           	CommonFunc.writeLogReport("Step 1. Select specific currency such as USD","info");
           	Control.select(selenium,NEWLrf_UICustomerReports_CustomerBalance.ddlCurrency,"USD",timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The page is lauching without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//NEWLrf_CustomerReports_CustomerBalance_TC005: Verify that submitting the report includes Test data without error
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC005: Verify that submitting the report includes Test data without error","name");
           	CommonFunc.writeLogReport("Step 1. Uncheck Exclude Test Data","info");
           	Control.Uncheck(selenium,NEWLrf_UICustomerReports_CustomerBalance.chkExcludeTestData,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The page is lauching without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//NEWLrf_CustomerReports_CustomerBalance_TC006: Verify that submitting the report base on other Select and Sort by
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC006: Verify that submitting the report base on other Select and Sort by","name");
           	CommonFunc.writeLogReport("Step 1. Select view by top 100","info");
           	Control.select(selenium,NEWLrf_UICustomerReports_CustomerBalance.ddlSelectTopCustomer,"100",timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 2. Select 'Win' sort by","info");
           	Control.select(selenium,NEWLrf_UICustomerReports_CustomerBalance.ddlSortBy,"Win",timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 3. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The page is lauching without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.tblReportContent,timeoutSecond,fCommon);
           	
           	
        	
        	
           	
           	
        	//NEWLrf_CustomerReports_CustomerBalance_TC007: Verify that exporting the report without error
           	CommonFunc.writeLogReport("NEWLrf_CustomerReports_CustomerBalance_TC007: Verify that exporting the report without error","name");
           	CommonFunc.writeLogReport("Step 1. Click on Export to excel icon","info");
           	Control.click(selenium,NEWLrf_UICustomerReports_CustomerBalance.icoExporttoExcel,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The page is lauching without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UICustomerReports_CustomerBalance.tblReportContent,timeoutSecond,fCommon);
           	
           	
        	//Post-condition: close export popup and logout the site
        	CommonFunc.writeLogReport("Post-condition: Close the export popup","info");
        	selenium.ChooseCancelOnNextConfirmation();
        	NEWLrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}