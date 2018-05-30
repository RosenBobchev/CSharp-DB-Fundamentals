ALTER TABLE Users
ADD CONSTRAINT DF_Date DEFAULT GETDATE() FOR LastLongTime

UPDATE Users SET LastLongTime = DEFAULT WHERE LastLongTime IS NULL

ALTER TABLE Users
ALTER COLUMN LastLongTime DATETIME2 NOT NULL