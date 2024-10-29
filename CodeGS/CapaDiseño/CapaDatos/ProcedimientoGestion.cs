using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoGestion
    {
        //Creacion de instancia
        private CapaDatos conexion = new CapaDatos();

        SqlDataReader leer;
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable llenar_roles()
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "SELECT rol_id, rol_descripcion FROM ROL WHERE rol_descripcion IN ('EMPLEADO', 'PROFESOR')";
            cmd.CommandType = CommandType.Text;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }
        public DataTable llenar_menues()
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "SELECT permiso_id, NOMBRE_MENU FROM PERMISO";
            cmd.CommandType = CommandType.Text;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        public bool AsignarMenuARol(int rol_id, string nombre_menu, out string mensaje)
        {
            SqlCommand cmd = new SqlCommand("Sp_AsignarMenuARol", conexion.Abrir());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rol_id", rol_id);
            cmd.Parameters.AddWithValue("@nombre_menu", nombre_menu);

            SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output };
            SqlParameter mensajeOut = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(respuesta);
            cmd.Parameters.Add(mensajeOut);

            cmd.ExecuteNonQuery();
            mensaje = mensajeOut.Value.ToString();
            conexion.Cerrar();
            return (bool)respuesta.Value;
        }

        public bool QuitarMenuDeRol(int rol_id, string nombre_menu, out string mensaje)
        {
            SqlCommand cmd = new SqlCommand("Sp_QuitarMenuDeRol", conexion.Abrir());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rol_id", rol_id);
            cmd.Parameters.AddWithValue("@nombre_menu", nombre_menu);

            SqlParameter respuesta = new SqlParameter("@Respuesta", SqlDbType.Bit) { Direction = ParameterDirection.Output };
            SqlParameter mensajeOut = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(respuesta);
            cmd.Parameters.Add(mensajeOut);

            cmd.ExecuteNonQuery();
            mensaje = mensajeOut.Value.ToString();
            conexion.Cerrar();
            return (bool)respuesta.Value;
        }

    }
}
