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
using System.Data;
using System.Data.SqlClient;

namespace CapaDiseño
{
    public partial class formGestion : Form
    {
        //Nueva instancia
        ProcedimientoGestion prG = new ProcedimientoGestion();
        ctrGestion gestion = new ctrGestion();


        public formGestion()
        {
            InitializeComponent();
        }

        private void cbReportesAlta_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void formGestion_Load(object sender, EventArgs e)
        {
            MostrarRoles();
            MostrarMenues();
        }

        public void MostrarRoles()
        {
            ProcedimientoGestion obj = new ProcedimientoGestion();
            comboRol.DataSource = obj.llenar_roles();
            comboRol.DisplayMember = "rol_descripcion";
            comboRol.ValueMember = "rol_id";
        }
        public void MostrarMenues()
        {
            ProcedimientoGestion obj = new ProcedimientoGestion();
            comboMenu.DataSource = obj.llenar_menues();
            comboMenu.DisplayMember = "nombre_menu";
            comboMenu.ValueMember = "permiso_id";
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int rol_id = (int)comboRol.SelectedValue;
            string nombre_menu = comboMenu.Text;

            string mensaje;
            bool resultado = gestion.AsignarMenuARol(rol_id, nombre_menu, out mensaje);

            if (resultado)
            {
                MessageBox.Show("Menú asignado correctamente: " + mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al asignar el menú: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int rol_id = (int)comboRol.SelectedValue;
            string nombre_menu = comboMenu.Text;

            string mensaje;
            bool resultado = gestion.QuitarMenuDeRol(rol_id, nombre_menu, out mensaje);

            if (resultado)
            {
                MessageBox.Show("Menú quitado correctamente: " + mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al quitar el menú: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}