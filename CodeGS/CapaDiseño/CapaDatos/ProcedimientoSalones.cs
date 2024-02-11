using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoSalones
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
            cmd.CommandText = "sp_MostrarSalones";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        //Alta
        public void Insert(string Nombre, int Capacidad, string Descripcion)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AgregarSalon";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre_salon", Nombre);
            cmd.Parameters.AddWithValue("@capacidad", Capacidad);
            cmd.Parameters.AddWithValue("@descripcion", Descripcion);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Id, string Nombre, int Capacidad, string Descripcion)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarSalon";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_salon", Id);
            cmd.Parameters.AddWithValue("@nombre_salon", Nombre);
            cmd.Parameters.AddWithValue("@capacidad", Capacidad);
            cmd.Parameters.AddWithValue("@descripcion", Descripcion);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Baja
        public void Delete(int Id)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaSalon";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_salon", Id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
