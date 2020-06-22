CREATE PROCEDURE [Core].[GetLatestPositionForUser]
	@username NVARCHAR(50)
AS
BEGIN
	SELECT TOP (1) [Latitude], [Longitude], [Altitude], [Timestamp], [Username] 
	FROM [Core].[Position]
	WHERE Username = @username
	ORDER BY [Timestamp] DESC
END