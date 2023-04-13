Alter PROCEDURE [dbo].[sp_DailyCashInOut] 
@fromdate date
--@todate date
AS


with DailyCash as(
select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as rowid,*,(Debit-Credit)as Balance from (
	select * from
		(
		select EDate,Debit,Credit,EventID as TrackingID,sum(pair) as Pairs,detail
		from(
			select l.datetime as EDate, CreditAmount as Debit,DebitAmount as Credit,l.EventID,(itemQty)as pair,
				concat(trim(SpecialNOte),' ',trim(Remarks),'- Mr.',trim(PName),' Sb from ',trim(PCompanyName))as detail 
			from tblLedger l, tblProfile p, tblDetailInvoice d 
			where l.EventID=d.InvoiceID and l.ProfileId=p.ProfileId and iarticle is not null
		)a
		group by a.EventID,a.EDate,a.Debit,a.Credit,a.detail
		union
		select Edate,Debit,Credit,TrackingID,null as Pairs,detail from(
			(select VDateTime as Edate,VAmount as Credit,'0'as Debit,jobid as TrackingID,
				concat(trim(VRemarks),'- Mr.',trim(PName),' Sb from ',trim(PCompanyName))as detail 
			from tblVenderBills b,tblProfile p 
			where VFlag='C' and b.ProfileID=p.ProfileId
			) union all
			(
			select VDateTime as Edate,'0'as Credit,ABS(VAmount) as Debit,jobid as TrackingID,
				concat(trim(VRemarks),'- Mr.',trim(PName),' Sb from ',trim(PCompanyName))as detail 
			from tblVenderBills b,tblProfile p 
			where VFlag='D' and b.ProfileID=p.ProfileId
		))b
		union

		select a.ExpDate as Edate,'0' as Credit,null as Pairs, ExpAmount as Debit,a.expID as TrackingID, CONCAT(ExpDetail,'-',SubCatagory,'-',Catagory) as detail from tblExpenses a,(
		select a.expenseheadID, a.ExpenseHead as SubCatagory,b.ExpenseHead as Catagory from tblExpenseHead a inner join tblExpenseHead b on a.MasterheadID=b.expenseheadID
		)c where a.expID=c.expenseheadID
		)c order by EDate asc offset 0 rows
	)f
)
select * from(
select a.rowid, Convert(varchar,a.EDate ,105) Edate,a.Credit,a.Debit,SUM(b.balance) as blc,a.detail,a.Pairs,a.TrackingID
from DailyCash a, DailyCash b
where b.rowid<=a.rowid 
group by a.rowid ,a.EDate,a.Credit,a.detail,a.Debit,a.TrackingID,a.Balance,a.Pairs
order by rowid offset 0 rows)g where  g.EDate>@fromdate
