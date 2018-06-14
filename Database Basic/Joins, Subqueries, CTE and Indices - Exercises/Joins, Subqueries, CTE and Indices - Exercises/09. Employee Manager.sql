SELECT emp.EmployeeID, emp.FirstName, emp.ManagerID, e.FirstName AS ManagerName
  FROM Employees AS emp
  JOIN Employees AS e
    ON e.EmployeeID = emp.ManagerID AND emp.ManagerID IN (3, 7)
 ORDER BY emp.EmployeeID ASC