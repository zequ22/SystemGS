using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using FontAwesome.Sharp;

namespace CapaDiseño
{
    public partial class formInicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public formInicio(Usuario objusuario = null)
        {
            if (objusuario == null)
              usuarioActual = new Usuario() { nombre_usuario = "admin", usuario_id = 5};
            else
            usuarioActual = objusuario;
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //formLogin formLogin = new formLogin();
            //formLogin.Show();
            //this.Hide();
            this.Close();
        }

        private void formInicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new Cn_Permiso().Listar(usuarioActual.usuario_id);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.nombre_menu == iconmenu.Name);

                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }

            lblUsuario.Text = usuarioActual.nombre_usuario;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Gray;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Teal;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formUsuarios());
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formReportes());
        }

        private void menuSocios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formSocios());

        }

        private void menuPagos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formPagos());
        }

        private void menuInscripciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formInscripciones());
        }

        private void menuActividades_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formActividades());
        }

        private void menuProfesores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formProfesores());
        }

        private void menuSalones_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formSalones());
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
