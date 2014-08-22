using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIAccountManagement_AddNewAccount
{
    public string lblTitle = "//div[text() = 'Add New Account']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblUsername = "//b[text()='Username:']";
    public string lblFirstName = "//td[text()='First Name:']";
    public string lblLastName = "//td[text()='Last Name:']";
    public string lblStatus = "//td[text()='Status:']";
    public string lblPassword = "//b[text()='Password']";
    public string lblConfirmPassword = "//b[contains(text(),'Confirm')]";
    public string lblOpen = "//label[text()='Open']";
    public string lblClosed = "//label[text()='Closed']";
    public string btnCheckAvailability = "btncheckusername";
    public string btnAdd = "btnAddNewAccount";
    public string rdoOpen = "rdoOpen";
    public string rdoClosed = "rdoClosed";

    public string txtUsername = "txtUserName";
    public string txtFirstName = "txtFirstName";
    public string txtLastName = "txtLastName";
    public string txtPassword = "txtPassWord";
    public string txtConfirmPassword = "txtConfirmPassWord";
    
}

