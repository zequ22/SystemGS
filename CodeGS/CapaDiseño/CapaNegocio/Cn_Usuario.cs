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
    }
}
