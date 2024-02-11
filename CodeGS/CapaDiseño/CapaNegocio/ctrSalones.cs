﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ctrSalones
    {
        //Nueva instancia
        private ProcedimientoSalones procedureSal = new ProcedimientoSalones();

        //Controladora Profesores
        public DataTable mostrarSalones()
        {
            DataTable table = new DataTable();
            table = procedureSal.mostrar();
            return table;
        }
        public void insertProfe(string Nombre, int Capacidad, string Descripcion)
        {
            procedureSal.Insert(Nombre, Capacidad, Descripcion);
        }
        public void updateProfe(int Id, string Nombre, int Capacidad, string Descripcion)
        {
            procedureSal.Update(Convert.ToInt32(Id), Nombre, Capacidad, Descripcion);
        }
        public void deleteProfe(int Id)
        {
            procedureSal.Delete(Convert.ToInt32(Id));
        }
    }
}
