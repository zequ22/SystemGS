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
    public partial class formInicio : Form
    {
        public formInicio()
        {
            InitializeComponent();
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            formSocios formuSocios = new formSocios();
            formuSocios.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formPagos formuPagos = new formPagos();
            formuPagos.Show();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            formInscripciones formuInscripciones = new formInscripciones();
            formuInscripciones.Show();
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            formActividades formuActividades = new formActividades();
            formuActividades.Show();
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            formProfesores formuProfesores = new formProfesores();
            formuProfesores.Show();
        }

        private void btnSalones_Click(object sender, EventArgs e)
        {
            formSalones formuSalones = new formSalones();
            formuSalones.Show();
        }
    }
}
