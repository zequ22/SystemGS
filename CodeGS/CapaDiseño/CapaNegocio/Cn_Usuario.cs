using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Cn_Usuario
    {
        private Cd_Usuario objcd_usuario = new Cd_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }

        public int Registrar(Usuario obj,out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.tipo_nro_doc == "")
            {
                Mensaje += "Documento requerido\n";
            }

            if (obj.nombre_usuario == "")
            {
                Mensaje += "Nombre requerido\n";
            }

            if (obj.apellido_usuario == "")
            {
                Mensaje += "Apellido requerido\n";
            }

            if (obj.clave == "")
            {
                Mensaje += "Contraseña requerida\n";
            }

            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }            
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.tipo_nro_doc == "")
            {
                Mensaje += "Documento requerido\n";
            }

            if (obj.nombre_usuario == "")
            {
                Mensaje += "Nombre requerido\n";
            }

            if (obj.apellido_usuario == "")
            {
                Mensaje += "Apellido requerido\n";
            }

            if (obj.clave == "")
            {
                Mensaje += "Contraseña requerida\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
    }
}
