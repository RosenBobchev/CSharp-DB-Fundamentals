SELECT FirstName
  FROM Employees
 WHERE HireDate BETWEEN '01/01/1995' AND '12/31/2005' AND DepartmentId IN (3, 10)