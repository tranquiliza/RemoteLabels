CREATE PROCEDURE [Core].[InsertPosition]
	@latitude decimal(12,9),
	@longitude decimal(12,9),
	@timeStamp datetime2,
	@username nvarchar(50)
AS
BEGIN
	INSERT INTO [Core].[Position] 
		([Latitude], [Longitude], [Timestamp], [Username])
	VALUES 
		(@latitude, @longitude, @timeStamp, @username)
END
