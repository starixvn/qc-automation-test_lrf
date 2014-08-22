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
    public class Acc_PositionTaking
    {
        public static void edit3rdPartyPositionTakingForSuper(ISelenium se, string strUserName, string str3rdPartyName, string strLabelSuperMaxPT, string strLabelSuperMinPT, string strLabelSuperCommission, string strValueOfMaxTransferCredit, bool flgClickUpdateButton, int timeoutSecond, CommonFunc cm)
        {
            try
            {   
                CommonFunc fCommon = new CommonFunc();
                string DataFileName = "Acc_Customer_PT_Edit3rdParty_01_Controls.xml";
                string strPathDataFile = fCommon.strRootFolder.Replace("/", "\\") + "Data\\Accounting Site\\Customer\\";
                Acc_UILeftMenu Acc_UILeftMenu = new Acc_UILeftMenu();
                CommonFunc.writeLogReport("Edit " + str3rdPartyName + " PT", "Info");
                //Load interface of 3rdParty page (ex: controls on the Edit Casino, Bingo pages)
                XmlNodeList DataListControls = CommonFunc.readDataFromXmlFile(strPathDataFile + DataFileName, "//DataSet//filter","@level='super' and @thirdParty='" + str3rdPartyName + "'");
                foreach (XmlNode DataControl in DataListControls)
                {
                    Acc_Common.gotoLeftMenu(se, strUserName, Acc_UILeftMenu.tabDetail, Acc_UILeftMenu.btnEdit, DataControl["linkEditControl"].InnerText, timeoutSecond, cm);
                    Control.select(se, DataControl["cmbSuperMaxPT"].InnerText, strLabelSuperMaxPT, timeoutSecond, cm);
                    Control.select(se, DataControl["cmbSuperMinPT"].InnerText, strLabelSuperMinPT, timeoutSecond, cm);
                    Control.select(se, DataControl["cmbSuperComm"].InnerText, strLabelSuperCommission, timeoutSecond, cm);
                    Control.addText(se, DataControl["txtMaxTransferCredit"].InnerText, strValueOfMaxTransferCredit, cm);
                    
                    if (Control.doesControlExist(se, DataControl["chkSyncData"].InnerText,timeoutSecond, cm) == true)
                    {
                        Control.click(se, DataControl["chkSyncData"].InnerText, timeoutSecond, cm);
                    }

                    if (flgClickUpdateButton == true)
                    {
                        Control.click(se, DataControl["btnUpdate"].InnerText, timeoutSecond, cm);
                    }
                    CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
                }
            }
            catch (Exception)
            {
                CommonFunc.writeLogReport("Cannot edit " + str3rdPartyName + " PT", "Error");
                se.Close();
                se.Stop();
            }
        }

        public static void verifyViewPTSuper(ISelenium se, string strUserName, string strSportType, string strBetType, string tableContentControl, string valueOfSuper, string valueOfMaster, string valueOfAgent, string valueOfMinPT, string valueOfAutoPT, string valueOfCom, bool flgIsLive, bool flgClickSubmitButton, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Verify ViewPT Super '" + strUserName + "'", "Info");
                Acc_UITopMenu Acc_UITopMenu = new Acc_UITopMenu();
                Acc_UIViewPT Acc_UIViewPT = new Acc_UIViewPT();
                Acc_Common.gotoTopMenu(se, Acc_UITopMenu.tabCustomer, Acc_UITopMenu.linkViewPT, timeoutSecond, cm);
                CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
                Control.select(se, Acc_UIViewPT.cmbSportType, strSportType, timeoutSecond, cm);//label=Casino, label=Bingo
                //CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);
                Control.select(se, Acc_UIViewPT.cmbBetType, strBetType, timeoutSecond, cm);//label=.: ALL - Game Kind :.

                if (flgIsLive == true)
                {
                    Control.click(se, Acc_UIViewPT.chkIsLive, timeoutSecond, cm);
                }
                Control.addText(se, Acc_UIViewPT.txtUsername, strUserName, cm);

                if (flgClickSubmitButton == true)
                {
                    Control.click(se, Acc_UIViewPT.btnSubmit, timeoutSecond, cm);
                    CommonFunc.waitForPageToLoad(se, timeoutSecond, cm);

                    if (valueOfSuper != "")
                    {
                        CommonFunc.verifyTextInTable(se, tableContentControl, 1, 1, valueOfSuper, true, cm, timeoutSecond);
                    }
                    if (valueOfMaster != "")
                    {
                        CommonFunc.verifyTextInTable(se, tableContentControl, 1, 2, valueOfMaster, true, cm, timeoutSecond);
                    }
                    if (valueOfAgent != "")
                    {
                        CommonFunc.verifyTextInTable(se, tableContentControl, 1, 3, valueOfAgent, true, cm, timeoutSecond);
                    }
                    if (valueOfMinPT != "")
                    {
                        CommonFunc.verifyTextInTable(se, tableContentControl, 1, 4, valueOfMinPT, true, cm, timeoutSecond);
                    }
                    if (valueOfAutoPT != "")
                    {
                        CommonFunc.verifyTextInTable(se, tableContentControl, 1, 6, valueOfAutoPT, true, cm, timeoutSecond);
                    }
                    if (valueOfCom != "")
                    {
                        CommonFunc.verifyTextInTable(se, tableContentControl, 1, 7, valueOfCom, true, cm, timeoutSecond);
                    }
                }

            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                StackTrace st = new StackTrace(new StackFrame(true));
                StackFrame sf = st.GetFrame(0);
                CommonFunc.writeLogReport(e.ToString(), "Error");
                se.Close();
                se.Stop();
            }
        }
    }
}
