CREATE PROCEDURE [Core].[InsertBitrate]
	@bitrate INT,
	@timestamp DATETIME2(0),
	@username NVARCHAR(50)
AS
BEGIN
	INSERT INTO [Core].[Bitrate] ([Bitrate], [Timestamp], [Username])
	VALUES (@bitrate, @timestamp, @username)
END