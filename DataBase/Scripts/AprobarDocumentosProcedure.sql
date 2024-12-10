CREATE OR ALTER PROCEDURE CambiarEstadoDocumento
    @idDocumento INT,
    @estado CHAR(1)
AS
BEGIN
    DECLARE @admin BIT = 0;
    DECLARE @idGrupo INT = 0;

    UPDATE Documento
    SET Estado_c = @estado
    WHERE IdDocumento_i = @idDocumento;

    SELECT TOP 1
           @admin = ClienteAdmin_bo,
           @idGrupo = IdGrupo_i
    FROM DetalleGrupo
    WHERE IdDocumentos_i = @idDocumento;

    IF @admin = 1 AND @estado = 'A'
    BEGIN
        UPDATE Grupo
        SET Estado_c = 'A'
        WHERE IdGrupo_i = @idGrupo;
    END
END;


--Select * from Documento

--EXEC CambiarEstadoDocumento 27,'A'
