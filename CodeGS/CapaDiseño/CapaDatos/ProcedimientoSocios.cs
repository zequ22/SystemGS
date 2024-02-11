using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoSocios
    {
        //Creacion de instancia
        private CapaDatos conexion = new CapaDatos();

        SqlDataReader leer;
        DataTable table = new DataTable();
        SqlCommand cmd = new SqlCommand();

        //Mostrar datos
        public DataTable mostrar()
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_MostrarSocios";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        //Alta
        public void Insert(string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Estado)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AgregarSocio";
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo_nro_doc", TipoDni);
            cmd.Parameters.AddWithValue("@nombre_soc", Nombre);
            cmd.Parameters.AddWithValue("@apellido_soc", Apellido);
            cmd.Parameters.AddWithValue("@nacimiento", Nacimiento);
            cmd.Parameters.AddWithValue("@tel", Tel);
            cmd.Parameters.AddWithValue("@estado", Estado);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Id, string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Estado)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarSocio";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_socio", Id);
            cmd.Parameters.AddWithValue("@tipo_nro_doc", TipoDni);
            cmd.Parameters.AddWithValue("@nombre_soc", Nombre);
            cmd.Parameters.AddWithValue("@apellido_soc", Apellido);
            cmd.Parameters.AddWithValue("@nacimiento", Nacimiento);
            cmd.Parameters.AddWithValue("@tel", Tel);
            cmd.Parameters.AddWithValue("@estado", Estado);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Baja
        public void Delete(int Id)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaSocio";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_socio", Id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
