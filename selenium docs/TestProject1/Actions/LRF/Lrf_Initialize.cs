using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTests
{
    public class Lrf_Initialize
    {
        public int port = 4444;
        public string browser = "*firefox";//"*iexplore";//"*firefox";//"*iehta";//"*firefox"
        //public string url = "http://203.160.236.150/LRF2/";
        //public string url = "http://203.160.236.150/LRF/";
        public string url = "http://internal.006660.com/Index.aspx";
        //public string url = "http://internal.006660.net/Index.aspx";
        //public string url = "http://10.18.200.201:8003/V1/Index.aspx";
        public string server = "localhost";
        public string strCaptcha = "9042";
        public string strAdminUserName = "tester03";
        public string strAdminPassword = "12345AA";
        //public string strAdminPassword = "1234aa";
        public string btnLicensee = "//p[@onclick=\"document.location.href='selectlicensee.aspx?licenseeid=1'\"]";
    }
}
