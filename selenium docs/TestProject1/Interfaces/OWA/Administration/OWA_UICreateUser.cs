using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWA_UICreateUser
	{
		public string fraCreatePage = "//*[@id='wizard']";
		
		//step1
		public string fraStep1 = "//*[@id='step-1']";
		public string txtUsername = "//*[@id='Username']";
		public string lblUsername = "//tr[2]/td[2]/span";
		public string lblRequireUserName = "//div[text()='Username cannot be blank']";
		public string lblRequirePassWord = "//div[text()='Password cannot be blank']";
		public string msgRequiredField = "//div[@id='wizard']/div[3]/div[2]";
		public string txtPassword = "//*[@id='Password']";
		public string txtDisplayName = "//*[@id='Name']";
		public string chkIsActive = "//*[@id='IsActive']";
		public string btnPrevious = "//a[contains(text(),'‹ Previous')]";
		public string btnNext = "//a[contains(text(),'Next ›')]";
		
		//step2
		public string fraStep2 = "//*[@id='step-2']";
    	public string popEditUserLicensee = "//*[@id='editUserAssignment']";
    	public string chkBCH = "//*[@id='BCH_1']";
    	public string chkBCH_12bet = "//*[@id='BCH_Lic_0']";
    	public string chkBCH_alog = "//*[@id='BCH_Lic_1']";
    	public string chkBCH_asiabet88 = "//*[@id='BCH_Lic_2']";
    	public string chkBCH_Bodog = "//*[@id='BCH_Lic_3']";
    	public string chkBCH_Ibobet = "//*[@id='BCH_Lic_4']";
    	public string chkBCH_Macaubet = "//*[@id='BCH_Lic_5']";
    	public string chkBCH_TLC = "//*[@id='BCH_Lic_6']";
    	public string chkBoping = "//*[@id='Boping_7']";
    	public string chkBoping_SG8 = "//*[@id='Boping_Lic_0']";
    	public string chkBoping_Tycoon = "//*[@id='Boping_Lic_1']";
    	public string chkBoping_Vcasia = "//*[@id='Boping_Lic_2']";
    	public string chkCozni = "//*[@id='Cozni_5']";
    	public string chkCozni_HAIFA = "//*[@id='Cozni_Lic_0']";
    	public string chkFDL = "//*[@id='FDL_4']";
    	public string chkFDL_IBC = "//*[@id='FDL_Lic_0']";
    	public string chkLDL = "//*[@id='LDL_2']";
    	public string chkLDL_DELA = "//*[@id='LDL_Lic_0']";
    	public string chkLDL_mansion88 = "//*[@id='LDL_Lic_1']";
    	public string chkLDL_MayFair = "//*[@id='LDL_Lic_2']";
    	public string chkLDL_SunGame = "//*[@id='LDL_Lic_3']";
    	public string chkLDL_Zzun88 = "//*[@id='LDL_Lic_4']";
    	public string chkPIH = "//*[@id='PIH_8']";
    	public string chkPIH_18bb = "//*[@id='PIH_Lic_0']";
    	public string chkDemo = "//*[@id='Demo_6']";
    	public string chkDemo_Spondemo = "//*[@id='Demo_Lic_0']";
    	
    	//step3
    	public string fraStep3 = "//*[@id='step-3']";
    	public string popEditUserPermission = "//*[@id='editUserPermission']";
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
		
    	//step4
    	public string fraStep4 = "//*[@id='step-4']";
    	public string lnkEditGeneral = "//tbody/tr[1]/td/a";
		public string lnkEditLicensee = "//tbody/tr[6]/td/a";
		public string lnkEditPermission = "//thead/tr[1]/td/a";
	}
}
