SELECT e.DepartmentId, SUM(e.Salary) AS TotalSalary
  FROM Employees AS e
 GROUP BY e.DepartmentId
 ORDER BY e.DepartmentId