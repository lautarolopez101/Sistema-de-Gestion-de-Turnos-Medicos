
DBCC CHECKIDENT	('Profesionales',RESEED,0)

/* ============================================================
   INSERCIÓN DE REGISTROS PROFESIONALES
   (ID_Profesional se genera automáticamente)
   ============================================================ */
INSERT INTO Profesionales 
(Matricula, Nombre, Apellido, Telefono, Email, Activo)
VALUES
('MAT-2001', 'Carla', 'Sosa', '222-0001', 'carla.sosa@hospital.com', 1),
('MAT-2002', 'Martín', 'Lopez', '222-0002', 'martin.lopez@hospital.com', 1),
('MAT-2003', 'Lucía', 'Paz', '222-0003', 'lucia.paz@hospital.com', 1),
('MAT-2004', 'Juan', 'Ramos', '222-0004', 'juan.ramos@hospital.com', 1),
('MAT-2005', 'Silvia', 'Álvarez', '222-0005', 'silvia.alvarez@hospital.com', 1),
('MAT-2006', 'Andrea', 'Méndez', '222-0006', 'andrea.mendez@hospital.com', 1),
('MAT-2007', 'Gonzalo', 'Peralta', '222-0007', 'gonzalo.peralta@hospital.com', 1),
('MAT-2008', 'Laura', 'Funes', '222-0008', 'laura.funes@hospital.com', 1),
('MAT-2009', 'Pablo', 'Moreno', '222-0009', 'pablo.moreno@hospital.com', 1),
('MAT-2010', 'Federico', 'Suárez', '222-0010', 'federico.suarez@hospital.com', 1),
('MAT-2011', 'Betina', 'Campos', '222-0011', 'betina.campos@hospital.com', 1),
('MAT-2012', 'Ignacio', 'Prado', '222-0012', 'ignacio.prado@hospital.com', 1),
('MAT-2013', 'Mariana', 'Castro', '222-0013', 'mariana.castro@hospital.com', 1),
('MAT-2014', 'Lucas', 'Herrera', '222-0014', 'lucas.herrera@hospital.com', 1),
('MAT-2015', 'Valeria', 'Gómez', '222-0015', 'valeria.gomez@hospital.com', 1),
('MAT-2016', 'Sergio', 'Cáceres', '222-0016', 'sergio.caceres@hospital.com', 1),
('MAT-2017', 'Claudia', 'Ortiz', '222-0017', 'claudia.ortiz@hospital.com', 1),
('MAT-2018', 'Andrés', 'Salinas', '222-0018', 'andres.salinas@hospital.com', 1),
('MAT-2019', 'Natalia', 'Gutiérrez', '222-0019', 'natalia.gutierrez@hospital.com', 1),
('MAT-2020', 'Ramiro', 'Bustos', '222-0020', 'ramiro.bustos@hospital.com', 1);
