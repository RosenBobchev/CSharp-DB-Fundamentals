SELECT TOP(5) emp.EmployeeID, emp.FirstName, p.Name
  FROM Employees AS emp
  JOIN EmployeesProjects AS e
    ON e.EmployeeID = emp.EmployeeID
  JOIN Projects AS p
    ON p.ProjectID = e.ProjectID AND p.StartDate > '08/13/2002' AND p.EndDate IS NULL
 ORDER BY emp.EmployeeID ASC