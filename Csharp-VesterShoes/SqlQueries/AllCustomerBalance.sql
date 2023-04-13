
select customerid,SUM(b.cr)as cr,SUM(b.dr)as dr, sum(cr-dr)as balance from
(
select a.ProfileId as customerid,cr,dr from (
select ProfileId,sum(CreditAmount)as cr,sum(DebitAmount) as dr from tblLedger group by ProfileId
) a , tblProfile p where a.ProfileId=p.ProfileId and PType=0 and a.ProfileId>0 and PGaurdianNameID<1
union
select PGaurdianNameID as customerid,sum(cr)as cr,sum(dr) as dr 
--select *
from 
(
select ProfileId,sum(CreditAmount)as cr,sum(DebitAmount) as dr from tblLedger group by ProfileId
) a , tblProfile p where a.ProfileId=p.ProfileId and (PType=0 or PType=3) and a.ProfileId>0 and PGaurdianNameID>0
group by PGaurdianNameID

)b group by customerid
