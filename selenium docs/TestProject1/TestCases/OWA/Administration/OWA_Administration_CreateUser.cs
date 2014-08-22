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

namespace SeleniumTests.OWA.Administration
{
    [TestFixture]
    public class OWA_Administration_CreateUser : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public OWA_UICreateUser OWA_UICreateUser = new OWA_UICreateUser();
        public OWA_UICreateGroup OWA_UICreateGroup = new OWA_UICreateGroup();
        public OWA_UIManageUser OWA_UIManageUser = new OWA_UIManageUser();
       	public OWA_UIMainPage OWA_UIMainPage = new OWA_UIMainPage();

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
        public string DataFileName = "OWA_Administration_ManageGroup_01.xml";
        public string strPathDataFile = "Data\\OWA\\Administration\\CreateUser\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Administration\\CreateUser\\";

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
        	//OWA_Administration_CreateUser_TC001: Verify that there is no error when navigate to Create User page"
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC001: Verify that there is no error when navigate to Create User page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Create User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkCreateUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Create User page","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraCreatePage,timeoutSecond,fCommon);
        	
        	
        	
        				
        	//OWA_Administration_CreateUser_TC002: Verify that require message shows when user clicks next button without enter Username
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC002: Verify that require message shows when user clicks next button without enter Username","name");
        	CommonFunc.writeLogReport("Step 1. Click on Next button","info");
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Required message is shown","info");
        	Control.checkTextInControl(selenium,OWA_UICreateUser.msgRequiredField,"Username cannot be blank\nX",timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC003: Verify that require message shows when user clicks next button without enter Password
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC003: Verify that require message shows when user clicks next button without enter Password","name");
        	CommonFunc.writeLogReport("Step 1. Enter text into username","info");
        	Control.addText(selenium,OWA_UICreateUser.txtUsername,"username",timeoutSecond,fCommon);
        	//get username at step 1 which is entered
        	string username1 = Control.getValue(selenium,OWA_UICreateUser.txtUsername,timeoutSecond,fCommon);
        			
        	CommonFunc.writeLogReport("Step 2. Click on Next button","info");
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Required message is shown","info");
        	Control.checkTextInControl(selenium,OWA_UICreateUser.msgRequiredField,"Password cannot be blank\nX",timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC004: Verify that user can pass to step2 after entering username and password
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC004: Verify that user can pass to step2 after entering username and password","name");
        	CommonFunc.writeLogReport("Step 1. Enter text into password","info");
        	Control.addText(selenium,OWA_UICreateUser.txtPassword,"password",timeoutSecond,fCommon);
        			
        	CommonFunc.writeLogReport("Step 2. Click on Next button","info");
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 2 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraStep2,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC005: Verify that user can go to step 3 without selecting any licensee
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC005: Verify that user can go to step 3 without selecting any licensee","name");
        	CommonFunc.writeLogReport("Step 1. Click on Next button to go to the next step","info");
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 3 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraStep3,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC006: Verify that user can go to step 4 without selecting any licensee
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC006: Verify that user can go to step 4 without selecting any licensee","name");
        	CommonFunc.writeLogReport("Step 1. Click on Next button to go to the next step","info");
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 4 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraStep4,timeoutSecond,fCommon);
        	//get username at step 4 which is shown
        	string username2 = Control.getText(selenium,OWA_UICreateUser.lblUsername,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC007: Verify that username is shown at Step 4 correctly
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC007: Verify that username is shown at Step 4 correctly","name");
        	CommonFunc.writeLogReport("VP. Username is shown correctly","info");
        	Control.verifyEquals(selenium,username1,username2,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC008: Verify that user edit General Info by clicking on edit
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC008: Verify that user edit General Info by clicking on edit","name");
        	CommonFunc.writeLogReport("Step 1. Click on Edit button to edit General info","info");
        	Control.click(selenium,OWA_UICreateUser.lnkEditGeneral,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 1 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraStep1,timeoutSecond,fCommon);
        	//get username at step 1 which is entered
        	string username3 = Control.getValue(selenium,OWA_UICreateUser.txtUsername,timeoutSecond,fCommon);
        	
        	
        	
        	
			
        	//OWA_Administration_CreateUser_TC009: Verify that username is shown at Step 1 correctly after returning from step 4
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC009: Verify that username is shown at Step 1 correctly after returning from step 4","name");
        	CommonFunc.writeLogReport("VP. Username is shown correctly","info");
        	Control.verifyEquals(selenium,username2,username3,timeoutSecond,fCommon);
        	
        		
        		
        		
        		
        	//OWA_Administration_CreateUser_TC010: Verify that user edit Licensee Info by clicking on edit
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC010: Verify that user edit Licensee Info by clicking on edit","name");
        	CommonFunc.writeLogReport("Step 1. Go to Step 4","info");
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Edit button to edit Licensee info","info");
        	Control.click(selenium,OWA_UICreateUser.lnkEditLicensee,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 2 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraStep2,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC011: Verify that user edit Permission Info by clicking on edit
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC011: Verify that user edit Permission Info by clicking on edit","name");
        	CommonFunc.writeLogReport("Step 1. Go to Step 4","info");
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateUser.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Edit button to edit Permission info","info");
        	Control.click(selenium,OWA_UICreateUser.lnkEditPermission,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 3 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraStep3,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateUser_TC012: Verify that Previous function works correctly
        	CommonFunc.writeLogReport("OWA_Administration_CreateUser_TC012: Verify that Previous function works correctly","name");
        	CommonFunc.writeLogReport("Step 1. Go to Step 1","info");
        	Control.click(selenium,OWA_UICreateUser.btnPrevious,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateUser.btnPrevious,timeoutSecond,fCommon);

        	CommonFunc.writeLogReport("VP. Step 1 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraStep1,timeoutSecond,fCommon);
        	//-----------Post Condition: Sign Out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}