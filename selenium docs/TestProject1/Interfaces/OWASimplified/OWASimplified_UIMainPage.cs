using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests
{
    public class OWASimplified_UIMainPage
    {
    	public string lnkAccountManagement = "//a[contains(text(),'Account Management')]";
        
        //Total Transaction lnk
        public string lnkTotalTrans = "//a[contains(text(),'Total Transaction')]";
        
        //Logout lnk
        public string lnkLogout = "//a[contains(text(),'Logout')]";
        
        //Change Password lnk
        public string lnkChangePW = "//a[contains(text(),'Change Password')]";
        
        //Full Screen icon
        public string iconFullScreen = "//*[@id='ContentHeader']/a";
        
        //Navigate to home page
        public string lnkHomePage = "//*[@id='authInfo']/div/a";
        
        //Win Loss report link
        public string lnkWinLossReport = "//a[contains(text(),'Sportsbook')]";
        
        //Number game report link
        public string lnkNumberGameReport = "//a[contains(text(),'Number Game')]";
        
        //VirtualSports report link
        public string lnkVirtualSportsReport = "//a[contains(text(),'Virtual Sports')]";
    }
}

