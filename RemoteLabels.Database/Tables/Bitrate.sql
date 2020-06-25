CREATE TABLE [Core].[Bitrate]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Bitrate] INT NOT NULL, 
    [Timestamp] DATETIME2(0) NOT NULL, 
    [Username] NVARCHAR(50) NOT NULL
)
GO

CREATE INDEX [IX_BITRATE_USERNAME] ON [Core].[Bitrate]([Username])