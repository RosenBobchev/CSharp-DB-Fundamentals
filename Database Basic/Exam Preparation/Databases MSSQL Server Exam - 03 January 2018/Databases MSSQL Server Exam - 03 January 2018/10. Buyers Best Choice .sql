SELECT m.Manufacturer, 
              m.Model, 
			  COUNT(o.VehicleId) AS TimesOrdered
  FROM Vehicles AS v
  JOIN Models AS m
    ON m.Id = v.ModelId
  LEFT JOIN Orders AS o
    ON o.VehicleId = v.Id
 GROUP BY m.Manufacturer, m.Model
 ORDER BY TimesOrdered DESC, m.Manufacturer DESC, m.Model ASC