select * from Especialidades

DBCC CHECKIDENT ('Especialidades',RESEED,10)

insert into Especialidades (Especialidad,Descripcion) 
values ('Odontolog�a','Salud bucal y dental')