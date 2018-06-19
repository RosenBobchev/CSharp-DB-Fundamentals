CREATE TABLE Logs (
	LogId INT NOT NULL,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL

	CONSTRAINT PK_LogId PRIMARY KEY (LogId)
	CONSTRAINT FK_AccountId_Accounts
	FOREIGN KEY (AccountId) REFERENCES Accounts (Id)
)

GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts AFTER UPDATE
AS
	INSERT INTO Logs
	SELECT inserted.Id, deleted.Balance, inserted.Balance
	  FROM inserted
	  JOIN deleted
	    ON inserted.Id = deleted.Id

GO

UPDATE Accounts
SET Balance -= 10
WHERE Id = 1