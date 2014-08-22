using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests
{
    public class OWA_UILogin
    {
        public string txtUserName = "//input[@id='UserName']";
        public string txtPassword = "//input[@id = 'Password']";
        public string btnLogin = "//input[@id='btnLogin']";
        public string msgRequireUserName = "//*[@id='valMsgUserName']";
        public string msgRequirePassword = "//*[@id='valMsgPassword']";
    }
}

