using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTests
{
     public class OWASimplified_Initialize
    {
        public int port = 4444;
        public string browser = "*firefox";//"*iexplore";//"*firefox";//"*iehta";//"*firefox"
        public string server = "localhost";
        
        //Live link
        public string url = "http://admin.oneworks.com";
        
        //UAT link
        //public string url = "http://203.160.236.150/OAS3/";
        
        //user UAT vs Live
        public string strAdminUserName = "pgmphuc";
        public string strAdminPassword = "1234aa";
    }
}
