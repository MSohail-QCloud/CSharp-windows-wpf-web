/*
   Thursday, August 31, 20173:47:48 PM
   User: 
   Server: ATOM-PC
   Database: abcstore
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.PO_master.po_id', N'Tmp_po_master_id', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PO_master.Tmp_po_master_id', N'po_master_id', 'COLUMN' 
GO
ALTER TABLE dbo.PO_master SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PO_master', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PO_master', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PO_master', 'Object', 'CONTROL') as Contr_Per 