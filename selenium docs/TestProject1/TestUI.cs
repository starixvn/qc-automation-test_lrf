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
//using System.Linq.Expressions;


//namespace SeleniumTests
//{
//    [TestFixture]
//    public class TestUI
//    {
//        public ISelenium selenium;
//        public Agent oAgent = new Agent();
//        public CommonFunc fCommon = new CommonFunc();
//        public UILogin UILogin = new UILogin();
//        public UIMain UIMain = new UIMain();
//        public UIAgeHome UIAgeHome = new UIAgeHome();
//        public UIAgentLogIn UIAgentLogIn = new UIAgentLogIn();
//        private StringBuilder verificationErrors;
//        public Control control = new Control();
//        public Utility util = new Utility();

//        public string browser;
//        public string url;
//        public string server;
//        public int port;
//        public string pathFileData;
//        public int timeoutSecond;
//        public string DataFileName = "login.txt";

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
//            CommonFunc.writeSummary(fCommon.numOfPassed, fCommon.numOfFailed, fCommon.numOfError);
//        }



//        [Test]
//        public void TestMethod1()
//        {
//            selenium.Open("http://qa.ibc88.com/");
//            selenium.WindowMaximize();
//            selenium.WindowFocus();

//            //selenium.Type(UIAgentLogIn.txtUserName, "testcs");
//            //selenium.Type(UIAgentLogIn.txtPassWord, "1234aa");
//            //selenium.Click(UIAgentLogIn.btnLogin);
            
//            ////selenium.GetAttribute(UIAgentLogIn.txtUserName);
//            ////Console.WriteLine(selenium.GetAttribute("txtUserName@style"));

//            //string str = control.getElementProperty(selenium, UIAgentLogIn.txtUserName, "style");
//            //Console.WriteLine(str);
//            //fCommon.
//            //Expression e = new Expression("2 + 3 * 5");
//            string str = "12a";
//            string str1 = "143.5"; 
//            //string strNum = "0123456789";

//            Boolean bl = util.isNumeric(str);
//            Console.WriteLine("str: " + bl);
//            Boolean bl1 = util.isNumeric(str1);
//            Console.WriteLine("str: " + bl1);
            
//            //int res = strNum.LastIndexOf(str);

//            //Console.WriteLine("aaaa: " + res);

//            //for (int i = 0; i <= str.Length; i++)
//            //{
//            //    if (strNum.LastIndexOf(str[i]) < 0)
//            //    {
//            //        strRes = "no";
//            //    }
//            //    else
//            //    {
//            //        strRes = "yes";
//            //    }
            
//            //}
//            //Console.WriteLine(strRes);
                   
//        }

//    }
//}