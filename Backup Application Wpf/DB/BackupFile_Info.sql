/*
   15 December, 201710:48:38
   User: 
   Server: ATOM-PC
   Database: BackupJobDB
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
CREATE TABLE dbo.Tmp_BackupFile_Info
	(
	Id_bpinfo int NOT NULL IDENTITY (1, 1),
	Filename nvarchar(50) NULL,
	FilePathFrom nvarchar(100) NULL,
	FilePathTo nvarchar(100) NULL,
	FileEXt nvarchar(50) NULL,
	Servertype nvarchar(50) NULL,
	ServerLocation nvarchar(50) NULL,
	CopyIpaddress text NULL,
	CopyUsername nvarchar(50) NULL,
	CopyPassword nvarchar(50) NULL,
	PasteIPaddress text NULL,
	PasteUsername nvarchar(50) NULL,
	PastePassword nvarchar(50) NULL,
	BackupSchedule nvarchar(50) NULL,
	IsActive char(10) NULL,
	IsAuto char(10) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_BackupFile_Info SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_BackupFile_Info ON
GO
IF EXISTS(SELECT * FROM dbo.BackupFile_Info)
	 EXEC('INSERT INTO dbo.Tmp_BackupFile_Info (Id_bpinfo, Filename, FilePathFrom, FilePathTo, FileEXt, Servertype, ServerLocation, CopyIpaddress, CopyUsername, CopyPassword)
		SELECT Id_bpinfo, Filename, FilePathFrom, FilePathTo, FileEXt, Servertype, ServerLocation, Ipaddress, Username, Password FROM dbo.BackupFile_Info WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_BackupFile_Info OFF
GO
DROP TABLE dbo.BackupFile_Info
GO
EXECUTE sp_rename N'dbo.Tmp_BackupFile_Info', N'BackupFile_Info', 'OBJECT' 
GO
COMMIT
select Has_Perms_By_Name(N'dbo.BackupFile_Info', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.BackupFile_Info', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.BackupFile_Info', 'Object', 'CONTROL') as Contr_Per 