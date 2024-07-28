using CapaDatos;
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
            MostrarSocios();
        }

        public void MostrarDatos()
        {
            ProcedimientoPagos obj = new ProcedimientoPagos();
            dgvPagos.DataSource = obj.mostrar();
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
                    prP.Insert(Convert.ToInt32(cmbSocios.SelectedValue), Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(txtPrecio.Text), txtEstado.Text);
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
                    prP.Update(Convert.ToInt32(id), Convert.ToInt32(cmbSocios.SelectedValue), Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(txtPrecio.Text), txtEstado.Text);
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
                txtFecha.Text = dgvPagos.CurrentRow.Cells["FECHA"].Value.ToString();
                txtPrecio.Text = dgvPagos.CurrentRow.Cells["PRECIO"].Value.ToString();
                txtEstado.Text = dgvPagos.CurrentRow.Cells["ESTADO"].Value.ToString();
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
    }
}
