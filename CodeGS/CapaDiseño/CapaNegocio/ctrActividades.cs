using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ctrActividades
    {
        //Nueva instancia
        private ProcedimientoActividades procedureAct = new ProcedimientoActividades();

        //Controladora Profesores
        public DataTable mostrarAct()
        {
            DataTable table = new DataTable();
            table = procedureAct.mostrar();
            return table;
        }

        public DataTable listar_profes()
        {
            DataTable table = new DataTable();
            table = procedureAct.llenar_profes();
            return table;
        }

        public DataTable listar_salones()
        {
            DataTable table = new DataTable();
            table = procedureAct.llenar_salones();
            return table;
        }

        public void insertAct(string Nombre, int Hora, int Profe, int Salon)
        {
            procedureAct.Insert(Nombre, Hora, Convert.ToInt32(Profe), Convert.ToInt32(Salon));
        }
        public void updateAct(int Id, string Nombre, int Hora, int Profe, int Salon)
        {
            procedureAct.Update(Convert.ToInt32(Id), Nombre, Convert.ToInt32(Hora), Convert.ToInt32(Profe), Convert.ToInt32(Salon));
        }
        public void deleteAct(int Id)
        {
            procedureAct.Delete(Convert.ToInt32(Id));
        }
    }
}
