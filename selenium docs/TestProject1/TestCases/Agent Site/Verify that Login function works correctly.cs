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
//    public class VerifyLoginFuncWorksCorrectly : ITestCase
//    {
//        /**********************************************************************************/
//        /*******************DO NOT DELETE     START****************************/
//        /**********************************************************************************/
//        public ISelenium selenium;
//        public CommonFunc fCommon = new CommonFunc();
//        public UILogin UILogin = new UILogin();
//        public UIMain UIMain = new UIMain();
//        private StringBuilder verificationErrors;

//        public string browser;
//        public string url;
//        public string server;
//        public int port;
//        public string pathFileData;
//        public int timeoutSecond;

//        //*******You have to edit the path and name of Data file which you load data from ex: "Handicap-OverUnder-Live.xml", Path: "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\"
//        public string DataFileName = "login.txt";//"Handicap-OverUnder-Live.xml";
//        public string strPathDataFile = "Data\\Agent Site\\Total Bets\\Handicap-OverUnder-Live\\";
//        //***************************************************************************************************************************************

//        public string strDuration = "";

//        //*******You have to edit the path of this test case ex: "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\"
//        public string strPathTestCase = "Agent Site\\Total Bets\\Handicap-OverUnder-Live\\";
//        //*********************************************************88
//        public DateTime dateStartTime;
//        public DateTime dateEndTime;

//        public String GetClassName()
//        {
//            string strClassName = TypeDescriptor.GetClassName(this, true);
//            int intIndexDot = strClassName.IndexOf(".");
//            int intLength = strClassName.Length - (intIndexDot + 1);
//            //Console.WriteLine(intLength.ToString());
//            string tmpStrClassName = strClassName.Substring(intIndexDot + 1, intLength);
//            return tmpStrClassName;
//        }

//        [SetUp]
//        public void SetupTest()
//        {
//            dateStartTime = DateTime.Now.ToLocalTime();
//            browser = fCommon.browser;
//            port = fCommon.port;
//            url = fCommon.url;
//            server = fCommon.server;
//            pathFileData = fCommon.pathFileData;
//            timeoutSecond = fCommon.timeoutSecond;
//            strPathDataFile = "..\\..\\Data";//fCommon.strRootFolder.Replace("/", "\\") + strPathDataFile;



//            selenium = new DefaultSelenium(server, port, browser, url);
//            selenium.Start();
//            verificationErrors = new StringBuilder();

//            string CookiesDir = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
//            string[] cookies = Directory.GetFiles(CookiesDir, "*.txt");
//            foreach (string cookie in cookies)
//            {
//                Routines.DeleteCacheIndexDat(cookie, false);
//            }

//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                //selenium.Close();
//                //selenium.Stop();

//            }
//            catch (Exception)
//            {
//                //Ignore errors if unable to close the browser
//                //Console.WriteLine(e.ToString());
//                //Write Total Result;

//            }
//            dateEndTime = DateTime.Now.ToLocalTime();
//            strDuration = CommonFunc.getDurationTime(dateStartTime, dateEndTime);
//            //CommonFunc.writeSummary(fCommon.numOfPassed, fCommon.numOfFailed, fCommon.numOfError);
//            //Console.WriteLine(strDuration);
//        }
//        /**********************************************************************************/
//        /***************************DO NOT DELETE     END******************************/
//        /**********************************************************************************/

//        [Test]
//        public void TestMethod1()
//        {
//            selenium.Open(url);
//            selenium.WindowMaximize();
//            selenium.WindowFocus();

//            ////Console.WriteLine(selenium.GetText(UILogin.lblErrMessage));
//            //Read data from the text file (Username    Password)
//            string[] arrData = CommonFunc.readTextFile(pathFileData, DataFileName);

//            //string[] arrPassword;
//            foreach (string line in arrData)
//            {
//                int indexOfTab = line.IndexOf("\t");
//                if (indexOfTab > 0)
//                {
//                    string[] arrUsernamePassword = Regex.Split(line, "\t");

//                    //Enter username, password
//                    CommonFunc.addText(selenium, UILogin.txtUserName, arrUsernamePassword[1], fCommon);
//                    CommonFunc.addText(selenium, UILogin.txtPassword, arrUsernamePassword[2], fCommon);

//                    //Click on the Submit button
//                    CommonFunc.click(selenium, UILogin.btnSubmit, fCommon);

//                    //If lblErrorMessage not exists then verify that user sign in successfully
//                    //Else check text in label
//                    if (CommonFunc.isControlExists(selenium, UILogin.lblErrMessage, false, 4, fCommon) == true)
//                    {
//                        //Verify title of window to make sure that user sign in successfully
//                        CommonFunc.waitForTitlePageExists(selenium, arrUsernamePassword[5], 30, fCommon);
//                        CommonFunc.verifyTitle(selenium, arrUsernamePassword[5], true, fCommon, timeoutSecond);

//                    }
//                    else
//                    {
//                        if (arrUsernamePassword[4].ToLower() == "true")
//                        {
//                            CommonFunc.checkText(selenium, UILogin.lblErrMessage, arrUsernamePassword[3], Convert.ToBoolean(arrUsernamePassword[4].ToLower()), fCommon, timeoutSecond);
//                        }
//                    }
//                }
//            }
//            //Logout and wait for the Login page exists
//            CommonFunc.LogOut(selenium, UIMain.linkLogout, 10, fCommon);


//        }

//    }
//}