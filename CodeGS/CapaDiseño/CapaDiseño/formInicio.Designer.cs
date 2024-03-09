namespace CapaDiseño
{
    partial class formInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.title = new System.Windows.Forms.Label();
            this.menuSalones = new FontAwesome.Sharp.IconMenuItem();
            this.menuProfesores = new FontAwesome.Sharp.IconMenuItem();
            this.menuActividades = new FontAwesome.Sharp.IconMenuItem();
            this.menuInscripciones = new FontAwesome.Sharp.IconMenuItem();
            this.menuPagos = new FontAwesome.Sharp.IconMenuItem();
            this.menuSocios = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.contenedor = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Tomato;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(633, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(99, 54);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(546, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuario: ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(546, 33);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(81, 17);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuReportes,
            this.menuSocios,
            this.menuPagos,
            this.menuInscripciones,
            this.menuActividades,
            this.menuProfesores,
            this.menuSalones});
            this.menu.Location = new System.Drawing.Point(0, 62);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(735, 77);
            this.menu.TabIndex = 11;
            this.menu.Text = "menuStrip1";
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.Teal;
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(735, 62);
            this.menuTitulo.TabIndex = 12;
            this.menuTitulo.Text = "menuTitulo";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(154, 31);
            this.title.TabIndex = 13;
            this.title.Text = "GYM Stats";
            // 
            // menuSalones
            // 
            this.menuSalones.BackColor = System.Drawing.Color.White;
            this.menuSalones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuSalones.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            this.menuSalones.IconColor = System.Drawing.Color.Black;
            this.menuSalones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuSalones.IconSize = 50;
            this.menuSalones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSalones.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuSalones.Name = "menuSalones";
            this.menuSalones.Size = new System.Drawing.Size(67, 73);
            this.menuSalones.Text = "Salones";
            this.menuSalones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuSalones.Click += new System.EventHandler(this.menuSalones_Click);
            // 
            // menuProfesores
            // 
            this.menuProfesores.BackColor = System.Drawing.Color.White;
            this.menuProfesores.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuProfesores.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.menuProfesores.IconColor = System.Drawing.Color.Black;
            this.menuProfesores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProfesores.IconSize = 50;
            this.menuProfesores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProfesores.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuProfesores.Name = "menuProfesores";
            this.menuProfesores.Size = new System.Drawing.Size(85, 73);
            this.menuProfesores.Text = "Profesores";
            this.menuProfesores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProfesores.Click += new System.EventHandler(this.menuProfesores_Click);
            // 
            // menuActividades
            // 
            this.menuActividades.BackColor = System.Drawing.Color.White;
            this.menuActividades.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuActividades.IconChar = FontAwesome.Sharp.IconChar.Dumbbell;
            this.menuActividades.IconColor = System.Drawing.Color.Black;
            this.menuActividades.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuActividades.IconSize = 50;
            this.menuActividades.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuActividades.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuActividades.Name = "menuActividades";
            this.menuActividades.Size = new System.Drawing.Size(90, 73);
            this.menuActividades.Text = "Actividades";
            this.menuActividades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuActividades.Click += new System.EventHandler(this.menuActividades_Click);
            // 
            // menuInscripciones
            // 
            this.menuInscripciones.BackColor = System.Drawing.Color.White;
            this.menuInscripciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuInscripciones.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.menuInscripciones.IconColor = System.Drawing.Color.Black;
            this.menuInscripciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuInscripciones.IconSize = 50;
            this.menuInscripciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuInscripciones.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuInscripciones.Name = "menuInscripciones";
            this.menuInscripciones.Size = new System.Drawing.Size(99, 73);
            this.menuInscripciones.Text = "Inscripciones";
            this.menuInscripciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuInscripciones.Click += new System.EventHandler(this.menuInscripciones_Click);
            // 
            // menuPagos
            // 
            this.menuPagos.BackColor = System.Drawing.Color.White;
            this.menuPagos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuPagos.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            this.menuPagos.IconColor = System.Drawing.Color.Black;
            this.menuPagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuPagos.IconSize = 50;
            this.menuPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuPagos.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuPagos.Name = "menuPagos";
            this.menuPagos.Size = new System.Drawing.Size(62, 73);
            this.menuPagos.Text = "Pagos";
            this.menuPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuPagos.Click += new System.EventHandler(this.menuPagos_Click);
            // 
            // menuSocios
            // 
            this.menuSocios.BackColor = System.Drawing.Color.White;
            this.menuSocios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuSocios.IconChar = FontAwesome.Sharp.IconChar.Running;
            this.menuSocios.IconColor = System.Drawing.Color.Black;
            this.menuSocios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuSocios.IconSize = 50;
            this.menuSocios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSocios.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuSocios.Name = "menuSocios";
            this.menuSocios.Size = new System.Drawing.Size(62, 73);
            this.menuSocios.Text = "Socios";
            this.menuSocios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuSocios.Click += new System.EventHandler(this.menuSocios_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.BackColor = System.Drawing.Color.White;
            this.menuReportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(75, 73);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReportes.Click += new System.EventHandler(this.menuReportes_Click);
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.BackColor = System.Drawing.Color.White;
            this.menuUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.User;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 50;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(74, 73);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // contenedor
            // 
            this.contenedor.Location = new System.Drawing.Point(0, 142);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(732, 474);
            this.contenedor.TabIndex = 14;
            // 
            // formInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(735, 617);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.title);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menu;
            this.Name = "formInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GS";
            this.Load += new System.EventHandler(this.formInicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuSocios;
        private FontAwesome.Sharp.IconMenuItem menuPagos;
        private FontAwesome.Sharp.IconMenuItem menuInscripciones;
        private FontAwesome.Sharp.IconMenuItem menuActividades;
        private FontAwesome.Sharp.IconMenuItem menuProfesores;
        private FontAwesome.Sharp.IconMenuItem menuSalones;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel contenedor;
    }
}