USE [VesterDB]
GO

/****** Object:  StoredProcedure [dbo].[CareOfcustomerLedger]    Script Date: 12/19/2021 9:05:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[CareOfcustomerLedger] 
@Customerid int, 
@fromdate date,
@todate date
AS


with debitCredit as
(
	select 0 as rowid, 0 as ledgerid,null as ledgerdate,null as eventid,'' as ProfileId,'' as Pname,'' as PCompanyName,'Brought Forward' as detail,null as debitamount,null as creditamount,ISNULL(sum(CreditAmount-DebitAmount),0) as balance
	from
		(select l.ledgerID,CAST( l.datetime as date)as LedgerDate,l.EventID,l.ProfileId,p.PName,p.PCompanyName,Concat(l.SpecialNOte,' ',l.Remarks )as detail,l.DebitAmount,l.CreditAmount 
		from tblLedger l, tblProfile p 
		where l.ProfileId=p.ProfileId and p.PGaurdianNameID=@Customerid 
		)a
	where a.LedgerDate <@fromdate 
	union all
	select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as rowid,* 
	from 
	(
		select l.ledgerID,CAST( l.datetime as date)as LedgerDate,l.EventID,l.ProfileId,p.PName,p.PCompanyName,concat(l.SpecialNOte,' ',l.Remarks)as detail ,l.DebitAmount,l.CreditAmount,(l.CreditAmount-l.DebitAmount)as balance 
		from tblLedger l, tblProfile p 
		where l.ProfileId=p.ProfileId and p.PGaurdianNameID=@Customerid
	)b
	where  b.LedgerDate >=@fromdate and b.LedgerDate <= @todate
)

select a.ledgerid,a.ledgerdate,a.eventid,a.ProfileId,a.Pname,a.PCompanyName,a.detail,a.debitamount,a.creditamount,SUM(b.balance) as blc
from debitCredit a, debitCredit b
where b.rowid<=a.rowid
group by a.rowid ,a.ledgerid,a.ledgerdate,a.eventid,a.ProfileId,a.Pname,a.PCompanyName,a.detail,a.debitamount,a.creditamount
order by a.rowid

GO


