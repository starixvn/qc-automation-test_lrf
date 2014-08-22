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
using System.Xml;


namespace SeleniumTests
{
    [TestFixture]
    public class _LRF_Multiple_TestCases
    {
        /*********DO NOT DELETE Start*************/
        public CommonFunc fCommon = new CommonFunc();

        private DateTime dateStartTime;
        private DateTime dateEndTime;
        private string strPathFolderOfSummaryReportFile = "";
        private string strSummaryReportFileName = "";
        private string strPathTestCaseFile = "";
        /*********DO NOT DELETE End*************/

        [SetUp]
        public void SetupTest()
        {
            strPathFolderOfSummaryReportFile = fCommon.strPathFolderOfSummaryReportFile ;

            Directory.CreateDirectory(strPathFolderOfSummaryReportFile);
            dateStartTime = DateTime.Now.ToLocalTime();
            strSummaryReportFileName = "Summary Report " + dateStartTime.ToString().Replace("/", "-").ToString().Replace(":", "-").ToString() + ".html";

            strPathTestCaseFile = fCommon.strRootFolder.Substring(0, fCommon.strRootFolder.Length - 1).Replace("/", "\\");
            Console.WriteLine(strPathTestCaseFile);
            CommonFunc.writeHeaderSummaryReport(strPathFolderOfSummaryReportFile + strSummaryReportFileName, dateStartTime.ToString());
        }



        [TearDown]
        public void TeardownTest()
        {
            try
            {



            }
            catch (Exception)
            {
                //Ignore errors if unable to close the browser
                //Console.WriteLine(e.ToString());
                //Write Total Result;

            }
            dateEndTime = DateTime.Now.ToLocalTime();
            CommonFunc.writeFinishSummaryReport(strPathFolderOfSummaryReportFile + strSummaryReportFileName, dateEndTime.ToString());
            //CommonFunc.writeSummary(fCommon.numOfPassed, fCommon.numOfFailed, fCommon.numOfError);
        }



        [Test]
        public void TestMethod()
        {
            //XmlNodeList TestCaseList = CommonFunc.readDataFromXmlFile(strPathDataFile + "ListTestCaseRunMultiple.xml", "//TestCaseList//TestCase");
            //foreach (XmlNode TestCase in TestCaseList)
            string[] TestCaseList = CommonFunc.readTextFile(strPathTestCaseFile, "ListTestCaseRunMultiple2.txt");
            foreach (string TestCase in TestCaseList)
            {
                if (File.Exists(TestCase.Trim()))
                {
                    string TestCaseName = getTestCaseName(TestCase);
                    int idxChar = TestCaseName.IndexOf("_", 8);
                    string NameSpace = TestCaseName.Substring(0, idxChar).Replace("_",".");

                    Console.WriteLine("SeleniumTests." + NameSpace + "." + TestCaseName);

                    CommonFunc.RunTest(strPathFolderOfSummaryReportFile + strSummaryReportFileName, "SeleniumTests." + NameSpace + "." + TestCaseName);
                    //Console.WriteLine(getTestCaseName(TestCase));
                }
            }
        }

        private string getTestCaseName(string strPathTestCase)
        {
            int i = strPathTestCase.LastIndexOf(@"\");
            int lastDotIndex = strPathTestCase.LastIndexOf(".");
            return strPathTestCase.Substring(i + 1, lastDotIndex - (i + 1));
        }

    }
}