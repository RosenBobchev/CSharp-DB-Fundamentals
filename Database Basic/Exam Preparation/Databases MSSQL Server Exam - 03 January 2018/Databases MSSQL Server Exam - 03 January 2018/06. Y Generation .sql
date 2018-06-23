SELECT FirstName, LastName
  FROM Clients
 WHERE BirthDate BETWEEN '01/01/1977' AND '12/31/1994'
 ORDER BY FirstName, LastName, Id