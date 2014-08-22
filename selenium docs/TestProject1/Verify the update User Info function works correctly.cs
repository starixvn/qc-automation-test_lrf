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
//    public class VerifyTheUpdateUserInfoFunctionWorksCorrectly
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
//        public string DataFileName = "editPersonalSetting.txt";

//        [SetUp]
//        public void SetupTest()
//        {
//            browser = fCommon.browser;
//            port = fCommon.port;
//            url = fCommon.url;
//            server = fCommon.server;
//            pathFileData = fCommon.pathFileData;
//            timeoutSecond = fCommon.timeoutSecond;

//            fCommon.numOfPassed = 0;
//            fCommon.numOfFailed = 0;
//            fCommon.numOfError = 0;

//            selenium = new DefaultSelenium(server, port, browser, url);
//            selenium.Start();
//            verificationErrors = new StringBuilder();
//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                selenium.Close();
//                selenium.Stop();

//                string CookiesDir = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
//                string[] cookies = Directory.GetFiles(CookiesDir, "*.txt");
//                foreach (string cookie in cookies)
//                {
//                    Routines.DeleteCacheIndexDat(cookie, false);
//                }
//            }
//            catch (Exception)
//            {
//                //Ignore errors if unable to close the browser
//                //Console.WriteLine(e.ToString());
//            }
//            CommonFunc.writeSummary(fCommon.numOfPassed, fCommon.numOfFailed, fCommon.numOfError);
//        }



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

//                    //Login Accounting
//                    CommonFunc.LogIn(selenium,UILogin.txtUserName,arrUsernamePassword[1],UILogin.txtPassword,
//                        arrUsernamePassword[2],UILogin.btnSubmit,timeoutSecond, fCommon);
                    
//                    //Click on the User Info link

//                    CommonFunc.click(selenium, UIMain.linkUserInfo, 6, fCommon);

                    

//                    //Verify that error "Password must have at least 4 characters!" displays if do not enter data to the password field
//                    CommonFunc.click(selenium, UIPersonalSetting.btnSubmit, timeoutSecond, fCommon);
//                    CommonFunc.checkText(selenium, UIPersonalSetting.lblErrMessage, arrUsernamePassword[3], true, fCommon, timeoutSecond);
                    
//                    //Verify that error "Wrong username or password" displays if enter invalid password to the password field
//                    CommonFunc.addText(selenium, UIPersonalSetting.txtPassword, arrUsernamePassword[8],fCommon);
//                    CommonFunc.click(selenium, UIPersonalSetting.btnSubmit, fCommon);
//                    CommonFunc.checkText(selenium, UIPersonalSetting.lblErrMessage, arrUsernamePassword[4], true, fCommon, timeoutSecond);

//                    //Update FName, LName
//                    CommonFunc.addText(selenium, UIPersonalSetting.txtPassword, arrUsernamePassword[2],fCommon);
//                    CommonFunc.click(selenium, UIPersonalSetting.btnSubmit, fCommon);
//                    CommonFunc.waitForControlExist(selenium, UIPersonalSetting.txtFirstName, 5, fCommon);
//                    CommonFunc.addText(selenium, UIPersonalSetting.txtFirstName, arrUsernamePassword[5], fCommon);
//                    CommonFunc.addText(selenium, UIPersonalSetting.txtLastName, arrUsernamePassword[6], fCommon);
//                    CommonFunc.click(selenium, UIPersonalSetting.btnSubmit, fCommon);

//                    //Verify that message "Your information is updated successful!" displays when edit info successful
//                    CommonFunc.checkText(selenium, UIPersonalSetting.lblErrMessage, arrUsernamePassword[7], true, fCommon, timeoutSecond);

//                    //Go to the Account Management page
//                    CommonFunc.click(selenium, UIMain.linkMenuUser, timeoutSecond, fCommon);
//                    CommonFunc.click(selenium, UIUser.linkAccountManagement, timeoutSecond, fCommon);
//                    CommonFunc.click(selenium, UIUser.btnViewAllAccounts, timeoutSecond, fCommon);
//                    CommonFunc.waitForControlExist(selenium, UIUser.txtKeyword, 5, fCommon);
//                    CommonFunc.addText(selenium, UIUser.txtKeyword, arrUsernamePassword[1], fCommon);
//                    CommonFunc.click(selenium, UIUser.btnSearch, fCommon);

//                    //Verify FName, LName in the User Table
//                    CommonFunc.checkDataInUserTable(selenium, UIUser.tblListAccount, arrUsernamePassword[1], arrUsernamePassword[5], true, arrUsernamePassword[6], true, "", false, "", false, "", false, true, fCommon, 5);

//                    //Clean up
//                    CommonFunc.click(selenium, UIMain.linkUserInfo, fCommon);
//                    CommonFunc.waitForControlExist(selenium, UIPersonalSetting.txtPassword, 6, fCommon);
//                    CommonFunc.addText(selenium, UIPersonalSetting.txtPassword, arrUsernamePassword[2], fCommon);
//                    CommonFunc.click(selenium, UIPersonalSetting.btnSubmit, fCommon);
//                    CommonFunc.waitForControlExist(selenium, UIPersonalSetting.txtFirstName, 5, fCommon);
//                    CommonFunc.addText(selenium, UIPersonalSetting.txtFirstName, "", fCommon);
//                    CommonFunc.addText(selenium, UIPersonalSetting.txtLastName, "", fCommon);
//                    CommonFunc.click(selenium, UIPersonalSetting.btnSubmit, fCommon);

//                    //Logout and wait for the Login page exists
//                    CommonFunc.LogOut(selenium, UIMain.linkLogout, 10, fCommon);
                    
//                }
//            }
            
//        }

//    }
//}