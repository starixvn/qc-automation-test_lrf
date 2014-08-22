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
    public class OWA_Administration_CreateGroup : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public OWA_UICreateGroup OWA_UICreateGroup = new OWA_UICreateGroup();
        public OWA_UIManageGroup OWA_UIManageGroup = new OWA_UIManageGroup();
        public OWA_UIMainPage OWA_UIMainPage = new OWA_UIMainPage();

        //private StringBuilder verificationErrors;
        public string strAdminUsername;
        public string strAdminPassword;
        public string browser;
        public string url;
        public string server;
        public int port;
        public int timeoutSecond;
        private string strTmplnkReport = "";
        public string strLinkReportFile { get; set; }
        public int numOfPassed { get; set; }
        public int numOfFailed { get; set; }
        public int numOfError { get; set; }

        //*******YOU HAVE TO EDIT THE PATH AND NAME OF DATA FILE WHICH YOU LOAD DATA FROM (ex: "Handicap-OverUnder-Live.xml", Path: "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string DataFileName = "OWA_Administration_CreateGroup_01.xml";
        public string strPathDataFile = "Data\\OWA\\Administration\\CreateGroup\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Administration\\CreateGroup\\";

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
            strTmplnkReport = strPathTestCase; strPathTestCase = fCommon.strPathFolderOfSummaryReportFile + strPathTestCase;
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
                strLinkReportFile = strTmplnkReport + strReportFileName;
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
        	//OWA_Administration_CreateGroup_TC001: Verify that there is no error when clicking on New Group button"
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC001: Verify that there is no error when clicking on New Group button","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Create Group page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkCreateGroup,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Create new group page shows without error","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep1,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC002: Verify that user can go to the next step after entering all required fields
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC002: Verify that user can go to the next step after entering all required fields","name");
        	CommonFunc.writeLogReport("Step 1. Enter Group name and remark text","info");
        	Control.addText(selenium,OWA_UICreateGroup.txtGroupName,"name",timeoutSecond,fCommon);
        	Control.addText(selenium,OWA_UICreateGroup.txtRemark,"remark",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Next button to go to the next step","info");
        	//-----------get groupname and remark at the create group page
        	string[] group1 = new string[]{Control.getValue(selenium,OWA_UICreateGroup.txtGroupName,timeoutSecond,fCommon),Control.getValue(selenium,OWA_UICreateGroup.txtRemark,timeoutSecond,fCommon)};
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 2 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep2,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC003: Verify that user can go to step 3 without selecting any licensee
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC003: Verify that user can go to step 3 without selecting any licensee","name");
        	CommonFunc.writeLogReport("Step 1. Click on Next button to go to the next step","info");
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 3 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep3,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC004: Verify that user can go to step 4 without selecting any licensee
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC004: Verify that user can go to step 4 without selecting any licensee","name");
        	CommonFunc.writeLogReport("Step 1. Click on Next button to go to the next step","info");
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 4 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep4,timeoutSecond,fCommon);
        	//-----------get groupname and remark at the Summary page
        	string[] group2 = new string[]{Control.getText(selenium,OWA_UICreateGroup.lblGroupName,timeoutSecond,fCommon),Control.getText(selenium,OWA_UICreateGroup.lblRemark,timeoutSecond,fCommon)};
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC005: Verify that the correctly entered group is shown at step 4 Summary
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC005: Verify that the correctly entered group is shown at step 4 Summary","name");
        	CommonFunc.writeLogReport("VP. Correctly entered group is shown at step 4 Summary","info");
        	Control.verifyEqualsArray(selenium,group1,group2,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC006: Verify that user edit General Info by clicking on edit
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC006: Verify that user edit General Info by clicking on edit","name");
        	CommonFunc.writeLogReport("Step 1. Click on Edit button to edit General info","info");
        	Control.click(selenium,OWA_UICreateGroup.lnkEditGeneral,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 1 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep1,timeoutSecond,fCommon);
        	//-----------get groupname and remark at the create group page
        	string[] group3 = new string[]{Control.getValue(selenium,OWA_UICreateGroup.txtGroupName,timeoutSecond,fCommon),Control.getValue(selenium,OWA_UICreateGroup.txtRemark,timeoutSecond,fCommon)};
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC007: Verify that the correctly entered group still there after returning from Step 4
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC007: Verify that the correctly entered group still there after returning from Step 4","name");
        	CommonFunc.writeLogReport("VP. Correctly entered group still there","info");
        	Control.verifyEqualsArray(selenium,group2,group3,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        		
        	//OWA_Administration_CreateGroup_TC008: Verify that user edit Licensee Info by clicking on edit
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC008: Verify that user edit Licensee Info by clicking on edit","name");
        	CommonFunc.writeLogReport("Step 1. Go to Step 4","info");
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Edit button to edit Licensee info","info");
        	Control.click(selenium,OWA_UICreateGroup.lnkEditLicensee,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 2 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep2,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC009: Verify that user edit Permission Info by clicking on edit
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC009: Verify that user edit Permission Info by clicking on edit","name");
        	CommonFunc.writeLogReport("Step 1. Go to Step 4","info");
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateGroup.btnNext,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Edit button to edit Permission info","info");
        	Control.click(selenium,OWA_UICreateGroup.lnkEditPermission,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Step 3 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep3,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        	//OWA_Administration_CreateGroup_TC010: Verify that Previous function works correctly
        	CommonFunc.writeLogReport("OWA_Administration_CreateGroup_TC010: Verify that Previous function works correctly","name");
        	CommonFunc.writeLogReport("Step 1. Go to Step 1","info");
        	Control.click(selenium,OWA_UICreateGroup.btnPrevious,timeoutSecond,fCommon);
        	Control.click(selenium,OWA_UICreateGroup.btnPrevious,timeoutSecond,fCommon);

        	CommonFunc.writeLogReport("VP. Step 1 is opened","info");
        	Control.checkControlExist(selenium,OWA_UICreateGroup.fraMainStep1,timeoutSecond,fCommon);
        	//-----------Post Condition: Sign Out ---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}