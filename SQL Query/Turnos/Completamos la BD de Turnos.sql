DELETE FROM Turnos

DBCC CHECKIDENT ('Turnos', RESEED, 0);

INSERT INTO Turnos (ID_Paciente, ID_Profesional, Estado, FechaHora, Motivo, Observaciones)
VALUES
-- Atendidos (observaciones SI)
(3,   1,  'Atendido',   '2025-10-20 09:00', 'Consulta general',                       'Evolución favorable; control en 3 meses'),
(17,  4,  'Atendido',   '2025-10-21 10:30', 'Control post-estudios',                  'Resultados dentro de rangos'),
(28,  6,  'Atendido',   '2025-10-22 11:15', 'Dolor lumbar',                           'Se indica kinesiología y AINES'),
(12,  8,  'Atendido',   '2025-10-23 15:00', 'Lesión de piel',                         'Se realiza crioterapia'),
(41,  3,  'Atendido',   '2025-10-24 09:45', 'Control pediátrico',                     'Peso y talla adecuados'),
(7,   10, 'Atendido',   '2025-10-24 14:00', 'Dolor de rodilla',                       'Sospecha meniscal; Rx solicitada'),
(25,  2,  'Atendido',   '2025-10-25 16:30', 'Cefaleas recurrentes',                   'Profilaxis indicada'),
(49,  5,  'Atendido',   '2025-10-26 08:30', 'Control tiroideo',                       'Ajuste de dosis'),
(14,  9,  'Atendido',   '2025-10-26 10:00', 'Rinitis',                                 'Se indica aerosol nasal'),
(30,  11, 'Atendido',   '2025-10-26 11:30', 'Control visual',                          'Cambio de graduación'),
(5,   12, 'Atendido',   '2025-10-27 09:00', 'Chequeo anual',                           'Sin hallazgos'),
(33,  13, 'Atendido',   '2025-10-27 10:15', 'Seguimiento oncológico',                  'Estudios estables'),
(21,  7,  'Atendido',   '2025-10-27 13:00', 'Controles de rutina',                     'Se programa control en 6 meses'),
(9,   16, 'Atendido',   '2025-10-28 09:30', 'Rehabilitación de tobillo',               'Buena respuesta; continuar'),
(22,  18, 'Atendido',   '2025-10-28 15:45', 'Hormonas/Metabolismo',                    'Laboratorio a 30 días'),

-- Confirmados (observaciones NO)
(45,  20, 'Confirmado', '2025-11-18 10:30', 'Control dermatológico',                   NULL),
(28,  19, 'Confirmado', '2025-11-18 12:00', 'Dolor de hombro',                         NULL),
(11,  15, 'Confirmado', '2025-11-18 16:00', 'Control de diabetes',                     NULL),
(51,  21, 'Confirmado', '2025-11-19 09:15', 'Fondo de ojo',                            NULL),
(6,   22, 'Confirmado', '2025-11-19 10:00', 'Consulta general',                        NULL),
(18,  23, 'Confirmado', '2025-11-19 11:30', 'Chequeo laboral',                         NULL),
(29,  24, 'Confirmado', '2025-11-19 14:00', 'Control de presión',                      NULL),
(32,  1,  'Confirmado', '2025-11-20 09:00', 'Control clínico',                         NULL),
(44,  2,  'Confirmado', '2025-11-20 10:30', 'Neuro - parestesias',                     NULL),
(4,   3,  'Confirmado', '2025-11-20 11:15', 'Control pediátrico',                      NULL),
(8,   4,  'Confirmado', '2025-11-20 15:00', 'Consulta cardiológica',                   NULL),
(13,  5,  'Confirmado', '2025-11-21 08:30', 'Controles hormonales',                    NULL),
(16,  6,  'Confirmado', '2025-11-21 10:00', 'Control ginecológico',                    NULL),
(20,  7,  'Confirmado', '2025-11-21 11:30', 'PAP/colpo',                                NULL),
(23,  8,  'Confirmado', '2025-11-21 14:00', 'Dermato - acné',                          NULL),
(26,  9,  'Confirmado', '2025-11-22 09:30', 'Otorrino - sinusitis',                    NULL),
(31,  10, 'Confirmado', '2025-11-22 11:00', 'Traumato - lumbalgia',                    NULL),
(34,  11, 'Confirmado', '2025-11-22 12:30', 'Oftalmo - control',                       NULL),
(37,  12, 'Confirmado', '2025-11-22 16:00', 'Clínica - dislipemia',                    NULL),
(40,  13, 'Confirmado', '2025-11-23 09:00', 'Oncología - revisión',                    NULL),

-- Pendientes (observaciones NULL obligatorio)
(2,   14, 'Pendiente',  '2025-11-23 11:00', 'Cardio - control post ECO',               NULL),
(10,  15, 'Pendiente',  '2025-11-23 15:45', 'Endocrino - control glucemia',            NULL),
(19,  16, 'Pendiente',  '2025-11-24 09:30', 'Kinesiología - rehabilitación',           NULL),
(27,  17, 'Pendiente',  '2025-11-24 10:45', 'Consulta general',                        NULL),
(35,  18, 'Pendiente',  '2025-11-24 12:15', 'Metabolismo - evaluación',                NULL),
(38,  19, 'Pendiente',  '2025-11-24 14:00', 'Traumato - hombro',                       NULL),
(42,  20, 'Pendiente',  '2025-11-25 09:15', 'Dermato - control',                       NULL),
(46,  21, 'Pendiente',  '2025-11-25 10:30', 'Oftalmo - graduación',                    NULL),

-- Cancelados (observaciones NULL obligatorio)
(1,   22, 'Cancelado',  '2025-11-25 11:45', 'Clínica - control',                       NULL),
(24,  23, 'Cancelado',  '2025-11-25 13:00', 'Chequeo prequirúrgico',                   NULL),
(36,  24, 'Cancelado',  '2025-11-26 09:00', 'Control de presión',                      NULL),
(43,  3,  'Cancelado',  '2025-11-26 10:30', 'Control pediátrico',                      NULL),
(48,  6,  'Cancelado',  '2025-11-26 11:45', 'Ginecología - control',                   NULL),
(50,  9,  'Cancelado',  '2025-11-26 15:15', 'Otorrino - oído tapado',                  NULL);

-- Total filas: 50

INSERT INTO Turnos
(ID_Paciente, ID_Profesional, Estado, FechaHora, Motivo, Observaciones)
VALUES
/* ============================
      🟩 ATENDIDO (5 turnos)
   ============================ */
(52, 4,  'Atendido', '2025-10-20 09:30', 'Cardiología - control anual',
 'Paciente estable; repetir estudios en 6 meses'),
(52, 7,  'Atendido', '2025-10-22 11:00', 'Ginecología - control de rutina',
 'Sin hallazgos; estudios normales'),
(52, 11, 'Atendido', '2025-10-25 15:15', 'Oftalmología - revisión',
 'Actualización de lentes recomendada'),
(52, 3,  'Atendido', '2025-10-28 08:30', 'Clínica médica - fiebre',
 'Buena evolución; completar antibiótico'),
(52, 15, 'Atendido', '2025-11-01 10:45', 'Endocrinología - tiroides',
 'Ajuste de dosis indicado por TSH elevada'),

/* ============================
    🟦 CONFIRMADO (5 turnos)
   ============================ */
(52, 9,  'Confirmado', '2025-11-18 11:00', 'Otorrino - chequeo de oído', NULL),
(52, 13, 'Confirmado', '2025-11-20 09:45', 'Oncología - seguimiento', NULL),
(52, 5,  'Confirmado', '2025-11-22 14:00', 'Endocrino - control metabólico', NULL),
(52, 18, 'Confirmado', '2025-11-24 08:30', 'Neurología - mareos', NULL),
(52, 21, 'Confirmado', '2025-11-25 16:00', 'Oftalmología - fondo de ojo', NULL),

/* ============================
      🟨 PENDIENTE (5 turnos)
   ============================ */
(52, 2,  'Pendiente', '2025-11-27 09:00', 'Clínica médica - control general', NULL),
(52, 8,  'Pendiente', '2025-11-27 11:30', 'Dermatología - lunares', NULL),
(52, 10, 'Pendiente', '2025-11-28 13:00', 'Traumatología - estudios', NULL),
(52, 17, 'Pendiente', '2025-11-29 15:15', 'Kinesiología - rehabilitación', NULL),
(52, 24, 'Pendiente', '2025-11-30 10:30', 'Clínica - análisis prequirúrgicos', NULL),

/* ============================
     🟥 CANCELADO (5 turnos)
   ============================ */
(52, 6,  'Cancelado', '2025-12-01 09:45', 'Ginecología - control anual', NULL),
(52, 12, 'Cancelado', '2025-12-02 08:00', 'Clínica - seguimiento', NULL),
(52, 14, 'Cancelado', '2025-12-03 10:00', 'Cardiología - revisión', NULL),
(52, 19, 'Cancelado', '2025-12-04 12:30', 'Traumatología - dolor lumbar', NULL),
(52, 22, 'Cancelado', '2025-12-05 16:45', 'Clínica - chequeo médico', NULL);