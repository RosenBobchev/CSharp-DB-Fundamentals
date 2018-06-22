SELECT emp.FirstName, 
        emp.LastName, 
	   r.DESCRIPTION, 
	   FORMAT(r.OpenDate, 'yyyy-MM-dd') AS OpenDate
  FROM Reports AS r
  JOIN Employees AS emp
    ON emp.Id = r.EmployeeId
 WHERE r.EmployeeId IS NOT NULL
 ORDER BY r.EmployeeId, r.OpenDate, r.Id