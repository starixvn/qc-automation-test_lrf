using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_Outright
{
    public string lblTitle = "//div[text() = 'Outright' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[1]";
    public string colTeam = "//tr[@class='RptHeader']/td[2]";
    public string colBalance = "//tr[@class='RptHeader']/td[3]";
    public string colForecast = "//tr[@class='RptHeader']/td[4]";
}

