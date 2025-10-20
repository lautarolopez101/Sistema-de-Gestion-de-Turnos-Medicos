INSERT INTO Patentes (Nombre, Descripcion, Activo)
VALUES
-- 🩺 PACIENTES
('Paciente.Crear', 'Permite crear un nuevo paciente', 1),
('Paciente.Editar', 'Permite editar los datos de un paciente', 1),
('Paciente.Eliminar', 'Permite eliminar o dar de baja un paciente', 1),
('Paciente.Ver', 'Permite ver la lista de pacientes', 1),
('Paciente.VerPropios', 'Permite al paciente ver solo su propia información', 1),

-- 👨‍⚕️ PROFESIONALES
('Profesional.Crear', 'Permite registrar un nuevo profesional', 1),
('Profesional.Editar', 'Permite editar datos de un profesional', 1),
('Profesional.Eliminar', 'Permite eliminar o dar de baja un profesional', 1),
('Profesional.Ver', 'Permite ver la lista de profesionales', 1),

-- 📅 TURNOS
('Turno.Crear', 'Permite crear nuevos turnos', 1),
('Turno.Editar', 'Permite modificar la fecha o estado de un turno', 1),
('Turno.Cancelar', 'Permite cancelar un turno existente', 1),
('Turno.Ver', 'Permite ver todos los turnos del sistema', 1),
('Turno.VerPropios', 'Permite al paciente ver solo sus turnos', 1),
('Turno.VerAgendaPropia', 'Permite al profesional ver su propia agenda', 1),
('Turno.Asignar', 'Permite asignar un turno a un paciente o profesional', 1),

-- 🔐 USUARIOS / SEGURIDAD
('Usuario.Crear', 'Permite crear nuevos usuarios', 1),
('Usuario.Editar', 'Permite modificar datos de usuarios', 1),
('Usuario.Eliminar', 'Permite eliminar usuarios', 1),
('Usuario.Ver', 'Permite ver la lista de usuarios', 1),
('Usuario.Bloquear', 'Permite bloquear o desbloquear usuarios', 1),
('Usuario.AsignarFamilia', 'Permite asignar o quitar roles a un usuario', 1),
('Usuario.AsignarPatente', 'Permite asignar o quitar patentes directas a un usuario', 1),

-- 🧩 FAMILIAS / ROLES
('Familia.Crear', 'Permite crear nuevas familias (roles)', 1),
('Familia.Editar', 'Permite modificar familias existentes', 1),
('Familia.Eliminar', 'Permite eliminar familias', 1),
('Familia.Ver', 'Permite ver el listado de familias', 1),
('Familia.AsignarPatente', 'Permite vincular patentes a una familia', 1),
('Familia.AsignarFamilia', 'Permite vincular familias entre sí', 1),

-- ⚙️ CONFIGURACIÓN
('Configuracion.Editar', 'Permite modificar configuraciones generales del sistema', 1),
('Idioma.Cambiar', 'Permite cambiar el idioma del sistema', 1),
('Sistema.RespaldarBD', 'Permite realizar copias de seguridad de la base de datos', 1),
('Sistema.RestaurarBD', 'Permite restaurar copias de seguridad de la base de datos', 1),

-- 🧾 AUDITORÍA
('Auditoria.Ver', 'Permite ver los registros de auditoría', 1),
('Auditoria.Exportar', 'Permite exportar los registros de auditoría', 1);


SELECT *FROM Patentes order by Nombre