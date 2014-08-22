using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTests
{
     public class OWA_Initialize
    {
        public int port = 4444;
        public string browser = "*firefox";//"*iexplore";//"*firefox";//"*iehta";//"*firefox"
        public string server = "localhost";
        
        //Local link
        //public string url = "http://10.18.200.201:8005/OWA1/Auth/Login/";
        
        //UAT link
        //public string url = "http://203.160.236.150/SA/Auth/Login";
        public string url = "http://203.160.236.150/OWA1/";
        	
        //Live link
        //public string url = "http://58.86.55.10:8090/";
        
        
        //user local
        //public string strAdminUserName = "pgmphuc";
        //public string strAdminPassword = "1234aa";
        
        //user UAT vs Live
        public string strAdminUserName = "pgmryan";
        public string strAdminPassword = "12345AA";
    }
}
