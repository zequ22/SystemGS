namespace CapaDiseño
{
    partial class formGestion
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
            this.comboRol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMenu = new System.Windows.Forms.ComboBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboRol
            // 
            this.comboRol.FormattingEnabled = true;
            this.comboRol.Location = new System.Drawing.Point(210, 7);
            this.comboRol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboRol.Name = "comboRol";
            this.comboRol.Size = new System.Drawing.Size(272, 24);
            this.comboRol.TabIndex = 0;
            this.comboRol.SelectedIndexChanged += new System.EventHandler(this.comboRol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el ROL a EDITAR:";
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAsignar.Location = new System.Drawing.Point(19, 71);
            this.btnAsignar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(463, 28);
            this.btnAsignar.TabIndex = 3;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seleccione el MENU:";
            // 
            // comboMenu
            // 
            this.comboMenu.FormattingEnabled = true;
            this.comboMenu.Location = new System.Drawing.Point(210, 39);
            this.comboMenu.Margin = new System.Windows.Forms.Padding(4);
            this.comboMenu.Name = "comboMenu";
            this.comboMenu.Size = new System.Drawing.Size(272, 24);
            this.comboMenu.TabIndex = 4;
            this.comboMenu.SelectedIndexChanged += new System.EventHandler(this.comboMenu_SelectedIndexChanged);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.Tomato;
            this.btnQuitar.Location = new System.Drawing.Point(19, 107);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(463, 28);
            this.btnQuitar.TabIndex = 6;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // formGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 148);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboMenu);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboRol);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formGestion";
            this.Text = "formGestion";
            this.Load += new System.EventHandler(this.formGestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMenu;
        private System.Windows.Forms.Button btnQuitar;
    }
}