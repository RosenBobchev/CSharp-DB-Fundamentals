SELECT c.CountryCode, COUNT(m.MountainId) AS MountainRanges
  FROM Countries AS c
  JOIN MountainsCountries AS m
    ON m.CountryCode = c.CountryCode AND m.CountryCode IN ('BG', 'RU', 'US')
 GROUP BY c.CountryCode