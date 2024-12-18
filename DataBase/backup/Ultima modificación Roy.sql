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




--////////////////////////////
--/////// DETALLE DE GRUPO ////////////
--////////////////////////////
CREATE OR ALTER PROCEDURE GrupoValidarDoc
AS
BEGIN
	SELECT	DG.IdGrupo_i,
			GR.Codigo_c,
			DG.IdCliente_i,
			CL.Codigo_c,
			DG.IdDocumentos_i,
			DOC.Estado_c,
			DOC.FileDocIdentidad_by AS DNI,
			DOC.FileAntecedentesPenales_by AS Antecedentes,
			DOC.FileReciboLuzAgua_by AS Recibo,
			DOC.FileEquifax_by AS Equifax
	FROM DetalleGrupo AS DG
	JOIN Grupo AS GR
		ON DG.IdGrupo_i = GR.IdGrupo_i
	JOIN Documento AS DOC
		ON DOC.IdDocumento_i = DG.IdDocumentos_i
	JOIN Cliente AS CL
		ON DG.IdCliente_i = CL.IdCliente_i
	ORDER BY DG.IdGrupo_i, DG.IdCliente_i
END;
GO

SELECT * FROM Estado

INSERT INTO Estado(Abreviatura_C, Descripcion_VC)
VALUES ('P','Pendiente'),
		('V','Validado'),
		('R','Rechazado'),
		('O','Observado')

--VISUALIZAR
CREATE OR ALTER PROCEDURE GrupoListarCompleto
AS
BEGIN
	SELECT	
	FROM Grupo AS GR
	JOIN DetalleGrupo AS DG
		ON GR.IdGrupo_i = DG.IdGrupo_i
	JOIN Documento AS DO
		ON DG.IdDocumentos_i = Documento.IdDocumento_i

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


