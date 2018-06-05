SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge) AS MinDepositCharge
  FROM WizzardDeposits AS w
 GROUP BY w.DepositGroup, w.MagicWandCreator