SELECT PeakName, RiverName, LOWER(SUBSTRING (PeakName, 1, LEN(PeakName) - 1)+ RiverName) AS MIX
  FROM Peaks, Rivers
 WHERE RIGHT(PeakName, 1) = LEFT(Rivername, 1)
 ORDER BY MIX ASC