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
    public class OWA_Report_LicenseeWL : ITestCase
    {
        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
       	public OWA_UIMainPage OWA_UIMainPage = new OWA_UIMainPage();
       	public OWA_UICommon OWA_UICommon = new OWA_UICommon();
       	public OWA_UILicenseeWinLoss OWA_UILicenseeWinLoss = new OWA_UILicenseeWinLoss();

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
        public string DataFileName = "OWA_Report_LicenseeWL_01.xml";
        public string strPathDataFile = "Data\\OWA\\Report\\LicenseeWinLoss\\";

      

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "OWA\\Report\\LicenseeWinLoss\\";

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
        	//OWA_Report_LicenseeWL_TC001: Verify that there is no error when navigate to Licensee Win Loss report page"
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC001: Verify that there is no error when navigate to Licensee Win Loss report page","name");
        	CommonFunc.writeLogReport("Step 1. Login to the OWA site","info");
        	OWA_MainFunction.Login(selenium,strAdminUsername,strAdminPassword,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Navigate to Summary Licensee Win Loss report page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkLicWinLoss,timeoutSecond,fCommon);
        	Thread.Sleep(1000);
        	if(selenium.IsElementPresent(OWA_UILicenseeWinLoss.lnkSummary))
        		{
        			Control.click(selenium,OWA_UILicenseeWinLoss.lnkSummary,timeoutSecond,fCommon);
        		}
        	
        	CommonFunc.writeLogReport("VP. There is no error when navigate to Licensee Win Loss report page","info");
        	Control.checkControlExist(selenium,OWA_UILicenseeWinLoss.fraLicenseeWinLossPage,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWA_Report_LicenseeWL_TC002*******************************\\
        	//OWA_Report_LicenseeWL_TC002: Verify that user can submit to view report without error
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC002: Verify that user can submit to view report without error","name");
        	CommonFunc.writeLogReport("Step 1. Enter 7days ago into From date","info");
        	string lastsevenday =Control.getSevenDaysBeforeTextFormat();
        	Control.addText(selenium,OWA_UILicenseeWinLoss.txtFromDate,lastsevenday,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Click on Submit","info");
        	Control.click(selenium,OWA_UILicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	
        	CommonFunc.writeLogReport("VP. The report is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UILicenseeWinLoss.tblReportResult,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        	
        			//****************************OWA_Report_LicenseeWL_TC003*******************************\\
        	//OWA_Report_LicenseeWL_TC003: Verify 'Convert figures to' is enable when select a currency differ with 'All'
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC003: Verify 'Convert figures to' is enable when select a currency except 'All'","name");
        	CommonFunc.writeLogReport("Step 1. Select other Currency except 'All' (ex. select AUD)","info");
        	Control.select(selenium,OWA_UILicenseeWinLoss.ddlCurrency,"AUD",timeoutSecond,fCommon);

        	CommonFunc.writeLogReport("VP. 'Convert figures to' is enable","info");
        	Control.verifyControlIsEnable(selenium,OWA_UILicenseeWinLoss.chkConverCurrency,"disable",timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWA_Report_LicenseeWL_TC004*******************************\\
        	//OWA_Report_LicenseeWL_TC004: Verify 'Convert figures to' is still uncheck after submitting with uncheck value at the first submitting time
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC004: Verify 'Convert figures to' is still uncheck after submitting with uncheck value at the first submitting time","name");
        	CommonFunc.writeLogReport("Step 1. Navigate to Summary Licensee Win Loss report page","info");
        	Control.click(selenium,OWA_UIMainPage.lnkLicWinLoss,timeoutSecond,fCommon);
        	Thread.Sleep(1000);
        	if(selenium.IsElementPresent(OWA_UILicenseeWinLoss.lnkSummary))
        		{
        			Control.click(selenium,OWA_UILicenseeWinLoss.lnkSummary,timeoutSecond,fCommon);
        		}
        	
        	CommonFunc.writeLogReport("Step 2. Select other Currency except 'All' (ex. select AUD)","info");
        	Control.select(selenium,OWA_UILicenseeWinLoss.ddlCurrency,"AUD",timeoutSecond,fCommon);		
        	
        	CommonFunc.writeLogReport("Step 3. Uncheck 'Convert figures to'","info");
        	Control.Uncheck(selenium,OWA_UILicenseeWinLoss.chkConverCurrency,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 4. Click on Submit","info");
        	Control.click(selenium,OWA_UILicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	
        	CommonFunc.writeLogReport("'Convert figures to' is still uncheck ","info");
        	Control.verifyControlChecked(selenium,OWA_UILicenseeWinLoss.chkConverCurrency,false,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWA_Report_LicenseeWL_TC005*******************************\\
        	//OWA_Report_LicenseeWL_TC005: Verify that user can switch to Detail report without error
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC005: Verify that user can switch to Detail report without error","name");
        	CommonFunc.writeLogReport("Step 1. Click on Detail link","info");
        	Control.click(selenium,OWA_UILicenseeWinLoss.lnkDetails,timeoutSecond,fCommon);
        	Thread.Sleep(timeoutSecond);
        	
        	CommonFunc.writeLogReport("VP. The details is shown without error","info");
        	Control.checkControlExist(selenium,OWA_UILicenseeWinLoss.ddlLicensee,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWA_Report_LicenseeWL_TC006*******************************\\
        	//OWA_Report_LicenseeWL_TC006: Verify that a recommend message displays after submitting without selected any Licensee
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC006: Verify that a recommend message displays after submitting without selected any Licensee","name");
        	CommonFunc.writeLogReport("Step 1. Click on Submit","info");
        	Control.click(selenium,OWA_UILicenseeWinLoss.btnSubmit,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. The required message displays","info");
        	Control.checkControlExist(selenium,OWA_UILicenseeWinLoss.msgRequiredLicensee,timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWA_Report_LicenseeWL_TC007*******************************\\
        	//OWA_Report_LicenseeWL_TC007: Verify that currency drop down list is disable 
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC007:Verify that currency drop down list is disable when unselected licensee ","name");
        	CommonFunc.writeLogReport("VP. Currency drop down list is disabled","info");
        	Control.verifyControlIsDisable(selenium,OWA_UILicenseeWinLoss.ddlCurrency,"disabled",timeoutSecond,fCommon);
        	
        	
        	
        	
        	
        			//****************************OWA_Report_LicenseeWL_TC008*******************************\\
        	//OWA_Report_LicenseeWL_TC008: Verify that currency drop down list is enable when selecting any licensee
        	CommonFunc.writeLogReport("OWA_Report_LicenseeWL_TC008:Verify that currency drop down list is enable when selecting any licensee","name");
        	CommonFunc.writeLogReport("Step 1. Select any licensee ","info");
        	Control.click(selenium,OWA_UICommon.chkBodog,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("Step 2. Uncheck IsConvert","info");
        	Control.Uncheck(selenium,OWA_UILicenseeWinLoss.chkConverCurrency,timeoutSecond,fCommon);
        	
        	CommonFunc.writeLogReport("VP. Currency drop down list is enable for uncheck/check","info");
        	Control.verifyControlChecked(selenium,OWA_UILicenseeWinLoss.chkConverCurrency,false,timeoutSecond,fCommon);
        	
        	//-----------Post Condition: Sign out---------//
        	OWA_MainFunction.Logout(selenium,timeoutSecond,fCommon);
        }
    }
}