
-- 05. Built-in Functions

-- 01. Find Names of All Employees by First Name

SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE [FirstName] LIKE 'Sa%'


-- 02. Find Names of All Employees by Last Name

SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%'


-- 03. Find First Names of All Employees

SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10)
   AND DATEPART(YEAR, [HireDate]) BETWEEN 1995 AND 2005

-- 04. Find All Employees Except Engineers

   SELECT [FirstName],
          [LastName]
     FROM [Employees]
WHERE NOT LOWER([JobTitle]) IN ('engineer')

-- 05. Find Towns With Name Length

  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

-- 06. Find Towns Starting With

  SELECT [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M','K','B','E')
ORDER BY [Name]

--07. Find Towns Not Starting With

  SELECT [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) NOT IN ('R','B','D')
ORDER BY [Name]