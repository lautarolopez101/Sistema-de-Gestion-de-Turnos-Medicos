USE [Sistema de Gestion de Turnos Medicos];
GO

/* =========================================================
   LIMPIEZA
========================================================= */
DELETE FROM dbo.Historiales;
DELETE FROM dbo.Turnos;
DELETE FROM dbo.Profesionales;
DELETE FROM dbo.Especialidades;
DELETE FROM dbo.Pacientes;

DBCC CHECKIDENT ('dbo.Pacientes', RESEED, 0);
DBCC CHECKIDENT ('dbo.Especialidades', RESEED, 0);
DBCC CHECKIDENT ('dbo.Profesionales', RESEED, 0);
DBCC CHECKIDENT ('dbo.Turnos', RESEED, 0);
GO

/* =========================================================
   1) PACIENTES (30)
========================================================= */
INSERT INTO dbo.Pacientes (DNI, Nombre, Apellido, Telefono, Email) VALUES
('30000001',N'Ana',N'García','111-0001','ana.garcia@mail.com'),
('30000002',N'Luis',N'Pérez','111-0002','luis.perez@mail.com'),
('30000003',N'Soledad',N'Martínez','111-0003','sole.martinez@mail.com'),
('30000004',N'Tomás',N'Rojas','111-0004','tomas.rojas@mail.com'),
('30000005',N'Carla',N'Díaz','111-0005','carla.diaz@mail.com'),
('30000006',N'Santiago',N'Marini','111-0006','santiago.marini@mail.com'),
('30000007',N'Paula',N'Sosa','111-0007','paula.sosa@mail.com'),
('30000008',N'Milagros',N'Gómez','111-0008','milagros.gomez@mail.com'),
('30000009',N'Joaquín',N'Fernández','111-0009','joaquin.fernandez@mail.com'),
('30000010',N'Luciano',N'Correa','111-0010','luciano.correa@mail.com'),
('30000011',N'Valentina',N'Molina','111-0011','valentina.molina@mail.com'),
('30000012',N'Camila',N'Ponce','111-0012','camila.ponce@mail.com'),
('30000013',N'Agustín',N'Vega','111-0013','agustin.vega@mail.com'),
('30000014',N'Florencia',N'Rivero','111-0014','flor.rivero@mail.com'),
('30000015',N'Nahuel',N'Quiroga','111-0015','nahuel.quiroga@mail.com'),
('30000016',N'Martina',N'López','111-0016','martina.lopez@mail.com'),
('30000017',N'Federico',N'Méndez','111-0017','fede.mendez@mail.com'),
('30000018',N'Lucía',N'Salazar','111-0018','lucia.salazar@mail.com'),
('30000019',N'Matías',N'Paredes','111-0019','matias.paredes@mail.com'),
('30000020',N'Julieta',N'Bravo','111-0020','julieta.bravo@mail.com'),
('30000021',N'Emilia',N'Torres','111-0021','emilia.torres@mail.com'),
('30000022',N'Andrés',N'Flores','111-0022','andres.flores@mail.com'),
('30000023',N'Rocío',N'Cruz','111-0023','rocio.cruz@mail.com'),
('30000024',N'Leandro',N'Romero','111-0024','leandro.romero@mail.com'),
('30000025',N'Pilar',N'Campos','111-0025','pilar.campos@mail.com'),
('30000026',N'Gabriel',N'Silva','111-0026','gabriel.silva@mail.com'),
('30000027',N'Abril',N'Ibarra','111-0027','abril.ibarra@mail.com'),
('30000028',N'Maxi',N'Acevedo','111-0028','maxi.acevedo@mail.com'),
('30000029',N'Delfina',N'Aguilar','111-0029','delfi.aguilar@mail.com'),
('30000030',N'Ignacio',N'Rey','111-0030','ignacio.rey@mail.com');
GO

/* =========================================================
   2) ESPECIALIDADES (10)
========================================================= */
INSERT INTO dbo.Especialidades (Especialidad, Descripcion) VALUES
(N'Clínica Médica',N'Medicina general'),
(N'Cardiología',N'Enfermedades cardíacas'),
(N'Pediatría',N'Salud infantil'),
(N'Dermatología',N'Piel y anexos'),
(N'Traumatología',N'Huesos y músculos'),
(N'Ginecología',N'Salud femenina'),
(N'Neurología',N'Sistema nervioso'),
(N'Endocrinología',N'Hormonas'),
(N'Oncología',N'Cáncer y tumores'),
(N'Psiquiatría',N'Salud mental');
GO

/* =========================================================
   3) PROFESIONALES (20)
========================================================= */
INSERT INTO dbo.Profesionales (Matricula, Nombre, Apellido, ID_Especialidad, Telefono, Email, Activo) VALUES
('MAT-2001',N'Carla',N'Sosa',1,'222-0001','carla.sosa@hospital.com',1),
('MAT-2002',N'Martín',N'Lopez',3,'222-0002','martin.lopez@hospital.com',1),
('MAT-2003',N'Lucía',N'Paz',4,'222-0003','lucia.paz@hospital.com',1),
('MAT-2004',N'Juan',N'Ramos',2,'222-0004','juan.ramos@hospital.com',1),
('MAT-2005',N'Silvia',N'Álvarez',5,'222-0005','silvia.alvarez@hospital.com',1),
('MAT-2006',N'Andrea',N'Méndez',6,'222-0006','andrea.mendez@hospital.com',1),
('MAT-2007',N'Gonzalo',N'Peralta',7,'222-0007','gonza.peralta@hospital.com',1),
('MAT-2008',N'Laura',N'Funes',8,'222-0008','laura.funes@hospital.com',1),
('MAT-2009',N'Pablo',N'Moreno',1,'222-0009','pablo.moreno@hospital.com',1),
('MAT-2010',N'Federico',N'Suárez',5,'222-0010','fede.suarez@hospital.com',1),
('MAT-2011',N'Betina',N'Campos',4,'222-0011','betina.campos@hospital.com',1),
('MAT-2012',N'Ignacio',N'Prado',2,'222-0012','ignacio.prado@hospital.com',1),
('MAT-2013',N'Mariana',N'Castro',9,'222-0013','mariana.castro@hospital.com',1),
('MAT-2014',N'Lucas',N'Herrera',10,'222-0014','lucas.herrera@hospital.com',1),
('MAT-2015',N'Valeria',N'Gómez',6,'222-0015','valeria.gomez@hospital.com',1),
('MAT-2016',N'Sergio',N'Cáceres',7,'222-0016','sergio.caceres@hospital.com',1),
('MAT-2017',N'Claudia',N'Ortiz',8,'222-0017','claudia.ortiz@hospital.com',1),
('MAT-2018',N'Andrés',N'Salinas',9,'222-0018','andres.salinas@hospital.com',1),
('MAT-2019',N'Natalia',N'Gutiérrez',10,'222-0019','natalia.gutierrez@hospital.com',1),
('MAT-2020',N'Ramiro',N'Bustos',3,'222-0020','ramiro.bustos@hospital.com',1);
GO

/* =========================================================
   4) TURNOS (40) CORREGIDO
========================================================= */
DECLARE @hoy DATETIME2(0) = CAST(SYSDATETIME() AS DATETIME2(0));

INSERT INTO dbo.Turnos (ID_Paciente,ID_Profesional,Estado,FechaHora,Motivo,Observarciones) VALUES
(1,1,N'Pendiente',DATEADD(HOUR,9,@hoy),N'Chequeo clínico',NULL),
(2,4,N'Confirmado',DATEADD(HOUR,10,@hoy),N'Control cardiológico',NULL),
(3,2,N'Pendiente',DATEADD(DAY,1,DATEADD(HOUR,9,@hoy)),N'Consulta pediátrica',NULL),
(4,3,N'Pendiente',DATEADD(DAY,1,DATEADD(HOUR,11,@hoy)),N'Alergia en piel',NULL),
(5,5,N'Pendiente',DATEADD(DAY,1,DATEADD(HOUR,12,@hoy)),N'Dolor de rodilla',NULL),
(6,6,N'Pendiente',DATEADD(DAY,2,DATEADD(HOUR,10,@hoy)),N'Chequeo ginecológico',NULL),
(7,7,N'Pendiente',DATEADD(DAY,2,DATEADD(HOUR,16,@hoy)),N'Migrañas',NULL),
(8,8,N'Pendiente',DATEADD(DAY,2,DATEADD(HOUR,9,@hoy)),N'Chequeo endocrino',NULL),
(9,9,N'Pendiente',DATEADD(DAY,2,DATEADD(HOUR,10,@hoy)),N'Fiebre',NULL),
(10,10,N'Pendiente',DATEADD(DAY,3,DATEADD(HOUR,14,@hoy)),N'Lesión deportiva',NULL),
(11,11,N'Pendiente',DATEADD(DAY,3,DATEADD(HOUR,11,@hoy)),N'Revisión lunar',NULL),
(12,12,N'Pendiente',DATEADD(DAY,3,DATEADD(HOUR,9,@hoy)),N'Control cardiológico',NULL),
(13,13,N'Pendiente',DATEADD(DAY,3,DATEADD(HOUR,15,@hoy)),N'Sospecha tumoral',NULL),
(14,14,N'Pendiente',DATEADD(DAY,3,DATEADD(HOUR,16,@hoy)),N'Ansiedad',NULL),
(15,15,N'Pendiente',DATEADD(DAY,4,DATEADD(HOUR,10,@hoy)),N'Control ginecológico',NULL),
(16,16,N'Pendiente',DATEADD(DAY,4,DATEADD(HOUR,12,@hoy)),N'Cefaleas',NULL),
(17,17,N'Pendiente',DATEADD(DAY,4,DATEADD(HOUR,14,@hoy)),N'Chequeo hormonal',NULL),
(18,18,N'Pendiente',DATEADD(DAY,4,DATEADD(HOUR,15,@hoy)),N'Control oncología',NULL),
(19,19,N'Pendiente',DATEADD(DAY,4,DATEADD(HOUR,9,@hoy)),N'Consulta psiquiátrica',NULL),
(20,20,N'Pendiente',DATEADD(DAY,4,DATEADD(HOUR,11,@hoy)),N'Control pediátrico',NULL),
(21,1,N'Pendiente',DATEADD(DAY,5,DATEADD(HOUR,9,@hoy)),N'Consulta clínica',NULL),
(22,2,N'Pendiente',DATEADD(DAY,5,DATEADD(HOUR,11,@hoy)),N'Control pediátrico',NULL),
(23,3,N'Pendiente',DATEADD(DAY,5,DATEADD(HOUR,13,@hoy)),N'Lesión cutánea',NULL),
(24,4,N'Pendiente',DATEADD(DAY,5,DATEADD(HOUR,10,@hoy)),N'Chequeo cardiológico',NULL),
(25,5,N'Pendiente',DATEADD(DAY,5,DATEADD(HOUR,12,@hoy)),N'Trauma deportivo',NULL),
(26,6,N'Pendiente',DATEADD(DAY,6,DATEADD(HOUR,9,@hoy)),N'Chequeo ginecológico',NULL),
(27,7,N'Pendiente',DATEADD(DAY,6,DATEADD(HOUR,16,@hoy)),N'Migrañas intensas',NULL),
(28,8,N'Pendiente',DATEADD(DAY,6,DATEADD(HOUR,11,@hoy)),N'Control endocrino',NULL),
(29,9,N'Pendiente',DATEADD(DAY,6,DATEADD(HOUR,10,@hoy)),N'Control clínico',NULL),
(30,10,N'Pendiente',DATEADD(DAY,6,DATEADD(HOUR,15,@hoy)),N'Fractura brazo',NULL),
(1,11,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,10,@hoy)),N'Dermatitis',NULL),
(2,12,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,9,@hoy)),N'Chequeo cardiológico',NULL),
(3,13,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,14,@hoy)),N'Oncología control',NULL),
(4,14,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,15,@hoy)),N'Consulta psiquiátrica',NULL),
(5,15,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,11,@hoy)),N'Ginecología anual',NULL),
(6,16,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,12,@hoy)),N'Cefalea recurrente',NULL),
(7,17,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,13,@hoy)),N'Chequeo hormonal',NULL),
(8,18,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,16,@hoy)),N'Control oncológico',NULL),
(9,19,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,9,@hoy)),N'Consulta psiquiátrica',NULL),
(10,20,N'Pendiente',DATEADD(DAY,7,DATEADD(HOUR,11,@hoy)),N'Chequeo pediátrico',NULL);
GO


/* =========================================================
   5) HISTORIALES (para algunos turnos)
========================================================= */
INSERT INTO dbo.Historiales (ID_Turno, Diagnostico, Indicaciones, Notas) VALUES
(2,N'Hipertensión leve',N'Reducir sal, medicación diaria',N'Seguimiento en 1 mes'),
(9,N'Faringitis viral',N'Hidratación y reposo',N'Revisar si persiste'),
(10,N'Esguince de tobillo',N'Inmovilización, reposo 2 semanas',N'Control en 15 días'),
(18,N'Carcinoma in situ',N'Derivar a oncología',N'Programar biopsia'),
(19,N'Trastorno de ansiedad',N'Terapia y medicación',N'Control en 1 mes');
GO

/* =========================================================
   6) VERIFICACIÓN
========================================================= */
SELECT 'Pacientes' AS Tabla, COUNT(*) FROM dbo.Pacientes
UNION ALL SELECT 'Especialidades', COUNT(*) FROM dbo.Especialidades
UNION ALL SELECT 'Profesionales', COUNT(*) FROM dbo.Profesionales
UNION ALL SELECT 'Turnos', COUNT(*) FROM dbo.Turnos
UNION ALL SELECT 'Historiales', COUNT(*) FROM dbo.Historiales;
GO