USE [Sistema de Gestion de Turnos Medicos];
GO

DELETE FROM dbo.Pacientes;

DBCC CHECKIDENT ('dbo.Pacientes', RESEED, 0);
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
   6) VERIFICACIÓN
========================================================= */
SELECT 'Pacientes' AS Tabla, COUNT(*) FROM dbo.Pacientes
GO