SELECT Names, Emails, Bills, TownsName
FROM (
	SELECT ROW_NUMBER() OVER (PARTITION BY t.Name ORDER BY o.Bill DESC) AS OrderByHighestBill,
		   CONCAT(c.FirstName, ' ', c.LastName) AS Names,
		   c.Id AS ClientId, c.Email AS Emails, o.Bill AS Bills, t.Name AS TownsName 
	  FROM Orders AS o
	  JOIN Clients AS c
		ON c.Id = o.ClientId
	  JOIN Towns AS t
		ON t.Id = o.TownId
	 WHERE o.CollectionDate > c.CardValidity AND o.Bill IS NOT NULL
 ) AS H
 WHERE OrderByHighestBill IN (1, 2)
 ORDER BY TownsName, Bills, ClientId