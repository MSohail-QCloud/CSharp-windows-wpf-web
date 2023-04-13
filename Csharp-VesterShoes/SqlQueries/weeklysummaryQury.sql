
select a.ProfileID,pname,PGaurdianName,vender_type_Descr,b.CurrWork,c.CurrRecieved,SUM(BillAmount)RemAmount from(select p.ProfileID,PName,PGaurdianName,PType,p.vender_type_id,PaidAmount,vender_type_Descr,b.BillAmount from tblProfile p, tblVenderBills b, tblProcessStates c where PType=1 and p.ProfileId=b.ProfileID and p.vender_type_id=c.vender_type_id)a,(select ProfileID,SUM(BillAmount)CurrWork from tblVenderBills where Vflag='C' and VDateTime>'' and VDateTime<'' group by ProfileID )b,(select ProfileID,SUM(BillAmount)CurrRecieved from tblVenderBills where Vflag='D' and VDateTime>'' and VDateTime<'' group by ProfileID)c where a.ProfileId=b.ProfileID and a.ProfileId=c.ProfileID group by a.ProfileId,a.PName,a.PGaurdianName,vender_type_Descr order by PName


 select * from tblVenderBills
 
 
 select a.ProfileID,pname,PGaurdianName,vender_type_Descr,b.CurrWork,c.CurrRecieved,SUM(BillAmount)RemAmount from(select p.ProfileID,PName,PGaurdianName,PType,p.vender_type_id,PaidAmount,vender_type_Descr,b.BillAmount from tblProfile p, tblVenderBills b, tblProcessStates c where PType=1 and p.ProfileId=b.ProfileID and p.vender_type_id=c.vender_type_id)a,(select ProfileID,SUM(BillAmount)CurrWork from tblVenderBills where Vflag='C' and VDateTime>'2021-01-22' and VDateTime<'2021-01-20' group by ProfileID )b,(select ProfileID,SUM(BillAmount)CurrRecieved from tblVenderBills where Vflag='D' and VDateTime>'2021-01-22' and VDateTime<'2021-01-20' group by ProfileID)c where a.ProfileId=b.ProfileID and a.ProfileId=c.ProfileID group by a.ProfileId,a.PName,a.PGaurdianName,vender_type_Descr order by PName



 