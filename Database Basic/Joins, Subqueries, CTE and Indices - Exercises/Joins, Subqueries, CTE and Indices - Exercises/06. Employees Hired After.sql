SELECT  emp.FirstName, emp.LastName, emp.HireDate, dept.Name AS DeptName
  FROM Employees AS emp
  JOIN Departments AS dept
    ON dept.DepartmentID = emp.DepartmentID
 WHERE emp.HireDate > '1/1/1999' AND
	   dept.Name IN ('Finance', 'Sales')
 ORDER BY emp.HireDate ASC