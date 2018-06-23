SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available
  FROM Mechanics AS m
 LEFT JOIN Jobs AS j
    ON j.MechanicId = m.MechanicId
 WHERE j.[Status] LIKE 'Finished' OR j.[Status] IS NULL
 GROUP BY m.FirstName, m.LastName, m.MechanicId
 ORDER BY m.MechanicId