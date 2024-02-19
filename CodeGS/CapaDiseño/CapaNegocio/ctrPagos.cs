using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ctrPagos
    {
        //Nueva instancia
        private ProcedimientoPagos procedurePag = new ProcedimientoPagos();

        //Controladora
        public DataTable mostrarPagos()
        {
            DataTable table = new DataTable();
            table = procedurePag.mostrar();
            return table;
        }
        public DataTable listar_socios()
        {
            DataTable table = new DataTable();
            table = procedurePag.llenar_socios();
            return table;
        }
        public void insertPago(int Socio, DateTime Fecha, int Precio, string Estado)
        {
            procedurePag.Insert(Convert.ToInt32(Socio), Fecha, Convert.ToInt32(Precio), Estado);
        }
        public void updatePago(int Id, int Socio, DateTime Fecha, int Precio, string Estado)
        {
            procedurePag.Update(Convert.ToInt32(Id), Convert.ToInt32(Socio), Fecha, Convert.ToInt32(Precio), Estado);
        }
        public void deletePago(int Id)
        {
            procedurePag.Delete(Convert.ToInt32(Id));
        }
    }
}
