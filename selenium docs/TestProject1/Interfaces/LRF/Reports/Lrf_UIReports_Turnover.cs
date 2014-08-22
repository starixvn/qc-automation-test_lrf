using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lrf_UIReports_Turnover
{
    public string ddlType = "//*[@id='dllType']";
    public string ddlCurrency = "//*[@id='ddlCurrency']";
    public string chkExcludeTestData = "//*[@id='rdoExcludeTesting']";
    public string frmMain = "//*[@id='criteria-container']";
    public string icoExporttoExcel = "//*[@id='exporttoexcel']";
    public string btnSubmit = "//*[@id='btnSubmit']";
	public string tblReportContent = "//*[@id='table_content']";
	public string txtExternalID = "//*[@id='txtUsername']";
    
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

