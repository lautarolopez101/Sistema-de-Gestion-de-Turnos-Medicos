/* ============================
   A.2 — CONSULTAS BÁSICAS
   Base de datos a usar
   ============================ */
USE [Sistema de Gestion de Turnos Medicos];
GO

/* 👀 A2.1: Ver todo (SELECT *) */
SELECT * FROM dbo.Pacientes;
SELECT * FROM dbo.Profesionales;
SELECT * FROM dbo.Especialidades;
SELECT * FROM dbo.Turnos;
SELECT * FROM dbo.Historiales;

/* 🔎 A2.2: Filtrar filas (WHERE) */
-- Pacientes con apellido 'García'
SELECT * FROM dbo.Pacientes
WHERE Apellido = N'García';

-- Turnos en estado 'Pendiente'
SELECT * FROM dbo.Turnos
WHERE Estado = N'Pendiente';

-- Turnos a partir de hoy
SELECT * FROM dbo.Turnos
WHERE FechaHora >= CONVERT(date, SYSUTCDATETIME());

/* 🧮 A2.3: Elegir columnas (evitar SELECT *) */
SELECT ID_Paciente, Nombre, Apellido
FROM dbo.Pacientes;

/* 🧱 A2.4: Ordenar resultados (ORDER BY) */
SELECT ID_Paciente, Nombre, Apellido
FROM dbo.Pacientes
ORDER BY Apellido ASC, Nombre ASC;

/* 🔗 A2.5: Unir tablas (JOIN) para ver datos “legibles” */
SELECT
    t.ID_Turno,
    t.FechaHora,
    t.Estado,
    p.Nombre  AS NombrePaciente,
    p.Apellido AS ApellidoPaciente,
    pr.Nombre + N' ' + pr.Apellido AS NombreMedico,
    e.Especialidad
FROM dbo.Turnos t
JOIN dbo.Pacientes p      ON p.ID_Paciente = t.ID_Paciente
JOIN dbo.Profesionales pr ON pr.ID_Profesional = t.ID_Profesional
JOIN dbo.Especialidades e ON e.ID_Especialidad = t.ID_Especialidad
ORDER BY t.FechaHora DESC;

/* 🧱 A2.6: Contar filas (COUNT) — ¿cuántos turnos por estado? */
SELECT Estado, COUNT(*) AS Cantidad
FROM dbo.Turnos
GROUP BY Estado;

/* ⏳ A2.7: Rango de fechas (BETWEEN) */
SELECT *
FROM dbo.Turnos
WHERE FechaHora BETWEEN DATEADD(DAY, -7, SYSUTCDATETIME()) AND DATEADD(DAY, 7, SYSUTCDATETIME());

/* ✅ A2.8: ¿Existe? (EXISTS) — ¿Hay turnos para un paciente específico? */
DECLARE @IdPaciente INT = 1; -- cambiá el valor para probar
IF EXISTS (SELECT 1 FROM dbo.Turnos WHERE ID_Paciente = @IdPaciente)
    PRINT 'Hay turnos para ese paciente';
ELSE
    PRINT 'No hay turnos para ese paciente';
