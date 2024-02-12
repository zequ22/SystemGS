--CREACION DB
create database GSDB
use GSDB

--MIEMBROS
create table Socios(
cod_socio int primary key identity(1,1),
tipo_nro_doc varchar(50),
nombre_soc varchar(50),
apellido_soc varchar(50),
nacimiento date,
tel varchar(50),
estado varchar(50))

--Mostrar
create procedure sp_MostrarSocios
as begin
select * from Socios
end
--Alta
create procedure sp_AgregarSocio
@tipo_nro_doc varchar(50),
@nombre_soc varchar(50),
@apellido_soc varchar(50),
@nacimiento date,
@tel varchar(50),
@estado varchar(50)
as begin
insert into Socios values (@tipo_nro_doc,@nombre_soc,@apellido_soc,@nacimiento,@tel,@estado)
end
--Modificacion
create procedure sp_ModificarSocio
@cod_socio int,
@tipo_nro_doc varchar(50),
@nombre_soc varchar(50),
@apellido_soc varchar(50),
@nacimiento date,
@tel varchar(50),
@estado varchar(50)
as begin
update Socios set tipo_nro_doc = @tipo_nro_doc , nombre_soc = @nombre_soc , apellido_soc = @apellido_soc , nacimiento = @nacimiento , tel = @tel , estado = @estado
where cod_socio = @cod_socio
end
--Baja
create procedure sp_BajaSocio
@cod_socio int
as begin
delete from Socios where cod_socio = @cod_socio
end


--PROFESORES
create table Profesores(
cod_profe int primary key identity(1,1),
tipo_nro_doc varchar(50),
nombre_profe varchar(50),
apellido_profe varchar(50),
nacimiento date,
tel varchar(50),
cargo varchar(50))
--Mostrar
create procedure sp_MostrarProfesores
as begin
select * from Profesores
end
--Alta
create procedure sp_AgregarProfesor
@tipo_nro_doc varchar(50),
@nombre_profe varchar(50),
@apellido_profe varchar(50),
@nacimiento date,
@tel varchar(50),
@cargo varchar(50)
as begin
insert into Profesores values (@tipo_nro_doc,@nombre_profe,@apellido_profe,@nacimiento,@tel,@cargo)
end
--Modificacion
create procedure sp_ModificarProfesor
@cod_profe int,
@tipo_nro_doc varchar(50),
@nombre_profe varchar(50),
@apellido_profe varchar(50),
@nacimiento date,
@tel varchar(50),
@cargo varchar(50)
as begin
update Profesores set tipo_nro_doc = @tipo_nro_doc , nombre_profe = @nombre_profe , apellido_profe = @apellido_profe , nacimiento = @nacimiento , tel = @tel , cargo = @cargo
where cod_profe = @cod_profe
end
--Baja
create procedure sp_BajaProfesor
@cod_profe int
as begin
delete from Profesores where cod_profe = @cod_profe
end


--SALONES
create table Salones(
cod_salon int primary key identity(1,1),
nombre_salon varchar(50),
capacidad int,
descripcion varchar(50))
--Mostrar
create procedure sp_MostrarSalones
as begin
select * from Salones
end
--Alta
create procedure sp_AgregarSalon
@nombre_salon varchar(50),
@capacidad int,
@descripcion varchar(50)
as begin
insert into Salones values (@nombre_salon,@capacidad,@descripcion)
end
--Modificacion
create procedure sp_ModificarSalon
@cod_salon int,
@nombre_salon varchar(50),
@capacidad int,
@descripcion varchar(50)
as begin
update Salones set nombre_salon = @nombre_salon , capacidad = @capacidad , descripcion = @descripcion
where cod_salon = @cod_salon
end
--Baja
create procedure sp_BajaSalon
@cod_salon int
as begin
delete from Salones where cod_salon = @cod_salon
end


--Actividades
create table Actividades(
cod_act int primary key identity(1,1),
nombre_act varchar(50),
hora int,
cod_profe int foreign key references Profesores(cod_profe),
cod_salon int foreign key references Salones(cod_salon))
--Mostrar
create procedure sp_MostrarAct
as begin
select * from Actividades
end
--Alta
create procedure sp_AgregarAct
@nombre_act varchar(50),
@hora int,
@cod_profe int,
@cod_salon int
as 
begin
insert into Actividades (nombre_act, hora, cod_profe, cod_salon)
values (@nombre_act, @hora, @cod_profe, @cod_salon)
end
--Modificacion
create procedure sp_ModificarAct
@cod_act int,
@nombre_act varchar(50),
@hora int,
@cod_profe int,
@cod_salon int
as 
begin
update Actividades set nombre_act = @nombre_act, hora = @hora, cod_profe = @cod_profe, cod_salon = @cod_salon
where cod_act = @cod_act
end
--Baja
create procedure sp_BajaActividad
@cod_act int
as 
begin
delete from Actividades where cod_act = @cod_act
end


--INSCRIPCIONES
create table Inscripciones(
cod_ins int primary key identity(1,1),
cod_socio int foreign key references Socios(cod_socio),
cod_act int foreign key references Actividades(cod_act))
--Mostrar
create procedure sp_MostrarIns
as begin
select * from Inscripciones
end
--Alta
create procedure sp_AgregarIns
@cod_socio int,
@cod_act int
as 
begin
insert into Inscripciones (cod_socio, cod_act)
values (@cod_socio, @cod_act)
end
--Modificacion
create procedure sp_ModificarIns
@cod_ins int,
@cod_socio int,
@cod_act int
as 
begin
update Inscripciones set cod_socio = @cod_socio, cod_act = @cod_act
where cod_ins = @cod_ins
end
--Baja
create procedure sp_BajaIns
@cod_ins int
as 
begin
delete from Inscripciones where cod_ins = @cod_ins
end


--CUOTA
CREATE TABLE Cuotas (
mes_cuota VARCHAR(50),
ano_cuota VARCHAR(50),
cod_cuota AS (mes_cuota + '_' + ano_cuota) PERSISTED NOT NULL PRIMARY KEY,
precio DECIMAL
)
INSERT INTO Cuotas (mes_cuota, ano_cuota, precio) VALUES ('Enero', '2024', 100.00);
select * from Cuotas


--PAGO
create table Pagos(
cod_pago int primary key identity(1,1),
cod_cuota int foreign key references Cuotas(cod_cuota),
cod_socio int foreign key references Socios(cod_socio),
estado nvarchar(60))