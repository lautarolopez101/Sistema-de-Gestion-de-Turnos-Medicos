

DBCC CHECKIDENT('Turnos',RESEED,0)

INSERT INTO Turnos
(ID_Paciente, ID_Profesional, Estado, FechaHora, Motivo, Observarciones)
VALUES
-- Semana actual
(3,   1,  'Reservado',  '2025-11-04 09:00', 'Chequeo clínico',                 'Primera consulta'),
(18,  4,  'Confirmado', '2025-11-04 10:30', 'Control cardiológico',            'ECG previo en mano'),
(27,  6,  'Reservado',  '2025-11-04 11:15', 'Ginecología - control anual',     NULL),
(12,  8,  'Reservado',  '2025-11-04 15:00', 'Dermatología - lunares',          'Trae fotos de lesiones'),
(41,  3,  'Confirmado', '2025-11-05 09:45', 'Pediatría - control',             'Viene con madre'),
(7,   10, 'Reservado',  '2025-11-05 14:00', 'Traumatología - dolor de rodilla','Lesión deportiva'),
(25,  2,  'Reservado',  '2025-11-05 16:30', 'Neurología - migrañas',           NULL),
(49,  5,  'Confirmado', '2025-11-06 08:30', 'Endocrinología - control tiroides','TSH alta'),
(14,  9,  'Reservado',  '2025-11-06 10:00', 'Otorrinolaringología - sinusitis',NULL),
(30,  11, 'Reservado',  '2025-11-06 11:30', 'Oftalmología - control visual',   'Usa anteojos'),

-- Próxima semana
(5,   12, 'Confirmado', '2025-11-10 09:00', 'Clínica médica - control anual',  'En ayunas'),
(33,  13, 'Reservado',  '2025-11-10 10:15', 'Oncología - seguimiento',         'Revisión de estudios'),
(21,  7,  'Reservado',  '2025-11-10 13:00', 'Ginecología - PAP',               NULL),
(9,   16, 'Reservado',  '2025-11-11 09:30', 'Kinesiología - rehabilitación',   'Esguince leve'),
(2,   14, 'Confirmado', '2025-11-11 11:00', 'Cardiología - control post ECO',  NULL),
(37,  18, 'Reservado',  '2025-11-11 15:45', 'Neurología - parestesias',        NULL),
(45,  20, 'Reservado',  '2025-11-12 10:30', 'Dermatología - acné',             NULL),
(28,  19, 'Confirmado', '2025-11-12 12:00', 'Traumatología - hombro',          'Dolor al levantar peso'),
(11,  15, 'Reservado',  '2025-11-12 16:00', 'Endocrinología - diabetes',       'Control de glucosa'),
(51,  21, 'Reservado',  '2025-11-13 09:15', 'Oftalmología - fondo de ojo',     NULL),

-- Turnos pasados / administrativos
(23,  1,  'Atendido',   '2025-10-28 10:00', 'Clínica médica - fiebre',         'Evolución favorable'),
(36,  4,  'Cancelado',  '2025-10-29 11:30', 'Cardiología - control',           'Canceló por viaje'),
(8,   6,  'Atendido',   '2025-10-30 14:30', 'Ginecología - control',           'Todo normal'),
(32,  10, 'Atendido',   '2025-10-31 09:45', 'Traumatología - tobillo',         'Alta sin kinesiología'),
(40,  3,  'Cancelado',  '2025-11-01 10:00', 'Pediatría - fiebre',              'No se presentó');


SELECT * FROM Turnos