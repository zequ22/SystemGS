using CapaDatos;
using CapaNegocio;
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
    public partial class formCuotas : Form
    {
        //Nueva instancia
        ProcedimientoCuotas prC = new ProcedimientoCuotas();
        private string id = null;
        private bool editar = false;

        public formCuotas()
        {
            InitializeComponent();
        }

        private void formCuotas_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        public void MostrarDatos()
        {
            ProcedimientoCuotas obj = new ProcedimientoCuotas();
            dgvCuotas.DataSource = obj.mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    prC.Insert(Convert.ToInt32(txtCod.Text), txtMes.Text, txtAnio.Text, Convert.ToInt32(txtPrecio.Text));
                    MessageBox.Show("Se agrego Cuota con exito!");
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
                    prC.Update(Convert.ToInt32(id), txtMes.Text, txtAnio.Text, Convert.ToInt32(txtPrecio.Text));
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
            if (dgvCuotas.SelectedRows.Count > 0)
            {
                editar = true;
                id = dgvCuotas.CurrentRow.Cells["CUOTA"].Value.ToString();
                txtMes.Text = dgvCuotas.CurrentRow.Cells["MES"].Value.ToString();
                txtAnio.Text = dgvCuotas.CurrentRow.Cells["ANIO"].Value.ToString();
                txtPrecio.Text = dgvCuotas.CurrentRow.Cells["PRECIO"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCuotas.SelectedRows.Count > 0)
            {
                id = dgvCuotas.CurrentRow.Cells["CUOTA"].Value.ToString();
                prC.Delete(Convert.ToInt32(id));
                MessageBox.Show("La Cuota se ha eliminado correctamente!");
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCod.Clear();
            txtMes.Clear();
            txtAnio.Clear();
            txtPrecio.Clear();
        }
    }
}
