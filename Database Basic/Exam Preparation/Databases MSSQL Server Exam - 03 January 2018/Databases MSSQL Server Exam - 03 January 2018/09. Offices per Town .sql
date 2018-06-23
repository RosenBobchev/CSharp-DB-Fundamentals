SELECT t.[Name] AS TownName, COUNT(*) AS OfficesNumber
  FROM Offices AS o
  JOIN Towns AS t
    ON t.Id = o.TownId
 GROUP BY t.[Name]
 ORDER BY OfficesNumber DESC, TownName ASC