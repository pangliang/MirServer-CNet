
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2013 22:55:13
-- Generated from EDMX file: D:\GameOfMir\DBServer\Mir2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Mir2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[HumDataInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HumDataInfo];
GO
IF OBJECT_ID(N'[dbo].[HumInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HumInfo];
GO
IF OBJECT_ID(N'[dbo].[TEST]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TEST];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HumDataInfo'
CREATE TABLE [dbo].[HumDataInfo] (
    [nId] int  NOT NULL,
    [dCreateDate] float  NULL,
    [sChrName] varchar(14)  NULL,
    [sCurMap] varchar(16)  NULL,
    [wCurX] int  NULL,
    [wCurY] int  NULL,
    [NG] int  NULL,
    [MaxNG] int  NULL,
    [wStatusTimeArr] varbinary(24)  NULL,
    [sHomeMap] varchar(16)  NULL,
    [wHomeX] int  NULL,
    [wHomeY] int  NULL,
    [btCreditPoint] int  NULL,
    [btUnKnow2] varbinary(3)  NULL,
    [nBonusPoint] int  NULL,
    [btF9] tinyint  NULL,
    [btIncHealth] tinyint  NULL,
    [btIncSpell] tinyint  NULL,
    [btIncHealing] tinyint  NULL,
    [btEF] tinyint  NULL,
    [wContribution] int  NULL,
    [nHungerStatus] int  NULL,
    [btLastOutStatus] tinyint  NULL,
    [btStatus] tinyint  NULL,
    [UnKnow] varbinary(30)  NULL,
    [HumMagicsBuff] varbinary(240)  NULL,
    [HumAddItemsBuff] varbinary(160)  NULL,
    [n_WinExp] int  NULL,
    [n_UsesItemTick] int  NULL,
    [nReserved] int  NULL,
    [nReserved1] int  NULL,
    [nReserved2] int  NULL,
    [nReserved3] int  NULL,
    [n_Reserved] int  NULL,
    [n_Reserved1] int  NULL,
    [n_Reserved2] int  NULL,
    [n_Reserved3] int  NULL,
    [boReserved] bit  NULL,
    [boReserved1] bit  NULL,
    [boReserved2] bit  NULL,
    [boReserved3] bit  NULL,
    [m_GiveDate] int  NULL,
    [Exp68] int  NULL,
    [MaxExp68] int  NULL,
    [nExpSkill69] int  NULL,
    [HumNGMagicsBuff] varbinary(240)  NULL,
    [HumPulses] varbinary(50)  NULL,
    [HumBatterMagicsBuff] varbinary(32)  NULL,
    [m_btFHeroJob] tinyint  NULL,
    [m_btFHeroType] tinyint  NULL,
    [m_nReserved5] tinyint  NULL,
    [m_nReserved6] int  NULL,
    [m_nReserved7] int  NULL,
    [m_nReserved8] int  NULL
);
GO

-- Creating table 'HumInfo'
CREATE TABLE [dbo].[HumInfo] (
    [nID] int IDENTITY(1,1) NOT NULL,
    [boDeleted] bit  NULL,
    [nSelectID] tinyint  NULL,
    [boIsHero] bit  NULL,
    [bt2] tinyint  NULL,
    [dCreateDate] float  NULL,
    [sName] varchar(15)  NULL,
    [sChrName] varchar(14)  NULL,
    [sAccount] varchar(50)  NULL,
    [boDeleted1] bit  NULL,
    [boIsHero1] bit  NULL,
    [dModDate] float  NULL,
    [btCount] tinyint  NULL,
    [boSelected] bit  NULL,
    [n6] varbinary(6)  NULL
);
GO

-- Creating table 'TEST'
CREATE TABLE [dbo].[TEST] (
    [ID] int  NOT NULL,
    [NAME] varchar(50)  NULL
);
GO

-- Creating table 'UserStorageItems集'
CREATE TABLE [dbo].[UserStorageItems集] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [MakeIndex] nvarchar(max)  NOT NULL,
    [ItemNumber] nvarchar(max)  NOT NULL,
    [Dura] nvarchar(max)  NOT NULL,
    [MaxDura] nvarchar(max)  NOT NULL,
    [Attribute] tinyint  NOT NULL
);
GO

-- Creating table 'UserItemInfo集'
CREATE TABLE [dbo].[UserItemInfo集] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [MakeIndex] nvarchar(max)  NOT NULL,
    [ItemNumber] nvarchar(max)  NOT NULL,
    [Dura] nvarchar(max)  NOT NULL,
    [MaxDura] nvarchar(max)  NOT NULL,
    [Attribute] tinyint  NOT NULL
);
GO

-- Creating table 'UserInfo集'
CREATE TABLE [dbo].[UserInfo集] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [sAccount] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Sex] nvarchar(max)  NOT NULL,
    [Job] nvarchar(max)  NOT NULL,
    [Hair] nvarchar(max)  NOT NULL,
    [Dir] nvarchar(max)  NOT NULL,
    [GameGold] nvarchar(max)  NOT NULL,
    [GameDiaMond] nvarchar(max)  NOT NULL,
    [GameGird] nvarchar(max)  NOT NULL,
    [GamePoint] nvarchar(max)  NOT NULL,
    [GameGlory] nvarchar(max)  NOT NULL,
    [MasterCount] nvarchar(max)  NOT NULL,
    [MasterName] nvarchar(max)  NOT NULL,
    [DearName] nvarchar(max)  NOT NULL,
    [StoragePwd] nvarchar(max)  NOT NULL,
    [HeroName] nvarchar(max)  NOT NULL,
    [PkPoint] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserAttribute集'
CREATE TABLE [dbo].[UserAttribute集] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Level] int  NOT NULL,
    [Ac] int  NOT NULL,
    [Mac] int  NOT NULL,
    [Dc] int  NOT NULL,
    [Mc] int  NOT NULL,
    [Sc] int  NOT NULL,
    [Hp] int  NOT NULL,
    [Mp] int  NOT NULL,
    [MaxHp] int  NOT NULL,
    [MaxMp] int  NOT NULL,
    [Exp] int  NOT NULL,
    [MaxExp] int  NOT NULL,
    [Weight] int  NOT NULL,
    [MaxWeight] int  NOT NULL,
    [WearWeight] int  NOT NULL,
    [MaxWearWeight] int  NOT NULL,
    [HandWeight] int  NOT NULL,
    [MaxHandWeight] int  NOT NULL
);
GO

-- Creating table 'UserStatus集'
CREATE TABLE [dbo].[UserStatus集] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [ReLevel] nvarchar(max)  NOT NULL,
    [boMaster] nvarchar(max)  NOT NULL,
    [IsDelete] nvarchar(max)  NOT NULL,
    [IsSelect] nvarchar(max)  NOT NULL,
    [IsLockLogon] nvarchar(max)  NOT NULL,
    [HaveHero] nvarchar(max)  NOT NULL,
    [IsHero] nvarchar(max)  NOT NULL,
    [AttatckMode] nvarchar(max)  NOT NULL,
    [AllowGroup] nvarchar(max)  NOT NULL,
    [GroupRcallTime] nvarchar(max)  NOT NULL,
    [QuestFlag] tinyint  NOT NULL,
    [ExpRate] nvarchar(max)  NOT NULL,
    [ExpTime] nvarchar(max)  NOT NULL,
    [AllowGuildReCall] nvarchar(max)  NOT NULL,
    [AllowGroupReCall] nvarchar(max)  NOT NULL,
    [FightZoneDieCount] nvarchar(max)  NOT NULL,
    [IsDivorce] nvarchar(max)  NOT NULL,
    [MarryCount] nvarchar(max)  NOT NULL,
    [nLoyal] nvarchar(max)  NOT NULL,
    [PayMentPoint] nvarchar(max)  NOT NULL,
    [BodyLuck] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NakedAbility集'
CREATE TABLE [dbo].[NakedAbility集] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Dc] nvarchar(max)  NOT NULL,
    [Mc] nvarchar(max)  NOT NULL,
    [Sc] nvarchar(max)  NOT NULL,
    [Ac] nvarchar(max)  NOT NULL,
    [Mac] nvarchar(max)  NOT NULL,
    [Hp] nvarchar(max)  NOT NULL,
    [Mp] nvarchar(max)  NOT NULL,
    [Hit] nvarchar(max)  NOT NULL,
    [Speed] nvarchar(max)  NOT NULL,
    [X2] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserBagItemInfo集'
CREATE TABLE [dbo].[UserBagItemInfo集] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [MakeIndex] nvarchar(max)  NOT NULL,
    [ItemNumber] nvarchar(max)  NOT NULL,
    [Dura] nvarchar(max)  NOT NULL,
    [MaxDura] nvarchar(max)  NOT NULL,
    [Attribute] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [nId] in table 'HumDataInfo'
ALTER TABLE [dbo].[HumDataInfo]
ADD CONSTRAINT [PK_HumDataInfo]
    PRIMARY KEY CLUSTERED ([nId] ASC);
GO

-- Creating primary key on [nID] in table 'HumInfo'
ALTER TABLE [dbo].[HumInfo]
ADD CONSTRAINT [PK_HumInfo]
    PRIMARY KEY CLUSTERED ([nID] ASC);
GO

-- Creating primary key on [ID] in table 'TEST'
ALTER TABLE [dbo].[TEST]
ADD CONSTRAINT [PK_TEST]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserStorageItems集'
ALTER TABLE [dbo].[UserStorageItems集]
ADD CONSTRAINT [PK_UserStorageItems集]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserItemInfo集'
ALTER TABLE [dbo].[UserItemInfo集]
ADD CONSTRAINT [PK_UserItemInfo集]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfo集'
ALTER TABLE [dbo].[UserInfo集]
ADD CONSTRAINT [PK_UserInfo集]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserAttribute集'
ALTER TABLE [dbo].[UserAttribute集]
ADD CONSTRAINT [PK_UserAttribute集]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserStatus集'
ALTER TABLE [dbo].[UserStatus集]
ADD CONSTRAINT [PK_UserStatus集]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'NakedAbility集'
ALTER TABLE [dbo].[NakedAbility集]
ADD CONSTRAINT [PK_NakedAbility集]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserBagItemInfo集'
ALTER TABLE [dbo].[UserBagItemInfo集]
ADD CONSTRAINT [PK_UserBagItemInfo集]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------