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

 Date: 21/03/2024 21:24:01
*/


-- ----------------------------
-- Table structure for funcusergroup
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[funcusergroup]') AND type IN ('U'))
	DROP TABLE [dbo].[funcusergroup]
GO

CREATE TABLE [dbo].[funcusergroup] (
  [id] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [funcugcode] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [funcugname] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [funcugdesc] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [createuser] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [createdata] int  NOT NULL,
  [createtime] int  NOT NULL,
  [loguser] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [logdate] int  NOT NULL,
  [logtime] int  NOT NULL
)
GO

ALTER TABLE [dbo].[funcusergroup] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of funcusergroup
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table funcusergroup
-- ----------------------------
ALTER TABLE [dbo].[funcusergroup] ADD CONSTRAINT [PK_dbo.funcusergroup] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

