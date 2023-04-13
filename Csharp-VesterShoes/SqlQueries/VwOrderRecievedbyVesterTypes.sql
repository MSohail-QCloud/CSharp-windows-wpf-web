USE [VesterDB]
GO

/****** Object:  View [dbo].[Vw_OrderRecieved_by_VesterTypes]    Script Date: 12/17/2021 7:36:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER View  [dbo].[Vw_OrderRecieved_by_VesterTypes]
AS
select a.VesterType,a.AllOrders,b.thisWeek,c.thisMonth,d.thisYear from (
select t.VesterType,z.AllOrders from (
select i.VesterTypeID,sum(ItemsQty)as AllOrders from tblOrders o, tblItems i where o.ItemsID=i.ItemsID group by i.VesterTypeID)
z, tblVesterType t where z.VesterTypeID=t.VesterTypeID
) a full join(
select t.VesterType,w.thisWeek from (
select i.VesterTypeID,sum(ItemsQty)as thisWeek from tblOrders o, tblItems i where o.ItemsID=i.ItemsID and o.OrderDatetime>= case when datepart(weekday, GETDATE()) >5 then
 DATEADD(DAY, +4, DATEADD(WEEK, DATEDIFF(WEEK, 0,GETDATE()), 0)) 
else DATEADD(DAY, -3, DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0)) end  group by i.VesterTypeID) 
w, tblVesterType t where w.VesterTypeID=t.VesterTypeID
)b on a.VesterType=b.VesterType full join(
select t.VesterType,w.thisMonth from (
select i.VesterTypeID,sum(ItemsQty)as thisMonth from tblOrders o, tblItems i where o.ItemsID=i.ItemsID and month (o.OrderDatetime)=month(getdate())group by i.VesterTypeID) 
w, tblVesterType t where w.VesterTypeID=t.VesterTypeID
)c on a.VesterType=c.VesterType full join(
select t.VesterType,w.thisYear from (
select i.VesterTypeID,sum(ItemsQty)as thisYear from tblOrders o, tblItems i where o.ItemsID=i.ItemsID and Year (o.OrderDatetime)=Year(getdate())group by i.VesterTypeID) 
w, tblVesterType t where w.VesterTypeID=t.VesterTypeID
)d on a.VesterType=d.VesterType

 --and a.VesterType=c.VesterType




--select * from tblOrders 




GO


