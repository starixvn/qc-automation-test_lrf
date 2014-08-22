using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTests
{
    public class Age_UIForecast_Handicap_OverUnder_Live
    {
        public string lblTitle = "//div[@id='header_main']/span[@id='leagueName']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
        public string btnRefresh = "//div[@id='CountDownRefresh' and @class='btnRefresh' and @onclick='return CountDownRefresh_Refresh()']";
        public string lblLeague = "//div[@id='box_header']/table/tbody/tr/td[text()='League'][1]";
        public string cmbLeague = "ddlLeague";
        public string colTeam = "//tr[@class='RptHeader']/td[@colspan='2'][1]";
        public string colHandicap = "//tr[@class='RptHeader']/td[2]";
        public string colOverUnder = "//tr[@class='RptHeader']/td[3]";
        public string iconForecast = "//a[contains(@href,'javascript:openForecastPopup')][1]";
        public string lnkViewOtherForecast = "//a[contains(@href,'javascript:GetFCAH')][1]";
    }

}