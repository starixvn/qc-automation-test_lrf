//using System;
//using System.Diagnostics;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading;
//using NUnit.Framework;
//using Selenium;
//using NUnit.Core;
//using System.IO;
//using System.ComponentModel;
//using System.Xml;


//namespace SeleniumTests
//{
//    [TestFixture]
//    public class Acc_Customer_PT_EditCasino_01_VerifyTheEditPTOf3rdPartyFucntionWorksCorrectly : ITestCase
//    {

//        /**********************************************************************************/
//        /*******************DO NOT DELETE     START****************************/
//        /**********************************************************************************/
//        public ISelenium selenium;
//        public CommonFunc fCommon = new CommonFunc();

//        //********IF YOU WANT TO USE ANY INTERFACES, ACTIONS YOU HAVE TO DEFINE THIS SECTION************/
//        public Acc_UILogin Acc_UILogin = new Acc_UILogin();
//        //public Acc_UILeftMenu Acc_UILeftMenu = new Acc_UILeftMenu();
//        //public Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
//        //public Lrf_UIForecast_Handicap_OverUnder_Live Lrf_UIForecast_Handicap_OverUnder_Live = new Lrf_UIForecast_Handicap_OverUnder_Live();
//        public Acc_Initialize Acc_Initialize = new Acc_Initialize();
//        //**********************************************************************************************
//        //private StringBuilder verificationErrors;

//        public string browser;
//        public string url;
//        public string server;
//        public int port;
//        public int timeoutSecond;
//        public string strLinkReportFile = "";

//        //*******YOU HAVE TO EDIT THE PATH AND NAME OF DATA FILE WHICH YOU LOAD DATA FROM (ex: "Handicap-OverUnder-Live.xml", Path: "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
//        //public string DataFileName = "Acc_Customer_PT_Edit3rdParty_01.xml";
//        public string DataFileName3rdParty = "Acc_Customer_PT_Edit3rdParty_01_List3rdParty.xml";
//        public string DataFileNameDataToUpdate = "Acc_Customer_PT_Edit3rdParty_01_Data.xml";
//        //public string DataFileNameControlsBelong3rdParty = "Acc_Customer_PT_Edit3rdParty_01_Controls.xml";
//        public string strPathDataFile = "Data\\Accounting Site\\Customer\\";
                
//        //***************************************************************************************************************************************

//        public string strDuration = "";

//        //*******YOU HAVE TO EDIT THE PATH OF THIS TEST CASE (ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\)"
//        public string strPathTestCase = "Accounting Site\\Customer\\";
//        //******************************************************************************

//        public DateTime dateStartTime;
//        public DateTime dateEndTime;
//        private string strReportFileName = "";

//        public String GetClassName()
//        {
//            string strClassName = TypeDescriptor.GetClassName(this, true);
//            int intIndexDot = strClassName.IndexOf(".");
//            int intLength = strClassName.Length - (intIndexDot + 1);
//            string tmpStrClassName = strClassName.Substring(intIndexDot + 1, intLength);
//            return tmpStrClassName;
//        }

//        [SetUp]
//        public void SetupTest()
//        {

//            dateStartTime = DateTime.Now.ToLocalTime();

//            browser = Acc_Initialize.browser;
//            port = Acc_Initialize.port;
//            url = Acc_Initialize.url;
//            server = Acc_Initialize.server;

//            selenium = new DefaultSelenium(server, port, browser, url);
//            selenium.Start();

//            timeoutSecond = fCommon.timeoutSecond;

//            strPathDataFile = fCommon.strRootFolder.Replace("/", "\\") + strPathDataFile;


//            //verificationErrors = new StringBuilder();

//            string CookiesDir = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
//            string[] cookies = Directory.GetFiles(CookiesDir, "*.txt");
//            foreach (string cookie in cookies)
//            {
//                Routines.DeleteCacheIndexDat(cookie, false);
//            }

//            /***Create Folder to save Report**/
//            strPathTestCase = fCommon.strPathFolderOfSummaryReportFile + strPathTestCase;
//            Directory.CreateDirectory(strPathTestCase);
//            //Create folder "Log" in the Root folder to save Report temp.
//            Directory.CreateDirectory(fCommon.strCommonPathReportFile);
//            /***********************************/

//            strReportFileName = "Report " + dateStartTime.ToString().Replace("/", "-").ToString().Replace(":", "-").ToString() + ".html";
//            //strPathTestCase + strReportFileName
//            CommonFunc.writeHeaderReport(fCommon.strCommonPathReportFile + fCommon.strCommonReportFileName, GetClassName(), dateStartTime.ToString());
//            selenium.Open(url);
//            selenium.WindowMaximize();
//            selenium.WindowFocus();
//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                dateEndTime = DateTime.Now.ToLocalTime();
//                strDuration = CommonFunc.getDurationTime(dateStartTime, dateEndTime);
//                CommonFunc.writeFinishReport(fCommon.strCommonPathReportFile + fCommon.strCommonReportFileName, strDuration, fCommon.numOfPassed, fCommon.numOfFailed, fCommon.numOfError, dateEndTime.ToString());
//                File.Move(fCommon.strCommonPathReportFile + fCommon.strCommonReportFileName, strPathTestCase + strReportFileName);
//                strLinkReportFile = strPathTestCase + strReportFileName;
//                //selenium.Close();
//                //selenium.Stop();
//            }
//            catch (Exception)
//            {
//            }
//        }
//        /**********************************************************************************/
//        /***************************DO NOT DELETE     END******************************/
//        /**********************************************************************************/



//        [Test]
//        public void TestMethod()
//        {
//            Acc_UITopMenu Acc_UITopMenu = new Acc_UITopMenu();
//            Acc_UIViewPT Acc_UIViewPT = new Acc_UIViewPT();
//            Random random = new Random();
//            int randomNumber = random.Next(1000000);
//            string strUserNameSuper = "testSuper124205";// "testSuper" + randomNumber.ToString();
//            Acc_Common.Login(selenium, Acc_Initialize.strAdminUserName, Acc_Initialize.strAdminPassword, "", timeoutSecond, fCommon);

//            Acc_Customer.addNewSuper(selenium, strUserNameSuper, "1234", "BEST-ODDS", "UUS", true, timeoutSecond, fCommon);
//            Acc_PositionTaking.edit3rdPartyPositionTakingForSuper(selenium, strUserNameSuper, "Casino", "0.88", "0.02", "0.0004", "1500", true, timeoutSecond, fCommon);
//            Acc_PositionTaking.verifyViewPTSuper(selenium, strUserNameSuper, "Casino", ".: ALL - Game Kind :.", "//div[@id='sContent']/div/div/table[2]", "0.88", "0.00", "0.00", "0.02", "0.00", "0.0004", false, true, timeoutSecond, fCommon);
//            //Acc_PositionTaking.verifyViewPTSuper(selenium, strUserNameSuper, "Bingo", ".: ALL - Game Kind :.", "//div[@id='sContent']/div/div/table", "0.89", "0.00", "0.00", "0.01", "0.00", "0.0004", false, true, timeoutSecond, fCommon);
//            //Acc_Common.gotoTopMenu(selenium, Acc_UITopMenu.tabCustomer, Acc_UITopMenu.linkViewPT, timeoutSecond, fCommon);
            
//            //string strUserNameSuper = "test654321";
//            ////string strUserNameMaster = "testmaster123456";
//            ////string strUserNameAgent = "testagent123456";
//            ////string strUserNameAgenMembert = "testmember123456";
//            ////string strPassword = "1234";
            
            
//            ////Log In Accounting Site as admin level
//            //Acc_Common.Login(selenium, Acc_Initialize.strAdminUserName, Acc_Initialize.strAdminPassword, "", timeoutSecond, fCommon);
            
//            ////Edit PT of 3rdParty for Super (ex: Casino, Bingo)
//            ////XmlNodeList DataListUser = CommonFunc.readDataFromXmlFile(strPathDataFile + DataFileName, "//DataSet//filter", "@level='super'");
//            ////foreach (XmlNode DataUser in DataListUser)
//            ////{
//            //XmlNodeList DataList3rdPartyName = CommonFunc.readDataFromXmlFile(strPathDataFile + DataFileName3rdParty, "//DataSet//filter");
//            //foreach (XmlNode Data3rdParty in DataList3rdPartyName)
//            //{
//            //    //Go to the Edit PT of 3rdParty (ex: Casino, Bingo)
//            //    //Acc_Common.gotoLeftMenu(selenium, DataUser["username"].InnerText, Acc_UILeftMenu.tabDetail, Acc_UILeftMenu.btnEdit, Data3rdParty["linkEditControl"].InnerText, timeoutSecond, fCommon);
//            //    //selenium.WaitForPageToLoad("30000");

//            //    //Get list controls belong 3rdParty pages
//            //    XmlNodeList DataListDataToUpdate = CommonFunc.readDataFromXmlFile(strPathDataFile + DataFileNameDataToUpdate, "//DataSet//filter", "@level='super' and @thirdParty='" + Data3rdParty["thirdPartyName"].InnerText + "'");
//            //    foreach (XmlNode DataToUpdate in DataListDataToUpdate)
//            //    {
                    
//            //        //Control.select(selenium, DataToUpdate["cmbSuperComm"].InnerText, "label=0.0005", timeoutSecond, fCommon);
//            //        //Control.waitForControlExist(selenium, DataToUpdate["cmbSuperComm"].InnerText, timeoutSecond, fCommon);
//            //        //selenium.Select(DataToUpdate["cmbSuperComm"].InnerText, "label=0.0005");
//            //        //Control.click(selenium, DataToUpdate["btnUpdate"].InnerText, timeoutSecond, fCommon);
//            //        //selenium.WaitForPageToLoad("" + timeoutSecond.ToString);
//            //        //CommonFunc.waitForPageToLoad(selenium, timeoutSecond, fCommon);
//            //        //Acc_PositionTaking.edit3rdPartyPositionTakingForSuper(selenium, DataUser["username"].InnerText, Data3rdParty["linkEditControl"].InnerText, DataToUpdate["cmbSuperMaxPT"].InnerText, DataToUpdate["valueOfSuperMaxPT"].InnerText, DataToUpdate["cmbSuperMinPT"].InnerText, DataToUpdate["valueOfSuperMinPT"].InnerText, DataToUpdate["cmbSuperComm"].InnerText, DataToUpdate["valueOfSuperComm"].InnerText, DataToUpdate["btnUpdate"].InnerText, true, timeoutSecond, fCommon);
//            //        Acc_PositionTaking.edit3rdPartyPositionTakingForSuper(selenium, strUserNameSuper, Data3rdParty["thirdPartyName"].InnerText, DataToUpdate["valueOfSuperMaxPT"].InnerText, DataToUpdate["valueOfSuperMinPT"].InnerText, DataToUpdate["valueOfSuperComm"].InnerText, DataToUpdate["valueOfMaxTransferCredit"].InnerText, true, timeoutSecond, fCommon);
//            //    }


//            //}
//            //    //Acc_Common.searchUserName(selenium, "sa-uus", timeoutSecond, fCommon);
                
//            //    //Log In Agent Site as Supper/Master/Agent level
//            //    //Lrf_Common.Login(selenium, Data["username"].InnerText, Data["password"].InnerText, Lrf_Initialize.strCaptcha, timeoutSecond, fCommon);
//            ////}
//            ////Control.click(selenium, Acc_UILeftMenu.tabDetail,timeoutSecond, fCommon);
//            ////Acc_Common.Logout(selenium, timeoutSecond, fCommon);

//            ////Control.addText(selenium, Acc_UILogin.txtUserName, "sa", fCommon);
//            ////Control.waitForControlExist(selenium, Acc_UILogin.txtUserName, timeoutSecond, fCommon);
//            ////selenium.Type(Acc_UILogin.txtUserName, "sa");
//            ////Control.addText(selenium, UILogin.txtUserName, "sa", fCommon);
//            ////Control.addText(selenium, Acc_UILogin.txtPassword, "1234", fCommon);
//            ////Control.addText(se, UILogin.txtCaptcha, strCaptcha, cm);
//            ////Control.click(selenium, UILogin.btnLogin, fCommon);
//            ////XmlNodeList DataList = CommonFunc.readDataFromXmlFile(strPathDataFile + DataFileName, "//DataSet//filter", "@level='super'");
//            ////foreach (XmlNode Data in DataList)
//            ////{
//            ////    //Log In Agent Site as Supper/Master/Agent level
//            ////    Lrf_Common.Login(selenium, Data["username"].InnerText, Data["password"].InnerText, Lrf_Initialize.strCaptcha, timeoutSecond, fCommon);
//            ////    ////Go to the Handicap/Over Under/Live page
//            ////    Lrf_Common.gotoLeftMenu(selenium, Lrf_UILeftMenu.tabMainMenu, Lrf_UILeftMenu.lnkParentMenu_Forecast, Lrf_UILeftMenu.lnkSubMenu_Forecast_HandicapOverUnderLive, timeoutSecond, fCommon);

//            ////    ////Verify the Handicap/Over Under/Live page displays properly
//            ////    Control.checkTextInControl(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.lblTitle, "FIBA World Championship 2010 Men (in Turkey)", timeoutSecond, fCommon);

//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.lblTitle, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.btnRefresh, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.colNumberOrder, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.colTime, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.colEvent, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.colFullTime, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.col1stHalf, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.colFullTime_Handicap, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.colFullTime_OverUnder, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.col1stHalf_Handicap, timeoutSecond, fCommon);
//            ////    //Control.checkControlExist(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.col1stHalf_OverUnder, timeoutSecond, fCommon);

//            ////    //Control.checkTextInControl(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.col1stHalf_Handicap, "Handicap", timeoutSecond, fCommon);
//            ////    //Control.checkTextInControl(selenium, Lrf_UIForecast_Handicap_OverUnder_Live.col1stHalf_OverUnder, "Over/Under", timeoutSecond, fCommon);
//            ////    ////Log Out
//            ////    //Lrf_Common.Logout(selenium, timeoutSecond, fCommon);
//            ////}
//        }
//    }
//}