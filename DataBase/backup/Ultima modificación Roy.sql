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

select * from Cliente

select * from Rol






--////////////////////////////
--/////// CLIENTE ////////////
--////////////////////////////


--VISUALIZAR
CREATE OR ALTER PROCEDURE ClienteListar
AS
BEGIN
	SELECT	IdCliente_i,
			Codigo_c,
			Nombre_nv,
			ApellidoPaterno_nv,
			ApellidoMaterno_nv,
			TipoDocumento_c,
			NroDocumento_v,
			Sexo_c,
			FechaNacimiento_d,
			EstadoCivil_c,
			NroContacto_c,
			Correo_nv,
			CorreoAutenticado_bo,
			Direccion_nv,
			DireccionRef_nv,
			IdDistrito_c,
			Estado_c,
			FechaInscripcion_d
	FROM Cliente
END;
GO





--DESACTIVAR
CREATE OR ALTER PROCEDURE ClienteDesactivar
@IdCliente_i INTEGER
AS
BEGIN
	UPDATE Cliente
	SET	Estado_c = 'I'
	WHERE IdCliente_i = @IdCliente_i
END;
GO

--ACTIVAR
CREATE OR ALTER PROCEDURE ClienteActivar
@IdCliente_i INTEGER
AS
BEGIN
	UPDATE Cliente
	SET	Estado_c = 'A'
	WHERE IdCliente_i = @IdCliente_i
END;
GO











---------------------

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Cliente';


