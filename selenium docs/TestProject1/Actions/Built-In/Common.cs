using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;
using NUnit.Core;
using System.Xml;
//using CarlosAg.ExcelXmlWriter;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.ComponentModel;

namespace SeleniumTests
{
    //Delegate do define an Object that like a parameter in function, void
    public delegate void TestMethod();
    public class CommonFunc
    {
        //public int port = 4444;
        //public string browser = "*firefox";//"*iehta";//"*firefox"
        //public string url = "http://10.18.200.201/agentbl/SignIn.aspx";//"http://tadmin.ibc88.com/Accounting_new/";
        //public string server = "localhost";
        //public string pathFileData = "..\\..\\Data";//You can delete this command
        public int timeoutSecond = 60;
        public string strPathFolderOfSummaryReportFile = "D:\\Automation Test Results\\";
        public string strRootFolder = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - "bin\\Debug".Length);
        //*******Note: If you edit this parameter, you have to edit parameter in the "writeLogReport()" function too
        public string strCommonPathReportFile = Directory.GetCurrentDirectory() + "\\Log\\";
        //*******Note: If you edit this parameter, you have to edit parameter in the "writeLogReport()" function too
        public string strCommonReportFileName = "Report.html";
        
        public int numPassed;
        public int numFailed;
        public int numError;
        public int glb_numOfPassed;
        public int glb_numOfFailed;
        public int glb_numOfError;

        /*public CommonFunc()
        {
           Console.WriteLine(getDurationTime(DateTime.Now.ToLocalTime(), DateTime.Now.ToLocalTime()));
        }*/
        
        public int numOfPassed
        {
            get
            {
                return numPassed;
            }
            set
            {
                numPassed = value;
            }
        }
        
        public int numOfFailed
        {
            get
            {
                return numFailed;
            }
            set
            {
                numFailed = value;
            }
        }

        public int numOfError
        {
            get
            {
                return numError;
            }
            set
            {
                numError = value;
            }
        }
        
        public static void verifyTitle(ISelenium se, string strTitle, bool flagChecked, CommonFunc cm, int timeoutSecond)
        {
            
            try
            {
                
                string title = se.GetTitle();
                if (((title == strTitle) && (flagChecked==true)) || ((title != strTitle) && (flagChecked==false)))
                {
                    //numPassed = numPassed + 1;
                    
                    cm.numOfPassed = cm.numOfPassed + 1;
                    
                    Console.WriteLine("===Verify title of window '" + title + "' is/is not '" + strTitle + "' passed");
                    //Console.WriteLine(numPassed);
                }
                else{
                    cm.numOfFailed = cm.numOfFailed + 1;
                    Console.WriteLine("===Verify title '" + title + "' is/is not '" + strTitle + "' FAILED");
                    StackTrace st = new StackTrace(new StackFrame(true));
                    StackFrame sf = st.GetFrame(0);
                    Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
                    Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                    Console.WriteLine("========================");
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' is '" + strTitle + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }

        
        public static string getTextInTable(ISelenium se, string tableID_or_Name, int row, int col, int timeoutSecond, CommonFunc cm)
        {
            try
            {

                Control.waitForControlExist(se, tableID_or_Name, timeoutSecond, cm);
                string textInCell = se.GetTable(tableID_or_Name + "." + row + "." + col);
                Console.WriteLine("Get text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' = '" + textInCell + "'");
                return textInCell;
            }
            catch(Exception)
            {
                return "isNaN";
            }
        }

        public static string getTextInTableNoID(ISelenium se, int row, int col, int timeoutSecond, CommonFunc cm)
        {
            try
            {

                //Control.waitForControlExist(se, timeoutSecond, cm);
                string textInCell = se.GetText("table/tbody/tr[" + row + "]/td[" + col + "]");//table/tbody/tr["+i+"]/td[2]"
                Console.WriteLine("Get text in table '" + "' at row/col '" + row + "/" + col + "' = '" + textInCell + "'");
                return textInCell;
            }
            catch (Exception)
            {
                return "isNaN";
            }
        }

        //public static void verifyTextInTable(ISelenium se, string tableID_or_Name, int row, int col, string strTextToVerify, bool flagChecked, CommonFunc cm, int timeoutSecond)
        //{
        //    try
        //    {
        //        string textInTable = CommonFunc.getTextInTable(se, tableID_or_Name, row, col, timeoutSecond, cm);
        //        if (textInTable != "isNaN")
        //        {
        //            if (((textInTable == strTextToVerify) && (flagChecked == true)) || ((textInTable != strTextToVerify) && (flagChecked == false)))
        //            {
        //                cm.numOfPassed = cm.numOfPassed + 1;
        //                Console.WriteLine("===Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "' passed");
        //            }
        //            else
        //            {
        //                cm.numOfFailed = cm.numOfFailed + 1;
        //                Console.WriteLine("===Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "' FAILED");
        //                StackTrace st = new StackTrace(new StackFrame(true));
        //                StackFrame sf = st.GetFrame(0);
        //                Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
        //                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
        //                Console.WriteLine("========================");
        //            }
        //        }
        //        else{
        //            cm.numOfFailed = cm.numOfFailed + 1;
        //            Console.WriteLine("===Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "' FAILED");
        //            StackTrace st = new StackTrace(new StackFrame(true));
        //            StackFrame sf = st.GetFrame(0);
        //            Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
        //            Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
        //            Console.WriteLine("========================");
        //        }
                
        //    }
        //    catch (Exception e)
        //    {
        //        cm.numOfError = cm.numOfError + 1;
        //        StackTrace st = new StackTrace(new StackFrame(true));
        //        StackFrame sf = st.GetFrame(0);
        //        Console.WriteLine("========ERROR===========");
        //        Console.WriteLine("Error when '" + sf.GetMethod().Name + "' at row/col '" + row + "/" + col + "' is '" + strTextToVerify + "'");
        //        Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
        //        Console.WriteLine(e.ToString());
        //        Console.WriteLine("========================");
        //        se.Close();
        //        se.Stop();
        //    }
        //}
        public static void verifyTextInTable(ISelenium se, string tableID_or_Name, int row, int col, string strTextToVerify, bool flagChecked, CommonFunc cm, int timeoutSecond)
        {
            try
            {
                CommonFunc.writeLogReport("Verify text in table '" + tableID_or_Name + "'", "Info");
                string textInTable = Control.getTextInTable(se, tableID_or_Name, row, col, timeoutSecond, cm);
                if (textInTable != "isNaN")
                {
                    if (((textInTable == strTextToVerify) && (flagChecked == true)) || ((textInTable != strTextToVerify) && (flagChecked == false)))
                    {
                        cm.numOfPassed = cm.numOfPassed + 1;
                        //Console.WriteLine("===Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "' passed");
                        CommonFunc.writeLogReport("Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "'", "Passed");
                    }
                    else
                    {
                        cm.numOfFailed = cm.numOfFailed + 1;
                        //Console.WriteLine("===Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "' FAILED");
                        CommonFunc.writeLogReport("Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "'", "Failed");
                        //StackTrace st = new StackTrace(new StackFrame(true));
                        //StackFrame sf = st.GetFrame(0);
                        //Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
                        //Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                        //Console.WriteLine("========================");
                    }
                }
                else
                {
                    cm.numOfFailed = cm.numOfFailed + 1;
                    //Console.WriteLine("===Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "' FAILED");
                    CommonFunc.writeLogReport("Verify text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' is/is not '" + strTextToVerify + "'", "Failed");
                    //StackTrace st = new StackTrace(new StackFrame(true));
                    //StackFrame sf = st.GetFrame(0);
                    //Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
                    //Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                    //Console.WriteLine("========================");
                }

            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                se.Close();
//                se.Stop();
            }
        }


        public static void checkDataInUserTable(ISelenium se, string tableID_or_Name, string UserName, string FName, bool verifyFName, string LName, bool verifyLName,
                            string Status, bool verifyStatus, string Creator, bool verifyCreator, string CreatedDate, bool verifyCreatedDate, bool flagChecked, CommonFunc cm, int timeoutSecond)
        {
            try
            {
                int row = 2;
                int limitRows = 500;
                int colUserName = 1;
                int colFName = 2;
                int colLName = 3;
                int colStatus = 4;
                int colCreator = 5;
                int colCreatedDate = 6;
                bool flagFName = true;
                bool flagLName = true;
                bool flagStatus = true;
                bool flagCreator = true;
                bool flagCreatedDate = true;
                bool flag = false;

                while (row <= limitRows && flag == false)
                {
                    string strUserName = CommonFunc.getTextInTable(se, tableID_or_Name, row, colUserName, timeoutSecond, cm);
                    if (strUserName != "isNaN")
                    {
                        if (strUserName == UserName)
                        {
                            if (verifyFName == true)
                            {
                                string strFName = CommonFunc.getTextInTable(se, tableID_or_Name, row, colFName, timeoutSecond, cm);
                                if (strFName != FName)
                                {
                                    flagFName = false;
                                }
                            }
                            if (verifyLName == true)
                            {
                                string strLName = CommonFunc.getTextInTable(se, tableID_or_Name, row, colLName, timeoutSecond,cm);
                                if (strLName != LName)
                                {
                                    flagLName = false;
                                }
                            }
                            if (verifyStatus == true)
                            {
                                string strStatus = CommonFunc.getTextInTable(se, tableID_or_Name, row, colStatus, timeoutSecond,cm);
                                if (strStatus != Status)
                                {
                                    flagStatus = false;
                                }
                            }
                            if (verifyCreator == true)
                            {
                                string strCreator = CommonFunc.getTextInTable(se, tableID_or_Name, row, colCreator, timeoutSecond,cm);
                                if (strCreator != Creator)
                                {
                                    flagCreator = false;
                                }
                            }
                            if (verifyCreatedDate == true)
                            {
                                string strCreatedDate = CommonFunc.getTextInTable(se, tableID_or_Name, row, colCreatedDate, timeoutSecond,cm);
                                if (strCreatedDate != CreatedDate)
                                {
                                    flagCreatedDate = false;
                                }
                            }
                            flag = true;
                        }
                    }
                    else
                    {
                        row = limitRows + 1;
                    }
                    row += 1;
                }

                if (flag == true)
                {
                    if ((flagFName && flagLName && flagStatus && flagCreator && flagCreatedDate) == flagChecked)
                    {
                        cm.numOfPassed = cm.numOfPassed + 1;
                        Console.WriteLine("===Verify data in table '" + tableID_or_Name + "': UserName = '" + UserName + "' passed");
                    }
                    else
                    {
                        cm.numOfFailed = cm.numOfFailed + 1;
                        Console.WriteLine("===Verify data in table '" + tableID_or_Name + "': UserName = '" + UserName + "' FAILED");
                        StackTrace st = new StackTrace(new StackFrame(true));
                        StackFrame sf = st.GetFrame(0);
                        Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
                        Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                        Console.WriteLine("========================");
                    }

                }
                else
                {
                    cm.numOfFailed = cm.numOfFailed + 1;
                    Console.WriteLine("===User '" + UserName + "' does not exist in the table '" + tableID_or_Name + "' => FAILED");
                    StackTrace st = new StackTrace(new StackFrame(true));
                    StackFrame sf = st.GetFrame(0);
                    Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
                    Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                    Console.WriteLine("========================");
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "', UserName = '" + UserName + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }


        public static void editCustomerInfo(ISelenium se, string customer, string FirstName, string LastName, string Phone, string Email, string Mobile,
                            string Address, string Fax, string Postal, string BettingCode, string City, string RefCode2, string State, string Remark, string Country, bool Important, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                UIMain UIMain = new UIMain();
                UICustomerDetail UICustomerDetail = new UICustomerDetail();
                UIEditCustomerInfo UIEditCustomerInfo = new UIEditCustomerInfo();
                UIWindow UIWindow = new UIWindow();


                Console.WriteLine("=Edit Customer Info=");
                Control.waitForControlExist(se, UIMain.txtUserName, 20,cm);
                Control.addText(se, UIMain.txtUserName, customer, cm);
                Control.click(se, UIMain.btnSearch,cm);

                Control.waitForControlExist(se, UICustomerDetail.tabDetail, timeoutSecond,cm);
                Control.click(se, UICustomerDetail.tabDetail,cm);
                Control.click(se, UICustomerDetail.linkInfo,timeoutSecond,cm);

                se.WaitForPopUp(UIWindow.EditCustomerInfoID, "30000");
                se.SelectWindow(UIWindow.EditCustomerInfo);

                Control.addText(se, UIEditCustomerInfo.txtFirstName, FirstName, cm);
                Control.addText(se, UIEditCustomerInfo.txtLastName, LastName, cm);
                Control.addText(se, UIEditCustomerInfo.txtEmail, Email, cm);
                Control.addText(se, UIEditCustomerInfo.txtAddress, Address, cm);
                Control.addText(se, UIEditCustomerInfo.txtPostal, Postal, cm);
                Control.addText(se, UIEditCustomerInfo.txtCity, City, cm);
                Control.addText(se, UIEditCustomerInfo.txtState, State, cm);
                se.Select(UIEditCustomerInfo.listCountry, "label=" + Country);
                Control.addText(se, UIEditCustomerInfo.txtPhone, Phone, cm);
                Control.addText(se, UIEditCustomerInfo.txtMobile, Mobile, cm);
                Control.addText(se, UIEditCustomerInfo.txtFax, Fax, cm);
                Control.addText(se, UIEditCustomerInfo.txtBettingCode, BettingCode, cm);
                Control.addText(se, UIEditCustomerInfo.txtRefCode2, RefCode2, cm);
                Control.addText(se, UIEditCustomerInfo.txtRemark, Remark, cm);
                if (Important == true)
                {
                    se.Check(UIEditCustomerInfo.chkImportant);
                }
                else
                {
                    se.Uncheck(UIEditCustomerInfo.chkImportant);
                }

                Control.click(se, UIEditCustomerInfo.btnSubmit,cm);
                Thread.Sleep(2000);
                se.SelectWindow(UIWindow.Main);
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' customer '" + customer + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }

        //public static void checkCustomerInfo(ISelenium se, string customer, string FirstName, bool checkFirstName, string LastName, bool checkLastName, string Phone, bool checkPhone, string Email, bool checkEmail, string Mobile, bool checkMobile,
        //                    string Address, bool checkAddress, string Fax, bool checkFax, string Postal, bool checkPostal, string BettingCode, bool checkBettingCode, string City, bool checkCity, string RefCode2, bool checkRefCode2,
        //                    string State, bool checkState, string Remark, bool checkRemark, string Country, bool checkCountry, bool Important, bool checkImportant, bool flagChecked, CommonFunc cm, int timeoutSecond)
        //{
        //    try
        //    {
        //        bool flagFirstName = true;
        //        bool flagLastName = true;
        //        bool flagPhone = true;
        //        bool flagEmail = true;
        //        bool flagMobile = true;
        //        bool flagAddress = true;
        //        bool flagFax = true;
        //        bool flagPostal = true;
        //        bool flagBettingCode = true;
        //        bool flagCity = true;
        //        bool flagRefCode2 = true;
        //        bool flagState = true;
        //        bool flagRemark = true;
        //        bool flagCountry = true;
        //        bool flagImportant = true;
                
        //        //bool flag = false;
        //        UIMain UIMain = new UIMain();
        //        UICustomerDetail UICustomerDetail = new UICustomerDetail();
        //        UIEditCustomerInfo UIEditCustomerInfo = new UIEditCustomerInfo();
        //        UIWindow UIWindow = new UIWindow();
                
        //        Control.waitForControlExist(se, UIMain.txtUserName, timeoutSecond,cm);
        //        Control.addText(se, UIMain.txtUserName, customer,cm);
        //        Control.click(se, UIMain.btnSearch,cm);

        //        Control.waitForControlExist(se, UICustomerDetail.tabDetail, timeoutSecond,cm);
        //        Control.click(se, UICustomerDetail.tabDetail,cm);
        //        Control.click(se, UICustomerDetail.linkInfo, timeoutSecond,cm);

        //        se.WaitForPopUp(UIWindow.EditCustomerInfoID, "30000");
        //        se.SelectWindow(UIWindow.EditCustomerInfo);

        //        if (checkFirstName == true)
        //        {
        //            string strFirstName = se.GetValue(UIEditCustomerInfo.txtFirstName);
        //            if (strFirstName != FirstName)
        //            {
        //                flagFirstName = false;
        //            }
        //        }
        //        if (checkLastName == true)
        //        {
        //            string strLastName = se.GetValue(UIEditCustomerInfo.txtLastName);
        //            if (strLastName != LastName)
        //            {
        //                flagLastName = false;
        //            }
        //        }
        //        if (checkPhone == true)
        //        {
        //            string strPhone = se.GetValue(UIEditCustomerInfo.txtPhone);
        //            if (strPhone != Phone)
        //            {
        //                flagPhone = false;
        //            }
        //        }
        //        if (checkEmail == true)
        //        {
        //            string strEmail = se.GetValue(UIEditCustomerInfo.txtEmail);
        //            if (strEmail != Email)
        //            {
        //                flagEmail = false;
        //            }
        //        }
        //        if (checkMobile == true)
        //        {
        //            string strMobile = se.GetValue(UIEditCustomerInfo.txtMobile);
        //            if (strMobile != Mobile)
        //            {
        //                flagMobile = false;
        //            }
        //        }
        //        if (checkAddress == true)
        //        {
        //            string strAddress = se.GetValue(UIEditCustomerInfo.txtAddress);
        //            if (strAddress != Address)
        //            {
        //                flagAddress = false;
        //            }
        //        }
        //        if (checkFax == true)
        //        {
        //            string strFax = se.GetValue(UIEditCustomerInfo.txtFax);
        //            if (strFax != Fax)
        //            {
        //                flagFax = false;
        //            }
        //        }
        //        if (checkPostal == true)
        //        {
        //            string strPostal = se.GetValue(UIEditCustomerInfo.txtPostal);
        //            if (strPostal != Postal)
        //            {
        //                flagPostal = false;
        //            }
        //        }
        //        if (checkBettingCode == true)
        //        {
        //            string strBettingCode = se.GetValue(UIEditCustomerInfo.txtBettingCode);
        //            if (strBettingCode != BettingCode)
        //            {
        //                flagBettingCode = false;
        //            }
        //        }
        //        if (checkCity == true)
        //        {
        //            string strCity = se.GetValue(UIEditCustomerInfo.txtCity);
        //            if (strCity != City)
        //            {
        //                flagCity = false;
        //            }
        //        }
        //        if (checkRefCode2 == true)
        //        {
        //            string strRefCode2 = se.GetValue(UIEditCustomerInfo.txtRefCode2);
        //            if (strRefCode2 != RefCode2)
        //            {
        //                flagRefCode2 = false;
        //            }
        //        }
        //        if (checkState == true)
        //        {
        //            string strState = se.GetValue(UIEditCustomerInfo.txtState);
        //            if (strState != State)
        //            {
        //                flagState = false;
        //            }
        //        }
        //        if (checkRemark == true)
        //        {
        //            string strRemark = se.GetValue(UIEditCustomerInfo.txtRemark);
        //            if (strRemark != Remark)
        //            {
        //                flagRemark = false;
        //            }
        //        }
        //        if (checkCountry == true)
        //        {
        //            string strCountry = se.GetSelectedLabel(UIEditCustomerInfo.listCountry);
        //            if (strCountry != Country)
        //            {
        //                flagCountry = false;
        //            }
        //        }
        //        if (checkImportant == true)
        //        {
        //            bool boolImportant = se.IsChecked(UIEditCustomerInfo.chkImportant);
        //            if (boolImportant != Important)
        //            {
        //                flagImportant = false;
        //            }
        //        }

        //        if ((flagFirstName && flagLastName && flagPhone && flagEmail && flagMobile && flagAddress && flagFax && flagPostal && flagBettingCode && flagCity && flagRefCode2 && flagState && flagRemark && flagCountry && flagImportant) == flagChecked)
        //        {
        //            cm.numOfPassed = cm.numOfPassed + 1;
        //            Console.WriteLine("===Verify Customer Info of customer '" + customer + "' passed");
        //        }
        //        else
        //        {
        //            cm.numOfFailed = cm.numOfFailed + 1;
        //            Console.WriteLine("===Verify Customer Info of customer '" + customer + "' FAILED");
        //            StackTrace st = new StackTrace(new StackFrame(true));
        //            StackFrame sf = st.GetFrame(0);
        //            Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
        //            Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
        //            Console.WriteLine("========================");
        //        }

        //        se.Close();
        //        se.SelectWindow(UIWindow.Main);
        //        Thread.Sleep(2000);
        //    }
        //    catch (Exception e)
        //    {
        //        cm.numOfError = cm.numOfError + 1;
        //        StackTrace st = new StackTrace(new StackFrame(true));
        //        StackFrame sf = st.GetFrame(0);
        //        Console.WriteLine("========ERROR===========");
        //        Console.WriteLine("Error when '" + sf.GetMethod().Name + "' of customer '" + customer + "'");
        //        Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
        //        Console.WriteLine(e.ToString());
        //        Console.WriteLine("========================");
        //        se.Close();
        //        se.Stop();
        //    }
        //}


        public static void checkCustomerInfo(ISelenium se, string customer, string FirstName, bool checkFirstName, string LastName, bool checkLastName, string Phone, bool checkPhone, string Email, bool checkEmail, string Mobile, bool checkMobile,
                            string Address, bool checkAddress, string Fax, bool checkFax, string Postal, bool checkPostal, string BettingCode, bool checkBettingCode, string City, bool checkCity, string RefCode2, bool checkRefCode2,
                            string State, bool checkState, string Remark, bool checkRemark, string Country, bool checkCountry, bool Important, bool checkImportant, bool flagChecked, CommonFunc cm, int timeoutSecond)
        {
            try
            {
                string strFailed = "";
                string strPassed = "";
                string strResultsPassed = "";
                string strResultsFailed = "";

                UIMain UIMain = new UIMain();
                UICustomerDetail UICustomerDetail = new UICustomerDetail();
                UIEditCustomerInfo UIEditCustomerInfo = new UIEditCustomerInfo();
                UIWindow UIWindow = new UIWindow();

                Control.waitForControlExist(se, UIMain.txtUserName, timeoutSecond, cm);
                Control.addText(se, UIMain.txtUserName, customer, cm);
                Control.click(se, UIMain.btnSearch, cm);

                Control.waitForControlExist(se, UICustomerDetail.tabDetail, timeoutSecond, cm);
                Control.click(se, UICustomerDetail.tabDetail, cm);
                Control.click(se, UICustomerDetail.linkInfo, timeoutSecond, cm);
                
                se.WaitForPopUp(UIWindow.EditCustomerInfoID, "30000");
                se.SelectWindow(UIWindow.EditCustomerInfo);

                if (checkFirstName == true)
                {
                    string strFirstName = se.GetValue(UIEditCustomerInfo.txtFirstName);

                    if (strFirstName != FirstName)
                    {
                        strFailed = strFailed + "FirstName" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + FirstName + ", Observed: " + strFirstName + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "FirstName" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + FirstName + ", Observed: " + strFirstName + "\t";
                    }
                    
                    //Console.WriteLine("Expected: " + FirstName + ", Observed: " + se.GetValue(UIEditCustomerInfo.txtFirstName));
                }
                if (checkLastName == true)
                {
                    string strLastName = se.GetValue(UIEditCustomerInfo.txtLastName);

                    if (strLastName != LastName)
                    {
                        //flagLastName = false;
                        strFailed = strFailed + "LastName" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + LastName + ", Observed: " + strLastName + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "LastName" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + LastName + ", Observed: " + strLastName + "\t";
                    }
                    
                   
                }
                if (checkPhone == true)
                {
                    string strPhone = se.GetValue(UIEditCustomerInfo.txtPhone);

                    if (strPhone != Phone)
                    //try
                    {
                        //Assert.AreEqual(Phone, "quanglewin");
                        //flagPhone = false;
                        strFailed = strFailed + "Phone" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Phone + ", Observed: " + strPhone + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Phone" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Phone + ", Observed: " + strPhone + "\t";
                    }
                    
                    
                }
                if (checkEmail == true)
                {
                    string strEmail = se.GetValue(UIEditCustomerInfo.txtEmail);

                    if (strEmail != Email)
                    {
                        //flagEmail = false;
                        strFailed = strFailed + "Email" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Email + ", Observed: " + strEmail + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Email" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Email + ", Observed: " + strEmail + "\t";
                    }
                    
                    
                }
                if (checkMobile == true)
                {
                    string strMobile = se.GetValue(UIEditCustomerInfo.txtMobile);

                    if (strMobile != Mobile)
                    {
                        //flagMobile = false;
                        strFailed = strFailed + "Mobile" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Mobile + ", Observed: " + strMobile + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Mobile" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Mobile + ", Observed: " + strMobile + "\t";
                    }
                    
                    
                }
                if (checkAddress == true)
                {
                    string strAddress = se.GetValue(UIEditCustomerInfo.txtAddress);

                    if (strAddress != Address)
                    {
                        //flagAddress = false;
                        strFailed = strFailed + "Address" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Address + ", Observed: " + strAddress + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Address" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Address + ", Observed: " + strAddress + "\t";
                    }
                    
                    
                }
                if (checkFax == true)
                {
                    string strFax = se.GetValue(UIEditCustomerInfo.txtFax);

                    if (strFax != Fax)
                    {
                        //flagFax = false;
                        strFailed = strFailed + "Fax" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Fax + ", Observed: " + strFax + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Fax" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Fax + ", Observed: " + strFax + "\t";
                    }
                    
                    
                }
                if (checkPostal == true)
                {
                    string strPostal = se.GetValue(UIEditCustomerInfo.txtPostal);

                    if (strPostal != Postal)
                    {
                        //flagPostal = false;
                        strFailed = strFailed + "Postal" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Postal + ", Observed: " + strPostal + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Postal" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Postal + ", Observed: " + strPostal + "\t";
                    }
                    
                    
                }
                if (checkBettingCode == true)
                {
                    string strBettingCode = se.GetValue(UIEditCustomerInfo.txtBettingCode);

                    if (strBettingCode != BettingCode)
                    {
                        //flagBettingCode = false;
                        strFailed = strFailed + "BettingCode" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + BettingCode + ", Observed: " + strBettingCode + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "BettingCode" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + BettingCode + ", Observed: " + strBettingCode + "\t";
                    }
                    
                    
                }
                if (checkCity == true)
                {
                    string strCity = se.GetValue(UIEditCustomerInfo.txtCity);

                    if (strCity != City)
                    {
                        //flagCity = false;
                        strFailed = strFailed + "City" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + City + ", Observed: " + strCity + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "City" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + City + ", Observed: " + strCity + "\t";
                    }
                    
                   
                }
                if (checkRefCode2 == true)
                {
                    string strRefCode2 = se.GetValue(UIEditCustomerInfo.txtRefCode2);

                    if (strRefCode2 != RefCode2)
                    {
                        //flagRefCode2 = false;
                        strFailed = strFailed + "RefCode2" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + RefCode2 + ", Observed: " + strRefCode2 + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "RefCode2" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + RefCode2 + ", Observed: " + strRefCode2 + "\t";
                    }
                    
                    
                }
                if (checkState == true)
                {
                    string strState = se.GetValue(UIEditCustomerInfo.txtState);

                    if (strState != State)
                    {
                        //flagState = false;
                        strFailed = strFailed + "State" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + State + ", Observed: " + strState + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "State" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + State + ", Observed: " + strState + "\t";
                    }
                    
                    
                }
                if (checkRemark == true)
                {
                    string strRemark = se.GetValue(UIEditCustomerInfo.txtRemark);

                    if (strRemark != Remark)
                    {
                        //flagRemark = false;
                        strFailed = strFailed + "Remark" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Remark + ", Observed: " + strRemark + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Remark" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Remark + ", Observed: " + strRemark + "\t";
                    }
                    
                    
                }
                if (checkCountry == true)
                {
                    string strCountry = se.GetSelectedLabel(UIEditCustomerInfo.listCountry);

                    if (strCountry != Country)
                    {
                        //flagCountry = false;
                        strFailed = strFailed + "Country" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Country + ", Observed: " + strCountry + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Country" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Country + ", Observed: " + strCountry + "\t";
                    }
                    
                    
                }
                if (checkImportant == true)
                {
                    bool boolImportant = se.IsChecked(UIEditCustomerInfo.chkImportant);

                    if (boolImportant != Important)
                    {
                        // flagImportant = false;
                        strFailed = strFailed + "Important" + "\t";
                        strResultsFailed = strResultsFailed + "Expected: " + Important.ToString() + ", Observed: " + boolImportant.ToString() + "\t";
                    }
                    else
                    {
                        strPassed = strPassed + "Important" + "\t";
                        strResultsPassed = strResultsPassed + "Expected: " + Important.ToString() + ", Observed: " + boolImportant.ToString() + "\t";
                    }
                    
                    
                }

                if (flagChecked)
                {
                    Console.WriteLine(strPassed);
                    Console.WriteLine(strFailed);
                    string[] arrPassed = Regex.Split(strPassed, "\t");
                    string[] arrResultPassed = Regex.Split(strResultsPassed, "\t");
                    for (int i = 0; i < arrPassed.Length - 1; i++)
                    {
                        cm.numOfPassed = cm.numOfPassed + 1;
                        Console.WriteLine("===Verify Customer Info: Check " + arrPassed[i] + " passed");
                        Console.WriteLine(arrResultPassed[i]);
                    }
                    string[] arrFailed = Regex.Split(strFailed, "\t");
                    string[] arrResultFailed = Regex.Split(strResultsFailed, "\t");
                    for (int i = 0; i < arrFailed.Length - 1; i++)
                    {
                        cm.numOfFailed = cm.numOfFailed + 1;
                        Console.WriteLine("=====================Verify Customer Info: Check " + arrFailed[i] + " FAILED");
                        Console.WriteLine(arrResultFailed[i]);
                    }
                }
                else
                {
                    Console.WriteLine(strPassed);
                    Console.WriteLine(strFailed);
                    string[] arrFailed = Regex.Split(strFailed, "\t");
                    string[] arrResultFailed = Regex.Split(strResultsFailed, "\t");
                    for (int i = 0; i < arrFailed.Length - 1; i++)
                    {
                        cm.numOfPassed = cm.numOfPassed + 1;
                        Console.WriteLine("===Verify Customer Info: Check " + arrFailed[i] + " passed");
                        Console.WriteLine(arrResultFailed[i]);
                    }
                    string[] arrPassed = Regex.Split(strPassed, "\t");
                    string[] arrResultPassed = Regex.Split(strResultsPassed, "\t");
                    for (int i = 0; i < arrPassed.Length - 1; i++)
                    {
                        cm.numOfFailed = cm.numOfFailed + 1;
                        Console.WriteLine("=====================Verify Customer Info: Check " + arrPassed[i] + " FAILED");
                        Console.WriteLine(arrResultPassed[i]);
                    }
                }


                se.Close();
                se.SelectWindow(UIWindow.Main);
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' of customer '" + customer + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }

        public static void waitForTitlePageExists(ISelenium se, string strTitle, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                int indexTime = 1;
                bool flag = false;
                while (indexTime <= timeoutSecond && flag == false)
                {
                    Console.WriteLine("Waiting for the title '" + strTitle + "'...");
                    Thread.Sleep(1000);
                    string title = se.GetTitle();
                    if (title == strTitle)
                    {
                        flag = true;
                    }
                    indexTime += 1;
                }
                
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' is '" + strTitle + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }

        public static void waitForTextInControl(ISelenium se, string control, string strText, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                int indexTime = 1;
                bool flag = false;
                while (indexTime <= timeoutSecond && flag == false)
                {
                    Console.WriteLine("Waiting for the text '" + strText + "' in control '" + control + "'...");
                    Thread.Sleep(1000);
                    string text = se.GetText(control);
                    if (text == strText)
                    {
                        flag = true;
                    }
                    indexTime += 1;
                }

            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' is '" + strText + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }

        public static void waitForPageToLoad(ISelenium se, int timeoutSecond, CommonFunc cm)
        {
        	
        	try
            {
                string strTimeOut = timeoutSecond.ToString() + "000";
                CommonFunc.writeLogReport("Waiting for the page is loaded...", "Debug");
                //Console.WriteLine("Waiting for the page is loaded...");
                se.WaitForPageToLoad(strTimeOut);

            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name);
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }
        
        
        public static void waitForFrameToLoad(ISelenium se, string strframeaddress, int timeoutSecond, CommonFunc cm)
        {
        	
        	try
            {
                string strTimeOut = timeoutSecond.ToString() + "000";
                CommonFunc.writeLogReport("Waiting for the page is loaded...", "Debug");
                //Console.WriteLine("Waiting for the page is loaded...");
                se.WaitForFrameToLoad(strframeaddress,strTimeOut);

            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name);
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }
        
        /// Checks if a wildcard string matches a domain

        /// </summary>
        //public static void addText(ISelenium se, string control, string str, CommonFunc cm)
        //{
        //    try
        //    {
        //        se.Type(control, str);
        //        Console.WriteLine("Enter '" + str + "' to control '" + control + "'");
        //    }
        //    catch (Exception e)
        //    {
        //        cm.numOfError = cm.numOfError + 1;
        //        StackTrace st = new StackTrace(new StackFrame(true));
        //        StackFrame sf = st.GetFrame(0);
        //        //Console.WriteLine(" File: {0}", sf.GetFileName());
        //        //Console.WriteLine(" Method: {0}", sf.GetMethod().Name);
        //        Console.WriteLine("========ERROR===========");
        //        Console.WriteLine("Error '" + sf.GetMethod().Name + "' into control '" + control + "'");
        //        Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
        //        Console.WriteLine(e.ToString());
        //        Console.WriteLine("========================");
                
        //        se.Close();
        //        se.Stop();
                
        //        //Console.WriteLine(" Column Number: {0}", sf.GetFileColumnNumber());
        //    }
        //}
        
        public static void LogOut(ISelenium se, string controlLogout, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                //UILogin UILogin = new UILogin();
                Console.WriteLine("=Log Out=");
                Control.waitForControlExist(se, controlLogout, timeoutSecond, cm);
                Control.click(se, controlLogout, timeoutSecond,cm);
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error '" + sf.GetMethod().Name + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }

        public static void LogIn(ISelenium se, string controlUsername, string strUsername, 
                                string controlPassword, string strPassword, string controlSubmit,
                                int timeoutSecond, CommonFunc cm)
        {
            try
            {
                
                Console.WriteLine("Log In");
                Control.addText(se, controlUsername, strUsername, cm);
                Control.addText(se, controlPassword, strPassword, cm);
                Control.click(se, controlSubmit,cm);
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }

        


        public static void checkText(ISelenium se, string control, string text, bool flag, CommonFunc cm, int timeoutSecond)
        {
            try
            {
                CommonFunc.waitForTextInControl(se, control, text, timeoutSecond, cm);
                string textInControl = se.GetText(control);
                if ((textInControl == text && flag == true) || (textInControl != text && flag == false))
                {
                    cm.numOfPassed = cm.numOfPassed + 1;
                    Console.WriteLine("===Verify text in control " + control + " is/is not '" + text + "' passed");
                }
                else
                {
                    cm.numOfFailed = cm.numOfFailed + 1;
                    Console.WriteLine("===Verify text in control " + control + " is/is not '" + text + "' FAILED");
                    StackTrace st = new StackTrace(new StackFrame(true));
                    StackFrame sf = st.GetFrame(0);
                    Console.WriteLine("Method '" + sf.GetMethod().Name + "'");
                    Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                    Console.WriteLine("========================");
                }

            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' in control '" + control + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
            }
        }
        
        public static void writeSummary(int numOfPassed, int numOfFailed, int numOfError)
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Total checks: " + (numOfPassed + numOfFailed));
            Console.WriteLine("Num of Passed: " + numOfPassed);
            Console.WriteLine("Num of Failed:" + numOfFailed);
            Console.WriteLine("Num of Error:" + numOfError);
            Console.WriteLine("**********************************************************");




            ////Microsoft.Office.Interop.Excel Excel = new Microsoft.Office.Interop.Excel();
            //Application app;
            //Workbook workbook;
            //Worksheet worksheet;
            //Range workSheet_range;
            ////Excel.Application app;
            ////Excel.Workbook workbook;
            ////Excel.Worksheet worksheet;
            ////Excel.Range workSheet_range;

            //app = new ApplicationClass();

            //app.Visible = true;
            //workbook = app.Workbooks.Add(1);
            //worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            ////createHeaders(worksheet, workSheet_range, 5, 2, "Total of Products", "B5", "D5", 2, "YELLOW", true, 10, "n");

            ////createHeaders(Excel.Worksheet worksheet,Excel.Range workSheet_range, int row, int col, string htext, string cell1, string cell2, int mergeColumns, string b, bool font, int size, string fcolor)

            //worksheet.Cells[5, 2] = "Total of Products";
            //workSheet_range = worksheet.get_Range("B5", "D5");
            //workSheet_range.Merge(2);
            ////string b = "YELLOW";
            //workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                 

            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.Font.Bold = true;
            //workSheet_range.ColumnWidth = 10;
            ////string fcolor = "n";
            //workSheet_range.Font.Color = System.Drawing.Color.Black.ToArgb();
            
            
            
            
            
            
            
            
            ////creates subheaders
            ////createHeaders(worksheet, workSheet_range, 6, 2, "Sold Product", "B6", "B6", 0, "GRAY", true, 10, "");
            //worksheet.Cells[6, 2] = "Sold Product";
            //workSheet_range = worksheet.get_Range("B6", "B6");
            //workSheet_range.Merge(0);
            ////b = "GRAY";
            //workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            

            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.Font.Bold = true;
            //workSheet_range.ColumnWidth = 10;
            //workSheet_range.Font.Color = System.Drawing.Color.White.ToArgb();
            




            
            
            ////createHeaders(worksheet, workSheet_range, 6, 3, "", "C6", "C6", 0, "GRAY", true, 10, "");
            //worksheet.Cells[6, 3] = "Sold Product";
            //workSheet_range = worksheet.get_Range("C6", "C6");
            //workSheet_range.Merge(0);
            ////b = "GRAY";
            //workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            
            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.Font.Bold = true;
            //workSheet_range.ColumnWidth = 10;
            //workSheet_range.Font.Color = System.Drawing.Color.White.ToArgb();

            
            ////createHeaders(worksheet, workSheet_range, 6, 4, "Initial Total", "D6", "D6", 0, "GRAY", true, 10, "");
            //worksheet.Cells[6, 4] = "Initial Total";
            //workSheet_range = worksheet.get_Range("D6", "D6");
            //workSheet_range.Merge(0);
            ////b = "GRAY";
            //workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();

            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.Font.Bold = true;
            //workSheet_range.ColumnWidth = 10;
            //workSheet_range.Font.Color = System.Drawing.Color.White.ToArgb();









            ////add Data to to cells
            ////addData(int row, int col, string data, string cell1, string cell2, string format)
            ////addData(7, 2, "114287", "B7", "B7", "#,##0");
            //worksheet.Cells[7, 2] = "114287";
            //workSheet_range = worksheet.get_Range("B7", "B7");
            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.NumberFormat = "#,##0";



            ////addData(7, 3, "", "C7", "C7", "");
            //worksheet.Cells[7, 3] = "";
            //workSheet_range = worksheet.get_Range("C7", "C7");
            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.NumberFormat = "";


            ////addData(worksheet, workSheet_range, 7, 4, "129121", "D7", "D7", "#,##0");
            //worksheet.Cells[7, 4] = "129121";
            //workSheet_range = worksheet.get_Range("D7", "D7");
            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.NumberFormat = "#,##0";


            ////add percentage row
            ////addData(worksheet, workSheet_range, 8, 2, "", "B8", "B8", "");
            //worksheet.Cells[8, 2] = "";
            //workSheet_range = worksheet.get_Range("B8", "B8");
            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.NumberFormat = "";


            ////addData(worksheet, workSheet_range, 8, 3, "=B7/D7", "C8", "C8", "0.0%");
            //worksheet.Cells[8, 3] = "=B7/D7";
            //workSheet_range = worksheet.get_Range("C8", "C8");
            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.NumberFormat = "0.0%";

            ////addData(worksheet, workSheet_range, 8, 4, "", "D8", "D8", "");
            //worksheet.Cells[8, 4] = "";
            //workSheet_range = worksheet.get_Range("D8", "D8");
            //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //workSheet_range.NumberFormat = "";

            ////add empty divider
            ////createHeaders(worksheet, workSheet_range, 9, 2, "", "B9", "D9", 2, "GAINSBORO", true, 10, "");

        }

        /*==========Write Header SUMMARY REPORT Start============*/
        public static void writeHeaderSummaryReport(string strPathFileName, string strStartTime)
        {
           
            try
            {
                FileStream outputfile = null;
                
                outputfile = new FileStream(strPathFileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                DoWrite(writer, "<HTML>");
                DoWrite(writer, "<HEAD>");
                DoWrite(writer, "<META http-equiv='Content-Type' content='text/html; charset=utf-8' />");
                DoWrite(writer, "<TITLE>");
                DoWrite(writer, "SUMMARY REPORT");
                DoWrite(writer, "</TITLE>");
                DoWrite(writer, "</HEAD>");
                DoWrite(writer, "<BODY>");
                DoWrite(writer, "<CENTER>");
                DoWrite(writer, "<H2>SUMMARY REPORT</H2>");
                DoWrite(writer, "<table cellpadding=0 cellspacing=0 border=0 align=center style='font-size:13px;'>");    
                DoWrite(writer, "<tr><td height=50 width='200' align='center' id='StartTime' valign=middle><b>Start Time:</b> " + strStartTime + "</td><td width='200' align='center' id='EndTime'><b>End Time:</b></td></tr>");
                DoWrite(writer, "</table>");
                DoWrite(writer, "<table cellpadding=0 cellspacing=0 style='font-size:13px;' border=1>");
                DoWrite(writer, "<tr style='background-color:#cccccc;font-weight:bold;'>");
                DoWrite(writer, "<td width='400' align=center valign=middle>Test Case Name</td>");
                DoWrite(writer, "<td width='170' align=center valign=middle>Start Time</td>");
                DoWrite(writer, "<td width='170' align=center valign=middle>End Time</td>");
                DoWrite(writer, "<td width='100' align=center valign=middle>Duration</td>");
                DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Checks</td>");
                DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Passes</td>");
                DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Failures</td>");
                DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Errors</td>");
                DoWrite(writer, "</tr>");
                //DoWrite(writer, "<script language=javascript>document.getElementById('EndTime').innerHTML = '<b>End Time:</b> " + strStartTime + "';</script>");
                //DoWrite(writer, "<tr>");
                //DoWrite(writer, "<td align=left valign=middle>Test Case Name</td>");
                //DoWrite(writer, "<td align=center valign=middle>" + EndTime.Subtract(StartTime).ToString().Split('.')[0].ToString() + "</td>");
                //DoWrite(writer, "<td align=center valign=middle>1</td>");
                //DoWrite(writer, "<td align=center valign=middle style='color:#1AC304'>2</td>");
                //DoWrite(writer, "<td align=center valign=middle style='color:#FF0000'>3</td>");
                //DoWrite(writer, "<td align=center valign=middle style='color:#FF0000'>4</td>");
                //DoWrite(writer, "</tr>");
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception GenerateCode = " + ex);
            }
        }
        /*==========Write Header SUMMARY REPORT End============*/
        /*==========Write Content SUMMARY REPORT Start============*/
        //public static void writeContentSummaryReport(string strPathFileName, string strTestCaseName, string strLinkReportFile, int intNumOfPassed, int intNumOfFailed, int intNumOfError, DateTime dateStartTime, DateTime dateEndTime)
        //{

        //    try
        //    {
        //        FileStream outputfile = null;

        //        outputfile = new FileStream(strPathFileName, FileMode.Append, FileAccess.Write);
        //        StreamWriter writer = new StreamWriter(outputfile);
        //        writer.BaseStream.Seek(0, SeekOrigin.End);
                                
        //        DoWrite(writer, "<tr>");
        //        DoWrite(writer, "<td align=left valign=middle><a href='" + strLinkReportFile + "' target=_blank>" + strTestCaseName + "</a></td>");
        //        DoWrite(writer, "<td align=center valign=middle>" + dateStartTime.ToString() + "</td>");
        //        DoWrite(writer, "<td align=center valign=middle>" + dateEndTime.ToString() + "</td>");
        //        DoWrite(writer, "<td align=center valign=middle>" + dateEndTime.Subtract(dateStartTime).ToString().Split('.')[0].ToString() + "</td>");
        //        DoWrite(writer, "<td align=center valign=middle>" + (intNumOfPassed + intNumOfFailed) + "</td>");
        //        DoWrite(writer, "<td align=center valign=middle style='color:#1AC304'>" + intNumOfPassed + "</td>");
        //        DoWrite(writer, "<td align=center valign=middle style='color:#FF0000'>" + intNumOfFailed + "</td>");
        //        DoWrite(writer, "<td align=center valign=middle style='color:#FF0000'>" + intNumOfError + "</td>");
        //        DoWrite(writer, "</tr>");
        //        //DoWrite(writer, "<script language=javascript>document.getElementById('EndTime').innerHTML = '<b>End Time:</b> " + EndTime.ToString() + "';</script>");
        //        writer.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception GenerateCode = " + ex);
        //    }
        //}
        public static void writeContentSummaryReport(string strPathFileName, ITestCase testCase)
        {
            try
            {
                using (FileStream outputfile
                    = new FileStream(strPathFileName, FileMode.Append,
                        FileAccess.Write)
                )
                {
                    using (StreamWriter writer = new StreamWriter(outputfile))
                    {
                        writer.BaseStream.Seek(0, SeekOrigin.End);

                        DoWrite(writer, "<tr>");
                        DoWrite(writer, "<td align=left valign=middle><a href='" + testCase.strLinkReportFile + "' target=_blank>" + testCase.GetClassName() + "</a></td>");
                        DoWrite(writer, "<td align=center valign=middle>" + testCase.dateStartTime.ToString() + "</td>");
                        DoWrite(writer, "<td align=center valign=middle>" + testCase.dateEndTime.ToString() + "</td>");
                        DoWrite(writer, "<td align=center valign=middle>" + testCase.dateEndTime.Subtract(testCase.dateStartTime).ToString().Split('.')[0].ToString() + "</td>");
                        DoWrite(writer, "<td align=center valign=middle>" + (testCase.numOfPassed + testCase.numOfFailed) + "</td>");
                        DoWrite(writer, "<td align=center valign=middle style='color:#1AC304'>" + testCase.numOfPassed + "</td>");
                        DoWrite(writer, "<td align=center valign=middle style='color:#FF0000'>" + testCase.numOfFailed + "</td>");
                        DoWrite(writer, "<td align=center valign=middle style='color:#FF0000'>" + testCase.numOfError + "</td>");
                        DoWrite(writer, "</tr>");
                        //DoWrite(writer, "<script language=javascript>document.getElementById('EndTime').innerHTML = '<b>End Time:</b> " + EndTime.ToString() + "';</script>");
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception GenerateCode = " + ex);
            }
        }
        /*==========Write Content SUMMARY REPORT End============*/
        /*==========Write Finish SUMMARY REPORT Start============*/
        public static void writeFinishSummaryReport(string strPathFileName, string strEndTime)
        {

            try
            {
                FileStream outputfile = null;

                outputfile = new FileStream(strPathFileName, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);

                DoWrite(writer, "</TABLE>");
                DoWrite(writer, "</BODY>");
                DoWrite(writer, "</HTML>");
                DoWrite(writer, "<script language=javascript>document.getElementById('EndTime').innerHTML = '<b>End Time:</b> " + strEndTime + "';</script>");
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception GenerateCode = " + ex);
            }
        }
        /*==========Write Finish SUMMARY REPORT End============*/
        /*==========Write Header REPORT Start============*/
        public static void writeHeaderReport(string strPathFileName, string strTestCaseName, string strStartTime)
        {
            try
            {
                FileStream outputfile = null;

                outputfile = new FileStream(strPathFileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                DoWrite(writer, "<HTML>");
                DoWrite(writer, "<HEAD>");
                DoWrite(writer, "<META http-equiv='Content-Type' content='text/html; charset=utf-8' />");
                DoWrite(writer, "<TITLE>");
                DoWrite(writer, "REPORT");
                DoWrite(writer, "</TITLE>");
                DoWrite(writer, "</HEAD>");
                DoWrite(writer, "<BODY>");
                DoWrite(writer, "<H3>" + strTestCaseName + "</H3>");
                DoWrite(writer, "<table cellpadding=0 cellspacing=0 border=0 style='font-size:13px;'>");
                DoWrite(writer, "<tr>");
                DoWrite(writer, "<td height=20 width='100' align=right valign=middle style='font-weight:bold;'>Start Time:</td>");
                DoWrite(writer, "<td width='10'></td>");
                DoWrite(writer, "<td width='150' align=left valign=middle id='StartTime'>"  + strStartTime + "</td>");
                DoWrite(writer, "</tr>");
                DoWrite(writer, "<tr>");
                DoWrite(writer, "<td height=20 align=right valign=middle style='font-weight:bold;'>End Time:</td>");
                DoWrite(writer, "<td></td>");
                DoWrite(writer, "<td align=left valign=middle id='EndTime'></td>");
                DoWrite(writer, "</tr>");
                DoWrite(writer, "<tr>");
                DoWrite(writer, "<td height=20 align=right valign=middle style='font-weight:bold;'>Duration:</td>");
                DoWrite(writer, "<td></td>");
                DoWrite(writer, "<td align=left valign=middle id='strDuration'></td>");
                DoWrite(writer, "</tr>");
                DoWrite(writer, "<tr>");
                DoWrite(writer, "<td height=20 align=right valign=middle style='font-weight:bold;'>Num Of Checks:</td>");
                DoWrite(writer, "<td></td>");
                DoWrite(writer, "<td align=left valign=middle id='intNumOfChecks'></td>");
                DoWrite(writer, "</tr>");
                DoWrite(writer, "<tr>");
                DoWrite(writer, "<td height=20 align=right valign=middle style='font-weight:bold;'>Num Of Passes:</td>");
                DoWrite(writer, "<td></td>");
                DoWrite(writer, "<td align=left valign=middle id='intNumOfPassed' style='color:#1AC304'></td>");
                DoWrite(writer, "</tr>");
                DoWrite(writer, "<tr>");
                DoWrite(writer, "<td height=20 align=right valign=middle style='font-weight:bold;'>Num Of Failures:</td>");
                DoWrite(writer, "<td></td>");
                DoWrite(writer, "<td align=left valign=middle id='intNumOfFailed' style='color:#FF0000'></td>");
                DoWrite(writer, "</tr>");
                DoWrite(writer, "<tr>");
                DoWrite(writer, "<td height=20 align=right valign=middle style='font-weight:bold;'>Num Of Errors:</td>");
                DoWrite(writer, "<td></td>");
                DoWrite(writer, "<td align=left valign=middle id='intNumOfError' style='color:#FF0000'></td>");
                DoWrite(writer, "</tr>");
                DoWrite(writer, "</table>");
                DoWrite(writer, "<div align=left style='margin-top:40px;font-size:13px;'>");
                
                
                //DoWrite(writer, "<table cellpadding=0 cellspacing=0 border=0 align=center style='font-size:13px;'>");
                //DoWrite(writer, "<tr><td height=50 width='200' align='center' id='StartTime' valign=middle><b>Start Time:</b> " + strStartTime + "</td><td width='200' align='center' id='EndTime'><b>End Time:</b></td></tr>");
                //DoWrite(writer, "</table>");
                //DoWrite(writer, "<table cellpadding=0 cellspacing=0 style='font-size:13px;' border=1>");
                //DoWrite(writer, "<tr style='background-color:#cccccc;font-weight:bold;'>");
                //DoWrite(writer, "<td width='100' align=center valign=middle>Duration</td>");
                //DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Checks</td>");
                //DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Passes</td>");
                //DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Failures</td>");
                //DoWrite(writer, "<td width='100' align=center valign=middle>Num Of Errors</td>");
                //DoWrite(writer, "</tr>");
                //DoWrite(writer, "<tr>");
                //DoWrite(writer, "<td align=center valign=middle id='strDuration'></td>");
                //DoWrite(writer, "<td align=center valign=middle id='intNumOfChecks'></td>");
                //DoWrite(writer, "<td align=center valign=middle style='color:#1AC304' id='intNumOfPassed'></td>");
                //DoWrite(writer, "<td align=center valign=middle style='color:#FF0000' id='intNumOfFailed'></td>");
                //DoWrite(writer, "<td align=center valign=middle style='color:#FF0000' id='intNumOfError'></td>");
                //DoWrite(writer, "</tr>");
                //DoWrite(writer, "</table><div align=left style='margin-top:40px;font-size:13px;'>");

                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception GenerateCode = " + ex);
            }
        }
        /*==========Write Header SUMMARY REPORT End============*/
        /*==========Write Log REPORT Start============*/
        public static void writeLogReport(string strLogMessage, string typeOfLog)
        {
            string strPathReportFile = Directory.GetCurrentDirectory() + "\\Log\\";
            string strReportFileName = "Report.html";
            string strPathFileName = strPathReportFile + strReportFileName;
            try
            {
                FileStream outputfile = null;

                outputfile = new FileStream(strPathFileName, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);


                switch (typeOfLog.ToLower())
                {
                    case "info":
                        DoWrite(writer, "++ <b>" + strLogMessage + "</b><br>");
                        break;
                    case "name":
                        DoWrite(writer, "<span style='color:#1B6BEF;'><b>" + strLogMessage + "</b></span><br>");
                        break;    
                    case "debug":
                        DoWrite(writer, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-- " + strLogMessage + "<br>");
                        break;
                    case "passed":
                        DoWrite(writer, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-- " + strLogMessage + " --> <span style='color:#1AC304;font-weight:bold;'>PASSED</span><br>");
                        break;
                    case "failed":
                        DoWrite(writer, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-- " + strLogMessage + " --> <span style='color:#FF0000;font-weight:bold;'>FAILED</span><br>");
                        break;
                    case "error":
                        DoWrite(writer, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-- <span style='color:#FF0000;'>" + strLogMessage + "</span><br>");
                        break;
                }
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception GenerateCode = " + ex);
            }
        }
        /*==========Write Log REPORT End============*/
        /*==========Write Finish REPORT Start============*/
        public static void writeFinishReport(string strPathFileName, string strDuration, int intNumOfPassed, int intNumOfFailed, int intNumOfError, string strEndTime)
        {

            try
            {
                FileStream outputfile = null;

                outputfile = new FileStream(strPathFileName, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);

                DoWrite(writer, "</div></BODY>");
                DoWrite(writer, "</HTML>");
                DoWrite(writer, "<script language=javascript>");
                DoWrite(writer, "document.getElementById('EndTime').innerHTML = '" + strEndTime + "';");
                DoWrite(writer, "document.getElementById('strDuration').innerHTML = '" + strDuration + "';");
                DoWrite(writer, "document.getElementById('intNumOfChecks').innerHTML = '" + (intNumOfPassed + intNumOfFailed) + "';");
                DoWrite(writer, "document.getElementById('intNumOfPassed').innerHTML = '" + intNumOfPassed + "';");
                DoWrite(writer, "document.getElementById('intNumOfFailed').innerHTML = '" + intNumOfFailed + "';");
                DoWrite(writer, "document.getElementById('intNumOfError').innerHTML = '" + intNumOfError + "';");
                DoWrite(writer, "</script>");
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception GenerateCode = " + ex);
            }
        }
        /*==========Write Finish REPORT End============*/
        /*==========Write to File Start============*/
        private static void DoWrite(StreamWriter writer, String line)
        {
            writer.WriteLine(line);
            writer.Flush();
        }
        /*==========Write to File End============*/
        public static bool isControlExists(ISelenium se, string control, bool flag, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                if (flag == false)
                {
                    Control.waitForControlNotExist(se, control, timeoutSecond, cm);
                    if (se.IsElementPresent(control) == false)
                    {
                        return true;
                    }else{
                        return false;
                    }

                }else{
                    Control.waitForControlExist(se, control, timeoutSecond, cm);
                    if (se.IsElementPresent(control) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' control '" + control + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
                return false;
            }
        }


        public static int doesControlExists(ISelenium se, string control, CommonFunc cm)
        {
            try
            {

                if (se.IsElementPresent(control) == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                Console.WriteLine("========ERROR===========");
                Console.WriteLine("Error when '" + sf.GetMethod().Name + "' control '" + control + "'");
                Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                Console.WriteLine(e.ToString());
                Console.WriteLine("========================");
//                se.Close();
//                se.Stop();
                return 0;
            }
        }

        public static XmlNodeList readDataFromXmlFile(string pathFile, string selectNode, string filterCondition)//filterCondition: @level='agent' and @username='Agent1'; @level='master' or @username='Master01'
        {
            CommonFunc.writeLogReport("Load data from '" + pathFile + "' file", "Info");
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(pathFile);
                XmlNodeList xnList = xml.SelectNodes(selectNode + "[" + filterCondition + "]");
                CommonFunc.writeLogReport("Load data '" + selectNode + "' by filter '" + filterCondition + "'", "Debug");
                return xnList;
            }
            catch (Exception)
            {
                CommonFunc.writeLogReport("Cannot load data from '" + pathFile + "' file", "Error");
                return null;
            }
        }
        public static XmlNodeList readDataFromXmlFile(string pathFile, string selectNode)
        {
            CommonFunc.writeLogReport("Load data from '" + pathFile + "' file", "Info");
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(pathFile);
                XmlNodeList xnList = xml.SelectNodes(selectNode);
                CommonFunc.writeLogReport("Load data '" + selectNode + "'", "Debug");
                return xnList;
            }
            catch (Exception)
            {
                CommonFunc.writeLogReport("Cannot load data from '" + pathFile + "' file", "Error");
                return null;
            }
        }

        public static bool IsDomainValid(string domain, string domainToCheck)
        {

            if (domainToCheck.Contains("*"))
            {

                string checkDomain = domainToCheck;



                if (checkDomain.StartsWith("*."))

                    checkDomain = "*" + checkDomain.Substring(2, checkDomain.Length - 2);



                return DoesWildcardMatch(domain, checkDomain);

            }

            else
            {

                return domainToCheck.Equals(domain, StringComparison.OrdinalIgnoreCase);

            }

        }



        /// <summary>

        /// Performs a wildcard (*) search on any string.

        /// </summary>

        public static bool DoesWildcardMatch(string originalString, string searchString)
        {

            if (!searchString.StartsWith("*"))
            {

                int stop = searchString.IndexOf('*');

                if (!originalString.StartsWith(searchString.Substring(0, stop)))

                    return false;

            }



            if (!searchString.EndsWith("*"))
            {

                int start = searchString.LastIndexOf('*') + 1;

                if (!originalString.EndsWith(searchString.Substring(start, searchString.Length - start)))

                    return false;

            }



            Regex regex = new Regex(searchString.Replace(@".", @"\.").Replace(@"*", @".*"));

            return regex.IsMatch(originalString);

        } 

         public static string Left(string param, int length)
        {
        //we start at 0 since we want to get the characters starting from the
        //left and with the specified lenght and assign it to a variable
        string result = param.Substring(0, length);
        //return the result of the operation
        return result;
        }
        public static string Right(string param, int len)
        {
        //start at the index based on the lenght of the sting minus
        //the specified lenght and assign it a variable
        string result = param.Substring(param.Length - len, len);
        //return the result of the operation
        return result;
        }

        public static string Mid(string param,int startIndex, int length)
        {
        //start at the specified index in the string ang get N number of
        //characters depending on the lenght and assign it to a variable
        string result = param.Substring(startIndex, length);
        //return the result of the operation
        return result;
        }

        public static string Mid(string param,int startIndex)
        {
        //start at the specified index and return all characters after it
        //and assign it to a variable
        string result = param.Substring(startIndex);
        //return the result of the operation
        return result;
        }

        //Read text file
        public static string[] readTextFile(string pathFile, string FileName)
        {
            StreamReader re = new StreamReader(pathFile + "//" + FileName);
            //FileStream fileStream = new FileStream(pathFile + "\\" + FileName, FileMode.Open, FileAccess.Read);
            
            string str="";
            
            string input = null;
            int i = 1;
            while ((input = re.ReadLine()) != null)
            {
                if (i != 1)
                {
                    str = str + input + "\r\n";
                }
                i += 1;
              
            }
            
            string[] arr = Regex.Split(str,"\r\n");
            
            re.Close();
            return arr;
        }

        /**===================Get Duration Time Start==================**/
        public static string getDurationTime(DateTime StartTime, DateTime EndTime)
        {
            return EndTime.Subtract(StartTime).ToString().Split('.')[0].ToString();
        }
        /**===========================================================**/

        /**=============This function to execute series Test Case======**/
        /*public static void RunTest(ITestCase testCase, TestMethod function)
        {
            if (function != null)
            {
                //setup 
                testCase.SetupTest();
                //execute test case
                function.Invoke();
                //teardown
                testCase.TeardownTest();
            }

        }*/
        public static void RunTest(string strPathFileName, string testCaseTypeName)
        {
			try
			{
            	ITestCase testCase = (ITestCase)System.Activator.CreateInstance(Type.GetType(testCaseTypeName));
            	if (testCase != null)
            		{
                	//setup 
                	testCase.SetupTest();
                	//execute test case
                	testCase.TestMethod();
                	//teardown
                	testCase.TeardownTest();
            		}
            	 writeContentSummaryReport(strPathFileName, testCase);
			}
            catch (Exception ex)
            {
                Console.WriteLine("Exception GenerateCode = " + ex);
            }
           
            //write this test case result report
        }
        /**==========================================================**/
        
        /**=============This function to execute series Test Case======**/
        //public static void SumNumOfCheckPassFailError(int numOfPassed, int numOfFailed, int numOfError)
        //{
        //    RunMultipleTestCases aa = new RunMultipleTestCases();
            
        //}
        /**==========================================================**/

        /*===============Create Excel File Start=============*/
        //public void createDoc()
        //{
        //    try
        //    {
        //        app = new Excel.Application();
        //        app.Visible = true;
        //        workbook = app.Workbooks.Add(1);
        //        worksheet = (Excel.Worksheet)workbook.Sheets[1];
        //        Console.Write("Phuc");
        //    }
        //    catch (Exception)
        //    {
        //        Console.Write("Erroraaaaa");
        //    }
        //    finally
        //    {

        //    }
        //}

        //public static void createHeaders(Excel.Worksheet worksheet,Excel.Range workSheet_range, int row, int col, string htext, string cell1, string cell2, int mergeColumns, string b, bool font, int size, string fcolor)
        //{
            
        //    worksheet.Cells[row, col] = htext;
        //    workSheet_range = worksheet.get_Range(cell1, cell2);
        //    workSheet_range.Merge(mergeColumns);
        //    switch (b)
        //    {
        //        case "YELLOW":
        //            workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
        //            break;
        //        case "GRAY":
        //            workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //            break;
        //        case "GAINSBORO":
        //            workSheet_range.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();
        //            break;
        //        case "Turquoise":
        //            workSheet_range.Interior.Color = System.Drawing.Color.Turquoise.ToArgb();
        //            break;
        //        case "PeachPuff":
        //            workSheet_range.Interior.Color = System.Drawing.Color.PeachPuff.ToArgb();
        //            break;
        //        default:
        //            //  workSheet_range.Interior.Color = System.Drawing.Color..ToArgb();
        //            break;

        //    }

        //    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    workSheet_range.Font.Bold = font;
        //    workSheet_range.ColumnWidth = size;
        //    if (fcolor.Equals(""))
        //    {
        //        workSheet_range.Font.Color = System.Drawing.Color.White.ToArgb();
        //    }
        //    else
        //    {
        //        workSheet_range.Font.Color = System.Drawing.Color.Black.ToArgb();
        //    }

        //}
        //private static void addData(Excel.Worksheet worksheet, Excel.Range workSheet_range, int row, int col, string data, string cell1, string cell2, string format)
        //{
        //    worksheet.Cells[row, col] = data;
        //    workSheet_range = worksheet.get_Range(cell1, cell2);
        //    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    workSheet_range.NumberFormat = format;
        //}
        /*===============Create Excel File End=============*/

    }
    class Routines
    {
        // delete file on reboot
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, int dwFlags);
        const int MOVEFILE_DELAY_UNTIL_REBOOT = 0x00000004;

        // lists, which keep information about the links, the pure links, the image links and others 
        public static SortedList<string, string> links = new SortedList<string, string>();
        public static SortedList<string, string> shortlinks = new SortedList<string, string>();
        public static SortedList<string, string> imagelinks = new SortedList<string, string>();
        public static SortedList<string, string> otherlinks = new SortedList<string, string>();

        // Some static methods for administrative purposes

        #region Read index.dat

        /// <summary>
        /// Reads a file of type index.dat (indexfile) and extracts some information.
        /// All found URLs are stored in the SortedList links. 
        /// links contains the following information:
        /// - all found links, reduced to pure address, are stored in the SortedList shortlinks
        /// - all found image links are stored in the SortedList imagelinks
        /// - all other links (not address and not image) are stored in the SortedList otherlinks.
        /// If additive = true, the 4 SortedLists will not be cleared on start, so they may contain
        /// the content of more than one index.dat.
        /// </summary>
        /// <param name="indexfile"></param>
        /// <param name="additive"></param>
        public static void ReadIndexDat(string indexfile, bool additive)
        {
            if (!File.Exists(indexfile))
            {
                //MessageBox.Show("The file " + indexfile + " does not exist!",
                //         "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (!additive) links.Clear();
                // open file in read mode
                Stream fStream = new FileStream(indexfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                byte[] buffer = new byte[fStream.Length];
                fStream.Read(buffer, 0, buffer.Length);
                // close file
                fStream.Close();
                String delim = " \0";
                for (int c = 0; c < buffer.Length - 4; c++)
                {
                    if ((buffer[c] == 'h') && (buffer[c + 1] == 't') && (buffer[c + 2] == 't') && (buffer[c + 3] == 'p'))
                    {
                        string slink = "";
                        for (int l = c; l < buffer.Length; l++)
                        {
                            byte blink = buffer[l];
                            if ((blink != '%') && (blink != '?') && (blink <= 127))
                            {
                                slink += (char)(blink);
                            }
                            else
                            {
                                c = l;
                                if (slink.Length > 4)
                                {
                                    string url_l = slink.ToLower().Trim(delim.ToCharArray());
                                    if (!links.ContainsKey(url_l)) links.Add(url_l, url_l);
                                }
                                break;
                            }
                        } // for
                    } // if http
                } // for
                // fill the lists with pure Link names, Image links and Others
                if (!additive)
                {
                    shortlinks.Clear();
                    imagelinks.Clear();
                    otherlinks.Clear();
                }
                bool listed = false;
                foreach (string li in links.Keys)
                {
                    string url_l = li.ToLower().Trim(delim.ToCharArray());
                    int nullend = url_l.IndexOf("\0");
                    if (nullend > 0)
                        url_l = url_l.Substring(0, nullend);
                    listed = false;
                    // Images
                    if (url_l.EndsWith(".bmp") || url_l.EndsWith(".ico") ||
                        url_l.EndsWith(".jpg") || url_l.EndsWith(".gif") || url_l.EndsWith(".png"))
                    {
                        // Image
                        if (!imagelinks.ContainsKey(url_l))
                        {
                            imagelinks.Add(url_l, url_l);
                            listed = true;
                        }
                    } // Image
                    // Links and Others
                    if (!listed)
                    {
                        // Links
                        int dp = url_l.IndexOf(":");
                        if (dp > 0)
                        {
                            int slash = url_l.IndexOf("/", dp + 3);
                            if (slash >= 0)
                            {
                                string shortlink = url_l.Substring(0, slash);
                                if (!shortlinks.ContainsKey(shortlink))
                                {
                                    shortlinks.Add(shortlink, shortlink);
                                }
                            }
                        }
                        else
                        {
                            // Other
                            if (!otherlinks.ContainsKey(url_l))
                            {
                                otherlinks.Add(url_l, url_l);
                            }
                        } // Other
                    } // if !listed
                } // foreach
            } // try
            catch
            {
                //MessageBox.Show("The file " + indexfile + " cannot be accessed!",
                //                "Access error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } // catch
        } // ReadIndexDat

        /// <summary>
        /// Reads a file of type cookie index.dat (indexfile) and extracts the cookie information.
        /// All found URLs are stored in the SortedList links. 
        /// </summary>
        /// <param name="indexfile"></param>
        public static void ReadCookiesIndexDat(string indexfile)
        {
            if (!File.Exists(indexfile))
            {
                //MessageBox.Show("The file " + indexfile + " does not exist!",
                //         "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                links.Clear();
                // open cookies index.dat file in read mode
                Stream fStream = new FileStream(indexfile, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] buffer = new byte[fStream.Length];
                fStream.Read(buffer, 0, buffer.Length);
                // close index.dat
                fStream.Close();
                String delim = " \0";
                for (int c = 0; c < buffer.Length - 7; c++)
                {
                    if ((buffer[c] == 'C') && (buffer[c + 1] == 'o') && (buffer[c + 2] == 'o') && (buffer[c + 3] == 'k') && (buffer[c + 4] == 'i') && (buffer[c + 5] == 'e') && (buffer[c + 6] == ':'))
                    {
                        string slink = "";
                        for (int l = c; l < buffer.Length; l++)
                        {
                            byte blink = buffer[l];
                            if ((blink != '%') && (blink != '?') && (blink <= 127))
                            {
                                slink += (char)(blink);
                            }
                            else
                            {
                                c = l;
                                if (slink.Length > 7)
                                {
                                    string url_l = slink.ToLower().Trim(delim.ToCharArray());
                                    if (!links.ContainsKey(url_l)) links.Add(url_l, url_l);
                                }
                                break;
                            }
                        } // for
                    } // if Cookie:
                } // for
            } // try
            catch
            {
                //MessageBox.Show("The file " + indexfile + " cannot be accessed!",
                //                "Access error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } // catch
        } // ReadCookiesIndexDat

        #endregion

        #region Delete file

        /// <summary>
        /// Tries to delete a file immediatetely.
        /// If this is not possible, the file is marked to be deleted on next reboot.
        /// bool output: if true, a message box will be shown, which informs the user, that
        /// the file is marked to be deleted on next reboot.
        /// Return value: int = 1: the file could be deleted immediately
        ///                   = 2: the file is marked to be deleted on next reboot
        /// </summary>
        /// <param name="file"></param>
        /// <param name="output"></param>
        public static int DeleteCacheIndexDat(string file, bool output)
        {
            int ret = 2;
            try
            {
                ret = 1;
                File.Delete(file);
            }
            catch
            {
                ret = 2;
                MarkFileToDeleteOnReboot(file);
                //if (output)
                    //MessageBox.Show("The file " + file + " is marked to be deleted on next reboot!",
                    //                "Delete index.dat file", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return ret;
        } // DeleteCacheIndexDat

        /// <summary>
        /// Marks a file filename to be deleted after reboot.
        /// </summary>
        /// <param name="fileName"></param>
        static public void MarkFileToDeleteOnReboot(string fileName)
        {
            MoveFileEx(fileName, null, MOVEFILE_DELAY_UNTIL_REBOOT);
        } // MarkFileToDeleteOnReboot

        #endregion

        #region Listview handling

        /// <summary>
        /// Collects all checked items of the listview ListViewSource and puts them (content of column)
        /// into the listview ListViewMyURL, The new content of ListViewMyURL is written
        /// to the file urls.txt, which holds all private (= my personal) urls.
        /// </summary>
        /// <param name="ListViewSource"></param>
        /// <param name="ListViewMyURL"></param>
        /// <param name="column"></param>
        //public static void StoreListViewToMyURLList(ListView ListViewSource, ListView ListViewMyURL, int column)
        //{
        //    // get the list of the previous stored URLs
        //    string f = Path.GetDirectoryName(Application.StartupPath) + @"\urls.txt";
        //    string line;
        //    ArrayList urls = new ArrayList();
        //    urls.Clear();
        //    if (File.Exists(f))
        //    {
        //        FileStream objFStreamRead = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.Read);
        //        StreamReader objSReader = new StreamReader(objFStreamRead, System.Text.Encoding.Default);
        //        while ((line = objSReader.ReadLine()) != null)
        //        {
        //            line = line.Trim();
        //            if (!urls.Contains(line)) urls.Add(line);
        //        }
        //        objSReader.Close();
        //        objFStreamRead.Close();
        //    }
        //    // get the selected items from the source listview
        //    foreach (ListViewItem lvi in ListViewSource.Items)
        //    {
        //        if (lvi.Checked == true)
        //        {
        //            line = lvi.SubItems[column].Text.Trim();
        //            if (!urls.Contains(line))
        //            {
        //                urls.Add(line);
        //                int itemcounter = ListViewMyURL.Items.Count + 1;
        //                // update also the listview with my URLs
        //                ListViewItem item = new ListViewItem(itemcounter.ToString(), 0);
        //                // place a check mark next to the item
        //                item.Checked = false;
        //                item.SubItems.Add(line);
        //                ListViewMyURL.Items.Add(item);
        //            }
        //        }
        //    } // foreach
        //    // store the list in the file for previous stored URLs
        //    if (File.Exists(f)) File.Delete(f);
        //    FileStream objFStream = new FileStream(f, FileMode.Append, FileAccess.Write, FileShare.None);
        //    StreamWriter objSWriter = new StreamWriter(objFStream, System.Text.Encoding.Default);
        //    for (int u = 0; u < urls.Count; u++)
        //    {
        //        objSWriter.WriteLine(urls[u].ToString());
        //    }
        //    objSWriter.Close();
        //    objFStream.Close();
        //} // StoreListViewToMyURLList

        ///// <summary>
        ///// Selects or deselects all item checks of a listview lv.
        ///// Select:   ischecked = true
        ///// Deselect: ischecked = false
        ///// </summary>
        ///// <param name="lv"></param>
        ///// <param name="ischecked"></param>
        //public static void SetListViewChecks(ListView lv, bool ischecked)
        //{
        //    foreach (ListViewItem lvi in lv.Items)
        //    {
        //        lvi.Checked = ischecked;
        //    }
        //} // SetListViewChecks

        #endregion

    }
}