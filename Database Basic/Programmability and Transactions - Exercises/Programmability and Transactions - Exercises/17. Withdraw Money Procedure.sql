CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN
		DECLARE @Balance MONEY = (SELECT Balance 
								    FROM Accounts
								   WHERE Id = @AccountId)
		BEGIN TRANSACTION
			UPDATE Accounts
			SET Balance -= @MoneyAmount
			WHERE Id = @AccountId

			IF(@Balance - @MoneyAmount < 0 OR @@ROWCOUNT != 1)
			BEGIN
				ROLLBACK
				RAISERROR('Cannot complete operation', 16, 1)
				RETURN
			END
		COMMIT
	END