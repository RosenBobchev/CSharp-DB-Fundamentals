SELECT emp.FirstName + ' ' + emp.LastName AS [Name], COUNT(r.UserId) AS [Users Number]
  FROM Reports AS r
  RIGHT JOIN Employees AS emp
    ON emp.Id = r.EmployeeId
 GROUP BY FirstName, LastName
 ORDER BY [Users Number] DESC, [Name] ASC