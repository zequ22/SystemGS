using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ctrSocios
    {
        //Nueva instancia
        private ProcedimientoSocios procedureSoc = new ProcedimientoSocios();

        //Controladora Socios
        public DataTable mostrarSocios()
        {
            DataTable table = new DataTable();
            table = procedureSoc.mostrar();
            return table;
        }
        public void insertSocio(string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Estado)
        {
            procedureSoc.Insert(TipoDni, Nombre, Apellido, Nacimiento, Tel, Estado);
        }
        public void updateSocio(int Id, string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Estado)
        {
            procedureSoc.Update(Convert.ToInt32(Id), TipoDni, Nombre, Apellido, Nacimiento, Tel, Estado);
        }
        public void deleteSocio(int Id)
        {
            procedureSoc.Delete(Convert.ToInt32(Id));
        }
    }
}
