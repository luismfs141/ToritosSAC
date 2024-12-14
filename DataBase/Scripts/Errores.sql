-- Error Linea 651 Modificaciones Roy
ALTER TABLE Modelo
    ADD CONSTRAINT CHK_Proveedor_Estado CHECK (Estado_c IN ('A', 'I'));
GO