--///////////////////////////////////////////
--//////////////// PROVEEDOR ////////////////
--///////////////////////////////////////////
--LISTAR
CREATE OR ALTER PROCEDURE ProveedorListar
AS
BEGIN
SELECT	PR.IdProveedor_i,
		PR.Nombre_nv,
		PR.Contacto_v,
		PR.CargoContacto_nv,
		PR.Direccion_nv,
		PA.Nombre_nv AS NombrePais,
		PR.IdPais_i,
		ES.Descripcion_vc
FROM Proveedor AS PR
JOIN Pais AS PA
	ON PR.IdPais_i = PA.IdPais_i
join Estado AS ES
	ON PR.Estado_c = ES.Abreviatura_c
END;
GO

--BUSCAR
CREATE OR ALTER PROCEDURE ProveedorBuscar
@Nombre_nv VARCHAR(80)
AS
BEGIN
SELECT	PR.IdProveedor_i,
		PR.Nombre_nv,
		PR.Contacto_v,
		PR.CargoContacto_nv,
		PR.Direccion_nv,
		PA.Nombre_nv AS NombrePais,
		PR.IdPais_i,
		ES.Descripcion_vc
FROM Proveedor AS PR
JOIN Pais AS PA
	ON PR.IdPais_i = PA.IdPais_i
join Estado AS ES
	ON PR.Estado_c = ES.Abreviatura_c
WHERE PR.Nombre_nv LIKE '%'+@Nombre_nv+'%'
ORDER BY IdProveedor_i ASC
END;
GO

--INSERTAR
CREATE OR ALTER PROCEDURE ProveedorInsertar
@Nombre_nv VARCHAR(80),
@Contacto_v VARCHAR(15),
@CargoContacto_nv VARCHAR(15),
@Direccion_nv VARCHAR(120),
@IdPais_i CHAR(3)
AS
BEGIN
INSERT INTO Proveedor(Nombre_nv, Contacto_v, CargoContacto_nv, Direccion_nv, IdPais_i)
VALUES
(@Nombre_nv, @Contacto_v, @CargoContacto_nv, @Direccion_nv, @IdPais_i)
END;
GO

--ACTUALIZAR
CREATE OR ALTER PROCEDURE ProveedorActualizar
@IdProveedor_i INTEGER,
@Nombre_nv VARCHAR(80),
@Contacto_v VARCHAR(15),
@CargoContacto_nv VARCHAR(15),
@Direccion_nv VARCHAR(120),
@IdPais_i CHAR(3)
AS
BEGIN
UPDATE Proveedor
SET Nombre_nv = @Nombre_nv,
	Contacto_v = @Contacto_v,
	CargoContacto_nv = @CargoContacto_nv,
	Direccion_nv = @Direccion_nv,
	IdPais_i = @IdPais_i
WHERE IdProveedor_i = @IdProveedor_i
END;
GO

--ELIMINAR
CREATE OR ALTER PROCEDURE ProveedorEliminar
@IdProveedor_i INTEGER
AS
BEGIN
DELETE FROM Proveedor
WHERE IdProveedor_i = @IdProveedor_i
END;
GO

--DESACTIVAR
CREATE OR ALTER PROCEDURE ProveedorDesactivar
@IdProveedor_i INTEGER
AS
BEGIN
UPDATE Proveedor
SET	Estado_c = 'I'
WHERE IdProveedor_i = @IdProveedor_i
END;
GO
--ACTIVAR
CREATE OR ALTER PROCEDURE ProveedorActivar
@IdProveedor_i INTEGER
AS
BEGIN
UPDATE Proveedor
SET	Estado_c = 'A'
WHERE  IdProveedor_i = @IdProveedor_i
END;
GO

--CATEGORIA EXISTENTE
CREATE OR ALTER PROCEDURE ProveedorExistente
@Nombre_nv VARCHAR(80),
@Existe BIT OUTPUT
AS
BEGIN
	IF EXISTS (SELECT Nombre_nv FROM Proveedor WHERE Nombre_nv = LTRIM(RTRIM(@Nombre_nv)))
		BEGIN 
			SET @Existe = 1
		END
	ELSE
		BEGIN
			SET @Existe = 0
		END
END;
GO



--LISTAR PAIS
CREATE OR ALTER PROCEDURE ListarPais
AS
BEGIN
	SELECT	IdPais_i,
			Nombre_nv
	FROM Pais
END;
GO



--///////////////////////////////////////////
--//////////////// MARCA /////////////////
--///////////////////////////////////////////
--LISTAR
CREATE OR ALTER PROCEDURE MarcaListar
AS
BEGIN
SELECT	MA.IdMarca_i,
		MA.Nombre_nv,
		MA.SitioWeb_nv,
		MA.Estado_c,
		ES.Descripcion_vc
FROM Marca AS MA
JOIN Estado AS ES
	ON MA.Estado_c = ES.Abreviatura_c
END;
GO

--BUSCAR
CREATE OR ALTER PROCEDURE MarcaBuscar
@Nombre_nv VARCHAR(80)
AS
BEGIN
SELECT	MA.IdMarca_i,
		MA.Nombre_nv,
		MA.SitioWeb_nv,
		MA.Estado_c,
		ES.Descripcion_vc
FROM Marca AS MA
JOIN Estado AS ES
	ON MA.Estado_c = ES.Abreviatura_c
WHERE MA.Nombre_nv LIKE '%'+@Nombre_nv+'%'
ORDER BY MA.Nombre_nv ASC
END;
GO

--INSERTAR
CREATE OR ALTER PROCEDURE MarcaInsertar
@Nombre_nv VARCHAR(80),
@SitioWeb_nv VARCHAR(100)
AS
BEGIN
INSERT INTO Marca(Nombre_nv, SitioWeb_nv)
VALUES
(@Nombre_nv, @SitioWeb_nv)
END;
GO

--ACTUALIZAR
CREATE OR ALTER PROCEDURE MarcaActualizar
@IdMarca_i INTEGER,
@Nombre_nv VARCHAR(80),
@SitioWeb_nv VARCHAR(100)
AS
BEGIN
UPDATE Marca
SET Nombre_nv = @Nombre_nv,
	SitioWeb_nv = @SitioWeb_nv
WHERE IdMarca_i = @IdMarca_i
END;
GO

--ELIMINAR
CREATE OR ALTER PROCEDURE MarcaEliminar
@IdMarca_i INTEGER
AS
BEGIN
DELETE FROM Marca
WHERE IdMarca_i = @IdMarca_i
END;
GO

--DESACTIVAR
CREATE OR ALTER PROCEDURE MarcaDesactivar
@IdMarca_i INTEGER
AS
BEGIN
UPDATE Marca
SET	Estado_c = 'I'
WHERE IdMarca_i = @IdMarca_i
END;
GO
--ACTIVAR
CREATE OR ALTER PROCEDURE MarcaActivar
@IdMarca_i INTEGER
AS
BEGIN
UPDATE Marca
SET	Estado_c = 'A'
WHERE  IdMarca_i = @IdMarca_i
END;
GO

--MARCA EXISTENTE
CREATE OR ALTER PROCEDURE MarcaExistente
@Nombre_nv VARCHAR(80),
@Existe BIT OUTPUT
AS
BEGIN
	IF EXISTS (SELECT Nombre_nv FROM Marca WHERE Nombre_nv = LTRIM(RTRIM(@Nombre_nv)))
		BEGIN 
			SET @Existe = 1
		END
	ELSE
		BEGIN
			SET @Existe = 0
		END
END;
GO

--///////////////////////////////////////////
--//////////////// MODELO /////////////////
--///////////////////////////////////////////
--LISTAR MARCAS ACTIVAS
CREATE OR ALTER PROCEDURE ModeloSeleccionarMarca
AS
BEGIN
SELECT	IdMarca_i,
		Nombre_nv
FROM Marca
WHERE Estado_c = 'A'
END;
GO

--LISTAR TIPO DE MODELO
CREATE OR ALTER PROCEDURE ModeloSeleccionarTipo
AS
BEGIN
SELECT	Abreviatura_c, 
		Descripcion_vc
FROM TipoModelo
END;
GO


--LISTAR
CREATE OR ALTER PROCEDURE ModeloListar
AS
BEGIN
SELECT	MO.IdModeloVehiculo_i,
		MO.Nombre_nv,
		MO.IdMarca_i,
		MA.Nombre_nv AS NombreMarca,
		MO.Tipo_c,
		TM.Descripcion_vc,
		MO.PrecioUnidadVehiculo_m,
		MO.Estado_c,
		ES.Descripcion_vc
FROM Modelo AS MO
JOIN Marca AS MA
	ON MO.IdMarca_i = MA.IdMarca_i
JOIN TipoModelo AS TM
	ON MO.Tipo_c = TM.Abreviatura_c
JOIN Estado AS ES
	ON MO.Estado_c = ES.Abreviatura_c
END;
GO

--BUSCAR
CREATE OR ALTER PROCEDURE ModeloBuscar
@Nombre_nv VARCHAR(80)
AS
BEGIN
SELECT	MO.IdModeloVehiculo_i,
		MO.Nombre_nv,
		MO.IdMarca_i,
		MA.Nombre_nv AS NombreMarca,
		MO.Tipo_c,
		TM.Descripcion_vc,
		MO.PrecioUnidadVehiculo_m,
		MO.Estado_c,
		ES.Descripcion_vc
FROM Modelo AS MO
JOIN Marca AS MA
	ON MO.IdMarca_i = MA.IdMarca_i
JOIN TipoModelo AS TM
	ON MO.Tipo_c = TM.Abreviatura_c
JOIN Estado AS ES
	ON MO.Estado_c = ES.Abreviatura_c
WHERE MO.Nombre_nv LIKE '%'+@Nombre_nv+'%' OR MA.Nombre_nv LIKE '%'+@Nombre_nv+'%'
ORDER BY MA.Nombre_nv ASC
END;
GO

--INSERTAR
CREATE OR ALTER PROCEDURE ModeloInsertar
@IdMarca_i INTEGER,
@Nombre_nv VARCHAR(50),
@Tipo_c CHAR(1),
@PrecioUnidadVehiculo_m MONEY
AS
BEGIN
INSERT INTO Modelo(IdMarca_i, Nombre_nv, Tipo_c, PrecioUnidadVehiculo_m)
VALUES
(@IdMarca_i, @Nombre_nv, @Tipo_c, @PrecioUnidadVehiculo_m)
END;
GO

--ACTUALIZAR
CREATE OR ALTER PROCEDURE ModeloActualizar
@IdModeloVehiculo_i INTEGER,
@IdMarca_i INTEGER,
@Nombre_nv VARCHAR(50),
@Tipo_c CHAR(1),
@PrecioUnidadVehiculo_m MONEY
AS
BEGIN
UPDATE Modelo
SET IdMarca_i = @IdMarca_i,
	Nombre_nv = @Nombre_nv,
	Tipo_c = @Tipo_c,
	PrecioUnidadVehiculo_m = @PrecioUnidadVehiculo_m
WHERE IdModeloVehiculo_i = @IdModeloVehiculo_i
END;
GO

--ELIMINAR
CREATE OR ALTER PROCEDURE ModeloEliminar
@IdModeloVehiculo_i INTEGER
AS
BEGIN
DELETE FROM Modelo
WHERE IdModeloVehiculo_i = @IdModeloVehiculo_i
END;
GO

--DESACTIVAR
CREATE OR ALTER PROCEDURE ModeloDesactivar
@IdModeloVehiculo_i INTEGER
AS
BEGIN
UPDATE Modelo
SET	Estado_c = 'I'
WHERE IdModeloVehiculo_i = @IdModeloVehiculo_i
END;
GO

--ACTIVAR
CREATE OR ALTER PROCEDURE ModeloActivar
@IdModeloVehiculo_i INTEGER
AS
BEGIN
UPDATE Modelo
SET	Estado_c = 'A'
WHERE  IdModeloVehiculo_i = @IdModeloVehiculo_i
END;
GO

--MARCA EXISTENTE
CREATE OR ALTER PROCEDURE ModeloExistente
@Nombre_nv VARCHAR(80),
@Existe BIT OUTPUT
AS
BEGIN
	IF EXISTS (SELECT Nombre_nv FROM Modelo WHERE Nombre_nv = LTRIM(RTRIM(@Nombre_nv)))
		BEGIN 
			SET @Existe = 1
		END
	ELSE
		BEGIN
			SET @Existe = 0
		END
END;
GO


--///////////////////////////////////////////
--//////////////// VEHICULO /////////////////
--///////////////////////////////////////////
--LISTAR MARCAS ACTIVAS
CREATE OR ALTER PROCEDURE VehiculoSeleccionarMarca
AS
BEGIN
SELECT	IdMarca_i,
		Nombre_nv
FROM Marca
WHERE Estado_c = 'A'
END;
GO

--LISTAR MARCAS ACTIVAS
CREATE OR ALTER PROCEDURE VehiculoSeleccionarColor
AS
BEGIN
SELECT	Abreviatura_c, 
		Descripcion_vc
FROM Color
END;
GO


--LISTAR
CREATE OR ALTER PROCEDURE VehiculoListar
AS
BEGIN
SELECT	VE.IdModeloVehiculo_i,
		VE.IdProveedor_i,
		VE.Serie_nv,
		VE.Placa_c,
		VE.AnioFabricacion_d,
		VE.PrecioCompraVehiculo_m,
		VE.Color_c,
		VE.FechaIngreso_d,
		VE.Estado_c,
		ES.Descripcion_vc
FROM Vehiculo AS VE
JOIN Estado AS ES
	ON VE.Estado_c = ES.Abreviatura_c
JOIN Color AS CO
	ON VE.Color_c = CO.Abreviatura_c
JOIN Proveedor AS PR
	ON VE.IdProveedor_i = PR.IdProveedor_i
JOIN Marca AS MA
	ON VE.IdModeloVehiculo_i = MA.IdMarca_i
END;
GO

--BUSCAR
CREATE OR ALTER PROCEDURE VehiculoBuscar
@Nombre_nv VARCHAR(80)
AS
BEGIN
SELECT	MA.IdMarca_i,
		MA.Nombre_nv,
		MA.SitioWeb_nv,
		MA.Estado_c,
		ES.Descripcion_vc
FROM Marca AS MA
JOIN Estado AS ES
	ON MA.Estado_c = ES.Abreviatura_c
WHERE MA.Nombre_nv LIKE '%'+@Nombre_nv+'%'
ORDER BY MA.Nombre_nv ASC
END;
GO

--INSERTAR
CREATE OR ALTER PROCEDURE VehiculoInsertar
@Nombre_nv VARCHAR(80),
@SitioWeb_nv VARCHAR(100)
AS
BEGIN
INSERT INTO Marca(Nombre_nv, SitioWeb_nv)
VALUES
(@Nombre_nv, @SitioWeb_nv)
END;
GO

--ACTUALIZAR
CREATE OR ALTER PROCEDURE VehiculoActualizar
@IdMarca_i INTEGER,
@Nombre_nv VARCHAR(80),
@SitioWeb_nv VARCHAR(100)
AS
BEGIN
UPDATE Marca
SET Nombre_nv = @Nombre_nv,
	SitioWeb_nv = @SitioWeb_nv
WHERE IdMarca_i = @IdMarca_i
END;
GO

--ELIMINAR
CREATE OR ALTER PROCEDURE VehiculoEliminar
@IdMarca_i INTEGER
AS
BEGIN
DELETE FROM Marca
WHERE IdMarca_i = @IdMarca_i
END;
GO

--DESACTIVAR
CREATE OR ALTER PROCEDURE VehiculoDesactivar
@IdMarca_i INTEGER
AS
BEGIN
UPDATE Marca
SET	Estado_c = 'I'
WHERE IdMarca_i = @IdMarca_i
END;
GO
--ACTIVAR
CREATE OR ALTER PROCEDURE VehiculoActivar
@IdMarca_i INTEGER
AS
BEGIN
UPDATE Marca
SET	Estado_c = 'A'
WHERE  IdMarca_i = @IdMarca_i
END;
GO

--MARCA EXISTENTE
CREATE OR ALTER PROCEDURE VehiculoExistente
@Nombre_nv VARCHAR(80),
@Existe BIT OUTPUT
AS
BEGIN
	IF EXISTS (SELECT Nombre_nv FROM Marca WHERE Nombre_nv = LTRIM(RTRIM(@Nombre_nv)))
		BEGIN 
			SET @Existe = 1
		END
	ELSE
		BEGIN
			SET @Existe = 0
		END
END;
GO



--///////////////////////////////////////
--//////////////// ROLES ////////////////
--///////////////////////////////////////

--LISTAR ROL
CREATE OR ALTER PROCEDURE RolListar
AS
BEGIN 
	SELECT	RO.IdRol_i,
			RO.Nombre_v,
			RO.Descripcion_v,
			RO.Estado_c,
			ES.Descripcion_vc
	FROM Rol AS RO
	JOIN Estado AS ES
		ON RO.Estado_c = ES.Abreviatura_c
END;
GO

--///////////////////////////////////////////
--//////////////// USUASRIOS ////////////////
--///////////////////////////////////////////

--PROCEDIMIENTO LISTAR
CREATE OR ALTER PROCEDURE UsuarioListar
AS
BEGIN
	SELECT	U.IdUsuario_i AS ID,
			U.IdRol_i, 
			R.Nombre_v AS Rol,
			U.Nombre_v AS Nombre,
			U.TipoDocumento_c AS Tipo_Documento,
			U.NroDocumento_v AS Num_Documento,
			U.Direccion_v AS Direccion,
			U.Telefono_c AS Telefono,
			U.Correo_v AS Correo,
			U.Estado_c AS Estado
	FROM Usuario AS U 
	JOIN Rol AS R 
		ON U.IdRol_i = R.IdRol_i
	ORDER BY U.IdUsuario_i desc
END;
GO

----LISTAR USUARIOS ACTIVOS
--CREATE OR ALTER PROCEDURE UsuarioCursoCategoriaListarActivos
--AS
--BEGIN
--	SELECT	IdCategoria,
--			Nombre
--	FROM Categoria
--	WHERE Estado = 1
--END;
--GO

--PROCEDIMIENTO BUSCAR
CREATE OR ALTER PROCEDURE UsuarioBuscar
@Valor VARCHAR(50)
AS
BEGIN
	SELECT	U.IdUsuario_i AS ID,
			U.IdRol_i, 
			R.Nombre_v AS Rol,
			U.Nombre_v AS Nombre,
			U.TipoDocumento_c AS Tipo_Documento,
			U.NroDocumento_v AS Num_Documento,
			U.Direccion_v AS Direccion,
			U.Telefono_c AS Telefono,
			U.Correo_v AS Correo,
			U.Estado_c AS Estado
	FROM Usuario AS U 
	JOIN Rol AS R 
		ON U.IdRol_i = R.IdRol_i
	WHERE U.Nombre_v like '%' +@Valor + '%' 
			Or U.Correo_v like '%' +@Valor + '%'
	ORDER BY U.Nombre_v ASC
END;
GO


--Procedimiento Insertar
CREATE OR ALTER PROCEDURE UsuarioInsertar
	@IdRol_i integer,
	@Nombre_v VARCHAR(50),
	@TipoDocumento_c CHAR(1),
	@NroDocumento_v VARCHAR(20),
	@Direccion_v VARCHAR(70),
	@Telefono_c CHAR(20),
	@Correo_v VARCHAR(50),
	@Clave_vb VARCHAR(64)
AS
BEGIN
	INSERT INTO Usuario(IdRol_i, Nombre_v, TipoDocumento_c, NroDocumento_v, Direccion_v, Telefono_c, Correo_v, Clave_vb)
	VALUES (@IdRol_i,@Nombre_v,@TipoDocumento_c,@NroDocumento_v,@Direccion_v, @Telefono_c, @Correo_v,HASHBYTES('SHA2_256',@Clave_vb))
END;
GO

--PROCEDIMIENTO ACTUALIZAR
CREATE OR ALTER PROCEDURE UsuarioActualizar
	@IdUsuario_i INTEGER,
	@IdRol_i INTEGER,
	@Nombre_v VARCHAR(50),
	@TipoDocumento_c CHAR(1),
	@NroDocumento_v VARCHAR(20),
	@Direccion_v VARCHAR(70),
	@Telefono_c CHAR(9),
	@Correo_v VARCHAR(50),
	@Clave_vb VARBINARY(64)
AS
BEGIN
	IF @Clave_vb <> ''
	UPDATE Usuario 
	SET	IdRol_i = @IdRol_i,
		Nombre_v = @Nombre_v,
		TipoDocumento_c = @TipoDocumento_c,
		NroDocumento_v = @NroDocumento_v,
		Direccion_v = @Direccion_v,
		Telefono_c = @Telefono_c,
		Correo_v = @Correo_v,
		Clave_vb = HASHBYTES('SHA2_256', @Clave_vb)
	WHERE IdUsuario_i=@IdUsuario_i;
	ELSE
	UPDATE Usuario 
	SET IdRol_i = @IdRol_i,
		Nombre_v = @Nombre_v,
		TipoDocumento_c = @TipoDocumento_c,
		NroDocumento_v = @NroDocumento_v,
		Direccion_v = @Direccion_v,
		Telefono_c = @Telefono_c,
		Correo_v = @Correo_v
	WHERE IdUsuario_i = @IdUsuario_i
END;
GO

--PROCEDIMIENTO ELIMINAR
CREATE OR ALTER PROCEDURE UsuarioEliminar
@IdUsuario_i INTEGER
AS
BEGIN
	DELETE FROM Usuario
	WHERE IdUsuario_i = @IdUsuario_i
END
GO

--PROCEDIMIENTO DESACTIVAR
CREATE OR ALTER PROCEDURE UsuarioDesactivar
@IdUsuario_i INTEGER
AS
BEGIN
	UPDATE Usuario
	SET	Estado_c = 'I'
	WHERE IdUsuario_i = @IdUsuario_i
END;
GO

--PROCEDIMIENTO ACTIVAR
CREATE OR ALTER PROCEDURE UsuarioActivar
@IdUsuario_i INTEGER
AS
BEGIN
	UPDATE Usuario
	SET	Estado_c = 'A'
	WHERE  IdUsuario_i = @IdUsuario_i
END;
GO

-- PROCEDIMIENTO VERIFICAR EXISTENCIA
CREATE OR ALTER PROCEDURE UsuarioExistente
@Correo_v VARCHAR(50),
@Existe BIT OUTPUT
AS
BEGIN
	IF 
		EXISTS (SELECT Correo_v FROM Usuario WHERE Correo_v = ltrim(rtrim(@Correo_v)))
		BEGIN
			SET @Existe = 1
		END
	ELSE
		BEGIN
			SET @Existe = 0
		END
END;
GO


CREATE OR ALTER PROCEDURE ListarTipoDocumento
AS
BEGIN
	SELECT	Nombre_v, 
			Codigo_c
	FROM UsuarioTipoDocumento
END;
GO

--/////////////////
CREATE OR ALTER PROCEDURE UsuarioLogin
@Correo_v NVARCHAR(50),
@Clave_vb VARCHAR(64)
AS
BEGIN
	SELECT	U.IdUsuario_i,
			U.IdRol_i,
			R.Nombre_v AS Rol,
			U.Nombre_v AS Nombre,
			U.Estado_c
	FROM Usuario AS U
	JOIN Rol AS R
		ON U.IdRol_i = R.IdRol_i
	WHERE U.Correo_v = @Correo_v
		AND U.Clave_vb = HASHBYTES('SHA2_256', @Clave_vb)
END;
GO