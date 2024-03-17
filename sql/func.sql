/*
 Navicat Premium Data Transfer

 Source Server         : SQLServer
 Source Server Type    : SQL Server
 Source Server Version : 16001000
 Source Host           : DESKTOP-GOVJGNI\SQLEXPRESS:1433
 Source Catalog        : dotnet
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000
 File Encoding         : 65001

 Date: 18/03/2024 01:28:31
*/


-- ----------------------------
-- Table structure for func
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[func]') AND type IN ('U'))
	DROP TABLE [dbo].[func]
GO

CREATE TABLE [dbo].[func] (
  [id] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [funcpara] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [funcname] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [createuser] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [funcurl] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [funcicon] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [parentid] nvarchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [createdata] int  NOT NULL,
  [createtime] int  NOT NULL,
  [loguser] nvarchar(100) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [logdate] int  NOT NULL,
  [logtime] int  NOT NULL
)
GO

ALTER TABLE [dbo].[func] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'功能参数',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'funcpara'
GO

EXEC sp_addextendedproperty
'MS_Description', N'功能名称',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'funcname'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'createuser'
GO

EXEC sp_addextendedproperty
'MS_Description', N'功能路径',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'funcurl'
GO

EXEC sp_addextendedproperty
'MS_Description', N'图标',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'funcicon'
GO

EXEC sp_addextendedproperty
'MS_Description', N'父节点',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'parentid'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建日期',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'createdata'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'createtime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'更新人',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'loguser'
GO

EXEC sp_addextendedproperty
'MS_Description', N'更新日期',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'logdate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'更新时间',
'SCHEMA', N'dbo',
'TABLE', N'func',
'COLUMN', N'logtime'
GO


-- ----------------------------
-- Records of func
-- ----------------------------
INSERT INTO [dbo].[func] ([id], [funcpara], [funcname], [createuser], [funcurl], [funcicon], [parentid], [createdata], [createtime], [loguser], [logdate], [logtime]) VALUES (N'1', NULL, N'首页', N'admin', N'/Home/Index', N'layui-icon layui-icon-console', N'ROOT', N'20240316', N'233742', N'admin', N'20240316', N'233742')
GO

INSERT INTO [dbo].[func] ([id], [funcpara], [funcname], [createuser], [funcurl], [funcicon], [parentid], [createdata], [createtime], [loguser], [logdate], [logtime]) VALUES (N'2', NULL, N'系统及门户管理', N'admin', N'', N'layui-icon layui-icon-console', N'ROOT', N'20240316', N'233742', N'admin', N'20240316', N'233742')
GO


-- ----------------------------
-- Primary Key structure for table func
-- ----------------------------
ALTER TABLE [dbo].[func] ADD CONSTRAINT [PK_dbo.func] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

