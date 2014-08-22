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
    public class OWA_Administration_ManageGroup : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public OWA_UICreateGroup OWA_UICreateGroup = new OWA_UICreateGroup();
        public OWA_UICreateUser OWA_UICreateUser = new OWA_UICreateUser();
        public OWA_UIManageGroup OWA_UIManageGroup = new OWA_UIManageGroup();

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
        public string strPathDataFile = "Data\\OWA\\Administration\\ManageGroup\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Administration\\ManageGroup\\";

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
        	//OWA_Administration_ManageGroup_TC001: Verify that there is no error when clicking on New Group button"
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC001: Verify that there is no error when clicking on New Group button","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Manage Group page","info");
        	OWA_MainFunction.gotoManageGroup(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on Create New Group button","info");
        	OWA_ManageGroupFunction.clickCreateNewGroup(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The create New Group page is displayed","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainCreatePage,timeoutSecond,fCommon);
        	//-----------Post Condition: go to Home page---------//
        	OWA_MainFunction.gotoHomePage(selenium,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC002: Verify that there is no error when clicking on New User button"
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC002: Verify that there is no error when clicking on New User button","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage Group page","info");
        	OWA_MainFunction.gotoManageGroup(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on create New User button","info");
        	OWA_ManageGroupFunction.clickCreateNewUser(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The create New User page is displayed","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraCreatePage,timeoutSecond,fCommon);
        	//-----------Post Condition: go to Home page----------//
        	OWA_MainFunction.gotoHomePage(selenium,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC003: Verify that there is no error when clicking on an existed Group link"
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC003: Verify that there is no error when clicking on an existed Group link","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage Group page","info");
        	OWA_MainFunction.gotoManageGroup(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on an existed Group link","info");
        	//-----------get groupname and remark of the group that will be selected
        	string[] group1 = new string[]{Control.getText(selenium,OWA_UIManageGroup.lnkEditExistGroup,timeoutSecond,fCommon),Control.getText(selenium,OWA_UIManageGroup.lblRemarkGroup,timeoutSecond,fCommon)};
        	OWA_ManageGroupFunction.clickExistedGroup(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The create New User page is displayed","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraCreatePage,timeoutSecond,fCommon);
        	//-----------get groupname and remark at the Edit group page
        	string[] group2 = new string[]{Control.getValue(selenium,OWA_UICreateGroup.txtGroupName,timeoutSecond,fCommon),Control.getValue(selenium,OWA_UICreateGroup.txtRemark,timeoutSecond,fCommon)};
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC004: Verify that the correctly selected group is opened for editing
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC004: Verify that the correctly selected group is opened for editing","name");
        	CommonFunc.writeLogReport("VP. Selected group is opened for editing","info");
        	Control.verifyEqualsArray(selenium,group1,group2,timeoutSecond,fCommon);
        	//-----------Post Condition: go to Home page----------//
        	OWA_MainFunction.gotoHomePage(selenium,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC005: Verify that the user list popup is opened when clicking on the user number without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC005: Verify that the user list popup is opened when clicking on the user number without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage Group page","info");
        	OWA_MainFunction.gotoManageGroup(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Clicking on No of users of the existed group","info");
        	Control.click(selenium,OWA_UIManageGroup.lnkGroupUserList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The user list popup is opened","info");
        	Control.checkControlExist(selenium,OWA_UIManageGroup.popMainUserList,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC006: Verify that the user can drill down to editing user page by clicking on the username
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC006: Verify that the user can drill down to editing user page by clicking on the username","name");
        	CommonFunc.writeLogReport("Step 1: Click on existed User link","info");
        	
        	//-----------get username and displayname of the group that will be selected
        	string[] group3 = new string[]{Control.getText(selenium,OWA_UIManageGroup.lnkEditUser,timeoutSecond,fCommon),Control.getText(selenium,OWA_UIManageGroup.lblDisplayName,timeoutSecond,fCommon)};
        	Control.click(selenium,OWA_UIManageGroup.lnkEditUser,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The create New User page is displayed","info");
        	Control.checkControlExist(selenium,OWA_UICreateUser.fraCreatePage,timeoutSecond,fCommon);
        	
        	//-----------get username and displayname at the Edit user page
        	string[] group4 = new string[]{Control.getValue(selenium,OWA_UICreateUser.txtUsername,timeoutSecond,fCommon),Control.getValue(selenium,OWA_UICreateUser.txtDisplayName,timeoutSecond,fCommon)};
        	CommonFunc.writeLogReport("VP. Editing user page is opened without error","info");
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC007: Verify that the correctly selected user is opened for editing
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC007: Verify that the correctly selected user is opened for editing","name");
        	CommonFunc.writeLogReport("VP. Selected user is opened for editing","info");
        	Control.verifyEqualsArray(selenium,group3,group4,timeoutSecond,fCommon);
        	//-----------Post Condition: go to Home page----------//
        	Control.click(selenium,OWA_UICreateGroup.fraMainCreatePage,timeoutSecond,fCommon);
        	OWA_MainFunction.gotoHomePage(selenium,timeoutSecond,fCommon);
        	
        	
        
        		       	
        	
        	
        	//OWA_Administration_ManageGroup_TC008: Verify that user can open change password without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC008: Verify that user can open change password without error","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Manage Group page","info");
        	OWA_MainFunction.gotoManageGroup(selenium,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on No of users of the existed group","info");
        	Control.click(selenium,OWA_UIManageGroup.lnkGroupUserList,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Click on change password of the first user","info");
        	Control.click(selenium,OWA_UIManageGroup.btnChangePassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User can open change password without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageGroup.btnNewPassword,timeoutSecond,fCommon);
        	//-----------Post Condition: Cancel the action to return to user list popup----------//
        	Control.click(selenium,OWA_UIManageGroup.btnCancelNewPassword,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC009: Verify that user can view user permission without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC009: Verify that user can view user permission without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on permission button to view detail user permission","info");
        	selenium.Focus(OWA_UIManageGroup.btnEditUserPermission);
        	Control.click(selenium,OWA_UIManageGroup.btnEditUserPermission,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User can view user permission without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageGroup.popEditUserPermission,timeoutSecond,fCommon);
        	//-----------Post Condition: Close the edit user permission popup----------//
        	Control.click(selenium,OWA_UIManageGroup.btnExitUserPermissionPopup,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC010: Verify that user can view user licensee without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC010: Verify that user can view user licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on licensee button to view detail user licensee","info");
        	Control.click(selenium,OWA_UIManageGroup.btnEditUserLicensee,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User can view user licensee without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageGroup.popEditUserLicensee,timeoutSecond,fCommon);
        	//-----------Post Condition: return to manage group page----------//
        	Control.click(selenium,OWA_UIManageGroup.btnExitUserLicenseePopup,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UIManageGroup.btnExitUserListPopup,timeoutSecond,fCommon);
			
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC011: Verify that user can view group permission without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC011: Verify that user can view group permission without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on group permission link button to view detail group permission","info");
        	Control.click(selenium,OWA_UIManageGroup.lnkGroupPermission,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User can view detail group permission without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageGroup.popEditGroupPermission,timeoutSecond,fCommon);
        	//-----------Post Condition: Close the edit group permission popup----------//
        	Control.click(selenium,OWA_UIManageGroup.btnExitGroupPermissionPopup,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Administration_ManageGroup_TC012: Verify that user can view group licensee without error
        	CommonFunc.writeLogReport("OWA_Administration_ManageGroup_TC012: Verify that user can view group licensee without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on group licensee link button to view detail group licensee","info");
        	Control.click(selenium,OWA_UIManageGroup.lnkGroupLicensee,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. User can view detail group licensee without error","info");
        	Control.checkControlExist(selenium,OWA_UIManageGroup.popEditGroupLicensee,timeoutSecond,fCommon);
        	//-----------Post Condition: Close the edit group permission popup and sign out----------//
        	Control.click(selenium,OWA_UIManageGroup.btnExitGroupLicenseePopup,timeoutSecond,fCommon);
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
        
    }
}