using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using System.Security.Claims;
using System.Runtime.Serialization;

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
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.usuario_id, u.tipo_nro_doc, u.nombre_usuario, u.apellido_usuario, u.clave, u.estado, r.rol_id, r.rol_descripcion from USUARIO u");
                    query.AppendLine("inner join rol r on r.rol_id = u.rol_id");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
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
                                estado = Convert.ToBoolean(dr["estado"]),
                                oRol = new Rol() { rol_id = Convert.ToInt32(dr["rol_id"]), 
                                rol_descripcion = dr["rol_descripcion"].ToString() }
                            });
                        }
                    }
                }
                catch(Exception ex){
                    lista = new List<Usuario>();
                }
            } return lista;        
        } 

        public int Registrar(Usuario obj ,out string Mensaje)
        {
            int idUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {                  

                    SqlCommand cmd = new SqlCommand("Sp_RegistrarUsuario".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("tipo_nro_doc",obj.tipo_nro_doc);
                    cmd.Parameters.AddWithValue("nombre_usuario", obj.nombre_usuario);
                    cmd.Parameters.AddWithValue("apellido_usuario", obj.apellido_usuario);
                    cmd.Parameters.AddWithValue("clave", obj.clave);
                    cmd.Parameters.AddWithValue("rol_id", obj.oRol.rol_id);
                    cmd.Parameters.AddWithValue("estado", obj.estado);
                    cmd.Parameters.Add("IdUsuarioResultado",SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idUsuarioGenerado = 0;
                Mensaje= ex.Message;
            }

            return idUsuarioGenerado;
        }


        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("Sp_EditarUsuario".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("usuario_id", obj.usuario_id);
                    cmd.Parameters.AddWithValue("tipo_nro_doc", obj.tipo_nro_doc);
                    cmd.Parameters.AddWithValue("nombre_usuario", obj.nombre_usuario);
                    cmd.Parameters.AddWithValue("apellido_usuario", obj.apellido_usuario);
                    cmd.Parameters.AddWithValue("clave", obj.clave);
                    cmd.Parameters.AddWithValue("rol_id", obj.oRol.rol_id);
                    cmd.Parameters.AddWithValue("estado", obj.estado);
                    cmd.Parameters.Add("Resupuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resupuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("Sp_EliminarUsuario".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("usuario_id", obj.usuario_id);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

    }
}
