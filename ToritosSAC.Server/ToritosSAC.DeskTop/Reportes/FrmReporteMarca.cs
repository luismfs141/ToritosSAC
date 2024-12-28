using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToritosSAC.DeskTop.Reportes
{
    public partial class FrmReporteMarca : Form
    {
        public FrmReporteMarca()
        {
            InitializeComponent();
        }

        private void FrmReporteMarca_Load(object sender, EventArgs e)
        {
            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                Dock = DockStyle.Fill
            };

            // Configura el archivo RDLC
            reportViewer.LocalReport.ReportPath = "ruta_del_archivo.rdlc";

            // Opcional: Agregar DataSources si los necesitas
            // reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetName", dataSource));

            // Agrega el control al formulario
            this.Controls.Add(reportViewer);

            // Refresca el informe
            reportViewer.RefreshReport();
        }
    }
}
