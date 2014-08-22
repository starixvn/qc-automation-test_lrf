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
    public class NEWLrf_Common
    {
        public static void Login(ISelenium se, string strUserName, string strPassword, string strCaptcha, int timeoutSecond, CommonFunc cm)
        {
            CommonFunc.writeLogReport("Log in", "Info");
            try
            {
                Lrf_UILogin UILogin = new Lrf_UILogin();
                Control.addText(se, UILogin.txtUserName, strUserName, timeoutSecond, cm);
                Control.addText(se, UILogin.txtPassword, strPassword, timeoutSecond , cm);
                Control.addText(se, UILogin.txtCaptcha, strCaptcha,timeoutSecond , cm);
                //Thread.Sleep(20000);
                Control.click(se, UILogin.btnLogin, cm);
                se.WaitForPageToLoad("60000");
                //cm.numOfPassed += 1;
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
             
            }
        }

        public static void Logout(ISelenium se, int timeoutSecond, CommonFunc cm)
        {
            CommonFunc.writeLogReport("Log out", "Info");
            try
            {
                Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
                Lrf_UIMain Lrf_UIMain = new Lrf_UIMain();
                Control.click(se, Lrf_UITopMenu.btnLogOut, cm);
                se.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport(e.ToString(), "Error");
              
            }
        }

        public static void searchCustomer(ISelenium se, string strUserName, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
                CommonFunc.writeLogReport("Search Customer", "Info");
                se.SelectFrame("relative=up");
                se.SelectFrame("relative=up");
            }
            catch (Exception)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Cannot search Customer", "Error");
                
            }
        }

        public static void gotoLeftMenu(ISelenium se, string strPatrentMenuControl, string strSubMenuControl, string strSectionMenu, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Go to Left Menu", "Info");
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);

                if (Convert.ToDecimal(Control.getControlHeight(se, strSectionMenu)) < 10)
                {
                    if (Control.doesControlExist(se, "menu",timeoutSecond,cm) == true)
                    {
                        se.SelectFrame("menu");
                    }
                    CommonFunc.writeLogReport("RunScript(\"menuToggle('" + strPatrentMenuControl.Substring("menu-".Length, strPatrentMenuControl.Length - "menu-".Length) + "');\")", "Debug");
                    se.RunScript("menuToggle('" + strPatrentMenuControl.Substring("menu-".Length, strPatrentMenuControl.Length - "menu-".Length) + "');");
                }
                if (strSubMenuControl != "")
                {
                    Control.click(se, strSubMenuControl, timeoutSecond, cm);
                }

            }
            catch (Exception)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Cannot go to Left Menu", "Error");
           
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
              
            }
        }
        public static void selectAnLicensee(ISelenium se, string btnLicensee, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Select an Licensee", "Info");
                Control.click(se, btnLicensee, timeoutSecond, cm);
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
            }
            catch (Exception)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Cannot select an Licensee", "Error");
              
            }
        }
        public static void selectLicenseeOnTopFrame(ISelenium se, string lbllLicensee, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                Lrf_UITopMenu Lrf_UITopMenu = new Lrf_UITopMenu();
                CommonFunc.writeLogReport("Select Licensee", "Info");
                Control.select(se, Lrf_UITopMenu.ddlLicensee, lbllLicensee, timeoutSecond, cm);
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
            }
            catch (Exception)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Cannot select Licensee", "Error");
             
            }
        }
    }
}