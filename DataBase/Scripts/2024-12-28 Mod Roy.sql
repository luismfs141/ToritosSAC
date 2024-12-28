CREATE TABLE EstadoDocumento
(
	Abreviatura_C char(1) NOT NULL,
	Descripcion_VC varchar(20) NOT NULL,
	Relevancia_i integer NOT NULL
	)
GO

INSERT INTO EstadoDocumento(Abreviatura_C,Descripcion_VC, Relevancia_i)
VALUES	('S','Sin registro',5),
		('O','Observado',2),
		('A','Aprobado',4),
		('R','Rechazado',3),
		('P','Pendiente',1)
		



ALTER TABLE [dbo].[Documento]
DROP COLUMN [FileEquifax_by];
GO


ALTER TABLE [dbo].[Documento]
ADD 
    [EstadoFileDocIdentidad_C] CHAR(1) NOT NULL DEFAULT ('S'),
    [EstadoFileAntecedentesPenales_C] CHAR(1) NOT NULL DEFAULT ('S'),
    [EstadoFileReciboLuzAgua_C] CHAR(1) NOT NULL DEFAULT ('S');
GO


--///////////////////////////////////////////
--//////////////// DOCUMENTO ////////////////
--///////////////////////////////////////////
--LISTAR
CREATE OR ALTER PROCEDURE DocumentoListar
AS
BEGIN
	SELECT	DG.IdGrupo_i,
			GR.Codigo_c,
			DG.IdCliente_i,
			UPPER(CL.ApellidoPaterno_nv + ' ' + CL.ApellidoMaterno_nv + ' ' + CL.Nombre_nv) AS Cliente,
			DO.IdDocumento_i,

			DO.EstadoFileDocIdentidad_C,
			ED1.Descripcion_VC,
			ED1.Relevancia_i,

			DO.EstadoFileAntecedentesPenales_C,
			ED2.Descripcion_VC,
			ED2.Relevancia_i,

			DO.EstadoFileReciboLuzAgua_C,
			ED3.Descripcion_VC,
			ED3.Relevancia_i,

			DO.Estado_c,
			ED4.Descripcion_VC,
			
			DO.FileDocIdentidad_by,
			DO.FileAntecedentesPenales_by,
			DO.FileReciboLuzAgua_by
	FROM Documento AS DO
	JOIN EstadoDocumento AS ED1
		ON DO.EstadoFileDocIdentidad_C = ED1.Abreviatura_C
	JOIN EstadoDocumento AS ED2
		ON DO.EstadoFileAntecedentesPenales_C = ED2.Abreviatura_C
	JOIN EstadoDocumento AS ED3
		ON DO.EstadoFileReciboLuzAgua_C = ED3.Abreviatura_C
	JOIN EstadoDocumento AS ED4
		ON DO.Estado_c = ED4.Abreviatura_C
	JOIN DetalleGrupo AS DG
		ON DG.IdDocumentos_i = DO.IdDocumento_i
	JOIN Grupo AS GR
		ON GR.IdGrupo_i = DG.IdGrupo_i
	JOIN Cliente AS CL
		ON CL.IdCliente_i = DG.IdCliente_i
	ORDER BY 1,2
END;
GO

--BUSCAR
CREATE OR ALTER PROCEDURE DocumentoBuscar
@Valor VARCHAR(80)
AS
BEGIN
	SELECT	DG.IdGrupo_i,
			GR.Codigo_c,
			DG.IdCliente_i,
			UPPER(CL.ApellidoPaterno_nv + ' ' + CL.ApellidoMaterno_nv + ' ' + CL.Nombre_nv) AS Cliente,
			DO.IdDocumento_i,

			--DO.FileDocIdentidad_by,
			DO.EstadoFileDocIdentidad_C,
			ED1.Descripcion_VC,
			ED1.Relevancia_i,

			--DO.FileAntecedentesPenales_by,
			DO.EstadoFileAntecedentesPenales_C,
			ED2.Descripcion_VC,
			ED2.Relevancia_i,

			--DO.FileReciboLuzAgua_by,
			DO.EstadoFileReciboLuzAgua_C,
			ED3.Descripcion_VC,
			ED3.Relevancia_i,

			DO.Estado_c,
			ED4.Descripcion_VC,

			DO.FileDocIdentidad_by,
			DO.FileAntecedentesPenales_by,
			DO.FileReciboLuzAgua_by
	FROM Documento AS DO
	JOIN EstadoDocumento AS ED1
		ON DO.EstadoFileDocIdentidad_C = ED1.Abreviatura_C
	JOIN EstadoDocumento AS ED2
		ON DO.EstadoFileAntecedentesPenales_C = ED2.Abreviatura_C
	JOIN EstadoDocumento AS ED3
		ON DO.EstadoFileReciboLuzAgua_C = ED3.Abreviatura_C
	JOIN EstadoDocumento AS ED4
		ON DO.Estado_c = ED4.Abreviatura_C
	JOIN DetalleGrupo AS DG
		ON DG.IdDocumentos_i = DO.IdDocumento_i
	JOIN Grupo AS GR
		ON GR.IdGrupo_i = DG.IdGrupo_i
	JOIN Cliente AS CL
		ON CL.IdCliente_i = DG.IdCliente_i

	WHERE CL.ApellidoPaterno_nv + ' ' + CL.ApellidoMaterno_nv + ' ' + CL.Nombre_nv LIKE '%'+@Valor+'%'
		OR GR.Codigo_c LIKE '%'+@Valor+'%'
	ORDER BY ED1.Relevancia_i, ED2.Relevancia_i, ED3.Relevancia_i ASC
END;
GO



--PRUEBA
--EXEC DocumentoBuscar @Valor = 'G000036';



-- DNI
-------------
CREATE OR ALTER PROCEDURE DocumentoAprobarDNI
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileDocIdentidad_C = 'A'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

CREATE OR ALTER PROCEDURE DocumentoRechazarDNI
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileDocIdentidad_C = 'R'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

CREATE OR ALTER PROCEDURE DocumentoObservarDNI
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileDocIdentidad_C = 'O'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

-- RECIBO
-------------
CREATE OR ALTER PROCEDURE DocumentoAprobarRecibo
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileReciboLuzAgua_C = 'A'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

CREATE OR ALTER PROCEDURE DocumentoRechazarRecibo
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileReciboLuzAgua_C = 'R'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

CREATE OR ALTER PROCEDURE DocumentoObservarRecibo
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileReciboLuzAgua_C = 'O'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

-- ANTECEDENTES
-------------
CREATE OR ALTER PROCEDURE DocumentoAprobarAntecedentes
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileAntecedentesPenales_C = 'A'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

CREATE OR ALTER PROCEDURE DocumentoRechazarAntecedentes
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileAntecedentesPenales_C = 'R'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO

CREATE OR ALTER PROCEDURE DocumentoObservarAntecedentes
@IdDocumento_i INTEGER
AS
BEGIN
UPDATE Documento
SET	EstadoFileAntecedentesPenales_C = 'O'
WHERE  IdDocumento_i = @IdDocumento_i
END;
GO




---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
VALUES	('S','Sin registro',5),
		('O','Observado',2),
		('A','Aprobado',4),
		('R','Rechazado',3),
		('P','Pendiente',1)

		
		EstadoFileDocIdentidad_C
		EstadoFileAntecedentesPenales_C
		EstadoFileReciboLuzAgua_C


select * from Grupo

select * from Usuario

SELECT * 
FROM Documento

SELECT * 
FROM Estado