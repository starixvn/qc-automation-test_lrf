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


namespace SeleniumTests.Lrf.AccountManagement
{
    [TestFixture]
    public class NEWLrf_AccountManagement_ManageAccount : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public NEWLrf_UILeftMenu NEWLrf_UILeftMenu = new NEWLrf_UILeftMenu();
        public NEWLrf_UITopMenu NEWLrf_UITopMenu = new NEWLrf_UITopMenu();
        public NEWLrf_UIAccountManagement_ManageAccount NEWLrf_UIAccountManagement_ManageAccount = new NEWLrf_UIAccountManagement_ManageAccount();
        public NEWLrf_UIMain NEWLrf_UIMain = new NEWLrf_UIMain();
        //public NEWLrf_UIAccountManagement_ManageAccount NEWLrf_UIAccountManagement_ManageAccount = new NEWLrf_UIAccountManagement_ManageAccount();
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
        public string DataFileName = "NEWLrf_AccountManagement_ManageAccount_01.xml";
        public string strPathDataFile = "Data\\LRF\\Account Management\\Manage Account\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "LRF\\Account Management\\Manage Account\\";
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
            //NEWLrf_AccountManagement_ManageAccount_TC001: Verify that opening the WinLoss report page without error
           	CommonFunc.writeLogReport("NEWLrf_AccountManagement_ManageAccount_TC001: Verify that opening the WinLoss report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the LRF site","info");
        	NEWLrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,NEWLrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the ManageAccount","info");
        	Control.click(selenium,NEWLrf_UILeftMenu.lnkAccountManagement_ManageAccount,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIAccountManagement_ManageAccount.tblContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	 //NEWLrf_AccountManagement_ManageAccount_TC002: Verify that opening reset password without error
           	CommonFunc.writeLogReport("NEWLrf_AccountManagement_ManageAccount_TC002: Verify that opening reset password without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Reset of tester02","info");
        	Control.click(selenium,NEWLrf_UIAccountManagement_ManageAccount.lnkResetPassWord,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The popup is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIAccountManagement_ManageAccount.txtPassword,timeoutSecond,fCommon);
        	//close popup
        	Control.click(selenium,NEWLrf_UIAccountManagement_ManageAccount.btnClose,timeoutSecond,fCommon);
        	
        	
        	
        	
        	 //NEWLrf_AccountManagement_ManageAccount_TC003: Verify that opening edit account without error
           	CommonFunc.writeLogReport("NEWLrf_AccountManagement_ManageAccount_TC003: Verify that opening edit account without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Edit account of tester02","info");
        	Control.click(selenium,NEWLrf_UIAccountManagement_ManageAccount.lnkEditAccount,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The popup is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIAccountManagement_ManageAccount.txtFirstname,timeoutSecond,fCommon);
        	//close popup
        	Control.click(selenium,NEWLrf_UIAccountManagement_ManageAccount.btnClose,timeoutSecond,fCommon);
        
        	
        	
        	
        	
        	 //NEWLrf_AccountManagement_ManageAccount_TC004: Verify that opening edit permission without error
           	CommonFunc.writeLogReport("NEWLrf_AccountManagement_ManageAccount_TC004: Verify that opening edit permission without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Edit permission of tester02","info");
        	Control.click(selenium,NEWLrf_UIAccountManagement_ManageAccount.lnkEditPermission,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The popup is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIAccountManagement_ManageAccount.chkTotalBets,timeoutSecond,fCommon);
        	
        		
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	NEWLrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}