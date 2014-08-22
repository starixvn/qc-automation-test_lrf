using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_HorseRacing
{
    public string lblTitle = "//div[text() = 'Horse Racing' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colRace = "//tr[@class='RptHeader']/td[@rowspan='3'][1]";
    public string colHorseNo = "//tr[@class='RptHeader']/td[@rowspan='3'][2]";
    public string colHorse = "//tr[@class='RptHeader']/td[@rowspan='3'][3]";
    public string colTote = "//tr[@class='RptHeader']/td[4]";
    public string colTote_Win = "//tr[@class='RptHeader']/td[@colspan='2'][1]";
    public string colTote_Place = "//tr[@class='RptHeader']/td[@colspan='2'][2]";
    public string colTote_WinPlace = "//tr[@class='RptHeader']/td[@colspan='2'][3]";
    public string colTote_Win_Total = "//tr[@class='RptHeader02']/td[1]";
    public string colTote_Win_WinLoss = "//tr[@class='RptHeader02']/td[2]";
    public string colTote_Place_Total = "//tr[@class='RptHeader02']/td[3]";
    public string colTote_Place_WinLoss = "//tr[@class='RptHeader02']/td[4]";
    public string colTote_WinPlace_Total = "//tr[@class='RptHeader02']/td[5]";
    public string colTote_WinPlace_WinLoss = "//tr[@class='RptHeader02']/td[6]";
}

