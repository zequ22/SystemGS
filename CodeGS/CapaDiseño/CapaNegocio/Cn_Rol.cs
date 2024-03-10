using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Cn_Rol
    {
        private Cd_Rol objcd_rol = new Cd_Rol();

        public List<Rol> Listar()
        {
            return objcd_rol.Listar();
        }
    }
}
