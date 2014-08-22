using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests
{
    public class OWA_UIMainPage
    {
        //Administration lnks 
    	public string lnkManageGroup = "//a[contains(text(),'Manage Group')]";
        public string lnkCreateGroup = "//a[contains(text(),'Create Group')]";
        public string lnkManageUser = "//a[contains(text(),'Manage User')]";
        public string lnkCreateUser = "//a[contains(text(),'Create User')]";
        
        //Total Transaction lnk
        public string lnkTotalTrans = "//li[2]/a/span";
        
        //Win Loss report lnks
        public string lnkLicWinLoss = "//a[contains(text(),'Licensee Win Loss')]";
        public string lnkCurWinLoss = "//a[contains(text(),'Currency Win Loss')]";
        public string lnkVirtualWinLoss = "//a[contains(text(),'Virtual Sports')]";
        public string lnkNumberGameWinLoss = "//a[contains(text(),'Number Game Win Loss')]";
        
        //Racing lnk
        public string lnkRacing = "//li[4]/a/span";
        
        //Exchange Rate lnk
        public string lnkExchangeRate = "//li[5]/a/span";
        
        //System Configuration lnks
        public string lnkManageConfig = "//a[contains(text(),'Manage Configuration')]";
        public string lnkManageFunction = "//a[contains(text(),'Manage Function')]";
        public string lnkManageMenu = "//a[contains(text(),'Manage Menu')]";
        
        //Logout lnk
        public string lnkLogout = "//a[contains(text(),'Logout')]";
        
        //Change Password lnk
        public string lnkChangePW = "//a[contains(text(),'Change Password')]";
        
        //Full Screen icon
        public string iconFullScreen = "//div[2]/div/div/div/a";
        
        //Navigate to home page
        public string lnkHomePage = "//*[@id='authInfo']/div/a";
        
        
//		public static Textbox userName = new Textbox("//*[@id='mainPage']/div[1]/div[2]/div/ul[1]/li[1]/a/span");

    }
}

