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

namespace CapaDiseño
{
    public partial class formReporteActividades : Form
    {
        private Cn_Reporte _cnReporte; // Instancia de la capa de negocio

        public formReporteActividades()
        {
            InitializeComponent();
            _cnReporte = new Cn_Reporte(); // Inicializa la instancia de la capa de negocio
        }

        // Manejador del evento Click del botón para generar el reporte de actividades
        private void BtnRepActividades_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarExcel(); // Llama al método para exportar los datos a Excel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para exportar los datos de actividades a un archivo de Excel
        private void ExportarExcel()
        {
            try
            {
                // Obtener los datos de actividades desde la capa de negocio
                List<ReporteActividades> actividades = _cnReporte.ListarActividades();

                // Crear un nuevo archivo de Excel
                var workbook = new ClosedXML.Excel.XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Actividades");

                // Escribir nombres de columnas
                worksheet.Cell(1, 1).Value = "Nombre Actividad";
                worksheet.Cell(1, 2).Value = "Hora";
                worksheet.Cell(1, 3).Value = "Salón";
                worksheet.Cell(1, 4).Value = "Profesor";
                worksheet.Cell(1, 5).Value = "Cantidad de Inscriptos";

                // Escribir datos
                int rowNum = 2;
                foreach (var actividad in actividades)
                {
                    worksheet.Cell(rowNum, 1).Value = actividad.NombreActividad;
                    worksheet.Cell(rowNum, 2).Value = actividad.Hora;
                    worksheet.Cell(rowNum, 3).Value = actividad.Salon;
                    worksheet.Cell(rowNum, 4).Value = actividad.Profesor;
                    worksheet.Cell(rowNum, 5).Value = actividad.CantidadInscriptos;
                    rowNum++;
                }

                // Guardar el archivo de Excel
                string filePath = "ReporteActividades.xlsx";
                workbook.SaveAs(filePath);

                MessageBox.Show("Archivo Excel generado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el archivo Excel
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
