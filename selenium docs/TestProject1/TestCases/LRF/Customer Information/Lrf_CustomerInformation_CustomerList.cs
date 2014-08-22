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


namespace SeleniumTests.Lrf.CustomerInformation
{
    [TestFixture]
    public class Lrf_CustomerInformation_CustomerList : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Lrf_UILeftMenu Lrf_UILeftMenu = new Lrf_UILeftMenu();
        public Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
        public Lrf_UICustomerInformation_CustomerList Lrf_UICustomerInformation_CustomerList = new Lrf_UICustomerInformation_CustomerList();
        public Lrf_UIMain Lrf_UIMain = new Lrf_UIMain();
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
        public string DataFileName = "Lrf_CustomerInformation_CustomerList.xml";
        public string strPathDataFile = "Data\\LRF\\Customer Information\\Customer List\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "LRF\\Customer Information\\Customer List\\";
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
            //Lrf_CustomerInformation_CustomerList_TC001: Verify that opening the CustomerList report page without error
           	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC001: Verify that opening the CustomerList report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the LRF site","info");
        	Lrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,Lrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the CustomerList report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkCustInfo_CustomerList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.frmMain,timeoutSecond,fCommon);
        	
        	Thread.Sleep(10000);
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC002: Verify that submitting the report without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC002: Verify that submitting the report without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on submit button","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC003: Verify that submitting the report when selecting a specific currency without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC003: Verify that submitting the report when selecting a specific currency without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency such as UUS","info");
        	Control.select(selenium,Lrf_UICustomerInformation_CustomerList.ddlCurrency,"UUS",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC004: Verify that submitting the report when uncheck Convert to EUR without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC004: Verify that submitting the report when uncheck Convert to EUR without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck Convert to EUR","info");
        	Control.Uncheck(selenium,Lrf_UICustomerInformation_CustomerList.chkConvertTo,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.tblReportContent,timeoutSecond,fCommon);
        	

        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC005: Verify that submitting the report when selecting BA on without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC005: Verify that submitting the report when selecting BA on without error","name");
        	CommonFunc.writeLogReport("Step 1. Select BA is BA","info");
        	Control.select(selenium,Lrf_UICustomerInformation_CustomerList.ddlBA,"BA",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC006: Verify that submitting the report when selecting Open status without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC006: Verify that submitting the report when selecting Open status without error","name");
        	CommonFunc.writeLogReport("Step 1. Select Open status","info");
        	Control.select(selenium,Lrf_UICustomerInformation_CustomerList.ddlStatus,"Open",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC007: Verify that submitting the report when selecting None special level without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC007: Verify that submitting the report when selecting None special level without error","name");
        	CommonFunc.writeLogReport("Step 1. Select None special level","info");
        	Control.select(selenium,Lrf_UICustomerInformation_CustomerList.ddlSpecialLevel,"None",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC008: Verify that submitting the report when entering a specific Username without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC008: Verify that submitting the report when entering a specific Username without error","name");
        	CommonFunc.writeLogReport("Step 1. Select BA is All","info");
        	Control.select(selenium,Lrf_UICustomerInformation_CustomerList.ddlBA,"All",timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("Step 2. Enter specific Username such as qatest003","info");
        	Control.addText(selenium,Lrf_UICustomerInformation_CustomerList.txtUsername,"qatest003",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on submit button","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC009: Verify that user can open Bet Setting without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC009: Verify that user can open Bet Setting without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Edit link of test user","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.lnkEditBetSetting,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("VP. Bet Setting popup is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.popBetSetting,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Post-condition: close the popup","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnExitBetSetting,timeoutSecond,fCommon);
        	
        	
        	
           	
        	
        	//Lrf_CustomerInformation_CustomerList_TC010: Verify that user can open Status edit popup without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC010: Verify that user can open Status edit popup without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Status edit of test user","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.lnkEditStatus,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("VP. Status edit popup is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.popChangeStatus,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Post-condition: close the popup","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnCancelChangeStatus,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC011: Verify that user can open Bet list without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC011: Verify that user can open Bet list without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Bet list of test user","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.lnkViewBetList,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("VP. Bet list popup is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.popBetList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Post-condition: close the popup","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnExitBetList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC012: Verify that user can open Statement without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC012: Verify that user can open Statement without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Statement of test user","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.lnkViewStatement,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("VP. Statement popup is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.popStatement,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Post-condition: close the popup","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnExitStatement,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//Lrf_CustomerInformation_CustomerList_TC013: Verify that user can open Log info without error
        	CommonFunc.writeLogReport("Lrf_CustomerInformation_CustomerList_TC013: Verify that user can open Log info without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Log info of test user","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.lnkViewLogInfo,timeoutSecond,fCommon);
        	
        	
        	CommonFunc.writeLogReport("VP. Log info popup is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UICustomerInformation_CustomerList.popLogInfo,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Post-condition: close the popup","info");
        	Control.click(selenium,Lrf_UICustomerInformation_CustomerList.btnExitLogInfo,timeoutSecond,fCommon);
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	Lrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}