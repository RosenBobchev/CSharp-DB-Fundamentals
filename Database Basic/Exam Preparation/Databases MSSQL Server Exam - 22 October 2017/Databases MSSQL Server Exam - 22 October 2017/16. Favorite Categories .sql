WITH CTE_Departments_With_Categories([Department Name], [Category Name], [Percentage])
AS (
SELECT d.[Name] AS [Department Name], c.[Name] AS [Category Name], COUNT(*) AS [Percentage]
  FROM Reports AS r
  JOIN Categories AS c
    ON c.Id = r.CategoryId
  JOIN Departments AS d
    ON d.Id = c.DepartmentId
 GROUP BY d.[Name], c.[Name]),

CTE_Departments_Total([Department Name], [Percentage])
AS(
 SELECT d.[Name] AS [Department Name], COUNT(*) AS [Percentage]
  FROM Reports AS r
  JOIN Categories AS c
    ON c.Id = r.CategoryId
  JOIN Departments AS d
    ON d.Id = c.DepartmentId
 GROUP BY d.[Name])

SELECT dc.[Department Name], 
       dc.[Category Name],
	   CAST(ROUND(CAST(dc.Percentage AS DECIMAL) / CAST(dt.Percentage AS DECIMAL) * 100, 0) AS INT) AS [Percentage]
  FROM CTE_Departments_With_Categories AS dc
  JOIN CTE_Departments_Total AS dt
    ON dt.[Department Name] = dc.[Department Name]
 ORDER BY dc.[Department Name], dc.[Category Name], dc.Percentage