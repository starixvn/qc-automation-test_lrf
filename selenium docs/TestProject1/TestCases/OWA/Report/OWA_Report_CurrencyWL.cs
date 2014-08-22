using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
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


namespace SeleniumTests.OWA.Report
{
    [TestFixture]
    public class OWA_Report_CurrencyWL : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
       	public OWA_UIMainPage OWA_UIMainPage = new OWA_UIMainPage();
       	public OWA_UICurrencyWinLoss OWA_UICurrencyWinLoss = new OWA_UICurrencyWinLoss();
		      	
       	
        //private StringBuilder verificationErrors;
        public string strAdminUsername;
        public string strAdminPassword;
        public string browser;
        public string disabled = "disabled";
        public string url;
        public string strtimeout = "180000";
        public string server;
        public int port;
        public int timeoutSecond;
        private string strTmpLinkReport = "";
        public string strLinkReportFile { get; set; }
        public int numOfPassed { get; set; }
        public int numOfFailed { get; set; }
        public int numOfError { get; set; }

        //*******YOU HAVE TO EDIT THE PATH AND NAME OF DATA FILE WHICH YOU LOAD DATA FROM (ex: "Handicap-OverUnder-Live.xml", Path: "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string DataFileName = "OWA_Report_CurrencyWL.xml";
        public string strPathDataFile = "Data\\OWA\\Report\\CurrencyWinLoss\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Report\\CurrencyWinLoss\\";

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
        	//OWA_Report_CurrencyWL_TC001: Verify that there is no error when navigate to Currency Win Loss report page"
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC001: Verify that there is no error when navigate to Currency Win Loss report page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Currency Win Loss report page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkCurWinLoss,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Currency Win Loss report page","info");
        	Control.checkControlExist(selenium,OWA_UICurrencyWinLoss.fraCurrencyWinLossPage,timeoutSecond,fCommon);
        	
        	
        	
        	//OWA_Report_CurrencyWL_TC002: Verify that all default checked-boxes are checked"
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC002: Verify that all default checked boxes are checked","name");
        	CommonFunc.writeLogReport("Step 1. Get all default checked-boxes status","info");
        	bool[] group2 = new bool[]
        	{
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkAllProduct,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkSportsBook,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkRacing,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkNumberGame,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkBA,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.rdoMYRconvert,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkSelectAllLicensees,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkAllBCHReseller,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chk12Bet,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkalog,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkasiabet88,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkBodog,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkTLC,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkAllBoping,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkMacaubet,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkTycoon,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkAllCozni,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkHAIFA,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkAllLDL,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkDELA,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkmansion88,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkMayFair,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkSunGame,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkZzun88,timeoutSecond,fCommon)
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkAllStarlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chk12betStarlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkalogStarlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkasiabet88Starlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkbodogStarlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkDELAStarlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkMayFairStarlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkTLCStarlit,timeoutSecond,fCommon),
//        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.chkZzun88Starlit,timeoutSecond,fCommon)
        	};
        		
        	CommonFunc.writeLogReport("VP. Verify that all default checked-boxes are checked","info");
        	Control.verifyMultipleCheckboxesStatus(selenium,group2,true,timeoutSecond,fCommon);
        			
        	
        	
        	
        	
        	//OWA_Report_CurrencyWL_TC003: Verify that all default uncheck-boxes are unchecked"
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC003: Verify that all default uncheck-boxes are unchecked","name");
        	CommonFunc.writeLogReport("Step 1. Get all default uncheck-boxes status","info");
        	bool[] group3 = new bool[]
        	{
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.rdoEURconvert,timeoutSecond,fCommon),
        		Control.getCheckboxStatus(selenium,OWA_UICurrencyWinLoss.rdoUSDconvert,timeoutSecond,fCommon),
        	};
        		
        	CommonFunc.writeLogReport("VP. Verify that all default uncheck-boxes are unchecked","info");
        	Control.verifyMultipleCheckboxesStatus(selenium,group3,false,timeoutSecond,fCommon);
        	
        	
        	
        	
        	

        	//OWA_Report_CurrencyWL_TC004: Verify that user can submit to view report without error
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC004: Verify that user can submit to view report without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit","info");
        	Control.click(selenium,OWA_UICurrencyWinLoss.btnSubmit,timeoutSecond,fCommon);
        	selenium.WaitForPageToLoad(strtimeout);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UICurrencyWinLoss.tblReportResult,timeoutSecond,fCommon);
        	
        		

        	
        	
        	
        	
        	//OWA_Report_CurrencyWL_TC005: Verify that "All Licensees" option are checked if user checks all of licensees
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC005:  Verify that 'All Licensees' option are checked if user checks all of licensees","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck any licensee","info");
        	Control.Uncheck(selenium,OWA_UICurrencyWinLoss.chk12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Check licensee which is unchecked","info");
        	Control.Check(selenium,OWA_UICurrencyWinLoss.chk12Bet,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. 'All Licensees option is unchecked'","info");
        	Control.verifyControlChecked(selenium,OWA_UICurrencyWinLoss.chkSelectAllLicensees,true,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Report_CurrencyWL_TC006: Verify that sporttype is disabled when Sportbook is unchecked.
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC006: Verify that sporttype is disabled when Sportbook is unchecked","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck Sportbook option","info");
        	Control.Uncheck(selenium,OWA_UICurrencyWinLoss.chkSportsBook,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Sporttype is disabled","info");
        	Control.verifyControlIsDisable(selenium,OWA_UICurrencyWinLoss.ddlSelectSportType,disabled,timeoutSecond,fCommon);

        	
        	
			
        	
        	//OWA_Report_CurrencyWL_TC007: Verify that sporttype is enable when Sportbook is checked.
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC007: Verify that sporttype is enable when Sportbook is checked","name");
        	CommonFunc.writeLogReport("Step 1. Check Sportbook option","info");
        	Control.Check(selenium,OWA_UICurrencyWinLoss.chkSportsBook,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Sporttype is enable","info");
        	Control.verifyControlIsEnable(selenium,OWA_UICurrencyWinLoss.ddlSelectSportType,disabled,timeoutSecond,fCommon);

        	
        	
        	
        	
        	//OWA_Report_CurrencyWL_TC008: Verify that bettype is disabled when all products are unchecked.
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC008: Verify that bettype is disabled when all products are unchecked","name");
        	CommonFunc.writeLogReport("Step 1. UnCheck all products options","info");
        	Control.Uncheck(selenium,OWA_UICurrencyWinLoss.chkAllProduct,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Sporttype is disable","info");
        	Control.verifyControlIsDisable(selenium,OWA_UICurrencyWinLoss.ddlSelectBetType,disabled,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Report_CurrencyWL_TC009: Verify that a recommend message displays after submitting without selected any product
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC009: Verify that a recommend message displays after submitting without selected any product","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit","info");
        	Control.click(selenium,OWA_UICurrencyWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The required message displays","info");
        	Control.checkControlExist(selenium,OWA_UICurrencyWinLoss.msgRequiredProduct,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	//OWA_Report_CurrencyWL_TC010: Verify that a recommend message displays after submitting without selected any Licensee
        	CommonFunc.writeLogReport("OWA_Report_CurrencyWL_TC010: Verify that a recommend message displays after submitting without selected any Licensee","name");
        	CommonFunc.writeLogReport("Step 1. Uncheck all licensees","info");
        	Control.Uncheck(selenium,OWA_UICurrencyWinLoss.chkSelectAllLicensees,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWA_UICurrencyWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The required message displays","info");
        	Control.checkControlExist(selenium,OWA_UICurrencyWinLoss.msgRequiredLicensee,timeoutSecond,fCommon);
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        	
        	
        	
        	
         
        }
        
      }
        
    }
    
