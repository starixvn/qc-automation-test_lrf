using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests
{
    public class OWA_UIManageGroup
    {
    	//controls on main Manage Group page
    	public string mainManageGroupPage = "//*[@id='groupScrollGrid']";
    	public string btnNewGroup = "//span[contains(text(),'New Group')]";
    	public string btnNewUser = "//span[contains(text(),'New User')]";
    	public string lnkEditExistGroup = "//tbody/tr[1]/td[1]/a";
    	public string lblRemarkGroup = "//tbody/tr[1]/td[3]/span";
    	public string lnkGroupUserList = "//td[2]/a[@id='1']";
    	public string lnkGroupPermission = "//tr[1]/td[6]/a/span";
    	public string lnkGroupLicensee = "//tr[1]/td[7]/a/span";
    	
    	//Group user list popup controls
    	public string popMainUserList = "//*[@id='userScrollGrid']";
    	public string lnkEditUser = "//a[contains(text(),'anthony')]";
    	public string txtUsername = "//*[@id='Username']";
    	public string lblDisplayName  = "//*[@id='tblUserList']/tbody/tr[1]/td[2]/span";
    	public string txtDisplayName = "//*[@id='Name']";
    	public string chkActiveUser = "//tr[1]/td[5]/button[@title='Deactivate anthony']";
    	public string chkIsActiveUser = "//*[@id='IsActive']";
    	public string btnConfirmYes = "//*[@id='msg']/a[1]";
    	public string btnConfirmNo = "//*[@id='msg']/a[2]";
    	public string btnChangePassword = "//tr[1]/td[6]/div/button";
    	public string btnNewPassword = "//input";
    	public string btnSaveNewPassword = "//tr[1]/td[6]/div/div/button[1]";
    	public string btnCancelNewPassword = "//tr[1]/td[6]/div/div/button[2]";
    	public string btnEditUserPermission = "//div[2]/table/tbody/tr[1]/td[7]/a/span";
    	public string btnEditUserLicensee = "//tr[1]/td[8]/a/span";
    	public string btnExitUserListPopup = "//div[@aria-labelledby='ui-dialog-title-dialog']/div[1]/a/span";
    	
    	//Edit User/Group Licensee popup (BCH reseller)
    	public string popEditGroupLicensee = "//*[@id='editGroupAssignment']";
    	public string popEditUserLicensee = "//*[@id='editUserAssignment']";
    	public string btnExitUserLicenseePopup = "//div[@aria-labelledby='ui-dialog-title-dialogIP']/div[1]/a/span";
    	public string btnExitGroupLicenseePopup = "//div[@aria-labelledby='ui-dialog-title-dialog']/div[1]/a/span";
    	public string chkBCH = "//*[@id='BCH_1']";
    	public string chkBCH_12bet = "//*[@id='BCH_Lic_0']";
    	public string chkBCH_alog = "//*[@id='BCH_Lic_1']";
    	public string chkBCH_asiabet88 = "//*[@id='BCH_Lic_2']";
    	public string chkBCH_Bodog = "//*[@id='BCH_Lic_3']";
    	public string chkBCH_Ibobet = "//*[@id='BCH_Lic_4']";
    	public string chkBCH_Macaubet = "//*[@id='BCH_Lic_5']";
    	public string chkBCH_TLC = "//*[@id='BCH_Lic_6']";
    	
    	//Edit Licensee popup (Boping reseller)
    	public string chkBoping = "//*[@id='Boping_7']";
    	public string chkBoping_SG8 = "//*[@id='Boping_Lic_0']";
    	public string chkBoping_Tycoon = "//*[@id='Boping_Lic_1']";
    	public string chkBoping_Vcasia = "//*[@id='Boping_Lic_2']";
    	
    	//Edit Licensee popup (Cozni reseller)
    	public string chkCozni = "//*[@id='Cozni_5']";
    	public string chkCozni_HAIFA = "//*[@id='Cozni_Lic_0']";
    	
    	//Edit Licensee popup (FDL reseller)
    	public string chkFDL = "//*[@id='FDL_4']";
    	public string chkFDL_IBC = "//*[@id='FDL_Lic_0']";
    	
    	//Edit Licensee popup (LDL reseller)
    	public string chkLDL = "//*[@id='LDL_2']";
    	public string chkLDL_DELA = "//*[@id='LDL_Lic_0']";
    	public string chkLDL_mansion88 = "//*[@id='LDL_Lic_1']";
    	public string chkLDL_MayFair = "//*[@id='LDL_Lic_2']";
    	public string chkLDL_SunGame = "//*[@id='LDL_Lic_3']";
    	public string chkLDL_Zzun88 = "//*[@id='LDL_Lic_4']";
    	
    	//Edit Licensee popup (PIH reseller)
    	public string chkPIH = "//*[@id='PIH_8']";
    	public string chkPIH_18bb = "//*[@id='PIH_Lic_0']";
    	
    	//Edit Licensee popup (Demo reseller)
    	public string chkDemo = "//*[@id='Demo_6']";
    	public string chkDemo_Spondemo = "//*[@id='Demo_Lic_0']";
    	
    	//Edit User/Group Permission
    	public string popEditGroupPermission = "//*[@id='editGroupPermission']";
    	public string popEditUserPermission = "//*[@id='editUserPermission']";
    	public string btnExitUserPermissionPopup = "//div[@aria-labelledby='ui-dialog-title-dialogIP']/div[1]/a/span";
    	public string btnExitGroupPermissionPopup = "//div[@aria-labelledby='ui-dialog-title-dialog']/div[1]/a/span";
    	public string btnWinLossRead = "//tr[1]/td[2]/button";
    	public string btnWinLossWrite = "//tr[1]/td[3]/button";
    	public string btnAdminRead ="//tr[2]/td[2]/button";
    	public string btnAdminWrite = "//tr[2]/td[3]/button";
    	public string btnManageGroupRead = "//tr[3]/td[2]/button";
    	public string btnManageGroupWrite = "//tr[3]/td[3]/button";
    	public string btnManageUserRead = "//tr[4]/td[2]/button";
    	public string btnManageUserWrite = "//tr[4]/td[3]/button";
    	public string btnTotalTransRead = "//tr[5]/td[2]/button";
    	public string btnTotalTransWrite = "//tr[5]/td[3]/button";
    	public string btnWinlossRead = "//tr[6]/td[2]/button";
    	public string btnWinlossWrite = "//tr[6]/td[3]/button";
    	public string btnRacingRead = "//tr[7]/td[2]/button";
    	public string btnRacingWrite = "//tr[7]/td[3]/button";
    	public string btnOANDARead = "//tr[8]/td[2]/button";
    	public string btnOANDAWrite = "//tr[8]/td[3]/button";
    	public string btnSystemCfgRead = "//tr[9]/td[2]/button";
    	public string btnSystemCfgWrite = "//tr[9]/td[3]/button";
    	public string btnManageCfgRead = "//tr[10]/td[2]/button";
    	public string btnManageCfgWrite = "//tr[10]/td[3]/button";
    	public string btnManageFuncRead = "//tr[11]/td[2]/button";
    	public string btnManageFuncWrite = "//tr[11]/td[3]/button";
    	public string btnManageMenuRead = "//tr[12]/td[2]/button";
    	public string btnManageMenuWrite = "//tr[12]/td[3]/button";
    	public string btnManageKPIRead = "//tr[13]/td[2]/button";
    	public string btnManageKPIWrite = "//tr[13]/td[3]/button";
    	public string btnSubmit = "//*[@id='Submit']";
    }
}

