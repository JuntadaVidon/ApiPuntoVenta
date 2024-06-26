CREATE DATABASE ButcheryPOSDB;
GO

USE ButcheryPOSDB;
GO

-- Tabla de Categorías
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(100) NOT NULL,
    Description TEXT,
    UserIng VARCHAR(100),
    FecIng DATETIME,
    UserMod VARCHAR(100),
    FecMod DATETIME,
    UserBaja VARCHAR(100),
    FecBaja DATETIME
);
GO

-- Tabla de Proveedores
CREATE TABLE Suppliers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SupplierName VARCHAR(100) NOT NULL,
    ContactName VARCHAR(100),
    Address VARCHAR(255),
    City VARCHAR(100),
    PostalCode VARCHAR(20),
    Country VARCHAR(100),
    Phone VARCHAR(20),
    UserIng VARCHAR(100),
    FecIng DATETIME,
    UserMod VARCHAR(100),
    FecMod DATETIME,
    UserBaja VARCHAR(100),
    FecBaja DATETIME
);
GO

-- Tabla de Productos
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    CategoryID INT,
    SupplierID INT,
    QuantityPerUnit VARCHAR(100),
    UnitPrice DECIMAL(10, 2),
    UnitsInStock INT,
    UnitsOnOrder INT,
    ReorderLevel INT,
    Discontinued BIT NOT NULL DEFAULT 0,
    UserIng VARCHAR(100),
    FecIng DATETIME,
    UserMod VARCHAR(100),
    FecMod DATETIME,
    UserBaja VARCHAR(100),
    FecBaja DATETIME,
    FOREIGN KEY (CategoryID) REFERENCES Categories(Id),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(Id)
);
GO

-- Tabla de Clientes
CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(100) NOT NULL,
    ContactName VARCHAR(100),
    Address VARCHAR(255),
    City VARCHAR(100),
    PostalCode VARCHAR(20),
    Country VARCHAR(100),
    Phone VARCHAR(20),
    UserIng VARCHAR(100),
    FecIng DATETIME,
    UserMod VARCHAR(100),
    FecMod DATETIME,
    UserBaja VARCHAR(100),
    FecBaja DATETIME
);
GO

-- Tabla de Ventas
CREATE TABLE Sales (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    SaleDate DATE NOT NULL,
    TotalAmount DECIMAL(10, 2),
    UserIng VARCHAR(100),
    FecIng DATETIME,
    UserMod VARCHAR(100),
    FecMod DATETIME,
    UserBaja VARCHAR(100),
    FecBaja DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customers(Id)
);
GO

-- Tabla de Detalle de Ventas
CREATE TABLE SalesDetails (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SaleID INT,
    ProductID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Discount DECIMAL(5, 2),
    UserIng VARCHAR(100),
    FecIng DATETIME,
    UserMod VARCHAR(100),
    FecMod DATETIME,
    UserBaja VARCHAR(100),
    FecBaja DATETIME,
    FOREIGN KEY (SaleID) REFERENCES Sales(Id),
    FOREIGN KEY (ProductID) REFERENCES Products(Id)
);
GO
-- Categorías
INSERT INTO Categories (CategoryName, Description, UserIng, FecIng) VALUES
('Red Meat', 'Beef, pork, etc.', 'admin', GETDATE()),
('White Meat', 'Chicken, turkey, etc.', 'admin', GETDATE()),
('Sausages', 'Chorizos, sausages, etc.', 'admin', GETDATE());
GO

-- Proveedores
INSERT INTO Suppliers (SupplierName, ContactName, Address, City, PostalCode, Country, Phone, UserIng, FecIng) VALUES
('Supplier 1', 'Contact 1', 'Address 1', 'City 1', '10001', 'Country 1', '123456789', 'admin', GETDATE()),
('Supplier 2', 'Contact 2', 'Address 2', 'City 2', '10002', 'Country 2', '987654321', 'admin', GETDATE());
GO

-- Productos
INSERT INTO Products (ProductName, CategoryID, SupplierID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued, UserIng, FecIng) VALUES
('Beef', 1, 1, '1 kg', 10.00, 50, 10, 5, 0, 'admin', GETDATE()),
('Whole Chicken', 2, 2, '1.5 kg', 7.50, 30, 5, 3, 0, 'admin', GETDATE()),
('Chorizo', 3, 1, '1 kg', 8.00, 20, 2, 2, 0, 'admin', GETDATE());
GO

-- Clientes
INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country, Phone, UserIng, FecIng) VALUES
('Customer 1', 'Contact 1', 'Address 1', 'City 1', '20001', 'Country 1', '123123123', 'admin', GETDATE()),
('Customer 2', 'Contact 2', 'Address 2', 'City 2', '20002', 'Country 2', '321321321', 'admin', GETDATE());
GO

-- Ventas
INSERT INTO Sales (CustomerID, SaleDate, TotalAmount, UserIng, FecIng) VALUES
(1, '2024-06-25', 25.50, 'admin', GETDATE()),
(2, '2024-06-26', 15.00, 'admin', GETDATE());
GO

-- Detalle de Ventas
INSERT INTO SalesDetails (SaleID, ProductID, Quantity, UnitPrice, Discount, UserIng, FecIng) VALUES
(1, 1, 2, 10.00, 0.00, 'admin', GETDATE()),
(1, 3, 1, 8.00, 0.00, 'admin', GETDATE()),
(2, 2, 1, 7.50, 0.50, 'admin', GETDATE());
GO
