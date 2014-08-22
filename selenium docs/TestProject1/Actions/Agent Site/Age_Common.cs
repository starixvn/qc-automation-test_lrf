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
    public class Age_Common
    {
        public static void Login(ISelenium se, string strUserName, string strPassword, string strCaptcha, int timeoutSecond, CommonFunc cm)
        {
            CommonFunc.writeLogReport("Log in", "Info");
            try
            {
                Age_UILogin UILogin = new Age_UILogin();
                Control.addText(se, UILogin.txtUserName, strUserName, cm);
                Control.addText(se, UILogin.txtPassword, strPassword, cm);
                Control.addText(se, UILogin.txtCaptcha, strCaptcha, cm);
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
                Age_UITopMenu Age_UITopMenu = new Age_UITopMenu();
                se.SelectFrame(Age_UITopMenu.frmTopMenu);
                Control.click(se, Age_UITopMenu.tabLogOut, cm);
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

        public static void gotoLeftMenu(ISelenium se, string strTabControl, string strPatrentMenuControl, string strSubMenuControl, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Go to Left Menu", "Info");
                Control.click(se, strTabControl, timeoutSecond, cm);
                
                if (Control.getControlProperty(se, strPatrentMenuControl, "class",1000, cm) == "Bleft_Parent")
                {
                    Control.click(se, strPatrentMenuControl, timeoutSecond, cm);
                }
                Control.click(se, strSubMenuControl, timeoutSecond, cm);
                
            }
            catch(Exception)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Cannot go to Left Menu", "Error");
                se.Close();
                se.Stop();
            }
        }


        /*
        *Created by: William.Nguyen
        *Date      : 26-12-2012
        *Function  : select Transfer Condition
        *Params    : 
        *           + selenium
        *           + strOption: Daily/Weekly
        *           + strDates: If strOption=Weekly then strDates="Mon,Tue,Wed,Thurs,Fri,Sat,Sun" else strDates=""
        *           + Timeout
        *           + fcommom (this param is used to write log)
        */
        public static void selectTransferCondition(ISelenium se, string strOption, string strDates, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Select Transfer Condition", "Info");
                Age_UINewMaster Age_UINewMaster = new Age_UINewMaster();
                switch(strOption)
                {
                    case "Daily":
                        //Control.click(se, Age_UINewMaster.rdoDaily, timeoutSecond, cm);
                        Control.Check(se, Age_UINewMaster.rdoDaily, timeoutSecond, cm);
                        break;
                    case "Weekly":
                        Control.Check(se, Age_UINewMaster.rdoWeekly, timeoutSecond, cm);
                        //Console.WriteLine(strDates.IndexOf("Mon").ToString());
                        if (strDates.IndexOf("Mon") >= 0)
                        {
                            Control.Check(se, Age_UINewMaster.chkMon, timeoutSecond, cm);
                        }
                        if (strDates.IndexOf("Tue") >= 0)
                        {
                            Control.Check(se, Age_UINewMaster.chkTue, timeoutSecond, cm);
                        }
                        if (strDates.IndexOf("Wed") >= 0)
                        {
                            Control.Check(se, Age_UINewMaster.chkWed, timeoutSecond, cm);
                        }
                        if (strDates.IndexOf("Thurs") >= 0)
                        {
                            Control.Check(se, Age_UINewMaster.chkThurs, timeoutSecond, cm);
                        }
                        if (strDates.IndexOf("Fri") >= 0)
                        {
                            Control.Check(se, Age_UINewMaster.chkFri, timeoutSecond, cm);
                        }
                        if (strDates.IndexOf("Sat") >= 0)
                        {
                            Control.Check(se, Age_UINewMaster.chkSat, timeoutSecond, cm);
                        }
                        if (strDates.IndexOf("Sun") >= 0)
                        {
                            Control.Check(se, Age_UINewMaster.chkSun, timeoutSecond, cm);
                        }
                        break;
                }
            }
            catch (Exception)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Error: select transfer condition", "Error");
                se.Close();
                se.Stop();
            }
        }


        /*
        *Created by: William.Nguyen
        *Date      : 27-12-2012
        *Function  : get position taking from Data (XML) file and convert to string (EX: s4$1$2$0=0.9;m4$1$2$0=0.8...)
          *s4$1$2$0:
               + s4: Super Max Position Taking
               + 1 : Sport Type
               + 2 : Bettype
               + 0 : Dead Ball (1: Live Ball)
        *Params    : 
        *           + strPathAndFileName (EX: "D:\Server TFS 2012\QC\Selenium\TestProject1\Data\Agent Site\Member Information\New Master\NewMaster.xml")
        *           + strSelectedNode: Node in xml file (EX: "//DataSet//filter")
        *           + strFilterCondition: get PT of Super / Master / Agent (EX: "@level='super' and @thirdParty='Horse Racing'") 
        */
        public static string getPositionTakingFromDataFile(string strPathAndFileName, string strSelectedNode, string strFilterCondition)
        {
            try
            {
                CommonFunc.writeLogReport("Get Position Taking from data file '" + strPathAndFileName + "'", "Info");
                string strPositionTaking = "";
                XmlNodeList DataList = CommonFunc.readDataFromXmlFile(strPathAndFileName, strSelectedNode, strFilterCondition);
                foreach (XmlNode Data in DataList)
                {
                    /* Super Level*/
                    if (strFilterCondition.IndexOf("@level='super'") >= 0)
                    {
                        /*Get All PT of Soccer*/
                        if (Data["PT_Soccer_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$1$1$0=" + Data["PT_Soccer_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$1$1$0=" + Data["PT_Soccer_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$1$1$0=" + Data["PT_Soccer_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$1$3$0=" + Data["PT_Soccer_Dead_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$1$3$0=" + Data["PT_Soccer_Dead_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$1$3$0=" + Data["PT_Soccer_Dead_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_1stHDP"] != null) { strPositionTaking = strPositionTaking + "s4$1$7$0=" + Data["PT_Soccer_Dead_SuperMax_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m4$1$7$0=" + Data["PT_Soccer_Dead_MasterMax_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_1stHDP"] != null) { strPositionTaking = strPositionTaking + "a4$1$7$0=" + Data["PT_Soccer_Dead_AgentMax_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$1$8$0=" + Data["PT_Soccer_Dead_SuperMax_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$1$8$0=" + Data["PT_Soccer_Dead_MasterMax_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$1$8$0=" + Data["PT_Soccer_Dead_AgentMax_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$1$2$0=" + Data["PT_Soccer_Dead_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$1$2$0=" + Data["PT_Soccer_Dead_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$1$2$0=" + Data["PT_Soccer_Dead_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_1x2"] != null) { strPositionTaking = strPositionTaking + "s4$1$5$0=" + Data["PT_Soccer_Dead_SuperMax_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_1x2"] != null) { strPositionTaking = strPositionTaking + "m4$1$5$0=" + Data["PT_Soccer_Dead_MasterMax_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_1x2"] != null) { strPositionTaking = strPositionTaking + "a4$1$5$0=" + Data["PT_Soccer_Dead_AgentMax_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "s4$1$4$0=" + Data["PT_Soccer_Dead_SuperMax_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "m4$1$4$0=" + Data["PT_Soccer_Dead_MasterMax_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "a4$1$4$0=" + Data["PT_Soccer_Dead_AgentMax_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "s4$1$6$0=" + Data["PT_Soccer_Dead_SuperMax_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "m4$1$6$0=" + Data["PT_Soccer_Dead_MasterMax_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "a4$1$6$0=" + Data["PT_Soccer_Dead_AgentMax_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_MixParlay"] != null) { strPositionTaking = strPositionTaking + "s4$1$9$0=" + Data["PT_Soccer_Dead_SuperMax_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m4$1$9$0=" + Data["PT_Soccer_Dead_MasterMax_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_MixParlay"] != null) { strPositionTaking = strPositionTaking + "a4$1$9$0=" + Data["PT_Soccer_Dead_AgentMax_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperMax_Outright"] != null) { strPositionTaking = strPositionTaking + "s4$1$10$0=" + Data["PT_Soccer_Dead_SuperMax_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterMax_Outright"] != null) { strPositionTaking = strPositionTaking + "m4$1$10$0=" + Data["PT_Soccer_Dead_MasterMax_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentMax_Outright"] != null) { strPositionTaking = strPositionTaking + "a4$1$10$0=" + Data["PT_Soccer_Dead_AgentMax_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$1$1$1=" + Data["PT_Soccer_Live_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$1$1$1=" + Data["PT_Soccer_Live_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$1$1$1=" + Data["PT_Soccer_Live_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$1$3$1=" + Data["PT_Soccer_Live_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$1$3$1=" + Data["PT_Soccer_Live_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$1$3$1=" + Data["PT_Soccer_Live_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperMax_1stHDP"] != null) { strPositionTaking = strPositionTaking + "s4$1$7$1=" + Data["PT_Soccer_Live_SuperMax_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterMax_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m4$1$7$1=" + Data["PT_Soccer_Live_MasterMax_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentMax_1stHDP"] != null) { strPositionTaking = strPositionTaking + "a4$1$7$1=" + Data["PT_Soccer_Live_AgentMax_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperMax_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$1$8$1=" + Data["PT_Soccer_Live_SuperMax_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterMax_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$1$8$1=" + Data["PT_Soccer_Live_MasterMax_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentMax_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$1$8$1=" + Data["PT_Soccer_Live_AgentMax_1stOverUnder"].InnerText + ";"; }

                        /*Get All PT of BasketBall*/
                        if (Data["PT_BasketBall_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$2$1$0=" + Data["PT_BasketBall_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$2$1$0=" + Data["PT_BasketBall_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$2$1$0=" + Data["PT_BasketBall_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$2$3$0=" + Data["PT_BasketBall_Dead_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$2$3$0=" + Data["PT_BasketBall_Dead_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$2$3$0=" + Data["PT_BasketBall_Dead_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$2$2$0=" + Data["PT_BasketBall_Dead_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$2$2$0=" + Data["PT_BasketBall_Dead_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$2$2$0=" + Data["PT_BasketBall_Dead_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s4$2$20$0=" + Data["PT_BasketBall_Dead_SuperMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m4$2$20$0=" + Data["PT_BasketBall_Dead_MasterMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AgentMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a4$2$20$0=" + Data["PT_BasketBall_Dead_AgentMax_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of FootBall*/
                        if (Data["PT_FootBall_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$3$1$0=" + Data["PT_FootBall_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$3$1$0=" + Data["PT_FootBall_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$3$1$0=" + Data["PT_FootBall_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$3$3$0=" + Data["PT_FootBall_Dead_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$3$3$0=" + Data["PT_FootBall_Dead_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$3$3$0=" + Data["PT_FootBall_Dead_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$3$2$0=" + Data["PT_FootBall_Dead_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$3$2$0=" + Data["PT_FootBall_Dead_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$3$2$0=" + Data["PT_FootBall_Dead_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s4$3$20$0=" + Data["PT_FootBall_Dead_SuperMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m4$3$20$0=" + Data["PT_FootBall_Dead_MasterMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AgentMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a4$3$20$0=" + Data["PT_FootBall_Dead_AgentMax_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Tenis*/
                        if (Data["PT_Tenis_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$5$1$0=" + Data["PT_Tenis_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$5$1$0=" + Data["PT_Tenis_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$5$1$0=" + Data["PT_Tenis_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$5$3$0=" + Data["PT_Tenis_Dead_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$5$3$0=" + Data["PT_Tenis_Dead_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$5$3$0=" + Data["PT_Tenis_Dead_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$5$2$0=" + Data["PT_Tenis_Dead_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$5$2$0=" + Data["PT_Tenis_Dead_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$5$2$0=" + Data["PT_Tenis_Dead_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s4$5$20$0=" + Data["PT_Tenis_Dead_SuperMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m4$5$20$0=" + Data["PT_Tenis_Dead_MasterMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AgentMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a4$5$20$0=" + Data["PT_Tenis_Dead_AgentMax_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of BaseBall*/
                        if (Data["PT_BaseBall_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$8$1$0=" + Data["PT_BaseBall_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$8$1$0=" + Data["PT_BaseBall_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$8$1$0=" + Data["PT_BaseBall_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$8$3$0=" + Data["PT_BaseBall_Dead_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$8$3$0=" + Data["PT_BaseBall_Dead_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$8$3$0=" + Data["PT_BaseBall_Dead_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s4$8$20$0=" + Data["PT_BaseBall_Dead_SuperMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m4$8$20$0=" + Data["PT_BaseBall_Dead_MasterMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AgentMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a4$8$20$0=" + Data["PT_BaseBall_Dead_AgentMax_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Golf*/
                        if (Data["PT_Golf_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$10$1$0=" + Data["PT_Golf_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$10$1$0=" + Data["PT_Golf_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$10$1$0=" + Data["PT_Golf_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$10$3$0=" + Data["PT_Golf_Dead_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$10$3$0=" + Data["PT_Golf_Dead_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$10$3$0=" + Data["PT_Golf_Dead_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$10$2$0=" + Data["PT_Golf_Dead_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$10$2$0=" + Data["PT_Golf_Dead_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$10$2$0=" + Data["PT_Golf_Dead_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s4$10$20$0=" + Data["PT_Golf_Dead_SuperMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m4$10$20$0=" + Data["PT_Golf_Dead_MasterMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AgentMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a4$10$20$0=" + Data["PT_Golf_Dead_AgentMax_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Motor Sports*/
                        if (Data["PT_MotorSports_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$11$1$0=" + Data["PT_MotorSports_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$11$1$0=" + Data["PT_MotorSports_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$11$1$0=" + Data["PT_MotorSports_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_SuperMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s4$11$20$0=" + Data["PT_MotorSports_Dead_SuperMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_MasterMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m4$11$20$0=" + Data["PT_MotorSports_Dead_MasterMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AgentMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a4$11$20$0=" + Data["PT_MotorSports_Dead_AgentMax_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Other Sports*/
                        if (Data["PT_OtherSports_Dead_SuperMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "s4$99$1$0=" + Data["PT_OtherSports_Dead_SuperMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "m4$99$1$0=" + Data["PT_OtherSports_Dead_MasterMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AgentMax_Handicap"] != null) { strPositionTaking = strPositionTaking + "a4$99$1$0=" + Data["PT_OtherSports_Dead_AgentMax_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$99$3$0=" + Data["PT_OtherSports_Dead_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$99$3$0=" + Data["PT_OtherSports_Dead_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$99$3$0=" + Data["PT_OtherSports_Dead_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$99$2$0=" + Data["PT_OtherSports_Dead_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$99$2$0=" + Data["PT_OtherSports_Dead_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$99$2$0=" + Data["PT_OtherSports_Dead_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s4$99$20$0=" + Data["PT_OtherSports_Dead_SuperMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m4$99$20$0=" + Data["PT_OtherSports_Dead_MasterMax_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AgentMax_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a4$99$20$0=" + Data["PT_OtherSports_Dead_AgentMax_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Mix Sports Parlay*/
                        if (Data["PT_MixSportsParlay_Dead_SuperMax_MixParlay"] != null) { strPositionTaking = strPositionTaking + "s4$99$9$0=" + Data["PT_MixSportsParlay_Dead_SuperMax_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_MasterMax_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m4$99$9$0=" + Data["PT_MixSportsParlay_Dead_MasterMax_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_AgentMax_MixParlay"] != null) { strPositionTaking = strPositionTaking + "a4$99$9$0=" + Data["PT_MixSportsParlay_Dead_AgentMax_MixParlay"].InnerText + ";"; }

                        /*Get All PT of Number Game*/
                        if (Data["PT_NumberGame_Dead_SuperMax_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$161$81$0=" + Data["PT_NumberGame_Dead_SuperMax_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterMax_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$161$81$0=" + Data["PT_NumberGame_Dead_MasterMax_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AgentMax_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$161$81$0=" + Data["PT_NumberGame_Dead_AgentMax_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperMax_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "s4$161$83$0=" + Data["PT_NumberGame_Dead_SuperMax_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterMax_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "m4$161$83$0=" + Data["PT_NumberGame_Dead_MasterMax_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AgentMax_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "a4$161$83$0=" + Data["PT_NumberGame_Dead_AgentMax_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperMax_Warrior"] != null) { strPositionTaking = strPositionTaking + "s4$161$88$0=" + Data["PT_NumberGame_Dead_SuperMax_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterMax_Warrior"] != null) { strPositionTaking = strPositionTaking + "m4$161$88$0=" + Data["PT_NumberGame_Dead_MasterMax_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AgentMax_Warrior"] != null) { strPositionTaking = strPositionTaking + "a4$161$88$0=" + Data["PT_NumberGame_Dead_AgentMax_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$161$86$0=" + Data["PT_NumberGame_Dead_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$161$86$0=" + Data["PT_NumberGame_Dead_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$161$86$0=" + Data["PT_NumberGame_Dead_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s4$161$85$1=" + Data["PT_NumberGame_Live_SuperMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m4$161$85$1=" + Data["PT_NumberGame_Live_MasterMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentMax_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a4$161$85$1=" + Data["PT_NumberGame_Live_AgentMax_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "s4$161$86$1=" + Data["PT_NumberGame_Live_SuperMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "m4$161$86$1=" + Data["PT_NumberGame_Live_MasterMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentMax_OddEven"] != null) { strPositionTaking = strPositionTaking + "a4$161$86$1=" + Data["PT_NumberGame_Live_AgentMax_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperMax_HighLow"] != null) { strPositionTaking = strPositionTaking + "s4$161$87$1=" + Data["PT_NumberGame_Live_SuperMax_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterMax_HighLow"] != null) { strPositionTaking = strPositionTaking + "m4$161$87$1=" + Data["PT_NumberGame_Live_MasterMax_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentMax_HighLow"] != null) { strPositionTaking = strPositionTaking + "a4$161$87$1=" + Data["PT_NumberGame_Live_AgentMax_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperMax_NextCombo"] != null) { strPositionTaking = strPositionTaking + "s4$161$89$1=" + Data["PT_NumberGame_Live_SuperMax_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterMax_NextCombo"] != null) { strPositionTaking = strPositionTaking + "m4$161$89$1=" + Data["PT_NumberGame_Live_MasterMax_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentMax_NextCombo"] != null) { strPositionTaking = strPositionTaking + "a4$161$89$1=" + Data["PT_NumberGame_Live_AgentMax_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperMax_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "s4$161$90$1=" + Data["PT_NumberGame_Live_SuperMax_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterMax_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "m4$161$90$1=" + Data["PT_NumberGame_Live_MasterMax_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentMax_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "a4$161$90$1=" + Data["PT_NumberGame_Live_AgentMax_NumberWheel"].InnerText + ";"; }
                    }
                    /* Master Level*/
                    if (strFilterCondition.IndexOf("@level='master'") >= 0)
                    {
                        /*Get All PT of Soccer*/
                        if (Data["PT_Soccer_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$1$1$0=" + Data["PT_Soccer_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$1$1$0=" + Data["PT_Soccer_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$1$1$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$1$1$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$1$3$0=" + Data["PT_Soccer_Dead_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$1$3$0=" + Data["PT_Soccer_Dead_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$1$3$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$1$3$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m3$1$7$0=" + Data["PT_Soccer_Dead_Master_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "s3$1$7$0=" + Data["PT_Soccer_Dead_SuperPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "us3$1$7$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "is3$1$7$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$1$8$0=" + Data["PT_Soccer_Dead_Master_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$1$8$0=" + Data["PT_Soccer_Dead_SuperPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$1$8$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$1$8$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$1$2$0=" + Data["PT_Soccer_Dead_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$1$2$0=" + Data["PT_Soccer_Dead_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$1$2$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$1$2$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_1x2"] != null) { strPositionTaking = strPositionTaking + "m3$1$5$0=" + Data["PT_Soccer_Dead_Master_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_1x2"] != null) { strPositionTaking = strPositionTaking + "s3$1$5$0=" + Data["PT_Soccer_Dead_SuperPreset_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_1x2"] != null) { strPositionTaking = strPositionTaking + "us3$1$5$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_1x2"] != null) { strPositionTaking = strPositionTaking + "is3$1$5$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "m3$1$4$0=" + Data["PT_Soccer_Dead_Master_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "s3$1$4$0=" + Data["PT_Soccer_Dead_SuperPreset_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "us3$1$4$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "is3$1$4$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "m3$1$6$0=" + Data["PT_Soccer_Dead_Master_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "s3$1$6$0=" + Data["PT_Soccer_Dead_SuperPreset_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "us3$1$6$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "is3$1$6$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m3$1$9$0=" + Data["PT_Soccer_Dead_Master_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "s3$1$9$0=" + Data["PT_Soccer_Dead_SuperPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "us3$1$9$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "is3$1$9$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Master_Outright"] != null) { strPositionTaking = strPositionTaking + "m3$1$10$0=" + Data["PT_Soccer_Dead_Master_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperPreset_Outright"] != null) { strPositionTaking = strPositionTaking + "s3$1$10$0=" + Data["PT_Soccer_Dead_SuperPreset_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperPreset_Outright"] != null) { strPositionTaking = strPositionTaking + "us3$1$10$0=" + Data["PT_Soccer_Dead_AutoSuperPreset_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperPreset_Outright"] != null) { strPositionTaking = strPositionTaking + "is3$1$10$0=" + Data["PT_Soccer_Dead_IsAutoSuperPreset_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$1$1$1=" + Data["PT_Soccer_Live_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$1$1$1=" + Data["PT_Soccer_Live_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$1$1$1=" + Data["PT_Soccer_Live_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$1$1$1=" + Data["PT_Soccer_Live_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$1$3$1=" + Data["PT_Soccer_Live_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$1$3$1=" + Data["PT_Soccer_Live_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$1$3$1=" + Data["PT_Soccer_Live_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$1$3$1=" + Data["PT_Soccer_Live_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Master_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m3$1$7$1=" + Data["PT_Soccer_Live_Master_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "s3$1$7$1=" + Data["PT_Soccer_Live_SuperPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "us3$1$7$1=" + Data["PT_Soccer_Live_AutoSuperPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "is3$1$7$1=" + Data["PT_Soccer_Live_IsAutoSuperPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Master_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$1$8$1=" + Data["PT_Soccer_Live_Master_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$1$8$1=" + Data["PT_Soccer_Live_SuperPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$1$8$1=" + Data["PT_Soccer_Live_AutoSuperPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$1$8$1=" + Data["PT_Soccer_Live_IsAutoSuperPreset_1stOverUnder"].InnerText + ";"; }

                        /*Get All PT of BasketBall*/
                        if (Data["PT_BasketBall_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$2$1$0=" + Data["PT_BasketBall_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$2$1$0=" + Data["PT_BasketBall_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$2$1$0=" + Data["PT_BasketBall_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$2$1$0=" + Data["PT_BasketBall_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$2$3$0=" + Data["PT_BasketBall_Dead_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$2$3$0=" + Data["PT_BasketBall_Dead_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$2$3$0=" + Data["PT_BasketBall_Dead_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$2$3$0=" + Data["PT_BasketBall_Dead_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$2$2$0=" + Data["PT_BasketBall_Dead_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$2$2$0=" + Data["PT_BasketBall_Dead_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$2$2$0=" + Data["PT_BasketBall_Dead_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$2$2$0=" + Data["PT_BasketBall_Dead_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_Master_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m3$2$20$0=" + Data["PT_BasketBall_Dead_Master_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s3$2$20$0=" + Data["PT_BasketBall_Dead_SuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us3$2$20$0=" + Data["PT_BasketBall_Dead_AutoSuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is3$2$20$0=" + Data["PT_BasketBall_Dead_IsAutoSuperPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of FootBall*/
                        if (Data["PT_FootBall_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$3$1$0=" + Data["PT_FootBall_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$3$1$0=" + Data["PT_FootBall_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$3$1$0=" + Data["PT_FootBall_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$3$1$0=" + Data["PT_FootBall_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$3$3$0=" + Data["PT_FootBall_Dead_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$3$3$0=" + Data["PT_FootBall_Dead_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$3$3$0=" + Data["PT_FootBall_Dead_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$3$3$0=" + Data["PT_FootBall_Dead_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$3$2$0=" + Data["PT_FootBall_Dead_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$3$2$0=" + Data["PT_FootBall_Dead_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$3$2$0=" + Data["PT_FootBall_Dead_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$3$2$0=" + Data["PT_FootBall_Dead_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_Master_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m3$3$20$0=" + Data["PT_FootBall_Dead_Master_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s3$3$20$0=" + Data["PT_FootBall_Dead_SuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us3$3$20$0=" + Data["PT_FootBall_Dead_AutoSuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is3$3$20$0=" + Data["PT_FootBall_Dead_IsAutoSuperPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Tenis*/
                        if (Data["PT_Tenis_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$5$1$0=" + Data["PT_Tenis_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$5$1$0=" + Data["PT_Tenis_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$5$1$0=" + Data["PT_Tenis_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$5$1$0=" + Data["PT_Tenis_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$5$3$0=" + Data["PT_Tenis_Dead_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$5$3$0=" + Data["PT_Tenis_Dead_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$5$3$0=" + Data["PT_Tenis_Dead_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$5$3$0=" + Data["PT_Tenis_Dead_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$5$2$0=" + Data["PT_Tenis_Dead_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$5$2$0=" + Data["PT_Tenis_Dead_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$5$2$0=" + Data["PT_Tenis_Dead_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$5$2$0=" + Data["PT_Tenis_Dead_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_Master_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m3$5$20$0=" + Data["PT_Tenis_Dead_Master_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s3$5$20$0=" + Data["PT_Tenis_Dead_SuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us3$5$20$0=" + Data["PT_Tenis_Dead_AutoSuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is3$5$20$0=" + Data["PT_Tenis_Dead_IsAutoSuperPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of BaseBall*/
                        if (Data["PT_BaseBall_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$8$1$0=" + Data["PT_BaseBall_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$8$1$0=" + Data["PT_BaseBall_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$8$1$0=" + Data["PT_BaseBall_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$8$1$0=" + Data["PT_BaseBall_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$8$3$0=" + Data["PT_BaseBall_Dead_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$8$3$0=" + Data["PT_BaseBall_Dead_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$8$3$0=" + Data["PT_BaseBall_Dead_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$8$3$0=" + Data["PT_BaseBall_Dead_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_Master_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m3$8$20$0=" + Data["PT_BaseBall_Dead_Master_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s3$8$20$0=" + Data["PT_BaseBall_Dead_SuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us3$8$20$0=" + Data["PT_BaseBall_Dead_AutoSuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is3$8$20$0=" + Data["PT_BaseBall_Dead_IsAutoSuperPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Golf*/
                        if (Data["PT_Golf_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$10$1$0=" + Data["PT_Golf_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$10$1$0=" + Data["PT_Golf_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$10$1$0=" + Data["PT_Golf_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$10$1$0=" + Data["PT_Golf_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$10$3$0=" + Data["PT_Golf_Dead_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$10$3$0=" + Data["PT_Golf_Dead_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$10$3$0=" + Data["PT_Golf_Dead_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$10$3$0=" + Data["PT_Golf_Dead_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$10$2$0=" + Data["PT_Golf_Dead_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$10$2$0=" + Data["PT_Golf_Dead_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$10$2$0=" + Data["PT_Golf_Dead_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$10$2$0=" + Data["PT_Golf_Dead_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_Master_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m3$10$20$0=" + Data["PT_Golf_Dead_Master_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s3$10$20$0=" + Data["PT_Golf_Dead_SuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us3$10$20$0=" + Data["PT_Golf_Dead_AutoSuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is3$10$20$0=" + Data["PT_Golf_Dead_IsAutoSuperPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of MotorSports*/
                        if (Data["PT_MotorSports_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$11$1$0=" + Data["PT_MotorSports_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$11$1$0=" + Data["PT_MotorSports_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$11$1$0=" + Data["PT_MotorSports_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$11$1$0=" + Data["PT_MotorSports_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_Master_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m3$11$20$0=" + Data["PT_MotorSports_Dead_Master_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_SuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s3$11$20$0=" + Data["PT_MotorSports_Dead_SuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us3$11$20$0=" + Data["PT_MotorSports_Dead_AutoSuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is3$11$20$0=" + Data["PT_MotorSports_Dead_IsAutoSuperPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of OtherSports*/
                        if (Data["PT_OtherSports_Dead_Master_Handicap"] != null) { strPositionTaking = strPositionTaking + "m3$99$1$0=" + Data["PT_OtherSports_Dead_Master_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "s3$99$1$0=" + Data["PT_OtherSports_Dead_SuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "us3$99$1$0=" + Data["PT_OtherSports_Dead_AutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "is3$99$1$0=" + Data["PT_OtherSports_Dead_IsAutoSuperPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$99$3$0=" + Data["PT_OtherSports_Dead_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$99$3$0=" + Data["PT_OtherSports_Dead_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$99$3$0=" + Data["PT_OtherSports_Dead_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$99$3$0=" + Data["PT_OtherSports_Dead_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$99$2$0=" + Data["PT_OtherSports_Dead_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$99$2$0=" + Data["PT_OtherSports_Dead_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$99$2$0=" + Data["PT_OtherSports_Dead_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$99$2$0=" + Data["PT_OtherSports_Dead_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_Master_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m3$99$20$0=" + Data["PT_OtherSports_Dead_Master_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s3$99$20$0=" + Data["PT_OtherSports_Dead_SuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us3$99$20$0=" + Data["PT_OtherSports_Dead_AutoSuperPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is3$99$20$0=" + Data["PT_OtherSports_Dead_IsAutoSuperPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of MixSportsParlay*/
                        if (Data["PT_MixSportsParlay_Dead_Master_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m3$99$9$0=" + Data["PT_MixSportsParlay_Dead_Master_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_SuperPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "s3$99$9$0=" + Data["PT_MixSportsParlay_Dead_SuperPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_AutoSuperPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "us3$99$9$0=" + Data["PT_MixSportsParlay_Dead_AutoSuperPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_IsAutoSuperPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "is3$99$9$0=" + Data["PT_MixSportsParlay_Dead_IsAutoSuperPreset_MixParlay"].InnerText + ";"; }

                        /*Get All PT of NumberGame*/
                        if (Data["PT_NumberGame_Dead_Master_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$161$81$0=" + Data["PT_NumberGame_Dead_Master_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperPreset_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$161$81$0=" + Data["PT_NumberGame_Dead_SuperPreset_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperPreset_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$161$81$0=" + Data["PT_NumberGame_Dead_AutoSuperPreset_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperPreset_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$161$81$0=" + Data["PT_NumberGame_Dead_IsAutoSuperPreset_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_Master_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "m3$161$83$0=" + Data["PT_NumberGame_Dead_Master_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperPreset_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "s3$161$83$0=" + Data["PT_NumberGame_Dead_SuperPreset_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperPreset_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "us3$161$83$0=" + Data["PT_NumberGame_Dead_AutoSuperPreset_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperPreset_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "is3$161$83$0=" + Data["PT_NumberGame_Dead_IsAutoSuperPreset_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_Master_Warrior"] != null) { strPositionTaking = strPositionTaking + "m3$161$88$0=" + Data["PT_NumberGame_Dead_Master_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperPreset_Warrior"] != null) { strPositionTaking = strPositionTaking + "s3$161$88$0=" + Data["PT_NumberGame_Dead_SuperPreset_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperPreset_Warrior"] != null) { strPositionTaking = strPositionTaking + "us3$161$88$0=" + Data["PT_NumberGame_Dead_AutoSuperPreset_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperPreset_Warrior"] != null) { strPositionTaking = strPositionTaking + "is3$161$88$0=" + Data["PT_NumberGame_Dead_IsAutoSuperPreset_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$161$86$0=" + Data["PT_NumberGame_Dead_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$161$86$0=" + Data["PT_NumberGame_Dead_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$161$86$0=" + Data["PT_NumberGame_Dead_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$161$86$0=" + Data["PT_NumberGame_Dead_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Master_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m3$161$85$1=" + Data["PT_NumberGame_Live_Master_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s3$161$85$1=" + Data["PT_NumberGame_Live_SuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us3$161$85$1=" + Data["PT_NumberGame_Live_AutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is3$161$85$1=" + Data["PT_NumberGame_Live_IsAutoSuperPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Master_OddEven"] != null) { strPositionTaking = strPositionTaking + "m3$161$86$1=" + Data["PT_NumberGame_Live_Master_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "s3$161$86$1=" + Data["PT_NumberGame_Live_SuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "us3$161$86$1=" + Data["PT_NumberGame_Live_AutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "is3$161$86$1=" + Data["PT_NumberGame_Live_IsAutoSuperPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Master_HighLow"] != null) { strPositionTaking = strPositionTaking + "m3$161$87$1=" + Data["PT_NumberGame_Live_Master_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperPreset_HighLow"] != null) { strPositionTaking = strPositionTaking + "s3$161$87$1=" + Data["PT_NumberGame_Live_SuperPreset_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperPreset_HighLow"] != null) { strPositionTaking = strPositionTaking + "us3$161$87$1=" + Data["PT_NumberGame_Live_AutoSuperPreset_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperPreset_HighLow"] != null) { strPositionTaking = strPositionTaking + "is3$161$87$1=" + Data["PT_NumberGame_Live_IsAutoSuperPreset_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Master_NextCombo"] != null) { strPositionTaking = strPositionTaking + "m3$161$89$1=" + Data["PT_NumberGame_Live_Master_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperPreset_NextCombo"] != null) { strPositionTaking = strPositionTaking + "s3$161$89$1=" + Data["PT_NumberGame_Live_SuperPreset_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperPreset_NextCombo"] != null) { strPositionTaking = strPositionTaking + "us3$161$89$1=" + Data["PT_NumberGame_Live_AutoSuperPreset_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperPreset_NextCombo"] != null) { strPositionTaking = strPositionTaking + "is3$161$89$1=" + Data["PT_NumberGame_Live_IsAutoSuperPreset_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Master_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "m3$161$90$1=" + Data["PT_NumberGame_Live_Master_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperPreset_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "s3$161$90$1=" + Data["PT_NumberGame_Live_SuperPreset_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperPreset_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "us3$161$90$1=" + Data["PT_NumberGame_Live_AutoSuperPreset_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperPreset_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "is3$161$90$1=" + Data["PT_NumberGame_Live_IsAutoSuperPreset_NumberWheel"].InnerText + ";"; }
                    }
                    /* Agent Level*/
                    if (strFilterCondition.IndexOf("@level='agent'") >= 0)
                    {
                        /*Get All PT of Soccer*/
                        if (Data["PT_Soccer_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$1$1$0=" + Data["PT_Soccer_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$1$1$0=" + Data["PT_Soccer_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$1$1$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$1$1$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$1$3$0=" + Data["PT_Soccer_Dead_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$1$3$0=" + Data["PT_Soccer_Dead_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$1$3$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$1$3$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_1stHDP"] != null) { strPositionTaking = strPositionTaking + "a2$1$7$0=" + Data["PT_Soccer_Dead_Agent_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m2$1$7$0=" + Data["PT_Soccer_Dead_MasterPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "um2$1$7$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "im2$1$7$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$1$8$0=" + Data["PT_Soccer_Dead_Agent_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$1$8$0=" + Data["PT_Soccer_Dead_MasterPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$1$8$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$1$8$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$1$2$0=" + Data["PT_Soccer_Dead_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$1$2$0=" + Data["PT_Soccer_Dead_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$1$2$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$1$2$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_1x2"] != null) { strPositionTaking = strPositionTaking + "a2$1$5$0=" + Data["PT_Soccer_Dead_Agent_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_1x2"] != null) { strPositionTaking = strPositionTaking + "m2$1$5$0=" + Data["PT_Soccer_Dead_MasterPreset_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_1x2"] != null) { strPositionTaking = strPositionTaking + "um2$1$5$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_1x2"] != null) { strPositionTaking = strPositionTaking + "im2$1$5$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "a2$1$4$0=" + Data["PT_Soccer_Dead_Agent_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "m2$1$4$0=" + Data["PT_Soccer_Dead_MasterPreset_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "um2$1$4$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "im2$1$4$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "a2$1$6$0=" + Data["PT_Soccer_Dead_Agent_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "m2$1$6$0=" + Data["PT_Soccer_Dead_MasterPreset_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "um2$1$6$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "im2$1$6$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_MixParlay"] != null) { strPositionTaking = strPositionTaking + "a2$1$9$0=" + Data["PT_Soccer_Dead_Agent_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m2$1$9$0=" + Data["PT_Soccer_Dead_MasterPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "um2$1$9$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "im2$1$9$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_Agent_Outright"] != null) { strPositionTaking = strPositionTaking + "a2$1$10$0=" + Data["PT_Soccer_Dead_Agent_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterPreset_Outright"] != null) { strPositionTaking = strPositionTaking + "m2$1$10$0=" + Data["PT_Soccer_Dead_MasterPreset_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterPreset_Outright"] != null) { strPositionTaking = strPositionTaking + "um2$1$10$0=" + Data["PT_Soccer_Dead_AutoMasterPreset_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterPreset_Outright"] != null) { strPositionTaking = strPositionTaking + "im2$1$10$0=" + Data["PT_Soccer_Dead_IsAutoMasterPreset_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$1$1$1=" + Data["PT_Soccer_Live_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$1$1$1=" + Data["PT_Soccer_Live_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$1$1$1=" + Data["PT_Soccer_Live_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$1$1$1=" + Data["PT_Soccer_Live_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$1$3$1=" + Data["PT_Soccer_Live_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$1$3$1=" + Data["PT_Soccer_Live_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$1$3$1=" + Data["PT_Soccer_Live_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$1$3$1=" + Data["PT_Soccer_Live_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Agent_1stHDP"] != null) { strPositionTaking = strPositionTaking + "a2$1$7$1=" + Data["PT_Soccer_Live_Agent_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m2$1$7$1=" + Data["PT_Soccer_Live_MasterPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "um2$1$7$1=" + Data["PT_Soccer_Live_AutoMasterPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterPreset_1stHDP"] != null) { strPositionTaking = strPositionTaking + "im2$1$7$1=" + Data["PT_Soccer_Live_IsAutoMasterPreset_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_Agent_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$1$8$1=" + Data["PT_Soccer_Live_Agent_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$1$8$1=" + Data["PT_Soccer_Live_MasterPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$1$8$1=" + Data["PT_Soccer_Live_AutoMasterPreset_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterPreset_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$1$8$1=" + Data["PT_Soccer_Live_IsAutoMasterPreset_1stOverUnder"].InnerText + ";"; }

                        /*Get All PT of BasketBall*/
                        if (Data["PT_BasketBall_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$2$1$0=" + Data["PT_BasketBall_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$2$1$0=" + Data["PT_BasketBall_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$2$1$0=" + Data["PT_BasketBall_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$2$1$0=" + Data["PT_BasketBall_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$2$3$0=" + Data["PT_BasketBall_Dead_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$2$3$0=" + Data["PT_BasketBall_Dead_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$2$3$0=" + Data["PT_BasketBall_Dead_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$2$3$0=" + Data["PT_BasketBall_Dead_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$2$2$0=" + Data["PT_BasketBall_Dead_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$2$2$0=" + Data["PT_BasketBall_Dead_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$2$2$0=" + Data["PT_BasketBall_Dead_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$2$2$0=" + Data["PT_BasketBall_Dead_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_Agent_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a2$2$20$0=" + Data["PT_BasketBall_Dead_Agent_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m2$2$20$0=" + Data["PT_BasketBall_Dead_MasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um2$2$20$0=" + Data["PT_BasketBall_Dead_AutoMasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im2$2$20$0=" + Data["PT_BasketBall_Dead_IsAutoMasterPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of FootBall*/
                        if (Data["PT_FootBall_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$3$1$0=" + Data["PT_FootBall_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$3$1$0=" + Data["PT_FootBall_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$3$1$0=" + Data["PT_FootBall_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$3$1$0=" + Data["PT_FootBall_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$3$3$0=" + Data["PT_FootBall_Dead_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$3$3$0=" + Data["PT_FootBall_Dead_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$3$3$0=" + Data["PT_FootBall_Dead_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$3$3$0=" + Data["PT_FootBall_Dead_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$3$2$0=" + Data["PT_FootBall_Dead_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$3$2$0=" + Data["PT_FootBall_Dead_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$3$2$0=" + Data["PT_FootBall_Dead_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$3$2$0=" + Data["PT_FootBall_Dead_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_Agent_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a2$3$20$0=" + Data["PT_FootBall_Dead_Agent_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m2$3$20$0=" + Data["PT_FootBall_Dead_MasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um2$3$20$0=" + Data["PT_FootBall_Dead_AutoMasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im2$3$20$0=" + Data["PT_FootBall_Dead_IsAutoMasterPreset_MoneyLine"].InnerText + ";"; }


                        /*Get All PT of Tenis*/
                        if (Data["PT_Tenis_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$5$1$0=" + Data["PT_Tenis_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$5$1$0=" + Data["PT_Tenis_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$5$1$0=" + Data["PT_Tenis_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$5$1$0=" + Data["PT_Tenis_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$5$3$0=" + Data["PT_Tenis_Dead_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$5$3$0=" + Data["PT_Tenis_Dead_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$5$3$0=" + Data["PT_Tenis_Dead_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$5$3$0=" + Data["PT_Tenis_Dead_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$5$2$0=" + Data["PT_Tenis_Dead_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$5$2$0=" + Data["PT_Tenis_Dead_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$5$2$0=" + Data["PT_Tenis_Dead_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$5$2$0=" + Data["PT_Tenis_Dead_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_Agent_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a2$5$20$0=" + Data["PT_Tenis_Dead_Agent_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m2$5$20$0=" + Data["PT_Tenis_Dead_MasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um2$5$20$0=" + Data["PT_Tenis_Dead_AutoMasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im2$5$20$0=" + Data["PT_Tenis_Dead_IsAutoMasterPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of BaseBall*/
                        if (Data["PT_BaseBall_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$8$1$0=" + Data["PT_BaseBall_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$8$1$0=" + Data["PT_BaseBall_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$8$1$0=" + Data["PT_BaseBall_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$8$1$0=" + Data["PT_BaseBall_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$8$3$0=" + Data["PT_BaseBall_Dead_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$8$3$0=" + Data["PT_BaseBall_Dead_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$8$3$0=" + Data["PT_BaseBall_Dead_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$8$3$0=" + Data["PT_BaseBall_Dead_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_Agent_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a2$8$20$0=" + Data["PT_BaseBall_Dead_Agent_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m2$8$20$0=" + Data["PT_BaseBall_Dead_MasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um2$8$20$0=" + Data["PT_BaseBall_Dead_AutoMasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im2$8$20$0=" + Data["PT_BaseBall_Dead_IsAutoMasterPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Golf*/
                        if (Data["PT_Golf_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$10$1$0=" + Data["PT_Golf_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$10$1$0=" + Data["PT_Golf_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$10$1$0=" + Data["PT_Golf_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$10$1$0=" + Data["PT_Golf_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$10$3$0=" + Data["PT_Golf_Dead_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$10$3$0=" + Data["PT_Golf_Dead_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$10$3$0=" + Data["PT_Golf_Dead_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$10$3$0=" + Data["PT_Golf_Dead_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$10$2$0=" + Data["PT_Golf_Dead_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$10$2$0=" + Data["PT_Golf_Dead_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$10$2$0=" + Data["PT_Golf_Dead_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$10$2$0=" + Data["PT_Golf_Dead_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_Agent_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a2$10$20$0=" + Data["PT_Golf_Dead_Agent_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m2$10$20$0=" + Data["PT_Golf_Dead_MasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um2$10$20$0=" + Data["PT_Golf_Dead_AutoMasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im2$10$20$0=" + Data["PT_Golf_Dead_IsAutoMasterPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of MotorSports*/
                        if (Data["PT_MotorSports_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$11$1$0=" + Data["PT_MotorSports_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$11$1$0=" + Data["PT_MotorSports_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$11$1$0=" + Data["PT_MotorSports_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$11$1$0=" + Data["PT_MotorSports_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_Agent_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a2$11$20$0=" + Data["PT_MotorSports_Dead_Agent_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_MasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m2$11$20$0=" + Data["PT_MotorSports_Dead_MasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um2$11$20$0=" + Data["PT_MotorSports_Dead_AutoMasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im2$11$20$0=" + Data["PT_MotorSports_Dead_IsAutoMasterPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of OtherSports*/
                        if (Data["PT_OtherSports_Dead_Agent_Handicap"] != null) { strPositionTaking = strPositionTaking + "a2$99$1$0=" + Data["PT_OtherSports_Dead_Agent_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "m2$99$1$0=" + Data["PT_OtherSports_Dead_MasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "um2$99$1$0=" + Data["PT_OtherSports_Dead_AutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterPreset_Handicap"] != null) { strPositionTaking = strPositionTaking + "im2$99$1$0=" + Data["PT_OtherSports_Dead_IsAutoMasterPreset_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$99$3$0=" + Data["PT_OtherSports_Dead_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$99$3$0=" + Data["PT_OtherSports_Dead_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$99$3$0=" + Data["PT_OtherSports_Dead_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$99$3$0=" + Data["PT_OtherSports_Dead_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$99$2$0=" + Data["PT_OtherSports_Dead_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$99$2$0=" + Data["PT_OtherSports_Dead_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$99$2$0=" + Data["PT_OtherSports_Dead_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$99$2$0=" + Data["PT_OtherSports_Dead_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_Agent_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a2$99$20$0=" + Data["PT_OtherSports_Dead_Agent_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m2$99$20$0=" + Data["PT_OtherSports_Dead_MasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um2$99$20$0=" + Data["PT_OtherSports_Dead_AutoMasterPreset_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterPreset_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im2$99$20$0=" + Data["PT_OtherSports_Dead_IsAutoMasterPreset_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of MixSportsParlay*/
                        if (Data["PT_MixSportsParlay_Dead_Agent_MixParlay"] != null) { strPositionTaking = strPositionTaking + "a2$99$9$0=" + Data["PT_MixSportsParlay_Dead_Agent_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_MasterPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m2$99$9$0=" + Data["PT_MixSportsParlay_Dead_MasterPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_AutoMasterPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "um2$99$9$0=" + Data["PT_MixSportsParlay_Dead_AutoMasterPreset_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_IsAutoMasterPreset_MixParlay"] != null) { strPositionTaking = strPositionTaking + "im2$99$9$0=" + Data["PT_MixSportsParlay_Dead_IsAutoMasterPreset_MixParlay"].InnerText + ";"; }

                        /*Get All PT of Number Game*/
                        if (Data["PT_NumberGame_Dead_Agent_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$161$81$0=" + Data["PT_NumberGame_Dead_Agent_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterPreset_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$161$81$0=" + Data["PT_NumberGame_Dead_MasterPreset_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterPreset_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$161$81$0=" + Data["PT_NumberGame_Dead_AutoMasterPreset_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterPreset_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$161$81$0=" + Data["PT_NumberGame_Dead_IsAutoMasterPreset_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_Agent_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "a2$161$83$0=" + Data["PT_NumberGame_Dead_Agent_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterPreset_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "m2$161$83$0=" + Data["PT_NumberGame_Dead_MasterPreset_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterPreset_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "um2$161$83$0=" + Data["PT_NumberGame_Dead_AutoMasterPreset_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterPreset_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "im2$161$83$0=" + Data["PT_NumberGame_Dead_IsAutoMasterPreset_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_Agent_Warrior"] != null) { strPositionTaking = strPositionTaking + "a2$161$88$0=" + Data["PT_NumberGame_Dead_Agent_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterPreset_Warrior"] != null) { strPositionTaking = strPositionTaking + "m2$161$88$0=" + Data["PT_NumberGame_Dead_MasterPreset_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterPreset_Warrior"] != null) { strPositionTaking = strPositionTaking + "um2$161$88$0=" + Data["PT_NumberGame_Dead_AutoMasterPreset_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterPreset_Warrior"] != null) { strPositionTaking = strPositionTaking + "im2$161$88$0=" + Data["PT_NumberGame_Dead_IsAutoMasterPreset_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$161$86$0=" + Data["PT_NumberGame_Dead_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$161$86$0=" + Data["PT_NumberGame_Dead_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$161$86$0=" + Data["PT_NumberGame_Dead_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$161$86$0=" + Data["PT_NumberGame_Dead_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Agent_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a2$161$85$1=" + Data["PT_NumberGame_Live_Agent_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m2$161$85$1=" + Data["PT_NumberGame_Live_MasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um2$161$85$1=" + Data["PT_NumberGame_Live_AutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterPreset_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im2$161$85$1=" + Data["PT_NumberGame_Live_IsAutoMasterPreset_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Agent_OddEven"] != null) { strPositionTaking = strPositionTaking + "a2$161$86$1=" + Data["PT_NumberGame_Live_Agent_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "m2$161$86$1=" + Data["PT_NumberGame_Live_MasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "um2$161$86$1=" + Data["PT_NumberGame_Live_AutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterPreset_OddEven"] != null) { strPositionTaking = strPositionTaking + "im2$161$86$1=" + Data["PT_NumberGame_Live_IsAutoMasterPreset_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Agent_HighLow"] != null) { strPositionTaking = strPositionTaking + "a2$161$87$1=" + Data["PT_NumberGame_Live_Agent_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterPreset_HighLow"] != null) { strPositionTaking = strPositionTaking + "m2$161$87$1=" + Data["PT_NumberGame_Live_MasterPreset_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterPreset_HighLow"] != null) { strPositionTaking = strPositionTaking + "um2$161$87$1=" + Data["PT_NumberGame_Live_AutoMasterPreset_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterPreset_HighLow"] != null) { strPositionTaking = strPositionTaking + "im2$161$87$1=" + Data["PT_NumberGame_Live_IsAutoMasterPreset_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Agent_NextCombo"] != null) { strPositionTaking = strPositionTaking + "a2$161$89$1=" + Data["PT_NumberGame_Live_Agent_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterPreset_NextCombo"] != null) { strPositionTaking = strPositionTaking + "m2$161$89$1=" + Data["PT_NumberGame_Live_MasterPreset_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterPreset_NextCombo"] != null) { strPositionTaking = strPositionTaking + "um2$161$89$1=" + Data["PT_NumberGame_Live_AutoMasterPreset_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterPreset_NextCombo"] != null) { strPositionTaking = strPositionTaking + "im2$161$89$1=" + Data["PT_NumberGame_Live_IsAutoMasterPreset_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_Agent_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "a2$161$90$1=" + Data["PT_NumberGame_Live_Agent_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterPreset_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "m2$161$90$1=" + Data["PT_NumberGame_Live_MasterPreset_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterPreset_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "um2$161$90$1=" + Data["PT_NumberGame_Live_AutoMasterPreset_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterPreset_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "im2$161$90$1=" + Data["PT_NumberGame_Live_IsAutoMasterPreset_NumberWheel"].InnerText + ";"; }
                    }
                    /* Member Level*/
                    if (strFilterCondition.IndexOf("@level='member'") >= 0)
                    {
                        /*Get All PT of Soccer*/
                        if (Data["PT_Soccer_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$1$1$0=" + Data["PT_Soccer_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$1$1$0=" + Data["PT_Soccer_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$1$1$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$1$1$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$1$1$0=" + Data["PT_Soccer_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$1$1$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$1$1$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$1$3$0=" + Data["PT_Soccer_Dead_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$1$3$0=" + Data["PT_Soccer_Dead_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$1$3$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$1$3$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$1$3$0=" + Data["PT_Soccer_Dead_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$1$3$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$1$3$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "a1$1$7$0=" + Data["PT_Soccer_Dead_AgentOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m1$1$7$0=" + Data["PT_Soccer_Dead_MasterOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "um1$1$7$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "im1$1$7$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "s1$1$7$0=" + Data["PT_Soccer_Dead_SuperOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "us1$1$7$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "is1$1$7$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$1$8$0=" + Data["PT_Soccer_Dead_AgentOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$1$8$0=" + Data["PT_Soccer_Dead_MasterOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$1$8$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$1$8$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$1$8$0=" + Data["PT_Soccer_Dead_SuperOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$1$8$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$1$8$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$1$2$0=" + Data["PT_Soccer_Dead_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$1$2$0=" + Data["PT_Soccer_Dead_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$1$2$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$1$2$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$1$2$0=" + Data["PT_Soccer_Dead_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$1$2$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$1$2$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_1x2"] != null) { strPositionTaking = strPositionTaking + "a1$1$5$0=" + Data["PT_Soccer_Dead_AgentOnMem_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_1x2"] != null) { strPositionTaking = strPositionTaking + "m1$1$5$0=" + Data["PT_Soccer_Dead_MasterOnMem_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_1x2"] != null) { strPositionTaking = strPositionTaking + "um1$1$5$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_1x2"] != null) { strPositionTaking = strPositionTaking + "im1$1$5$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_1x2"] != null) { strPositionTaking = strPositionTaking + "s1$1$5$0=" + Data["PT_Soccer_Dead_SuperOnMem_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_1x2"] != null) { strPositionTaking = strPositionTaking + "us1$1$5$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_1x2"] != null) { strPositionTaking = strPositionTaking + "is1$1$5$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_1x2"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "a1$1$4$0=" + Data["PT_Soccer_Dead_AgentOnMem_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "m1$1$4$0=" + Data["PT_Soccer_Dead_MasterOnMem_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "um1$1$4$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "im1$1$4$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "s1$1$4$0=" + Data["PT_Soccer_Dead_SuperOnMem_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "us1$1$4$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_CorrectScore"] != null) { strPositionTaking = strPositionTaking + "is1$1$4$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_CorrectScore"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "a1$1$6$0=" + Data["PT_Soccer_Dead_AgentOnMem_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "m1$1$6$0=" + Data["PT_Soccer_Dead_MasterOnMem_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "um1$1$6$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "im1$1$6$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "s1$1$6$0=" + Data["PT_Soccer_Dead_SuperOnMem_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "us1$1$6$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_TotalGoal"] != null) { strPositionTaking = strPositionTaking + "is1$1$6$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_TotalGoal"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "a1$1$9$0=" + Data["PT_Soccer_Dead_AgentOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m1$1$9$0=" + Data["PT_Soccer_Dead_MasterOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "um1$1$9$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "im1$1$9$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "s1$1$9$0=" + Data["PT_Soccer_Dead_SuperOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "us1$1$9$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "is1$1$9$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AgentOnMem_Outright"] != null) { strPositionTaking = strPositionTaking + "a1$1$10$0=" + Data["PT_Soccer_Dead_AgentOnMem_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_MasterOnMem_Outright"] != null) { strPositionTaking = strPositionTaking + "m1$1$10$0=" + Data["PT_Soccer_Dead_MasterOnMem_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoMasterOnMem_Outright"] != null) { strPositionTaking = strPositionTaking + "um1$1$10$0=" + Data["PT_Soccer_Dead_AutoMasterOnMem_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoMasterOnMem_Outright"] != null) { strPositionTaking = strPositionTaking + "im1$1$10$0=" + Data["PT_Soccer_Dead_IsAutoMasterOnMem_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_SuperOnMem_Outright"] != null) { strPositionTaking = strPositionTaking + "s1$1$10$0=" + Data["PT_Soccer_Dead_SuperOnMem_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_AutoSuperOnMem_Outright"] != null) { strPositionTaking = strPositionTaking + "us1$1$10$0=" + Data["PT_Soccer_Dead_AutoSuperOnMem_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Dead_IsAutoSuperOnMem_Outright"] != null) { strPositionTaking = strPositionTaking + "is1$1$10$0=" + Data["PT_Soccer_Dead_IsAutoSuperOnMem_Outright"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$1$1$1=" + Data["PT_Soccer_Live_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$1$1$1=" + Data["PT_Soccer_Live_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$1$1$1=" + Data["PT_Soccer_Live_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$1$1$1=" + Data["PT_Soccer_Live_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$1$1$1=" + Data["PT_Soccer_Live_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$1$1$1=" + Data["PT_Soccer_Live_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$1$1$1=" + Data["PT_Soccer_Live_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$1$3$1=" + Data["PT_Soccer_Live_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$1$3$1=" + Data["PT_Soccer_Live_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$1$3$1=" + Data["PT_Soccer_Live_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$1$3$1=" + Data["PT_Soccer_Live_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$1$3$1=" + Data["PT_Soccer_Live_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$1$3$1=" + Data["PT_Soccer_Live_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$1$3$1=" + Data["PT_Soccer_Live_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "a1$1$7$1=" + Data["PT_Soccer_Live_AgentOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "m1$1$7$1=" + Data["PT_Soccer_Live_MasterOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "um1$1$7$1=" + Data["PT_Soccer_Live_AutoMasterOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "im1$1$7$1=" + Data["PT_Soccer_Live_IsAutoMasterOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "s1$1$7$1=" + Data["PT_Soccer_Live_SuperOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "us1$1$7$1=" + Data["PT_Soccer_Live_AutoSuperOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperOnMem_1stHDP"] != null) { strPositionTaking = strPositionTaking + "is1$1$7$1=" + Data["PT_Soccer_Live_IsAutoSuperOnMem_1stHDP"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AgentOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$1$8$1=" + Data["PT_Soccer_Live_AgentOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_MasterOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$1$8$1=" + Data["PT_Soccer_Live_MasterOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoMasterOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$1$8$1=" + Data["PT_Soccer_Live_AutoMasterOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoMasterOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$1$8$1=" + Data["PT_Soccer_Live_IsAutoMasterOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_SuperOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$1$8$1=" + Data["PT_Soccer_Live_SuperOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_AutoSuperOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$1$8$1=" + Data["PT_Soccer_Live_AutoSuperOnMem_1stOverUnder"].InnerText + ";"; }
                        if (Data["PT_Soccer_Live_IsAutoSuperOnMem_1stOverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$1$8$1=" + Data["PT_Soccer_Live_IsAutoSuperOnMem_1stOverUnder"].InnerText + ";"; }

                        /*Get All PT of BasketBall*/
                        if (Data["PT_BasketBall_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$2$1$0=" + Data["PT_BasketBall_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$2$1$0=" + Data["PT_BasketBall_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$2$1$0=" + Data["PT_BasketBall_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$2$1$0=" + Data["PT_BasketBall_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$2$1$0=" + Data["PT_BasketBall_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$2$1$0=" + Data["PT_BasketBall_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$2$1$0=" + Data["PT_BasketBall_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$2$3$0=" + Data["PT_BasketBall_Dead_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$2$3$0=" + Data["PT_BasketBall_Dead_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$2$3$0=" + Data["PT_BasketBall_Dead_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$2$3$0=" + Data["PT_BasketBall_Dead_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$2$3$0=" + Data["PT_BasketBall_Dead_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$2$3$0=" + Data["PT_BasketBall_Dead_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$2$3$0=" + Data["PT_BasketBall_Dead_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$2$2$0=" + Data["PT_BasketBall_Dead_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$2$2$0=" + Data["PT_BasketBall_Dead_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$2$2$0=" + Data["PT_BasketBall_Dead_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$2$2$0=" + Data["PT_BasketBall_Dead_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$2$2$0=" + Data["PT_BasketBall_Dead_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$2$2$0=" + Data["PT_BasketBall_Dead_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$2$2$0=" + Data["PT_BasketBall_Dead_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AgentOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a1$2$20$0=" + Data["PT_BasketBall_Dead_AgentOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_MasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m1$2$20$0=" + Data["PT_BasketBall_Dead_MasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um1$2$20$0=" + Data["PT_BasketBall_Dead_AutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im1$2$20$0=" + Data["PT_BasketBall_Dead_IsAutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_SuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s1$2$20$0=" + Data["PT_BasketBall_Dead_SuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_AutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us1$2$20$0=" + Data["PT_BasketBall_Dead_AutoSuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BasketBall_Dead_IsAutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is1$2$20$0=" + Data["PT_BasketBall_Dead_IsAutoSuperOnMem_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of FootBall*/
                        if (Data["PT_FootBall_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$3$1$0=" + Data["PT_FootBall_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$3$1$0=" + Data["PT_FootBall_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$3$1$0=" + Data["PT_FootBall_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$3$1$0=" + Data["PT_FootBall_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$3$1$0=" + Data["PT_FootBall_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$3$1$0=" + Data["PT_FootBall_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$3$1$0=" + Data["PT_FootBall_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$3$3$0=" + Data["PT_FootBall_Dead_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$3$3$0=" + Data["PT_FootBall_Dead_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$3$3$0=" + Data["PT_FootBall_Dead_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$3$3$0=" + Data["PT_FootBall_Dead_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$3$3$0=" + Data["PT_FootBall_Dead_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$3$3$0=" + Data["PT_FootBall_Dead_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$3$3$0=" + Data["PT_FootBall_Dead_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$3$2$0=" + Data["PT_FootBall_Dead_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$3$2$0=" + Data["PT_FootBall_Dead_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$3$2$0=" + Data["PT_FootBall_Dead_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$3$2$0=" + Data["PT_FootBall_Dead_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$3$2$0=" + Data["PT_FootBall_Dead_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$3$2$0=" + Data["PT_FootBall_Dead_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$3$2$0=" + Data["PT_FootBall_Dead_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AgentOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a1$3$20$0=" + Data["PT_FootBall_Dead_AgentOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_MasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m1$3$20$0=" + Data["PT_FootBall_Dead_MasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um1$3$20$0=" + Data["PT_FootBall_Dead_AutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im1$3$20$0=" + Data["PT_FootBall_Dead_IsAutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_SuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s1$3$20$0=" + Data["PT_FootBall_Dead_SuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_AutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us1$3$20$0=" + Data["PT_FootBall_Dead_AutoSuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_FootBall_Dead_IsAutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is1$3$20$0=" + Data["PT_FootBall_Dead_IsAutoSuperOnMem_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Tenis*/
                        if (Data["PT_Tenis_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$5$1$0=" + Data["PT_Tenis_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$5$1$0=" + Data["PT_Tenis_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$5$1$0=" + Data["PT_Tenis_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$5$1$0=" + Data["PT_Tenis_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$5$1$0=" + Data["PT_Tenis_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$5$1$0=" + Data["PT_Tenis_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$5$1$0=" + Data["PT_Tenis_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$5$3$0=" + Data["PT_Tenis_Dead_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$5$3$0=" + Data["PT_Tenis_Dead_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$5$3$0=" + Data["PT_Tenis_Dead_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$5$3$0=" + Data["PT_Tenis_Dead_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$5$3$0=" + Data["PT_Tenis_Dead_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$5$3$0=" + Data["PT_Tenis_Dead_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$5$3$0=" + Data["PT_Tenis_Dead_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$5$2$0=" + Data["PT_Tenis_Dead_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$5$2$0=" + Data["PT_Tenis_Dead_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$5$2$0=" + Data["PT_Tenis_Dead_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$5$2$0=" + Data["PT_Tenis_Dead_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$5$2$0=" + Data["PT_Tenis_Dead_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$5$2$0=" + Data["PT_Tenis_Dead_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$5$2$0=" + Data["PT_Tenis_Dead_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AgentOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a1$5$20$0=" + Data["PT_Tenis_Dead_AgentOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_MasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m1$5$20$0=" + Data["PT_Tenis_Dead_MasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um1$5$20$0=" + Data["PT_Tenis_Dead_AutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im1$5$20$0=" + Data["PT_Tenis_Dead_IsAutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_SuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s1$5$20$0=" + Data["PT_Tenis_Dead_SuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_AutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us1$5$20$0=" + Data["PT_Tenis_Dead_AutoSuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Tenis_Dead_IsAutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is1$5$20$0=" + Data["PT_Tenis_Dead_IsAutoSuperOnMem_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of BaseBall*/
                        if (Data["PT_BaseBall_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$8$1$0=" + Data["PT_BaseBall_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$8$1$0=" + Data["PT_BaseBall_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$8$1$0=" + Data["PT_BaseBall_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$8$1$0=" + Data["PT_BaseBall_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$8$1$0=" + Data["PT_BaseBall_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$8$1$0=" + Data["PT_BaseBall_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$8$1$0=" + Data["PT_BaseBall_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$8$3$0=" + Data["PT_BaseBall_Dead_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$8$3$0=" + Data["PT_BaseBall_Dead_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$8$3$0=" + Data["PT_BaseBall_Dead_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$8$3$0=" + Data["PT_BaseBall_Dead_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$8$3$0=" + Data["PT_BaseBall_Dead_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$8$3$0=" + Data["PT_BaseBall_Dead_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$8$3$0=" + Data["PT_BaseBall_Dead_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AgentOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a1$8$20$0=" + Data["PT_BaseBall_Dead_AgentOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_MasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m1$8$20$0=" + Data["PT_BaseBall_Dead_MasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um1$8$20$0=" + Data["PT_BaseBall_Dead_AutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im1$8$20$0=" + Data["PT_BaseBall_Dead_IsAutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_SuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s1$8$20$0=" + Data["PT_BaseBall_Dead_SuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_AutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us1$8$20$0=" + Data["PT_BaseBall_Dead_AutoSuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_BaseBall_Dead_IsAutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is1$8$20$0=" + Data["PT_BaseBall_Dead_IsAutoSuperOnMem_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of Golf*/
                        if (Data["PT_Golf_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$10$1$0=" + Data["PT_Golf_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$10$1$0=" + Data["PT_Golf_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$10$1$0=" + Data["PT_Golf_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$10$1$0=" + Data["PT_Golf_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$10$1$0=" + Data["PT_Golf_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$10$1$0=" + Data["PT_Golf_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$10$1$0=" + Data["PT_Golf_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$10$3$0=" + Data["PT_Golf_Dead_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$10$3$0=" + Data["PT_Golf_Dead_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$10$3$0=" + Data["PT_Golf_Dead_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$10$3$0=" + Data["PT_Golf_Dead_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$10$3$0=" + Data["PT_Golf_Dead_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$10$3$0=" + Data["PT_Golf_Dead_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$10$3$0=" + Data["PT_Golf_Dead_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$10$2$0=" + Data["PT_Golf_Dead_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$10$2$0=" + Data["PT_Golf_Dead_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$10$2$0=" + Data["PT_Golf_Dead_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$10$2$0=" + Data["PT_Golf_Dead_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$10$2$0=" + Data["PT_Golf_Dead_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$10$2$0=" + Data["PT_Golf_Dead_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$10$2$0=" + Data["PT_Golf_Dead_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AgentOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a1$10$20$0=" + Data["PT_Golf_Dead_AgentOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_MasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m1$10$20$0=" + Data["PT_Golf_Dead_MasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um1$10$20$0=" + Data["PT_Golf_Dead_AutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im1$10$20$0=" + Data["PT_Golf_Dead_IsAutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_SuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s1$10$20$0=" + Data["PT_Golf_Dead_SuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_AutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us1$10$20$0=" + Data["PT_Golf_Dead_AutoSuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_Golf_Dead_IsAutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is1$10$20$0=" + Data["PT_Golf_Dead_IsAutoSuperOnMem_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of MotorSports*/
                        if (Data["PT_MotorSports_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$11$1$0=" + Data["PT_MotorSports_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$11$1$0=" + Data["PT_MotorSports_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$11$1$0=" + Data["PT_MotorSports_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$11$1$0=" + Data["PT_MotorSports_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$11$1$0=" + Data["PT_MotorSports_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$11$1$0=" + Data["PT_MotorSports_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$11$1$0=" + Data["PT_MotorSports_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AgentOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a1$11$20$0=" + Data["PT_MotorSports_Dead_AgentOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_MasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m1$11$20$0=" + Data["PT_MotorSports_Dead_MasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um1$11$20$0=" + Data["PT_MotorSports_Dead_AutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im1$11$20$0=" + Data["PT_MotorSports_Dead_IsAutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_SuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s1$11$20$0=" + Data["PT_MotorSports_Dead_SuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_AutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us1$11$20$0=" + Data["PT_MotorSports_Dead_AutoSuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_MotorSports_Dead_IsAutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is1$11$20$0=" + Data["PT_MotorSports_Dead_IsAutoSuperOnMem_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of OtherSports*/
                        if (Data["PT_OtherSports_Dead_AgentOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "a1$99$1$0=" + Data["PT_OtherSports_Dead_AgentOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "m1$99$1$0=" + Data["PT_OtherSports_Dead_MasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "um1$99$1$0=" + Data["PT_OtherSports_Dead_AutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "im1$99$1$0=" + Data["PT_OtherSports_Dead_IsAutoMasterOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "s1$99$1$0=" + Data["PT_OtherSports_Dead_SuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "us1$99$1$0=" + Data["PT_OtherSports_Dead_AutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperOnMem_Handicap"] != null) { strPositionTaking = strPositionTaking + "is1$99$1$0=" + Data["PT_OtherSports_Dead_IsAutoSuperOnMem_Handicap"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$99$3$0=" + Data["PT_OtherSports_Dead_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$99$3$0=" + Data["PT_OtherSports_Dead_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$99$3$0=" + Data["PT_OtherSports_Dead_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$99$3$0=" + Data["PT_OtherSports_Dead_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$99$3$0=" + Data["PT_OtherSports_Dead_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$99$3$0=" + Data["PT_OtherSports_Dead_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$99$3$0=" + Data["PT_OtherSports_Dead_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$99$2$0=" + Data["PT_OtherSports_Dead_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$99$2$0=" + Data["PT_OtherSports_Dead_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$99$2$0=" + Data["PT_OtherSports_Dead_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$99$2$0=" + Data["PT_OtherSports_Dead_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$99$2$0=" + Data["PT_OtherSports_Dead_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$99$2$0=" + Data["PT_OtherSports_Dead_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$99$2$0=" + Data["PT_OtherSports_Dead_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AgentOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "a1$99$20$0=" + Data["PT_OtherSports_Dead_AgentOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_MasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "m1$99$20$0=" + Data["PT_OtherSports_Dead_MasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "um1$99$20$0=" + Data["PT_OtherSports_Dead_AutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoMasterOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "im1$99$20$0=" + Data["PT_OtherSports_Dead_IsAutoMasterOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_SuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "s1$99$20$0=" + Data["PT_OtherSports_Dead_SuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_AutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "us1$99$20$0=" + Data["PT_OtherSports_Dead_AutoSuperOnMem_MoneyLine"].InnerText + ";"; }
                        if (Data["PT_OtherSports_Dead_IsAutoSuperOnMem_MoneyLine"] != null) { strPositionTaking = strPositionTaking + "is1$99$20$0=" + Data["PT_OtherSports_Dead_IsAutoSuperOnMem_MoneyLine"].InnerText + ";"; }

                        /*Get All PT of MixSportsParlay*/
                        if (Data["PT_MixSportsParlay_Dead_AgentOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "a1$99$9$0=" + Data["PT_MixSportsParlay_Dead_AgentOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_MasterOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "m1$99$9$0=" + Data["PT_MixSportsParlay_Dead_MasterOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_AutoMasterOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "um1$99$9$0=" + Data["PT_MixSportsParlay_Dead_AutoMasterOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_IsAutoMasterOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "im1$99$9$0=" + Data["PT_MixSportsParlay_Dead_IsAutoMasterOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_SuperOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "s1$99$9$0=" + Data["PT_MixSportsParlay_Dead_SuperOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_AutoSuperOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "us1$99$9$0=" + Data["PT_MixSportsParlay_Dead_AutoSuperOnMem_MixParlay"].InnerText + ";"; }
                        if (Data["PT_MixSportsParlay_Dead_IsAutoSuperOnMem_MixParlay"] != null) { strPositionTaking = strPositionTaking + "is1$99$9$0=" + Data["PT_MixSportsParlay_Dead_IsAutoSuperOnMem_MixParlay"].InnerText + ";"; }

                        /*Get All PT of NumberGame*/
                        if (Data["PT_NumberGame_Dead_AgentOnMem_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$161$81$0=" + Data["PT_NumberGame_Dead_AgentOnMem_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterOnMem_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$161$81$0=" + Data["PT_NumberGame_Dead_MasterOnMem_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterOnMem_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$161$81$0=" + Data["PT_NumberGame_Dead_AutoMasterOnMem_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterOnMem_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$161$81$0=" + Data["PT_NumberGame_Dead_IsAutoMasterOnMem_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperOnMem_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$161$81$0=" + Data["PT_NumberGame_Dead_SuperOnMem_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperOnMem_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$161$81$0=" + Data["PT_NumberGame_Dead_AutoSuperOnMem_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperOnMem_1stLastOverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$161$81$0=" + Data["PT_NumberGame_Dead_IsAutoSuperOnMem_1stLastOverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AgentOnMem_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "a1$161$83$0=" + Data["PT_NumberGame_Dead_AgentOnMem_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterOnMem_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "m1$161$83$0=" + Data["PT_NumberGame_Dead_MasterOnMem_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterOnMem_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "um1$161$83$0=" + Data["PT_NumberGame_Dead_AutoMasterOnMem_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterOnMem_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "im1$161$83$0=" + Data["PT_NumberGame_Dead_IsAutoMasterOnMem_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperOnMem_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "s1$161$83$0=" + Data["PT_NumberGame_Dead_SuperOnMem_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperOnMem_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "us1$161$83$0=" + Data["PT_NumberGame_Dead_AutoSuperOnMem_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperOnMem_1stLastOddEven"] != null) { strPositionTaking = strPositionTaking + "is1$161$83$0=" + Data["PT_NumberGame_Dead_IsAutoSuperOnMem_1stLastOddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AgentOnMem_Warrior"] != null) { strPositionTaking = strPositionTaking + "a1$161$88$0=" + Data["PT_NumberGame_Dead_AgentOnMem_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterOnMem_Warrior"] != null) { strPositionTaking = strPositionTaking + "m1$161$88$0=" + Data["PT_NumberGame_Dead_MasterOnMem_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterOnMem_Warrior"] != null) { strPositionTaking = strPositionTaking + "um1$161$88$0=" + Data["PT_NumberGame_Dead_AutoMasterOnMem_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterOnMem_Warrior"] != null) { strPositionTaking = strPositionTaking + "im1$161$88$0=" + Data["PT_NumberGame_Dead_IsAutoMasterOnMem_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperOnMem_Warrior"] != null) { strPositionTaking = strPositionTaking + "s1$161$88$0=" + Data["PT_NumberGame_Dead_SuperOnMem_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperOnMem_Warrior"] != null) { strPositionTaking = strPositionTaking + "us1$161$88$0=" + Data["PT_NumberGame_Dead_AutoSuperOnMem_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperOnMem_Warrior"] != null) { strPositionTaking = strPositionTaking + "is1$161$88$0=" + Data["PT_NumberGame_Dead_IsAutoSuperOnMem_Warrior"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$161$86$0=" + Data["PT_NumberGame_Dead_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$161$86$0=" + Data["PT_NumberGame_Dead_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$161$86$0=" + Data["PT_NumberGame_Dead_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$161$86$0=" + Data["PT_NumberGame_Dead_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$161$86$0=" + Data["PT_NumberGame_Dead_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$161$86$0=" + Data["PT_NumberGame_Dead_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Dead_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$161$86$0=" + Data["PT_NumberGame_Dead_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "a1$161$85$1=" + Data["PT_NumberGame_Live_AgentOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "m1$161$85$1=" + Data["PT_NumberGame_Live_MasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "um1$161$85$1=" + Data["PT_NumberGame_Live_AutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "im1$161$85$1=" + Data["PT_NumberGame_Live_IsAutoMasterOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "s1$161$85$1=" + Data["PT_NumberGame_Live_SuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "us1$161$85$1=" + Data["PT_NumberGame_Live_AutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperOnMem_OverUnder"] != null) { strPositionTaking = strPositionTaking + "is1$161$85$1=" + Data["PT_NumberGame_Live_IsAutoSuperOnMem_OverUnder"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "a1$161$86$1=" + Data["PT_NumberGame_Live_AgentOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "m1$161$86$1=" + Data["PT_NumberGame_Live_MasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "um1$161$86$1=" + Data["PT_NumberGame_Live_AutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "im1$161$86$1=" + Data["PT_NumberGame_Live_IsAutoMasterOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "s1$161$86$1=" + Data["PT_NumberGame_Live_SuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "us1$161$86$1=" + Data["PT_NumberGame_Live_AutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperOnMem_OddEven"] != null) { strPositionTaking = strPositionTaking + "is1$161$86$1=" + Data["PT_NumberGame_Live_IsAutoSuperOnMem_OddEven"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentOnMem_HighLow"] != null) { strPositionTaking = strPositionTaking + "a1$161$87$1=" + Data["PT_NumberGame_Live_AgentOnMem_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterOnMem_HighLow"] != null) { strPositionTaking = strPositionTaking + "m1$161$87$1=" + Data["PT_NumberGame_Live_MasterOnMem_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterOnMem_HighLow"] != null) { strPositionTaking = strPositionTaking + "um1$161$87$1=" + Data["PT_NumberGame_Live_AutoMasterOnMem_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterOnMem_HighLow"] != null) { strPositionTaking = strPositionTaking + "im1$161$87$1=" + Data["PT_NumberGame_Live_IsAutoMasterOnMem_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperOnMem_HighLow"] != null) { strPositionTaking = strPositionTaking + "s1$161$87$1=" + Data["PT_NumberGame_Live_SuperOnMem_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperOnMem_HighLow"] != null) { strPositionTaking = strPositionTaking + "us1$161$87$1=" + Data["PT_NumberGame_Live_AutoSuperOnMem_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperOnMem_HighLow"] != null) { strPositionTaking = strPositionTaking + "is1$161$87$1=" + Data["PT_NumberGame_Live_IsAutoSuperOnMem_HighLow"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentOnMem_NextCombo"] != null) { strPositionTaking = strPositionTaking + "a1$161$89$1=" + Data["PT_NumberGame_Live_AgentOnMem_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterOnMem_NextCombo"] != null) { strPositionTaking = strPositionTaking + "m1$161$89$1=" + Data["PT_NumberGame_Live_MasterOnMem_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterOnMem_NextCombo"] != null) { strPositionTaking = strPositionTaking + "um1$161$89$1=" + Data["PT_NumberGame_Live_AutoMasterOnMem_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterOnMem_NextCombo"] != null) { strPositionTaking = strPositionTaking + "im1$161$89$1=" + Data["PT_NumberGame_Live_IsAutoMasterOnMem_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperOnMem_NextCombo"] != null) { strPositionTaking = strPositionTaking + "s1$161$89$1=" + Data["PT_NumberGame_Live_SuperOnMem_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperOnMem_NextCombo"] != null) { strPositionTaking = strPositionTaking + "us1$161$89$1=" + Data["PT_NumberGame_Live_AutoSuperOnMem_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperOnMem_NextCombo"] != null) { strPositionTaking = strPositionTaking + "is1$161$89$1=" + Data["PT_NumberGame_Live_IsAutoSuperOnMem_NextCombo"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AgentOnMem_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "a1$161$90$1=" + Data["PT_NumberGame_Live_AgentOnMem_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_MasterOnMem_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "m1$161$90$1=" + Data["PT_NumberGame_Live_MasterOnMem_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoMasterOnMem_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "um1$161$90$1=" + Data["PT_NumberGame_Live_AutoMasterOnMem_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoMasterOnMem_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "im1$161$90$1=" + Data["PT_NumberGame_Live_IsAutoMasterOnMem_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_SuperOnMem_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "s1$161$90$1=" + Data["PT_NumberGame_Live_SuperOnMem_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_AutoSuperOnMem_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "us1$161$90$1=" + Data["PT_NumberGame_Live_AutoSuperOnMem_NumberWheel"].InnerText + ";"; }
                        if (Data["PT_NumberGame_Live_IsAutoSuperOnMem_NumberWheel"] != null) { strPositionTaking = strPositionTaking + "is1$161$90$1=" + Data["PT_NumberGame_Live_IsAutoSuperOnMem_NumberWheel"].InnerText + ";"; }
                    }
                }

                return strPositionTaking;
            }
            catch (Exception)
            {
                //cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Could not <b>getPositionTakingFromDataFile</b>", "Error");
                return "isNaN";
            }
        }


        /*
        *Created by: William.Nguyen
        *Date      : 31-12-2012
        *Function  : select Position Taking Super/Master/Agent/Member
        *Params    : 
        *           + selenium
        *           + strLevel: super/master/agent/member
        *           + strProduct: Sportsbook/Casino/Racing/LiveCasino/Virtual Sports
        *           + strPositionTaking: "m3$1$1$0=0.9;s3$1$1$0=0.8;us3$1$1$0=0.7;is3$1$1$0=0;m3$1$3$0=0.9;s3$1$3$0=0.8;us3$1$3$0=0.7;"
        *           + Timeout
        *           + fcommom (this param is used to write log)
        */
        public static void selectPositionTaking(ISelenium se, string strLevel, string strProduct, string strPositionTaking, int timeoutSecond, CommonFunc cm)
        {
            try
            {
                CommonFunc.writeLogReport("Select Position Taking on Add/Edit '" + strLevel + "' page", "Info");
                strPositionTaking = strPositionTaking.Substring(0, strPositionTaking.Length - 1);
                //Console.WriteLine(strPositionTaking);

                switch (strLevel.ToLower())
                {
                    case "super":
                        switch (strProduct.ToLower())
                        {
                            case "sportsbook":

                                break;
                        }
                        break;
                    case "master":
                        Age_UINewMaster Age_UINewMaster = new Age_UINewMaster();
                        switch (strProduct.ToLower())
                        {
                            case "sportsbook":
                                string[] arrPositionTaking = strPositionTaking.Split(';');
                                for (int i = 0; i < arrPositionTaking.Length; i++)
                                {
                                    string[] arrSubPT = arrPositionTaking[i].Split('=');
                                    if (arrSubPT[0].IndexOf("s3") == 0)
                                    {
                                        string tmp_right = arrSubPT[0].Substring(arrSubPT[0].IndexOf("s3") + 2, arrSubPT[0].Length - (arrSubPT[0].IndexOf("s3") + 2));
                                        if (strPositionTaking.IndexOf("is3" + tmp_right + "=0") >= 0)
                                        {
                                            Control.Uncheck(se, "is3" + tmp_right, timeoutSecond, cm);
                                            Control.select(se, arrSubPT[0], arrSubPT[1], timeoutSecond, cm);
                                        }else if (strPositionTaking.IndexOf("is3" + tmp_right + "=1") < 0)
                                        {
                                            Control.select(se, arrSubPT[0], arrSubPT[1], timeoutSecond, cm);
                                        }
                                    }
                                    else if (arrSubPT[0].IndexOf("us3") >= 0)
                                    {
                                        string tmp_right = arrSubPT[0].Substring(arrSubPT[0].IndexOf("us3") + 3, arrSubPT[0].Length - (arrSubPT[0].IndexOf("us3") + 3));
                                        if (strPositionTaking.IndexOf("is3" + tmp_right + "=1") >= 0)
                                        {
                                            Control.Check(se, "is3" + tmp_right, timeoutSecond, cm);
                                            Control.select(se, arrSubPT[0], arrSubPT[1], timeoutSecond, cm);
                                        }
                                    }
                                    else if (arrSubPT[0].IndexOf("is3") >= 0)
                                    {
                                        string tmp_right = arrSubPT[0].Substring(arrSubPT[0].IndexOf("is3") + 3, arrSubPT[0].Length - (arrSubPT[0].IndexOf("is3") + 3));
                                        if (strPositionTaking.IndexOf("s3" + tmp_right) < 0 && strPositionTaking.IndexOf("us3" + tmp_right) < 0)
                                        {
                                            if (arrSubPT[1] == "1")
                                            {
                                                Control.Check(se, arrSubPT[0], timeoutSecond, cm);
                                            }
                                            else if (arrSubPT[1] == "0")
                                            {
                                                Control.Uncheck(se, arrSubPT[0], timeoutSecond, cm);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Control.select(se, arrSubPT[0], arrSubPT[1], timeoutSecond, cm);
                                    }
                                }
                                break;
                        }
                        break;
                    case "agent":
                        

                        break;
                    case "member":
                        

                        break;
                }
            }
            catch (Exception)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport("Error: Select Position Taking on Add/Edit '" + strLevel + "' page", "Error");
                se.Close();
                se.Stop();
            }
        }

    }
}