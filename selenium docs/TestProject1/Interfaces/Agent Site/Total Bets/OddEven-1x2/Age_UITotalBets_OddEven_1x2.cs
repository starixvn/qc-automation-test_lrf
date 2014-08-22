using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_OddEven_1x2
{
    public string lblTitle = "//div[text() = 'Odd/Even + 1 X 2' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='#']";
    public string colTime = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='Time']";
    public string colEvent = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='Event']";
    public string colFullTime = "//tr[@class='RptHeader']/td[@colspan='3' and text()='Full Time']";
    public string col1stHalf = "//tr[@class='RptHeader']/td[@colspan='3' and text()='1st Half']";
    public string colFullTime_OddEven = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[1]";
    public string colFullTime_1x2 = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[2]";
    public string col1stHalf_OddEven = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[3]";
    public string col1stHalf_1x2 = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[4]";
}

