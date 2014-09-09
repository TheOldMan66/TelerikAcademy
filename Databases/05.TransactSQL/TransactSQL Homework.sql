USE master
GO
DROP DATABASE TestBank
GO
CREATE DATABASE TestBank
GO
USE TestBank
GO

/* TASK 1: Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
  and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. */

CREATE TABLE Persons(
	ID int IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN NVARCHAR(20) NOT NULL
	)
GO

CREATE TABLE Accounts(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	PersonID INT FOREIGN KEY REFERENCES Persons(ID) NOT NULL,
	Balance MONEY NOT NULL
	)
GO

INSERT INTO PERSONS (FirstName, LastName, SSN) VALUES 
('Stamat', 'Ivanov', '0000000000'),
('Peshko', 'Petrov', '1111111111'),
('Goshko', 'Georgiev','2222222222')
GO

INSERT INTO Accounts (PersonID, Balance) VALUES 
('1', 100),
('3', 500),
('2', 200),
('3', 0),
('1', 300)

GO

/* Task1:  Write a stored procedure that selects the full names of all persons. */
CREATE PROC usp_GetFullName
AS
  SELECT FirstName + ' ' + LastName as FullName
  FROM Persons
GO

/* TASK 2: Create a stored procedure that accepts a number as a parameter and returns 
all persons who have more money in their accounts than the supplied number */
CREATE PROC usp_BalanceGretherThan (@minBalance money)
AS
  SELECT p.FirstName + ' ' + p.LastName as FullName, a.Balance
  FROM Persons p
	JOIN Accounts a
	ON p.ID = a.PersonID
	WHERE a.Balance > @minBalance
GO

/* Task 3: Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
    It should calculate and return the new sum. */

CREATE FUNCTION ufn_Interest(@startSum money, @Period int, @yearInterest money)
RETURNS money 
AS 
BEGIN
    RETURN @startSum *( 1 + (@yearInterest/12*@period))
END
GO

/* TASK 5: Add two more stored procedures WithdrawMoney( AccountId, money) 
and DepositMoney (AccountId, money) that operate in transactions. */
CREATE PROC usp_WithdrwMoney(@accountID int, @amount money)
AS
	BEGIN TRANSACTION
	DECLARE @oldAmount money
	SET @oldAmount = (
		SELECT Balance FROM Accounts
		WHERE ID = @accountID
		)
	IF @oldAmount-@amount < 0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END
	UPDATE Accounts
	SET Balance = @oldAmount - @amount
	WHERE ID = @accountID
	IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END
	COMMIT TRANSACTION
GO

CREATE PROC usp_DepositMoney(@accountID int, @amount money)
AS
	BEGIN TRANSACTION
	DECLARE @oldAmount money
	SET @oldAmount = (
		SELECT Balance FROM Accounts
		WHERE ID = @accountID
		)
	UPDATE Accounts
	SET Balance = @oldAmount + @amount
	WHERE ID = @accountID
	IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END
	COMMIT TRANSACTION
GO

/* Task 6: Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table 
that enters a new entry into the Logs table every time the sum on an account changes.*/
	CREATE TABLE Logs(
		LogID int IDENTITY,
		AccountID int NOT NULL,
		OldSum money NOT NULL,
		NewSum money NOT NULL,
		CONSTRAINT Pk_Logs PRIMARY KEY(LogID)
	)
GO

CREATE TRIGGER tr_OnAccountBalanceChange
ON Accounts FOR UPDATE 
AS
DECLARE 	
	@sumBefore int,  
	@accId int,  
	@sumAfter int
		SELECT @sumBefore = d.Balance,
		@sumAfter = i.Balance,
		@accId = i.PersonId
	From deleted d 
		JOIN inserted i   
		ON d.Id = i.Id
	WHERE d.Balance <> i.Balance
	
INSERT INTO LOGS (AccountID, OldSum, NewSum)
	VALUES (@accId, @sumBefore, @sumAfter)
GO

/* Task 1 */
EXEC usp_GetFullName

/* Task 2 */
EXEC usp_BalanceGretherThan 200

/* Task 4 (but for 18 monts, not for 1 :) Year interest = 12% (1% / month) */
SELECT p.FirstName, p.LastName, a.Balance, dbo.ufn_Interest(a.Balance,18,0.12) AS [Balance after 18 months] From Persons p
	JOIN Accounts a
	ON p.ID = a.PersonID

/* Task 5 */
EXEC usp_WithdrwMoney 10,100
EXEC usp_DepositMoney 10,200


/* Task 7. Define a function in the database TelerikAcademy that returns all Employee's	
 names (first or middle or last name) and all town's names that are comprised of
 given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith',
 … but not 'Rob' and 'Guy'.*/

USE [TelerikAcademy]
GO

CREATE FUNCTION [dbo].ufn_StringComprisedOf(@inputString nvarchar(50), @letterSet nvarchar(100))
  RETURNS BIT
AS
  BEGIN
	DECLARE @inputStringLenght int
	DECLARE @currentIndex int
	DECLARE @input nvarchar(50)
	DECLARE @pattern nvarchar(100)
	SET @inputStringLenght = LEN(@inputString)
	SET @currentIndex = 1
	SET @input = LOWER(@inputString)
	SET @pattern = LOWER(@letterSet)

	WHILE @currentIndex <= @inputStringLenght
	  BEGIN
		IF(CHARINDEX(SUBSTRING(@input,@currentindex,1),@pattern)=0)
		  BEGIN
			RETURN 0
		  END
		SET @currentIndex = @currentIndex +1
	  END
	RETURN 1
  END
GO


CREATE FUNCTION [dbo].ufn_EmployeesAndTownsNameComprisedOf(@letterSet nvarchar(100))
  RETURNS @resulst_table TABLE (name nvarchar(50))
AS
BEGIN
DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT Name FROM (
  SELECT FirstName AS Name FROM Employees
  UNION
  SELECT MiddleName AS Name FROM Employees
  UNION
  SELECT LastName AS Name FROM Employees
  UNION
  SELECT Name AS Name FROM Towns
  ) AS Names
  WHERE Name IS NOT NULL

OPEN empCursor
DECLARE @name nvarchar(50)
FETCH NEXT FROM empCursor INTO @name

DECLARE @nameLen int, @currentIndex int

WHILE @@FETCH_STATUS = 0
  BEGIN
	IF(dbo.ufn_StringComprisedOf(@name,@letterSet)=1)
	  BEGIN
	    INSERT INTO @resulst_table
		VALUES (@name)
	  END
    FETCH NEXT FROM empCursor 
    INTO @name
  END

CLOSE empCursor
DEALLOCATE empCursor
  RETURN
END
GO

SELECT * FROM [dbo].ufn_EmployeesAndTownsNameComprisedOf('oistmiahf')
GO

/* Task 8. Using database cursor write a T-SQL script that scans all employees and
 their addresses and prints all pairs of employees that live in the same town.*/

USE [TelerikAcademy]
GO

SELECT e.EmployeeID ,e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID, t.Name as TownName
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE UNIQUE CLUSTERED INDEX Idx_TemEmp ON #TempEmployeesWithTowns(EmployeeID)

DECLARE empCursor CURSOR READ_ONLY FOR
SELECT EmployeeID, EmployeeName, TownID,TownName
FROM #TempEmployeesWithTowns

OPEN empCursor
DECLARE @employeeID int, @employeeName varchar(150), @townID int,  @townName varchar(50)
FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName

CREATE TABLE #TempEmployeeFromSameTownPairs (FirstEmployeeName varchar(150), SecondEmployeeName varchar(150), TownName varchar(50))
WHILE @@FETCH_STATUS = 0
  BEGIN
	INSERT INTO #TempEmployeeFromSameTownPairs (FirstEmployeeName, SecondEmployeeName, TownName)
	SELECT @employeeName, EmployeeName, @townName FROM #TempEmployeesWithTowns e
	WHERE e.TownID = @townID AND e.EmployeeID <> @employeeID
    FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName           
  END
CLOSE empCursor
DEALLOCATE empCursor

SELECT TownName, FirstEmployeeName, SecondEmployeeName FROM #TempEmployeeFromSameTownPairs
ORDER BY TownName, FirstEmployeeName, SecondEmployeeName
DROP TABLE #TempEmployeeFromSameTownPairs
DROP TABLE #TempEmployeesWithTowns
GO

SELECT t1.Name, e1.FirstName + ISNULL(' '+ e1.MiddleName, '') + ' ' + e1.LastName AS FirstEmployeeName,
e2.FirstName + ISNULL(' '+ e2.MiddleName, '') + ' ' + e2.LastName AS SecondEmployeeName
FROM Employees e1 JOIN Addresses a1 ON e1.AddressID = a1.AddressID
JOIN Towns t1 ON a1.TownID = t1.TownID,
Employees e2 JOIN Addresses a2 ON e2.AddressID = a2.AddressID
JOIN Towns t2 ON a2.TownID = t2.TownID
WHERE t1.Name = t2.Name
AND e1.EmployeeID <> e2.EmployeeID
ORDER BY t1.Name, FirstEmployeeName, SecondEmployeeName

/* Task 9. Write a T-SQL script that shows for each town a list of all employees
that live in it. */

USE [TelerikAcademy]
GO

SELECT e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID
INTO #TempEmployeesWithTowns
FROM Employees e INNER JOIN Addresses a on e.AddressID = a.AddressID
INNER JOIN Towns t on a.TownID = t.TownID 
CREATE INDEX Idx_TemTown ON #TempEmployeesWithTowns(TownID)


DECLARE townCursor CURSOR READ_ONLY FOR
SELECT TownID, Name FROM Towns
OPEN townCursor
DECLARE @townID int, @townName varchar(50)
FETCH NEXT FROM townCursor INTO @townID, @townName
WHILE @@FETCH_STATUS = 0
  BEGIN
    DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT EmployeeName FROM #TempEmployeesWithTowns
	WHERE TownID = @townID

	OPEN empCursor
	DECLARE @employeeName varchar(150), @employeesList varchar(MAX)
	SET @employeesList = ''
	FETCH NEXT FROM empCursor INTO @employeeName

	WHILE @@FETCH_STATUS = 0	
	  BEGIN
		SET @employeesList = CONCAT(@employeesList, @employeeName, ', ')
		FETCH NEXT FROM empCursor INTO @employeeName
	  END  
	CLOSE empCursor
	DEALLOCATE empCursor
	SET @employeesList = LEFT(@employeesList, LEN(@employeesList) - 1)
	PRINT @townName + ' -> ' + @employeesList
	FETCH NEXT FROM townCursor INTO @townID, @townName         
  END
CLOSE townCursor
DEALLOCATE townCursor
DROP TABLE #TempEmployeesWithTowns
GO