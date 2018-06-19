CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(MAX))
 RETURNS TABLE
AS
 RETURN SELECT SUM(Cash) AS SumCash
   FROM (
			SELECT ug.Cash,
				   ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
			  FROM UsersGames AS ug
			  JOIN Games AS g
			    ON g.Id = ug.GameId
			 WHERE g.Name = @GameName
		) AS CashList
  WHERE RowNumber % 2 = 1