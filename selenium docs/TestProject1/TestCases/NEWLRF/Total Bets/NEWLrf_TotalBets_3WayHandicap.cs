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


namespace SeleniumTests.NEWLrf.TotalBets
{
    [TestFixture]
    public class NEWLrf_TotalBets_3WayHandicap : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public NEWLrf_UILeftMenu NEWLrf_UILeftMenu = new NEWLrf_UILeftMenu();
        public NEWLrf_UITopMenu NEWLrf_UITopMenu = new NEWLrf_UITopMenu();
        public NEWLrf_UITotalBets_3WayHandicap NEWLrf_UITotalBets_3WayHandicap = new NEWLrf_UITotalBets_3WayHandicap();
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
        public string DataFileName = "3WayHandicap.xml";
        public string strPathDataFile = "Data\\NEWLrf\\Total Bets\\3-Way Handicap\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "NEWLrf\\Total Bets\\3-Way Handicap\\";
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
            //NEWLrf_TotalBets_3WayHandicap_TC001: Verify that opening the 3WayHandicap total bets page without error
           	CommonFunc.writeLogReport("NEWLrf_TotalBets_3WayHandicap_TC001: Verify that opening the 3WayHandicap total bets page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the NEWLrf site","info");
        	NEWLrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,NEWLrf_UIMain.btnMansion88,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the 3WayHandicap total bets","info");
        	Control.click(selenium,NEWLrf_UILeftMenu.lnkTotalBets_3WayHandicap,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UITotalBets_3WayHandicap.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	//NEWLrf_TotalBets_3WayHandicap_TC002: Verify that the 3WayHandicap total bets page is exported without error
           	CommonFunc.writeLogReport("NEWLrf_TotalBets_3WayHandicap_TC002: Verify that the 3WayHandicap total bets page is exported without error","name");
           	CommonFunc.writeLogReport("Step 1. Click on Export to Excel icon","info");
           	Control.click(selenium,NEWLrf_UITotalBets_3WayHandicap.icoExportToExcel,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The content is exported without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UITotalBets_3WayHandicap.tblDataContent,timeoutSecond,fCommon);
        	
        	
        	
        	//NEWLrf_TotalBets_3WayHandicap_TC003: Verify that the 3WayHandicap total bets page is submitted without error
           	CommonFunc.writeLogReport("NEWLrf_TotalBets_3WayHandicap_TC003: Verify that the 3WayHandicap total bets page is submitted without error","name");
           	CommonFunc.writeLogReport("Step 1. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UITotalBets_3WayHandicap.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The page is submitted without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UITotalBets_3WayHandicap.tblDataContent,timeoutSecond,fCommon);
        	
        	
        	
        	

        	
        	
        	//NEWLrf_TotalBets_3WayHandicap_TC004: Verify that the 3WayHandicap total bets page is submitted after changing Currency type without error
           	CommonFunc.writeLogReport("NEWLrf_TotalBets_3WayHandicap_TC004: Verify that the 3WayHandicap total bets page is submitted after changing Currency type without error","name");
           	CommonFunc.writeLogReport("Step 1. Select other Currency type (Ex. USD)","info");
           	Control.select(selenium,NEWLrf_UITotalBets_3WayHandicap.ddlCurrency,"USD",timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UITotalBets_3WayHandicap.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The page is submitted without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UITotalBets_3WayHandicap.tblDataContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_TotalBets_3WayHandicap_TC005: Verify that the 3WayHandicap total bets page is submitted after Uncheck 'Convert to EUR' without error
           	CommonFunc.writeLogReport("NEWLrf_TotalBets_3WayHandicap_TC005: Verify that the 3WayHandicap total bets page is submitted after Uncheck 'Convert to EUR' without error","name");
           	CommonFunc.writeLogReport("Step 1. Uncheck 'Convert to EUR'","info");
           	Control.Uncheck(selenium,NEWLrf_UITotalBets_3WayHandicap.chkConvertTo,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("Step 2. Click on Submit button","info");
           	Control.click(selenium,NEWLrf_UITotalBets_3WayHandicap.btnSubmit,timeoutSecond,fCommon);
           	
           	CommonFunc.writeLogReport("VP. The page is submitted without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UITotalBets_3WayHandicap.tblDataContent,timeoutSecond,fCommon);
        	
        	      	
        	
        	
        	
        	//Post-condition: close export popup and logout the site
        	NEWLrf_Common.Logout(selenium,timeoutSecond,fCommon);

        }
    }
}