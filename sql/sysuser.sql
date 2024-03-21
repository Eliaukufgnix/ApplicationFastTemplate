/*
 Navicat Premium Data Transfer

 Source Server         : mssql
 Source Server Type    : SQL Server
 Source Server Version : 16001000
 Source Host           : LG4266\SQLEXPRESS:1433
 Source Catalog        : dotnet
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000
 File Encoding         : 65001

 Date: 21/03/2024 21:24:09
*/


-- ----------------------------
-- Table structure for sysuser
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sysuser]') AND type IN ('U'))
	DROP TABLE [dbo].[sysuser]
GO

CREATE TABLE [dbo].[sysuser] (
  [id] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [account] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [password] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [salt] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [createuser] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [createdata] int  NOT NULL,
  [createtime] int  NOT NULL,
  [loguser] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [logdate] int  NOT NULL,
  [logtime] int  NOT NULL
)
GO

ALTER TABLE [dbo].[sysuser] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sysuser
-- ----------------------------
INSERT INTO [dbo].[sysuser] ([id], [account], [password], [salt], [createuser], [createdata], [createtime], [loguser], [logdate], [logtime]) VALUES (N'0', N'admin', N'2PChxcuTwTWlqD48En5J7Rn0YOR3rZZ1OeFvbK4S4EQ=', N'Bb6b2a6S9pKql3zf5r0zeA==', N'admin', N'20240316', N'233742', N'admin', N'20240316', N'233742')
GO


-- ----------------------------
-- Primary Key structure for table sysuser
-- ----------------------------
ALTER TABLE [dbo].[sysuser] ADD CONSTRAINT [PK__sysuser___3213E83F4DC68851] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

