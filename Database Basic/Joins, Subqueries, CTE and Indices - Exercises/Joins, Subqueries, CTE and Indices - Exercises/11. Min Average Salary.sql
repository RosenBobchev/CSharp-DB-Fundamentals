SELECT MIN(DepartmentSalary.AverageSalary) AS MinAverageSalary
  FROM 
(
   SELECT AVG(emp.Salary) AS AverageSalary
    FROM Employees AS emp
    GROUP BY emp.DepartmentID 
) AS DepartmentSalary

--OR

SELECT TOP(1) AVG(emp.Salary) AS MinAverageSalary
  FROM Employees AS emp
  GROUP BY emp.DepartmentID
 ORDER BY MinAverageSalary