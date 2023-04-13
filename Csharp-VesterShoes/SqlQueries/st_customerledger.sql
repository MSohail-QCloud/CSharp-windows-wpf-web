CREATE PROCEDURE customerLedger 
@Customerid int, 
@fromdate date,
@todate date
AS

with debitCredit as
(
	select 0 as rowid, 0 as ledgerid,null as ledgerdate,null as eventid,ProfileId as ProfileId,PName as Pname,PCompanyName as PCompanyName,'Brought Forward' as specialNote,null as debitamount,null as creditamount,ISNULL(sum(CreditAmount-DebitAmount),0) as balance
	from
		(select l.ledgerID,CAST( l.datetime as date)as LedgerDate,l.EventID,l.ProfileId,p.PName,p.PCompanyName,l.SpecialNOte ,l.DebitAmount,l.CreditAmount 
		from tblLedger l, tblProfile p 
		where l.ProfileId=p.ProfileId and l.ProfileId=@Customerid 
		)a
	where a.LedgerDate <@fromdate 
	group by a.ProfileId,a.PName,a.PCompanyName
	union all
	select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as rowid,* 
	from 
	(
		select l.ledgerID,CAST( l.datetime as date)as LedgerDate,l.EventID,l.ProfileId,p.PName,p.PCompanyName,l.SpecialNOte ,l.DebitAmount,l.CreditAmount,(l.CreditAmount-l.DebitAmount)as balance 
		from tblLedger l, tblProfile p 
		where l.ProfileId=p.ProfileId and l.ProfileId=@Customerid
	)b
	where  b.LedgerDate >=@fromdate and b.LedgerDate <= @todate
)

select a.ledgerid,a.ledgerdate,a.eventid,a.ProfileId,a.Pname,a.PCompanyName,a.specialNote,a.debitamount,a.creditamount,SUM(b.balance) as blc
from debitCredit a, debitCredit b
where b.rowid<=a.rowid
group by a.rowid ,a.ledgerid,a.ledgerdate,a.eventid,a.ProfileId,a.Pname,a.PCompanyName,a.specialNote,a.debitamount,a.creditamount
order by a.rowid




GO;