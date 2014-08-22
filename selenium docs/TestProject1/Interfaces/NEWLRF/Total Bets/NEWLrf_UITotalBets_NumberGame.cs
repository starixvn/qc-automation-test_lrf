using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NEWLrf_UITotalBets_NumberGame
{
    public string lblTitle = "//div[text()='Number Game']";//----//div[contains(text(), 'Click here')];----"css=div:contains("Click here")"       
    public string lblType = "//div[text()='Type:']";
    public string lblCurrency = "//div[text()='Currency:']";
    public string lblConvertTo = "//label[text()='Convert to EUR']";
    public string ddlType = "LicenseeType";
    public string ddlCurrency = "CurrencyId";
    public string chkConvertTo = "IsConvert";
    public string btnSubmit = "//*[@id='submit-button']";
    public string btnRefresh = "//*[@id='CountDownRefresh']";
    public string btnDownTime = "//div[@class='btnDown']";
    public string opt15sec = "//*[@id='option0']";
	public string opt30sec = "//*[@id='option1']";
	public string opt45sec = "//*[@id='option2']";
	public string opt65sec = "//*[@id='option3']";
	public string opt75sec = "//*[@id='option4']";
	public string tblDataContent = "//*[@id='data-content']";
	public string frmMain = "//*[@id='page-content']";
    public string colNumberOrder = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='#']";
    public string colEvent = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='Event']";
    public string colWarrior = "//tr[@class='RptHeader']/td[@colspan='2' and text()='Warrior']";
    public string col1stBall = "//tr[@class='RptHeader']/td[@colspan='2' and text()='1st Ball']";
    public string colLastBall = "//tr[@class='RptHeader']/td[@colspan='2' and text()='Last Ball']";
    public string colNextCombo = "//tr[@class='RptHeader']/td[@colspan='4' and text()='Next Combo']";
    public string colNextBall = "//tr[@class='RptHeader']/td[@colspan='3' and text()='Next Ball']";
    public string colFullTimeOddEven = "//tr[@class='RptHeader']/td[@rowspan='2' and text()='FT.O/E' and @title='Full Time Odd/Even']";
    public string colWarrior_2ndBallWin = "//tr[@class='RptHeader02']/td[1]";
    public string txtWarrior_2ndBallWin = "2nd ball win";
    public string colWarrior_3rdBallWin = "//tr[@class='RptHeader02']/td[2]";
    public string txtWarrior_3rdBallWin = "3rd ball win";
    public string col1stBall_OverUnder = "//tr[@class='RptHeader02']/td[3]";
    public string txt1stBall_OverUnder = "O/U";
    public string col1stBall_OddEven = "//tr[@class='RptHeader02']/td[4]";
    public string txt1stBall_OddEven = "O/E";
    public string colLastBall_OverUnder = "//tr[@class='RptHeader02']/td[5]";
    public string txtLastBall_OverUnder = "O/U";
    public string colLastBall_OddEven = "//tr[@class='RptHeader02']/td[6]";
    public string txtLastBall_OddEven = "O/E";
    public string colNextBall_OverUnder = "//tr[@class='RptHeader02']/td[7]";
    public string txtNextBall_OverUnder = "O/U";
    public string colNextBall_OddEven = "//tr[@class='RptHeader02']/td[8]";
    public string txtNextBall_OddEven = "O/E";
    public string colNextBall_HighLow = "//tr[@class='RptHeader02']/td[9]";
    public string txtNextBall_HighLow = "High/Low";
    public string colNextCombo_OverOdd = "//tr[@class='RptHeader02']/td[10]";
    public string txtNextCombo_OverOdd = "O/O";
    public string colNextCombo_UnderOdd = "//tr[@class='RptHeader02']/td[11]";
    public string txtNextCombo_UnderOdd = "U/O";
    public string colNextCombo_OverEven = "//tr[@class='RptHeader02']/td[12]";
    public string txtNextCombo_OverEven = "O/E";
    public string colNextCombo_UnderEven = "//tr[@class='RptHeader02']/td[13]";
    public string txtNextCombo_UnderEven = "U/E";
   
}

