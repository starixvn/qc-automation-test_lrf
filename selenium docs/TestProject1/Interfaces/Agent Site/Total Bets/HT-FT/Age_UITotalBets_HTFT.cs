using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UITotalBets_HTFT
{
    public string lblTitle = "//div[text() = 'HT/FT' and @id='header_main']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[1]";
    public string colHome = "//tr[@class='RptHeader']/td[2]";
    public string colAway = "//tr[@class='RptHeader']/td[3]";
    public string colHH = "//tr[@class='RptHeader']/td[4]";
    public string colHD = "//tr[@class='RptHeader']/td[5]";
    public string colHA = "//tr[@class='RptHeader']/td[6]";
    public string colDH = "//tr[@class='RptHeader']/td[7]";
    public string colDD = "//tr[@class='RptHeader']/td[8]";
    public string colDA = "//tr[@class='RptHeader']/td[9]";
    public string colAH = "//tr[@class='RptHeader']/td[10]";
    public string colAD = "//tr[@class='RptHeader']/td[11]";
    public string colAA = "//tr[@class='RptHeader']/td[12]";
}

