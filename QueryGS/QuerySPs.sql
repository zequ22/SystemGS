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
