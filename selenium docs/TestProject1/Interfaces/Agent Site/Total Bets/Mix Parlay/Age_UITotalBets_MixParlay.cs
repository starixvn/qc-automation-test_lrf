using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_MixParlay
{
    public string lblTitle = "//div[@id='header_main']/b[text()='Mix Parlay ']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string colNumberOrder = "//tr[@class='RptHeader']/td[1]";
    public string colMember = "//tr[@class='RptHeader']/td[2]";
    public string colTransTime = "//tr[@class='RptHeader']/td[3]";
    public string colChoice = "//tr[@class='RptHeader']/td[4]";
    public string colOdds = "//tr[@class='RptHeader']/td[5]";
    public string colStake = "//tr[@class='RptHeader']/td[6]";
    public string colStatus = "//tr[@class='RptHeader']/td[7]";
    public string colAgentPTComm = "//tr[@class='RptHeader']/td[contains(text(),'AgentPT/')]";
    //public string colAgentPTComm = "//tr[@class='RptHeader']/td[text()='AgentPT/<br>Comm']";
    public string icoExportToExcel = "//input[@id='exporttoexcel' and @title='Export to Excel']";
}

