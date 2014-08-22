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
	public class OWA_ManageGroupFunction 
    {	
		public static void clickCreateNewGroup(ISelenium se, int timeoutSecond, CommonFunc cm)
        {
			try
            {
				OWA_UIManageGroup managegroup = new OWA_UIManageGroup();
                Control.click(se, managegroup.btnNewGroup, cm);
                se.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport(e.ToString(), "Error");
                if (se!= null)
                {
                	se.Stop();
                	se.Close();
                }
            }
        }
		
		public static void clickCreateNewUser(ISelenium se, int timeoutSecond, CommonFunc cm)
        {
			try
            {
				OWA_UIManageGroup managegroup = new OWA_UIManageGroup();
                Control.click(se, managegroup.btnNewUser, cm);
                se.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
                CommonFunc.writeLogReport(e.ToString(), "Error");
                if (se!= null)
                {
                	se.Stop();
                	se.Close();
                }
            }
        }
		
		public static void clickExistedGroup(ISelenium se, int timeoutSecond, CommonFunc cm)
        {
			try
            {
				OWA_UIManageGroup managegroup = new OWA_UIManageGroup();
                Control.click(se, managegroup.lnkEditExistGroup, cm);
                se.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                cm.numOfError = cm.numOfError + 1;
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