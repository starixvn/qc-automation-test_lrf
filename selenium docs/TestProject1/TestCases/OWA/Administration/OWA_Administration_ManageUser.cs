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
    public class OWA_Administration_ManageUser : ITestCase
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
        public string strPathDataFile = "Data\\OWA\\Administration\\ManageUser\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Administration\\ManageUser\\";

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
        	//OWA_Administration_ManageUser_TC001: Verify that there is no error when navigate to Manage User page"
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC001: Verify that there is no error when navigate to Manage User page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Manage User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkManageUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Manage User page","info");
        	Control.checkControlExist(selenium,OWA_UIManageUser.mainManageUserPage,timeoutSecond,fCommon);
        	
        	


        	
        	//OWA_Administration_ManageUser_TC002: Verify that user can open Create New Group page
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC002: Verify that user can open Create New Group page","name");
        	CommonFunc.writeLogReport("Step 1. Click on New Group button","info");
        	Control.click(selenium,OWA_UIManageUser.btnNewGroup,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The Create Group page is opened without error","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep1,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageUser_TC003: Verify that user can open Create New User page
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC003: Verify that user can open Create New User page","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkManageUser,timeoutSecond,fCommon);
        			
        	CommonFunc.writeLogReport("Step 2. Click on New User button","info");
        	Control.click(selenium,OWA_UIManageUser.btnNewUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The Create User page is opened without error","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraCreatePage,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageUser_TC004: Verify that user can search existed user without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC004: Verify that user can search existed user without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkManageUser,timeoutSecond,fCommon);
        			
        	CommonFunc.writeLogReport("Step 2. Enter existed user into search text box","info");
        	//get username which will be selected to search
        	string username1 = Control.getText(selenium,OWA_UIManageUser.lnkEditExistUser,timeoutSecond,fCommon);
        	Control.addText(selenium,OWA_UIManageUser.txtSearchUser,username1,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on search button","info");
        	Control.click(selenium,OWA_UIManageUser.btnSearch,timeoutSecond,fCommon);
        	string username2 = Control.getText(selenium,OWA_UIManageUser.lnkEditExistUser,timeoutSecond,fCommon);             
        	
        	CommonFunc.writeLogReport("VP. The existed user is shown","info");
        	Control.verifyEquals(selenium,username2,username1,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageUser_TC005: Verify that user can open active user popup without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC005: Verify that user can open active user popup without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkManageUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on active user button","info");
        	Control.click(selenium,OWA_UIManageUser.btnActiveUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User opens the Active/Inactive popup without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageUser.btnConfirmNo,timeoutSecond,fCommon);
        	//-----------Post Condition: Click No to close the popup---------//
        	Control.click(selenium,OWA_UIManageUser.btnConfirmNo,timeoutSecond,fCommon);
        	
        	
        	



        	//OWA_Administration_ManageUser_TC006: Verify that user can open Change Password of user without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC006: Verify that user can open Change Password of user without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkManageUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Change Password button","info");
        	Control.click(selenium,OWA_UIManageUser.btnChangePassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User opens the Change Password popup without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageUser.btnCancelNewPassword,timeoutSecond,fCommon);
        	//-----------Post Condition: Click No to close the popup---------//
        	Control.click(selenium,OWA_UIManageUser.btnCancelNewPassword,timeoutSecond,fCommon);
        	
        	
        



        	//OWA_Administration_ManageUser_TC007: Verify that user can open permission of user without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC007: Verify that user can open permission of user without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkManageUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on user permission button","info");
        	Control.click(selenium,OWA_UIManageUser.btnEditUserPermission,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User opens the permission popup without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageUser.popEditUserPermission,timeoutSecond,fCommon);
        	//-----------Post Condition: Click Submit to close the popup---------//
        	Control.click(selenium,OWA_UIManageUser.btnExitUserPermissionPopup,timeoutSecond,fCommon);
        	
        	
        	
        	


        	//OWA_Administration_ManageUser_TC008: Verify that user can open licensee of user without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageUser_TC008: Verify that user can open licensee of user without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage User page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkManageUser,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on user licensee button","info");
        	Control.click(selenium,OWA_UIManageUser.btnEditUserLicensee,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User opens the licensee popup without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageUser.popEditUserLicensee,timeoutSecond,fCommon);
        	//-----------Post Condition: Click Submit to close the popup---------//
        	Control.click(selenium,OWA_UIManageUser.btnExitUserLicenseePopup,timeoutSecond,fCommon);
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}