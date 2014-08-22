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
using System.Drawing;
using System.Drawing.Imaging;

namespace SeleniumTests
{
    public class Control
    {
        /*The function getControlProperty with timeout parameter
         *Created by Ryan Nguyen*/
        public static string getControlProperty(ISelenium se, string strControlName, string strProperty, int timeoutSecond, CommonFunc cm)
        {
			waitForControlExist(se, strControlName, timeoutSecond, cm);           
        	try
            {
                string strVal = se.GetAttribute(strControlName + "@" + strProperty);
                CommonFunc.writeLogReport("Get control property '" + strControlName + "': " + strProperty + "-> " + strVal, "Debug");
                return strVal;
            }
            catch (Exception e)
            {
                return (e.ToString());
            }
                      
        }
        
        /*The function getControlProperty without timeout parameter
         *Created by William*/
        public static string getControlProperty(ISelenium se, string strControlName, string strProperty, CommonFunc cm)
        {
        	try
            {
                string strVal = se.GetAttribute(strControlName + "@" + strProperty);
                CommonFunc.writeLogReport("Get control property '" + strControlName + "': " + strProperty + "-> " + strVal, "Debug");
                return strVal;
            }
            catch (Exception e)
            {
                return (e.ToString());
            }
                      
        }
        
        public static string getControlHeight(ISelenium se, string strControlName)
        {
            try
            {
                string strVal = se.GetElementHeight(strControlName).ToString();
                CommonFunc.writeLogReport("Get control Height '" + strControlName + "'-> " + strVal, "Debug");
                return strVal;
            }
            catch (Exception e)
            {
                return (e.ToString());
            }

        }
        public static void click(ISelenium se, string control, CommonFunc cm)
        {
            try
            {
                se.Highlight(control);
                se.Click(control);
                CommonFunc.writeLogReport("Click on control '" + control + "'", "Debug");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport("Error when click on control '" + control + "'", "Error");
                CommonFunc.writeLogReport("Line Number: " + sf.GetFileLineNumber(), "Error");
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }

        public static void click(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                waitForControlExist(se, control, timeoutSecond, cm);
                CommonFunc.writeLogReport("Click on control '" + control + "'", "Debug");
                se.Click(control);
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc. writeLogReport("Error when click on control '" + control + "'", "Error");
                CommonFunc.writeLogReport("Line Number: " + sf.GetFileLineNumber(), "Error");
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
             
            }
        }

        public static void addText(ISelenium se, string control, string str, CommonFunc cm)
        {
            try
            {
                se.Type(control, str);
                CommonFunc.writeLogReport("Enter '" + str + "' to control '" + control + "'", "Debug");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport("Error '" + sf.GetMethod().Name + "' into control '" + control + "'", "Error");
                CommonFunc.writeLogReport("Line Number: " + sf.GetFileLineNumber(), "Error");
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
                
            }
        }

         public static void addText(ISelenium se, string control, string str,int timeoutSecond, CommonFunc cm)
        {
            try
            {
				waitForControlExist(se, control, timeoutSecond, cm);               
            	se.Type(control, str);
                CommonFunc.writeLogReport("Enter '" + str + "' to control '" + control + "'", "Debug");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport("Error '" + sf.GetMethod().Name + "' into control '" + control + "'", "Error");
                CommonFunc.writeLogReport("Line Number: " + sf.GetFileLineNumber(), "Error");
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
                
            }
        }
        
        public static void select(ISelenium se, string control, string strLabel, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                waitForControlExist(se, control, timeoutSecond, cm);
                se.Select(control, "label="+strLabel);
                CommonFunc.writeLogReport("Select '" + strLabel + "' in control '" + control + "'", "Debug");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
               	CommonFunc.writeLogReport("Error '" + sf.GetMethod().Name + "' into control '" + control + "'", "Error");
                CommonFunc.writeLogReport("Line Number: " + sf.GetFileLineNumber(), "Error");
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }

        /*
         * Created by: William Nguyen
         * Date: Jun 05 2012
         * Descriptions:
         *      - This function is used to select items in combobox if combobox contains optgroup tags 
         *        and there are more than 2 items that are the same.
         * Parameters:
         *      - strLabel: the label of item that we want to select
         *      - order: order of item in combobox
         */
        public static void select(ISelenium se, string control, string strLabel, int order, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                waitForControlExist(se, control, timeoutSecond, cm);
                if (order < 2)
                {
                    se.Select(control, "label=" + strLabel);
                    CommonFunc.writeLogReport("Select '" + strLabel + "' in control '" + control + "'", "Debug");
                }
                else
                {
                    se.ClickAt(control, "5,5");
                    se.KeyPress(control, "36");//36(home); 35(end); 37(left arrow); 38(up arrow); 39(right arrow); 40(down arrow)
                    string[] arrListOptions = se.GetSelectOptions(control);
                    string strIndex = "";
                    for (var i = 0; i <= arrListOptions.Length - 1; i++)
                    {
                        if (arrListOptions[i].ToLower() == strLabel.ToLower())
                        {
                            strIndex = strIndex + i.ToString() + ",";
                        }
                        //Console.WriteLine(arrListOptions[i]);
                    }
                    strIndex = strIndex.Substring(0, strIndex.Length - 1);
                    string[] arrIndexOfLabels = strIndex.Split(',');
                    for (var j = 1; j <= Convert.ToInt16(arrIndexOfLabels[order - 1]); j++)
                    {
                        se.KeyPress(control, "40");//40(down arrow)
                    }
                    se.KeyPress(control, "13");//13(Enter)
                    CommonFunc.writeLogReport("Select '" + strLabel + "' in control '" + control + "' - order: " + order, "Debug");
                }
                
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }

        public static void selectFrame(ISelenium se, string strFrameName, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Select Frame '" + strFrameName + "'", "Debug");
                se.SelectFrame(strFrameName);
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }

        public static void Check(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
			waitForControlExist(se, control, timeoutSecond, cm);           
        	try
            {
                
                //se.Check(control);
                if (getCheckboxStatus(se, control, timeoutSecond, cm) == false)
                {
                    click(se, control, timeoutSecond, cm);
                }
                CommonFunc.writeLogReport("Check checkbox '" + control + "'", "Debug");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
        public static bool getCheckboxStatus(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                bool flag = false;
                waitForControlExist(se, control, timeoutSecond, cm);
                //se.Check(control);
                if (se.IsChecked(control) == true)
                {
                    flag = true;
                    CommonFunc.writeLogReport("Get checkbox '" + control + "' status = TRUE", "Debug");
                }
                else
                {
                    flag = false;
                    CommonFunc.writeLogReport("Get checkbox '" + control + "' status = FALSE", "Debug");
                }
                return flag;
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                return false;
            }
        }
        public static void verifyControlChecked(ISelenium se, string control, bool flag, int timeoutSecond, CommonFunc cm)
        {
            waitForControlExist(se, control, timeoutSecond, cm);
        	try
            {
                if ((getCheckboxStatus(se, control, timeoutSecond, cm) == true && flag == true) || (getCheckboxStatus(se, control, timeoutSecond, cm) == false && flag == false))
                {
                    if (flag == true)
                    {
                        cm.numOfPassed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' checked", "Passed");
                    }
                    else
                    {
                        cm.numOfPassed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' not checked", "Passed");
                    }
                }
                else
                {
                    if (flag == true)
                    {
                        cm.numOfFailed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' checked", "Failed" ); 
                        CaptureScreenshot();
                        
                    }
                    else
                    {
                        cm.numOfFailed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' not checked", "Failed" ); 
                        CaptureScreenshot();
                        
                    }
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
        
        //Create by Ryan
        //Capture Screenshot, no need parameter
        //Using: put it at any place
        //output :\\Automation Test Results\\ScreenShot\\
        public static string CaptureScreenshot()
		{
        	Bitmap bmpScreenshot = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
			Graphics Screenshot = Graphics.FromImage(bmpScreenshot);
			Screenshot.CopyFromScreen(0, 0, 0, 0, new Size(1024, 768));
			string name = ("ScreenShot "+System.Convert.ToString(System.DateTime.Now).Replace("/", "_")).Replace(":", "_") + ".jpg";
       		string sourcePath = @"D:\Nexcel_Auto\QC\Selenium\TestProject1\bin\Debug";
        	string targetPath =  @"D:\Automation Test Results\ScreenShot";
			string sourceFile = System.IO.Path.Combine(sourcePath, name);
        	string destFile = System.IO.Path.Combine(targetPath, name);
        	if (!System.IO.Directory.Exists(targetPath))
        		{
            System.IO.Directory.CreateDirectory(targetPath);
        		}
			bmpScreenshot.Save(name,ImageFormat.Jpeg);
			System.IO.File.Move(sourceFile, destFile);
			return name;
		}

		//Create by Ryan
        //get 7 days before
        //Using: put it at any place
        //output :\\Automation Test Results\\ScreenShot\\
        
        public static string getSevenDaysBefore()
 		{
			 return DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy");
 		}
        
        
         public static string getSevenDaysBeforeTextFormat()
 		{
			 return DateTime.Now.AddDays(-7).ToString("MMMM dd, yyyy");
 		}
        
        public static void Uncheck(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                waitForControlExist(se, control, timeoutSecond, cm);
                //se.Uncheck(control);
                if (getCheckboxStatus(se, control, timeoutSecond, cm) == true)
                {
                    click(se, control, timeoutSecond, cm);
                }
                CommonFunc.writeLogReport("Uncheck checkbox '" + control + "'", "Debug");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
        

        public static void checkTextInControl(ISelenium se, string control, string strExpectedResult, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Check text in control '" + control + "'......", "Debug");
                string strObservedResult = se.GetText(control);
                if (strObservedResult == strExpectedResult)
                {
                    cm.numOfPassed += 1;
                    CommonFunc.writeLogReport("&nbsp;&nbsp;&nbsp;&nbsp;Expected Result: " + strExpectedResult + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Observed Result: " + strObservedResult + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Result: ", "Passed");
                }
                else
                {
                    cm.numOfFailed += 1;
                    CommonFunc.writeLogReport("&nbsp;&nbsp;&nbsp;&nbsp;Expected Result: " + strExpectedResult + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Observed Result: " + strObservedResult + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Result: ", "Failed" ); 
                    CaptureScreenshot();
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport("Error '" + sf.GetMethod().Name + "' into control '" + control + "'", "Error");
                CommonFunc.writeLogReport("Line Number: " + sf.GetFileLineNumber(), "Error");
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }

        public static void waitForControlExist(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                int indexTime = 1;
                bool flag = false;
                while (indexTime <= timeoutSecond && flag == false)
                {
                    CommonFunc.writeLogReport("Waiting for control '" + control + "' exist...........", "Debug");
                    Thread.Sleep(3000);
                    if (se.IsElementPresent(control))
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
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }

        public static void waitForControlNotExist(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                int indexTime = 1;
                bool flag = false;
                while (indexTime <= timeoutSecond && flag == false)
                {
                    CommonFunc.writeLogReport("Waiting for control '" + control + "' not exist...........", "Debug");
                    Thread.Sleep(3000);
                    if (se.IsElementPresent(control) == false)
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
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
	
        
        public static bool doesControlExist(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Does control '" + control + "' exist", "Debug");
                return se.IsElementPresent(control);
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                return false;
            }
        }

        //verify that the control is existed
        public static void checkControlExist(ISelenium se, string control, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                waitForControlExist(se, control, timeoutSecond, cm);
                if (doesControlExist(se, control,timeoutSecond, cm) == true)
                {
                    cm.numOfPassed += 1;
                    CommonFunc.writeLogReport("Check control '" + control + "' exist", "Passed");
                }
                else
                {
                    cm.numOfFailed += 1;
                    CommonFunc.writeLogReport("Check control '" + control + "' exist", "Failed"); 
                    CaptureScreenshot();
                    
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
        
        
         //verify that the control is existed or not existed by enter Flag
         //Create by Ryan
        public static void checkControlExist(ISelenium se, string control, bool flag, int timeoutSecond, CommonFunc cm)
        {
            waitForControlExist(se, control, timeoutSecond, cm);
        	try
            {
                if ((doesControlExist(se, control, timeoutSecond, cm) == true && flag == true) || (doesControlExist(se, control, timeoutSecond, cm) == false && flag == false))
                {
                    if (flag == true)
                    {
                        cm.numOfPassed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' existed", "Passed");
                    }
                    else
                    {
                        cm.numOfPassed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' not existed", "Passed");
                    }
                }
                else
                {
                    if (flag == true)
                    {
                        cm.numOfFailed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' existed", "Failed"); 
                        CaptureScreenshot();
                        
                    }
                    else
                    {
                        cm.numOfFailed += 1;
                        CommonFunc.writeLogReport("Verify control '" + control + "' not existed", "Failed"); 
                        CaptureScreenshot();
                        
                    }
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
        
      

        //Get text in a table
        public static string getTextInTable(ISelenium se, string tableID_or_Name, int row, int col, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                string textInCell = se.GetTable(tableID_or_Name + "." + row + "." + col);
                CommonFunc.writeLogReport("Get text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' = '" + textInCell + "'", "Debug");
                Control.waitForControlExist(se, tableID_or_Name, timeoutSecond, cm);
                
                //Console.WriteLine("Get text in table '" + tableID_or_Name + "' at row/col '" + row + "/" + col + "' = '" + textInCell + "'");
                return textInCell;
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                return "isNaN";
            }
        }

        /*public static string getTextInTableNoID(ISelenium se, int row, int col, int timeoutSecond, CommonFunc cm)
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
        }*/

        //Get value of the object
        public static string getValue(ISelenium se, string locator, int timeoutSecond, CommonFunc cm)
        {
            try
            {

                Control.waitForControlExist(se, locator, timeoutSecond, cm);
                string valueInCell = se.GetValue(locator);
                CommonFunc.writeLogReport("The value of field '"+ locator +"' is '" + valueInCell + "'","Debug");
                //Console.WriteLine("Get value in table '" + valueInCell + "'");
                return valueInCell;
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                return "isNaN";
            }
        }
        /*create by Ryan.Nguyen
         * date: 30-05-2012
         *Get text of the object*/
         public static string getText(ISelenium se, string locator, int timeoutSecond, CommonFunc cm)
        {
            try
            {
				
                Control.waitForControlExist(se, locator, timeoutSecond, cm);
                string text = se.GetText(locator);
				//Console.WriteLine("Get title '" + title + "'");
				CommonFunc.writeLogReport("The text of field '"+ locator +"' is '" + text + "'","Debug");
                return text;
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                return "isNaN";
            }
        }
         /*create by Ryan.Nguyen
          * date: 30-05-2012
          *Compare value of 2 objects */
         public static void verifyEquals(ISelenium se, string firstcontrol, string secondcontrol, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                if (Equals(firstcontrol, secondcontrol) == true)
                {
                    cm.numOfPassed += 1;
                    CommonFunc.writeLogReport("Two values are equals", "Passed");
                }
                else
                {
                    cm.numOfFailed += 1;
                    CommonFunc.writeLogReport("Two values are not equals", "Failed"); 
                    CaptureScreenshot();
                    
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
         /*create by Ryan.Nguyen
          * date: 30-05-2012
          *Compare all values of 2 arrays*/
         public static void verifyEqualsArray(ISelenium se, string[] firstcontrol, string[] secondcontrol, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                if (ArraysEqual(firstcontrol, secondcontrol) == true)
                {
                    cm.numOfPassed += 1;
                    CommonFunc.writeLogReport("Two values are equals", "Passed");
                }
                else
                {
                    cm.numOfFailed += 1;
                    CommonFunc.writeLogReport("Two values are not equals", "Failed"); 
                    CaptureScreenshot();
                    
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
         
          /*create by Ryan.Nguyen
          * date: 20-07-2012
          *verify checkboxes are true or false*/
         public static void verifyMultipleCheckboxesStatus(ISelenium se, bool[] control, bool flag, int timeoutSecond, CommonFunc cm)
        {
            try
            {
            	//for(int i=0;i<control.Length;i++)
            	
            		if (isChecks(control, true) == true && flag == true) 
               			{
                        	cm.numOfPassed += 1;
                        	CommonFunc.writeLogReport("Verify control '" + control + "' are checked", "Passed");
                    	}
                    else if(isChecks(control, false) == true && flag == false)
                    	{
                       		cm.numOfPassed += 1;
                        	CommonFunc.writeLogReport("Verify control '" + control + "' are not checked", "Passed");
                    	}
                	else if(isChecks(control, true) == false && flag == true)
                    	{
                        	cm.numOfFailed += 1;
                        	CommonFunc.writeLogReport("Verify control '" + control + "' are checked", "Failed"); 
                        	CaptureScreenshot();
                    	}
                    else if(isChecks(control, false) == false && flag == false)
                    	{
                        	cm.numOfFailed += 1;
                        	CommonFunc.writeLogReport("Verify control '" + control + "' are not checked", "Failed"); 
                        	CaptureScreenshot();
	                    }
	                
            }
            
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
         
         
          /*create by Ryan.Nguyen
          * date: 20-07-2012
          *used for verify checkboxes are true or false function*/
         
         public static bool isChecks(bool[] arr, bool flag)
        	
       		{        	
        	
	        for (int i = 0; i < arr.Length; i++ ){
        		if(flag){
        			if(!arr[i])
        				return false;
	        	}	     
        		else{
        			if(arr[i])
        				return false;
        		}
        	}
        	
        	return true;
         }
         
         
         /*create by Ryan.Nguyen
          * date: 30-05-2012
          * used for verifyEqualsArray*/
         public static bool ArraysEqual<T>(T[] a1, T[] a2)
         {
             if (ReferenceEquals(a1, a2))
                 return true;

             if (a1 == null || a2 == null)
                 return false;

             if (a1.Length != a2.Length)
                 return false;

             EqualityComparer<T> comparer = EqualityComparer<T>.Default;
             for (int i = 0; i < a1.Length; i++)
             {
                 if (!comparer.Equals(a1[i], a2[i])) return false;
             }
             return true;
         }
         
         
        
       
          /*create by Ryan.Nguyen
          * date: 4-06-2012
          *verify control is disabled*/
         public static void verifyControlIsDisable(ISelenium se, string strControlName, string strProperty, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                if (getControlProperty(se,strControlName, strProperty,timeoutSecond,cm) == "true")
                {
                    cm.numOfPassed += 1;
                    CommonFunc.writeLogReport("Control '"+ strControlName +"'is disabled", "Passed");
                }
                else
                {
                    cm.numOfFailed += 1;
                    CommonFunc.writeLogReport("Control '"+ strControlName +"'is enable", "Failed");
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }

         /*
         *Created by: William.Nguyen
         *Date      : 26-12-2012
         *Function  : Verify control is disabled
         *Params    : selenium, control, timeout, fcommom (this param is used to write log)
         */
         public static void verifyControlIsDisable(ISelenium se, string strControlName, int timeoutSecond, CommonFunc cm)
         {
             try
             {
                 if (getControlProperty(se, strControlName, "disabled", timeoutSecond, cm) == "true")
                 {
                     cm.numOfPassed += 1;
                     CommonFunc.writeLogReport("Verified control '" + strControlName + "' is disabled", "Passed");
                 }
                 else
                 {
                     cm.numOfFailed += 1;
                     CommonFunc.writeLogReport("Verified control '" + strControlName + "' is disabled", "Failed");
                 }
             }
             catch (Exception e)
             {
                 cm.numOfError = cm.numOfError + 1;
                 StackTrace st = new StackTrace(new StackFrame(true));
                 StackFrame sf = st.GetFrame(0);
                 CommonFunc.writeLogReport(e.ToString(), "Error");
                 
             }
         }
         
         
          /*create by Ryan.Nguyen
          * date: 4-06-2012
          *verify control is enable*/
         public static void verifyControlIsEnable(ISelenium se, string strControlName, string strProperty, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                if (getControlProperty(se,strControlName, strProperty,timeoutSecond,cm) == "true")
                {
                    cm.numOfFailed += 1;
                    CommonFunc.writeLogReport("Control '"+ strControlName +"'is disabled", "Failed");
                }
                else
                {
                    cm.numOfPassed += 1;
                    CommonFunc.writeLogReport("Control '"+ strControlName +"'is enable", "Passed");
                }
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }


         /*
          *Created by: William.Nguyen
          *Date      : 26-12-2012
          *Function  : Verify control is enabled
          *Params    : selenium, control, timeout, fcommom (this param is used to write log)
         */
         public static void verifyControlIsEnable(ISelenium se, string strControlName, int timeoutSecond, CommonFunc cm)
         {
             try
             {
                 if (getControlProperty(se, strControlName, "disabled", timeoutSecond, cm) == "true")
                 {
                     cm.numOfFailed += 1;
                     CommonFunc.writeLogReport("Verify control '" + strControlName + "' is enabled", "Failed");
                 }
                 else
                 {
                     cm.numOfPassed += 1;
                     CommonFunc.writeLogReport("Verify control '" + strControlName + "' is enabled", "Passed");
                 }
             }
             catch (Exception e)
             {
                 cm.numOfError = cm.numOfError + 1;
                 StackTrace st = new StackTrace(new StackFrame(true));
                 StackFrame sf = st.GetFrame(0);
                 CommonFunc.writeLogReport(e.ToString(), "Error");
                 
             }
         }
         
          public static void verifyPopup(ISelenium se, CommonFunc cm)
        {
            try
            {
            	String href = se.GetAttribute("link=http://10.18.200.201:8005/OWA1/Report/ExchangeRate@herf");
            	se.OpenWindow(href,"Opening");
            	
                CommonFunc.writeLogReport("Focus on Popup " , "Debug");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                //CommonFunc.writeLogReport("Error when click on control '" + control + "'", "Error");
                CommonFunc.writeLogReport("Line Number: " + sf.GetFileLineNumber(), "Error");
                CommonFunc.writeLogReport(e.ToString(), "Error");
//                if (se!= null)
//                {
//                	se.Stop();
//                	se.Close();
//                }
            }
        }
    }

}
