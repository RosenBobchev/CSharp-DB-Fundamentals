CREATE TRIGGER tr_addQuantities ON Orders AFTER UPDATE AS
BEGIN
	UPDATE Parts
	SET StockQty += op.Quantity
	FROM deleted AS d
	JOIN inserted AS i
	ON d.OrderId = i.OrderId
	JOIN OrderParts AS op
	ON i.OrderId = op.OrderId
	WHERE d.Delivered = 0 AND i.Delivered = 1 AND Parts.PartId = op.PartId
END