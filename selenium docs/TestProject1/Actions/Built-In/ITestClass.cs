using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTests
{
    public interface ITestCase
    {

        void SetupTest();
        void TeardownTest();
        string GetClassName();
        DateTime dateStartTime
        {get;set;}
        DateTime dateEndTime
        {get;set;}
        string strLinkReportFile
        { get; set; }
        int numOfPassed { get; set; }
        int numOfFailed { get; set; }
        int numOfError { get; set; }
        //string strPathFileName
        //{ get; set; }

        
        void TestMethod();
    }
}