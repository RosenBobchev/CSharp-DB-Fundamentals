WITH CTE_MechanicsAllParts(MechanicId, Count) AS
(
	SELECT m.MechanicId, SUM(op.Quantity) FROM Mechanics As m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	JOIN Orders AS o ON j.JobId = o.JobId
	JOIN OrderParts AS op ON o.OrderId = op.OrderId
	GROUP BY m.MechanicId
),

CTE_PartsByVendorMechanic(MechanicId, VendorId, VendorCount) AS
(
	SELECT m.MechanicId, v.VendorId, SUM(op.Quantity) FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	JOIN Orders AS o ON j.JobId = o.JobId
	JOIN OrderParts AS op ON o.OrderId = op.OrderId
	JOIN Parts as p ON op.PartId = p.PartId
	JOIN Vendors AS v ON p.VendorId = v.VendorId
	GROUP BY m.MechanicId, v.VendorId
)

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, 
	v.Name AS Vendor, 
	pv.VendorCount AS Parts, 
	CONCAT((pv.VendorCount * 100)/ap.Count, '%') AS Preference  
	FROM Mechanics AS m
JOIN CTE_MechanicsAllParts AS ap ON m.MechanicId = ap.MechanicId
JOIN CTE_PartsByVendorMechanic AS pv ON ap.MechanicId = pv.MechanicId
JOIN Vendors AS v ON pv.VendorId = v.VendorId
ORDER BY Mechanic, Parts DESC, Vendor