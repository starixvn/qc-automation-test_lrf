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


namespace SeleniumTests.NEWLrf.DataWarehouse
{
    [TestFixture]
    public class NEWLrf_DataWarehouse_WinLoss : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public NEWLrf_UILeftMenu NEWLrf_UILeftMenu = new NEWLrf_UILeftMenu();
        public NEWLrf_UITopMenu NEWLrf_UITopMenu = new NEWLrf_UITopMenu();
        public NEWLrf_UIDataWarehouse_WinLoss NEWLrf_UIDataWarehouse_WinLoss = new NEWLrf_UIDataWarehouse_WinLoss();
        public NEWLrf_UIMain NEWLrf_UIMain = new NEWLrf_UIMain();
        //public NEWLrf_UIDataWarehouse_WinLoss NEWLrf_UIDataWarehouse_WinLoss = new NEWLrf_UIDataWarehouse_WinLoss();
        public NEWLrf_Initialize NEWLrf_Initialize = new NEWLrf_Initialize();
        //**********************************************************************************************
        //private StringBuilder verificationErrors;

        public string browser;
        public string url;
        public string sevenday = Control.getSevenDaysBeforeTextFormat();
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
        public string DataFileName = "NEWLrf_DataWarehouse_WinLoss.xml";
        public string strPathDataFile = "Data\\NEWLrf\\Data Warehouse\\Win Loss\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "NEWLrf\\Data Warehouse\\Win Loss\\";
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
            //NEWLrf_DataWarehouse_WinLoss_TC001: Verify that opening the WinLoss report page without error
           	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC001: Verify that opening the WinLoss report page without error","name");
        	CommonFunc.writeLogReport("Step 1. Login to the NEWLrf site","info");
        	NEWLrf_Common.Login(selenium,strAdminUsername,strAdminPassword,strCaptcha,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Open a Licensee to test (Ex. Licensee 12Bet)","info");
        	Control.click(selenium,NEWLrf_UIMain.btn12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 3. Navigate to the WinLoss report","info");
        	Control.click(selenium,NEWLrf_UILeftMenu.lnkDataWarehouse_WinLoss,timeoutSecond,fCommon);
        	Thread.Sleep(10000);
        	CommonFunc.writeLogReport("VP. The page is opened without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.frmMain,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC002: Verify that submitting the report without error
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC002: Verify that submitting the report without error","name");
			CommonFunc.writeLogReport("Step 1. Enter seven date before into from date","info");
        	Control.addText(selenium,NEWLrf_UIDataWarehouse_WinLoss.txtFromdate,sevenday,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC003: Verify that export without error
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC003: Verify that export without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck Convert to EUR","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.icoExporttoExcel,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	

        	
        	
        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC004: Verify that submitting the report when selecting a specific currency without error
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC004: Verify that submitting the report when selecting a specific currency without error","name");
        	CommonFunc.writeLogReport("Step 1. Select a specific currency such as UUS","info");
        	Control.select(selenium,NEWLrf_UIDataWarehouse_WinLoss.ddlCurrency,"UUS",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC005: Verify that submitting the report when uncheck Convert to EUR without error
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC005: Verify that submitting the report when uncheck Convert to EUR without error","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck Convert to EUR","info");
        	Control.Uncheck(selenium,NEWLrf_UIDataWarehouse_WinLoss.chkConvertTo,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	

        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC006: Verify that submitting the report by Month
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC006: Verify that submitting the report by Month","name");
        	CommonFunc.writeLogReport("Step 1. Select Month","info");
        	Control.select(selenium,NEWLrf_UIDataWarehouse_WinLoss.ddlReportBy,"Month",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	

        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC007: Verify that submitting the report by Currency
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC007: Verify that submitting the report by Currency","name");
        	CommonFunc.writeLogReport("Step 1. Select Currency","info");
        	Control.select(selenium,NEWLrf_UIDataWarehouse_WinLoss.ddlReportBy,"Currency",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	

        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC008: Verify that submitting the report by Bet type
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC008: Verify that submitting the report by Bet type","name");
        	CommonFunc.writeLogReport("Step 1. Select Bet type","info");
        	Control.select(selenium,NEWLrf_UIDataWarehouse_WinLoss.ddlReportBy,"Bet type",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC009: Verify that submitting the report by League
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC009: Verify that submitting the report by League","name");
        	CommonFunc.writeLogReport("Step 1. Select League","info");
        	Control.select(selenium,NEWLrf_UIDataWarehouse_WinLoss.ddlReportBy,"League",timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        		
        	//NEWLrf_DataWarehouse_WinLoss_TC010: Verify that submitting the report by Normal
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC009: Verify that submitting the report by Normal","name");
        	CommonFunc.writeLogReport("Step 1. Select Normal","info");
        	Control.Check(selenium,NEWLrf_UIDataWarehouse_WinLoss.rdoNormal,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        	
        	
        	
        	//NEWLrf_DataWarehouse_WinLoss_TC011: Verify that submitting the report by No Draws For Turnover Only
        	CommonFunc.writeLogReport("NEWLrf_DataWarehouse_WinLoss_TC009: Verify that submitting the report by No Draws For Turnover Only","name");
        	CommonFunc.writeLogReport("Step 1. Select No Draws For Turnover Only","info");
        	Control.Check(selenium,NEWLrf_UIDataWarehouse_WinLoss.rdoNoDrawsForTurnoverOnly,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on submit button","info");
        	Control.click(selenium,NEWLrf_UIDataWarehouse_WinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForFrameToLoad("//Warehouse/Winloss?showsb=true&showrb=true&showng=true&showba=true&showlc=true&rdoExcludeTesting=true","360000");
        	
        	CommonFunc.writeLogReport("VP. The page is load without error","info");
        	Control.checkControlExist(selenium,NEWLrf_UIDataWarehouse_WinLoss.tblReportContent,timeoutSecond,fCommon);
        	
        		
        		
        	//Post-condition: logout the site
        	CommonFunc.writeLogReport("Post-condition: logout the site","info");
        	NEWLrf_Common.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}