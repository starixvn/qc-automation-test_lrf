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
//using System.Xml;
//using CarlosAg.ExcelXmlWriter;
//using Excel = Microsoft.Office.Interop.Excel;

//namespace SeleniumTests
//{
//    public class TestCase2
//    {
//        public ISelenium selenium;
//        public CommonFunc fCommon = new CommonFunc();
//        public UILogin UILogin = new UILogin();
//        private StringBuilder verificationErrors;

//        public string browser;
//        public string url;
//        public string server;
//        public int port;
//        public int timeoutSecond;

//        [SetUp]
//        public void SetupTest()
//        {
//            browser = fCommon.browser;
//            port = fCommon.port;
//            url = fCommon.url;
//            server = fCommon.server;
//            timeoutSecond = fCommon.timeoutSecond;

//            fCommon.numOfPassed = 0;
//            fCommon.numOfFailed = 0;

//            selenium = new DefaultSelenium(server, port, browser, url);
//            selenium.Start();
//            verificationErrors = new StringBuilder();
//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                selenium.Stop();
//            }
//            catch (Exception e)
//            {
//                //Ignore errors if unable to close the browser
//                Console.WriteLine(e.ToString());
//            }
//            Assert.AreEqual("", verificationErrors.ToString());
//        }



//        [Test]
//        public void TestMethod2()
//        {

//            selenium.Open(url);
//            selenium.WindowMaximize();
//            selenium.WindowFocus();

//            CommonFunc.verifyTitle(selenium, "Log In Accounting Admin System", true, fCommon,timeoutSecond);

//            //CommonFunc.verifyTitle(selenium, "Log In Accounting Admin System", true, fCommon);
//            //CommonFunc.verifyTitle(selenium, "Log In Accounting Admin Systemz", true, fCommon);

//            CommonFunc.addText(selenium, UILogin.txtUserName, "phuc");
//            CommonFunc.addText(selenium, UILogin.txtPassword, "1234");

//            selenium.Click(UILogin.btnSubmit);

//            selenium.WaitForPageToLoad("3000");

//            //Verify that user sign in successfully
//            CommonFunc.verifyTitle(selenium, "Accounting Admin System", true, fCommon,timeoutSecond);

//            //Common Commona = new Common();
//            //CommonFunc.verifyTitle(selenium, "Accounting Admin System", true, fCommon);
//            Console.WriteLine("**********************************************************");
//            Console.WriteLine("Total checks: " + (fCommon.numOfPassed + fCommon.numOfFailed));
//            Console.WriteLine("Num of Passed: " + fCommon.numOfPassed);
//            Console.WriteLine("Num of Failed:" + fCommon.numOfFailed);
//            Console.WriteLine("**********************************************************");
//            //Console.WriteLine(Common.numOfFailed);

//            // Assert Title of page.
//            //Assert.AreEqual("Log In Accounting Admin System", selenium.GetTitle());

//            // Provide search term as "Selenium OpenQA"
//            // Collection of String values.
//            //String[] arr = { "ide", "rc", "grid" };

//            // Execute loop for each String in array 'arr'.
//            //foreach (String s in arr)
//            //{
//            //    selenium.Type(UILogin.txtUserName, s);
//            //    Assert.AreEqual(s, selenium.GetValue(UILogin.txtUserName));
//            //    //sel.click("btnG");
//            //    //sel.waitForPageToLoad("30000");
//            //    //assertTrue("Expected text: " +s+ " is missing on page."
//            //    //sel.isTextPresent("Results * for selenium " + s));
//            //}




//            // Read the keyed search term and assert it.


//            // Provide search term as "Selenium OpenQA"
//            //selenium.Type(UILogin.txtPassword, "1234");

//            // Read the keyed search term and assert it.
//            //Assert.AreEqual("1234", selenium.GetValue(UILogin.txtPassword));

//            // Click on Search button.
//            //selenium.Click("//img[@id='imglogout' and @onclick=\"fnClick('3')\"]");
//            //selenium.click("link=Close this window"); 
//            //if (selenium.IsElementPresent(UILogin.btnSubmit)==true)
//            //{
//            //    selenium.Click(UILogin.btnSubmit);
//            //   selenium.WaitForPageToLoad("30000");
//            //}



//            // Wait for page to load.
//            //selenium.WaitForPageToLoad("5000");

//            // Assert that "www.openqa.org" is available in search results.
//            //Assert.IsTrue(selenium.IsTextPresent("Selenium web application testing system"));

//            // Assert that page title is - "Selenium OpenQA - Google Search"
//            //selenium.Refresh();


//            //Assert.AreEqual("Accounting Admin System",selenium.GetTitle());
//            //selenium.
//            //Assert.AreEqual("", selenium.GetTitle());
//            //String[]  = selenium.GetAllWindowNames();
//            //Assert.AreEqual("", String.Join(",", selenium.GetAllLinks()));
//            //catch (AssertionException e)
//            //{
//            //    verificationErrors.Append(e.Message);
//            //}
//            //Console.WriteLine(selenium.GetAllLinks());


//            //int indexOfTab = line.IndexOf("\t");
//            //int indexArray = 0;
//            //if(indexOfTab > 0)
//            //{
//            //    //arrUsername[indexArray] = CommonFunc.Left(line,indexOfTab-1);
//            //    strUsername = strUsername + CommonFunc.Left(line, indexOfTab - 1)+"\r\n";
//            //    strPassword = strPassword + CommonFunc.Left(line, indexOfTab - 1) + "\r\n";
//            //    Console.WriteLine(arrUsername[indexArray]);
//            //}

//            //string DataUsername = .ToString(); 


//            //CommonFunc.verifyTitle(selenium, "Log In Accounting Admin System", true, fCommon);

//            //CommonFunc.addText(selenium, UILogin.txtUserName, "phuc");
//            //CommonFunc.addText(selenium, UILogin.txtPassword, "1234");

//            //selenium.Click(UILogin.btnSubmit);

//            //selenium.WaitForPageToLoad("3000");

//            ////Verify that user sign in successfully
//            //CommonFunc.verifyTitle(selenium, "Accounting Admin System", true, fCommon);
//            // Provide search term as "Selenium OpenQA"
//            // Collection of String values.
//            //String[] arr = { "ide", "rc", "grid" };

//            // Execute loop for each String in array 'arr'.
//            //foreach (String s in arr)
//            //{
//            //    selenium.Type(UILogin.txtUserName, s);
//            //    Assert.AreEqual(s, selenium.GetValue(UILogin.txtUserName));
//            //    //sel.click("btnG");
//            //    //sel.waitForPageToLoad("30000");
//            //    //assertTrue("Expected text: " +s+ " is missing on page."
//            //    //sel.isTextPresent("Results * for selenium " + s));
//            //}




//            // Read the keyed search term and assert it.


//            // Provide search term as "Selenium OpenQA"
//            //selenium.Type(UILogin.txtPassword, "1234");

//            // Read the keyed search term and assert it.
//            //Assert.AreEqual("1234", selenium.GetValue(UILogin.txtPassword));

//            // Click on Search button.
//            //selenium.Click("//img[@id='imglogout' and @onclick=\"fnClick('3')\"]");
//            //selenium.click("link=Close this window"); 
//            //if (selenium.IsElementPresent(UILogin.btnSubmit)==true)
//            //{
//            //    selenium.Click(UILogin.btnSubmit);
//            //   selenium.WaitForPageToLoad("30000");
//            //}



//            // Wait for page to load.
//            //selenium.WaitForPageToLoad("5000");

//            // Assert that "www.openqa.org" is available in search results.
//            //Assert.IsTrue(selenium.IsTextPresent("Selenium web application testing system"));

//            // Assert that page title is - "Selenium OpenQA - Google Search"
//            //selenium.Refresh();


//            //Assert.AreEqual("Accounting Admin System",selenium.GetTitle());
//            //selenium.
//            //Assert.AreEqual("", selenium.GetTitle());
//            //String[]  = selenium.GetAllWindowNames();
//            //Assert.AreEqual("", String.Join(",", selenium.GetAllLinks()));
//            //catch (AssertionException e)
//            //{
//            //    verificationErrors.Append(e.Message);
//            //}
//            //Console.WriteLine(selenium.GetAllLinks());

//            //Console.WriteLine("**********************************************************");
//            //Console.WriteLine("Total checks: " + (fCommon.numOfPassed + fCommon.numOfFailed));
//            //Console.WriteLine("Num of Passed: " + fCommon.numOfPassed);
//            //Console.WriteLine("Num of Failed:" + fCommon.numOfFailed);
//            //Console.WriteLine("**********************************************************");







//            //***********************************WildCard****************************
//            //class TestRegularExpressions
//            //{
//            //    static void Main()
//            //    {
//            //        string[] sentences = 
//            //        {
//            //            "cow over the moon",
//            //            "Betsy the Cow",
//            //            "cowering in the corner",
//            //            "no match here"
//            //        };

//            //        string sPattern = "cow";

//            //        foreach (string s in sentences)
//            //        {
//            //            System.Console.Write("{0,24}", s);

//            //            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
//            //            {
//            //                System.Console.WriteLine("  (match for '{0}' found)", sPattern);
//            //            }
//            //            else
//            //            {
//            //                System.Console.WriteLine();
//            //            }
//            //        }
//            //    }
//            //}
//            //class TestRegularExpressionValidation
//            //{
//            //    static void Main()
//            //    {
//            //        string[] numbers = 
//            //        {
//            //            "123-456-7890", 
//            //            "444-234-22450", 
//            //            "690-203-6578", 
//            //            "146-893-232",
//            //            "146-839-2322",
//            //            "4007-295-1111", 
//            //            "407-295-1111", 
//            //            "407-2-5555", 
//            //        };

//            //        string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";

//            //        foreach (string s in numbers)
//            //        {
//            //            System.Console.Write("{0,14}", s);

//            //            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
//            //            {
//            //                System.Console.WriteLine(" - valid");
//            //            }
//            //            else
//            //            {
//            //                System.Console.WriteLine(" - invalid");
//            //            }
//            //        }
//            //    }
//            //}


//            //************************************Dynamic Control*****************************
//            //selenium.Click("//span[text()='phucSelenium']");
//            //if(selenium.isElementPresent("css=table#tableID tr>td:nth-child(1):contains('Test Mail77777')")){
//            //System.out.println("The element Found");
//            //}else{

//            //System.out.println("The element not Found");

//            //} 
            
//            //***********************************Verify Text WildCard*************************** 
//            //<tr>
//            //    <td>click</td>
//            //    <td>//span[contains(text(),'phucSeleniu')]</td>
//            //    <td></td>
//            //</tr>
//            //<tr>
//            //    <td>verifyTextPresent</td>
//            //    <td></td>
//            //    <td>glob:phucSelen*</td>
//            //</tr>

//            //</tbody></table>
//            //</body>
//            //</html>

//                Workbook book = new Workbook();
  //              Worksheet sheet = book.Worksheets.Add("Sample");
    //            WorksheetRow row =  sheet.Table.Rows.Add();
      //          WorksheetColumn col = sheet.Table.Columns.Add();
        //        row.Cells.Add("Hello World");
          //      row.Cells.Add("<b>sassHello World</b>");
                
            //    col.AutoFitWidth = true;
                
              //  col.Width = 500;
               // book.Save(@"D:\test.xls");



                //string myXmlString = "..//..//Data//Agent Site//Total Bets//Handicap-OverUnder-Live//Age_TotalBets_HDP_OU_Live_01.xml";
                ////XmlNodeList xnList = testXml(myXmlString, "//DataSet//filter", "@username='Harry Potter' or @value=''");//xml.SelectNodes("//DataSet//filter[@username='Harry Potter' or @value='']");////input[@class='log_button' and @type='submit']
                ////foreach (XmlNode xn in xnList)
                ////{
                ////    string filter = xn.Attributes["value"].Value;
                ////    /*string firstName = xn["Filter"].InnerText;
                ////    string lastName = xn["LastName"].InnerText;
                ////    Console.WriteLine("Name: {0} {1}", firstName, lastName);*/
                ////    //string filter = xn["filter"].Attributes["value"].Value;
                ////    string username = xn["username"].InnerText;
                ////    Console.WriteLine("filter: {0} ==> {1}", filter, username);
                ////    //Console.WriteLine("filter: {0} ", xn["filter"].InnerText);
                ////}
//        }

//    }
//}