SELECT TOP(5) emp.EmployeeID, emp.FirstName, emp.Salary, dept.Name
  FROM Employees AS emp
  JOIN Departments AS dept
    ON dept.DepartmentID = emp.DepartmentID AND emp.Salary > 15000
 ORDER BY dept.DepartmentID ASC