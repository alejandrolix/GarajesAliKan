using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Clases;
using Microsoft.Reporting.WinForms;

namespace GarajesAliKan.Forms.FacturasEInformes
{
    public partial class FrmFactClienteGaraje : Form
    {
        public FrmFactClienteGaraje()
        {
            InitializeComponent();
        }

        private void FrmFactClienteGaraje_Load(object sender, EventArgs e)
        {
            int numFactura = FacturaGaraje.ObtenerNumFactura();
            ReportParameterCollection listaParametros = new ReportParameterCollection();
            listaParametros.Add(new ReportParameter("numFactura", numFactura.ToString()));

            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.SetParameters(listaParametros);
            ReportViewer.RefreshReport();
        }
    }
}
