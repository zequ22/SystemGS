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

--ESTADO ACTIVIDAD
CREATE PROCEDURE sp_ActualizarEstadoActividad
AS
BEGIN
    UPDATE Actividades
    SET estado = CASE
                    WHEN cant_ins >= 15 THEN 'ACTIVO'
                    ELSE 'CERRADO'
                 END;
END;
