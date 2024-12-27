DROP TABLE IF EXISTS [dbo].[DetalleEstadoCuenta];

GO
CREATE TABLE [dbo].[Cuota] (
    [IdCuota_i] INT IDENTITY(1,1) PRIMARY KEY, -- Clave primaria con identidad
    [IdDetalleGrupo] INT NOT NULL,               -- Clave foránea
    [NumCuota_i] INT NOT NULL,                  -- Número de cuota
    [MontoCuota_n] NUMERIC(18,2) NOT NULL,      -- Monto de la cuota
    [FechaInicio_d] DATE NOT NULL,              -- Fecha de inicio
    [FechaFin_d] DATE NOT NULL,                 -- Fecha de fin
    [EstadoCuota_c] CHAR(1) NOT NULL,           -- Estado de la cuota
    CONSTRAINT FK_Cuota_DetalleGrupo FOREIGN KEY ([IdDetalleGrupo]) REFERENCES [dbo].[DetalleGrupo]([IdDetalleGrupo_i]) -- Relación con DetalleGrupo
);

GO
CREATE TABLE [dbo].[EstadoCuenta] (
    [IdEstadoCuenta_i] INT IDENTITY(1,1) PRIMARY KEY,  -- Clave primaria con identidad
    [IdDetalleGrupo_i] INT NOT NULL,                    -- Clave foránea
    [MontoRecaudado_n] NUMERIC(18,2) NOT NULL,          -- Monto recaudado
    CONSTRAINT FK_EstadoCuenta_DetalleGrupo FOREIGN KEY ([IdDetalleGrupo_i]) REFERENCES [dbo].[DetalleGrupo]([IdDetalleGrupo_i]) -- Relación con DetalleGrupo
);

GO
CREATE TABLE [dbo].[DetalleEstadoCuenta] (
    [IdDetalleEstadoCuenta_i] INT IDENTITY(1,1) PRIMARY KEY, -- Clave primaria con identidad
    [IdEstadoCuenta_i] INT NOT NULL,                         -- Clave foránea
    [ReferenciaOperacion_i] INT NULL,                    -- Clave foránea a Pago
    [TipoOperacion_c] CHAR(1) NOT NULL,                      -- Tipo de operación
    [Monto] NUMERIC(18,2) NOT NULL,                          -- Monto
    [FechaPago_dt] DATETIME NOT NULL,                        -- Fecha de pago
    [CodigoPago_v] VARCHAR(15) NOT NULL,                     -- Código de pago
    CONSTRAINT FK_DetalleEstadoCuenta_EstadoCuenta FOREIGN KEY ([IdEstadoCuenta_i]) REFERENCES [dbo].[EstadoCuenta]([IdEstadoCuenta_i]), -- Relación con EstadoCuenta
);

GO
CREATE TABLE [dbo].[CronogramaGrupo] (
    [IdCronogramaGrupo_i] INT IDENTITY(1,1) PRIMARY KEY,  -- Clave primaria con identidad
    [IdGrupo_i] INT NOT NULL,                             -- Clave foránea
    [Fecha_d] DATE NOT NULL,                              -- Fecha
    [CuotaIndividual_n] NUMERIC(18,2) NOT NULL,           -- Cuota individual
    [CuotaGrupal_n] NUMERIC(18,2) NOT NULL,               -- Cuota grupal
    [HabilitarSorteo_b] BIT NOT NULL,                     -- Habilitar sorteo
    [HabilitarMartillazo_b] BIT NOT NULL,                 -- Habilitar martillazo
    CONSTRAINT FK_CronogramaGrupo_Grupo FOREIGN KEY ([IdGrupo_i]) REFERENCES [dbo].[Grupo]([IdGrupo_i]) -- Relación con Grupo
);

GO
CREATE TABLE [dbo].[Pago] (
    [IdPago_i] INT IDENTITY(1,1) PRIMARY KEY,          -- Clave primaria con identidad
    [IdCliente_i] INT NOT NULL,                         -- Clave foránea
    [CodigoPago_v] VARCHAR(15) NOT NULL,                -- Código de pago
    [Concepto_c] CHAR(1) NOT NULL,                      -- Concepto
    [MontoPago_n] NUMERIC(18,2) NOT NULL,               -- Monto de pago
    [FechaPago_d] DATETIME NOT NULL,                    -- Fecha de pago
    [OpcionPago_c] CHAR(1) NOT NULL,                    -- Opción de pago
    CONSTRAINT FK_Pago_Cliente FOREIGN KEY ([IdCliente_i]) REFERENCES [dbo].[Cliente]([IdCliente_i]) -- Relación con Cliente
);

GO
-- Crear tabla Sorteo
CREATE TABLE [dbo].[Sorteo] (
    [IdSorteo_i] INT IDENTITY(1,1) PRIMARY KEY,           -- Clave primaria con identidad
    [IdDetalleGrupo_i] INT NOT NULL,                       -- Clave foránea
    [Fecha_d] DATE NOT NULL,                               -- Fecha del sorteo
    [TipoSorteo_c] CHAR(1) NOT NULL,                       -- Tipo de sorteo (por ejemplo: A o B)
    CONSTRAINT FK_Sorteo_DetalleGrupo FOREIGN KEY ([IdDetalleGrupo_i]) REFERENCES [dbo].[DetalleGrupo]([IdDetalleGrupo_i]) -- Relación con DetalleGrupo
);

GO
ALTER TABLE [dbo].[DetalleGrupo]
ADD 
    [EsGanador_b] BIT NOT NULL DEFAULT 0,       -- Indica si el grupo es ganador
    [EstadoPropietario_b] BIT NOT NULL DEFAULT 0;

GO
ALTER TABLE [dbo].[Cuota]
ADD [Penalidad_n] NUMERIC(18,2) NOT NULL DEFAULT 0;


ALTER TABLE [dbo].[EstadoCuenta]
ADD 
    [FechaApertura_d] DATE NULL,        -- Fecha de apertura del estado de cuenta
    [FechaCierre_d] DATE NULL,          -- Fecha de cierre del estado de cuenta
    [MotivoCierre_c] CHAR(1) NULL; 

GO
ALTER TABLE [dbo].[DetalleGrupo] 
DROP CONSTRAINT FK_DetalleGrupo_Asignacion;

GO
-- Eliminar la columna IdAsignacion_i de la tabla DetalleGrupo
ALTER TABLE [dbo].[DetalleGrupo]
DROP COLUMN [IdAsignacion_i];

GO
-- Agregar la columna IdSorteo_i a la tabla Asignacion
ALTER TABLE [dbo].[Asignacion]
ADD [IdSorteo_i] INT NOT NULL;

GO
ALTER TABLE [dbo].[Asignacion]
ADD CONSTRAINT FK_Asignacion_Sorteo FOREIGN KEY ([IdSorteo_i]) 
REFERENCES [dbo].[Sorteo]([IdSorteo_i]);