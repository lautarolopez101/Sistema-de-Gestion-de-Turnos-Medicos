USE [Sistema de Gestion de Turnos Medicos];
GO

DELETE FROM dbo.Pacientes;
/* Lo que hago aca es de la tabla pacientes borro el historial de ID_Pacientes para que pueda arrancar desde 
 0 otra vez
*/
DBCC CHECKIDENT ('dbo.Pacientes', RESEED, 0);
GO

/* =========================================================
   1) PACIENTES (30)
========================================================= */
INSERT INTO Pacientes(DNI, Nombre, Apellido, FechaNacimiento, Telefono, Email, Estado) VALUES
(30123456, 'Juan', 'Pérez', '1962-03-14', '+54 9 11 54321234', 'juan.perez@mail.com', 'Activo'),
(31234567, 'María', 'Gómez', '1965-11-23', '+54 9 11 67893456', 'maria.gomez@mail.com', 'Activo'),
(32345678, 'Carlos', 'López', '1968-07-05', '+54 9 11 78904567', 'carlos.lopez@mail.com', 'Activo'),
(33456789, 'Laura', 'Martínez', '1970-01-18', '+54 9 11 43217890', 'laura.martinez@mail.com', 'Activo'),
(34567890, 'Lucía', 'Fernández', '1972-09-02', '+54 9 11 56781234', 'lucia.fernandez@mail.com', 'Activo'),
(35678901, 'Miguel', 'Rodríguez', '1974-12-25', '+54 9 11 65437890', 'miguel.rodriguez@mail.com', 'Activo'),
(36789012, 'Sofía', 'Díaz', '1976-04-09', '+54 9 11 78906543', 'sofia.diaz@mail.com', 'Activo'),
(37890123, 'Javier', 'Sánchez', '1978-08-15', '+54 9 11 87654321', 'javier.sanchez@mail.com', 'Activo'),
(38901234, 'Natalia', 'Romero', '1980-02-12', '+54 9 11 91234567', 'natalia.romero@mail.com', 'Activo'),
(39012345, 'Andrés', 'Ruiz', '1982-06-30', '+54 9 11 65439876', 'andres.ruiz@mail.com', 'Activo'),
(40123456, 'Florencia', 'Torres', '1984-09-11', '+54 9 11 72345678', 'florencia.torres@mail.com', 'Activo'),
(41234567, 'Diego', 'Benítez', '1986-03-28', '+54 9 11 73456789', 'diego.benitez@mail.com', 'Activo'),
(42345678, 'Camila', 'Molina', '1988-07-22', '+54 9 11 74567890', 'camila.molina@mail.com', 'Activo'),
(43456789, 'Matías', 'Silva', '1990-05-13', '+54 9 11 75678901', 'matias.silva@mail.com', 'Activo'),
(44567890, 'Julieta', 'Castro', '1992-12-04', '+54 9 11 76789012', 'julieta.castro@mail.com', 'Activo'),
(45678901, 'Lucas', 'Arias', '1994-01-19', '+54 9 11 77890123', 'lucas.arias@mail.com', 'Activo'),
(46789012, 'Paula', 'Ramos', '1995-08-07', '+54 9 11 78901234', 'paula.ramos@mail.com', 'Activo'),
(47890123, 'Federico', 'Herrera', '1997-04-26', '+54 9 11 89012345', 'federico.herrera@mail.com', 'Activo'),
(48901234, 'Valentina', 'Domínguez', '1998-11-10', '+54 9 11 90123456', 'valentina.dominguez@mail.com', 'Activo'),
(49012345, 'Martín', 'Gutiérrez', '2000-06-01', '+54 9 11 91234567', 'martin.gutierrez@mail.com', 'Activo'),
(50123456, 'Agustina', 'Acosta', '2001-03-08', '+54 9 11 92345678', 'agustina.acosta@mail.com', 'Activo'),
(51234567, 'Santiago', 'Peralta', '2002-07-25', '+54 9 11 93456789', 'santiago.peralta@mail.com', 'Activo'),
(52345678, 'Micaela', 'Vega', '2003-02-19', '+54 9 11 94567890', 'micaela.vega@mail.com', 'Activo'),
(53456789, 'Tomás', 'Navarro', '2004-10-14', '+54 9 11 95678901', 'tomas.navarro@mail.com', 'Activo'),
(54567890, 'Antonella', 'Ponce', '2005-05-06', '+54 9 11 96789012', 'antonella.ponce@mail.com', 'Activo'),
(55678901, 'Nicolás', 'Suárez', '2006-09-29', '+54 9 11 97890123', 'nicolas.suarez@mail.com', 'Activo'),
(56789012, 'Carolina', 'Flores', '1960-02-17', '+54 9 11 98901234', 'carolina.flores@mail.com', 'Activo'),
(57890123, 'Franco', 'Medina', '1963-07-08', '+54 9 11 99012345', 'franco.medina@mail.com', 'Activo'),
(58901234, 'Elena', 'Blanco', '1975-11-19', '+54 9 11 90124567', 'elena.blanco@mail.com', 'Activo'),
(59012345, 'Ricardo', 'Cabrera', '1981-10-03', '+54 9 11 91235678', 'ricardo.cabrera@mail.com', 'Activo')
GO

/* =========================================================
   6) VERIFICACIÓN
========================================================= */
SELECT 'Pacientes' AS Tabla, COUNT(*) FROM dbo.Pacientes
GO