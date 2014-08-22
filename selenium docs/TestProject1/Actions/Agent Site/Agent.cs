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

namespace SeleniumTests
{
    public class Agent
    {
        public void Login(ISelenium se, string UserName, string Password)
        {
            UIAgentLogIn uiAgenLogin = new UIAgentLogIn();
            se.Type(uiAgenLogin.txtUserName, UserName);
            se.Type(uiAgenLogin.txtPassWord, Password);
            se.Click(uiAgenLogin.btnLogin);
        }
    }
}
