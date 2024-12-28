-- 1. Agregar la columna IdGrupo_i
ALTER TABLE [dbo].[Sorteo]
ADD [IdGrupo_i] INT;

-- 2. Establecer la clave foránea que referencia la tabla Grupo
ALTER TABLE [dbo].[Sorteo]
ADD CONSTRAINT FK_Sorteo_Grupo
FOREIGN KEY ([IdGrupo_i])
REFERENCES [dbo].[Grupo]([IdGrupo_i]);