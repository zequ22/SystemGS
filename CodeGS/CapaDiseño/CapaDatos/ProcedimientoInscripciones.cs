using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoInscripciones
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
            cmd.CommandText = "sp_MostrarIns";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        public DataTable llenar_socios()
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "SELECT cod_socio, tipo_nro_doc FROM Socios";
            cmd.CommandType = CommandType.Text;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        public DataTable llenar_actividades()
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "SELECT cod_act, nombre_act FROM Actividades";
            cmd.CommandType = CommandType.Text;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        //Alta
        public void Insert(int Socio, int Act)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AgregarIns";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_socio", Socio);
            cmd.Parameters.AddWithValue("@cod_act", Act);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Id, int Socio, int Act)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarIns";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_ins", Id);
            cmd.Parameters.AddWithValue("@cod_socio", Socio);
            cmd.Parameters.AddWithValue("@cod_act", Act);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Baja
        public void Delete(int Id)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaIns";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_ins", Id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
