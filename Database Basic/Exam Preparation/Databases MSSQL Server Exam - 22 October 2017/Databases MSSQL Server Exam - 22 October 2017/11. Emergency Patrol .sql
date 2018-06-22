SELECT r.OpenDate, r.DESCRIPTION, u.Email AS [Reporter Email]
  FROM Reports AS r
  JOIN Users AS u
    ON u.Id = r.UserId
  JOIN Categories AS c
    ON c.Id = r.CategoryId
 WHERE r.CloseDate IS NULL AND LEN(r.DESCRIPTION) > 20 
						   AND r.DESCRIPTION LIKE '%str%'
						   AND c.DepartmentId IN(1, 4, 5)
 ORDER BY r.OpenDate, u.Email, r.Id