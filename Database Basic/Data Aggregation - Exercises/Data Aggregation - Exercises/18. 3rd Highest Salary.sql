SELECT DISTINCT DepartmentId, Salary AS ThirdHighestSalary
  FROM
	(
		SELECT DepartmentId, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) RowNumber FROM Employees
	) Employees
WHERE RowNumber = 3