SELECT emp.EmployeeID, emp.FirstName, emp.LastName, dept.Name
  FROM Employees AS emp
  JOIN Departments AS dept
    ON dept.DepartmentID = emp.DepartmentID AND dept.Name = 'Sales'
 ORDER BY emp.EmployeeID