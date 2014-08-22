using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests
{
    public class OWASimplified_UILogin
    {
        public string txtUserName = "//input[@id='UserName']";
        public string txtPassword = "//input[@id = 'Password']";
        public string btnLogin = "//input[@type='submit']";
        public string chkRememberMe = "//*[@id='RememberMe']";
        public string msgErrMessage = "//*[@id='msgBox']";
    }
}

