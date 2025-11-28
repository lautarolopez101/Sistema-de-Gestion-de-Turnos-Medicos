SELECT 
    p.Nombre     AS NombreProfesional,
    p.Apellido   AS ApellidoProfesional,
    t.Estado,
    t.Motivo,
	t.Observaciones,
    t.FechaHora
FROM dbo.Turnos AS t
INNER JOIN dbo.Profesionales AS p
    ON p.ID_Profesional = t.ID_Profesional
WHERE 
    t.ID_Paciente = 52
    AND t.Estado IN (N'Atendido', N'Cancelado')
ORDER BY t.FechaHora DESC;