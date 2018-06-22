SELECT c.Name, COUNT(*) AS [Employees Number]
  FROM Employees AS emp
  JOIN Categories AS c
    ON c.DepartmentId = emp.DepartmentId
 GROUP BY c.Name
 ORDER BY c.Name