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
select cod_socio, apellido_soc, nombre_soc, tipo_nro_doc, estado, nacimiento, tel from Socios
order by apellido_soc, nombre_soc, tipo_nro_doc
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
select cod_profe, apellido_profe, nombre_profe, tipo_nro_doc, cargo, nacimiento,tel from Profesores
order by apellido_profe,nombre_profe,tipo_nro_doc
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
--MOD
ALTER TABLE Actividades
ADD cant_ins INT DEFAULT 0,
    estado VARCHAR(50);
--Mostrar
create PROCEDURE sp_MostrarAct
AS 
BEGIN
    SELECT A.cod_act, A.nombre_act, A.hora, A.cant_ins, A.estado, A.cod_profe, P.nombre_profe, A.cod_salon, S.nombre_salon 
    FROM Actividades A
    INNER JOIN Profesores P ON A.cod_profe = P.cod_profe
    INNER JOIN Salones S ON A.cod_salon = S.cod_salon;
END;
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
CREATE PROCEDURE sp_ModificarAct
@cod_act int,
@nombre_act varchar(50),
@hora int,
@cod_profe int,
@cod_salon int
AS 
BEGIN
    DECLARE @cant_ins int;
    SELECT @cant_ins = COUNT(*) FROM Inscripciones WHERE cod_act = @cod_act;

    IF @cant_ins >= 15
        UPDATE Actividades SET nombre_act = @nombre_act, hora = @hora, cod_profe = @cod_profe, cod_salon = @cod_salon, estado = 'ACTIVA' WHERE cod_act = @cod_act;
    ELSE
        UPDATE Actividades SET nombre_act = @nombre_act, hora = @hora, cod_profe = @cod_profe, cod_salon = @cod_salon, estado = 'CERRADA' WHERE cod_act = @cod_act;
END
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
CREATE PROCEDURE sp_MostrarIns
AS 
BEGIN
    SELECT I.cod_socio, S.apellido_soc, S.nombre_soc, I.cod_act, A.nombre_act, I.cod_ins 
    FROM Inscripciones I
    INNER JOIN Actividades A ON I.cod_act = A.cod_act
    INNER JOIN Socios S ON I.cod_socio = S.cod_socio;
END;
--Alta
create PROCEDURE sp_AgregarIns
    @cod_socio INT,
    @cod_act INT
AS
BEGIN
    -- Verificar si ya existe una inscripción para el mismo socio y actividad
    IF NOT EXISTS (SELECT 1 FROM Inscripciones WHERE cod_socio = @cod_socio AND cod_act = @cod_act)
    BEGIN
        -- No existe una inscripción previa, proceder con la inserción
        INSERT INTO Inscripciones (cod_socio, cod_act)
        VALUES (@cod_socio, @cod_act);

        -- Incrementar el valor de cant_ins en la tabla de Actividades
        UPDATE Actividades
        SET cant_ins = cant_ins + 1
        WHERE cod_act = @cod_act;
    END
    ELSE
    BEGIN
        -- Ya existe una inscripción para el mismo socio y actividad, mostrar un mensaje indicando que no se puede realizar la inserción
        RAISERROR ('Ya existe una inscripción para este socio y actividad.', 16, 1);
    END
END
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
CREATE PROCEDURE sp_BajaIns
@cod_ins INT
AS
BEGIN
    DECLARE @cod_act INT;

    -- Obtener el código de la actividad antes de eliminar la inscripción
    SELECT @cod_act = cod_act FROM Inscripciones WHERE cod_ins = @cod_ins;

    -- Eliminar la inscripción
    DELETE FROM Inscripciones WHERE cod_ins = @cod_ins;

    -- Decrementar el valor de cant_ins en la tabla de Actividades
    UPDATE Actividades
    SET cant_ins = cant_ins - 1
    WHERE cod_act = @cod_act;
END


--PAGO
create table Pagos (
cod_pago int primary key identity(1,1),
cod_socio int foreign key references Socios(cod_socio),
fecha date,
precio int,
estado varchar(50))
--Mostrar
create PROCEDURE sp_MostrarPagos
AS 
BEGIN
    SELECT P.fecha, P.cod_socio, S.apellido_soc, S.nombre_soc, S.tipo_nro_doc, P.estado, P.precio 
    FROM Pagos P
    INNER JOIN Socios S ON P.cod_socio = S.cod_socio
    ORDER BY P.fecha, S.apellido_soc, S.nombre_soc, S.tipo_nro_doc;
END;
--Alta
create procedure sp_AgregarPago
@cod_socio int,
@fecha date,
@precio int,
@estado varchar(50)
as 
begin
insert into Pagos (cod_socio, fecha, precio, estado)
values (@cod_socio, @fecha, @precio, @estado)
end
--Modificacion
create procedure sp_ModificarPago
@cod_pago int,
@cod_socio int,
@fecha date,
@precio int,
@estado varchar(50)
as 
begin
update Pagos set cod_socio = @cod_socio, fecha = @fecha, precio = @precio, estado = @estado
where cod_pago = @cod_pago
end
--Baja
create procedure sp_BajaPago
@cod_pago int
as 
begin
delete from Pagos where cod_pago = @cod_pago
end
