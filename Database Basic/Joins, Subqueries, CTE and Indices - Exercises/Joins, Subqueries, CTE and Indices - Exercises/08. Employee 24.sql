SELECT emp.EmployeeID, emp.FirstName,
  CASE 
  WHEN p.StartDate > '01/01/2005' THEN NULL
  ELSE p.Name
  END AS ProjectName
  FROM Employees AS emp
  JOIN EmployeesProjects AS e
    ON e.EmployeeID = emp.EmployeeID AND e.EmployeeID = 24
  JOIN Projects AS p
    ON p.ProjectID = e.ProjectID