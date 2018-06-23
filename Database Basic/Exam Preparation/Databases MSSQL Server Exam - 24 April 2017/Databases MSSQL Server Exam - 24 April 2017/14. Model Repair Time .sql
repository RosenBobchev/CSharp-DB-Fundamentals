SELECT m.ModelId, m.[Name],
	   CAST(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS VARCHAR(5)) + ' days' AS [Average Service Time]	
  FROM Jobs AS j
  JOIN Models AS m
    ON m.ModelId = j.ModelId
 WHERE j.[Status] = 'Finished'
 GROUP BY m.ModelId, m.[Name]
 ORDER BY AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))