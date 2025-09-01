create database my
use my

create procedure getcustomersbycountry
    @country nvarchar(50)
as
begin
    select customerid, companyname, contactname, country
    from customers
    where country = @country
end


CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATETIME,
    ShipName NVARCHAR(100),
    ShipCity NVARCHAR(50),
    ShipCountry NVARCHAR(50),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CompanyName NVARCHAR(100),
    ContactName NVARCHAR(100),
    Country NVARCHAR(50)
);

INSERT INTO Employees (EmployeeID, FirstName, LastName)VALUES (5, 'Steven', 'Buchanan');

INSERT INTO Orders (OrderID, OrderDate, ShipName, ShipCity, ShipCountry, EmployeeID)
VALUES (101, GETDATE(), 'Alpha Corp', 'Seattle', 'USA', 5),
(102, GETDATE(), 'Beta Ltd', 'New York', 'USA', 5);

INSERT INTO Customers (CustomerID, CompanyName, ContactName, Country)
VALUES 
(1, 'Contoso Ltd', 'Alice', 'USA'),
(2, 'Northwind Traders', 'Bob', 'Germany');








