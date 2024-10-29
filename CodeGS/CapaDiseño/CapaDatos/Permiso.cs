using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Permiso
    {
        public int permiso_id { get; set; }
        public Rol oRol { get; set; }
        public string nombre_menu { get; set; }
        public string permiso_fechaAlta { get; set; }
    }
}