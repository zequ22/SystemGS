﻿namespace CapaDiseño
{
    partial class formReporteSocios
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
            this.BtnRepSocios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRepSocios
            // 
            this.BtnRepSocios.BackColor = System.Drawing.Color.White;
            this.BtnRepSocios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRepSocios.ForeColor = System.Drawing.Color.Teal;
            this.BtnRepSocios.Location = new System.Drawing.Point(12, 12);
            this.BtnRepSocios.Name = "BtnRepSocios";
            this.BtnRepSocios.Size = new System.Drawing.Size(135, 70);
            this.BtnRepSocios.TabIndex = 1;
            this.BtnRepSocios.Text = "Descargar Reporte";
            this.BtnRepSocios.UseVisualStyleBackColor = false;
            this.BtnRepSocios.Click += new System.EventHandler(this.BtnRepSocios_Click);
            // 
            // formReporteSocios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnRepSocios);
            this.Name = "formReporteSocios";
            this.Text = "formReporteSocios";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnRepSocios;
    }
}