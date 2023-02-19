-- 01. Database Design
CREATE DATABASE Boardgames
GO

USE Boardgames
GO

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town NVARCHAR(30) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) UNIQUE NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
    Website NVARCHAR(40),
    Phone NVARCHAR(40)
)

CREATE TABLE PlayersRanges
(
    Id INT PRIMARY KEY IDENTITY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(8,2) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
    PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL,
)

CREATE TABLE Creators
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
    CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL,
    BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id) NOT NULL,
    PRIMARY KEY(CreatorId, BoardgameId)
)

-- 02. Insert

INSERT INTO Boardgames
VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers
VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

-- 03. Update

UPDATE PlayersRanges
SET PlayersMax += 1
WHERE PlayersMax = 2 AND PlayersMin = 2

UPDATE Boardgames
SET Name += 'V2'
WHERE YearPublished >= 2020

-- 04. Delete

DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (
    SELECT Id 
    FROM Boardgames
    WHERE PublisherId IN (
        SELECT Id
        FROM Publishers
        WHERE AddressId IN(
            SELECT Id FROM Addresses
            WHERE TOWN LIKE 'L%'
        )
    )
)

DELETE FROM Boardgames
WHERE PublisherId IN(
    SELECT Id
    FROM Publishers
    WHERE AddressId IN (
        SELECT Id FROM Addresses
        WHERE TOWN LIKE 'L%'
    )
)

DELETE FROM Publishers
WHERE AddressId IN (
    SELECT Id FROM Addresses
WHERE TOWN LIKE 'L%'
)

DELETE FROM Addresses
WHERE TOWN LIKE 'L%'

-- 05. Boradgames by Year of Publication

SELECT 
    [Name],
    Rating
FROM Boardgames
ORDER BY YearPublished, [Name] DESC

-- 06.BoardGames by Category

SELECT
    b.Id AS Id,
    b.[Name],
    YearPublished,
    c.[Name] AS [CategoryName]
FROM Boardgames AS b
JOIN Categories c ON c.Id = b.CategoryId
WHERE c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY YearPublished DESC

-- 07. Creators without Boardgames

SELECT
    c.Id,
    CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,
    c.Email
FROM Creators AS c 
LEFT JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
WHERE cb.BoardgameId IS NULL
ORDER BY CreatorName

-- 08. First 5 Boardgames

SELECT TOP(5)
    b.[Name],
    b.Rating,
    c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories c ON b.CategoryId = c.Id
JOIN PlayersRanges pr ON b.PlayersRangeId = pr.Id
WHERE (Rating > 7.00 AND b.[Name] LIKE '%a%')
   OR (Rating > 7.50 AND (pr.PlayersMin = 2 AND Pr.PlayersMax = 5))
ORDER BY b.[Name], Rating DESC

-- 09. Creators with Emails

SELECT 
    CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
    c.Email,
    MAX(b.Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
JOIN Boardgames b ON b.Id = cb.BoardgameId
GROUP BY c.FirstName, c.LastName, c.Email
HAVING RIGHT(c.Email, 4) = '.com'
ORDER BY FullName

-- 10. Creators by Rating

SELECT 
    c.LastName,
    CEILING(AVG(b.Rating)) AS AverageRating,
    p.Name AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames cb ON c.Id = cb.CreatorId
JOIN Boardgames b ON b.Id = cb.BoardgameId
JOIN Publishers p ON b.PublisherId = p.Id
GROUP BY c.LastName, p.Name
HAVING p.Name = 'Stonemaier Games'
ORDER BY AVG(b.Rating) DESC

-- 11. Creator with Boardgames

CREATE OR ALTER FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @creatorId INT = (
        SELECT Id 
        FROM Creators
        WHERE FirstName = @name
     )
RETURN (SELECT COUNT(*)
    FROM CreatorsBoardgames
    WHERE CreatorId = @creatorId
    )
END

-- 12. Search for Boardgame with Specific Category

CREATE OR ALTER PROCEDURE usp_SearchByCategory(@category NVARCHAR(50))
AS
BEGIN
    SELECT
        b.[Name],
        YearPublished,
        Rating,
        c.[Name] AS CategoryName,
        p.[Name] AS PublisherName,
        CONCAT(pr.PlayersMin, ' people') AS MinPlayers,
        CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
    FROM Boardgames AS b 
    JOIN Categories c ON b.CategoryId = c.Id
    JOIN Publishers p ON b.PublisherId = p.Id
    JOIN PlayersRanges pr ON b.PlayersRangeId = pr.Id
    WHERE b.CategoryId = (
        SELECT Id 
        FROM Categories
        WHERE [Name] = @category
    )
    ORDER BY PublisherName, YearPublished DESC
END 

EXEC usp_SearchByCategory 'Wargames'