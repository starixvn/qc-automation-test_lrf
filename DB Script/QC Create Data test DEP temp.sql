CREATE PROCEDURE QC_Create_Data_test_DEP_temp                     
AS                        
--CREATE PROCEDURE [QC_Create_Data_test]                         
--AS                        
                        
/*                        
Created: 20150422@Harris                        
Task :                         
DB: DB206.bodb02                        
Original:                         
Revisions:                        
                         
Step:                        
1. Delete old Data                        
2. Insert match (dbo.match, dbo.outright)                        
3. Insert odds                        
4. Insert SB tickets. Start of @transid = 9499000000                        
5. Insert Mix parlay tickets. Start of @transid = 9499090000 , @transid_m = 960900000                        
6. Insert System Parlay tickets. Start of @transid = 9499290000 , @transid_m = 962900000                        
7. Insert Racing tickets. Start of @transid = 9499330000 , @transid_m = 963300000                        
                        
*/                        
SET NOCOUNT ON                        
                        
                        
---- DECLARE SECTION                        
DECLARE @bettype  INT                        
  ,@betteam  VARCHAR(10)                        
  ,@username Varchar(50) = 'SPONUUS01017'                        
  ,@matchid BIGINT  = 71000000                        
  ,@transid BIGINT  = 9499000000                        
  ,@transid_m BIGINT  = 960000000                        
  ,@sporttype INT                        
  ,@errcode INT                        
  ,@errmsg NVARCHAR (200)                        
  ,@oddsid INT   = 81000000                        
  ,@max_matchid bigint                        
  ,@min_matchid bigint                        
  ,@winlostdate date                        
  ,@refno bigint                        
  ,@orid int                        
  ,@VSorid int                        
Select @winlostdate = Cast(GETDATE() as Date)                        
DECLARE @bettype_TABLE TABLE(                        
  transid bigint, sporttype INT, bettype SMALLINT, betteam VARCHAR(20),liveindicator bit, livehomescore int, liveawayscore int,hdp1 money, hdp2 money, oddstype int, status VARCHAR(10),         
  statusID TINYINT, ruben TINYINT, betcheck VARCHAR(50), betid BIGINT, transdesc NVARCHAR(1000))            
            
Declare @parlaydetail TABLE (serial int, sporttype int)                        
                        
Declare @custid bigint, @recommend bigint, @mrecommend bigint, @srecommend bigint                        
Select @custid = custid, @recommend = recommend, @mrecommend = mrecommend, @srecommend= srecommend                        
from CustInfo with (nolock) where username = @username                        
-- Delete old data                        
                        
delete from bettrans where transid between @transid and @transid + 100000000               
delete from bettransRnG where transid between @transid and @transid + 100000000               
delete from translog where translogid between @transid and @transid + 100000000                       
Delete from bettransm where transid between @transid_m and @transid_m +  10000000 --and username =@username                        
    
--delete from [DB215].[bodb02].[dbo].[bettrans] where transid between @transid and @transid + 100000000               
--delete from [DB215].[bodb02].[dbo].[bettransRnG] where transid between @transid and @transid + 100000000               
--delete from [DB215].[bodb02].[dbo].[translog] where translogid between @transid and @transid + 100000000               
delete from [DB215].[bodb02].[dbo].[bettrans_lrf_betRunning] where transid between @transid and @transid + 100000000                        
delete from [DB215].[bodb02].[dbo].[bettrans_Running] where transid between @transid and @transid + 100000000    
    
delete from [DB234].[bodb02].[dbo].[bettrans] WHERE transid between @transid and @transid + 100000000            
delete from [DB234].[bodb02].[dbo].[bettransRnG] WHERE transid between @transid and @transid + 100000000          
delete from [DB234].[bodb02].[dbo].[translog] WHERE translogid between @transid and @transid + 100000000          
              
DECLARE @isloop tinyint = 1                          
DECLARE @cnt int                        
                        
/****INSERT MATCH******/                        
EXEC [QC_create_match] @matchid = @matchid, @sport = '',@isDep = 1, @max_matchid = @max_matchid Output, @min_matchid = @min_matchid output,@orid = @orid output,@vsorid = @vsorid output, @eventstatus = 'completed'                        
/****END INSERT MATCH******/                        
                  
/****INSERT RUNNING SOCCER MATCH******/                       
--Delete if already existed                    
DELETE FROM match where matchid='71000050'                    
SET IDENTITY_INSERT [dbo].[match] ON                      
  INSERT INTO match ([matchid],[leagueid],[homeid],[awayid],[eventdate],[eventstatus],[betstatus],[livehomescore],[liveawayscore],[finalhomescore],[finalawayscore],[creator],[matchcode],                      
  [kickofftime],[closedtime],[showtime],[hthomescore],[htawayscore],[ruben],[multiple],[yenbet],[exrisk],[sporttype],[tstamp],[homeid2],[awayid2],[DisplayMode],[LeaguePatternID],[HomeDisplayPatternID],                    
  [AwayDisplayPatternID],[IsNeutral],[InjuryTime],[GoalRecord],[ParentID],[ChildMatchType],[GlobalShowTime],[HasLive],[changetime],[settletime])                        
  Values( '71000050', '43','111', '22', CAST(GETDATE() AS DATE),'running',                      
  ' ', NULL,NULL,NULL,NULL, 8,'QCTEST',CAST(GETDATE() AS DATE),NULL,Null,                     
    NULL,NULL,0,0,null, null, 1,null, 0,0,0,0,0,0,1,0,NULL,0,0,0,0,0,0)                      
SET IDENTITY_INSERT [dbo].[match] OFF                  
/**** END INSERT RUNNING SOCCER MATCH******/                    
                  
/***INSERT RUNNING OURIGHT MATCH***/                  
DELETE FROM outright where outright.orid='71000051'                  
SET IDENTITY_INSERT [dbo].[outright] ON                     
INSERT INTO [dbo].[outright] (orid,leagueid,teamid,eventdate,kickofftime,oddsstatus,odds,maxbet,gapodds,matchcode,groupmatch,status,creator,bal,risk,DisplayMode,changetime,LeaguePatternID,TeamPatternID)                  
values('71000051','43','111',GETDATE(),GETDATE(),'running','2.5','1000','0.10','QCTEST',NULL,NULL,8,'532','700',0,GETDATE(),0,0)                  
SET IDENTITY_INSERT [dbo].[outright] OFF                     
/*** END INSERT RUNNING OURIGHT MATCH***/               
          
/****INSERT MUAY THAI MATCH******/                   
                
--Delete if already existed                
DELETE FROM match where matchid='71000052'                
DELETE FROM match where matchid='71000053'                
                
SET IDENTITY_INSERT [dbo].[match] ON                  
                  
  INSERT INTO match ([matchid],[leagueid],[homeid],[awayid],[eventdate],[eventstatus],[betstatus],[livehomescore],[liveawayscore],[finalhomescore],[finalawayscore],[creator],[matchcode],                  
  [kickofftime],[closedtime],[showtime],[hthomescore],[htawayscore],[ruben],[multiple],[yenbet],[exrisk],[sporttype],[tstamp],[homeid2],[awayid2],[DisplayMode],[LeaguePatternID],[HomeDisplayPatternID],                
  [AwayDisplayPatternID],[IsNeutral],[InjuryTime],[GoalRecord],[ParentID],[ChildMatchType],[GlobalShowTime],[HasLive],[changetime],[settletime])                    
  Values( '71000052',                  
  '50759','320048', '320049', CAST(GETDATE() AS DATE),'completed',                  
  '1', NULL,NULL,'1','0', 8,'QCTEST',CAST(GETDATE() AS DATE),NULL,Null,                 
    NULL,NULL,0,0,null, null, 44,null, 0,0,0,0,0,0,1,0,NULL,0,0,0,0,0,CAST(GETDATE() AS DATE))                  
                
  INSERT INTO match ([matchid],[leagueid],[homeid],[awayid],[eventdate],[eventstatus],[betstatus],[livehomescore],[liveawayscore],[finalhomescore],[finalawayscore],[creator],[matchcode],                  
  [kickofftime],[closedtime],[showtime],[hthomescore],[htawayscore],[ruben],[multiple],[yenbet],[exrisk],[sporttype],[tstamp],[homeid2],[awayid2],[DisplayMode],[LeaguePatternID],[HomeDisplayPatternID],                
  [AwayDisplayPatternID],[IsNeutral],[InjuryTime],[GoalRecord],[ParentID],[ChildMatchType],[GlobalShowTime],[HasLive],[changetime],[settletime])                    
  Values( '71000053',                  
  '50759','320048', '320049', CAST(GETDATE() AS DATE),'running',                  
  ' ', NULL,NULL,NULL,NULL, 8,'QCTEST',CAST(GETDATE() AS DATE),NULL,Null,                 
    NULL,NULL,0,0,null, null, 44,null, 0,0,0,0,0,0,1,0,NULL,0,0,0,0,0,0)                  
                    
SET IDENTITY_INSERT [dbo].[match] OFF                
                
/**** END INSERT MUAY THAI MATCH******/               
          
/***INSERT CRICKET MATCH***/                  
DELETE FROM match where matchid='71000054'                    
SET IDENTITY_INSERT [dbo].[match] ON                      
  INSERT INTO match ([matchid],[leagueid],[homeid],[awayid],[eventdate],[eventstatus],[betstatus],[livehomescore],[liveawayscore],[finalhomescore],[finalawayscore],[creator],[matchcode],                      
  [kickofftime],[closedtime],[showtime],[hthomescore],[htawayscore],[ruben],[multiple],[yenbet],[exrisk],[sporttype],[tstamp],[homeid2],[awayid2],[DisplayMode],[LeaguePatternID],[HomeDisplayPatternID],                    
  [AwayDisplayPatternID],[IsNeutral],[InjuryTime],[GoalRecord],[ParentID],[ChildMatchType],[GlobalShowTime],[HasLive],[changetime],[settletime])                        
  Values( '71000054', '43','111', '22', CAST(GETDATE() AS DATE),'completed',                      
  ' ', NULL,NULL,1,1, 8,'QCTEST',CAST(GETDATE() AS DATE),NULL,Null,                     
    NULL,NULL,1,0,null, null, 50,null, 0,0,0,0,0,0,1,0,NULL,0,0,0,0,0,0)                      
SET IDENTITY_INSERT [dbo].[match] OFF                       
/*** END INSERT CRICKET MATCH***/             
          
/***INSERT RUNNING CRICKET MATCH***/                  
DELETE FROM match where matchid='71000055'                    
SET IDENTITY_INSERT [dbo].[match] ON                      
  INSERT INTO match ([matchid],[leagueid],[homeid],[awayid],[eventdate],[eventstatus],[betstatus],[livehomescore],[liveawayscore],[finalhomescore],[finalawayscore],[creator],[matchcode],                      
  [kickofftime],[closedtime],[showtime],[hthomescore],[htawayscore],[ruben],[multiple],[yenbet],[exrisk],[sporttype],[tstamp],[homeid2],[awayid2],[DisplayMode],[LeaguePatternID],[HomeDisplayPatternID],                    
  [AwayDisplayPatternID],[IsNeutral],[InjuryTime],[GoalRecord],[ParentID],[ChildMatchType],[GlobalShowTime],[HasLive],[changetime],[settletime])                        
  Values( '71000055', '43','111', '22', CAST(GETDATE() AS DATE),'running',                      
  ' ', NULL,NULL,NULL,NULL, 8,'QCTEST',CAST(GETDATE() AS DATE),NULL,Null,                     
    NULL,NULL,0,0,null, null, 50,null, 0,0,0,0,0,0,1,0,NULL,0,0,0,0,0,0)                      
SET IDENTITY_INSERT [dbo].[match] OFF                         
/*** END INSERT RUNNING CRICKET MATCH***/                  
                  
/****INSERT ODDS******/                        
DECLARE @odds_table TABLE (sporttype int, bettype int)                        
INSERT INTO @odds_table                        
Select distinct sporttype, bettype from @bettype_TABLE                        
                  
DELETE FROM odds where matchid between @min_matchid and @max_matchid                     
                  
INSERT INTO Odds (matchid, bettype, hdp1, hdp2, odds1a, odds2a, oddsstatus, liveindicator, creator,sporttype)                        
SELECT m.matchid, bettype, 0, 0, 0, 0, 'Closed', 0,8,m.sporttype                        
FROM @odds_table o                        
join match m with (nolock) on m.sporttype = o.sporttype                
where m.matchid between @min_matchid and @max_matchid                  
                    
DELETE FROM odds where matchid='71000050'                  
                  
INSERT INTO Odds (matchid, bettype, hdp1, hdp2, odds1a, odds2a, oddsstatus, liveindicator, creator,sporttype)                        
VALUES ('71000050','1',0,0,0,0,'running',0,8,'1') -- insert odds for running soccer match                  
                  
--select * from odds with (nolock) where oddsid >= 80000000                        
/****END INSERT ODDS******/                        
                        
--Insert into @parlaydetail                        
--Values (3020001,1),(3020001,5)                        
--  ,(3020002,5),(3020002,10)                        
--  ,(3020003,1),(3020003,10)                        
--  ,(3030001,1),(3030001,5),(3030001,10)       
--Delete from BetParlayDetail                        
--where matchid in                        
-- (select matchid from match m join @parlaydetail p on m.sporttype = p.sporttype where matchid between @min_matchid and @max_matchid )                        
    
/****INSERT SB TICKET******/                        
INSERT INTO @bettype_TABLE                        
select  TransID,sporttype,bettype,betteam,liveindicator,livehomescore,liveawayscore,hdp1,hdp2,oddstype,status,statusID,ruben,betcheck,betid,Transdesc from QC_data_test_DEP qc with (nolock)                          
where qc.sporttype not in (203, 205)  -- get all SB tickets except MGC    
        
select @cnt = count (*) from @bettype_TABLE         
    
Set @isloop = 1                        
WHILE @isloop > 0                        
 BEGIN                        
                         
 SELECT top 1 @transid = transid                         
 FROM @bettype_TABLE                        
                        
 SET IDENTITY_INSERT [dbo].[bettrans] ON                        
    INSERT INTO Bettrans                         
    (transid,                        
    custid,transdate, oddsid,hdp1,hdp2, odds,stake,status, winlost,awinlost,mwinlost,playercomm,comm,acomm,apositiontaking,mpositiontaking,          
    tpositiontaking,playerdiscount,discount,adiscount,livehomescore,liveawayscore, liveindicator,betteam, creator, refno,comstatus,winlostdate,           
    betfrom, betcheck, checktime, oddsspread, actualrate, matchid, recommEND, mrecommEND, ruben, betid,statuswinlost, modds,bettype, betdaqid,           
    tstamp, actual_stake, currency, IP, transdesc, sdiscount, scomm, spositiontaking,swinlost,          
    srecommEND,Username, CurrencyName, virtualrate, oddstype, statusID,currency2,balance, SecAcceptFlag, transid2,RecommDate)                        
    SELECT top 1                        
      transid = bt.transid ,                        
      [custid] = @custid -- SPONUUS01017                        
       ,[transdate] = getdate()                        
       ,[oddsid] = o.oddsID                        
       ,[hdp1] = bt.hdp1                      
       ,[hdp2] = bt.hdp2                        
       ,[odds] = 2.5                        
       ,[stake] = 100                        
       ,[status] = bt.status                       
       ,[winlost] = 0                        
       ,[awinlost] =40                        
       ,[mwinlost] = 30                        
       ,[playercomm] = 0.5                        
       ,[comm] =0.2                         
       ,[acomm]= 0.15                        
       ,[apositiontaking] = 0.4                        
       ,[mpositiontaking] = 0.3                        
       ,[tpositiontaking] = 0.9                        
       ,[playerdiscount] = 0.005                        
       ,[discount] = 0.005                        
       ,[adiscount] = 0.005                        
       ,[livehomescore] = ISNULL(bt.livehomescore,0)                        
       ,[liveawayscore] = ISNULL(bt.liveawayscore,0)                        
       ,[liveindicator] = bt.liveindicator                      
       ,[betteam] = bt.betteam                        
       ,[creator] = 8 -- sa                        
       ,[refno] = 100000000000                      
       ,[comstatus] = 0                        
       ,[winlostdate] = @winlostdate                        
       ,[betfrom] = 'a'                        
       ,[betcheck] = bt.betcheck                         
       ,[checktime] = Null                        
       ,[oddsspread] = 0                        
       ,[actualrate] = 0                       
       ,[matchid] = CASE WHEN bt.sporttype=1 and bt.bettype NOT IN (10) and bt.statusID='0' THEN 71000050 -- soccer running match                  
       WHEN bt.bettype=10 and bt.statusID='0' THEN  71000051 -- ouright running match                
       WHEN bt.ruben=1 and bt.sporttype=44 THEN 71000052 -- Muay Thai                
       WHEN bt.ruben=0 and bt.sporttype=44 THEN 71000053 -- running Muay Thai          
       WHEN bt.ruben=1 and bt.sporttype=50 THEN 71000054 -- Cricket               
       WHEN bt.ruben=0 and bt.sporttype=50 THEN 71000055 -- running Cricket                   
       ELSE m.matchid END                      
       ,[recommEND] = @recommend -- agent                        
       ,[mrecommEND] = @mrecommend --master                        
       ,[ruben] = bt.ruben                        
       ,[betid] = CASE WHEN bt.sporttype = 161 then bt.betid -- Number game                        
          WHEN bt.sporttype = 5 AND bt.bettype  = 1324 then 80305 -- Tennis set 3 game 5 winner                        
          WHEN bt.sporttype = 5 AND bt.bettype  <> 1324 then 803 -- Tennis set 3                        
          ELSE 0 END                         
       ,[statuswinlost] = null                        
       ,[modds] = -1                        
       ,[bettype] = bt.bettype                        
       ,[betdaqid] = -1                        
       ,[tstamp] = null                        
       ,[actual_stake] = 100                        
       ,[currency] = 20                   
       ,[ip] = '127.0.0.1'                        
       ,[transdesc] = bt.Transdesc                     
       ,[sdiscount] = 0.005                        
       ,[scomm] = 0.1                        
       ,[spositiontaking] = 0.1                        
       ,[swinlost] = 10                        
   ,[srecommEND] = @srecommend                        
       ,[Username] = @username                        
       ,[CurrencyName] = 'UUS'                        
       ,[virtualrate] = '1'                        
       ,[oddstype] = bt.oddstype                        
       ,[statusID] = bt.statusID                      
       ,[currency2] = null                        
       ,[balance] = 1000000                        
       ,[SecAcceptFlag] = 1                        
       ,[transid2] = 0                        
       ,[RecommDate] = null                  
                        
    FROM @bettype_TABLE bt                        
    join odds o with (nolock) on bt.bettype = o.bettype                        
    join match m with (nolock) on bt.sporttype = m.sporttype                        
    where transid = @transid                        
    and m.matchid between @min_matchid and @max_matchid         
    and bt.sporttype not in (203, 205)  -- get all tickets except MGC    
                            
    SET IDENTITY_INSERT [dbo].[bettrans] OFF                        
                           
    DELETE FROM @bettype_TABLE                        
    where transid = @transid                        
                            
    --select @transid = @transid +1                           
                                
    IF NOT EXISTS (select top 1 * from @bettype_TABLE)                        
     set @isloop = 0                        
                            
                            
 END                        
/****END INSERT SB TICKET******/                        
    
/****INSERT MICROGAMING TICKET INTO BETTRANS******/               
INSERT INTO @bettype_TABLE                        
select  TransID,sporttype,bettype,betteam,liveindicator,livehomescore,liveawayscore,hdp1,hdp2,oddstype,status,statusID,ruben,betcheck,betid,Transdesc from QC_data_test_DEP qc with (nolock)                          
where (qc.sporttype in (203) and qc.statusID != '0')   -- exclude running MGC LC                 
    or (qc.sporttype in (205) and qc.betcheck='SUM') -- get ticket sum of MGC RNG    
        
Set @isloop = 1                        
WHILE @isloop > 0                        
 BEGIN                        
                         
 SELECT top 1 @transid = transid                         
 FROM @bettype_TABLE                        
                        
 SET IDENTITY_INSERT [dbo].[bettrans] ON                        
    INSERT INTO Bettrans                         
    (transid,                        
    custid,transdate, oddsid,hdp1,hdp2, odds,stake,status, winlost,awinlost,mwinlost,playercomm,comm,acomm,apositiontaking,mpositiontaking,          
    tpositiontaking,playerdiscount,discount,adiscount,livehomescore,liveawayscore, liveindicator,betteam, creator, refno,comstatus,winlostdate,           
    betfrom, betcheck, checktime, oddsspread, actualrate, matchid, recommEND, mrecommEND, ruben, betid,statuswinlost, modds,bettype, betdaqid,           
    tstamp, actual_stake, currency, IP, transdesc, sdiscount, scomm, spositiontaking,swinlost,          
    srecommEND,Username, CurrencyName, virtualrate, oddstype, statusID,currency2,balance, SecAcceptFlag, transid2,RecommDate)                        
    SELECT top 1                        
      transid = bt.transid ,                        
      [custid] = @custid -- SPONUUS01017                        
       ,[transdate] = getdate()                        
       ,[oddsid] = '0'                        
       ,[hdp1] = bt.hdp1                      
       ,[hdp2] = bt.hdp2                        
       ,[odds] = 2.5                        
       ,[stake] = 100                        
       ,[status] = bt.status                       
       ,[winlost] = 0                        
       ,[awinlost] =40                        
       ,[mwinlost] = 30                        
       ,[playercomm] = 0.5                        
       ,[comm] =0.2                         
       ,[acomm]= 0.15                        
       ,[apositiontaking] = 0.4                        
       ,[mpositiontaking] = 0.3                        
       ,[tpositiontaking] = 0.9                        
       ,[playerdiscount] = 0.005                        
       ,[discount] = 0.005                        
       ,[adiscount] = 0.005                        
       ,[livehomescore] = ISNULL(bt.livehomescore,0)                        
       ,[liveawayscore] = ISNULL(bt.liveawayscore,0)                        
       ,[liveindicator] = bt.liveindicator                      
       ,[betteam] = bt.betteam                        
       ,[creator] = 8 -- sa                        
       ,[refno] = CASE WHEN bt.sporttype in (203) THEN bt.transid ELSE 0 END                      
       ,[comstatus] = 0                        
       ,[winlostdate] = @winlostdate                        
       ,[betfrom] = 'a'                        
       ,[betcheck] = bt.betcheck                         
       ,[checktime] = Null                        
       ,[oddsspread] = 0                        
       ,[actualrate] = 0                        
       ,[matchid] = bt.sporttype                   
       ,[recommEND] = @recommend -- agent                        
       ,[mrecommEND] = @mrecommend --master                        
       ,[ruben] = bt.ruben                        
       ,[betid] = 0                     
       ,[statuswinlost] = null                        
       ,[modds] = -1                        
       ,[bettype] = bt.bettype                        
       ,[betdaqid] = -1                        
       ,[tstamp] = null                        
       ,[actual_stake] = 100                        
       ,[currency] = 20                   
       ,[ip] = '127.0.0.1'                        
       ,[transdesc] = bt.Transdesc                     
       ,[sdiscount] = 0.005                        
       ,[scomm] = 0.1                        
       ,[spositiontaking] = 0.1                        
       ,[swinlost] = 10                        
   ,[srecommEND] = @srecommend                        
       ,[Username] = @username                        
       ,[CurrencyName] = 'UUS'                        
       ,[virtualrate] = '1'                        
       ,[oddstype] = bt.oddstype                        
       ,[statusID] = bt.statusID                      
       ,[currency2] = null                        
       ,[balance] = 1000000                        
       ,[SecAcceptFlag] = 1                        
       ,[transid2] = 0                        
       ,[RecommDate] = null                  
                        
    FROM @bettype_TABLE bt                        
    where (bt.sporttype in (203) and bt.statusID != '0')   -- get settle ticket of MGC LC                 
    or (bt.sporttype in (205) and bt.betcheck='SUM') -- get ticket sum of MGC RNG        
                            
    SET IDENTITY_INSERT [dbo].[bettrans] OFF                        
                           
    DELETE FROM @bettype_TABLE                        
    where transid = @transid                        
                            
    --select @transid = @transid +1                           
                                
    IF NOT EXISTS (select top 1 * from @bettype_TABLE)                        
     set @isloop = 0                        
                            
                            
 END                        
/****END INSERT MICROGAMING TICKET INTO BETTRANS******/                
                  
/*** INSERT RUNNING MICROGAMING LC TICKET INTO TRANSLOG ***/                  
INSERT INTO @bettype_TABLE                        
select  TransID,sporttype,bettype,betteam,liveindicator,livehomescore,liveawayscore,hdp1,hdp2,oddstype,status,statusID,ruben,betcheck,betid,qc.Transdesc from QC_data_test_DEP qc with (nolock)                          
Where qc.bettype in (2001,2002,2003,2004,2005,2006,2007) and qc.statusID='0'                   
    
Set @isloop = 1                        
WHILE @isloop > 0                        
 BEGIN                        
                         
 SELECT top 1 @transid = transid                         
 FROM @bettype_TABLE                  
                        
 SET IDENTITY_INSERT [dbo].[translog] ON                        
    INSERT INTO translog                         
    (translogid, custid, transdate, odds, stake, status, apositiontaking, mpositiontaking, tpositiontaking,                   
spositiontaking, playerdiscount, discount, adiscount, sdiscount, creator, winlostdate, betfrom, virtualrate,                   
actualrate,actual_stake, currency, CurrencyName, recommend, mrecommend, srecommend, ip, statusID, balance,                   
Username, transdesc, productID, gameID, eventID, vendorID, Gameid3rd, Tranid3rd, custom1, liveindicator, custom2,                   
custom3)                  
 SELECT top 1                        
      [translogid] = bt.transid         
    ,[custid] = @custid -- SPONUUS01017                        
       ,[transdate] = getdate()                        
       ,[odds] = 0                        
       ,[stake] = 100                        
       ,[status] = bt.status                    
       ,[apositiontaking] = 0.00                        
       ,[mpositiontaking] = 0.00                        
       ,[tpositiontaking] = 0.00                    
       ,[spositiontaking] = 0.00                  
       ,playerdiscount = 0                  
    ,discount = 0                  
       ,adiscount = 0                  
       ,sdiscount = 0                  
       ,creator = @custid                  
       ,winlostdate = getdate()                  
       ,betfrom = 'a'                            
       ,virtualrate = 2E-102                  
       ,actualrate = 2E-102                  
       ,actual_stake = 100.00                  
       ,currency = 20                  
       ,CurrencyName = 'UUS'                  
       ,recommend = @recommend                  
       ,mrecommend = @mrecommend                  
       ,srecommend = @srecommend                  
       ,ip = '127.0.0.1'                  
       ,statusID = bt.statusID                  
       ,balance = 1000.00                         
       ,Username = @username                  
       ,transdesc = 'MicroGaming QC DEP test'          
       ,productID = bt.sporttype                  
       ,gameID = bt.bettype                  
       ,eventID = 1207571                  
       ,vendorID = 1                  
       ,Gameid3rd = NULL                  
       ,Tranid3rd = NULL                  
       ,custom1 = NULL                  
       ,liveindicator = NULL                  
       ,custom2 = NULL                  
       ,custom3 = NULL                  
    FROM @bettype_TABLE bt                  
    Where bt.bettype in (2001,2002,2003,2004,2005,2006,2007) and bt.statusID='0'                            
    SET IDENTITY_INSERT [dbo].[translog] OFF                        
                           
    DELETE FROM @bettype_TABLE                        
    where transid = @transid                        
                            
    --select @transid = @transid +1                           
                                
    IF NOT EXISTS (select top 1 * from @bettype_TABLE)                   
     set @isloop = 0                        
                            
 END                        
/*** END INSERT RUNNING MICROGAMING LC TICKET INTO TRANSLOG ***/                  
        
/*** INSERT MICROGAMING RNG TICKET INTO BETTRANSRNG***/                  
INSERT INTO @bettype_TABLE                        
select  TransID,sporttype,bettype,betteam,liveindicator,livehomescore,liveawayscore,hdp1,hdp2,oddstype,status,statusID,ruben,betcheck,betid,qc.Transdesc from QC_data_test_DEP qc with (nolock)                          
Where qc.bettype in (2009) and qc.BetCheck='DETAIL'        
    
Set @isloop = 1                        
WHILE @isloop > 0                        
 BEGIN                        
                         
 SELECT top 1 @transid = transid                         
 FROM @bettype_TABLE                  
                        
 SET IDENTITY_INSERT [dbo].[bettransRnG] ON                        
    INSERT INTO [bettransRnG]                         
    ([transid],[custid], [transdate], [odds], [stake], [status], [apositiontaking], [mpositiontaking], [tpositiontaking], [spositiontaking]        
   , [playerdiscount], [discount], [adiscount], [sdiscount], [creator], [winlostdate], [betfrom], [virtualrate], [actualrate], [actual_stake], [currency]        
   , [CurrencyName], [recommend], [mrecommend], [srecommend], [ip], [statusID], [balance], [Username], [transdesc], [productID], [gameID], [vendorID]        
   , [GameId3rd], [TranId3rd], [RefNo], [IsSum], [winlost], [awinlost], [mwinlost], [swinlost], [playercomm], [comm], [acomm], [scomm], [Transdate3rd])                 
 SELECT top 1                        
      [transid] = bt.transid                   
    ,[custid] = @custid -- SPONUUS01017                        
       ,[transdate] = getdate()                        
       ,[odds] = 0                        
       ,[stake] = 100                        
       ,[status] = bt.status                    
       ,[apositiontaking] = 0.00                
       ,[mpositiontaking] = 0.00                        
       ,[tpositiontaking] = 0.00                    
       ,[spositiontaking] = 0.00                  
       ,playerdiscount = 0                  
    ,discount = 0                  
       ,adiscount = 0                  
       ,sdiscount = 0                  
       ,creator = @custid                  
       ,winlostdate = getdate()                  
       ,betfrom = 'a'                            
       ,virtualrate = 2E-102                  
       ,actualrate = 2E-102                  
       ,actual_stake = 100.00                  
       ,currency = 20                  
       ,CurrencyName = 'UUS'                  
       ,recommend = @recommend                  
       ,mrecommend = @mrecommend                  
       ,srecommend = @srecommend                  
       ,ip = '127.0.0.1'                  
       ,statusID = bt.statusID                  
       ,balance = 1000.00                         
       ,Username = @username                  
       ,transdesc = bt.transdesc                 
       ,productID = bt.sporttype             
       ,gameID = bt.bettype        
       ,vendorID = 3                  
,Gameid3rd = 'Football Star'                  
       ,Tranid3rd = 337                  
       ,RefNo = 9499000780        
       ,IsSum = CASE WHEN bt.statusID=0 THEN 0 ELSE 1 END         
       ,winlost = 0        
       ,awinlost= 0        
       ,mwinlost= 0        
       ,swinlost= 0        
       ,playercomm= 0        
       ,comm= 0        
       ,acomm= 0        
       ,scomm= 0        
       ,Transdate3rd= getdate()                 
    FROM @bettype_TABLE bt                  
    Where bt.bettype in (2009) and bt.BetCheck='DETAIL'                            
    SET IDENTITY_INSERT [dbo].[bettransRnG] OFF                        
                           
    DELETE FROM @bettype_TABLE                        
    where transid = @transid                        
                            
    --select @transid = @transid +1                           
                                
    IF NOT EXISTS (select top 1 * from @bettype_TABLE)                   
     set @isloop = 0                        
                            
 END                        
/*** END INSERT MICROGAMING RNG TICKET INTO BETTRANS RNG ***/         
        
/*** INSERT MIX PARLAY ***/                        
/*                      
BEGIN                      
SET @transid = 9499090000 -- start of Mix parlay                        
SET @transid_m = 960900000                        
DELETE from bettrans where transid between @transid and @transid + 100000                        
Delete from bettransm where transid between @transid_m and @transid_m +  10000000 --and username =@username                        
                        
INSERT INTO @bettype_table                        
Select * from QC_data_test_DEP with (nolock)                        
where sporttype = 1                        
UNION ALL                        
Select * from QC_data_test_DEP with (nolock)                        
where sporttype =5 and bettype = 20                        
UNION ALL                        
Select * from QC_data_test_DEP with (nolock)                        
where sporttype =10 and bettype = 1                        
                        
                        
set @isloop = 1                        
WHILE @isloop > 0                        
BEGIN                        
 declare @refn int                        
 UPDATE ref with (rowlock,updlock) SET @refn=refno=refno+1  WHERE  refid='refno'                        
 set @refno = @refn + 100000000000                        
                        
 SET IDENTITY_INSERT [dbo].[bettrans] ON                        
  INSERT INTO Bettrans                         
  (transid,                        
  custid,transdate, oddsid,hdp1,hdp2, odds,stake,status, winlost,awinlost,mwinlost,playercomm,comm,acomm,apositiontaking,mpositiontaking,tpositiontaking,playerdiscount,discount,adiscount,livehomescore,liveawayscore, liveindicator,betteam, creator, refno,
  
    
      
        
           
           
              
                
                   
                    
                      
comstatus,winlostdate, betfrom, betcheck, checktime, oddsspread, actualrate, matchid, recommEND, mrecommEND, ruben, betid,statuswinlost, modds,bettype, betdaqid, tstamp, actual_stake, currency, IP, transdesc, sdiscount, scomm, spositiontaking,swinlost, sr
  
    
      
        
          
            
              
                
                  
                    
ecommEND,Username, CurrencyName, virtualrate, oddstype, statusID,currency2,balance, SecAcceptFlag, transid2,RecommDate)                        
  SELECT top 1                        
    transid = @transid,                        
    [custid] = @custid -- member05                        
     ,[transdate] = getdate()                        
     ,[oddsid] = 99                        
     ,[hdp1] = 0                        
     ,[hdp2] = 0                        
     ,[odds] = 3.375 -- = 1.5x1.5x1.5                        
     ,[stake] = 100                        
     ,[status] = 'LOSE'                        
     ,[winlost] = 0                        
     ,[awinlost] =40                        
     ,[mwinlost] = 30                        
     ,[playercomm] = 0.5                        
     ,[comm] =0.2                         
     ,[acomm]= 0.15                        
     ,[apositiontaking] = 0.4                        
     ,[mpositiontaking] = 0.3                        
     ,[tpositiontaking] = 0.9                        
     ,[playerdiscount] = 0.005                        
     ,[discount] = 0.005                        
     ,[adiscount] = 0.005                        
     ,[livehomescore] = 0                        
     ,[liveawayscore] = 0                        
     ,[liveindicator] = 0                        
     ,[betteam] = 'a'                        
     ,[creator] = 8 -- sa                        
     ,[refno] = @refno                        
     ,[comstatus] = 0                        
     ,[winlostdate] = @winlostdate                        
     ,[betfrom] = 'i'                        
     ,[betcheck] = 'm3'                         
     ,[checktime] = Null                        
     ,[oddsspread] = 0                        
     ,[actualrate] = 0                        
     ,[matchid] = 9                        
     ,[recommEND] = @recommend -- agent                        
     ,[mrecommEND] = @mrecommend --master                  
     ,[ruben] = 1                        
     ,[betid] = NULL                        
     ,[statuswinlost] = null                        
     ,[modds] = 0                        
     ,[bettype] = 9                        
     ,[betdaqid] = Null                        
     ,[tstamp] = null                        
     ,[actual_stake] = 100                        
     ,[currency] = 20                        
     ,[ip] = '127.0.0.1'                        
     ,[transdesc] = null                        
     ,[sdiscount] = 0.005                        
     ,[scomm] = 0.1                        
     ,[spositiontaking] = 0.1                        
     ,[swinlost] = 10                        
     ,[srecommEND] = @srecommend                        
     ,[Username] = @username                        
     ,[CurrencyName] = 'UUS'                        
     ,[virtualrate] = '1'                        
     ,[oddstype] = 1                        
     ,[statusID] = 113                        
     ,[currency2] = null                        
     ,[balance] = 1000000                        
     ,[SecAcceptFlag] = 1                        
     ,[transid2] = 0                        
     ,[RecommDate] = null                        
                        
  --FROM @bettype_TABLE bt                        
  --join odds o with (nolock) on bt.bettype = o.bettype                        
  --join match m with (nolock) on bt.sporttype = m.sporttype                        
  --where transid = @transid                        
  --and m.matchid between @min_matchid and @max_matchid                        
                          
 SET IDENTITY_INSERT [dbo].[bettrans] OFF                        
 Set @cnt = 3                        
 WHILE @cnt >=1                        
  BEGIN                        
   IF @cnt = 3 SELECT @sporttype = 1             
   IF @cnt = 2 select @sporttype = 5                        
   IF @cnt = 1 Select @sporttype = 10                        
                           
                         
                           
   SET IDENTITY_INSERT [dbo].[bettransm] ON                        
                        
   INSERT INTO bettransm (transid,                        
custid, oddsid, hdp1, hdp2, odds, betteam, [status], statusID,                         
  finalodds, livehomescore, liveawayscore,                        
  stake, refno, creator, betfrom, tpositiontaking, apositiontaking, mpositiontaking, spositiontaking,                        
  playerdiscount, discount, adiscount, sdiscount, actualrate, comstatus, matchid, matchdate,                         
  bettype, liveindicator, oddsspread)                         
                         
   SELECT top 1                        
    @transid_m,@custid, o.oddsid as oddsid,                         
    bt.hdp1,                        
    bt.hdp2,                        
  1.5, bt.betteam,                         
    'LOSE',                        
    113,                        
    1.5, isnull(bt.livehomescore,0),isnull(bt.liveawayscore,0),                        
    100, @refno, 8, 'i',                         
    0.9, 0.4, 0.3, 0.2,                        
    0.005, 0.005, 0.005, 0.005,                        
    0, @refno, m.matchid, m.eventdate,                         
    bt.bettype, bt.liveindicator, m.sporttype                        
   from @bettype_table bt                        
   join match m with (nolock) on bt.Sporttype = m.sporttype                        
   join odds o with (nolock) on o.matchid = m.matchid                        
   where m.sporttype = @sporttype                        
   and m.matchid between @min_matchid and @max_matchid          
                          
                         
   SET IDENTITY_INSERT [dbo].[bettransm] OFF                        
   Select @bettype = bettype, @betteam = betteam                         
   from bettransm with (nolock) where transid = @transid_m                        
   IF @sporttype = 1                        
    Delete from @bettype_table                        
    where Sporttype = 1 and bettype = @bettype and betteam = @betteam                        
                           
   Set @transid_m = @transid_m + 1                        
   Set @cnt = @cnt -1                        
                          
  END                        
 IF exists (Select top 1 * from bettransm with (nolock) where refno = @refno and liveindicator = 1)                         
  UPDATE bettrans                        
  set liveindicator = 1    where transid = @transid                        
                          
 select @transid = @transid + 1                        
                         
            
 IF NOT Exists (select top 1 * from @bettype_table where Sporttype = 1)                        
  set @isloop = 0                        
END                        
                      
END                      
*/                      
/*** END INSERT MIX PARLAY ***/                        
/*** INSERT SYSTEM PARLAY ***/                        
/*                      
BEGIN               
SET @transid = 9499290000 -- start of SYSTEM parlay                        
SET @transid_m = 962900000                        
                        
DELETE from bettrans where transid between @transid and @transid + 100000                        
Delete from bettransm where transid between @transid_m and @transid_m +  10000000 --and username =@username                        
                        
INSERT INTO @bettype_table -- system parlay not support live                        
Select * from QC_data_test_DEP with (nolock)                        
where sporttype = 1 and liveindicator =0                        
UNION ALL                        
Select * from QC_data_test_DEP with (nolock)                        
where sporttype =5 and bettype = 20 and liveindicator =0                        
UNION ALL                        
Select * from QC_data_test_DEP with (nolock)                        
where sporttype =10 and bettype = 1 and liveindicator =0                        
set @isloop = 1                        
WHILE @isloop > 0                        
BEGIN                        
 --declare @refn int                        
 UPDATE ref with (rowlock,updlock) SET @refn=refno=refno+1  WHERE  refid='refno'                        
 set @refno = @refn + 100000000000                        
                        
 SET IDENTITY_INSERT [dbo].[bettrans] ON                        
  INSERT INTO Bettrans                         
  (transid,                
  custid,transdate, oddsid,hdp1,hdp2, odds,stake,status, winlost,awinlost,mwinlost,playercomm,comm,acomm,apositiontaking,mpositiontaking,tpositiontaking,playerdiscount,discount,adiscount,livehomescore,liveawayscore, liveindicator,betteam, creator, refno,
   
   
      
        
           
           
              
                 
                  
                    
                      
comstatus,winlostdate, betfrom, betcheck, checktime, oddsspread, actualrate, matchid, recommEND, mrecommEND, ruben, betid,statuswinlost, modds,bettype, betdaqid, tstamp, actual_stake, currency, IP, transdesc, sdiscount, scomm, spositiontaking,swinlost, sr
  
    
      
        
          
            
              
                
                  
                    
ecommEND,Username, CurrencyName, virtualrate, oddstype, statusID,currency2,balance, SecAcceptFlag, transid2,RecommDate)                        
  SELECT top 1                        
    transid = @transid,                        
    [custid] = @custid -- member05                        
     ,[transdate] = getdate()                        
     ,[oddsid] = 99                        
     ,[hdp1] = 0                        
     ,[hdp2] = 0                        
     ,[odds] = 3.375 -- = 1.5x1.5x1.5                        
     ,[stake] = 100                        
     ,[status] = 'LOSE'                        
     ,[winlost] = 0                        
     ,[awinlost] =40                        
     ,[mwinlost] = 30                        
     ,[playercomm] = 0.5                        
     ,[comm] =0.2                         
     ,[acomm]= 0.15                        
     ,[apositiontaking] = 0.4                        
     ,[mpositiontaking] = 0.3                        
     ,[tpositiontaking] = 0.9                        
     ,[playerdiscount] = 0.005                        
     ,[discount] = 0.005                        
     ,[adiscount] = 0.005                        
     ,[livehomescore] = 0                        
     ,[liveawayscore] = 0                        
     ,[liveindicator] = 0                        
     ,[betteam] = '110'                        
     ,[creator] = 8 -- sa                        
     ,[refno] = @refno                        
     ,[comstatus] = 0                        
     ,[winlostdate] =  @winlostdate                        
     ,[betfrom] = 'i'                        
     ,[betcheck] = 0                        
     ,[checktime] = Null                        
     ,[oddsspread] = 0                        
     ,[actualrate] = 0                        
     ,[matchid] = 29                        
     ,[recommEND] = @recommend -- agent                        
     ,[mrecommEND] = @mrecommend --master                        
     ,[ruben] = 1                        
     ,[betid] = NULL                        
     ,[statuswinlost] = null                        
     ,[modds] = 0                        
 ,[bettype] = 29                        
     ,[betdaqid] = Null                        
     ,[tstamp] = null                        
     ,[actual_stake] = 100                        
     ,[currency] = 20                        
     ,[ip] = '127.0.0.1'                        
     ,[transdesc] = null                        
     ,[sdiscount] = 0.005                        
     ,[scomm] = 0.1           
     ,[spositiontaking] = 0.1                        
     ,[swinlost] = 10                        
     ,[srecommEND] = @srecommend                        
 ,[Username] = @username                        
     ,[CurrencyName] = 'UUS'                        
     ,[virtualrate] = '1'                        
     ,[oddstype] = 1                        
     ,[statusID] = 113                        
     ,[currency2] = null                        
     ,[balance] = 1000000                        
     ,[SecAcceptFlag] = 1                        
     ,[transid2] = 0                        
     ,[RecommDate] = null                        
                        
  --FROM @bettype_TABLE bt                        
  --join odds o with (nolock) on bt.bettype = o.bettype                        
  --join match m with (nolock) on bt.sporttype = m.sporttype                        
  --where transid = @transid                        
  --and m.matchid between @min_matchid and @max_matchid                        
                          
 SET IDENTITY_INSERT [dbo].[bettrans] OFF                        
 Set @cnt = 3                        
 WHILE @cnt >=1                    
  BEGIN                        
   IF @cnt = 3 SELECT @sporttype = 1                        
   IF @cnt = 2 select @sporttype = 5                        
   IF @cnt = 1 Select @sporttype = 10                        
   SET IDENTITY_INSERT [dbo].[bettransm] ON                        
                        
INSERT INTO bettransm (transid,                        
  custid, oddsid, hdp1, hdp2, odds, betteam, [status], statusID,                         
  finalodds, livehomescore, liveawayscore,                        
  stake, refno, creator, betfrom, tpositiontaking, apositiontaking, mpositiontaking, spositiontaking,                        
  playerdiscount, discount, adiscount, sdiscount, actualrate, comstatus, matchid, matchdate,                         
  bettype, liveindicator, oddsspread,winlostdate)                         
                         
   SELECT top 1                        
    @transid_m,@custid, o.oddsid as oddsid,                         
    bt.hdp1,                        
    bt.hdp2,                        
    1.5, bt.betteam,                         
    'LOSE',                        
    113,                        
    1.5, 0, 0,                        
    100, @refno, 8, 'i',                         
    0.9, 0.4, 0.3, 0.2,                        
    0.005, 0.005, 0.005, 0.005,                        
    0, @refno, m.matchid, m.eventdate,                         
    bt.bettype, 0, m.sporttype,m.eventdate                        
   from @bettype_table bt                        
   join match m with (nolock) on bt.Sporttype = m.sporttype                        
   join odds o with (nolock) on o.matchid = m.matchid                        
   where m.sporttype = @sporttype              
   and m.matchid between @min_matchid and @max_matchid                        
                          
                         
   SET IDENTITY_INSERT [dbo].[bettransm] OFF                        
   Select @bettype = bettype, @betteam = betteam                         
   from bettransm with (nolock) where transid = @transid_m                        
                           
   IF @sporttype = 1                        
    Delete from @bettype_table                        
    where Sporttype = 1 and bettype = @bettype and betteam = @betteam                        
                           
   Set @transid_m = @transid_m + 1                        
   Set @cnt = @cnt -1                        
                          
  END                        
                         
 INSERT INTO BetParlayDetail([RefNo]     ,[Serial]                        
      ,[transid]      ,[winlostdate]      ,[statuswinlost]      ,[statusid]                        
      ,[matchid]      ,[bettype]      ,[stake]      ,[odds]      ,[betteam]                        
      ,[hdp1]      ,[hdp2]      ,[livehomescore]      ,[liveawayscore]                        
      ,[liveindicator]      ,[betcheck])                        
 SELECT Refno,serial,transid,winlostdate,4,113,bm.matchid,bettype,stake,odds,betteam, hdp1, hdp2, bm.livehomescore, bm.liveawayscore, bm.liveindicator,betcheck                        
 FROM bettransm bm                         
 join match m on bm.matchid = m.matchid                        
 join @parlaydetail p on m.sporttype = p.sporttype                        
 where m.matchid between @min_matchid and @max_matchid                        
                         
 --select * from BetParlayDetail where RefNo = @refno                        
                         
 select @transid = @transid + 1                        
                         
 --Select * from bettrans where transid = @transid                        
 IF NOT Exists (select top 1 * from @bettype_table where Sporttype = 1)                        
  set @isloop = 0                        
END                        
                      
END                      
*/                      
/*** END INSERT SYSTEM PARLAY ***/                        
                        
                        
/*** INSERT RACING TICKET ***/                        
BEGIN                      
SET @transid = 9499330000 -- start of Racing                        
SET @transid_m = 963300000                   
SET @matchid = @orid                        
WHILE @matchid <= 6000002                        
BEGIN                        
 SET @bettype = 31                        
 SET @betteam = 'horse'                        
 While @bettype <=33                        
  BEGIN                    
    SET IDENTITY_INSERT [dbo].[bettrans] ON                        
    INSERT INTO Bettrans                         
    (transid,                        
    custid,transdate, oddsid,hdp1,hdp2, odds,stake,status, winlost,awinlost,mwinlost,playercomm,comm,acomm,apositiontaking,mpositiontaking,tpositiontaking,playerdiscount,discount,                
    adiscount,livehomescore,liveawayscore, liveindicator,betteam, creator, refno, comstatus,winlostdate, betfrom, betcheck, checktime, oddsspread, actualrate, matchid, recommEND,                 
    mrecommEND, ruben, betid,statuswinlost, modds,bettype, betdaqid, tstamp, actual_stake, currency, IP, transdesc, sdiscount, scomm, spositiontaking,swinlost,srecommEND,Username,                 
    CurrencyName, virtualrate, oddstype, statusID,currency2,balance, SecAcceptFlag, transid2,RecommDate)                        
    VALUES (                        
      @transid                        
        ,@custid -- member05                        
        ,getdate()                        
        , 0                        
        , 0                        
        , 0                        
        ,2.5                        
        , 100                        
        , 'LOSE'                        
        , 0                        
        ,40                        
        , 30                        
        ,0.5                        
        ,0.2                         
        , 0.15                        
        , 0.4                        
        , 0.3                        
        ,0.9                        
        , 0.005                        
        ,0.005                        
        , 0.005                        
        , 0           
        , 0                        
        , 0                        
        , @betteam                        
        , 8 -- sa                        
        , 100000000000                        
        , 0                        
        , @winlostdate                        
        , 'i'                        
        , NUll                         
        , Null                        
        , 0                        
        , 0                        
        , @matchid                        
        , @recommend -- agent                        
        , @mrecommend --master                        
        , 0       
        , 0                        
        , null                        
        , -1                        
        , @bettype                        
        , -1                        
        ,null                        
        , 100                        
        , 20                        
       , '127.0.0.1'                        
        , null                        
        , 0.005                        
        , 0.1                        
        , 0.1                        
        , 10                        
        , @srecommend                        
        , @username                        
        , 'UUS'                        
        ,'1'                        
        , 1                        
        , 113                   
        , 48                        
        , 1000000                        
        , 1                        
        , 0                        
        , null                        
     )                        
                             
                             
    SET IDENTITY_INSERT [dbo].[bettrans] OFF                        
   SET @bettype = @bettype +1                        
   SET @transid = @transid +1                        
  END                        
 Select @transid = @transid -1                        
                        
 set @bettype = 31                        
 While @bettype <33 -- Win/place bettype in bettransm                        
  BEGIN                         
   SET IDENTITY_INSERT [dbo].[bettransm] ON                        
   INSERT INTO bettransm                         
   (transid,                        
   custid,transdate, oddsid,hdp1,hdp2, odds,stake,status, winlost,awinlost,mwinlost,playercomm,comm,acomm,apositiontaking,mpositiontaking,tpositiontaking,playerdiscount,discount,adiscount,livehomescore,liveawayscore, liveindicator,                       
 
   betteam, creator, refno, comstatus,winlostdate, betfrom, betcheck, checktime, oddsspread, actualrate, matchid,  ruben, statuswinlost,                        
   bettype, sdiscount, scomm, spositiontaking,swinlost,                         
    statusID)                        
   VALUES (                        
     @transid_m                        
       ,@custid -- member05                        
       ,getdate()                        
       , 0                        
       , 0                        
       , 0                        
       ,2.5                        
       , 50                        
       , 'LOSE'                        
       , 0                        
       ,0                        
       , 0                        
       ,0                        
       ,0                        
       , 0                        
       , 0                        
       , 0                        
       ,0                        
       ,0                        
  ,0                        
       , 0                        
       , 0                        
       , 0                        
       , 0                        
       , @betteam                        
       , 8 -- sa                        
       , @transid                        
       , 0                        
       , @winlostdate                        
       , 'i'                        
       , NUll                         
       , Null                        
       , 0                        
       , 0                        
       , @matchid                        
       , 1                        
       , null                        
       , @bettype                        
       ,0,0,0,0                        
       , 113                        
    )                        
                             
   SET IDENTITY_INSERT [dbo].[bettransm] OFF                        
   SET @bettype = @bettype +1                        
   SET @transid_m = @transid_m +1                        
  END                        
 SET @matchid = @matchid + 1                        
 SET @transid = @transid +1      
END                        
END                      
/*** END INSERT RACING TICKET ***/                        
--return                        
                        
select bettype,betteam,* from bettrans where username = @username and transid >= 9000000000                        
order by transid                        
-- 9999022872                        
--delete from bettrans where transid > 9999000000 and username ='member05'                        
                        
select  * from match with (nolock)                        
where matchid  between @min_matchid and @max_matchid or matchid=71000050                        
select refno, bettype,* from bettrans where transid >=9499090000 and transid < 9500000000 and bettype = 9                        
--select refno,bettype,matchid,* from bettransm where transid >= 960900000                    
                  
select * from translog where custid='3548651'        
select * from bettransRnG where custid='3548651'  