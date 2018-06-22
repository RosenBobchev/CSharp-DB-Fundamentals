CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
  BEGIN TRAN
	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Reports.Id = @reportId

	DECLARE @employeeCategory INT = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
	DECLARE @reportCategory INT = (SELECT c.DepartmentId FROM Reports AS r 
									 JOIN Categories AS c 
									 ON c.Id = r.CategoryId WHERE r.Id = @reportId)

	IF(@employeeCategory != @reportCategory)
	 BEGIN
		ROLLBACK
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
	 END
  COMMIT
GO

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 2