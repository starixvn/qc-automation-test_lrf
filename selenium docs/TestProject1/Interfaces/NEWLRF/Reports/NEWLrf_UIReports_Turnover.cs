using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_Turnover
{
    public string ddlType = "//*[@id='dllType']";
    public string ddlCurrency = "//*[@id='ddlCurrency']";
    public string chkExcludeTestData = "//*[@id='rdoExcludeTesting']";
    public string frmMain = "//*[@id='TurnoverForm']";
    public string icoExporttoExcel = "//*[@id='ExportToExcel']";
    public string btnSubmit = "//*[@id='SubmitButton']";
	public string tblReportContent = "//*[@id='data-content']";
	public string txtExternalID = "//*[@id='Username']";
	public string chkAllProduct = "ALLProducts";
    public string chkSBProduct = "//*[@data-product-code='SB' and @type='checkbox']";
    public string chkRacingProduct = "//*[@data-product-code='RB' and @type='checkbox']";
    public string chkNumberGameProduct = "//*[@data-product-code='NG' and @type='checkbox']";
    public string chkBAProduct = "//*[@data-product-code='BA' and @type='checkbox']";
    public string chkVSProduct = "//*[@data-product-code='VS' and @type='checkbox']";
    public string chkLCProduct = "//*[@data-product-code='LC' and @type='checkbox']";
    
    public string colNumberOrder = "//tr[@id='tr-betlist-header']/th[text()='#']";
    public string colExternalID = "//tr[@id='tr-betlist-header']/th[text()='External ID']";
    public string colSystemID = "//tr[@id='tr-betlist-header']/th[text()='System ID']";
    public string colTransTime = "//tr[@id='tr-betlist-header']/th[text()='Trans.Time']";
    public string colChoice = "//tr[@id='tr-betlist-header']/th[text()='Choice']";
    public string colOdds = "//tr[@id='tr-betlist-header']/th[text()='Odds']";
    public string colStake = "//tr[@id='tr-betlist-header']/th[text()='Stake']";
    public string colStatus = "//tr[@id='tr-betlist-header']/th[text()='Status']";
    public string msgRequired = "//*[@id='Turnover1_ltrWarningMessage']";
}

