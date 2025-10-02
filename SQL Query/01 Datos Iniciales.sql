USE [Sistema de Gestion de Turnos Medicos];
GO

/* =============================
   Insertar datos de prueba
   ============================= */

/* 👩‍🦰 PACIENTES */
INSERT INTO dbo.Pacientes (DNI, Nombre, Apellido, FechaNacimiento, Telefono, Email)
VALUES 
('30111222', N'Ana',  N'García',  '1990-05-10', '11-5555-0001', 'ana.garcia@mail.com'),
('29000999', N'Luis', N'Pérez',   '1985-08-02', '11-5555-0002', 'luis.perez@mail.com'),
('31555999', N'Soledad', N'Martínez', '1995-01-15', '11-5555-0003', 'sole.martinez@mail.com');

/* 🏷️ ESPECIALIDADES */
INSERT INTO dbo.Especialidades (Especialidad, Descripcion)
VALUES
(N'Clínica Médica', N'Medicina general para adultos'),
(N'Cardiología',    N'Diagnóstico y tratamiento de enfermedades del corazón'),
(N'Pediatría',      N'Atención médica para niños');

/* 👨‍⚕️ PROFESIONALES */
-- Carla Sosa (Clínica Médica)
INSERT INTO dbo.Profesionales (Matricula, Nombre, Apellido, ID_Especialidad, Telefono, Email)
VALUES ('MAT-1234', N'Carla', N'Sosa', 
        (SELECT ID_Especialidad FROM dbo.Especialidades WHERE Especialidad=N'Clínica Médica'),
        '11-4444-1001', 'carla.sosa@clinica.com');

-- Martín Lopez (Pediatría)
INSERT INTO dbo.Profesionales (Matricula, Nombre, Apellido, ID_Especialidad, Telefono, Email)
VALUES ('MAT-5678', N'Martín', N'Lopez', 
        (SELECT ID_Especialidad FROM dbo.Especialidades WHERE Especialidad=N'Pediatría'),
        '11-4444-1002', 'martin.lopez@clinica.com');

/* 📅 TURNOS */
-- Turno mañana 10:00 (Ana con Carla - Clínica Médica)
DECLARE @IdAna INT = (SELECT ID_Paciente FROM dbo.Pacientes WHERE DNI='30111222');
DECLARE @IdCarla INT = (SELECT ID_Profesional FROM dbo.Profesionales WHERE Matricula='MAT-1234');
DECLARE @IdClinica INT = (SELECT ID_Especialidad FROM dbo.Especialidades WHERE Especialidad=N'Clínica Médica');

INSERT INTO dbo.Turnos (ID_Paciente, ID_Profesional, ID_Especialidad, FechaHora, Estado, Motivo)
VALUES (@IdAna, @IdCarla, @IdClinica, DATEADD(DAY,1, CAST(CONVERT(date, SYSUTCDATETIME()) AS DATETIME2(0)) + '10:00'),
        N'Pendiente', N'Chequeo anual');

/* 📓 HISTORIALES */
DECLARE @IdTurno INT = SCOPE_IDENTITY();

INSERT INTO dbo.Historiales (ID_Turno, Diagnostico, Indicaciones, Notas)
VALUES (@IdTurno, N'Sin hallazgos relevantes', N'Hidratación y control anual', N'Paciente en buen estado general');
GO

/* =============================
   Verificación rápida
   ============================= */
SELECT * FROM dbo.Pacientes;
SELECT * FROM dbo.Especialidades;
SELECT * FROM dbo.Profesionales;
SELECT * FROM dbo.Turnos;
SELECT * FROM dbo.Historiales;
