using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_MoneyLine
{
    public string lblTitle = "//div[text() = 'Money Line' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='#']";
    public string colTime = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='Time']";
    public string colEvent = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='Event']";
    public string colFullTime = "//tr[@class='RptHeader']/td[@colspan='4' and text()='Full Time']";
    public string col1stHalf = "//tr[@class='RptHeader']/td[@colspan='4' and text()='1st Half']";
    public string colFullTime_TotalHome = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[text()='Total Home'][1]";
    public string colFullTime_TotalAway = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[text()='Total Away'][2]";
    public string colFullTime_ForecastHome = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[3]";
    public string colFullTime_ForecastAway = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[4]";
    public string col1stHalf_TotalHome = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[5]";
    public string col1stHalf_TotalAway = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[6]";
    public string col1stHalf_ForecastHome = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[7]";
    public string col1stHalf_ForecastAway = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[8]";
}

