-- Crear base de datos
CREATE DATABASE IzumiClientesDB;
GO

USE IzumiClientesDB;
GO

-- Crear tabla Clientes
CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoDocumento NVARCHAR(50) NOT NULL,
    NumeroDocumento NVARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    PrimerNombre NVARCHAR(100) NOT NULL,
    SegundoNombre NVARCHAR(100),
    PrimerApellido NVARCHAR(100) NOT NULL,
    SegundoApellido NVARCHAR(100),
    Direccion NVARCHAR(200) NOT NULL,
    Celular NVARCHAR(50) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    PlanPreferencia NVARCHAR(100) NOT NULL
);

-- Crear índice para evitar duplicados en TipoDocumento + NumeroDocumento
CREATE UNIQUE INDEX IX_Clientes_Tipo_NumeroDocumento
ON Clientes (TipoDocumento, NumeroDocumento);
