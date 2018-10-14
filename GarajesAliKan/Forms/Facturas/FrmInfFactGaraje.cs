using CrystalDecisions.CrystalReports.Engine;
using GarajesAliKan.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarajesAliKan.Forms.Facturas
{
    public partial class FrmInfFactGaraje : Form
    {
        private int IdFactura;

        public FrmInfFactGaraje(int idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        /// <summary>
        /// Establece los datos al informe de un garaje.
        /// </summary>
        /// <param name="informe">El informe para establecer los datos.</param>
        /// <param name="factura">Los datos de la factura.</param>
        private void EstablecerParametrosInforme(ReportDocument informe, Factura factura)
        {
            informe.Load(@"..\..\..\Informes\InfFacturaGaraje.rpt");            
        }

        private void FrmInfFactGaraje_Load(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerFacturaGarajePorId(IdFactura);

            ReportDocument informe = new ReportDocument();
            EstablecerParametrosInforme(informe, factura);

            CrystalReportViewer.ReportSource = informe;
            CrystalReportViewer.RefreshReport();
        }
    }
}
