--01.Exercises: Database Introduction

-- 1.Create Database
CREATE TABLE Minions

USE [Minions]

-- 2.Create Tables
CREATE TABLE Minions
(
    Id     INT IDENTITY  NOT NULL,
    [Name] VARCHAR(100),
    Age    INT
)


CREATE TABLE Towns
(
    Id      INT IDENTITY NOT NULL,
    [Name]  VARCHAR(100)
)

ALTER TABLE Minions
ADD CONSTRAINT PK_MinionsId PRIMARY KEY (Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownsId PRIMARY KEY(Id)

-- 3.Alter Minions Table
ALTER TABLE Minions
ADD TownId INT NOT NULL

ALTER TABLE Minions
ADD CONSTRAINT FK_TownId FOREIGN KEY(TownId) REFERENCES Towns(Id)

-- 4.Insert Records in Both Tables
INSERT INTO Towns
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob',15, 3),
(3, 'Steward', NULL, 2)

-- 5.Truncate Table Minions
TRUNCATE TABLE Minions

-- 6.Drop All Tables
DROP TABLE Minions
DROP TABLE Towns

-- 7.Create Table People
CREATE TABLE People
(
    Id     INT PRIMARY KEY IDENTITY NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    Picture VARBINARY(MAX) NULL,
    Height DECIMAL(10,2) NULL,
    Weight DECIMAL(10,2) NULL,
    Gender CHAR(1) NOT NULL,
    Birthdate DATETIME2 NOT NULL,
    Biography NVARCHAR(MAX) NULL
)
INSERT INTO People
VALUES
('John', null, 178, 83, 'm', '09-23-1985', 'Raahr'),
('Dean', null, 173, 81, 'm', '08-13-1983', 'Raahr'),
('Max', null, 171, 80, 'm', '10-21-1987', 'Raahr'),
('Jack', null, 188, 93, 'm', '05-13-1989', 'Raahr'),
('Mary', null, 171, 63, 'f', '03-20-1982', 'Raahr')

-- 8.Create Table Users
CREATE TABLE Users
(
    Id     BIGINT PRIMARY KEY IDENTITY NOT NULL,
    Username VARCHAR(30) NOT NULL,
    Password VARCHAR(26) NOT NULL,
    ProfilePicture VARBINARY(MAX) NULL,
    LastLoginTime DATETIME2 ,
    IsDeleted VARCHAR(5) NOT NULL,
)

INSERT INTO Users
VALUES
('John', '12345', null, GETDATE(), 'false'),
('Jack', '123456', null, GETDATE(), 'false'),
('James', '123454', null, GETDATE(), 'false'),
('Jerry', '123452', null, GETDATE(), 'false'),
('Jasmine', '123451', null, GETDATE(), 'true')

-- 9.Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07FF212F0A]
ALTER TABLE Users
ADD CONSTRAINT PK_Users_ID_Name PRIMARY KEY(Id, Username)

-- 10.Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_Password_Min_Len CHECK(LEN(Password) >= 5)

-- 11.Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT Login_Time_Default
DEFAULT GETDATE() For LastLoginTime

-- 12.Set Unique Field
ALTER TABLE Users DROP CONSTRAINT PK_Users_ID_Name
ALTER TABLE Users ADD CONSTRAINT PK_Id PRIMARY KEY(Id)
ALTER TABLE Users ADD CONSTRAINT UC_Username UNIQUE(Username)
ALTER TABLE Users ADD CONSTRAINT CHK_Username_Len CHECK(LEN(Username) >= 3)

-- 13.Movies Database
CREATE TABLE Directors
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,DirectorName VARCHAR(30)
    ,Notes NVARCHAR(MAX)
)

INSERT INTO Directors
VALUES
('John', 'la la land'),
('John2', 'la la land'),
('John3', 'la la land'),
('John4', 'la la land'),
('John5', 'la la land')

CREATE TABLE Genres
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,GenreName VARCHAR(30)
    ,Notes NVARCHAR(MAX)
)

INSERT INTO Genres
VALUES
('Horror', 'Scaryyyy'),
('Comedy', 'LMAO'),
('Romance', 'Awww'),
('Action', 'FIGHT'),
('Anime', 'Kawai')

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,CategoryName VARCHAR(30)
    ,Notes NVARCHAR(MAX)
)

INSERT INTO Categories
VALUES
('123', 'Scaryyyy'),
('234', 'LMAO'),
('345', 'Awww'),
('456', 'FIGHT'),
('567', 'Kawai')

CREATE TABLE Movies
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,Title VARCHAR(100) NOT NULL
    ,DirectorId INT NOT NULL CONSTRAINT FK_Director_Id FOREIGN KEY REFERENCES Directors(Id)
    ,CopyrightYear INT NULL
    ,Length INT NULL
    ,GenreId INT NOT NULL CONSTRAINT FK_Genre_Id FOREIGN KEY REFERENCES Genres(Id)
    ,GategoryId INT NOT NULL CONSTRAINT FK_Category_Id FOREIGN KEY REFERENCES Categories(Id)
    ,Rating INT NULL
    ,Notes NVARCHAR(MAX)
)

INSERT INTO Movies
VALUES
('Dive Harder Daddy',1 ,2006, 62, 1, 1, 10, 'For more information visit hentai-master.org'),
('Dive Harder Daddy2',1 ,2007, 60, 2, 2, 10, 'For more information visit hentai-master.org'),
('Dive Harder Daddy3',1 ,2007, 63, 3, 3, 10, 'For more information visit hentai-master.org'),
('Dive Harder Daddy4',1 ,2007, 61, 4, 4, 10, 'For more information visit hentai-master.org'),
('Dive Harder Daddy5',1 ,2007, 65, 5, 5, 10, 'For more information visit hentai-master.org')

-- 14.Car Rental Database
CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,CategoryName VARCHAR(50) NOT NULL
    ,DailyRate INT NOT NULL
    ,WeeklyRate INT NOT NULL
    ,MonthlyRate INT NOT NULL
    ,WeekendRate INT NOT NULL
)

INSERT INTO Categories
VALUES
('First class', 20, 140, 560, 40),
('Second class', 10, 70, 280, 20),
('Bussiness class', 40, 280, 1120, 80)

CREATE TABLE Cars
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,PlateNumber VARCHAR(6)NOT NULL
    ,Manufacturer VARCHAR(30) NOT NULL
    ,Model VARCHAR(20) NOT NULL
    ,CarYear INT NULL
    ,CategoryId INT NOT NULL CONSTRAINT FK_Category_Id FOREIGN KEY REFERENCES Categories(Id)
    ,Doors INT NULL
    ,Picture VARBINARY(MAX) NULL
    ,Condition NVARCHAR(50) NULL
    ,Available VARCHAR(5) NOT NULL
)

INSERT INTO Cars
VALUES
('CV3577', 'Subaru', 'Impreza', 2013, 3, 2, null, 'Very good', 'true'),
('MZ3122', 'Nissan', 'Sentra', 2011, 2, 4, null, 'Very good', 'true'),
('AK1299', 'Opel', 'Astra', 2021, 1, 4, null, 'good', 'true')

CREATE TABLE Employees
(
   Id INT PRIMARY KEY IDENTITY NOT NULL
   ,FirstName VARCHAR(15) NOT NULL
   ,LastName VARCHAR (20) NOT NULL
   ,Title VARCHAR(20) NOT NULL
   ,Notes NVARCHAR(50) NULL 
)

INSERT INTO Employees
VALUES
('Jack','Marksson', 'Car salesman', 'Extremely productive'),
('John', 'Johnson', 'Car salesman', 'Not very good at it'),
('James', 'Morrison', 'Car salesman', 'Doing great at it')

CREATE TABLE Customers
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,DriverLicenseNumber VARCHAR(8) NOT NULL
    ,FullName VARCHAR(50) NOT NULL
    ,[Address] VARCHAR(30) NOT NULL
    ,City VARCHAR(20) NOT NULL
    ,ZIPCode TINYINT
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO Customers
VALUES
(23731827, 'Carol Smith', '7th street 23', 'Henderson', null, 'SUCH A KAREN'),
(36178236, 'John Smith','7th street 23', 'Henderson', null, 'Karens husband, even worse of a Karen'),
(18283942, 'Jack Henkerson', '7th street 23', 'Henderson', null, 'Thank god he is not a Karen too')

CREATE TABLE RentalOrders
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,EmployeeId INT NOT NULL CONSTRAINT FK_Employee_Id FOREIGN KEY REFERENCES Employees(Id)
    ,CustomerId INT NOT NULL CONSTRAINT FK_Customer_Id FOREIGN KEY REFERENCES Customers(Id)
    ,CarId INT NOT NULL CONSTRAINT FK_Car_Id FOREIGN KEY REFERENCES Cars(Id)
    ,TankLevel INT NOT NULL
    ,KilometragesStart INT NOT NULL
    ,KilometragesEnd INT NOT NULL
    ,TotalKilometrage INT NOT NULL
    ,StartDate DATETIME2 NOT NULL
    ,EndDate DATETIME2 NOT NULL
    ,TotalDays INT NOT NULL
    ,RateApplied INT NULL
    ,TaxRate INT NULL
    ,OrderStatus VARCHAR NOT NULL
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO RentalOrders
VALUES
(1, 1, 1, 50, 2300, 3000, 700, GETDATE(), GETDATE(), 7, 6, 12, 'f', 'non taken'),
(2, 2, 2, 50, 2300, 3000, 700, GETDATE(), GETDATE(), 7, 6, 12, 'f', 'non taken'),
(3, 3, 3, 50, 2300, 3000, 700, GETDATE(), GETDATE(), 7, 6, 12, 'f', 'non taken')

-- 15.Hotel Database
CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
   Id INT PRIMARY KEY IDENTITY NOT NULL
   ,FirstName VARCHAR(15) NOT NULL
   ,LastName VARCHAR (20) NOT NULL
   ,Title VARCHAR(20) NOT NULL
   ,Notes NVARCHAR(50) NULL 
)

INSERT INTO Employees
VALUES
('Jack','Marksson', 'Receptionist', 'Extremely productive'),
('John', 'Johnson', 'Receptionist', 'Not very good at it'),
('James', 'Morrison', 'Receptionist', 'Doing great at it')

CREATE TABLE Customers
(
    AccountNumber INT PRIMARY KEY IDENTITY NOT NULL
    ,FirstName VARCHAR(15) NOT NULL
    ,LastName VARCHAR (20) NOT NULL
    ,PhoneNumber INT NOT NULL
    ,EmergencyName VARCHAR(30) NOT NULL
    ,EmergencyNumber INT NOT NULL
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO Customers
VALUES
('Jack','Marksson',0896023213, 'Jane Marksson', 0883271283, null),
('John','Johnson',0894218328, 'Mia Johnson', 0889212311, null),
('James', 'Morrison',0895281392, 'Kate Morrison', 0887126823, null)

CREATE TABLE RoomStatus
(
    RoomStatus VARCHAR(10) PRIMARY KEY NOT NULL
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO RoomStatus
VALUES
('Vacant', 'none'),
('Soon', 'none'),
('Free', 'none')

CREATE TABLE RoomTypes
(
    RoomTypes VARCHAR(10) PRIMARY KEY NOT NULL
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO RoomTypes
VALUES
('Small', 'none'),
('Big', 'none'),
('Apartment', 'none')

CREATE TABLE BedTypes
(
    BedType VARCHAR(10) PRIMARY KEY NOT NULL
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO BedTypes
VALUES
('Single', 'none'),
('Double', 'none'),
('Extra', 'none')

CREATE TABLE Rooms
(
    RoomNumber INT PRIMARY KEY NOT NULL
    ,RoomType VARCHAR(10) NOT NULL CONSTRAINT FK_RoomType FOREIGN KEY REFERENCES RoomTypes(RoomTypes)
    ,BedType VARCHAR(10) NOT NULL CONSTRAINT FK_BedType FOREIGN KEY REFERENCES BedTypes(BedType)
    ,Rate DECIMAL NOT NULL
    ,RoomStatus VARCHAR(10) NOT NULL CONSTRAINT FK_RoomStatus FOREIGN KEY REFERENCES RoomStatus(RoomStatus)
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO Rooms
VALUES
(3003, 'Small', 'Single', 40, 'Free', null),
(3013, 'Big', 'Double', 70, 'Soon', null),
(3033, 'Apartment', 'Extra', 140, 'Vacant', null)

CREATE TABLE Payments
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,EmployeeId INT NOT NULL CONSTRAINT FK_EmployeeId FOREIGN KEY REFERENCES Employees(Id)
    ,PaymentDate DATETIME2 NOT NULL
    ,AccountNumber INT NOT NULL CONSTRAINT FK_Account_Number FOREIGN KEY REFERENCES Customers(AccountNumber)
    ,FirstDateOccupied DATETIME2 NOT NULL
    ,LastDateOccupied DATETIME2 NOT NULL
    ,TotalDays INT
    ,AmountCharged DECIMAL NOT NULL
    ,TaxRate INT NOT NULL
    ,TaxAmount INT NOt NULL
    ,PaymentTotal DECIMAL NULL
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO Payments
VALUES
(1, GETDATE(), 1, GETDATE(), GETDATE(), 5, 120, 20, 50, 190, null),
(2, GETDATE(), 2, GETDATE(), GETDATE(), 15, 1120, 120, 150, 1190, null),
(3, GETDATE(), 3, GETDATE(), GETDATE(), 25, 2120, 220, 250, 2190, null)

CREATE TABLE Occupancies
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,EmployeeId INT NOT NULL CONSTRAINT FK_EmployeeId2 FOREIGN KEY REFERENCES Employees(Id)
    ,PaymentDate DATETIME2 NOT NULL
    ,DateOccupied DATETIME2 NOT NULL
    ,AccountNumber INT NOT NULL CONSTRAINT FK_Account_Number2 FOREIGN KEY REFERENCES Customers(AccountNumber)
    ,RoomNumber INT NOT NULL CONSTRAINT FK_Room_Number2 FOREIGN KEY REFERENCES Rooms(RoomNumber)
    ,RateApplied INT NOT NULL
    ,PhoneCharge INT NULL
    ,Notes NVARCHAR(50) NULL 
)

INSERT INTO Occupancies
VALUES
(1, GETDATE(), GETDATE(), 1, 3003, 50, 12, null),
(2, GETDATE(), GETDATE(), 2, 3013, 50, 12, null),
(3, GETDATE(), GETDATE(), 3, 3033, 50, 12, null)


-- 16.Create Softuni Database

CREATE DATABASE Softuni

USE Softuni

CREATE TABLE Towns
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,AddressText NVARCHAR(50)
    ,TownId INT NOT NULL CONSTRAINT FK_TownId FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
    Id INT PRIMARY KEY IDENTITY NOT NULL
    ,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
     Id INT PRIMARY KEY IDENTITY NOT NULL
     ,FirstName VARCHAR(20) NOT NULL
     ,MiddleName VARCHAR(20) NULL
     ,LastName VARCHAR(20) NOT NULL
     ,JobTitle VARCHAR(30) NOT NULL
     ,DepartmentId INT NOT NULL CONSTRAINT FK_DepartmentId FOREIGN KEY REFERENCES Departments(Id)
     ,HireDate DATETIME2 NOT NULL
     ,Salary Decimal NOT NULL
     ,AddressId INT NOT NULL CONSTRAINT FK_AddressId FOREIGN KEY REFERENCES Addresses(Id)
)

-- 17.Backup Database
USE Softuni
DROP TABLE Employees

-- 18.Basic Insert
USE Softuni

INSERT INTO Towns 
VALUES
('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO Departments
VALUES
('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

INSERT INTO Addresses
VALUES
('5th Street', 1),
('15th Street', 1),
('3th Street', 2),
('12th Street', 3),
('21th Street', 4)

INSERT INTO Employees
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, 1),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 2),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 3),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 4),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 5)

-- 19.Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

-- 20.Basic Select All Fields and Order Them
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY [Salary] DESC

-- 21.Basic Select Some Fields
SELECT [Name] FROM [Towns] ORDER BY [Name]

SELECT [Name] FROM [Departments] ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary]
FROM [Employees]
ORDER BY [Salary] DESC

-- 22.Increase Employees Salary
UPDATE [Employees]
SET [Salary] *= 1.1;

SELECT [Salary] FROM [Employees]

-- 23.Decrease Tax Rate
USE Hotel

UPDATE [Payments]
SET [TaxRate] *= 0.97

SELECT [TaxRate] FROM [Payments]

-- 24.Delete All Records
TRUNCATE TABLE [Occupancies]