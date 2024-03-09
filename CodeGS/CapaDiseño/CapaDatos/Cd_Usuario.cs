using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace CapaDatos
{
    public class Cd_Usuario
    {
        public List<Usuario> Listar() { 
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select usuario_id, tipo_nro_doc, nombre_usuario, apellido_usuario, clave, estado from USUARIO";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                usuario_id = Convert.ToInt32(dr["usuario_id"]),
                                tipo_nro_doc = dr["tipo_nro_doc"].ToString(),
                                nombre_usuario = dr["nombre_usuario"].ToString(),
                                apellido_usuario = dr["apellido_usuario"].ToString(),
                                clave = dr["clave"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"])
                            });
                        }
                    }
                }
                catch(Exception ex){
                    lista = new List<Usuario>();
                }
            } return lista;        
        } 
    }
}
