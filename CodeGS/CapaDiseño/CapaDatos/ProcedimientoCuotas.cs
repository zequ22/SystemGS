using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoCuotas
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
            cmd.CommandText = "sp_MostrarCuotas";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        //Alta
        public void Insert(int Cuota, string Mes, string Anio, int Precio)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AgregarCuota";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_cuota", Cuota);
            cmd.Parameters.AddWithValue("@mes_cuota", Mes);
            cmd.Parameters.AddWithValue("@anio_cuota", Anio);
            cmd.Parameters.AddWithValue("@precio_cuota", Precio);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Cuota, string Mes, string Anio, int Precio)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarCuota";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_cuota", Cuota);
            cmd.Parameters.AddWithValue("@mes_cuota", Mes);
            cmd.Parameters.AddWithValue("@anio_cuota", Anio);
            cmd.Parameters.AddWithValue("@precio_cuota", Precio);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Baja
        public void Delete(int Cuota)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaCuota";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_cuota", Cuota);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
