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
using System.ComponentModel;
using SeleniumTests.OWA.Report;

namespace SeleniumTests
{
	public class OWA_MainFunction 
    {
         public static void Login(ISelenium se, string strUserName, string strPassword, int timeoutSecond,CommonFunc cm)
        {
            //CommonFunc.writeLogReport("Log in", "Info");
            try
            {
                OWA_UILogin Login = new OWA_UILogin();
                Control.addText(se, Login.txtUserName, strUserName,timeoutSecond,cm);
                Control.addText(se, Login.txtPassword, strPassword,timeoutSecond,cm);
                Control.click(se, Login.btnLogin, cm);
                se.WaitForPageToLoad("80000");
                
                //cm.numOfPassed += 1;
            }
            catch (Exception e)
            {
            	cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                if (se!= null)
                {
                	se.Stop();
                	se.Close();
                }
            }
        }
         
        public static void gotoManageGroup(ISelenium se, int timeoutSecond,CommonFunc cm)
        {
         	try
            {
         		OWA_UIMainPage mainpage = new OWA_UIMainPage();
                Control.click(se, mainpage.lnkManageGroup, cm);
                se.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                if (se!= null)
                {
                	se.Stop();
                	se.Close();
                }
            }
        }
        
        public static void gotoHomePage(ISelenium se, int timeoutSecond,CommonFunc cm)
        {
         	try
            {
         		OWA_UIMainPage mainpage = new OWA_UIMainPage();
                Control.click(se, mainpage.lnkHomePage, cm);
                se.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                if (se!= null)
                {
                	se.Stop();
                	se.Close();
                }
            }
        }

        public static void Logout(ISelenium se, int timeoutSecond,CommonFunc cm)
        {
        	//CommonFunc.writeLogReport("Log out", "Info");
            try
            {
                OWA_UIMainPage mainpage = new OWA_UIMainPage();
                Control.click(se, mainpage.lnkLogout, cm);
            }
          
         	catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                if (se!= null)
                {
                	se.Stop();
                	se.Close();
                }
            }
        }
     }
}