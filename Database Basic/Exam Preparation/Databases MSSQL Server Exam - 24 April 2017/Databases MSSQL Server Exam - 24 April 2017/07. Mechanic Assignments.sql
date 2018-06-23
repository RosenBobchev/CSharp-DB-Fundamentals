SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   j.[Status], j.IssueDate
  FROM Jobs AS j
  JOIN Mechanics AS m
    ON m.MechanicId = j.MechanicId
 ORDER BY j.MechanicId, j.IssueDate, j.JobId