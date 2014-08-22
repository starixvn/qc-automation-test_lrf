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

namespace SeleniumTests
{
    public class Acc_Common
    {
        public static void Login(ISelenium se, string strUserName, string strPassword, string strCaptcha, int timeoutSecond, CommonFunc cm)
        {
            CommonFunc.writeLogReport("Log in", "Info");
            try
            {
                Acc_UILogin UILogin = new Acc_UILogin();
                Control.addText(se, UILogin.txtUserName, strUserName, cm);
                Control.addText(se, UILogin.txtPassword, strPassword, cm);
                //Control.addText(se, UILogin.txtCaptcha, strCaptcha, cm);
                Control.click(se, UILogin.btnLogin, cm);
                se.WaitForPageToLoad("30000");
                //cm.numOfPassed += 1;
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                //Console.WriteLine("========ERROR===========");
                //Console.WriteLine("Error when '" + sf.GetMethod().Name + "'");
                //Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                //Console.WriteLine(e.ToString());
                //Console.WriteLine("========================");
                CommonFunc.writeLogReport(e.ToString(), "Error");
                se.Close();
                se.Stop();
            }
        }

        public static void Logout(ISelenium se, int timeoutSecond, CommonFunc cm)
        {
            CommonFunc.writeLogReport("Log out", "Info");
            try
            {
                Acc_UITopMenu Acc_UITopMenu = new Acc_UITopMenu();
                //se.SelectFrame(Acc_UITopMenu.frmTopMenu);
                Control.click(se, Acc_UITopMenu.linkLogOut, cm);
                se.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                //Console.WriteLine("========ERROR===========");
                //Console.WriteLine("Error when '" + sf.GetMethod().Name + "'");
                //Console.WriteLine("Line Number: {0}", sf.GetFileLineNumber());
                //Console.WriteLine(e.ToString());
                //Console.WriteLine("========================");
                CommonFunc.writeLogReport(e.ToString(), "Error");
                se.Close();
                se.Stop();
            }
        }

        public static void searchCustomer(ISelenium se, string strUserName, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                Acc_UITopMenu Acc_UITopMenu = new Acc_UITopMenu();
                Acc_UICommon Acc_UICommon = new Acc_UICommon();
                CommonFunc.writeLogReport("Search Customer", "Info");
                //se.SelectFrame(Acc_UICommon.frmContent);
                //se.SelectWindow("name=content");
                se.SelectFrame("relative=up");
                se.SelectFrame("relative=up");
                Control.addText(se, Acc_UITopMenu.txtSearchUserName, strUserName, cm);
                Control.click(se, Acc_UITopMenu.btnSearchUserName, timeoutSecond, cm);
            }
            catch (Exception)
            {
                CommonFunc.writeLogReport("Cannot search Customer", "Error");
                se.Close();
                se.Stop();
            }
        }

        public static void gotoLeftMenu(ISelenium se, string strUserName, string strTabControl, string strSubLinkOrControl, string strSub2LinkOrControl, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Go to Left Menu", "Info");
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
                searchCustomer(se, strUserName, timeoutSecond, cm);

                Control.click(se, strTabControl, timeoutSecond, cm);

                if (strSubLinkOrControl != "")
                {
                    Control.click(se, strSubLinkOrControl, timeoutSecond, cm);
                }
                if (strSub2LinkOrControl != "")
                {
                    Control.click(se, strSub2LinkOrControl, timeoutSecond, cm);
                }
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
            }
            catch (Exception)
            {
                CommonFunc.writeLogReport("Cannot go to Left Menu", "Error");
                se.Close();
                se.Stop();
            }
        }
        public static void gotoTopMenu(ISelenium se, string strTabControl, string strSubTabControl, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Go to Top Menu", "Info");
                Control.click(se, strTabControl, timeoutSecond, cm);
                Control.click(se, strSubTabControl, timeoutSecond, cm);
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
            }
            catch (Exception)
            {
                CommonFunc.writeLogReport("Cannot go to Top Menu", "Error");
                se.Close();
                se.Stop();
            }
        }
    }
}