SELECT TOP(3) CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
			  COUNT(*) AS Jobs
  FROM Mechanics AS m
  JOIN Jobs AS j
    ON j.MechanicId = m.MechanicId
 GROUP BY m.FirstName, m.LastName, j.FinishDate, m.MechanicId
 HAVING COUNT(*) > 1 AND j.FinishDate IS NULL
 ORDER BY Jobs DESC, m.MechanicId