CREATE PROCEDURE usp_GetTownsStartingWith (@Letter VARCHAR(10))
AS
SELECT Name 
  FROM Towns
 WHERE Name LIKE @Letter + '%'

 EXEC usp_GetTownsStartingWith b