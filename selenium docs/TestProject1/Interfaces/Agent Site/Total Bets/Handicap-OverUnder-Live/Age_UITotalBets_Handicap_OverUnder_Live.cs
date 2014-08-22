using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_Handicap_OverUnder_Live
{
    public string lblTitle = "//div[text() = 'Handicap/Over Under/Live' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    //public string btnSubmit = "//input[@class='log_button' and @type='submit']";
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='#']";
    public string colTime = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='Time']";
    public string colEvent = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='Event']";
    public string colFullTime = "//tr[@class='RptHeader']/td[@colspan='4' and text()='Full Time']";
    public string col1stHalf = "//tr[@class='RptHeader']/td[@colspan='4' and text()='1st Half']";
    public string colFullTime_Handicap = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[@colspan='2' and text()='Handicap'][1]";
    public string colFullTime_OverUnder = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[@colspan='2' and text()='Over/Under'][2]";
    public string col1stHalf_Handicap = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[@colspan='2'][3]";
    public string col1stHalf_OverUnder = "//div[@id='sContent']/table/tbody/tr[@class='RptHeader02']/td[@colspan='2'][4]";
}

