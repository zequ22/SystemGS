use GSDB

//
CREATE PROC Sp_AsignarMenuARol(
    @rol_id int,
    @nombre_menu varchar(100),
    @Respuesta bit OUTPUT,
    @Mensaje varchar(500) OUTPUT
)
AS
BEGIN
    SET @Respuesta = 0;
    IF NOT EXISTS (SELECT * FROM PERMISO WHERE rol_id = @rol_id AND nombre_menu = @nombre_menu)
    BEGIN
        INSERT INTO PERMISO (rol_id, nombre_menu, permiso_fechaAlta) 
        VALUES (@rol_id, @nombre_menu, GETDATE());
        SET @Respuesta = 1;
        SET @Mensaje = 'Men� asignado al rol exitosamente.';
    END
    ELSE
        SET @Mensaje = 'El men� ya est� asignado a este rol.';
END

//
CREATE PROC Sp_QuitarMenuDeRol(
    @rol_id int,
    @nombre_menu varchar(100),
    @Respuesta bit OUTPUT,
    @Mensaje varchar(500) OUTPUT
)
AS
BEGIN
    SET @Respuesta = 0;
    IF EXISTS (SELECT * FROM PERMISO WHERE rol_id = @rol_id AND nombre_menu = @nombre_menu)
    BEGIN
        DELETE FROM PERMISO WHERE rol_id = @rol_id AND nombre_menu = @nombre_menu;
        SET @Respuesta = 1;
        SET @Mensaje = 'Men� quitado del rol exitosamente.';
    END
    ELSE
        SET @Mensaje = 'El men� no est� asignado a este rol.';
END