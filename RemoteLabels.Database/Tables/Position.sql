CREATE TABLE [Core].[Position]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Latitude] DECIMAL(12, 9) NOT NULL, 
    [Longitude] DECIMAL(12, 9) NOT NULL, 
    [Timestamp] DATETIME2 NOT NULL, 
    [Username] NVARCHAR(50) NOT NULL
)
