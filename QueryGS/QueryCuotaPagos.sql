use GSDB

/*
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
end*/

drop table Pagos
drop table Cuotas

-- CUOTAS
create table Cuotas (
    cod_cuota int primary key,
    mes_cuota varchar(50),
    anio_cuota int,
    precio_cuota decimal)

alter table Cuotas
alter column precio_cuota int

-- PAGOS
create table Pagos (
    cod_pago int primary key identity(1,1),
    cod_socio int,
    cod_cuota int,
    fecha_pago date,
    precio_pago decimal,
    foreign key (cod_socio) references Socios(cod_socio),
    foreign key (cod_cuota) references Cuotas(cod_cuota))

alter table Pagos
alter column precio_pago int

--TRIGGER
create trigger trg_set_precio_pago
on Pagos
after insert
as
begin
    update Pagos
    set precio_pago = Cuotas.precio_cuota
    from Pagos
    join Cuotas on Pagos.cod_cuota = Cuotas.cod_cuota
    where Pagos.cod_pago in (select cod_pago from inserted);
end;

--SPs
create procedure sp_MostrarCuotas
as
begin
    select cod_cuota as CODIGO, mes_cuota as MES, anio_cuota as ANIO, precio_cuota as PRECIO from Cuotas;
end;
--ALTA
create procedure sp_AltaCuota
    @cod_cuota int,
    @mes_cuota varchar(50),
    @anio_cuota int,
    @precio_cuota decimal
as
begin
    insert into Cuotas (cod_cuota, mes_cuota, anio_cuota, precio_cuota)
    values (@cod_cuota, @mes_cuota, @anio_cuota, @precio_cuota);
end;
--MOD
create procedure sp_ModificarCuota
    @cod_cuota int,
    @mes_cuota varchar(50),
    @anio_cuota int,
    @precio_cuota decimal
as
begin
    update Cuotas
    set mes_cuota = @mes_cuota,
        anio_cuota = @anio_cuota,
        precio_cuota = @precio_cuota
    where cod_cuota = @cod_cuota;
end;
--BAJA
create procedure sp_BajaCuota
    @cod_cuota int
as
begin
    delete from Cuotas
    where cod_cuota = @cod_cuota;
end;

--MOSTRAR
drop procedure sp_MostrarPagos
/*create procedure sp_MostrarPagos
as
begin
    select cod_pago AS PAGO, cod_cuota as CUOTA, cod_socio as SOCIO, fecha_pago as FECHA, precio_pago as PRECIO from Pagos;
end;*/

CREATE PROCEDURE sp_MostrarPagos
AS
BEGIN
    SELECT 
        P.cod_pago AS PAGO, 
        P.cod_cuota AS CUOTA, 
        P.cod_socio AS SOCIO,
        S.nombre_soc AS NOMBRE,
        S.apellido_soc AS APELLIDO,
        P.fecha_pago AS FECHA, 
        P.precio_pago AS PRECIO,
        S.tipo_nro_doc AS DNI
    FROM 
        Pagos P
    JOIN 
        Socios S ON P.cod_socio = S.cod_socio;
END;

--ALTA
create procedure sp_AltaPago
    @cod_socio int,
    @cod_cuota int,
    @fecha_pago date
as
begin
    insert into Pagos (cod_socio, cod_cuota, fecha_pago)
    values (@cod_socio, @cod_cuota, @fecha_pago);
end;
--MOD
create procedure sp_ModificarPago
    @cod_pago int,
    @cod_socio int,
    @cod_cuota int,
    @fecha_pago date
as
begin
    update Pagos
    set cod_socio = @cod_socio,
        cod_cuota = @cod_cuota,
        fecha_pago = @fecha_pago
    where cod_pago = @cod_pago;
end;
--BAJA
create procedure sp_BajaPago
    @cod_pago int
as
begin
    delete from Pagos
    where cod_pago = @cod_pago;
end;




--PRUEBA
select * from Socios
select * from Cuotas
select * from Pagos

insert into Cuotas (cod_cuota, mes_cuota, anio_cuota, precio_cuota) values (082024,'agosto',2024,21500)

insert into Pagos (cod_socio, cod_cuota, fecha_pago) values (1,082024,'2/8/2024')