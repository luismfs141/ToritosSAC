--03/12/2024
USE ToritosDB;
GO

-- Verificar si la columna 'Nombre_nv' existe y si es 'NULL', cambiarla a 'NOT NULL'
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'Nombre_nv' AND IS_NULLABLE = 'YES')
BEGIN
    ALTER TABLE Proveedor
    ALTER COLUMN Nombre_nv VARCHAR(80) NOT NULL;
END
GO

-- Verificar si la columna 'CargoContacto_nv' existe y si es 'NULL', cambiarla a 'NOT NULL'
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'CargoContacto_nv' AND IS_NULLABLE = 'YES')
BEGIN
    ALTER TABLE Proveedor
    ALTER COLUMN CargoContacto_nv VARCHAR(15) NOT NULL;
END
GO

-- Verificar si la columna 'Direccion_nv' existe y si es 'NULL', cambiarla a 'NOT NULL'
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
           WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'Direccion_nv' AND IS_NULLABLE = 'YES')
BEGIN
    ALTER TABLE Proveedor
    ALTER COLUMN Direccion_nv VARCHAR(120) NOT NULL;
END
GO

-- Verificar si la columna 'Estado_c' ya existe
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'Proveedor' AND COLUMN_NAME = 'Estado_c')
BEGIN
    ALTER TABLE Proveedor
    ADD Estado_c CHAR(1) NOT NULL DEFAULT 'A';
END
GO

-- Verificar si la restricci�n 'CHK_Proveedor_Estado' ya existe
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints 
               WHERE name = 'CHK_Proveedor_Estado' AND parent_object_id = OBJECT_ID('Proveedor'))
BEGIN
    ALTER TABLE Proveedor
    ADD CONSTRAINT CHK_Proveedor_Estado CHECK (Estado_c IN ('A', 'I'));
END
GO

-- Verificar si la columna 'Admision_C' ya existe en la tabla 'DetalleGrupo'
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
               WHERE TABLE_NAME = 'DetalleGrupo' AND COLUMN_NAME = 'Admision_C')
BEGIN
    ALTER TABLE [dbo].[DetalleGrupo]
    ADD [Admision_C] CHAR(1);
END
GO




--04/12/2024

INSERT INTO Distrito (IdDistrito_c, Nombre_nv, IdProvincia_C)
VALUES
('150501', 'San Vicente de Ca�ete', '1505'),
('150502', 'Asia', '1505'),
('150503', 'Calango', '1505'),
('150504', 'Cerro Azul', '1505'),
('150505', 'Chilca', '1505'),
('150506', 'Coayllo', '1505'),
('150507', 'Imperial', '1505'),
('150508', 'Lunahuana', '1505'),
('150509', 'Mala', '1505'),
('150510', 'Nuevo Imperial', '1505'),
('150511', 'Pacaran', '1505'),
('150512', 'Quilmana', '1505'),
('150513', 'San Antonio', '1505'),
('150514', 'San Luis', '1505'),
('150515', 'Santa Cruz de Flores', '1505'),
('150516', 'Z��iga', '1505'),
('150601', 'Huaral', '1506'),
('150602', 'Atavillos Alto', '1506'),
('150603', 'Atavillos Bajo', '1506'),
('150604', 'Aucallama', '1506'),
('150605', 'Chancay', '1506'),
('150606', 'Ihuari', '1506'),
('150607', 'Lampian', '1506'),
('150608', 'Pacaraos', '1506'),
('150609', 'San Miguel de Acos', '1506'),
('150610', 'Santa Cruz de Andamarca', '1506'),
('150611', 'Sumbilca', '1506'),
('150612', 'Veintisiete de Noviembre', '1506'),
('150701', 'Matucana', '1507'),
('150702', 'Antioquia', '1507'),
('150703', 'Callahuanca', '1507'),
('150704', 'Carampoma', '1507'),
('150705', 'Chicla', '1507'),
('150706', 'Cuenca', '1507'),
('150707', 'Huachupampa', '1507'),
('150708', 'Huanza', '1507'),
('150709', 'Huarochiri', '1507'),
('150710', 'Lahuaytambo', '1507'),
('150711', 'Langa', '1507'),
('150712', 'Laraos', '1507'),
('150713', 'Mariatana', '1507'),
('150714', 'Ricardo Palma', '1507'),
('150715', 'San Andr�s de Tupicocha', '1507'),
('150716', 'San Antonio', '1507'),
('150717', 'San Bartolom�', '1507'),
('150718', 'San Damian', '1507'),
('150719', 'San Juan de Iris', '1507'),
('150720', 'San Juan de Tantaranche', '1507'),
('150721', 'San Lorenzo de Quinti', '1507'),
('150722', 'San Mateo', '1507'),
('150723', 'San Mateo de Otao', '1507'),
('150724', 'San Pedro de Casta', '1507'),
('150725', 'San Pedro de Huancayre', '1507'),
('150726', 'Sangallaya', '1507'),
('150727', 'Santa Cruz de Cocachacra', '1507'),
('150728', 'Santa Eulalia', '1507'),
('150729', 'Santiago de Anchucaya', '1507'),
('150730', 'Santiago de Tuna', '1507'),
('150731', 'Santo Domingo de Los Olleros', '1507'),
('150732', 'Surco', '1507'),
('150801', 'Huacho', '1508'),
('150802', 'Ambar', '1508'),
('150803', 'Caleta de Carquin', '1508'),
('150804', 'Checras', '1508'),
('150805', 'Hualmay', '1508'),
('150806', 'Huaura', '1508'),
('150807', 'Leoncio Prado', '1508'),
('150808', 'Paccho', '1508'),
('150809', 'Santa Leonor', '1508'),
('150810', 'Santa Mar�a', '1508'),
('150811', 'Sayan', '1508'),
('150812', 'Vegueta', '1508'),
('150901', 'Oyon', '1509'),
('150902', 'Andajes', '1509'),
('150903', 'Caujul', '1509'),
('150904', 'Cochamarca', '1509'),
('150905', 'Navan', '1509'),
('150906', 'Pachangara', '1509'),
('151001', 'Yauyos', '1510'),
('151002', 'Alis', '1510'),
('151003', 'Allauca', '1510'),
('151004', 'Ayaviri', '1510'),
('151005', 'Az�ngaro', '1510'),
('151006', 'Cacra', '1510'),
('151007', 'Carania', '1510'),
('151008', 'Catahuasi', '1510'),
('151009', 'Chocos', '1510'),
('151010', 'Cochas', '1510'),
('151011', 'Colonia', '1510'),
('151012', 'Hongos', '1510'),
('151013', 'Huampara', '1510'),
('151014', 'Huancaya', '1510'),
('151015', 'Huangascar', '1510'),
('151016', 'Huantan', '1510'),
('151017', 'Hua�ec', '1510'),
('151018', 'Laraos', '1510'),
('151019', 'Lincha', '1510'),
('151020', 'Madean', '1510'),
('151021', 'Miraflores', '1510'),
('151022', 'Omas', '1510'),
('151023', 'Putinza', '1510'),
('151024', 'Quinches', '1510'),
('151025', 'Quinocay', '1510'),
('151026', 'San Joaqu�n', '1510'),
('151027', 'San Pedro de Pilas', '1510'),
('151028', 'Tanta', '1510'),
('151029', 'Tauripampa', '1510'),
('151030', 'Tomas', '1510'),
('151031', 'Tupe', '1510'),
('151032', 'Vi�ac', '1510'),
('151033', 'Vitis', '1510'),
('160101', 'Iquitos', '1601'),
('160102', 'Alto Nanay', '1601'),
('160103', 'Fernando Lores', '1601'),
('160104', 'Indiana', '1601'),
('160105', 'Las Amazonas', '1601'),
('160106', 'Mazan', '1601'),
('160107', 'Napo', '1601'),
('160108', 'Punchana', '1601'),
('160110', 'Torres Causana', '1601'),
('160112', 'Bel�n', '1601'),
('160113', 'San Juan Bautista', '1601'),
('160201', 'Yurimaguas', '1602'),
('160202', 'Balsapuerto', '1602'),
('160205', 'Jeberos', '1602'),
('160206', 'Lagunas', '1602'),
('160210', 'Santa Cruz', '1602'),
('160211', 'Teniente Cesar L�pez Rojas', '1602'),
('160301', 'Nauta', '1603'),
('160302', 'Parinari', '1603'),
('160303', 'Tigre', '1603'),
('160304', 'Trompeteros', '1603'),
('160305', 'Urarinas', '1603'),
('160401', 'Ram�n Castilla', '1604'),
('160402', 'Pebas', '1604'),
('160403', 'Yavari', '1604'),
('160404', 'San Pablo', '1604'),
('160501', 'Requena', '1605'),
('160502', 'Alto Tapiche', '1605'),
('160503', 'Capelo', '1605'),
('160504', 'Emilio San Mart�n', '1605'),
('160505', 'Maquia', '1605'),
('160506', 'Puinahua', '1605'),
('160507', 'Saquena', '1605'),
('160508', 'Soplin', '1605'),
('160509', 'Tapiche', '1605'),
('160510', 'Jenaro Herrera', '1605'),
('160511', 'Yaquerana', '1605'),
('160601', 'Contamana', '1606'),
('160602', 'Inahuaya', '1606'),
('160603', 'Padre M�rquez', '1606'),
('160604', 'Pampa Hermosa', '1606'),
('160605', 'Sarayacu', '1606'),
('160606', 'Vargas Guerra', '1606'),
('160701', 'Barranca', '1607'),
('160702', 'Cahuapanas', '1607'),
('160703', 'Manseriche', '1607'),
('160704', 'Morona', '1607'),
('160705', 'Pastaza', '1607'),
('160706', 'Andoas', '1607'),
('160801', 'Putumayo', '1608'),
('160802', 'Rosa Panduro', '1608'),
('160803', 'Teniente Manuel Clavero', '1608'),
('160804', 'Yaguas', '1608'),
('170101', 'Tambopata', '1701'),
('170102', 'Inambari', '1701'),
('170103', 'Las Piedras', '1701'),
('170104', 'Laberinto', '1701'),
('170201', 'Manu', '1702'),
('170202', 'Fitzcarrald', '1702'),
('170203', 'Madre de Dios', '1702'),
('170204', 'Huepetuhe', '1702'),
('170301', 'I�apari', '1703'),
('170302', 'Iberia', '1703'),
('170303', 'Tahuamanu', '1703'),
('180101', 'Moquegua', '1801'),
('180102', 'Carumas', '1801'),
('180103', 'Cuchumbaya', '1801'),
('180104', 'Samegua', '1801'),
('180105', 'San Crist�bal', '1801'),
('180106', 'Torata', '1801'),
('180201', 'Omate', '1802'),
('180202', 'Chojata', '1802'),
('180203', 'Coalaque', '1802'),
('180204', 'Ichu�a', '1802'),
('180205', 'La Capilla', '1802'),
('180206', 'Lloque', '1802'),
('180207', 'Matalaque', '1802'),
('180208', 'Puquina', '1802'),
('180209', 'Quinistaquillas', '1802'),
('180210', 'Ubinas', '1802'),
('180211', 'Yunga', '1802'),
('180301', 'Ilo', '1803'),
('180302', 'El Algarrobal', '1803'),
('180303', 'Pacocha', '1803'),
('190101', 'Chaupimarca', '1901'),
('190102', 'Huachon', '1901'),
('190103', 'Huariaca', '1901'),
('190104', 'Huayllay', '1901'),
('190105', 'Ninacaca', '1901'),
('190106', 'Pallanchacra', '1901'),
('190107', 'Paucartambo', '1901'),
('190108', 'San Francisco de As�s de Yarusyacan', '1901'),
('190109', 'Simon Bol�var', '1901'),
('190110', 'Ticlacayan', '1901'),
('190111', 'Tinyahuarco', '1901'),
('190112', 'Vicco', '1901'),
('190113', 'Yanacancha', '1901'),
('190201', 'Yanahuanca', '1902'),
('190202', 'Chacayan', '1902'),
('190203', 'Goyllarisquizga', '1902'),
('190204', 'Paucar', '1902'),
('190205', 'San Pedro de Pillao', '1902'),
('190206', 'Santa Ana de Tusi', '1902'),
('190207', 'Tapuc', '1902'),
('190208', 'Vilcabamba', '1902'),
('190301', 'Oxapampa', '1903'),
('190302', 'Chontabamba', '1903'),
('190303', 'Huancabamba', '1903'),
('190304', 'Palcazu', '1903'),
('190305', 'Pozuzo', '1903'),
('190306', 'Puerto Berm�dez', '1903'),
('190307', 'Villa Rica', '1903'),
('190308', 'Constituci�n', '1903'),
('200101', 'Piura', '2001'),
('200104', 'Castilla', '2001'),
('200105', 'Catacaos', '2001'),
('200107', 'Cura Mori', '2001'),
('200108', 'El Tallan', '2001'),
('200109', 'La Arena', '2001'),
('200110', 'La Uni�n', '2001'),
('200111', 'Las Lomas', '2001'),
('200114', 'Tambo Grande', '2001'),
('200115', 'Veintiseis de Octubre', '2001'),
('200201', 'Ayabaca', '2002'),
('200202', 'Frias', '2002'),
('200203', 'Jilili', '2002'),
('200204', 'Lagunas', '2002'),
('200205', 'Montero', '2002'),
('200206', 'Pacaipampa', '2002'),
('200207', 'Paimas', '2002'),
('200208', 'Sapillica', '2002'),
('200209', 'Sicchez', '2002'),
('200210', 'Suyo', '2002'),
('200301', 'Huancabamba', '2003'),
('200302', 'Canchaque', '2003'),
('200303', 'El Carmen de la Frontera', '2003'),
('200304', 'Huarmaca', '2003'),
('200305', 'Lalaquiz', '2003'),
('200306', 'San Miguel de El Faique', '2003'),
('200307', 'Sondor', '2003'),
('200308', 'Sondorillo', '2003'),
('200401', 'Chulucanas', '2004'),
('200402', 'Buenos Aires', '2004'),
('200403', 'Chalaco', '2004'),
('200404', 'La Matanza', '2004'),
('200405', 'Morropon', '2004'),
('200406', 'Salitral', '2004'),
('200407', 'San Juan de Bigote', '2004'),
('200408', 'Santa Catalina de Mossa', '2004'),
('200409', 'Santo Domingo', '2004'),
('200410', 'Yamango', '2004'),
('200501', 'Paita', '2005'),
('200502', 'Amotape', '2005'),
('200503', 'Arenal', '2005'),
('200504', 'Colan', '2005'),
('200505', 'La Huaca', '2005'),
('200506', 'Tamarindo', '2005'),
('200507', 'Vichayal', '2005'),
('200601', 'Sullana', '2006'),
('200602', 'Bellavista', '2006'),
('200603', 'Ignacio Escudero', '2006'),
('200604', 'Lancones', '2006'),
('200605', 'Marcavelica', '2006'),
('200606', 'Miguel Checa', '2006'),
('200607', 'Querecotillo', '2006'),
('200608', 'Salitral', '2006'),
('200701', 'Pari�as', '2007'),
('200702', 'El Alto', '2007'),
('200703', 'La Brea', '2007'),
('200704', 'Lobitos', '2007'),
('200705', 'Los Organos', '2007'),
('200706', 'Mancora', '2007'),
('200801', 'Sechura', '2008'),
('200802', 'Bellavista de la Uni�n', '2008'),
('200803', 'Bernal', '2008'),
('200804', 'Cristo Nos Valga', '2008'),
('200805', 'Vice', '2008'),
('200806', 'Rinconada Llicuar', '2008'),
('210101', 'Puno', '2101'),
('210102', 'Acora', '2101'),
('210103', 'Amantani', '2101'),
('210104', 'Atuncolla', '2101'),
('210105', 'Capachica', '2101'),
('210106', 'Chucuito', '2101'),
('210107', 'Coata', '2101'),
('210108', 'Huata', '2101'),
('210109', 'Ma�azo', '2101'),
('210110', 'Paucarcolla', '2101'),
('210111', 'Pichacani', '2101'),
('210112', 'Plateria', '2101'),
('210113', 'San Antonio', '2101'),
('210114', 'Tiquillaca', '2101'),
('210115', 'Vilque', '2101'),
('210201', 'Az�ngaro', '2102'),
('210202', 'Achaya', '2102'),
('210203', 'Arapa', '2102'),
('210204', 'Asillo', '2102'),
('210205', 'Caminaca', '2102'),
('210206', 'Chupa', '2102'),
('210207', 'Jos� Domingo Choquehuanca', '2102'),
('210208', 'Mu�ani', '2102'),
('210209', 'Potoni', '2102'),
('210210', 'Saman', '2102'),
('210211', 'San Anton', '2102'),
('210212', 'San Jos�', '2102'),
('210213', 'San Juan de Salinas', '2102'),
('210214', 'Santiago de Pupuja', '2102'),
('210215', 'Tirapata', '2102'),
('210301', 'Macusani', '2103'),
('210302', 'Ajoyani', '2103'),
('210303', 'Ayapata', '2103'),
('210304', 'Coasa', '2103'),
('210305', 'Corani', '2103'),
('210306', 'Crucero', '2103'),
('210307', 'Ituata', '2103'),
('210308', 'Ollachea', '2103'),
('210309', 'San Gaban', '2103'),
('210310', 'Usicayos', '2103'),
('210401', 'Juli', '2104'),
('210402', 'Desaguadero', '2104'),
('210403', 'Huacullani', '2104'),
('210404', 'Kelluyo', '2104'),
('210405', 'Pisacoma', '2104'),
('210406', 'Pomata', '2104'),
('210407', 'Zepita', '2104'),
('210501', 'Ilave', '2105'),
('210502', 'Capazo', '2105'),
('210503', 'Pilcuyo', '2105'),
('210504', 'Santa Rosa', '2105'),
('210505', 'Conduriri', '2105'),
('210601', 'Huancane', '2106'),
('210602', 'Cojata', '2106'),
('210603', 'Huatasani', '2106'),
('210604', 'Inchupalla', '2106'),
('210605', 'Pusi', '2106'),
('210606', 'Rosaspata', '2106'),
('210607', 'Taraco', '2106'),
('210608', 'Vilque Chico', '2106'),
('210701', 'Lampa', '2107'),
('210702', 'Cabanilla', '2107'),
('210703', 'Calapuja', '2107'),
('210704', 'Nicasio', '2107'),
('210705', 'Ocuviri', '2107'),
('210706', 'Palca', '2107'),
('210707', 'Paratia', '2107'),
('210708', 'Pucara', '2107'),
('210709', 'Santa Lucia', '2107'),
('210710', 'Vilavila', '2107'),
('210801', 'Ayaviri', '2108'),
('210802', 'Antauta', '2108'),
('210803', 'Cupi', '2108'),
('210804', 'Llalli', '2108'),
('210805', 'Macari', '2108'),
('210806', 'Nu�oa', '2108'),
('210807', 'Orurillo', '2108'),
('210808', 'Santa Rosa', '2108'),
('210809', 'Umachiri', '2108'),
('210901', 'Moho', '2109'),
('210902', 'Conima', '2109'),
('210903', 'Huayrapata', '2109'),
('210904', 'Tilali', '2109'),
('211001', 'Putina', '2110'),
('211002', 'Ananea', '2110'),
('211003', 'Pedro Vilca Apaza', '2110'),
('211004', 'Quilcapuncu', '2110'),
('211005', 'Sina', '2110'),
('211101', 'Juliaca', '2111'),
('211102', 'Cabana', '2111'),
('211103', 'Cabanillas', '2111'),
('211104', 'Caracoto', '2111'),
('211105', 'San Miguel', '2111'),
('211201', 'Sandia', '2112'),
('211202', 'Cuyocuyo', '2112'),
('211203', 'Limbani', '2112'),
('211204', 'Patambuco', '2112'),
('211205', 'Phara', '2112'),
('211206', 'Quiaca', '2112'),
('211207', 'San Juan del Oro', '2112'),
('211208', 'Yanahuaya', '2112'),
('211209', 'Alto Inambari', '2112'),
('211210', 'San Pedro de Putina Punco', '2112'),
('211301', 'Yunguyo', '2113'),
('211302', 'Anapia', '2113'),
('211303', 'Copani', '2113'),
('211304', 'Cuturapi', '2113'),
('211305', 'Ollaraya', '2113'),
('211306', 'Tinicachi', '2113'),
('211307', 'Unicachi', '2113'),
('220101', 'Moyobamba', '2201'),
('220102', 'Calzada', '2201'),
('220103', 'Habana', '2201'),
('220104', 'Jepelacio', '2201'),
('220105', 'Soritor', '2201'),
('220106', 'Yantalo', '2201'),
('220201', 'Bellavista', '2202'),
('220202', 'Alto Biavo', '2202'),
('220203', 'Bajo Biavo', '2202'),
('220204', 'Huallaga', '2202'),
('220205', 'San Pablo', '2202'),
('220206', 'San Rafael', '2202'),
('220301', 'San Jos� de Sisa', '2203'),
('220302', 'Agua Blanca', '2203'),
('220303', 'San Mart�n', '2203'),
('220304', 'Santa Rosa', '2203'),
('220305', 'Shatoja', '2203'),
('220401', 'Saposoa', '2204'),
('220402', 'Alto Saposoa', '2204'),
('220403', 'El Eslab�n', '2204'),
('220404', 'Piscoyacu', '2204'),
('220405', 'Sacanche', '2204'),
('220406', 'Tingo de Saposoa', '2204'),
('220501', 'Lamas', '2205'),
('220502', 'Alonso de Alvarado', '2205'),
('220503', 'Barranquita', '2205'),
('220504', 'Caynarachi', '2205'),
('220505', 'Cu�umbuqui', '2205'),
('220506', 'Pinto Recodo', '2205'),
('220507', 'Rumisapa', '2205'),
('220508', 'San Roque de Cumbaza', '2205'),
('220509', 'Shanao', '2205'),
('220510', 'Tabalosos', '2205'),
('220511', 'Zapatero', '2205'),
('220601', 'Juanju�', '2206'),
('220602', 'Campanilla', '2206'),
('220603', 'Huicungo', '2206'),
('220604', 'Pachiza', '2206'),
('220605', 'Pajarillo', '2206'),
('220701', 'Picota', '2207'),
('220702', 'Buenos Aires', '2207'),
('220703', 'Caspisapa', '2207'),
('220704', 'Pilluana', '2207'),
('220705', 'Pucacaca', '2207'),
('220706', 'San Crist�bal', '2207'),
('220707', 'San Hilari�n', '2207'),
('220708', 'Shamboyacu', '2207'),
('220709', 'Tingo de Ponasa', '2207'),
('220710', 'Tres Unidos', '2207'),
('220801', 'Rioja', '2208'),
('220802', 'Awajun', '2208'),
('220803', 'El�as Soplin Vargas', '2208'),
('220804', 'Nueva Cajamarca', '2208'),
('220805', 'Pardo Miguel', '2208'),
('220806', 'Posic', '2208'),
('220807', 'San Fernando', '2208'),
('220808', 'Yorongos', '2208'),
('220809', 'Yuracyacu', '2208'),
('220901', 'Tarapoto', '2209'),
('220902', 'Alberto Leveau', '2209'),
('220903', 'Cacatachi', '2209'),
('220904', 'Chazuta', '2209'),
('220905', 'Chipurana', '2209'),
('220906', 'El Porvenir', '2209'),
('220907', 'Huimbayoc', '2209'),
('220908', 'Juan Guerra', '2209'),
('220909', 'La Banda de Shilcayo', '2209'),
('220910', 'Morales', '2209'),
('220911', 'Papaplaya', '2209'),
('220912', 'San Antonio', '2209'),
('220913', 'Sauce', '2209'),
('220914', 'Shapaja', '2209'),
('221001', 'Tocache', '2210'),
('221002', 'Nuevo Progreso', '2210'),
('221003', 'Polvora', '2210'),
('221004', 'Shunte', '2210'),
('221005', 'Uchiza', '2210'),
('230101', 'Tacna', '2301'),
('230102', 'Alto de la Alianza', '2301'),
('230103', 'Calana', '2301'),
('230104', 'Ciudad Nueva', '2301'),
('230105', 'Inclan', '2301'),
('230106', 'Pachia', '2301'),
('230107', 'Palca', '2301'),
('230108', 'Pocollay', '2301'),
('230109', 'Sama', '2301'),
('230110', 'Coronel Gregorio Albarrac�n Lanchipa', '2301'),
('230111', 'La Yarada los Palos', '2301'),
('230201', 'Candarave', '2302'),
('230202', 'Cairani', '2302'),
('230203', 'Camilaca', '2302'),
('230204', 'Curibaya', '2302'),
('230205', 'Huanuara', '2302'),
('230206', 'Quilahuani', '2302'),
('230301', 'Locumba', '2303'),
('230302', 'Ilabaya', '2303'),
('230303', 'Ite', '2303'),
('230401', 'Tarata', '2304'),
('230402', 'H�roes Albarrac�n', '2304'),
('230403', 'Estique', '2304'),
('230404', 'Estique-Pampa', '2304'),
('230405', 'Sitajara', '2304'),
('230406', 'Susapaya', '2304'),
('230407', 'Tarucachi', '2304'),
('230408', 'Ticaco', '2304'),
('240101', 'Tumbes', '2401'),
('240102', 'Corrales', '2401'),
('240103', 'La Cruz', '2401'),
('240104', 'Pampas de Hospital', '2401'),
('240105', 'San Jacinto', '2401'),
('240106', 'San Juan de la Virgen', '2401'),
('240201', 'Zorritos', '2402'),
('240202', 'Casitas', '2402'),
('240203', 'Canoas de Punta Sal', '2402'),
('240301', 'Zarumilla', '2403'),
('240302', 'Aguas Verdes', '2403'),
('240303', 'Matapalo', '2403'),
('240304', 'Papayal', '2403'),
('250101', 'Calleria', '2501'),
('250102', 'Campoverde', '2501'),
('250103', 'Iparia', '2501'),
('250104', 'Masisea', '2501'),
('250105', 'Yarinacocha', '2501'),
('250106', 'Nueva Requena', '2501'),
('250107', 'Manantay', '2501'),
('250201', 'Raymondi', '2502'),
('250202', 'Sepahua', '2502'),
('250203', 'Tahuania', '2502'),
('250204', 'Yurua', '2502'),
('250301', 'Padre Abad', '2503'),
('250302', 'Irazola', '2503'),
('250303', 'Curimana', '2503'),
('250304', 'Neshuya', '2503'),
('250305', 'Alexander Von Humboldt', '2503'),
('250401', 'Purus', '2504');



CREATE TABLE Estado
(
	Abreviatura_C CHAR(1) NOT NULL,
	Descripcion_VC VARCHAR(20) NOT NULL,
);
GO

INSERT INTO Estado(Abreviatura_C, Descripcion_VC)
VALUES	('A', 'Activo'),
		('I', 'Inactivo');
GO


ALTER TABLE Proveedor
ADD CONSTRAINT CK_Proveedor_Contacto
CHECK (Contacto_v LIKE '+[0-9]%' OR Contacto_v LIKE '[0-9]%');
GO

ALTER TABLE Marca
ALTER COLUMN Nombre_nv VARCHAR(30) NOT NULL;
GO

ALTER TABLE Marca
ALTER COLUMN SitioWeb_nv VARCHAR(100) NOT NULL;
GO

ALTER TABLE Marca
ADD CONSTRAINT DF_Marca_Estado DEFAULT 'A' FOR Estado_c;
GO


CREATE TABLE TipoModelo
(
	Abreviatura_c CHAR(2), 
	Descripcion_vc NVARCHAR(15)
);
GO

INSERT INTO TipoModelo (Abreviatura_c, Descripcion_vc)
VALUES	('E', 'El�ctrico'),
		('D','Dual');
GO


ALTER TABLE Modelo
ADD Estado_c CHAR(1) NOT NULL DEFAULT 'A';
GO

ALTER TABLE Modelo
    ADD CONSTRAINT CHK_Proveedor_Estado CHECK (Estado_c IN ('A', 'I'));
GO

ALTER TABLE Modelo
ALTER COLUMN Nombre_nv VARCHAR(50) NOT NULL;
GO


--TABLA ROL
CREATE TABLE Rol
(
	IdRol_i INTEGER IDENTITY,
	Nombre_v VARCHAR(20) NOT NULL,
	Descripcion_v VARCHAR(255) NULL,
	Estado_c CHAR(1) NOT NULL DEFAULT('A') ----------- 1=Activo, 2=Inactivo
	CONSTRAINT PK_Rol_IdRol PRIMARY KEY (IdRol_i),
	CONSTRAINT CHK_Rol_Estado CHECK (Estado_c IN ('A', 'I'))
);
GO


INSERT INTO ROL(Nombre_v)
VALUES	('Administrador'), 
		('Vendedor'), 
		('Gestor')

--TABLA USUARIO
CREATE TABLE Usuario
(
	IdUsuario_i INTEGER IDENTITY,
	IdRol_i INTEGER NOT NULL,
	Nombre_v VARCHAR(50) NOT NULL,
	TipoDocumento_c CHAR(1) NOT NULL, 
	NroDocumento_v VARCHAR(9) NOT NULL,
	Direccion_v VARCHAR(70) NOT NULL,
	Telefono_c CHAR(9) NOT NULL,
	Correo_v VARCHAR(50) NOT NULL,
	Clave_vb VARBINARY(64) NOT NULL, 
	Estado_c CHAR(1) NOT NULL DEFAULT 'A',
	CONSTRAINT PK_Usuario_IdUsuario PRIMARY KEY (IdUsuario_i),
	CONSTRAINT FK_Usuario_IdRol FOREIGN KEY (IdRol_i) REFERENCES Rol(IdRol_i),
	CONSTRAINT CHK_Usuario_TipoDocumento CHECK (TipoDocumento_c IN ('D', 'E', 'P')),
	CONSTRAINT CHK_Usuario_NroDocumento CHECK (NroDocumento_v LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR NroDocumento_v LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CONSTRAINT CHK_Usuario_Telefono CHECK (Telefono_c LIKE '9[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CONSTRAINT CHK_Usuario_Correo CHECK (Correo_v LIKE '%_@__%._%'),
	CONSTRAINT CHK_Usuario_Estado CHECK (Estado_c IN ('A', 'I'))
);
GO






CREATE TABLE UsuarioTipoDocumento
(
	Nombre_v VARCHAR(20) NOT NULL,
	Codigo_c CHAR(1) NOT NULL,
);
GO

INSERT INTO UsuarioTipoDocumento (Nombre_v, Codigo_c)
VALUES	('DNI','D'),
		('Carn� de Extranjer�a','E'),
		('Pasaporte', 'P')
//////////////////////////////////










CREATE TABLE Color
(
	Abreviatura_c CHAR(2), 
	Descripcion_vc NVARCHAR(15)
);
GO

INSERT INTO Color (Abreviatura_c, Descripcion_vc)
VALUES	('BL', 'Blanco'),
		('AD','Amarillo/Dorado'),
		('AZ','Azul'),
		('RO','Roj'),
		('NE','Negro'),
		('VR','Verde'),
		('RS','Rosado'),
		('OT','Otro');
GO

