/*
   Saturday, August 26, 20176:57:53 PM
   User: 
   Server: DRYABADI-PC\SQLEXPRESS
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
CREATE TABLE dbo.Tmp_store_product
	(
	p_id int NOT NULL IDENTITY (1, 1),
	p_code int NULL,
	p_name nvarchar(50) NOT NULL,
	p_type nvarchar(50) NULL,
	p_size nvarchar(50) NULL,
	p_price int NOT NULL,
	p_detail nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_store_product SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_store_product ON
GO
IF EXISTS(SELECT * FROM dbo.store_product)
	 EXEC('INSERT INTO dbo.Tmp_store_product (p_id, p_name, p_type, p_size, p_price, p_detail)
		SELECT p_id, p_name, p_type, p_size, p_price, p_detail FROM dbo.store_product WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_store_product OFF
GO
DROP TABLE dbo.store_product
GO
EXECUTE sp_rename N'dbo.Tmp_store_product', N'store_product', 'OBJECT' 
GO
ALTER TABLE dbo.store_product ADD CONSTRAINT
	PK_store_product PRIMARY KEY CLUSTERED 
	(
	p_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.store_product', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.store_product', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.store_product', 'Object', 'CONTROL') as Contr_Per 