using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ctrCuotas
    {
        //Nueva instancia
        private ProcedimientoCuotas procedureCuo = new ProcedimientoCuotas();

        //Controladora
        public DataTable mostrarCuotas()
        {
            DataTable table = new DataTable();
            table = procedureCuo.mostrar();
            return table;
        }
        public void insertCuota(int Cuota, string Mes, string Anio, int Precio)
        {
            procedureCuo.Insert(Convert.ToInt32(Cuota), Mes, Anio, Convert.ToInt32(Precio));
        }
        public void updateCuota(int Cuota, string Mes, string Anio, int Precio)
        {
            procedureCuo.Update(Convert.ToInt32(Cuota), Mes, Anio, Convert.ToInt32(Precio));
        }
        public void deleteCuota(int Cuota)
        {
            procedureCuo.Delete(Convert.ToInt32(Cuota));
        }
    }
}
