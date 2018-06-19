CREATE PROC usp_AssignProject(@EmployeeId INT, @ProjectId INT)
AS
	BEGIN
		BEGIN TRAN
			INSERT INTO EmployeesProjects
			VALUES (@EmployeeId, @ProjectId)
				IF(SELECT COUNT(ProjectId)
					 FROM EmployeesProjects
					WHERE EmployeeId = @EmployeeId) > 3
				BEGIN
					RAISERROR ('The employee has too many projects!', 16, 1)
					ROLLBACK
					RETURN
				END
		COMMIT
	END