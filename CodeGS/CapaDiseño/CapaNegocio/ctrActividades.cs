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

        public void insertAct(string Nombre, TimeSpan Hora, int Profe, int Salon, string Estado)
        {
            procedureAct.Insert(Nombre, Hora, Convert.ToInt32(Profe), Convert.ToInt32(Salon), Estado);
        }
        public void updateAct(int Id, string Nombre, TimeSpan Hora, int Profe, int Salon, int Cantidad, string Estado)
        {
            procedureAct.Update(Convert.ToInt32(Id), Nombre, Hora, Convert.ToInt32(Profe), Convert.ToInt32(Salon), Convert.ToInt32(Cantidad), Estado);
        }
        public void deleteAct(int Id)
        {
            procedureAct.Delete(Convert.ToInt32(Id));
        }

        public void ActualizarEstadoAct()
        {
            // Llamar al procedimiento almacenado de la capa de datos para actualizar el estado de los socios
            procedureAct.ActualizarEstadoAct();
        }
    }
}
