CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
 ALTER TABLE Departments
  ALTER COLUMN ManagerID INT NULL

 DELETE FROM EmployeesProjects
  WHERE EmployeeID IN
   (
	  SELECT EmployeeID
	    FROM Employees
	   WHERE DepartmentID = @DepartmentId
   )

 UPDATE Employees
    SET ManagerID = NULL
  WHERE ManagerID IN
   (
      SELECT EmployeeID
	    FROM Employees
	   WHERE DepartmentID = @DepartmentId
   )

 UPDATE Departments
    SET ManagerID = NULL
  WHERE ManagerID IN
   (
	  SELECT EmployeeID
	    FROM Employees
	   WHERE DepartmentID = @DepartmentId
   )

 DELETE FROM Employees
  WHERE EmployeeID IN
   (
	  SELECT EmployeeID
	    FROM Employees
	   WHERE DepartmentID = @DepartmentId
   )

 DELETE FROM Departments
  WHERE DepartmentID = @DepartmentId

 SELECT COUNT(*) AS [Employee Count]
   FROM Employees AS e
   JOIN Departments AS d
     ON d.DepartmentID = e.DepartmentID
  WHERE e.DepartmentID = @DepartmentId