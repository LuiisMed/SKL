--Tabla de ASPECTOS
INSERT INTO SKL.Aspects (aspect_name) VALUES ('COMUNICACIÓN');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('CARGA LABORAL');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('RESULTADOS Y COMUNICACION');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('SEGUIMIENTO DE RESULTADOS');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('MOTIVACIÓN Y RECONOCIMIENTO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('CULTURA DE RECONOCIMIENTO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('COMUNICACIÓN ABIERTA Y MEJORA CONTINUA');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('BIENESTAR EN EL TRABAJO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('SEGUIMIENTO A LA COMUNICACIÓN ');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('RESPETO E IGUALDAD');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('COMUNICACIÓN CONTINUA Y ALINEAMIENTO DEL EQUIPO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('RESPONSABILIDAD Y CUMPLIMIENTO DE LOS ESTÁNDARES ');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('ESCUCHA ACTIVA Y COMPROMISO DEL EQUIPO ');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('COLABORACIÓN Y TRABAJO EN EQUIPO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('EMPATÍA ');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('CRECIMIENTO PROFESIONAL');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('CAPACITACIÓN Y ADIESTRAMIENTO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('IGUALDAD Y FAVORITISMO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('CONFIANZA');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('TRATO AL PERSONAL');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('OPTIMIZAR LA DISTRIBUCIÓN DE TAREAS');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('INSTRUCCIONES CLARAS Y DETALLADAS');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('MATRIZ DE HABILIDADES ');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('PARTICIPACIÓN ACTIVA');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('PROMOCIONES');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('DISCIPLINA');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('MONITOREO ');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('INSTRUCCIONES CLARAS');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('RESPONSABILIDAD ');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('CAPACITACIÓN');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('COMPROMISO');
INSERT INTO SKL.Aspects (aspect_name) VALUES ('CONVIVENCIA');


--TABLA DE DEPARTAMENTOS
INSERT INTO SKL.Departments (department_name) VALUES ('Recursos Humanos');
INSERT INTO SKL.Departments (department_name) VALUES ('SMT');
INSERT INTO SKL.Departments (department_name) VALUES ('INGENIERIA');
INSERT INTO SKL.Departments (department_name) VALUES ('OQA');
INSERT INTO SKL.Departments (department_name) VALUES ('CAR AUDIO PRODUCTION');
INSERT INTO SKL.Departments (department_name) VALUES ('MACHINE CENTER');
INSERT INTO SKL.Departments (department_name) VALUES ('SMT MATERIALES');
INSERT INTO SKL.Departments (department_name) VALUES ('QS 9000');
INSERT INTO SKL.Departments (department_name) VALUES ('WAREHOUSE');
INSERT INTO SKL.Departments (department_name) VALUES ('COMPRAS MRO');
INSERT INTO SKL.Departments (department_name) VALUES ('CAR AUDIO QC');
INSERT INTO SKL.Departments (department_name) VALUES ('PACKING & FG');
INSERT INTO SKL.Departments (department_name) VALUES ('FACILITIES');

--INSERT DE FASE
INSERT INTO SKL.Fase (fase_name, fase_startdate, fase_enddate, Is_Active) VALUES ('FASE 10', '2024-12-01 00:00:00', '2025-10-31 00:00:00', 1);

--INSERT POSITIONS
INSERT INTO SKL.Positions (position_name) VALUES ('Gerente');
INSERT INTO SKL.Positions (position_name) VALUES ('SUPERVISOR');
INSERT INTO SKL.Positions (position_name) VALUES ('PRACTICANTE');
INSERT INTO SKL.Positions (position_name) VALUES ('DATA CLERK');
INSERT INTO SKL.Positions (position_name) VALUES ('COORDINADOR');
INSERT INTO SKL.Positions (position_name) VALUES ('LIDER DE GRUPO');
INSERT INTO SKL.Positions (position_name) VALUES ('AUXILIAR DE CAPTURA');

--INSERT TURNOS
INSERT INTO skl.[Shift] (shift_name, start, [end]) VALUES ('1', '6:15', '15:45');
INSERT INTO skl.[Shift] (shift_name, start, [end]) VALUES ('2', '3:45', '12:45');
INSERT INTO skl.[Shift] (shift_name, start, [end]) VALUES ('3', '12:45AM', '6:00AM');
INSERT INTO skl.[Shift] (shift_name, start, [end]) VALUES ('1A', '6:00AM', '6:00PM');
INSERT INTO skl.[Shift] (shift_name, start, [end]) VALUES ('1B', '6:00PM', '6:00AM');
INSERT INTO skl.[Shift] (shift_name, start, [end]) VALUES ('2A', '6:00AM', '6:00PM');
INSERT INTO skl.[Shift] (shift_name, start, [end]) VALUES ('2B', '6:00PM', '6:00AM');


--TIPOS DE USUARIO
INSERT INTO SKL.UserType (usr_type_name) VALUES ('Administrador');
INSERT INTO SKL.UserType (usr_type_name) VALUES ('Usuario');

--INSERT USUARIOS
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('Luis Perez', 'Lmed', 'Pasmx123', 1, 3, 1, 3, 90469, '2024-12-09', '', 'lp_bg25@hotmail.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('Hector Garcia', 'GarciaH', 'Pasmx123', 1, 3, 1, 1, 2428, '2024-10-08', '', '');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('Osiris Valenzuela', 'OValen', 'Pasmx123', 3, 1, 1, 1, 1993, '2024-12-09', '', '');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('Alejandra Manriquez', 'AleM', 'Pasmx123', 1, 4, 1, 1, 90502, '2024-12-18', '', 'skiplevel.pasmx@ext.panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('YORIMAR AYALA VEGA', 'Ayalay', 'Pana123', 3, 3, 1, 5, 2528, '2024-12-09', '', 'yorimar.ayala@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('IRMA TORRES RAMIREZ', 'Torresi', 'Pana123', 3, 6, 1, 5, 2757, '2024-12-09', '', 'irma.torres@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('CAMILO MALDONADO PEREZ', 'Maldonadoc', 'Pana123', 3, 3, 1, 5, 1239, '2024-12-09', '', 'Camilo.Maldonado@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ELOISA AVILES HERVERT', 'Avilese', 'Pana123', 3, 3, 1, 5, 2592, '2024-12-09', '', 'eloisa.aviles@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('IMELDA HERNANDEZ VILLEDA', 'Hernandezi', 'Pana123', 3, 3, 1, 5, 2529, '2024-12-09', '', 'Imelda.Hernandez@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('SAN JUANITA SIFUENTES GARCIA', 'Sifuentess', 'Pana123', 3, 3, 1, 5, 2736, '2024-12-09', '', 'sanjuanita.sifuentes@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ADRIANA ZAVALA GOMEZ', 'Zavalaa', 'Pana123', 3, 3, 1, 5, 2508, '2024-12-09', '', 'beatriz.zavala@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('MIGUEL GARRIDO PORRAS', 'Garridom', 'Pana123', 3, 7, 1, 5, 20907, '2024-12-12', '', 'pandita_garrido@hotmail.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('YOMELI GARCIA PONCE', 'Garciay', 'Pana123', 3, 8, 1, 5, 18983, '2024-12-12', '', 'istria.garcia@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('LUISA IBARRA ARAIZA', 'Ibarral', 'Pana123', 3, 3, 1, 5, 1779, '2024-12-12', '', 'Luisa.Ibarra@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ADRIAN SEPULVEDA ZAMORA', 'Sepulvedaa', 'Pana123', 3, 3, 1, 5, 2631, '2024-12-12', '', 'Adrian.Avila@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ELENA SANCHEZ', 'Sanchezel', 'Pana123', 3, 3, 2, 5, 2590, '2024-12-12', '', 'Elena.Sanchezh@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('RAUL  MOJICA LAGUNES', 'Mojicar', 'Pana123', 3, 3, 2, 5, 2586, '2024-12-12', '', 'yaet.mojica@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('MARIANA MARIN JARQUIN', 'Marinm', 'Pana123', 3, 3, 2, 5, 2347, '2024-12-12', '', 'mariana.marin@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('GILBERTO SOSA HERNANDEZ', 'Sosag', 'Pana123', 3, 3, 2, 5, 2581, '2024-12-12', '', 'gilberto.sosa@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('FRANCISCO GALLEGOS ESPINOZA', 'Gallegosf', 'Pana123', 3, 3, 2, 5, 1234, '2024-12-12', '', 'Francisco.Gallegos@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('JOVITA PAULIN REYES', 'Paulinj', 'Pana123', 3, 3, 2, 5, 2545, '2024-12-12', '', 'jovita.paulin@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('MARIO MAURO RIOS', 'Riosm', 'Pana123', 3, 3, 3, 5, 2618, '2024-12-12', '', 'mario.rios@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('GLORIA ISIDRO', 'Isidrog', 'Pana123', 3, 3, 3, 5, 2618, '2024-12-12', '', 'gloria.isidro@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('MARCELO MOLAR', 'Molarm', 'Pana123', 3, 3, 1, 11, 1409, '2024-12-12', '', 'Marcelo.Molar@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('KARINA GUTIERREZ', 'Gutierrezk', 'Pana123', 3, 6, 1, 11, 2795, '2024-12-12', '', 'karina.gutierrez@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('DOROTEO NAVA', 'Navad', 'Pana123', 3, 3, 7, 13, 1013, '2024-12-12', '', 'Doroteo.Nava@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('NOE AVENDAÑO', 'Noea', 'Pana123', 3, 6, 5, 13, 1146, '2024-12-12', '', 'Noe.Avendano@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ADRIANA DELGADILLO', 'Delgadilloa', 'Pana123', 3, 3, 1, 13, 2418, '2024-12-12', '', 'Adriana.Delgadillo@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ELEUTERIO RAMOS', 'Ramose', 'Pana123', 3, 3, 5, 6, 1121, '2024-12-12', '', 'Eleuterio.Ramos@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ADRIAN AVILA', 'Avilaa', 'Pana123', 3, 3, 5, 6, 1916, '2024-12-12', '', 'Adrian.Avila@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('EUFEMIA CRUZ', 'Cruze', 'Pana123', 3, 3, 4, 6, 2721, '2024-12-12', '', 'eufemia.cruz@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('JOSE LUIS RUIZ', 'Ruisj', 'Pana123', 3, 3, 6, 6, 2437, '2024-12-12', '', 'luis.ruiz@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('FERNANDO ADAME', 'Adamef', 'natalia3108', 3, 6, 5, 6, 2747, '2024-12-12', '', 'luis.adame@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('LUIS URIBE', 'Uribel', 'Pana123', 3, 3, 6, 6, 2603, '2024-12-12', '', 'Luis.Uribel@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ARACELY LOPEZ', 'Lopeza', 'Pana123', 3, 6, 7, 6, 2741, '2024-12-12', '', 'aracely.lopezp@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ELIAZER DE LUNA', 'Delunae', 'Pana123', 3, 3, 4, 6, 2671, '2024-12-12', '', 'eliezer.deluna@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('JOSE GUERRERO', 'Guerreroj', 'Pana123', 3, 3, 5, 6, 2100, '2024-12-12', '', 'jose.guerrero@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ESMERALDA DIAZ', 'Diaze', 'Pana123', 3, 3, 4, 6, 2270, '2024-12-12', '', 'Esmeralda.Diaz@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('MARTIN SALINAS', 'Salinasm', 'Pana123', 3, 3, 4, 6, 2361, '2024-12-12', '', 'martin.salinas@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('JOSE CRUZ SANCHES', 'Sanchezj', 'Pana123', 3, 3, 7, 6, 1756, '2024-12-12', '', 'Jose.Sanchez@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('JESUS HERNANDEZ', 'Hernandezh', 'Pana123', 3, 3, 4, 6, 1719, '2024-12-12', '', 'Jesus.Hernandez@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('FRANCISCO MARTINEZ', 'Martinezf', 'Pana123', 3, 3, 6, 6, 2653, '2024-12-12', '', 'francisco.martinezO@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('JANETH', 'Delangelja', 'Pana123', 3, 6, 1, 12, 2756, '2024-12-12', '', 'janeth.delangel@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ISIDORO DEL ANGEL', 'Delangelis', 'Pana123', 3, 6, 2, 12, 2756, '2024-12-12', '', 'Isidoro.Lorenzo@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('YOLANDA CASTILLO', 'Castilloy', 'Pana123', 3, 6, 5, 7, 2465, '2024-12-12', '', 'Yolanda.Castillo@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('LETICIA PONCE', 'Poncel', 'Pana123', 3, 6, 6, 7, 2785, '2024-12-12', '3', 'leticia.ponce@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('CECILIA BAUTISTA', 'Bautistac', 'Pana123', 3, 8, 4, 7, 19845, '2024-12-12', '', 'cecilia.bautista@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ALFONSO RAMOS SANTES', 'Ramosal', 'Pana123', 3, 6, 1, 7, 2761, '2024-12-12', '', 'alfonso.ramos1@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('VICENTE VEGA', 'Vegav', 'Pana123', 3, 3, 2, 7, 2645, '2024-12-12', '', 'jesus.vega@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('BRIAN MANUEL HERRRARA', 'Herrerab', 'Pana123', 3, 3, 2, 9, 2045, '2024-12-12', '', 'brian.herrera@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ELISEO HERNANDEZ', 'Hernandezel', 'Pana123', 3, 3, 2, 9, 1495, '2024-12-12', '', 'Eliseo.Hernandez@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('DEMETRIO SOSA', 'Sosad', 'Pana123', 3, 3, 4, 9, 2470, '2024-12-12', '', 'demetrio.sosa@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('IRASEMA MONTOYA', 'Montoyam', 'Pana123', 3, 3, 3, 9, 2454, '2024-12-12', '', 'Irasema.Montoya@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ALBERTO CARDOSO', 'Cardosoa', 'Pana123', 3, 3, 7, 9, 2471, '2024-12-12', '', 'alberto.cardoso@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('CARLOS NAVARRO', 'Navarroc', 'Pana123', 3, 3, 5, 9, 2451, '2024-12-12', '', 'Carlos.Navarro@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('SARAY TORRES', 'Torress', 'Pana123', 3, 3, 1, 9, 1059, '2024-12-12', '', 'Sarai.Torres@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('RUBEN LUCAS', 'Lucasr', 'Pana123', 3, 3, 1, 9, 1940, '2024-12-12', '', 'Ruben.Lucas@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ALBERTO ORTIZ', 'Ortiza', 'Pana123', 3, 3, 4, 9, 2404, '2024-12-12', '', 'alberto.ortiz@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ROMAN DE LEON', 'Deleonr', 'Pana123', 3, 3, 1, 9, 2479, '2024-12-12', '', 'roman.deleon@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('RAUL HEREDIA', 'Herediar', 'Pana123', 3, 3, 1, 3, 1378, '2024-12-09', '', 'Raul.Heredia@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('CARLOS VALENZUELA', 'Valenzuelac', 'Pana123', 3, 3, 1, 3, 2663, '2024-12-09', '', 'carlos.valenzuelar@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('WENCESLAO DEL ANGEL', 'Delangelw', 'Pana123', 3, 3, 2, 3, 1694, '2024-12-09', '', 'Wenceslao.DelAngel@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('RICARDO GONZALEZ', 'Gonzalezg', 'Pana123', 3, 3, 1, 8, 2704, '2024-12-12', '', 'Ricardo.Gonzalez@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('ELIANA GARZA', 'Garzae', 'Pana123', 3, 6, 1, 10, 2808, '2024-12-18', '', 'eliana.garza@panasonicautomotive.com');
INSERT INTO [SKL].Usuarios (name, usr_name, usr_pass, id_usr_type, id_usr_position, id_shift, id_usr_department, emp_no, date, usr_img, Email) VALUES ('NANCY PEÑA', 'Peñan', 'Pana123', 1, 5, 1, 1, 27841, '2024-12-17', '', '');



