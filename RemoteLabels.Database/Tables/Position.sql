CREATE TABLE [Core].[Position]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Latitude] FLOAT NOT NULL, 
    [Longitude] FLOAT NOT NULL, 
    [Altitude] FLOAT NOT NULL, 
    [Timestamp] DATETIME2(0) NOT NULL, 
    [Username] NVARCHAR(50) NOT NULL
)
GO

CREATE INDEX [IX_POSITION_USERNAME] ON [Core].[Position](Username)