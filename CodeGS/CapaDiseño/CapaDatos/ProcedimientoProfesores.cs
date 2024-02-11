using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoProfesores
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
            cmd.CommandText = "sp_MostrarProfesores";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        //Alta
        public void Insert(string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Cargo)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AgregarProfesor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo_nro_doc", TipoDni);
            cmd.Parameters.AddWithValue("@nombre_profe", Nombre);
            cmd.Parameters.AddWithValue("@apellido_profe", Apellido);
            cmd.Parameters.AddWithValue("@nacimiento", Nacimiento);
            cmd.Parameters.AddWithValue("@tel", Tel);
            cmd.Parameters.AddWithValue("@cargo", Cargo);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Id, string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Cargo)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarProfesor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_profe", Id);
            cmd.Parameters.AddWithValue("@tipo_nro_doc", TipoDni);
            cmd.Parameters.AddWithValue("@nombre_profe", Nombre);
            cmd.Parameters.AddWithValue("@apellido_profe", Apellido);
            cmd.Parameters.AddWithValue("@nacimiento", Nacimiento);
            cmd.Parameters.AddWithValue("@tel", Tel);
            cmd.Parameters.AddWithValue("@cargo", Cargo);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Baja
        public void Delete(int Id)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaProfesor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_profe", Id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
