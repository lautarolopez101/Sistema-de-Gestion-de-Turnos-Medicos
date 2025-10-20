INSERT INTO Familias (Nombre, Descripcion, Activo)
VALUES
('Administrador', 'Rol con acceso total al sistema, puede gestionar usuarios, permisos y ver todos los módulos.', 1),
('Profesional', 'Rol de profesional médico, puede ver y gestionar sus pacientes y turnos.', 1),
('Recepcion', 'Rol de recepción, puede crear y gestionar pacientes y turnos.', 1),
('Paciente', 'Rol de paciente, solo puede ver sus datos personales y sus turnos.', 1);

SELECT *FROM Familias