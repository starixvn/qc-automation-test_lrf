//using System;
//using System.Text;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading;
//using NUnit.Framework;
//using Selenium;
//using NUnit.Core;


//namespace SeleniumTests
//{
//    /// <summary>
//    /// Summary description for UnitTest1
//    /// </summary>
//    [TestFixture]
//    public class TestCase1
//    {
//        public ISelenium selenium;
//        private StringBuilder verificationErrors;

//        [SetUp]
//        public void SetupTest()
//        {
//            selenium = new DefaultSelenium("localhost", 4444, "*firefox", "http://tadmin.ibc88.com/Accounting_new/");
//            selenium.Start();
//            verificationErrors = new StringBuilder();

//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                //selenium.Stop();
//            }
//            catch (Exception)
//            {
//                //Ignore errors if unable to close the browser
//            }
//            Assert.AreEqual("", verificationErrors.ToString());

//        }


//        [Test]

//        public void TestMethod1()
//        {
//            //
//            // TODO: Add test logic	here
//            //
//            // Open Google search engine.
//            selenium.Open("http://www.google.com/");

//            // Assert Title of page.
//            Assert.AreEqual("Google", selenium.GetTitle());

//            // Provide search term as "Selenium OpenQA"
//            selenium.Type("q", "Selenium");

//            // Read the keyed search term and assert it.
//            Assert.AreEqual("Selenium", selenium.GetValue("q"));

//            // Click on Search button.
//            selenium.Click("btnG");


//            try
//            {
//                // Assert that "www.openqa.org" is available in search results.
//                Assert.IsTrue(selenium.IsTextPresent("Selenium dfgd sdsd sdfsd "));
                
//            }
//            catch (AssertionException e)
//            {
//                verificationErrors.Append(e.Message);
                
//            }

//            // Wait for page to load.
//            selenium.WaitForPageToLoad("5000");
            
//            Assert.AreEqual("Seleniumsdf - Tìm với Google",
//                        selenium.GetTitle());
//            try
//            {
//                // Assert that "www.openqa.org" is available in search results.
//                Assert.IsTrue(selenium.IsTextPresent("Selenium abc web application testing system"));
//            }
//            catch (AssertionException e)
//            {
//                verificationErrors.Append(e.Message);
//            }
//            // Assert that page title is - "Selenium OpenQA - Google Search"
           
            

//        }

//    }
//}
