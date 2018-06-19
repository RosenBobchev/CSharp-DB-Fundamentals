CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Salary DECIMAL(18,2))
AS
SELECT FirstName, LastName
  FROM Employees
 WHERE Salary >= @Salary

 EXEC usp_GetEmployeesSalaryAboveNumber 48100