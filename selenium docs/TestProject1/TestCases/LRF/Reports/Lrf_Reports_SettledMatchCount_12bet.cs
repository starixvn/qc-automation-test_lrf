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


namespace SeleniumTests.Lrf.Reports
{
    [TestFixture]
    public class Lrf_Reports_SettledMatchCount_12bet : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Lrf_UILeftMenu Lrf_UILeftMenu = new Lrf_UILeftMenu();
        public Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
        public Lrf_UIReports_SettledMatchCount Lrf_UIReports_SettledMatchCount = new Lrf_UIReports_SettledMatchCount();
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
        public string DataFileName = "Lrf_Reports_SettledMatchCount.xml";
        public string strPathDataFile = "Data\\LRF\\Reports\\Settled Match Count\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "LRF\\Reports\\Settled Match Count\\";
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
 			//Lrf_Reports_SettledMatchCount_TC001: Verify that opening the Settled Match Count report page without error
           	CommonFunc.writeLogReport("Lrf_Reports_SettledMatchCount_TC001: Verify that opening the Settled Match Count report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the LRF site","info");
        	Lrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,Lrf_UIMain.btnMansion88,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the Settled Match Count report","info");
        	Control.click(selenium,Lrf_UILeftMenu.lnkReports_SettledMatchCount,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,Lrf_UIReports_SettledMatchCount.tblSettledMatchCount,timeoutSecond,fCommon);
        	
        	
        	
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	Lrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}