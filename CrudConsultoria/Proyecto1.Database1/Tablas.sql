create database dbSistemadeInformacionIINoviembre2024
go
use dbSistemadeInformacionIINoviembre2024
go
exec sp_addtype codigo,'bigint','not null';
go

select * from cliente

--DROP TABLE Cliente
--DROP TABLE ClienteJuridico
--DROP TABLE ClienteNatural
--DROP TABLE EntidadFinanciera
--DROP TABLE TipoCuenta
--DROP TABLE CuentaBancaria
--DROP TABLE EntidadReguladora
--DROP TABLE Empleado
--DROP TABLE TipoTramite
--DROP TABLE Tramite
--DROP TABLE SustanciaControlada
--DROP TABLE TramiteSustancia
--DROP TABLE TramiteCombustible
--DROP TABLE Contrato
--DROP TABLE SeguimientoTramite
--DROP TABLE Documento
--DROP TABLE AutorizacionSustancia
-- Tabla Cliente (tabla base)
CREATE TABLE Cliente (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Direccion VARCHAR(200),
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    FechaRegistro DATE,
    Nit VARCHAR(20)
)
IF OBJECT_ID('ClientePlanPago', 'U') IS NOT NULL
    DROP TABLE ClientePlanPago;

-- Agregar IdPlanPago a la tabla Cliente
ALTER TABLE Cliente 
ADD IdPlanPago INT FOREIGN KEY REFERENCES PlanPago(Id);

-- Tabla ClienteJuridico
CREATE TABLE ClienteJuridico (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(Id),
    Nombre VARCHAR(100),
    RazonSocial VARCHAR(100),
    NIT VARCHAR(20),
    NroPadron VARCHAR(50),
    RepresentanteLegal VARCHAR(100)
)
-- Tabla ClienteNatural
CREATE TABLE ClienteNatural (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(Id),
    Nombre VARCHAR(100),
    ApellidoMaterno VARCHAR(50),
    ApellidoPaterno VARCHAR(50),
    DocumentoIdentidad VARCHAR(20),
    FechaNacimiento DATE,
    Genero CHAR(1)
)

-- Tabla EntidadFinanciera
CREATE TABLE EntidadFinanciera (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Direccion VARCHAR(200),
    NombreEntidadFinanciera VARCHAR(100),
    NroCuenta VARCHAR(50),
    NroTelefono VARCHAR(20)
)

-- Tabla TipoCuenta
CREATE TABLE TipoCuenta (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50),
    TipoCuenta VARCHAR(50)
)

-- Tabla CuentaBancaria
CREATE TABLE CuentaBancaria (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaApertura DATE,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(Id),
    IdEntidadFinanciera INT FOREIGN KEY REFERENCES EntidadFinanciera(Id),
    NroCuenta VARCHAR(50)
)

-- Tabla EntidadReguladora
CREATE TABLE EntidadReguladora (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Direccion VARCHAR(200),
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    Tipo VARCHAR(50)
)

-- Tabla Empleado
CREATE TABLE Empleado (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Cargo VARCHAR(50),
    DocumentoIdentidad VARCHAR(20)
)

-- Tabla TipoTramite
CREATE TABLE TipoTramite (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Costo DECIMAL(10,2),
    Descripcion VARCHAR(500),
    Obligatorio BIT
)

-- Tabla Tramite
CREATE TABLE Tramite (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(500),
    Estado VARCHAR(50),
    FechaFin DATE,
    FechaInicio DATE,
    Id_Prioridad INT,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(Id),
    IdTipoTramite INT FOREIGN KEY REFERENCES TipoTramite(Id),
    IdEmpleado INT FOREIGN KEY REFERENCES Empleado(Id),
    IdEntidadReguladora INT FOREIGN KEY REFERENCES EntidadReguladora(Id)
)

-- Tabla SustanciaControlada
CREATE TABLE SustanciaControlada (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Categoria VARCHAR(50),
    Codigo VARCHAR(20),
    Nombre VARCHAR(100),
    UnidadMedida VARCHAR(20)
)

-- Tabla TramiteSustancia
CREATE TABLE TramiteSustancia (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CantidadSolicitada DECIMAL(10,2),
    IdTramite INT FOREIGN KEY REFERENCES Tramite(Id),
    IdSustancia INT FOREIGN KEY REFERENCES SustanciaControlada(Id),
    Justificacion VARCHAR(500),
    PeriodoUso DATE,
    Tipo VARCHAR(50)
)

-- Tabla TramiteCombustible
CREATE TABLE TramiteCombustible (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CantidadSolicitada DECIMAL(10,2),
    IdTramite INT FOREIGN KEY REFERENCES Tramite(Id),
    Justificacion VARCHAR(500),
    PeriodoUso DATE,
    Tipo VARCHAR(50)
)

-- Tabla Contrato
CREATE TABLE Contrato (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Clausula TEXT,
    Costo DECIMAL(10,2),
    Estado VARCHAR(50),
    FechaFin DATE,
    FechaInicio DATE,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(Id),
    VolumenActividad DECIMAL(10,2)
)

-- Tabla SeguimientoTramite
CREATE TABLE SeguimientoTramite (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Estado VARCHAR(50),
    Fecha DATE,
    IdTramite INT FOREIGN KEY REFERENCES Tramite(Id),
    Observaciones VARCHAR(500)
)

-- Tabla Documento
CREATE TABLE Documento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Archivo VARCHAR(200),
    Estado VARCHAR(50),
    FechaSubida DATE,
    IdTramite INT FOREIGN KEY REFERENCES Tramite(Id),
    Nombre VARCHAR(100),
    Tipo VARCHAR(50)
)

-- Tabla AutorizacionSustancia
CREATE TABLE AutorizacionSustancia (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CantidadAutorizada DECIMAL(10,2),
    FechaEmision DATE,
    FechaVencimiento DATE,
    NumeroAutorizacion VARCHAR(50)
)

-- Tabla AutorizacionCombustible
CREATE TABLE AutorizacionCombustible (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CantidadAutorizada DECIMAL(10,2),
    FechaEmision DATE,
    FechaVencimiento DATE,
    NumeroAutorizacion VARCHAR(50)
)

-- Tabla para el catálogo de planes de pago
CREATE TABLE PlanPago (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50)
);

-- Tabla intermedia para relacionar Cliente con PlanPago
CREATE TABLE ClientePlanPago (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(Id),
    IdPlanPago INT FOREIGN KEY REFERENCES PlanPago(Id),
    FechaEmision DATE,
    FechaVencimiento DATE,
    Id_remesa VARCHAR(50)
);
INSERT INTO PlanPago (Descripcion) VALUES ('Mensual');
INSERT INTO PlanPago (Descripcion) VALUES ('Quincenal');
INSERT INTO PlanPago (Descripcion) VALUES ('Trimestral');

-- Tabla Moneda
CREATE TABLE Moneda (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreMoneda VARCHAR(50),
    PaisProcedencia VARCHAR(50)
)

-- Tabla Factura
CREATE TABLE Factura (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Estado VARCHAR(50),
    Fecha DATE,
    Nit VARCHAR(20),
    Total DECIMAL(10,2)
)

-- Tabla Pago
CREATE TABLE Pago (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Estado VARCHAR(50),
    Fecha DATE,
    MetodoPago VARCHAR(50),
    Monto DECIMAL(10,2),
    IdFactura INT FOREIGN KEY REFERENCES Factura(Id)
)

ALTER TABLE Cliente 
ADD TipoCliente VARCHAR(20) NOT NULL CHECK (TipoCliente IN ('Juridico', 'Natural'));
-- Índices para mejorar el rendimiento
CREATE INDEX IX_Tramite_Cliente ON Tramite(IdCliente)
CREATE INDEX IX_Tramite_Estado ON Tramite(Estado)
CREATE INDEX IX_Tramite_Empleado ON Tramite(IdEmpleado)
CREATE INDEX IX_Tramite_TipoTramite ON Tramite(IdTipoTramite)
CREATE INDEX IX_Contrato_Cliente ON Contrato(IdCliente)
CREATE INDEX IX_TramiteSustancia_Tramite ON TramiteSustancia(IdTramite)
CREATE INDEX IX_ClienteJuridico_Cliente ON ClienteJuridico(IdCliente)
CREATE INDEX IX_ClienteNatural_Cliente ON ClienteNatural(IdCliente)
CREATE INDEX IX_Cliente_CuentaBancaria ON Cliente(IdCuentaBancaria)

-- Insertar Tipos de Trámite
INSERT INTO TipoTramite (Nombre, Descripcion, Costo, Obligatorio) VALUES 
('Trámite Sustancia', 'Trámite para sustancias controladas', 100.00, 1),
('Trámite Combustible', 'Trámite para combustibles', 150.00, 1),
('Trámite Regular', 'Trámite administrativo regular', 50.00, 0);

-- Insertar Empleados (responsables)
INSERT INTO Empleado (Nombre, Cargo, DocumentoIdentidad) VALUES 
('Juan Pérez', 'Supervisor', '1234567'),
('María García', 'Analista', '2345678'),
('Carlos López', 'asesor', '3456789');

-- Insertar Entidades Reguladoras
INSERT INTO EntidadReguladora (Nombre, Direccion, Email, Telefono, Tipo) VALUES 
('Direccion General de sustancia controlada', 'Av Sandoval 2do anillo', 'dgsc@gmail.com', '1111-1111', 'Sustancias'),
('ANH', 'Av Sant dumont', 'Anh@gmail.com', '2222-2222', 'Hidrocarburos'),
('YPFB', 'Av 3 pasos al frente', 'Ypfb@gmail.com', '3333-3333', 'Hidrocarburos');

-- Insertar Sustancias Controladas
INSERT INTO SustanciaControlada (Categoria, Codigo, Nombre, UnidadMedida) VALUES 
('acidos', 'SUB001', 'acido clorhidrico', 'Litros'),
('peroxido', 'SUB002', 'Peroxido de litio', 'Kilogramos'),
('acidos', 'SUB003', 'soda cautica', 'Unidades');


-- Relación entre Pago y PlanPago
ALTER TABLE Pago
ADD IdPlanPago INT;

ALTER TABLE Pago
ADD CONSTRAINT FK_Pago_PlanPago FOREIGN KEY (IdPlanPago)
REFERENCES PlanPago(Id);

-- Relación entre Pago y Moneda
ALTER TABLE Pago
ADD IdMoneda INT;

ALTER TABLE Pago
ADD CONSTRAINT FK_Pago_Moneda FOREIGN KEY (IdMoneda)
REFERENCES Moneda(Id);

-- Relación entre CuentaBancaria y TipoCuenta (ya existe en tu esquema original)
-- Solo aseguramos que el índice exista
CREATE INDEX IX_CuentaBancaria_TipoCuenta ON CuentaBancaria(IdTipoCuenta);

-- Relación entre TramiteSustancia y AutorizacionSustancia
ALTER TABLE TramiteSustancia
ADD IdAutorizacionSustancia INT;

ALTER TABLE TramiteSustancia
ADD CONSTRAINT FK_TramiteSustancia_AutorizacionSustancia FOREIGN KEY (IdAutorizacionSustancia)
REFERENCES AutorizacionSustancia(Id);

-- Relación entre TramiteCombustible y AutorizacionCombustible
ALTER TABLE TramiteCombustible
ADD IdAutorizacionCombustible INT;

ALTER TABLE TramiteCombustible
ADD CONSTRAINT FK_TramiteCombustible_AutorizacionCombustible FOREIGN KEY (IdAutorizacionCombustible)
REFERENCES AutorizacionCombustible(Id);

-- Crear índices para mejorar el rendimiento
CREATE INDEX IX_Pago_PlanPago ON Pago(IdPlanPago);
CREATE INDEX IX_Pago_Moneda ON Pago(IdMoneda);
CREATE INDEX IX_TramiteSustancia_Autorizacion ON TramiteSustancia(IdAutorizacionSustancia);
CREATE INDEX IX_TramiteCombustible_Autorizacion ON TramiteCombustible(IdAutorizacionCombustible);

-- Relación entre CuentaBancaria y Moneda
ALTER TABLE CuentaBancaria
ADD IdMoneda INT;

ALTER TABLE CuentaBancaria
ADD CONSTRAINT FK_CuentaBancaria_Moneda FOREIGN KEY (IdMoneda)
REFERENCES Moneda(Id);

-- Relación entre CuentaBancaria y TipoCuenta
ALTER TABLE CuentaBancaria
ADD IdTipoCuenta INT;

ALTER TABLE CuentaBancaria
ADD CONSTRAINT FK_CuentaBancaria_TipoCuenta FOREIGN KEY (IdTipoCuenta)
REFERENCES TipoCuenta(Id);


IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Pago_Moneda')
    ALTER TABLE Pago DROP CONSTRAINT FK_Pago_Moneda;

-- Luego eliminar la columna
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Pago') AND name = 'IdMoneda')
    ALTER TABLE Pago DROP COLUMN IdMoneda;

-- Opcional: Eliminar el índice si existe
IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Pago_Moneda')
    DROP INDEX IX_Pago_Moneda ON Pago;