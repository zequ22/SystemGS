using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CapaDatos
    {
        //Cadena de conexion
        private SqlConnection Conexion = new SqlConnection("Data Source=NMICHELETTI\\SQLEXPRESS;Initial Catalog=GSDB;Integrated Security=true");

        //Abrir conexion
        public SqlConnection Abrir()
        {
            if(Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }

        //Cerrar conexion
        public SqlConnection Cerrar()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }
    }
}
