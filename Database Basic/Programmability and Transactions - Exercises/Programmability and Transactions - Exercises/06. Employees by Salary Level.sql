CREATE PROCEDURE usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(10))
AS
SELECT FirstName, LastName 
  FROM Employees
 WHERE @SalaryLevel = dbo.ufn_GetSalaryLevel(Salary)