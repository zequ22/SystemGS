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
    public partial class formInscripciones : Form
    {
        //Nueva instancia
        ProcedimientoInscripciones prI = new ProcedimientoInscripciones();
        private string id = null;
        private bool editar = false;

        public formInscripciones()
        {
            InitializeComponent();
        }

        private void formInscripciones_Load(object sender, EventArgs e)
        {
            MostrarDatos();
            MostrarSocios();
            MostrarActividades();
        }

        public void MostrarSocios()
        {
            ProcedimientoInscripciones obj = new ProcedimientoInscripciones();
            cmbSocio.DataSource = obj.llenar_socios();
            cmbSocio.DisplayMember = "tipo_nro_doc";
            cmbSocio.ValueMember = "cod_socio";
        }

        public void MostrarActividades()
        {
            ProcedimientoInscripciones obj = new ProcedimientoInscripciones();
            cmbAct.DataSource = obj.llenar_actividades();
            cmbAct.DisplayMember = "nombre_act";
            cmbAct.ValueMember = "cod_act";
        }

        public void MostrarDatos()
        {
            ProcedimientoInscripciones obj = new ProcedimientoInscripciones();
            dgvIns.DataSource = obj.mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    prI.Insert(Convert.ToInt32(cmbSocio.SelectedValue), Convert.ToInt32(cmbAct.SelectedValue));
                    MessageBox.Show("Se agrego Inscripcion con exito!");
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
                    prI.Update(Convert.ToInt32(id), Convert.ToInt32(cmbSocio.SelectedValue), Convert.ToInt32(cmbAct.SelectedValue));
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
            if (dgvIns.SelectedRows.Count > 0)
            {
                editar = true;
                id = dgvIns.CurrentRow.Cells["cod_ins"].Value.ToString();
                cmbSocio.SelectedValue = dgvIns.CurrentRow.Cells["cod_socio"].Value.ToString();
                cmbAct.SelectedValue = dgvIns.CurrentRow.Cells["cod_act"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvIns.SelectedRows.Count > 0)
            {
                id = dgvIns.CurrentRow.Cells["cod_ins"].Value.ToString();
                prI.Delete(Convert.ToInt32(id));
                MessageBox.Show("La Inscripcion se ha eliminado correctamente!");
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
