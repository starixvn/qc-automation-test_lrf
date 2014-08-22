using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Age_UINewMaster
{
    public string divTitle = "//div[@id='header_main' and text()='Add New Master']";
    
    public string tabSearchAndCopy = "//span[text()='Search And Copy']";
    public string tabFullMode = "//span[text()='Full Mode']";

    public string btnAdd = "btnSubmit";

    //General Information Section
    public string divGeneralInformation = "//div[text()='General Information']";
    public string cmbSubUserName1 = "selectedOne";
    public string cmbSubUserName2 = "selectedTwo";
    public string txtPassword = "password";
    public string txtFirstName = "firstName";
    public string txtLastName = "lastName";
    public string txtPhone = "phone";
    public string txtMobilePhone = "mobilePhone";
    public string txtMasterMaxCredit = "credit";
    public string txtFax = "fax";
    public string chkAllowAutoPT = "allowautopt";
    public string chkSuspended = "suspended";

    //Commission Section
    public string divCommission = "//div[text()='Commission']";
    public string cmbGroupA = "groupA";
    public string cmbGroupB = "groupB";
    public string cmbGroupC = "groupC";
    public string cmbGroupD = "groupD";
    public string cmb1x2Comm = "discount1x2";
    public string cmbOthersComm = "discountCS";
    public string cmbGameComm = "discountNumber";

    //Account Balance Transfer Condition Section
    public string divAccountBalanceTransferCondition = "//div[text()='Account Balance Transfer Condition']";
    public string rdoDaily = "rdDaily";
    public string rdoWeekly = "rdWeekly";
    public string chkMon = "chkMon";
    public string chkTue = "chkTue";
    public string chkWed = "chkWed";
    public string chkThurs = "chkThurs";
    public string chkFri = "chkFri";
    public string chkSat = "chkSat";
    public string chkSun = "chkSun";

    //Bet Setting Section
    public string divBetSetting = "//div[text()='Bet Setting']";

    public string divCopyAllBetSettingFromSoccer = "//div[@title='Copy all below bet settings from Soccer (excluding Number Game)']";
    public string divCopyAllBetSettingFromBasketball = "//div[@title='Copy all below bet settings from Basketball (excluding Number Game)']";
    
    public string txtSoccerMinBet = "xpath=(//input[@type='text'])[7]";
    public string txtSoccerMaxBet = "xpath=(//input[@type='text'])[8]";
    public string txtSoccerMaxPerMatch = "xpath=(//input[@type='text'])[9]";

    public string txtBasketBallMinBet = "xpath=(//input[@type='text'])[10]";
    public string txtBasketBallMaxBet = "xpath=(//input[@type='text'])[11]";
    public string txtBasketBallMaxPerMatch = "xpath=(//input[@type='text'])[12]";

    public string txtFootballMinBet = "xpath=(//input[@type='text'])[13]";
    public string txtFootballMaxBet = "xpath=(//input[@type='text'])[14]";
    public string txtFootballMaxPerMatch = "xpath=(//input[@type='text'])[15]";

    public string txtTenisMinBet = "xpath=(//input[@type='text'])[16]";
    public string txtTenisMaxBet = "xpath=(//input[@type='text'])[17]";
    public string txtTenisMaxPerMatch = "xpath=(//input[@type='text'])[18]";

    public string txtBaseballMinBet = "xpath=(//input[@type='text'])[19]";
    public string txtBaseballMaxBet = "xpath=(//input[@type='text'])[20]";
    public string txtBaseballMaxPerMatch = "xpath=(//input[@type='text'])[21]";

    public string txtGolfMinBet = "xpath=(//input[@type='text'])[22]";
    public string txtGolfMaxBet = "xpath=(//input[@type='text'])[23]";
    public string txtGolfMaxPerMatch = "xpath=(//input[@type='text'])[24]";

    public string txtMotorSportsMinBet = "xpath=(//input[@type='text'])[25]";
    public string txtMotorSportsMaxBet = "xpath=(//input[@type='text'])[26]";
    public string txtMotorSportsMaxPerMatch = "xpath=(//input[@type='text'])[27]";

    public string txtOtherSportsMinBet = "xpath=(//input[@type='text'])[28]";
    public string txtOtherSportsMaxBet = "xpath=(//input[@type='text'])[29]";
    public string txtOtherSportsMaxPerMatch = "xpath=(//input[@type='text'])[30]";

    public string txtMixSportsParlayMinBet = "xpath=(//input[@type='text'])[31]";
    public string txtMixSportsParlayMaxBet = "xpath=(//input[@type='text'])[32]";
    public string txtMixSportsParlayMaxPerMatch = "xpath=(//input[@type='text'])[33]";

    public string txtNumberGameMinBet = "xpath=(//input[@type='text'])[34]";
    public string txtNumberGameMaxBet = "xpath=(//input[@type='text'])[35]";
    public string txtNumberGameMaxPerMatch = "xpath=(//input[@type='text'])[36]";
    public string txtNumberGameMaxPerBall = "xpath=(//input[@type='text'])[37]";


    //Position Taking Section
    public string divPositionTaking = "//div[text()='Position Taking']";

    public string divCopyAllPTFromSoccer = "//div[@title='Copy all below position taking settings from Soccer Handicap']";
    public string divCopyAllPTFromBasketball = "//div[@title='Copy all below position taking settings from Basketball Handicap']";

    //Soccer
    public string divSoccerPTTitle = "//div[@class='PTSportLabel' and text()='Soccer']";
    public string divCopyFromSoccer_DeadBall_Handicap = "//div[@id='e$1$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"
    public string divCopyFromSoccer_DeadBall_1x2 = "//div[@id='e$1$5$0']/div";
    public string divCopyFromSoccer_LiveBall_Handicap = "//div[@id='e$1$1$1']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbSoccer_DeadBall_MasterPreset_Handicap = "m3$1$1$0";
    public string cmbSoccer_DeadBall_SuperPreset_Handicap = "s3$1$1$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_Handicap = "us3$1$1$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_Handicap = "//input[@name='is3$1$1$0']";

    public string cmbSoccer_DeadBall_MasterPreset_OverUnder = "m3$1$3$0";
    public string cmbSoccer_DeadBall_SuperPreset_OverUnder = "s3$1$3$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_OverUnder = "us3$1$3$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_OverUnder = "//input[@name='is3$1$3$0']";

    public string cmbSoccer_DeadBall_MasterPreset_1stHandicap = "m3$1$7$0";
    public string cmbSoccer_DeadBall_SuperPreset_1stHandicap = "s3$1$7$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_1stHandicap = "us3$1$7$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_1stHandicap = "//input[@name='is3$1$7$0']";

    public string cmbSoccer_DeadBall_MasterPreset_1stOverUnder = "m3$1$8$0";
    public string cmbSoccer_DeadBall_SuperPreset_1stOverUnder = "s3$1$8$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_1stOverUnder = "us3$1$8$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_1stOverUnder = "//input[@name='is3$1$8$0']";

    public string cmbSoccer_DeadBall_MasterPreset_OddEven = "m3$1$2$0";
    public string cmbSoccer_DeadBall_SuperPreset_OddEven = "s3$1$2$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_OddEven = "us3$1$2$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_OddEven = "//input[@name='is3$1$2$0']";

    public string cmbSoccer_DeadBall_MasterPreset_1x2 = "m3$1$5$0";
    public string cmbSoccer_DeadBall_SuperPreset_1x2 = "s3$1$5$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_1x2 = "us3$1$5$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_1x2 = "//input[@name='is3$1$5$0']";

    public string cmbSoccer_DeadBall_MasterPreset_CorrectScore = "m3$1$4$0";
    public string cmbSoccer_DeadBall_SuperPreset_CorrectScore = "s3$1$4$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_CorrectScore = "us3$1$4$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_CorrectScore = "//input[@name='is3$1$4$0']";

    public string cmbSoccer_DeadBall_MasterPreset_TotalGoal = "m3$1$6$0";
    public string cmbSoccer_DeadBall_SuperPreset_TotalGoal = "s3$1$6$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_TotalGoal = "us3$1$6$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_TotalGoal = "//input[@name='is3$1$6$0']";

    public string cmbSoccer_DeadBall_MasterPreset_MixParlay = "m3$1$9$0";
    public string cmbSoccer_DeadBall_SuperPreset_MixParlay = "s3$1$9$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_MixParlay = "us3$1$9$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_MixParlay = "//input[@name='is3$1$9$0']";

    public string cmbSoccer_DeadBall_MasterPreset_Outright = "m3$1$10$0";
    public string cmbSoccer_DeadBall_SuperPreset_Outright = "s3$1$10$0";
    public string cmbSoccer_DeadBall_AutoSuperPreset_Outright = "us3$1$10$0";
    public string chkSoccer_DeadBall_AutoSuperPreset_Outright = "//input[@name='is3$1$10$0']";

    public string cmbSoccer_LiveBall_MasterPreset_Handicap = "m3$1$1$1";
    public string cmbSoccer_LiveBall_SuperPreset_Handicap = "s3$1$1$1";
    public string cmbSoccer_LiveBall_AutoSuperPreset_Handicap = "us3$1$1$1";
    public string chkSoccer_LiveBall_AutoSuperPreset_Handicap = "//input[@name='is3$1$1$1']";

    public string cmbSoccer_LiveBall_MasterPreset_OverUnder = "m3$1$3$1";
    public string cmbSoccer_LiveBall_SuperPreset_OverUnder = "s3$1$3$1";
    public string cmbSoccer_LiveBall_AutoSuperPreset_OverUnder = "us3$1$3$1";
    public string chkSoccer_LiveBall_AutoSuperPreset_OverUnder = "//input[@name='is3$1$3$1']";

    public string cmbSoccer_LiveBall_MasterPreset_1stHandicap = "m3$1$7$1";
    public string cmbSoccer_LiveBall_SuperPreset_1stHandicap = "s3$1$7$1";
    public string cmbSoccer_LiveBall_AutoSuperPreset_1stHandicap = "us3$1$7$1";
    public string chkSoccer_LiveBall_AutoSuperPreset_1stHandicap = "//input[@name='is3$1$7$1']";

    public string cmbSoccer_LiveBall_MasterPreset_1stOverUnder = "m3$1$8$1";
    public string cmbSoccer_LiveBall_SuperPreset_1stOverUnder = "s3$1$8$1";
    public string cmbSoccer_LiveBall_AutoSuperPreset_1stOverUnder = "us3$1$8$1";
    public string chkSoccer_LiveBall_AutoSuperPreset_1stOverUnder = "//input[@name='is3$1$8$1']";


    //Basketball
    public string divBasketBallPTTitle = "//div[@class='PTSportLabel' and text()='Basketball']";
    public string divCopyFromBasketBall_Handicap = "//div[@id='e$2$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbBasketBall_MasterPreset_Handicap = "m3$2$1$0";
    public string cmbBasketBall_SuperPreset_Handicap = "s3$2$1$0";
    public string cmbBasketBall_AutoSuperPreset_Handicap = "us3$2$1$0";
    public string chkBasketBall_AutoSuperPreset_Handicap = "//input[@name='is3$2$1$0']";

    public string cmbBasketBall_MasterPreset_OverUnder = "m3$2$3$0";
    public string cmbBasketBall_SuperPreset_OverUnder = "s3$2$3$0";
    public string cmbBasketBall_AutoSuperPreset_OverUnder = "us3$2$3$0";
    public string chkBasketBall_AutoSuperPreset_OverUnder = "//input[@name='is3$2$3$0']";

    public string cmbBasketBall_MasterPreset_OddEven = "m3$2$2$0";
    public string cmbBasketBall_SuperPreset_OddEven = "s3$2$2$0";
    public string cmbBasketBall_AutoSuperPreset_OddEven = "us3$2$2$0";
    public string chkBasketBall_AutoSuperPreset_OddEven = "//input[@name='is3$2$2$0']";

    public string cmbBasketBall_MasterPreset_MoneyLine = "m3$2$20$0";
    public string cmbBasketBall_SuperPreset_MoneyLine = "s3$2$20$0";
    public string cmbBasketBall_AutoSuperPreset_MoneyLine = "us3$2$20$0";
    public string chkBasketBall_AutoSuperPreset_MoneyLine = "//input[@name='is3$2$20$0']";


    //Football
    public string divFootBallPTTitle = "//div[@class='PTSportLabel' and text()='Football']";
    public string divCopyFromFootBall_Handicap = "//div[@id='e$3$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbFootBall_MasterPreset_Handicap = "m3$3$1$0";
    public string cmbFootBall_SuperPreset_Handicap = "s3$3$1$0";
    public string cmbFootBall_AutoSuperPreset_Handicap = "us3$3$1$0";
    public string chkFootBall_AutoSuperPreset_Handicap = "//input[@name='is3$3$1$0']";

    public string cmbFootBall_MasterPreset_OverUnder = "m3$3$3$0";
    public string cmbFootBall_SuperPreset_OverUnder = "s3$3$3$0";
    public string cmbFootBall_AutoSuperPreset_OverUnder = "us3$3$3$0";
    public string chkFootBall_AutoSuperPreset_OverUnder = "//input[@name='is3$3$3$0']";

    public string cmbFootBall_MasterPreset_OddEven = "m3$3$2$0";
    public string cmbFootBall_SuperPreset_OddEven = "s3$3$2$0";
    public string cmbFootBall_AutoSuperPreset_OddEven = "us3$3$2$0";
    public string chkFootBall_AutoSuperPreset_OddEven = "//input[@name='is3$3$2$0']";

    public string cmbFootBall_MasterPreset_MoneyLine = "m3$3$20$0";
    public string cmbFootBall_SuperPreset_MoneyLine = "s3$3$20$0";
    public string cmbFootBall_AutoSuperPreset_MoneyLine = "us3$3$20$0";
    public string chkFootBall_AutoSuperPreset_MoneyLine = "//input[@name='is3$3$20$0']";

    //Tenis
    public string divTenisPTTitle = "//div[@class='PTSportLabel' and text()='Tennis']";
    public string divCopyFromTenis_Handicap = "//div[@id='e$5$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbTenis_MasterPreset_Handicap = "m3$5$1$0";
    public string cmbTenis_SuperPreset_Handicap = "s3$5$1$0";
    public string cmbTenis_AutoSuperPreset_Handicap = "us3$5$1$0";
    public string chkTenis_AutoSuperPreset_Handicap = "//input[@name='is3$5$1$0']";

    public string cmbTenis_MasterPreset_OverUnder = "m3$5$3$0";
    public string cmbTenis_SuperPreset_OverUnder = "s3$5$3$0";
    public string cmbTenis_AutoSuperPreset_OverUnder = "us3$5$3$0";
    public string chkTenis_AutoSuperPreset_OverUnder = "//input[@name='is3$5$3$0']";

    public string cmbTenis_MasterPreset_OddEven = "m3$5$2$0";
    public string cmbTenis_SuperPreset_OddEven = "s3$5$2$0";
    public string cmbTenis_AutoSuperPreset_OddEven = "us3$5$2$0";
    public string chkTenis_AutoSuperPreset_OddEven = "//input[@name='is3$5$2$0']";

    public string cmbTenis_MasterPreset_MoneyLine = "m3$5$20$0";
    public string cmbTenis_SuperPreset_MoneyLine = "s3$5$20$0";
    public string cmbTenis_AutoSuperPreset_MoneyLine = "us3$5$20$0";
    public string chkTenis_AutoSuperPreset_MoneyLine = "//input[@name='is3$5$20$0']";

    //BaseBall
    public string divBaseBallPTTitle = "//div[@class='PTSportLabel' and text()='Baseball']";
    public string divCopyFromBaseBall_Handicap = "//div[@id='e$8$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbBaseBall_MasterPreset_Handicap = "m3$8$1$0";
    public string cmbBaseBall_SuperPreset_Handicap = "s3$8$1$0";
    public string cmbBaseBall_AutoSuperPreset_Handicap = "us3$8$1$0";
    public string chkBaseBall_AutoSuperPreset_Handicap = "//input[@name='is3$8$1$0']";

    public string cmbBaseBall_MasterPreset_OverUnder = "m3$8$3$0";
    public string cmbBaseBall_SuperPreset_OverUnder = "s3$8$3$0";
    public string cmbBaseBall_AutoSuperPreset_OverUnder = "us3$8$3$0";
    public string chkBaseBall_AutoSuperPreset_OverUnder = "//input[@name='is3$8$3$0']";

    public string cmbBaseBall_MasterPreset_MoneyLine = "m3$8$20$0";
    public string cmbBaseBall_SuperPreset_MoneyLine = "s3$8$20$0";
    public string cmbBaseBall_AutoSuperPreset_MoneyLine = "us3$8$20$0";
    public string chkBaseBall_AutoSuperPreset_MoneyLine = "//input[@name='is3$8$20$0']";

    //Golf
    public string divGolfPTTitle = "//div[@class='PTSportLabel' and text()='Golf']";
    public string divCopyFromGolf_Handicap = "//div[@id='e$10$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbGolf_MasterPreset_Handicap = "m3$10$1$0";
    public string cmbGolf_SuperPreset_Handicap = "s3$10$1$0";
    public string cmbGolf_AutoSuperPreset_Handicap = "us3$10$1$0";
    public string chkGolf_AutoSuperPreset_Handicap = "//input[@name='is3$10$1$0']";

    public string cmbGolf_MasterPreset_OverUnder = "m3$10$3$0";
    public string cmbGolf_SuperPreset_OverUnder = "s3$10$3$0";
    public string cmbGolf_AutoSuperPreset_OverUnder = "us3$10$3$0";
    public string chkGolf_AutoSuperPreset_OverUnder = "//input[@name='is3$10$3$0']";

    public string cmbGolf_MasterPreset_OddEven = "m3$10$2$0";
    public string cmbGolf_SuperPreset_OddEven = "s3$10$2$0";
    public string cmbGolf_AutoSuperPreset_OddEven = "us3$10$2$0";
    public string chkGolf_AutoSuperPreset_OddEven = "//input[@name='is3$10$2$0']";

    public string cmbGolf_MasterPreset_MoneyLine = "m3$10$20$0";
    public string cmbGolf_SuperPreset_MoneyLine = "s3$10$20$0";
    public string cmbGolf_AutoSuperPreset_MoneyLine = "us3$10$20$0";
    public string chkGolf_AutoSuperPreset_MoneyLine = "//input[@name='is3$10$20$0']";

    //Motor Sports
    public string divMotorSportsPTTitle = "//div[@class='PTSportLabel' and text()='Motor Sports']";
    public string divCopyFromMotorSports_Handicap = "//div[@id='e$11$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbMotorSports_MasterPreset_Handicap = "m3$11$1$0";
    public string cmbMotorSports_SuperPreset_Handicap = "s3$11$1$0";
    public string cmbMotorSports_AutoSuperPreset_Handicap = "us3$11$1$0";
    public string chkMotorSports_AutoSuperPreset_Handicap = "//input[@name='is3$11$1$0']";

    public string cmbMotorSports_MasterPreset_MoneyLine = "m3$11$20$0";
    public string cmbMotorSports_SuperPreset_MoneyLine = "s3$11$20$0";
    public string cmbMotorSports_AutoSuperPreset_MoneyLine = "us3$11$20$0";
    public string chkMotorSports_AutoSuperPreset_MoneyLine = "//input[@name='is3$11$20$0']";

    //OtherSports
    public string divOtherSportsPTTitle = "//div[@class='PTSportLabel' and text()='Other Sports']";
    public string divCopyFromOtherSports_Handicap = "//div[@id='e$99$1$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbOtherSports_MasterPreset_Handicap = "m3$99$1$0";
    public string cmbOtherSports_SuperPreset_Handicap = "s3$99$1$0";
    public string cmbOtherSports_AutoSuperPreset_Handicap = "us3$99$1$0";
    public string chkOtherSports_AutoSuperPreset_Handicap = "//input[@name='is3$99$1$0']";

    public string cmbOtherSports_MasterPreset_OverUnder = "m3$99$3$0";
    public string cmbOtherSports_SuperPreset_OverUnder = "s3$99$3$0";
    public string cmbOtherSports_AutoSuperPreset_OverUnder = "us3$99$3$0";
    public string chkOtherSports_AutoSuperPreset_OverUnder = "//input[@name='is3$99$3$0']";

    public string cmbOtherSports_MasterPreset_OddEven = "m3$99$2$0";
    public string cmbOtherSports_SuperPreset_OddEven = "s3$99$2$0";
    public string cmbOtherSports_AutoSuperPreset_OddEven = "us3$99$2$0";
    public string chkOtherSports_AutoSuperPreset_OddEven = "//input[@name='is3$99$2$0']";

    public string cmbOtherSports_MasterPreset_MoneyLine = "m3$99$20$0";
    public string cmbOtherSports_SuperPreset_MoneyLine = "s3$99$20$0";
    public string cmbOtherSports_AutoSuperPreset_MoneyLine = "us3$99$20$0";
    public string chkOtherSports_AutoSuperPreset_MoneyLine = "//input[@name='is3$99$20$0']";

    //Mix Sports Parlay
    public string divMixSportsParlayPTTitle = "//div[@class='PTSportLabel' and text()='Mix Sports Parlay']";

    public string cmbMixSportsParlay_MasterPreset_MixParlay = "m3$99$9$0";
    public string cmbMixSportsParlay_SuperPreset_MixParlay = "s3$99$9$0";
    public string cmbMixSportsParlay_AutoSuperPreset_MixParlay = "us3$99$9$0";
    public string chkMixSportsParlay_AutoSuperPreset_MixParlay = "//input[@name='is3$99$9$0']";


    //Number Game
    public string divNumberGamePTTitle = "//div[@class='PTSportLabel' and text()='Number Game']";
    public string divCopyFromNumberGame_DeadBall_1stLastOverUnder = "//div[@id='e$161$81$0']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"
    public string divCopyFromNumberGame_LiveBall_OverUnder = "//div[@id='e$161$85$1']/div";//Class normal="BetTypeHeader2"; Class Active = "BetTypeHeaderActive"

    public string cmbNumberGame_DeadBall_MasterPreset_1stLastOverUnder = "m3$161$81$0";
    public string cmbNumberGame_DeadBall_SuperPreset_1stLastOverUnder = "s3$161$81$0";
    public string cmbNumberGame_DeadBall_AutoSuperPreset_1stLastOverUnder = "us3$161$81$0";
    public string chkNumberGame_DeadBall_AutoSuperPreset_1stLastOverUnder = "//input[@name='is3$161$81$0']";

    public string cmbNumberGame_DeadBall_MasterPreset_1stLastOddEven = "m3$161$83$0";
    public string cmbNumberGame_DeadBall_SuperPreset_1stLastOddEven = "s3$161$83$0";
    public string cmbNumberGame_DeadBall_AutoSuperPreset_1stLastOddEven = "us3$161$83$0";
    public string chkNumberGame_DeadBall_AutoSuperPreset_1stLastOddEven = "//input[@name='is3$161$83$0']";

    public string cmbNumberGame_DeadBall_MasterPreset_Warrior = "m3$161$88$0";
    public string cmbNumberGame_DeadBall_SuperPreset_Warrior = "s3$161$88$0";
    public string cmbNumberGame_DeadBall_AutoSuperPreset_Warrior = "is3$161$88$0";
    public string chkNumberGame_DeadBall_AutoSuperPreset_Warrior = "//input[@name='us3$161$88$0']";

    public string cmbNumberGame_DeadBall_MasterPreset_OddEven = "m3$161$86$0";
    public string cmbNumberGame_DeadBall_SuperPreset_OddEven = "s3$161$86$0";
    public string cmbNumberGame_DeadBall_AutoSuperPreset_OddEven = "us3$161$86$0";
    public string chkNumberGame_DeadBall_AutoSuperPreset_OddEven = "//input[@name='is3$161$86$0']";

    public string cmbNumberGame_LiveBall_MasterPreset_OverUnder = "m3$161$85$1";
    public string cmbNumberGame_LiveBall_SuperPreset_OverUnder = "s3$161$85$1";
    public string cmbNumberGame_LiveBall_AutoSuperPreset_OverUnder = "us3$161$85$1";
    public string chkNumberGame_LiveBall_AutoSuperPreset_OverUnder = "//input[@name='is3$161$85$1']";

    public string cmbNumberGame_LiveBall_MasterPreset_OddEven = "m3$161$86$1";
    public string cmbNumberGame_LiveBall_SuperPreset_OddEven = "s3$161$86$1";
    public string cmbNumberGame_LiveBall_AutoSuperPreset_OddEven = "us3$161$86$1";
    public string chkNumberGame_LiveBall_AutoSuperPreset_OddEven = "//input[@name='is3$161$86$1']";

    public string cmbNumberGame_LiveBall_MasterPreset_HighLow = "m3$161$87$1";
    public string cmbNumberGame_LiveBall_SuperPreset_HighLow = "s3$1$7$1";
    public string cmbNumberGame_LiveBall_AutoSuperPreset_HighLow = "us3$1$7$1";
    public string chkNumberGame_LiveBall_AutoSuperPreset_HighLow = "//input[@name='is3$161$87$1']";

    public string cmbNumberGame_LiveBall_MasterPreset_NextCombo = "m3$161$89$1";
    public string cmbNumberGame_LiveBall_SuperPreset_NextCombo = "s3$161$89$1";
    public string cmbNumberGame_LiveBall_AutoSuperPreset_NextCombo = "us3$161$89$1";
    public string chkNumberGame_LiveBall_AutoSuperPreset_NextCombo = "//input[@name='is3$161$89$1']";

    public string cmbNumberGame_LiveBall_MasterPreset_NumberWheel = "m3$161$90$1";
    public string cmbNumberGame_LiveBall_SuperPreset_NumberWheel = "s3$161$90$1";
    public string cmbNumberGame_LiveBall_AutoSuperPreset_NumberWheel = "us3$161$90$1";
    public string chkNumberGame_LiveBall_AutoSuperPreset_NumberWheel = "//input[@name='is3$161$90$1']";

    //public string txtSoccerMaxPerMatch = "xpath=(//input[@type='text'])[9]";
}

