using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class Cd_Reporte
    {
        public List<ReporteSocios> Listar()
        {
            List<ReporteSocios> lista = new List<ReporteSocios>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_MostrarInfoSocios", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteSocios()
                            {
                                DNI = dr["DNI"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                CantidadActividadesInscriptas = Convert.ToInt32(dr["Cantidad de Actividades Inscriptas"]),
                                ActividadesInscriptas = dr["Actividades Inscriptas"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                }
            }
            return lista;
        }

        public List<ReporteActividades> ListarActividades()
        {
            List<ReporteActividades> lista = new List<ReporteActividades>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_MostrarInfoActividades", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteActividades()
                            {
                                NombreActividad = dr["Nombre Actividad"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                Salon = dr["Salón"].ToString(),
                                Profesor = dr["Profesor"].ToString(),
                                CantidadInscriptos = Convert.ToInt32(dr["Cantidad de Inscriptos"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                }
            }
            return lista;
        }

    }
}