using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests
{
    public class OWASimplified_UIAccountManagement
    {
    	//controls on main AccountManagement page
    	public string mainManageUserPage = "//*[@id='mainPage']/div[2]/div/div[2]";
    	public string btnNewAccount = "//span[contains(text(),'New Account')]";
    	public string lnkEditExistUser = "//tbody/tr[1]/td[1]/a";
    	public string btnActiveUser = "//*[@id='btnActivateUser_3']";
    	public string popActiveUser = "//*[@id='msgbox1']";
    	public string btnConfirmYes = "//*[@id='msgbox1']/div/a[1]";
    	public string btnConfirmNo = "//*[@id='msgbox1']/div/a[2]";
    	public string btnChangePassword = "//tr[1]/td[7]/div/button";
    	public string txtNewPassword = "//input";
    	public string btnSaveNewPassword = "//tr[1]/td[7]/div/div/button[1]";
    	public string btnCancelNewPassword = "//tr[1]/td[7]/div/div/button[2]";
    	
    	//create and edit User
    	public string dlgEditAccount = "//*[@id='dialog']";
    	public string lblAccountName = "//*[@id='ui-dialog-title-dialog']/span";
    	public string txtUsername = "//*[@id='Username']";
    	public string txtPassword = "//*[@id='Password']";
    	public string txtDisplayName = "//*[@id='Name']";
    	public string chkIsActiveStatus = "//*[@id='IsActive']";
    	public string chkIsAdminRole = "//*[@id='IsAdmin']";
    	public string btnSubmit = "//*[@id='Submit']";
    	public string btnCancel = "//*[@id='Cancel']";
    }
}

