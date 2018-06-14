SELECT TOP(3) emp.EmployeeID, emp.FirstName
  FROM Employees AS emp
 LEFT JOIN EmployeesProjects AS e
    ON e.EmployeeID = emp.EmployeeID
 WHERE e.EmployeeID IS NULL
 ORDER BY emp.EmployeeID ASC