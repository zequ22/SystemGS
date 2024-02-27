use GSDB

--ESTADO SOCIOS
-- Procedimiento almacenado para actualizar el estado de los socios
CREATE PROCEDURE sp_ActualizarEstadoSocios
AS
BEGIN
    UPDATE Socios
    SET estado = CASE
                    WHEN EXISTS (SELECT 1 FROM Pagos WHERE Pagos.cod_socio = Socios.cod_socio AND Pagos.fecha > DATEADD(DAY, 30, GETDATE()))
                    THEN 'DEUDOR'
                    WHEN NOT EXISTS (SELECT 1 FROM Pagos WHERE Pagos.cod_socio = Socios.cod_socio)
                    THEN 'DEUDOR'
                    ELSE 'ACTIVO'
                 END;
END;

--VALIDAR ESTADO PARA INSCRIPCION
CREATE PROCEDURE sp_AgregarIns
@cod_socio int,
@cod_act int
AS 
BEGIN
    DECLARE @estado_socio VARCHAR(50)
    
    -- Obtener el estado del socio
    SELECT @estado_socio = estado FROM Socios WHERE cod_socio = @cod_socio
    
    -- Verificar si el estado del socio es "DEUDOR"
    IF @estado_socio = 'DEUDOR'
    BEGIN
        PRINT 'El socio tiene estado deudor y no puede inscribirse en una actividad.'
    END
    ELSE
    BEGIN
        -- Insertar la inscripción
        INSERT INTO Inscripciones (cod_socio, cod_act) VALUES (@cod_socio, @cod_act)
        PRINT 'Se agrego Inscripcion con exito!'
    END
END;
