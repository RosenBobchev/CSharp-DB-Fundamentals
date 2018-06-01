SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
  FROM Games
 WHERE [Start] BETWEEN '01/01/2011' AND '12/31/2012'
 ORDER BY [Start], [Name]