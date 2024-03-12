using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaNegocio;
using CapaDatos;
using ClosedXML.Excel;

namespace CapaDiseño
{
    public partial class formReporteSocios : Form
    {
        private Cn_Reporte _cnReporte;

        public formReporteSocios()
        {
            InitializeComponent();
            _cnReporte = new Cn_Reporte();
        }

        private void BtnRepSocios_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarExcel()
        {
            try
            {
                // Obtener los datos de la base de datos
                List<ReporteSocios> socios = _cnReporte.ListarSocios();
                if (socios == null || socios.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos de socios para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Socios");

                // Escribir encabezados
                worksheet.Cell(1, 1).Value = "DNI";
                worksheet.Cell(1, 2).Value = "Apellido";
                worksheet.Cell(1, 3).Value = "Nombre";
                worksheet.Cell(1, 4).Value = "Estado";
                worksheet.Cell(1, 5).Value = "Cantidad de Actividades Inscriptas";
                worksheet.Cell(1, 6).Value = "Actividades Inscriptas";

                // Escribir datos
                for (int i = 0; i < socios.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = socios[i].DNI;
                    worksheet.Cell(i + 2, 2).Value = socios[i].Apellido;
                    worksheet.Cell(i + 2, 3).Value = socios[i].Nombre;
                    worksheet.Cell(i + 2, 4).Value = socios[i].Estado;
                    worksheet.Cell(i + 2, 5).Value = socios[i].CantidadActividadesInscriptas;
                    worksheet.Cell(i + 2, 6).Value = socios[i].ActividadesInscriptas;
                }

                // Autoajustar ancho de columnas
                worksheet.Columns().AdjustToContents();

                // Guardar el archivo de Excel
                string filePath = "ReporteSocios.xlsx";
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
