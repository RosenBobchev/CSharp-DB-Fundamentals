CREATE FUNCTION ufn_GetSalaryLevel (@Salary DECIMAL(18, 4))
RETURNS VARCHAR(10)
AS
	BEGIN
		DECLARE @SalaryLevel VARCHAR(10);
		
		IF(@Salary < 30000)
		BEGIN
			SET @SalaryLevel = 'Low'
		END
		ELSE IF(@Salary BETWEEN 30000 AND 50000)
		BEGIN
			SET @SalaryLevel = 'Average'
		END
		ELSE
		BEGIN
			SET @SalaryLevel = 'High'
		END

		RETURN @SalaryLevel
	END

GO

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
  FROM Employees
 ORDER BY Salary