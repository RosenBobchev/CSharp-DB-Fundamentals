SELECT Manufacturer, AverageConsumption
FROM (
	SELECT TOP(7) m.Model, m.Manufacturer,
			AVG(m.Consumption) AS AverageConsumption,
			COUNT(m.Model) AS [Counter]
	  FROM Orders AS o
	  JOIN Vehicles AS v
		ON v.Id = o.VehicleId
	  JOIN Models AS m
		ON m.Id = v.ModelId
	 GROUP BY m.Model, m.Manufacturer
	 ORDER BY [Counter] DESC
 ) AS H
 WHERE AverageConsumption BETWEEN 5 AND 15
 ORDER BY Manufacturer, AverageConsumption