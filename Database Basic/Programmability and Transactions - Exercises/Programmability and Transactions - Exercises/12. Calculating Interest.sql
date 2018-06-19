CREATE PROCEDURE usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT)
AS
 BEGIN
	DECLARE @Years INT = 5;

	 SELECT ah.Id AS [Account ID],
			ah.FirstName AS [First Name],
			ah.LastName AS [Last Name],
			acc.Balance AS [Current Balance],
			dbo.ufn_CalculateFutureValue(acc.Balance, @InterestRate, @Years) AS [Balance in 5 years]
	   FROM AccountHolders AS ah
	   JOIN Accounts AS acc
	     ON acc.AccountHolderId = ah.Id
	  WHERE acc.Id = @AccountId
 END

EXEC usp_CalculateFutureValueForAccount 1, 0.10