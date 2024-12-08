ALTER TABLE Grupo
DROP CONSTRAINT CK__Grupo__CantidadC__5DCAEF64;

ALTER TABLE Grupo
ADD CONSTRAINT CK_CantidadCuotas_i CHECK (CantidadCuotas_i > 0 AND CantidadCuotas_i < 50);


--CAMBIAR ESTADO GRUPO

ALTER TABLE Grupo
DROP CONSTRAINT CK__Grupo__Estado_c__60A75C0F;

ALTER TABLE Grupo
ADD CONSTRAINT CK_GrupoEstadoC
CHECK ([Estado_c] IN ('E', 'A', 'C', 'F', 'T'));