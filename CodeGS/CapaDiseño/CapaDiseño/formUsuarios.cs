using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDiseño.Utilidades;
using CapaDatos;
using CapaNegocio;

namespace CapaDiseño
{
    public partial class formUsuarios : Form
    {
        public formUsuarios()
        {
            InitializeComponent();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new opcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new opcionCombo() { Valor = 0, Texto = "Inactivo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRol = new Cn_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cboRol.Items.Add(new opcionCombo() { Valor = item.rol_id, Texto = item.rol_descripcion });
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboFiltrar.Items.Add(new opcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboFiltrar.DisplayMember = "Texto";
            cboFiltrar.ValueMember = "Valor";
            cboFiltrar.SelectedIndex = 0;

            //Muestra todos los usuarios:
            List<Usuario> listaUsuario = new Cn_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvData.Rows.Add(new object[] {"", 
                    item.usuario_id, 
                    item.tipo_nro_doc, 
                    item.nombre_usuario, 
                    item.apellido_usuario,
                    item.clave, 
                    item.oRol.rol_id, 
                    item.oRol.rol_descripcion, 
                    item.estado == true ? 1 : 0, 
                    item.estado == true ? "Activo" : "Inactivo"
            });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Usuario objusuario = new Usuario()
            {
                usuario_id = Convert.ToInt32(txtId.Text),
                tipo_nro_doc = txtDocumento.Text,
                nombre_usuario = txtNombre.Text,
                apellido_usuario = txtApellido.Text,
                clave = txtClave.Text,
                oRol = new Rol() { rol_id = Convert.ToInt32(((opcionCombo)cboRol.SelectedItem).Valor) },
                estado = Convert.ToInt32(((opcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (objusuario.usuario_id == 0)
            {
                int idUsuarioGenerado = new Cn_Usuario().Registrar(objusuario, out mensaje);

                if (idUsuarioGenerado != 0)
                {
                    dgvData.Rows.Add(new object[] {"", idUsuarioGenerado, txtDocumento.Text, txtNombre.Text, txtApellido.Text,
                    txtClave.Text, ((opcionCombo)cboRol.SelectedItem).Valor.ToString(),
                    ((opcionCombo)cboRol.SelectedItem).Texto.ToString(),
                    ((opcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                    ((opcionCombo)cboEstado.SelectedItem).Texto.ToString()
                    });

                    Limpiar();
                } else
                {
                    MessageBox.Show(mensaje);
                } 
            }else
            {
                bool resultado = new Cn_Usuario().Editar(objusuario, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["documento"].Value = txtDocumento.Text;
                    row.Cells["nombre"].Value = txtNombre.Text;
                    row.Cells["apellido"].Value = txtApellido.Text;
                    row.Cells["clave"].Value = txtClave.Text;
                    row.Cells["IdRol"].Value = ((opcionCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((opcionCombo)cboRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((opcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((opcionCombo)cboEstado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }                      
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.Icono.Width;
                var h = Properties.Resources.Icono.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Icono, new Rectangle(x,y,w,h));
                e.Handled = true;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que no sea una celda de encabezado
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
                {
                    int indice = e.RowIndex;

                    if (indice >= 0)
                    {
                        txtIndice.Text = indice.ToString();
                        txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                        txtDocumento.Text = dgvData.Rows[indice].Cells["documento"].Value.ToString();
                        txtNombre.Text = dgvData.Rows[indice].Cells["nombre"].Value.ToString();
                        txtApellido.Text = dgvData.Rows[indice].Cells["apellido"].Value.ToString();
                        txtClave.Text = dgvData.Rows[indice].Cells["clave"].Value.ToString();
                        txtConfirmarClave.Text = dgvData.Rows[indice].Cells["clave"].Value.ToString();

                        foreach (opcionCombo oc in cboRol.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                            {
                                int indice_combo = cboRol.Items.IndexOf(oc);
                                cboRol.SelectedIndex = indice_combo;
                                break;
                            }
                        }

                        foreach (opcionCombo oc in cboEstado.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                            {
                                int indice_combo = cboEstado.Items.IndexOf(oc);
                                cboEstado.SelectedIndex = indice_combo;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtId.Text) != 0)
            {
                if(MessageBox.Show("¿Quiere eliminar el Usuario?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {

                    string mensaje = string.Empty;

                    Usuario objusuario = new Usuario()
                    {
                        usuario_id = Convert.ToInt32(txtId.Text)
                    };

                    bool respuesta = new Cn_Usuario().Eliminar(objusuario, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    } else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((opcionCombo)cboFiltrar.SelectedItem).Valor.ToString();

            if(dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtFiltrar.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    } else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltrar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
