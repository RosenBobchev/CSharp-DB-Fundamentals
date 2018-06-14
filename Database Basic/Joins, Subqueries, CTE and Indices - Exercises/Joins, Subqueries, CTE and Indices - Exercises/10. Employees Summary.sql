SELECT TOP(50) emp.EmployeeID,
	   emp.FirstName + ' ' + emp.LastName AS EmployeeName,
	   e.FirstName + ' ' + e.LastName AS ManagerName,
	   dept.Name AS DepartmentName
  FROM Employees AS emp
  JOIN Employees AS e
    ON e.EmployeeID = emp.ManagerID
  JOIN Departments AS dept
    ON dept.DepartmentID = emp.DepartmentID
 ORDER BY emp.EmployeeID ASC