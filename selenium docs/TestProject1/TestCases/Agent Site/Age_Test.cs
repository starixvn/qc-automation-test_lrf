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


namespace SeleniumTests.Age
{
    [TestFixture]
    public class Age_Test : ITestCase
    {

        /**********************************************************************************/
        /*******************DO NOT DELETE     START****************************/
        /**********************************************************************************/
        public ISelenium selenium;
        public CommonFunc fCommon = new CommonFunc();

        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
        public Age_UILogin Age_UILogin = new Age_UILogin();
        public Age_UIChangePassword Age_UIChangePassword = new Age_UIChangePassword();
        public Age_UILeftMenu Age_UILeftMenu = new Age_UILeftMenu();
        public Age_UINewMaster Age_UINewMaster = new Age_UINewMaster();
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
        public string DataFileName = "NewMaster.xml";
        public string strPathDataFile = "Data\\Agent Site\\Member Information\\New Master\\";
        //***************************************************************************************************************************************

        public string strDuration = "";

        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
        public string strPathTestCase = "Agent Site\\Change Password\\";
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
                //selenium.Close();
                //selenium.Stop();
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
            
            //XmlNodeList DataList = CommonFunc.readDataFromXmlFile(strPathDataFile + DataFileName, "//DataSet//filter");
            //foreach (XmlNode Data in DataList)
            //{
            //Log In Agent Site as Supper/Master/Agent level
            //Age_Common.Login(selenium, Data["username"].InnerText, Data["password"].InnerText, Age_Initialize.strCaptcha, timeoutSecond, fCommon);
            //Age_Common.Login(selenium, "supertest1", "1234aa", "1111", timeoutSecond, fCommon);
            
            

            //Change password if Login the first times
            //if (Control.doesControlExist(selenium, Age_UIChangePassword.divTitle, timeoutSecond, fCommon) == true)
            //{
            //    Control.addText(selenium, Age_UIChangePassword.txtOldPassword, "1234aa", timeoutSecond, fCommon);
            //    Control.addText(selenium, Age_UIChangePassword.txtPassword, "1234aa", timeoutSecond, fCommon);
            //    Control.addText(selenium, Age_UIChangePassword.txtConfirmPassword, "1234aa", timeoutSecond, fCommon);
            //    Control.click(selenium, Age_UIChangePassword.btnSubmit, timeoutSecond, fCommon);
            //    Control.waitForControlExist(selenium, Age_UILeftMenu.lnkParentMenu_TotalBets, timeoutSecond, fCommon);
            //}

            ////Go to Add New Master -> Full Mode
            //Age_Common.gotoLeftMenu(selenium, Age_UILeftMenu.tabMainMenu, Age_UILeftMenu.lnkParentMenu_MemberInformation, Age_UILeftMenu.lnkSubMenu_MemberInformation_NewMaster, timeoutSecond, fCommon);
            //Control.click(selenium, Age_UINewMaster.tabFullMode, timeoutSecond, fCommon);

            //Age_Common.selectTransferCondition(selenium, "Weekly", "Mon,Sun,Thurs", timeoutSecond, fCommon);

            string abc = Age_Common.getPositionTakingFromDataFile(strPathDataFile + DataFileName, "//DataSet//filter", "@level='super'");
            Console.WriteLine(abc);
            //Age_Common.selectPositionTaking(selenium, "master", "sportsbook", abc, timeoutSecond, fCommon);

            //string aaa = "is3$1$1$0";
            //Control.checkControlExist(selenium, "//input[@name='"+aaa+"']", timeoutSecond, fCommon);

            ////Control.addText(selenium, Age_UINewMaster.txtNumberGameMinBet, "500", timeoutSecond, fCommon);


            ////Control.checkControlExist(selenium, Age_UINewMaster.tabSearchAndCopy, timeoutSecond, fCommon);
            //Control.click(selenium, Age_UINewMaster.divCopyAllBetSettingFromSoccer, timeoutSecond, fCommon);

            //Control.verifyControlIsEnable(selenium, Age_UINewMaster.txtSoccerMaxBet, timeoutSecond, fCommon);

            //Control.verifyControlIsDisable(selenium, Age_UINewMaster.txtBaseballMaxBet, timeoutSecond, fCommon);

            //Control.click(selenium, Age_UINewMaster.divCopyAllBetSettingFromSoccer, timeoutSecond, fCommon);

            //Control.verifyControlIsEnable(selenium, Age_UINewMaster.txtSoccerMaxBet, timeoutSecond, fCommon);

            //Control.verifyControlIsEnable(selenium, Age_UINewMaster.txtBaseballMaxBet, timeoutSecond, fCommon);


            //

            //Age_Common.selectTransferCondition(selenium, "Daily", "", timeoutSecond, fCommon);
            //Control.checkControlExist(selenium, Age_UINewMaster.txtSoccerMaxBet, timeoutSecond, fCommon);    

            /*Console.WriteLine(Control.getControlProperty(selenium,Age_UINewMaster.txtSoccerMaxBet,"disabled",timeoutSecond,fCommon));
            Console.WriteLine(Control.getControlProperty(selenium,Age_UINewMaster.txtSoccerMaxBet,"enabled",timeoutSecond,fCommon));
            Console.WriteLine(Control.getControlProperty(selenium,Age_UINewMaster.txtBasketBallMaxBet,"disabled",timeoutSecond,fCommon));
            Console.WriteLine(Control.getControlProperty(selenium,Age_UINewMaster.txtBasketBallMaxBet,"enabled",timeoutSecond,fCommon));
             */
            //Control.ch

            //Console.Write(Control.getControlProperty(selenium, Age_UITotalBets_CorrectScore.icoExportToExcel, "src"));

            //Log Out
            //Age_Common.Logout(selenium, timeoutSecond, fCommon);
            //}
        }
    }
}