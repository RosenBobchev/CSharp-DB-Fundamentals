CREATE FUNCTION ufn_IsWordComprised (@SetOfLetters NVARCHAR(MAX), @Word NVARCHAR(MAX))
 RETURNS BIT
AS
 BEGIN
	DECLARE @IsComprised BIT = 0;
	DECLARE @CurrentIndex INT = 1;
	DECLARE @CurrentChar CHAR;

	WHILE(@CurrentIndex <= LEN(@Word))
	 BEGIN
		SET @CurrentChar = SUBSTRING(@Word, @CurrentIndex, 1)
		IF(CHARINDEX(@CurrentChar, @SetOfLetters) = 0)
		 BEGIN
			RETURN @IsComprised;
		 END
	   SET @CurrentIndex += 1;
	 END

   RETURN @IsComprised + 1;
 END