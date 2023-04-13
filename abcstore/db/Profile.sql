/*
   Thursday, August 24, 20173:00:00 PM
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
CREATE TABLE dbo.Tmp_Profile
	(
	Pro_id int NOT NULL IDENTITY (1, 1),
	Pro_code int NOT NULL,
	Pro_name nvarchar(50) NOT NULL,
	pro_fname nvarchar(50) NULL,
	pro_mno1 nvarchar(50) NULL,
	pro_mno2 nvarchar(50) NULL,
	pro_companyname nvarchar(50) NULL,
	pro_add nvarchar(50) NULL,
	pro_email nvarchar(50) NULL,
	pro_city nvarchar(50) NULL,
	Pro_country nvarchar(50) NULL,
	pro_cv int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Profile SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Profile ON
GO
IF EXISTS(SELECT * FROM dbo.Profile)
	 EXEC('INSERT INTO dbo.Tmp_Profile (Pro_id, Pro_code, Pro_name, pro_fname, pro_mno1, pro_mno2, pro_companyname, pro_add, pro_email, pro_city, Pro_country, pro_cv)
		SELECT Pro_id, Pro_code, Pro_name, pro_fname, pro_mno1, pro_mno2, pro_companyname, pro_add, pro_email, pro_city, Pro_country, pro_cv FROM dbo.Profile WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Profile OFF
GO
DROP TABLE dbo.Profile
GO
EXECUTE sp_rename N'dbo.Tmp_Profile', N'Profile', 'OBJECT' 
GO
ALTER TABLE dbo.Profile ADD CONSTRAINT
	PK_Profile PRIMARY KEY CLUSTERED 
	(
	Pro_id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Profile', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Profile', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Profile', 'Object', 'CONTROL') as Contr_Per 