CREATE FUNCTION [dbo].[GetCustomerId]()
RETURNS INT
AS
BEGIN
	DECLARE @id INT;

	DELETE TOP (1) dbo.RandomNumber
	OUTPUT deleted.Value INTO @id;

	RETURN @id;
END;