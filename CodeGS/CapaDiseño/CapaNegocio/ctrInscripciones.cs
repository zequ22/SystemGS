using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ctrInscripciones
    {
        //Nueva instancia
        private ProcedimientoInscripciones procedureIns = new ProcedimientoInscripciones();

        //Controladora Profesores
        public DataTable mostrarAct()
        {
            DataTable table = new DataTable();
            table = procedureIns.mostrar();
            return table;
        }

        public DataTable listar_socios()
        {
            DataTable table = new DataTable();
            table = procedureIns.llenar_socios();
            return table;
        }

        public DataTable listar_actividades()
        {
            DataTable table = new DataTable();
            table = procedureIns.llenar_actividades();
            return table;
        }

        public void insertAct(int Socio, int Act)
        {
            procedureIns.Insert(Convert.ToInt32(Socio), Convert.ToInt32(Act));
        }
        public void updateIns(int Id, int Socio, int Act)
        {
            procedureIns.Update(Convert.ToInt32(Id), Convert.ToInt32(Socio), Convert.ToInt32(Act));
        }
        public void deleteIns(int Id)
        {
            procedureIns.Delete(Convert.ToInt32(Id));
        }
    }
}
