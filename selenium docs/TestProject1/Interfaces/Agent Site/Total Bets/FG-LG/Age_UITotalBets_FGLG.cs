using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_FGLG
{
    public string lblTitle = "//div[text() = 'FG/LG' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[1]";
    public string colTime = "//tr[@class='RptHeader']/td[2]";
    public string colHomeAway = "//tr[@class='RptHeader']/td[3]";
    public string colFirstGoal = "//tr[@class='RptHeader']/td[4]";
    public string colLastGoal = "//tr[@class='RptHeader']/td[5]";
    public string colNoGoal = "//tr[@class='RptHeader']/td[6]";
}

