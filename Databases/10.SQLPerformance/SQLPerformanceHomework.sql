/*USE MASTER
GO

CREATE DATABASE TESTDB
GO

USE TESTDB
GO

CREATE TABLE Test(
  Id INT PRIMARY KEY IDENTITY NOT NULL,
  TheDate datetime,
  TheText nvarchar(100),
)

GO

CREATE PROC usp_Add1MilionLogs
AS
DECLARE @count INT
DECLARE @text nvarchar(50)
SET @count = 1
WHILE(@count < 100000) -- Sorry, I have a very old computer and cannot wait days to generate 10 mln elements 
BEGIN
  DECLARE @Date DATETIME
	SET @Date = 
	DATEADD(MONTH, CONVERT(varbinary, newid()) % (50 * 12), getdate())
	SET @text = CAST(@count AS NVARCHAR) + 'Record' + CAST(@count AS NVARCHAR)
	INSERT INTO Test (TheDate, TheText)	VALUES(@Date, @text)
	SET @count = @count + 1
END
GO

EXEC usp_Add1MilionLogs */

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Clear cache

--TASK 1
SELECT TheDate FROM Test
WHERE YEAR(TheDate) < 2012 AND YEAR(TheDate) > 2001

--TASK 2

CREATE INDEX IDX_TheDate ON Test(TheDate)
GO

SELECT TheDate
FROM Test
WHERE YEAR(TheDate) < 2012 AND YEAR(TheDate) > 2001

--TASK 3
DROP INDEX IDX_TheDate ON Test
GO

SELECT TheText
FROM Test
WHERE TheText LIKE '%1'
ORDER BY TheText

CREATE INDEX IDX_TheText ON Test(TheText)
GO

SELECT TheText
FROM Test
WHERE TheText LIKE '%1'
ORDER BY TheText

DROP INDEX IDX_TheText ON Test
GO
