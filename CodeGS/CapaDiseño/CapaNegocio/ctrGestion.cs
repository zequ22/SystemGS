using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class ctrGestion
    {
        //Nueva instancia
        private ProcedimientoGestion procedureGes = new ProcedimientoGestion();

        public DataTable listar_roles()
        {
            DataTable table = new DataTable();
            table = procedureGes.llenar_roles();
            return table;
        }

        public DataTable listar_menues()
        {
            DataTable table = new DataTable();
            table = procedureGes.llenar_menues();
            return table;
        }

        public bool AsignarMenuARol(int rol_id, string nombre_menu, out string mensaje)
        {
            return procedureGes.AsignarMenuARol(rol_id, nombre_menu, out mensaje);
        }

        public bool QuitarMenuDeRol(int rol_id, string nombre_menu, out string mensaje)
        {
            return procedureGes.QuitarMenuDeRol(rol_id, nombre_menu, out mensaje);
        }

    }
}
