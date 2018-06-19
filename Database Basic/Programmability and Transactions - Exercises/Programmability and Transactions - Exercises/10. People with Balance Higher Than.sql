CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@Money DECIMAL(16, 2))
AS
SELECT ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name]
  FROM AccountHolders AS ah
  JOIN Accounts AS acc
    ON acc.AccountHolderId = ah.Id
 GROUP BY ah.FirstName, ah.LastName
 HAVING SUM(acc.Balance) > @Money