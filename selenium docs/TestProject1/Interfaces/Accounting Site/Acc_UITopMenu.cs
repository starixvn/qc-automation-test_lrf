using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Acc_UITopMenu
{
    //public string tabBalance = "//a[@id='balance' and text()='Balance']";
    //public string tabTransfer = "//a[@id='transfer' and text()='Transfer']";
    //public string tabChangePassword = "//a[@id='changepass' and text()='Change Password']";
    //public string tabViewLog = "//a[@id='viewlog' and text()='View Log']";
    public string linkLogOut = "//a[text()='Log out']";
    public string txtSearchUserName = "txtuserName";
    public string btnSearchUserName = "btnSendMsg";
    
    //-----------Customer
    public string tabCustomer = "//li[@id='item_127']/a/span";
    public string linkNewCustomer = "//a[@onclick=\"activeParentMenu(document.getElementById('item_127_0'));Submenu_Click('Customer/CustomerFrame.aspx');\"]";
    public string linkViewPT = "//a[text()='View PT']";
    //public string linkSubNewCustomer = "//div[@id='sitem_127_0']";
    //public string frmTopMenu = "//frame[@id='frHeader' and @name='frHeader']";
}
