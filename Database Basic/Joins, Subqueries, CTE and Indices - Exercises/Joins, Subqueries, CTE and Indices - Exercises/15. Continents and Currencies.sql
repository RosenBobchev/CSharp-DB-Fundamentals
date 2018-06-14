WITH CTE_CountriesInfo (ContinentCode, CurrencyCode, CurrencyUsage) AS (
SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage
  FROM Countries
 GROUP BY ContinentCode, CurrencyCode
 HAVING COUNT(CurrencyCode) > 1 )

 SELECT e.ContinentCode, cci.CurrencyCode, e.MaxCurrency AS CurrencyUsage
   FROM (
 SELECT ContinentCode, MAX(CurrencyUsage) AS MaxCurrency
   FROM CTE_CountriesInfo
 GROUP BY ContinentCode ) AS e
   JOIN CTE_CountriesInfo AS cci
     ON cci.ContinentCode = e.ContinentCode
	AND cci.CurrencyUsage = e.MaxCurrency