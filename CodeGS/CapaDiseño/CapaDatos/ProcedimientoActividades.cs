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
        public void Insert(string Nombre, int Hora, int Profe, int Salon, string Estado)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_AgregarAct";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre_act", Nombre);
            cmd.Parameters.AddWithValue("@hora", Hora);
            cmd.Parameters.AddWithValue("@cod_profe", Profe);
            cmd.Parameters.AddWithValue("@cod_salon", Salon);
            // No es necesario pasar valores para estado y cant_ins ya que tienen valores predeterminados o son nulos
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Modificar
        public void Update(int Id, string Nombre, int Hora, int Profe, int Salon, int Cantidad, string Estado)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_ModificarAct";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_act", Id);
            cmd.Parameters.AddWithValue("@nombre_act", Nombre);
            cmd.Parameters.AddWithValue("@hora", Hora);
            cmd.Parameters.AddWithValue("@cod_profe", Profe);
            cmd.Parameters.AddWithValue("@cod_salon", Salon);
            cmd.Parameters.AddWithValue("@cant_ins", Cantidad); // Agregar parámetro para la cantidad de inscritos
            cmd.Parameters.AddWithValue("@estado", Estado); // Agregar parámetro para el estado
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        //Baja
        public void Delete(int Id)
        {
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "sp_BajaActividad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod_act", Id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public int ObtenerCantidadInscritos(int IdActividad)
        {
            int cantidadInscritos = 0;
            cmd.Connection = conexion.Abrir();
            cmd.CommandText = "SELECT COUNT(*) FROM Inscripciones WHERE cod_act = @cod_act";
            cmd.Parameters.AddWithValue("@cod_act", IdActividad);
            cantidadInscritos = (int)cmd.ExecuteScalar();
            conexion.Cerrar();
            return cantidadInscritos;
        }

        public void ActualizarEstadoAct()
        {
            try
            {
                // Establecer la conexión
                cmd.Connection = conexion.Abrir();

                // Ejecutar el procedimiento almacenado
                cmd.CommandText = "sp_ActualizarEstadoActividad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                throw new Exception("Error al actualizar el estado de las actividades: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                conexion.Cerrar();
            }
        }
    }
}
