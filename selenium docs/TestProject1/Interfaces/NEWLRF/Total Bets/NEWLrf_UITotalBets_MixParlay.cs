using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UITotalBets_MixParlay
{
    public string lnkMixParlay = "//span[text() = 'Mix Parlay' and @id='mixparlay_9']";//
    public string lnkSystemParlay = "//span[text() = 'System Parlay' and @id='mixparlay_29']";//
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyId";
    public string chkConvertTo = "IsConvert";
    public string btnSubmit = "//*[@id='submit-button']";
    public string frmMain = "//*[@id='page-content']";
    public string tblDataContent = "//*[@id='hor-minimalist-a']";

    public string colNumberOrder = "//th[text()='#']";
    public string colExternalID = "//th[text()='External ID']";
    public string colSystemID = "//th[text()='System ID']";
    public string colTransTime = "//th[text()='Trans.Time']";
    public string colChoice = "//th[text()='Choice']";
    public string colOdds = "//th[text()='Odds']";
    public string colStake = "//th[text()='Stake']";
    public string colStatus = "//th[text()='Status']";
    public string icoExportToExcel = "//input[@id='exporttoexcel' and @title='Export to Excel']";
}

