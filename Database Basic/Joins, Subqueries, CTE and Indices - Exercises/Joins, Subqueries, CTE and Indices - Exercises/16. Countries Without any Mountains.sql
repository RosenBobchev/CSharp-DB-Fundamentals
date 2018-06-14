SELECT COUNT(*)
  FROM Countries AS c
 LEFT JOIN MountainsCountries AS m
   ON m.CountryCode = c.CountryCode
 WHERE m.CountryCode IS NULL