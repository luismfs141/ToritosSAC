--03/12/2024
USE ToritosDB;
GO

-- Verificar si la columna 'Nombre_nv' existe y si es 'NULL', cambiarla a 'NOT NULL'
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'Nombre_nv' AND IS_NULLABLE = 'YES')
BEGIN
    ALTER TABLE Proveedor
    ALTER COLUMN Nombre_nv VARCHAR(80) NOT NULL;
END
GO

-- Verificar si la columna 'CargoContacto_nv' existe y si es 'NULL', cambiarla a 'NOT NULL'
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'CargoContacto_nv' AND IS_NULLABLE = 'YES')
BEGIN
    ALTER TABLE Proveedor
    ALTER COLUMN CargoContacto_nv VARCHAR(15) NOT NULL;
END
GO

-- Verificar si la columna 'Direccion_nv' existe y si es 'NULL', cambiarla a 'NOT NULL'
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'Direccion_nv' AND IS_NULLABLE = 'YES')
BEGIN
    ALTER TABLE Proveedor
    ALTER COLUMN Direccion_nv VARCHAR(120) NOT NULL;
END
GO

-- Verificar si la columna 'Estado_c' ya existe
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'Estado_c')
BEGIN
    ALTER TABLE Proveedor
    ADD Estado_c CHAR(1) NOT NULL DEFAULT 'A';
END
GO

-- Verificar si la restricción 'CHK_Proveedor_Estado' ya existe
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints 
               WHERE name = 'CHK_Proveedor_Estado' AND parent_object_id = OBJECT_ID('Proveedor'))
BEGIN
    ALTER TABLE Proveedor
    ADD CONSTRAINT CHK_Proveedor_Estado CHECK (Estado_c IN ('A', 'I'));
END
GO

-- Verificar si la columna 'Admision_C' ya existe en la tabla 'DetalleGrupo'
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'DetalleGrupo' AND COLUMN_NAME = 'Admision_C')
BEGIN
    ALTER TABLE [dbo].[DetalleGrupo]
    ADD [Admision_C] CHAR(1);
END
GO







--04/12/2024