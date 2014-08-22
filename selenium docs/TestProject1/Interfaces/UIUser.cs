using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class UIUser
{
    public string linkNumAccIT = "//span[@onclick=\"SelAccount(1,'IT');\"]";
    public string linkAccount = "//span[@onclick=\"OpenEditAcc(2428924,'phucSelenium','IT');\"]";

    public string linkAccountManagement = "//a[@id='item_8_0']/span";
    public string txtEditFName = "txtFName";
    public string txtEditLName = "txtLName";
    public string txtKeyword = "txtSearch";
    public string btnEditSubmit = "btnSubmit";
    public string btnSearch = "btnGo";
    public string btnViewAllAccounts = "//a[@onclick=\"SelAccount('','all');\"]";
    //public string tblListAccount = "//table[@id='tblallaccountlist']";
    public string tblListAccount = "tblallaccountlist";
}

