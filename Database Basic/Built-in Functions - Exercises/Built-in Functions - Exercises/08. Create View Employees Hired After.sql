CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
  FROM Employees
 WHERE HireDate >= '01/01/2001'

 SELECT * FROM V_EmployeesHiredAfter2000