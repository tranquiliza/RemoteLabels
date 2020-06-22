CREATE PROCEDURE [Core].[InsertPosition]
	@latitude float,
	@longitude float,
	@altitude float,
	@timeStamp datetime2(0),
	@username nvarchar(50)
AS
BEGIN
	INSERT INTO [Core].[Position] 
		([Latitude], [Longitude], [Altitude], [Timestamp], [Username])
	VALUES 
		(@latitude, @longitude, @altitude, @timeStamp, @username)
END
