/* 
Lo que hariamos aca seria actualizar en la lista de pacientes
el paciente dicho ID_Paciente para poder despues agregarlo a la lista de
Historial de cambios de estado.

Despues tengo que poner que cuando me muestre la lista de pacientes pueda filtrar para ver por UNICO Paciente
todos los cambios que tuvo y asi para poder ver que fue lo que paso 
*/ 
 
update Pacientes set
DNI ='46567030',
Nombre = 'Lautaro' ,
Apellido = 'Lopez' ,
FechaNacimiento = '2025-03-22',
Telefono = '+54 11 57027054',
Email = 'lautaro.lopez@mail.com' , 
Estado = 'Desactivado'
where ID_Paciente = 31


Insert into HistorialCambiosEstadoPacientes (ID_Paciente, Estado)

select * from Pacientes
where Estado = 'Desactivado'