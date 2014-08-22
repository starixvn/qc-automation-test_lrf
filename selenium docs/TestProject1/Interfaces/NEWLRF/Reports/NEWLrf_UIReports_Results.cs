using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UIReports_Results
{
    public string lblTitle = "//div[text() = 'Results']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblDate = "//span[text()='Date:']";
    public string icoExporttoExcel = "exporttoexcel";
    public string btnSubmit = "submit-button";
    public string btnToday = "dToday";
    public string btnYesterday = "dYesterday";
    public string btnOutright = "btResultType blockui";
    public string txtDate = "fdate";
    public string btnSelectDate = "//*[@id='fdate_trigger']";
    public string frmMain = "//*[@id='criteria-container']";
    public string ddlSportType = "//*[@id='ddlSport']";
    public string ddlLeagues = "//*[@id='ddlLeague']";
    public string tblReportContent = "//*[@id='tbl-rpt']";
}

