using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_TotalGoal
{
    public string lblTitle = "//div[text() = 'Total Goal' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[1]";
    public string colHome = "//tr[@class='RptHeader']/td[2]";
    public string colAway = "//tr[@class='RptHeader']/td[3]";
    public string col01 = "//tr[@class='RptHeader']/td[4]";
    public string col23 = "//tr[@class='RptHeader']/td[5]";
    public string col46 = "//tr[@class='RptHeader']/td[6]";
    public string col7Over = "//tr[@class='RptHeader']/td[7]";
}

