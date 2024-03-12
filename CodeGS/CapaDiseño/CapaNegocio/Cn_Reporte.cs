using System;
using System.Collections.Generic;
using CapaDatos;

namespace CapaNegocio
{
    public class Cn_Reporte
    {
        private Cd_Reporte _cdReporte;

        public Cn_Reporte()
        {
            _cdReporte = new Cd_Reporte();
        }

        public List<ReporteSocios> ListarSocios()
        {
            try
            {
                return _cdReporte.Listar();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return new List<ReporteSocios>(); // O devuelve null, lanza excepción, etc.
            }
        }

        public List<ReporteActividades> ListarActividades()
        {
            try
            {
                return _cdReporte.ListarActividades();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return new List<ReporteActividades>(); // O devuelve null, lanza excepción, etc.
            }
        }

    }
}
