select * FROM rptLicWinloss2 where custid='3548651' and sporttype=205
--DELETE FROM rptLicWinloss2 where custid='3548651' and sporttype=205

select * from ExchangeDailyOanda
EXEC Age_SelBalanceUpDay
-- user: 12BET iceEW custid=3548651
-- Have to run 'EXEC Age_SelBalanceUpDay' to get MOVEBETDAY and update the scripts below
insert into rptLicWinloss2(winlostdate, username, username2, custid, roleid ,recommend, mrecommend, srecommend,
							turnover, winlost, awinlost, mwinlost, swinlost, playercomm, comm, acomm, scomm,
							winlostvirtual, commvirtual, BetCount, Currency, sporttype, bettype, 
							statusID, isBA, isMobile, betfrom, BetEffective, BuyBackAmt, BABuyBackAmt )
					VALUES ('2016-04-15', 'SPONUUS01017', 'spondemo$iceEW', '3548651', '1', '3233923', '3233915', '3233912',
							'10', '35', 0, 0, 0, 0, 0, 0, 0,
							0, 0, 2, '20', 205, 2009, 
							'112', 0, 0, 'a', 10, 0, 0)

