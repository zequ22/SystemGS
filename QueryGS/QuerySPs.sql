use GSDB

--ESTADO SOCIOS
-- Procedimiento almacenado para actualizar el estado de los socios
/*CREATE PROCEDURE sp_ActualizarEstadoSocios
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
*/
CREATE PROCEDURE sp_ActualizarEstadoSocios
AS
BEGIN
    UPDATE Socios
    SET estado = CASE
                    WHEN EXISTS (SELECT 1 FROM Pagos WHERE Pagos.cod_socio = Socios.cod_socio AND Pagos.fecha > DATEADD(DAY, 30, GETDATE()))
                    THEN 'DEUDOR'
                    WHEN NOT EXISTS (SELECT 1 FROM Pagos WHERE Pagos.cod_socio = Socios.cod_socio)
                    THEN 'DEUDOR'
                    WHEN DATEDIFF(DAY, (SELECT MAX(fecha) FROM Pagos WHERE Pagos.cod_socio = Socios.cod_socio), GETDATE()) > 60
                    THEN 'BAJA'
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

--REPORTE SOCIOS
drop PROCEDURE sp_MostrarInfoSocios

CREATE PROCEDURE sp_MostrarInfoSocios
AS
BEGIN
    SELECT S.tipo_nro_doc AS 'DNI',
           S.apellido_soc AS 'Apellido',
           S.nombre_soc AS 'Nombre',
           S.estado AS 'Estado',
           COUNT(I.cod_ins) AS 'Cantidad de Actividades Inscritas',
           STUFF((SELECT ', ' + A.nombre_act
                  FROM Inscripciones I2
                  INNER JOIN Actividades A ON I2.cod_act = A.cod_act
                  WHERE I2.cod_socio = S.cod_socio
                  FOR XML PATH('')), 1, 2, '') AS 'Actividades Inscritas'
    FROM Socios S
    LEFT JOIN Inscripciones I ON S.cod_socio = I.cod_socio
    WHERE S.estado IN ('ACTIVO', 'DEUDOR')
    GROUP BY S.cod_socio, S.tipo_nro_doc, S.apellido_soc, S.nombre_soc, S.estado
END;

EXEC sp_MostrarInfoSocios

--REPORTE ACTIVIDADES
CREATE PROCEDURE sp_MostrarInfoActividades
AS
BEGIN
    SELECT A.nombre_act AS 'Nombre Actividad',
           A.hora AS 'Hora',
           S.nombre_salon AS 'Salón',
           CONCAT(P.apellido_profe, ', ', P.nombre_profe) AS 'Profesor',
           A.cant_ins AS 'Cantidad de Inscriptos'
    FROM Actividades A
    INNER JOIN Salones S ON A.cod_salon = S.cod_salon
    INNER JOIN Profesores P ON A.cod_profe = P.cod_profe
END;

exec sp_MostrarInfoActividades