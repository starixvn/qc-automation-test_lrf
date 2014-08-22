using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Acc_UIAddNewSuper
{
    //public string tabBalance = "//a[@id='balance' and text()='Balance']";
    //public string tabTransfer = "//a[@id='transfer' and text()='Transfer']";
    //public string tabChangePassword = "//a[@id='changepass' and text()='Change Password']";
    //public string tabViewLog = "//a[@id='viewlog' and text()='View Log']";
    public string cmbListTypeCustomerToAddNews = "listType";
    public string txtPassword = "txtPwd";
    public string txtUsername = "//input[@class='f8 w130']";//id=txtUsername, but dont know why selenium cannot input text if capture control by id
    public string cmbSite = "listSite";
    public string cmbCurrency = "listCurrency";
    public string btnAdd = "btnAdd";
    
    //public string frmTopMenu = "//frame[@id='frHeader' and @name='frHeader']";
}
