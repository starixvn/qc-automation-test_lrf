using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIAccountManagement_ManageAccount
{
    public string lblTitle = "//*[@id='header-title']";
    public string lnkResetPassWord = "//span[@class='link' and @username='tester02' and contains(text(),'Reset')]";
    public string lnkEditAccount = "//span[@class='link' and @custid='996' and @onclick='EditAccount(this)' and contains(text(),'Edit')]";
	public string lnkEditPermission = "//span[@class='link' and @custid='996' and @onclick='Permission(this)' and contains(text(),'Edit')]";

    public string colNumberOrder = "//tr[@class='report-table-header']/th[contains(text(),'#')]";
    public string colUsername = "//tr[@class='report-table-header']/th[contains(text(),'Username')]";
    public string colFirstName = "//tr[@class='report-table-header']/th[contains(text(),'First Name')]";
    public string colLastName = "//tr[@class='report-table-header']/th[contains(text(),'Last Name')]";
    public string colStatus = "//tr[@class='report-table-header']/th[contains(text(),'Status')]";
    public string colPassword = "//tr[@class='report-table-header']/th[contains(text(),'Password')]";
    public string colAccount = "//tr[@class='report-table-header']/th[contains(text(),'Account')]";
    public string colPermission = "//tr[@class='report-table-header']/th[contains(text(),'Permission')]";
    public string colAccountManagement = "//tr[@class='report-table-header']/th[contains(text(),'Account Management')]";
    public string tblContent = "//*[@id='tbl-rpt']";
    
    //reset password
    public string popResetPassword = "//*[@id='lrfPopup']";
    public string txtPassword = "//*[@id='txtPassword']";
    public string txtConfirm = "//*[@id='txtConfirm']";
    public string btnSave = "//*[@id='btnSave']";
    public string btnCancel = "//*[@id='btnCancel']";
    public string btnClose = "//span[contains(text(),'close')]";
    
    //edit account
    public string popEditAccount = "//*[@id='page-content']";
    public string txtFirstname = "//*[@id='txtFirstName']";
    public string txtLastname = "//*[@id='txtLastName']";
    public string rdoOpenStatus = "//*[@id='rdoOpen']";
    public string rdoClosedStatus = "//*[@id='rdoClosed']";
    
    //edit Permision
    public string frmPermission = "//*[@id='page-content']";
    public string chkTotalBets = "//*[@id='1']";
    public string chkForecast = "//*[@id='2']";
    public string chkReports = "//*[@id='3']";
    public string chkCustomerReport = "//*[@id='4']";
    public string chkCustomerInformation = "//*[@id='5']";
    public string chkDataWarehouse = "//*[@id='6']";
    public string chkAcountManagement = "//*[@id='7']";
    public string btnSaveNewPermission = "//input[@value='Save']";
    public string btnResetPermission = "//input[@value='Reset']";
    public string btnCancelPermission = "//input[@value='Cancel']";
}

