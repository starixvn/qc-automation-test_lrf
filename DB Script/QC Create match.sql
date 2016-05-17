CREATE PROCEDURE [dbo].[QC_create_match]    
     
 @matchid bigint,    
 @sport varchar (200) = '',    
 @isDEP bit = 0,    
 @min_matchid bigint OUTPUT,    
 @max_matchid bigint OUTPUT,    
 @orid int output,    
 @VSOrid int output,  
 @eventstatus varchar (200)      
    
/*    
Created: 20160624@Ben    
Task : create running match for data test    
DB: DB206.bodb02    
Original:     
Revisions:    
     
Param's Explanation:      
*/    
    
AS    
SET NOCOUNT ON    
DECLARE @sport_table TABLE (Sporttype int)    
    
IF @sport = '' OR ISNULL(@sport,'') = ''    
 IF @isDEP = 0     
  INSERT INTO @sport_table    
  SELECT DISTINCT sporttype from QC_data_test with (nolock)    
 ELSE     
  INSERT INTO @sport_table    
  SELECT DISTINCT sporttype from QC_data_test_DEP with (nolock)    
ELSE     
 INSERT INTO @sport_table    
 SELECT DISTINCT CAST(val AS int) from dbo.strSplit(@sport,',')    
    
    
Declare @cnt_sport int, @isloop bit =1, @sporttype int    
select @cnt_sport = count (*) from @sport_table    
Delete from match    
where matchid between @matchid and @matchid + @cnt_sport    
    
/****INSERT MATCH******/    
Declare @leagueid int= 0, @homeid int = 0, @awayid int = 0    
    
 while @isloop >0    
 BEGIN    
  SELECT top 1 @sporttype = sporttype from @sport_table    
    
  IF @sporttype =1 -- Soccer    
   Select @leagueid = 43 -- LaLiga    
     ,@homeid = 111 -- Real madrid    
     ,@awayid = 22 -- Barca    
  IF @sporttype = 5 -- Tennis    
   select @leagueid = 1708 -- US open    
     ,@homeid = 9289 -- Roger Federer    
     ,@awayid = 286768 -- Pete Sampras    
  IF @sporttype = 2 -- BasketBall    
   select @leagueid = 2129 -- NBA BASKETBALL    
     ,@homeid = 1975 -- Chicago Bulls    
     ,@awayid = 1968 -- Philadelphia 76ers    
  IF @sporttype = 4 -- Ice Hockey    
   select @leagueid = 661 -- NHL (NATIONAL HOCKEY LEAGUE)    
     ,@homeid = 8898 -- New York Rangers    
     ,@awayid = 8913 -- Phoenix Coyotes    
  IF @sporttype = 6 -- volleyball    
   select @leagueid = 25857 -- Korea Suwon Cup    
     ,@homeid = 177431 --Incheon Korean Air Jumbos    
     ,@awayid = 177613 -- Seoul Woori Capital Dream6    
  IF @sporttype = 10 -- Golf    
   select @leagueid = 1693 -- PGA Tour - RBC Heritage Winner    
     ,@homeid = 13074 --Tiger Woods    
     ,@awayid = 13090 --Geoff Ogilvy    
  IF @sporttype = 161    
   Select @leagueid = 15223    
     ,@homeid = 0    
     ,@awayid = 0     
  SET IDENTITY_INSERT [dbo].[match] ON    
  INSERT INTO match ([matchid],[leagueid],[homeid],[awayid],[eventdate],[eventstatus],[betstatus],[livehomescore],[liveawayscore],[finalhomescore],[finalawayscore],[creator],[matchcode],    
  [kickofftime],[closedtime],[showtime],[hthomescore],[htawayscore],[ruben],[multiple],[yenbet],[exrisk],[sporttype],[tstamp],[homeid2],[awayid2],[DisplayMode],[LeaguePatternID],[HomeDisplayPatternID],[AwayDisplayPatternID],[IsNeutral],[InjuryTime],[GoalR
ecord],[ParentID],[ChildMatchType],[GlobalShowTime],[HasLive],[changetime],[settletime])      
    
  Values( @matchid,    
  @leagueid,@homeid, @awayid, CAST(GETDATE() AS DATE),@eventstatus,    
  case when @sporttype = 1 then '1FL:1-2;FL:1-1;PS:Y;'    
    when @sporttype in (5) then '6-1,2-6,7-5,0-0,0-0'    
    when @sporttype in (6,9,30) then '21-12,21-17,21-15,0-0,0-0'    
    Else '' end,    
  Case when @sporttype = 161 then 27 else 0 end,0     
  ,Case when @sporttype = 161 then 27 else 2 end,1,    
  8,'QCTEST','2014-12-24 0:00:30',NULL,Null, Case when @sporttype = 161 then 36 else 1 end,1,1,0,null, null, @sporttype,null, 0,0,0,0,0,0,1,0,    
  case when @sporttype = 1 then 'HA;H'    
    ELSE ';' END,0,0,0,0,0,0)    
      
      
  SET IDENTITY_INSERT [dbo].[match] OFF    
      
  IF @sporttype = 5    
  BEGIN    
   DELETE FROM ResultDetail    
   Where MatchId = @matchid    
       
   Insert into ResultDetail (Matchid, ResourceID,Homevalue, Awayvalue, ResultStatusID, SettlementStatusID,Createdate, CreateBy )    
   Values    
   (@matchid,'00','2','1',5,4,getdate(),16379384),    
   (@matchid,'01','6','1',5,4,getdate(),16379384),    
   (@matchid,'02','2','6',5,4,getdate(),16379384),    
   (@matchid,'03','7','5',5,4,getdate(),16379384),    
   (@matchid,'0301','40','15',5,4,getdate(),16379384),    
   (@matchid,'0302','15','40',5,4,getdate(),16379384),    
   (@matchid,'0303','40','A',5,4,getdate(),16379384),    
   (@matchid,'0304','15','40',5,4,getdate(),16379384),    
   (@matchid,'0305','A','40',5,4,getdate(),16379384),    
   (@matchid,'0306','30','40',5,4,getdate(),16379384),    
   (@matchid,'0307','15','40',5,4,getdate(),16379384),    
   (@matchid,'0308','40','A',5,4,getdate(),16379384)    
    
       
       
       
  END    
      
  Delete from @sport_table    
  where sporttype = @sporttype    
      
  IF @sporttype = 161    
   BEGIN    
   DELETE FROM bingoBall    
   where Matchid = @matchid    
   INSERT INTO bingoBall    
   Values (@matchid,1,36,GETDATE())    
     ,(@matchid,2,59,GETDATE())    
     ,(@matchid,3,27,GETDATE())    
   END    
  set @matchid = @matchid +1    
  --select top 1 * from @sport_table    
  --If @@rowcount = 0     
  IF NOT EXISTS (select top 1 * from @sport_table)    
   set @isloop = 0    
      
      
      
 END    
/****END INSERT MATCH******/    
    
    
Select @max_matchid = max(matchid), @min_matchid = min(matchid)    
from match with (nolock)    
where matchid between @matchid - @cnt_sport and @matchid    
    
select @max_matchid, @min_matchid    
    
/****INSERT OUTRIGHT FOR RACING******/    
Set @orid  = 6000000    
 Delete from Outright    
 where orid between 6000000 and 6000100    
INSERT INTO @sport_table    
VALUES (151),(152),(153)    
    
DECLARE @teamid int    
Set @isloop = 1    
WHILE @isloop >0    
BEGIN    
 Select top 1 @sporttype = Sporttype from @sport_table    
 IF @sporttype = 151    
  Select @leagueid = 4016, @teamid = 38985    
 IF @sporttype = 152    
  Select @leagueid = 22380, @teamid = 190282    
 IF @sporttype = 152    
  Select @leagueid = 24020, @teamid = 186266    
     
 SET IDENTITY_INSERT [Outright] ON    
  INSERT INTO Outright( [orid]    
    ,[leagueid]    
    ,[teamid]    
    ,[eventdate]    
    ,[kickofftime]    
    ,[oddsstatus]    
    ,[odds]    
    ,[maxbet]    
    ,[gapodds]    
    ,[matchcode]    
    ,[groupmatch]    
    ,[status]    
    ,[creator]    
    ,[bal]    
    ,[risk]    
    ,[DisplayMode]    
    ,[ProgramID]    
    ,[HorseJockey]    
    ,[HorseDraw]    
    ,[HorseWgt]    
    ,[PlaceOdds]    
    ,[Placing]    
    ,[IsFavor]    
    ,[IsSCR]    
    ,[Colours]    
    ,[HorseTrainer]    
    ,[FOddsStatus]    
    ,[SCRTime]    
    ,[changetime]    
    ,[LeaguePatternID]    
    ,[TeamPatternID]    
    ,[ProgramDate]    
    ,[IsDeadheat]    
    ,[StdDelBetCheck])    
  VALUES (@orid, @leagueid, @teamid, CAST(getdate() AS DATE), getdate(), @eventstatus ,0.00, 0, 0.00, 6, 4, NULL, @sporttype, 0.00, 0.00, 0, NULL, NULL, NULL, NULL, 0.00, 0, 0, 0, NULL, NULL, NULL, NULL, '', 1, 0, '', NULL, NULL)    
 SET IDENTITY_INSERT [Outright] OFF    
 Set @orid = @orid +1    
 Delete from @sport_table    
 where Sporttype = @sporttype    
     
 IF NOT Exists (select top 1 * from @sport_table)    
  SET @isloop = 0    
     
END    
Select @orid = 6000000    
/****END INSERT OUTRIGHT******/    
    
/****INSERT OUTRIGHT FOR VSRACING******/    
    
SET @VSorid = 2002000    
    
DECLARE @eventID int, @RacerID int, @humanID int, @color varchar (100)    
INSERT INTO @sport_table    
VALUES (181),(182),(183),(184),(185)    
SET @isloop = 1    
WHILE @isloop >0    
BEGIN    
 Select top 1 @sporttype = Sporttype from @sport_table    
 IF @sporttype = 181     
  Select @eventID = 10155238,@RacerID = 227122, @humanID = 227152, @color = 'VirtualSports/HorseRacing/SilkSmall_04.jpg'    
 IF @sporttype = 182    
  Select @eventID = 20177383,@RacerID = 246675, @humanID = 246955, @color = 'VirtualSports/Greyhounds/1.jpg'    
 IF @sporttype = 183    
  Select @eventID = 60349214,@RacerID = 270508, @humanID = 270145, @color = 'VirtualSports/Speedway/2.jpg'    
 IF @sporttype = 184    
  Select @eventID = 30233777,@RacerID = 258880, @humanID = 259380, @color = 'VirtualSports/MotorRacing/4.jpg'    
 IF @sporttype = 185    
  Select @eventID = 50303611,@RacerID = 271666, @humanID = 270936, @color = 'VirtualSports/Cycling/2.jpg'    
     
 IF NOT EXISTS (Select top 1 * from VSOutright with (nolock) where Orid = @VSorid)    
 BEGIN    
     
 SET IDENTITY_INSERT [VSOutright] ON    
  INSERT INTO VSOutright([Orid]      ,[EventID]      ,[RacerNum]      ,[IsFavor]      ,[EventDate]      ,[KickoffTime]      ,[RacerID]      ,[HumanID]      ,[WinOdds]    
      ,[PlaceOdds]      ,[Lane]      ,[MaxBet]      ,[DisplayMode]      ,[Placing]      ,[Colours]      ,[Creator]      ,[tstamp]      ,[ChangeTime]      ,[EventStatus])      
      SELECT [Orid] = @VSorid    
           ,[EventID]= @eventID    
      ,[RacerNum]= 7    
      ,[IsFavor]=''    
      ,[EventDate]=GETDATE()    
      ,[KickoffTime]=GETDATE()    
      ,[RacerID]=@RacerID    
      ,[HumanID]=@humanID    
      ,[WinOdds]= 9.5    
      ,[PlaceOdds]=3.2    
      ,[Lane]=6    
      ,[MaxBet]=2200    
      ,[DisplayMode]=0    
      ,[Placing]=0    
      ,[Colours]=@color    
      ,[Creator]=@sporttype    
      ,[tstamp]=NULL    
      ,[ChangeTime]=null    
      ,[EventStatus]=@eventstatus   
     
 SET IDENTITY_INSERT [VSOutright] OFF    
 END    
 ELSE     
 UPDATE VSOutright    
 Set EventID = @eventID, RacerNum = 7, EventDate = CAST(getdate() as DATE),    
 KickoffTime = GETDATE(), RacerID =@RacerID, HumanID = @humanID, WinOdds = 9.5,    
 [PlaceOdds]=3.2,[Lane]=6      ,[MaxBet]=2200      ,[DisplayMode]=0      ,[Placing]=0    
      ,[Colours]=@color      ,[Creator]=@sporttype      ,[EventStatus]=@eventstatus    
 Where Orid = @VSorid     
     
 Set @VSorid = @VSorid +1    
 Delete from @sport_table    
 where Sporttype = @sporttype    
     
 IF NOT Exists (select top 1 * from @sport_table)    
  SET @isloop = 0    
END    
Select @VSorid = 2002000    
    
    
    
    
    
/****END INSERT OUTRIGHT******/ 