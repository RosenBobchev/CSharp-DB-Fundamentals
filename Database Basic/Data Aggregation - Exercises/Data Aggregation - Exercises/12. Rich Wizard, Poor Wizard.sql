SELECT SUM(e.Diff) AS SumDifference FROM (
SELECT w.DepositAmount - (
	LEAD(DepositAmount) OVER (ORDER BY Id)
  ) AS Diff
  FROM WizzardDeposits AS w
) AS e

-- OR THIS

SELECT SUM(e.Diff) AS SumDifference FROM (
SELECT w.DepositAmount - (
	SELECT DepositAmount 
	  FROM WizzardDeposits
	 WHERE Id = w.Id + 1
  ) AS Diff
  FROM WizzardDeposits AS w
) AS e