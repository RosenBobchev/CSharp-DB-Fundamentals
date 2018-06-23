SELECT ISNULL(SUM(op.Quantity * p.Price), 0) AS [Parts Total]
  FROM Parts AS p
  JOIN OrderParts AS op
    ON op.PartId = p.PartId
  JOIN Orders AS o
    ON o.OrderId = op.OrderId
 WHERE o.IssueDate BETWEEN DATEADD(WEEK, -3, '2017-04-24') AND '2017-04-24'