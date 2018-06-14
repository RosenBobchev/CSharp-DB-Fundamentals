SELECT c.CountryCode, mount.MountainRange, p.PeakName, p.Elevation
  FROM Countries AS c
  JOIN MountainsCountries AS m
    ON m.CountryCode = c.CountryCode AND m.CountryCode = 'BG'
  JOIN Peaks AS p
    ON p.MountainId = m.MountainId AND p.Elevation > 2835
  JOIN Mountains AS mount
	ON mount.Id = m.MountainId
 ORDER BY p.Elevation DESC