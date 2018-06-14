SELECT TOP(5) c.CountryName, r.RiverName
  FROM Countries AS c
  LEFT JOIN CountriesRivers AS rivers
    ON rivers.CountryCode = c.CountryCode
  LEFT JOIN Rivers AS r
    ON r.Id = rivers.RiverId
 WHERE c.ContinentCode = 'AF'
 ORDER BY c.CountryName ASC