USE [VesterDB]
GO

/****** Object:  StoredProcedure [dbo].[spCountPairsProductionbyBill]    Script Date: 02/03/2022 11:28:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spCountPairsProductionbyBill] 
@BillFrom int, 
@BillTo int
AS
/*Declare Variable*/  
DECLARE @Pivot_Column nvarchar;  
DECLARE @Query nvarchar;  
  
/*Select Pivot Column*/  
SELECT @Pivot_Column= COALESCE(@Pivot_Column+',','')+ QUOTENAME(VesterType) FROM  
(SELECT DISTINCT [VesterType] FROM tblVesterType WHERE Active=1 )Tab  
  
/*Create Dynamic Query*/  
SELECT @Query='SELECT invoicedate,Invoiceid, '+@Pivot_Column+'FROM   
(select m.invoicedate,o.Invoiceid,t.VesterType,d.itemQty from tblOrders o,tblItems i,  tblVesterType t, tblMasterInvoice m, tblDetailInvoice d where o.ItemsID=i.ItemsID and o.orderdetailID=d.orderdetailID and d.InvoiceID=m.InvoiceID and  i.VesterTypeID=t.VesterTypeID and m.DeleteBill=0  and o.Invoiceid is not null and t.Active=1 and m.InvoiceID>'+@BillFrom+' 
 )Tab1  
PIVOT  
(  
SUM(itemQty) FOR [VesterType] IN ('+@Pivot_Column+')
) AS Tab2  
ORDER BY Tab2.Invoiceid'  
  
/*Execute Query*/  
EXEC  sp_executesql  @Query  


--/*Declare Variable*/  
--DECLARE @Pivot_Column [nvarchar](max);  
--DECLARE @Query [nvarchar](max);  
 --and m.InvoiceID>'+@BillFrom+' and m.InvoiceID<='+@BillTo+'
--/*Select Pivot Column*/  
--SELECT @Pivot_Column= COALESCE(@Pivot_Column+',','')+ QUOTENAME(Year) FROM  
--(SELECT DISTINCT [Year] FROM Employee)Tab  
  
--/*Create Dynamic Query*/  
--SELECT @Query='SELECT Name, '+@Pivot_Column+'FROM   
--(SELECT Name, [Year] , Sales FROM Employee )Tab1  
--PIVOT  
--(  
--SUM(Sales) FOR [Year] IN ('+@Pivot_Column+')) AS Tab2  
--ORDER BY Tab2.Name'  
  
--/*Execute Query*/  
--EXEC  sp_executesql  @Query  
GO


