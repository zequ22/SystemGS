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
    public partial class formActividades : Form
    {
        //Nueva instancia
        ProcedimientoActividades prA = new ProcedimientoActividades();
        private string id = null;
        private bool editar = false;

        public formActividades()
        {
            InitializeComponent();
        }

        private void formActividades_Load(object sender, EventArgs e)
        {
            MostrarDatos();
            MostrarProfes();
            MostrarSalones();
        }

        public void MostrarProfes()
        {
            ProcedimientoActividades obj = new ProcedimientoActividades();
            cmbProfe.DataSource = obj.llenar_profes();
            cmbProfe.DisplayMember = "nombre_profe";
            cmbProfe.ValueMember = "cod_profe";
        }

        public void MostrarSalones()
        {
            ProcedimientoActividades obj = new ProcedimientoActividades();
            cmbSalones.DataSource = obj.llenar_salones();
            cmbSalones.DisplayMember = "nombre_salon";
            cmbSalones.ValueMember = "cod_salon";
        }

        public void MostrarDatos()
        {
            ProcedimientoActividades obj = new ProcedimientoActividades();
            dgvAct.DataSource = obj.mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    prA.Insert(txtNombre.Text, Convert.ToInt32(txtHora.Text), Convert.ToInt32(cmbProfe.SelectedValue), Convert.ToInt32(cmbSalones.SelectedValue));
                    MessageBox.Show("Se agrego Actividad con exito!");
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
                    prA.Update(Convert.ToInt32(id), txtNombre.Text, Convert.ToInt32(txtHora.Text), Convert.ToInt32(cmbProfe.SelectedValue), Convert.ToInt32(cmbSalones.SelectedValue));
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
            if (dgvAct.SelectedRows.Count > 0)
            {
                editar = true;
                id = dgvAct.CurrentRow.Cells["cod_act"].Value.ToString();
                txtNombre.Text = dgvAct.CurrentRow.Cells["nombre_act"].Value.ToString();
                txtHora.Text = dgvAct.CurrentRow.Cells["hora"].Value.ToString();
                cmbProfe.SelectedValue = dgvAct.CurrentRow.Cells["cod_profe"].Value.ToString();
                cmbSalones.SelectedValue = dgvAct.CurrentRow.Cells["cod_salon"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAct.SelectedRows.Count > 0)
            {
                id = dgvAct.CurrentRow.Cells["cod_act"].Value.ToString();
                prA.Delete(Convert.ToInt32(id));
                MessageBox.Show("La Actividad se ha eliminado correctamente!");
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
            txtNombre.Clear();
            txtHora.Clear();
        }
    }
}
