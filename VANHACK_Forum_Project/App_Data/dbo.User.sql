CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [Birth_Date] DATE NOT NULL, 
    [Creat_Date] DATETIME NULL DEFAULT getdate()
)
