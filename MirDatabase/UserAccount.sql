CREATE TABLE [dbo].[UserAccount]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Account] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL, 
    [CHID] NVARCHAR(50) NULL, 
    [UserName] NVARCHAR(50) NULL, 
    [EMAIL] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [MobilePhone] NVARCHAR(50) NULL, 
    [Birthday] DATETIME NULL, 
    [Question1] NVARCHAR(50) NULL, 
    [Answer1] NVARCHAR(50) NULL, 
    [Question2] NVARCHAR(50) NULL, 
    [Answer2] NVARCHAR(50) NULL, 
    [Deleted] TINYINT NULL, 
    [CreateDate] DATETIME NULL, 
    [UpdateDate] DATETIME NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'账号信息',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UserAccount',
    @level2type = NULL,
    @level2name = NULL