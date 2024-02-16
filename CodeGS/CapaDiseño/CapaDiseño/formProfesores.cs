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
    public partial class formProfesores : Form
    {
        //Nueva instancia
        ProcedimientoProfesores prP = new ProcedimientoProfesores();
        private string id = null;
        private bool editar = false;

        public formProfesores()
        {
            InitializeComponent();
        }

        private void formProfesores_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        public void MostrarDatos()
        {
            ProcedimientoProfesores obj = new ProcedimientoProfesores();
            dgvProfesores.DataSource = obj.mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    prP.Insert(txtDoc.Text, txtNombre.Text, txtApellido.Text, Convert.ToDateTime(txtNac.Text), txtTel.Text, txtCargo.Text);
                    MessageBox.Show("Se agrego Profesor con exito!");
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
                    prP.Update(Convert.ToInt32(id), txtDoc.Text, txtNombre.Text, txtApellido.Text, Convert.ToDateTime(txtNac.Text), txtTel.Text, txtCargo.Text);
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
            if (dgvProfesores.SelectedRows.Count > 0)
            {
                editar = true;
                id = dgvProfesores.CurrentRow.Cells["cod_profe"].Value.ToString();
                txtDoc.Text = dgvProfesores.CurrentRow.Cells["tipo_nro_doc"].Value.ToString();
                txtNombre.Text = dgvProfesores.CurrentRow.Cells["nombre_profe"].Value.ToString();
                txtApellido.Text = dgvProfesores.CurrentRow.Cells["apellido_profe"].Value.ToString();
                txtNac.Text = dgvProfesores.CurrentRow.Cells["nacimiento"].Value.ToString();
                txtTel.Text = dgvProfesores.CurrentRow.Cells["tel"].Value.ToString();
                txtCargo.Text = dgvProfesores.CurrentRow.Cells["cargo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProfesores.SelectedRows.Count > 0)
            {
                id = dgvProfesores.CurrentRow.Cells["cod_profe"].Value.ToString();
                prP.Delete(Convert.ToInt32(id));
                MessageBox.Show("El Profesor se ha eliminado correctamente!");
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Error al eliminar los datos!");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCod.Clear();
            txtDoc.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtNac.Clear();
            txtTel.Clear();
            txtCargo.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
