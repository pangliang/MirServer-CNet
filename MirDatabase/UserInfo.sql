CREATE TABLE [dbo].[UserInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Deleted] TINYINT NULL, 
	[Selected] TINYINT NULL,
    [SelectID] TINYINT NULL, 
    [isHero] TINYINT NULL, 
    [ChrName] NVARCHAR(50) NULL, 
    [Account] NVARCHAR(50) NULL, 
	[CreateDate] DATETIME NULL, 
    [ModDate] DATETIME NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户信息',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserInfo',
    @level2type = NULL,
    @level2name = NULL