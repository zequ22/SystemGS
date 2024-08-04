using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ProcedimientoPagos
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
            cmd.CommandText = "sp_MostrarPagos";
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

        public DataTable llenar_cuotas()
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "SELECT cod_cuota, mes_cuota, anio_cuota FROM Cuotas";
            cmd.CommandType = CommandType.Text;
            leer = cmd.ExecuteReader();
            table.Load(leer);
            conexion.Cerrar();
            return table;
        }

        //Alta
        public void Insert(int Socio, int Cuota, DateTime Fecha)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AltaPago";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_socio", Socio);
            cmd.Parameters.AddWithValue("@cod_cuota", Cuota);
            cmd.Parameters.AddWithValue("@fecha_pago", Fecha);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Id, int Socio, int Cuota, DateTime Fecha)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarPago";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_pago", Id);
            cmd.Parameters.AddWithValue("@cod_socio", Socio);
            cmd.Parameters.AddWithValue("@cod_cuota", Cuota);
            cmd.Parameters.AddWithValue("@fecha_pago", Fecha);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }


        //Baja
        public void Delete(int Id)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaPago";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_pago", Id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //FILTRO
        public DataTable FiltrarPagosPorDocumento(string tipoDocumento)
        {
            DataTable tablaFiltrada = new DataTable();
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_FiltrarPagosPorDocumento";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo_nro_doc", tipoDocumento);
            leer = cmd.ExecuteReader();
            tablaFiltrada.Load(leer);
            conexion.Cerrar();
            cmd.Parameters.Clear();
            return tablaFiltrada;
        }

    }
}
