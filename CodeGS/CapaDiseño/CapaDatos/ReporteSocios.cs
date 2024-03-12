using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ReporteSocios
    {
        public string DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int CantidadActividadesInscriptas { get; set; }
        public string ActividadesInscriptas { get; set; }
    }
}
