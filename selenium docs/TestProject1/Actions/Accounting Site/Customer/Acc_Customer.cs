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
using System.Xml;

namespace SeleniumTests
{
    public class Acc_Customer
    {
        public static void addNewSuper(ISelenium se, string strUserName, string strPassword, string strSite, string strCurrency, bool flgClickAddButton, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Add new Super '" + strUserName + "'", "Info");
                Acc_UITopMenu Acc_UITopMenu = new Acc_UITopMenu();
                Acc_UICommon Acc_UICommon = new Acc_UICommon();
                Acc_UIAddNewSuper Acc_UIAddNewSuper = new Acc_UIAddNewSuper();
                Acc_Common.gotoTopMenu(se, Acc_UITopMenu.tabCustomer, Acc_UITopMenu.linkNewCustomer, timeoutSecond, cm);

                Control.select(se, Acc_UIAddNewSuper.cmbListTypeCustomerToAddNews, "Add New Super", timeoutSecond, cm);
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
                Control.waitForControlExist(se, Acc_UIAddNewSuper.txtUsername, timeoutSecond, cm);
                Control.addText(se, Acc_UIAddNewSuper.txtUsername, strUserName, cm);
                Control.addText(se, Acc_UIAddNewSuper.txtPassword, strPassword, cm);

                se.SelectFrame(Acc_UICommon.frmContent);
                se.SelectFrame(Acc_UICommon.frmCenter);
                se.SelectFrame(Acc_UICommon.frmMainCust);

                Control.select(se, Acc_UIAddNewSuper.cmbSite, strSite, timeoutSecond, cm);//"label=BEST-ODDS"
                Control.select(se, Acc_UIAddNewSuper.cmbCurrency, strCurrency, timeoutSecond, cm);//"label=UUS"
                if (flgClickAddButton == true)
                {
                    Control.click(se, Acc_UIAddNewSuper.btnAdd, timeoutSecond, cm);
                    CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
                }
            }
            catch (Exception)
            {
                CommonFunc.writeLogReport("Cannot add new Super '" + strUserName + "'", "Error");
                //se.Close();
                //se.Stop();
            }
        }

    }
}