﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDiseño
{
    public partial class formPagos : Form
    {
        //Nueva instancia
        ProcedimientoPagos prP = new ProcedimientoPagos();
        private string id = null;
        private bool editar = false;

        public formPagos()
        {
            InitializeComponent();
        }

        private void formPagos_Load(object sender, EventArgs e)
        {
            MostrarDatos();
            MostrarCuotas();
            MostrarSocios();
        }

        public void MostrarDatos()
        {
            ProcedimientoPagos obj = new ProcedimientoPagos();
            dgvPagos.DataSource = obj.mostrar();
        }
        public void MostrarCuotas()
        {
            ProcedimientoPagos obj = new ProcedimientoPagos();
            cmbCuota.DataSource = obj.llenar_cuotas();
            cmbCuota.DisplayMember = "mes_cuota";
            cmbCuota.ValueMember = "cod_cuota";
        }
        public void MostrarSocios()
        {
            ProcedimientoPagos obj = new ProcedimientoPagos();
            cmbSocios.DataSource = obj.llenar_socios();
            cmbSocios.DisplayMember = "tipo_nro_doc";
            cmbSocios.ValueMember = "cod_socio";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    prP.Insert(Convert.ToInt32(cmbSocios.SelectedValue), Convert.ToInt32(cmbCuota.SelectedValue), Convert.ToDateTime(txtFecha.Text));
                    MessageBox.Show("Se agrego Pago con exito!");
                    MostrarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ingresar datos!" + ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    prP.Update(Convert.ToInt32(id), Convert.ToInt32(cmbSocios.SelectedValue), Convert.ToInt32(cmbCuota.SelectedValue), Convert.ToDateTime(txtFecha.Text));
                    MessageBox.Show("Datos modificados con exito!");
                    MostrarDatos();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ingresar datos!" + ex);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count > 0)
            {
                editar = true;
                id = dgvPagos.CurrentRow.Cells["PAGO"].Value.ToString();
                cmbSocios.SelectedValue = dgvPagos.CurrentRow.Cells["SOCIO"].Value.ToString();
                txtFecha.Text = dgvPagos.CurrentRow.Cells["CUOTA"].Value.ToString();
                txtPrecio.Text = dgvPagos.CurrentRow.Cells["PRECIO"].Value.ToString();
                txtFecha.Text = dgvPagos.CurrentRow.Cells["FECHA"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count > 0)
            {
                id = dgvPagos.CurrentRow.Cells["PAGO"].Value.ToString();
                prP.Delete(Convert.ToInt32(id));
                MessageBox.Show("El Pago se ha eliminado correctamente!");
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Error al eliminar los datos!");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCuota_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCod.Clear();
            txtFecha.Clear();
            txtPrecio.Clear();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            if (cmbSocios.SelectedIndex != -1)
            {
                string tipoDocumento = cmbSocios.Text; // Obtener el tipo de documento seleccionado
                FiltrarPorDocumento(tipoDocumento);
            }
        }
        private void FiltrarPorDocumento(string tipoDocumento)
        {
            ProcedimientoPagos obj = new ProcedimientoPagos();
            DataTable tablaFiltrada = obj.FiltrarPagosPorDocumento(tipoDocumento);
            dgvPagos.DataSource = tablaFiltrada;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
