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

//namespace SeleniumTests
//{
//    [TestFixture]
//    public class VerifyTheEditCustomerInfoFunctionWorksCorrectly : ITestCase
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
//        public string DataFileName = "editCustomerInfo.txt";//"Handicap-OverUnder-Live.xml";
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
//            Console.WriteLine(intLength.ToString());
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
//            strPathDataFile = fCommon.strRootFolder.Replace("/", "\\") + strPathDataFile;



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
//                selenium.Close();
//                selenium.Stop();

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
//            Console.WriteLine(strDuration);
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
//                    string[] arrUserPass = Regex.Split(line, "\t");

//                    //Login Accounting
//                    CommonFunc.LogIn(selenium,UILogin.txtUserName,arrUserPass[1],UILogin.txtPassword,
//                        arrUserPass[2],UILogin.btnSubmit,timeoutSecond, fCommon);
                    
//                    //Edit Customer Info
//                    CommonFunc.editCustomerInfo(selenium,arrUserPass[3],arrUserPass[4],arrUserPass[5],arrUserPass[6],arrUserPass[7],arrUserPass[8], arrUserPass[9],arrUserPass[10],
//                        arrUserPass[11],arrUserPass[12],arrUserPass[13],arrUserPass[14],arrUserPass[15],arrUserPass[16],arrUserPass[17],Convert.ToBoolean(arrUserPass[18]),20, fCommon);
                    
//                    //Verify that Customer Info is updated successful
//                    CommonFunc.checkCustomerInfo(selenium, arrUserPass[3], arrUserPass[4],true, arrUserPass[5],true, arrUserPass[6],true, arrUserPass[7],true, arrUserPass[8],true, arrUserPass[9],true, arrUserPass[10],true,
//                        arrUserPass[11],true, arrUserPass[12],true, arrUserPass[13],true, arrUserPass[14],true, arrUserPass[15],true, arrUserPass[16],true, arrUserPass[17],true, Convert.ToBoolean(arrUserPass[18]),true,true,fCommon, timeoutSecond);

//                    //Clean up
//                    CommonFunc.editCustomerInfo(selenium, arrUserPass[3], "", "", "", "", "", "", "",
//                       "", "", "", "", "", "", arrUserPass[17], false, 20, fCommon);

//                    //Logout and wait for the Login page exists
//                    CommonFunc.LogOut(selenium, UIMain.linkLogout, 10, fCommon);
//                }
//            }
            
            
//        }

//    }
//}