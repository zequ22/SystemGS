--NUEVO			
create table ROL(
rol_id int primary key identity,
rol_descripcion varchar(50),
rol_fechaAlta datetime default getdate()
)

select * from ROL

delete from ROL where rol_id = 4 

insert into ROL (rol_descripcion) 
values('ADMINISTRADOR')

insert into ROL (rol_descripcion) 
values('EMPLEADO') 

insert into ROL (rol_descripcion) 
values('PROFESOR') 

insert into ROL (rol_descripcion) 
values('SUPERADMIN')

create table PERMISO(
permiso_id int primary key identity,
rol_id int references ROL(rol_id),
nombre_menu varchar(100),
permiso_fechaAlta datetime default getdate()
)
select * from PERMISO
-- Muestar los permisos que tiene el usuario
select p.rol_id, p.nombre_menu from PERMISO p
inner join ROL r on r.rol_id = p.rol_id
inner join USUARIO u on u.rol_id = r.rol_id
where u.usuario_id = 1


insert into PERMISO (rol_id, nombre_menu)
values 
(4, 'menuCuotas')

insert into PERMISO (rol_id, nombre_menu)
values 
(1, 'menuUsuarios'),
(1, 'menuReportes')

insert into PERMISO (rol_id, nombre_menu)
values 
(2, 'menuSocios'),
(2, 'menuPagos'),
(2, 'menuInscripciones'),
(2, 'menuActividades')

insert into PERMISO (rol_id, nombre_menu)
values 
(3, 'menuProfesores'),
(3, 'menuSalones')

insert into PERMISO (rol_id, nombre_menu)
values 
(4, 'menuUsuarios'),
(4, 'menuReportes'),
(4, 'menuSocios'),
(4, 'menuPagos'),
(4, 'menuInscripciones'),
(4, 'menuActividades'),
(4, 'menuProfesores'),
(4, 'menuSalones')
-- MODIFICAR PROFESOR AGREGANDO CLAVE

create table USUARIO(
usuario_id int primary key identity,
tipo_nro_doc varchar(50),
nombre_usuario varchar(50),
apellido_usuario varchar(50),
clave varchar(50),
rol_id int references ROL(rol_id),
estado bit,
usuario_fechaAlta datetime default getdate()
)

select * from USUARIO

insert into USUARIO(tipo_nro_doc, nombre_usuario, apellido_usuario, clave, rol_id, estado)
values ('1111', 'Nico', 'Micheletti', 'test1234', 1, 1)

insert into USUARIO(tipo_nro_doc, nombre_usuario, apellido_usuario, clave, rol_id, estado)
values ('2222', 'Juana', 'Gonz�lez', 'test1234', 2, 1)

insert into USUARIO(tipo_nro_doc, nombre_usuario, apellido_usuario, clave, rol_id, estado)
values ('3333', 'Rodrigo', 'Cavazza', 'test1234', 3, 1)

insert into USUARIO(tipo_nro_doc, nombre_usuario, apellido_usuario, clave, rol_id, estado)
values ('4', 'Super', 'Admin', 'test1234', 4, 1)

insert into USUARIO(tipo_nro_doc, nombre_usuario, apellido_usuario, clave, rol_id, estado)
values ('admin', 'Admin', 'Admin', 'admin', 4, 1)

drop table USUARIO
drop table PERMISO
drop table ROL
delete USUARIO
delete PERMISO
delete ROL

select u.usuario_id, u.tipo_nro_doc, u.nombre_usuario, u.apellido_usuario, u.clave, u.estado, r.rol_id, r.rol_descripcion from USUARIO u
inner join rol r on r.rol_id = u.rol_id

-- CREO SP PARA CREAR UN USUARIO

CREATE PROC Sp_RegistrarUsuario(
	@tipo_nro_doc varchar(50),
	@nombre_usuario varchar(50),
	@apellido_usuario varchar(50),
	@clave varchar(100),
	@rol_id int,
	@estado bit,
	@IdUsuarioResultado int output,
	@Mensaje varchar(500) output
)
AS
BEGIN
	set @IdUsuarioResultado = 0

	if not exists(select * from USUARIO where tipo_nro_doc = @tipo_nro_doc)
	BEGIN
		insert into USUARIO(tipo_nro_doc,nombre_usuario,apellido_usuario,clave,rol_id,estado) 
		values (@tipo_nro_doc, @nombre_usuario, @apellido_usuario, @clave, @rol_id, @estado)

		set @IdUsuarioResultado = SCOPE_IDENTITY()
		set @Mensaje = ''
	END
	else 
	set @Mensaje = 'No pueden existir dos Usuario con el mismo DNI'
END
use GSDB
-- SP Editar Usuario
CREATE PROC Sp_EditarUsuario(
	@usuario_id int,
	@tipo_nro_doc varchar(50),
	@nombre_usuario varchar(50),
	@apellido_usuario varchar(50),
	@clave varchar(100),
	@rol_id int,
	@estado bit,
	@Resupuesta bit output,
	@Mensaje varchar(500) output
)
AS
BEGIN
	set @Resupuesta = 0
	set @Mensaje = ''

	if not exists(select * from USUARIO where tipo_nro_doc = @tipo_nro_doc and usuario_id != @usuario_id)
	BEGIN
		update USUARIO set
		tipo_nro_doc = @tipo_nro_doc,
		nombre_usuario = @nombre_usuario,
		apellido_usuario = @apellido_usuario,
		clave = @clave,
		rol_id = @rol_id,
		estado = @estado 		
		where usuario_id = @usuario_id

		set @Resupuesta = 1		
	END
	else 
	set @Mensaje = 'No pueden existir dos Usuario con el mismo DNI'
END

go

CREATE PROC Sp_EliminarUsuario
@usuario_id int,
@Respuesta bit output,
@Mensaje varchar(500) output
AS
BEGIN
	set @Respuesta = 0
	set @Mensaje = ''
	--IF EXISTS (SELECT * FROM Actividades)
	--select * FROM profesores ACA HAY QUE CREAR RELACION CON ACTIVIDADES (PROFE EN LA CLASE) Y PROFESOR (UN PROFE ACTIVO PARA QUE CARGUE SUS HORAS DE TRABAJO)
	DELETE FROM USUARIO where usuario_id = @usuario_id
	set @Respuesta = 1
END
