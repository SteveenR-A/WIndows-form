-- Script para recrear la base de datos SQL Server usada por la app (bd_ventas)
-- ADVERTENCIA: ejecuta DROP DATABASE, se perderán datos existentes

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'bd_ventas')
BEGIN
    ALTER DATABASE bd_ventas SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE bd_ventas;
END
GO

CREATE DATABASE bd_ventas;
GO

USE bd_ventas;
GO

CREATE TABLE Catalogo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL UNIQUE,
    Nombre NVARCHAR(200) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL
);

CREATE TABLE Factura (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Cliente NVARCHAR(200) NULL,
    Total DECIMAL(18,2) NOT NULL
);

CREATE TABLE Producto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FacturaId INT NOT NULL REFERENCES Factura(Id),
    CatalogoId INT NOT NULL REFERENCES Catalogo(Id),
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL
);

-- Datos de ejemplo para catálogo
INSERT INTO Catalogo (Codigo, Nombre, Precio) VALUES ('P001','Producto de ejemplo 1',10.00);
INSERT INTO Catalogo (Codigo, Nombre, Precio) VALUES ('P002','Producto de ejemplo 2',20.00);
GO
