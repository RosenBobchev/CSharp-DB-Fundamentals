WITH CTE_CountriesInfo (CountryName, PeakName, Elevation, MountainRange) AS (
SELECT c.CountryName, p.PeakName, MAX(p.Elevation), m.MountainRange 
  FROM Countries AS c
 LEFT JOIN MountainsCountries AS mc
    ON mc.CountryCode = c.CountryCode
 LEFT JOIN Mountains AS m
    ON m.Id = mc.MountainId
 LEFT JOIN Peaks AS p
    ON p.MountainId = m.Id
 GROUP BY c.CountryName, p.PeakName, m.MountainRange)

 SELECT TOP(5) e.CountryName, 
			   ISNULL(cci.PeakName, '(no highest peak)') AS [Highest Peak Name], 
			   ISNULL(cci.Elevation, 0) AS [Highest Peak Elevation], 
			   ISNULL(cci.MountainRange, '(no mountain)') AS [Mountain]
   FROM (
 SELECT CountryName, MAX(Elevation) AS MaxElevtaion
   FROM CTE_CountriesInfo
 GROUP BY CountryName )AS e
 LEFT JOIN CTE_CountriesInfo AS cci ON cci.CountryName = e.CountryName 
                                    AND cci.Elevation = e.MaxElevtaion
 ORDER BY e.CountryName, cci.PeakName