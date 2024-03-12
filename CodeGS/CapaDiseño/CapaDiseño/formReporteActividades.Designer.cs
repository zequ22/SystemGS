namespace CapaDiseño
{
    partial class formReporteActividades
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
            this.BtnRepActividades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRepActividades
            // 
            this.BtnRepActividades.BackColor = System.Drawing.Color.White;
            this.BtnRepActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRepActividades.ForeColor = System.Drawing.Color.Teal;
            this.BtnRepActividades.Location = new System.Drawing.Point(12, 12);
            this.BtnRepActividades.Name = "BtnRepActividades";
            this.BtnRepActividades.Size = new System.Drawing.Size(122, 72);
            this.BtnRepActividades.TabIndex = 0;
            this.BtnRepActividades.Text = "Descargar Reporte";
            this.BtnRepActividades.UseVisualStyleBackColor = false;
            this.BtnRepActividades.Click += new System.EventHandler(this.BtnRepActividades_Click);
            // 
            // formReporteActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnRepActividades);
            this.Name = "formReporteActividades";
            this.Text = "formReporteActividades";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRepActividades;
    }
}