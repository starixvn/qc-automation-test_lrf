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

//namespace SeleniumTests
//{
//    public class UniTest1
//    {
//        public ISelenium selenium;
//        public CommonFunc fCommon = new CommonFunc();
//        public UILogin UILogin = new UILogin();
//        public UIMain UIMain = new UIMain();
//        public UIUser UIUser = new UIUser();
//        public UIPersonalSetting UIPersonalSetting = new UIPersonalSetting();
//        private StringBuilder verificationErrors;

//        public string browser;
//        public string url;
//        public string server;
//        public int port;
//        public string pathFileData;
//        public int timeoutSecond;
//        public string DataFileName = "editCustomerInfo.txt";
        
//        public UniTest1()
//        {
//            browser = fCommon.browser;
//            port = fCommon.port;
//            url = fCommon.url;
//            server = fCommon.server;
//            pathFileData = fCommon.pathFileData;
//            timeoutSecond = fCommon.timeoutSecond;

//            selenium = new DefaultSelenium(server, port, browser, url);
//            selenium.Start();
//            verificationErrors = new StringBuilder();

//            string CookiesDir = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
//            string[] cookies = Directory.GetFiles(CookiesDir, "*.txt");
//            foreach (string cookie in cookies)
//            {
//                Routines.DeleteCacheIndexDat(cookie, false);
//            }

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
//                    CommonFunc.LogIn(selenium, UILogin.txtUserName, arrUserPass[1], UILogin.txtPassword,
//                        arrUserPass[2], UILogin.btnSubmit, timeoutSecond, fCommon);

//                    //Edit Customer Info
//                    CommonFunc.editCustomerInfo(selenium, arrUserPass[3], arrUserPass[4], arrUserPass[5], arrUserPass[6], arrUserPass[7], arrUserPass[8], arrUserPass[9], arrUserPass[10],
//                        arrUserPass[11], arrUserPass[12], arrUserPass[13], arrUserPass[14], arrUserPass[15], arrUserPass[16], arrUserPass[17], Convert.ToBoolean(arrUserPass[18]), 20, fCommon);

//                    //Verify that Customer Info is updated successful
//                    CommonFunc.checkCustomerInfo(selenium, arrUserPass[3], arrUserPass[4], true, arrUserPass[5], true, arrUserPass[6], true, arrUserPass[7], true, arrUserPass[8], true, arrUserPass[9], true, arrUserPass[10], true,
//                        arrUserPass[11], true, arrUserPass[12], true, arrUserPass[13], true, arrUserPass[14], true, arrUserPass[15], true, arrUserPass[16], true, arrUserPass[17], true, Convert.ToBoolean(arrUserPass[18]), true, true, fCommon, timeoutSecond);

//                    //Clean up
//                    CommonFunc.editCustomerInfo(selenium, arrUserPass[3], "", "", "", "", "", "", "",
//                       "", "", "", "", "", "", arrUserPass[17], false, 20, fCommon);

//                    //Logout and wait for the Login page exists
//                    CommonFunc.LogOut(selenium, UIMain.linkLogout, 10, fCommon);
//                }
//            }

//            selenium.Close();
//            selenium.Stop();
//            CommonFunc.writeSummary(fCommon.numOfPassed, fCommon.numOfFailed, fCommon.numOfError);
//        }

        


      
            
      


//    }
//}