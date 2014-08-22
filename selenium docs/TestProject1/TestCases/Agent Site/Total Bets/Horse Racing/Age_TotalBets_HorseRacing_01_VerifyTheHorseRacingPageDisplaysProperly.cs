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


namespace SeleniumTests
{
    [TestFixture]
    public class Age_TotalBets_HorseRacing_01_VerifyTheHorseRacingPageDisplaysProperly : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Age_UILeftMenu Age_UILeftMenu = new Age_UILeftMenu();
        public Age_UITotalBets_HorseRacing Age_UITotalBets_HorseRacing = new Age_UITotalBets_HorseRacing();
        public Age_Initialize Age_Initialize = new Age_Initialize();
        //**********************************************************************************************
        //private StringBuilder verificationErrors;

        public string browser;
        public string url;
        public string server;
        public int port;
        public int timeoutSecond; private string strTmpLinkReport = "";
        public string strLinkReportFile { get; set; }
        public int numOfPassed { get; set; }
        public int numOfFailed { get; set; }
        public int numOfError { get; set; }

        //*******YOU HAVE TO EDIT THE PATH AND NAME OF DATA FILE WHICH YOU LOAD DATA FROM (ex: "Handicap-OverUnder-Live.xml", Path: "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string DataFileName = "Age_TotalBets_HorseRacing_01.xml";
        public string strPathDataFile = "Data\\Agent Site\\Total Bets\\Horse Racing\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "Agent Site\\Total Bets\\Horse Racing\\";
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

            browser = Age_Initialize.browser;
            port = Age_Initialize.port;
            url = Age_Initialize.url;
            server = Age_Initialize.server;

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
            XmlNodeList DataList = CommonFunc.readDataFromXmlFile(strPathDataFile + DataFileName, "//DataSet//filter");
            foreach (XmlNode Data in DataList)
            {
                //Log In Agent Site as Supper/Master/Agent level
                Age_Common.Login(selenium, Data["username"].InnerText, Data["password"].InnerText, Age_Initialize.strCaptcha, timeoutSecond, fCommon);
                ////Go to the Horse Racing page
                Age_Common.gotoLeftMenu(selenium, Age_UILeftMenu.tabMainMenu, Age_UILeftMenu.lnkParentMenu_TotalBets, Age_UILeftMenu.lnkSubMenu_TotalBets_Racing, timeoutSecond, fCommon);

                ////Verify the Horse Racing page displays properly
                //Check the Horse Racing page displays all controls lblTitle, Race column, Horse No column, Horse column, Tote column

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.lblTitle, timeoutSecond, fCommon);
                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.btnRefresh, timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colRace, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colRace, "Race", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colHorseNo, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colHorseNo, "Horse No", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colHorse, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colHorse, "Horse", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote, "Tote", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_Win, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_Win, "Win", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_Win_Total, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_Win_Total, "Total", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_Win_WinLoss, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_Win_WinLoss, "Win Loss", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_Place, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_Place, "Place", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_Place_Total, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_Place_Total, "Total", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_Place_WinLoss, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_Place_WinLoss, "Win Loss", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_WinPlace, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_WinPlace, "Win Place", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_WinPlace_Total, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_WinPlace_Total, "Total", timeoutSecond, fCommon);

                Control.checkControlExist(selenium, Age_UITotalBets_HorseRacing.colTote_WinPlace_WinLoss, timeoutSecond, fCommon);
                Control.checkTextInControl(selenium, Age_UITotalBets_HorseRacing.colTote_WinPlace_WinLoss, "Win Loss", timeoutSecond, fCommon);

                //Log Out
                Age_Common.Logout(selenium, timeoutSecond, fCommon);
            }
        }
    }
}