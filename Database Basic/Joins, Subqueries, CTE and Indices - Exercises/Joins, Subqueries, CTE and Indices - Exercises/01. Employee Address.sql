SELECT TOP(5) emp.EmployeeID, emp.JobTitle, emp.AddressID, a.AddressText
  FROM Employees AS emp
  JOIN Addresses AS a
    ON a.AddressID = emp.AddressID
 ORDER BY emp.AddressID ASC