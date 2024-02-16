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
    public partial class formSalones : Form
    {
        //Nueva instancia
        ProcedimientoSalones prS = new ProcedimientoSalones();
        private string id = null;
        private bool editar = false;

        public formSalones()
        {
            InitializeComponent();
        }

        private void formSalones_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        public void MostrarDatos()
        {
            ProcedimientoSalones obj = new ProcedimientoSalones();
            dgvSalones.DataSource = obj.mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    prS.Insert(txtNombre.Text, Convert.ToInt32(txtCapacidad.Text), txtDescripcion.Text);
                    MessageBox.Show("Se agrego Salon con exito!");
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
                    prS.Update(Convert.ToInt32(id), txtNombre.Text, Convert.ToInt32(txtCapacidad.Text), txtDescripcion.Text);
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
            if (dgvSalones.SelectedRows.Count > 0)
            {
                editar = true;
                id = dgvSalones.CurrentRow.Cells["cod_salon"].Value.ToString();
                txtNombre.Text = dgvSalones.CurrentRow.Cells["nombre_salon"].Value.ToString();
                txtCapacidad.Text = dgvSalones.CurrentRow.Cells["capacidad"].Value.ToString();
                txtDescripcion.Text = dgvSalones.CurrentRow.Cells["descripcion"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSalones.SelectedRows.Count > 0)
            {
                id = dgvSalones.CurrentRow.Cells["cod_salon"].Value.ToString();
                prS.Delete(Convert.ToInt32(id));
                MessageBox.Show("El Salon se ha eliminado correctamente!");
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Error al eliminar los datos!");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtCapacidad.Clear();
            txtDescripcion.Clear();
            txtCod.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
