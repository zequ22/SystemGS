using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ctrProfesores
    {
        //Nueva instancia
        private ProcedimientoProfesores procedurePro = new ProcedimientoProfesores();

        //Controladora Profesores
        public DataTable mostrarProfesores()
        {
            DataTable table = new DataTable();
            table = procedurePro.mostrar();
            return table;
        }
        public void insertProfe(string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Cargo)
        {
            procedurePro.Insert(TipoDni, Nombre, Apellido, Nacimiento, Tel, Cargo);
        }
        public void updateProfe(int Id, string TipoDni, string Nombre, string Apellido, DateTime Nacimiento, string Tel, string Cargo)
        {
            procedurePro.Update(Convert.ToInt32(Id), TipoDni, Nombre, Apellido, Nacimiento, Tel, Cargo);
        }
        public void deleteProfe(int Id)
        {
            procedurePro.Delete(Convert.ToInt32(Id));
        }
    }
}
