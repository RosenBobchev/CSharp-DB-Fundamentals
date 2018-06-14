SELECT TOP(50) emp.FirstName, emp.LastName,t.Name AS Town , a.AddressText
  FROM Employees AS emp
  JOIN Addresses AS a
    ON a.AddressID = emp.AddressID
  JOIN Towns AS t
    ON t.TownID = a.TownID
 ORDER BY emp.FirstName, emp.LastName