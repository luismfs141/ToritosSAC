-- Procedimiento para agregar grupo a lista de cliente
Create Or Alter Procedure AñadirClientesGrupo
	@idGrupo int
AS
BEGIN
	Declare @numIntegrantesFaltantes int
	Declare @CantActualIntegrantes int

	Select @CantActualIntegrantes = COUNT(D.IdDetalleGrupo_i)
	from DetalleGrupo D
	Where D.IdGrupo_i = @idGrupo

	Select @numIntegrantesFaltantes =  g.CantMaxIntegrantes_i - @CantActualIntegrantes
	From Grupo g 
	Where g.IdGrupo_i = @idGrupo

	Select @numIntegrantesFaltantes

	Insert into DetalleGrupo
	SELECT TOP (@numIntegrantesFaltantes) @idGrupo,IdCliente_i, NULL, NULL, 0, 'N'
	FROM Cliente;
END

--exec AñadirClientesGrupo 56

--Procedimientos para crear y actualizar documentos
-- Procedimiento para crear documentos
GO
CREATE OR ALTER PROCEDURE InsertarDocumento
    @FileDocIdentidad_by VARBINARY(MAX),
    @FileAntecedentesPenales_by VARBINARY(MAX),
    @FileReciboLuzAgua_by VARBINARY(MAX),
    @FileEquifax_by VARBINARY(MAX),
    @Estado_c CHAR(1),
    @FechaAprovacion_d DATETIME,
    @IdDocumento_i INT OUTPUT -- Parámetro de salida para el ID insertado
AS
BEGIN
    -- Inserta un nuevo documento en la tabla Documento
    INSERT INTO Documento (
        FileDocIdentidad_by,
        FileAntecedentesPenales_by,
        FileReciboLuzAgua_by,
        FileEquifax_by,
        Estado_c,
        FechaAprovacion_d
    )
    VALUES (
        @FileDocIdentidad_by,
        @FileAntecedentesPenales_by,
        @FileReciboLuzAgua_by,
        @FileEquifax_by,
        @Estado_c,
        @FechaAprovacion_d
    );

    -- Devuelve el IdDocumento_i generado
    SET @IdDocumento_i = SCOPE_IDENTITY(); -- Obtiene el último valor insertado en la tabla

    -- Opcionalmente, puedes devolver el IdDocumento_i como resultado
    SELECT @IdDocumento_i AS IdDocumento_i;
END;


--Procedimiento para crear e insertar documentos a clientes por grupo
GO
CREATE PROCEDURE InsertarYActualizarDocumento
    @IdGrupo_i INT,
    @FileDocIdentidad_by VARBINARY(MAX),
    @FileAntecedentesPenales_by VARBINARY(MAX),
    @FileReciboLuzAgua_by VARBINARY(MAX),
    @FileEquifax_by VARBINARY(MAX),
    @Estado_c CHAR(1),
    @FechaAprovacion_d DATETIME
AS
BEGIN
    DECLARE @IdDetalleGrupo_i INT;
    DECLARE @IdCliente_i INT;
    DECLARE @IdDocumento_i INT;
    
    -- Declarar un cursor para recorrer los registros de DetalleGrupo donde IdDocumentos_i es NULL
    DECLARE cursorDetalles CURSOR FOR
    SELECT IdDetalleGrupo_i, IdCliente_i
    FROM DetalleGrupo
    WHERE IdDocumentos_i IS NULL AND IdGrupo_i = @IdGrupo_i;
    
    OPEN cursorDetalles;
    
    FETCH NEXT FROM cursorDetalles INTO @IdDetalleGrupo_i, @IdCliente_i;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Insertar un documento utilizando el procedimiento InsertarDocumento
        EXEC InsertarDocumento 
            @FileDocIdentidad_by = @FileDocIdentidad_by,
            @FileAntecedentesPenales_by = @FileAntecedentesPenales_by,
            @FileReciboLuzAgua_by = @FileReciboLuzAgua_by,
            @FileEquifax_by = @FileEquifax_by,
            @Estado_c = @Estado_c,
            @FechaAprovacion_d = @FechaAprovacion_d,
            @IdDocumento_i = @IdDocumento_i OUTPUT;

        -- Actualizar la tabla DetalleGrupo con el IdDocumento_i obtenido
        UPDATE DetalleGrupo
        SET IdDocumentos_i = @IdDocumento_i
        WHERE IdDetalleGrupo_i = @IdDetalleGrupo_i;

        -- Obtener la siguiente fila del cursor
        FETCH NEXT FROM cursorDetalles INTO @IdDetalleGrupo_i, @IdCliente_i;
    END;
    
    CLOSE cursorDetalles;
    DEALLOCATE cursorDetalles;
END;

/*
EXEC InsertarYActualizarDocumento
    @IdGrupo_i = 56,
    @FileDocIdentidad_by = 0x123456,
    @FileAntecedentesPenales_by = 0xABCDEF,
    @FileReciboLuzAgua_by = 0x987654,
    @FileEquifax_by = NULL,
    @Estado_c = 'A',
    @FechaAprovacion_d = null
*/

--Procedimiento para solicitar unión de grupo masivo
GO
CREATE OR ALTER PROCEDURE SolicitarTodosUnionGrupo
	@idGrupo int
AS
BEGIN
	UPDATE DetalleGrupo
	SET Admision_C = 'P'
	WHERE Admision_C = 'N' AND IdGrupo_i = @idGrupo
END

--Exec SolicitarTodosUnionGrupo 56