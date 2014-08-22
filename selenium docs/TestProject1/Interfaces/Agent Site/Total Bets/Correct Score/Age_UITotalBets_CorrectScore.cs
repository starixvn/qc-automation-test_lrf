using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_CorrectScore
{
    public string lblTitle = "//div[@id='header_main']/b[text() = 'Bet List ']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string colNumberOrder = "//tr[@class='RptHeader']/td[text()='#']";
    public string colMember = "//tr[@class='RptHeader']/td[text()='Member']";
    public string colTransTime = "//tr[@class='RptHeader']/td[text()='Trans.Time']";
    public string colChoice = "//tr[@class='RptHeader']/td[text()='Choice']";
    public string colOdds = "//tr[@class='RptHeader']/td[text()='Odds']";
    public string colStake = "//tr[@class='RptHeader']/td[text()='Stake']";
    public string colStatus = "//tr[@class='RptHeader']/td[text()='Status']";
    public string colAgentPTComm = "//tr[@class='RptHeader']/td[contains(text(),'AgentPT/')]";
    //public string colAgentPTComm = "//tr[@class='RptHeader']/td[text()='AgentPT/<br>Comm']";
    public string icoExportToExcel = "//input[@id='exporttoexcel' and @title='Export to Excel']";
}

