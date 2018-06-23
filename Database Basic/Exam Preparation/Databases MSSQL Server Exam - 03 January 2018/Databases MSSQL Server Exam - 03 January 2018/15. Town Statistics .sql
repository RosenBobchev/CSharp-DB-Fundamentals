SELECT t.[Name] AS TownName,
	   (SUM(H.m) * 100) / (ISNULL(SUM(H.m), 0) + ISNULL(SUM(H.f), 0)) AS MalePercent,
	   (SUM(H.f) * 100) / (ISNULL(SUM(H.m), 0) + ISNULL(SUM(H.f), 0)) AS FemalePercent
FROM(
	SELECT o.TownId, 
		   CASE WHEN (Gender = 'M') THEN COUNT(o.Id) ELSE NULL END AS m,
		   CASE WHEN (Gender = 'F') THEN COUNT(o.Id) ELSE NULL END AS f
	  FROM Orders AS o
	  JOIN Clients AS c
		ON c.Id = o.ClientId
	 GROUP BY c.Gender, o.TownId
 ) AS H
 JOIN Towns AS t
   ON t.Id = H.TownId
 GROUP BY t.Name