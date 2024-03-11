using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Usuario
    {
        public int usuario_id { get; set; }
        public string tipo_nro_doc { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string clave { get; set; }
        public Rol oRol { get; set; }
        public bool estado { get; set; }
        public string usuario_fechaAlta { get; set; }
    }
}
