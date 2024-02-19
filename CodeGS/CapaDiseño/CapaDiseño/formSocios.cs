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
    public partial class formSocios : Form
    {
        // Declarar un temporizador
        private System.Windows.Forms.Timer timer;

        //Nueva instancia
        ProcedimientoSocios prS = new ProcedimientoSocios();
        private string id = null;
        private bool editar = false;

        public formSocios()
        {
            InitializeComponent();

            // Configurar el temporizador para que se ejecute cada hora
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000;
            timer.Tick += timerEstado_Tick;
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        public void MostrarDatos()
        {
            ProcedimientoSocios obj = new ProcedimientoSocios();
            dgvSocios.DataSource = obj.mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(editar == false)
            {
                try
                {
                    prS.Insert(txtDoc.Text, txtNombre.Text, txtApellido.Text, Convert.ToDateTime(txtNac.Text), txtTel.Text, txtEstado.Text);
                    MessageBox.Show("Se agrego Socio con exito!");
                    MostrarDatos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al ingresar datos!"+ex);
                }
            }
            if(editar == true)
            {
                try
                {
                    prS.Update(Convert.ToInt32(id), txtDoc.Text, txtNombre.Text, txtApellido.Text, Convert.ToDateTime(txtNac.Text), txtTel.Text, txtEstado.Text);
                    MessageBox.Show("Datos modificados con exito!");
                    MostrarDatos();
                    editar = false;
                }catch(Exception ex)
                {
                    MessageBox.Show("Error al ingresar datos!" + ex);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvSocios.SelectedRows.Count > 0)
            {
                editar = true;
                id = dgvSocios.CurrentRow.Cells["cod_socio"].Value.ToString();
                txtDoc.Text = dgvSocios.CurrentRow.Cells["tipo_nro_doc"].Value.ToString();
                txtNombre.Text = dgvSocios.CurrentRow.Cells["nombre_soc"].Value.ToString();
                txtApellido.Text = dgvSocios.CurrentRow.Cells["apellido_soc"].Value.ToString();
                txtNac.Text = dgvSocios.CurrentRow.Cells["nacimiento"].Value.ToString();
                txtTel.Text = dgvSocios.CurrentRow.Cells["tel"].Value.ToString();
                txtEstado.Text = dgvSocios.CurrentRow.Cells["estado"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvSocios.SelectedRows.Count > 0)
            {
                id = dgvSocios.CurrentRow.Cells["cod_socio"].Value.ToString();
                prS.Delete(Convert.ToInt32(id));
                MessageBox.Show("El socio se ha eliminado correctamente!");
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
            txtEstado.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerEstado_Tick(object sender, EventArgs e)
        {
            try
            {
                ctrSocios controladorSocios = new ctrSocios();

                // Llamar al método de la capa de negocio para actualizar el estado de los socios
                controladorSocios.ActualizarEstadoSocios();
                lblEstado.Text = "OK";
                MostrarDatos();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show("Error al actualizar el estado de los socios: " + ex.Message);
            }
        }
    }
}
