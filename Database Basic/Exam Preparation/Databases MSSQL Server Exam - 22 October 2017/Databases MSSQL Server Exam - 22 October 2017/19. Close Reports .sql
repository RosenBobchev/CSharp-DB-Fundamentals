CREATE TRIGGER tr_ChangeStatus ON Reports AFTER UPDATE
AS
	UPDATE Reports
	SET StatusId = 3
	FROM deleted AS d
	JOIN inserted AS i
	  ON i.Id = d.Id
	WHERE i.CloseDate IS NOT NULL