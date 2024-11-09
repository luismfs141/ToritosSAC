UPDATE Cliente
SET Password_bi = HASHBYTES('SHA2_256', '12345.')
WHERE IdCliente_i = 3;