
select 0 as ledgerid,null as ledgerdate,null as eventid,a.ProfileId as ProfileId,PName as Pname,PCompanyName as PCompanyName,'Brought Forward' as specialNote,null as debitamount,null as creditamount,ISNULL(sum(CreditAmount-DebitAmount),0) as balance
from
(select l.ledgerID,CAST( l.datetime as date)as LedgerDate,l.EventID,l.ProfileId,p.PName,p.PCompanyName,l.SpecialNOte ,l.DebitAmount,l.CreditAmount from tblLedger l, tblProfile p where l.ProfileId=p.ProfileId and l.ProfileId=49 )a
where a.LedgerDate <'2021-12-04'


select * from tblLedger

WITH tempDebitCredit AS (
Select 0 As Details_ID, null As Creation_Date, null As Reference_ID, 'Brought Forward' As Transaction_Kind, null As Amount_Debit, null As Amount_Credit, isNull(Sum(Amount_Debit - Amount_Credit), 0) 'diff'
From _YourTable_Name
where Account_ID = @Account_ID
And Creation_Date < @Query_Start_Date
Union All
SELECT a.Details_ID, a.Creation_Date, a.Reference_ID, a.Transaction_Kind, a.Amount_Debit, a.Amount_Credit, a.Amount_Debit - a.Amount_Credit 'diff'
FROM _YourTable_Name a
where Account_ID = @Account_ID
And Creation_Date >= @Query_Start_Date And Creation_Date <= @Query_End_Date
)

SELECT a.Details_ID, a.Creation_Date, a.Reference_ID, a.Transaction_Kind, 
a.Amount_Debit, a.Amount_Credit, SUM(b.diff) 'Balance'
FROM   tempDebitCredit a, tempDebitCredit b
WHERE b.Details_ID <= a.Details_ID
GROUP BY a.Details_ID, a.Creation_Date, a.Reference_ID, a.Transaction_Kind, 
a.Amount_Debit, a.Amount_Credit
Order By a.Details_ID Desc

