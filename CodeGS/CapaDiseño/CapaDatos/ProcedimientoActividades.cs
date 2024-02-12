using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoActividades
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
            cmd.CommandText = "sp_MostrarAct";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        public DataTable llenar_profes()
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "SELECT cod_profe, nombre_profe FROM Profesores";
            cmd.CommandType = CommandType.Text;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        public DataTable llenar_salones()
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
        public void Insert(string Nombre, int Hora, int Profe, int Salon)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AgregarAct";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre_act", Nombre);
            cmd.Parameters.AddWithValue("@hora", Hora);
            cmd.Parameters.AddWithValue("@cod_profe", Profe);
            cmd.Parameters.AddWithValue("@cod_salon", Salon);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Id, string Nombre, int Hora, int Profe, int Salon)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarAct";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_act", Id);
            cmd.Parameters.AddWithValue("@nombre_act", Nombre);
            cmd.Parameters.AddWithValue("@hora", Hora);
            cmd.Parameters.AddWithValue("@cod_profe", Profe);
            cmd.Parameters.AddWithValue("@cod_salon", Salon);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Baja
        public void Delete(int Id)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaAct";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_act", Id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
