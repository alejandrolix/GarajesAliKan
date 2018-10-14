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
            CrystalReportViewer.ReportSource = informe;
            informe.SetParameterValue("numFactura", factura.Id);
            informe.SetParameterValue("fecha", factura.Fecha);
            informe.SetParameterValue("cliente", factura.Cliente.Nombre);
            informe.SetParameterValue("nif", factura.Cliente.Nif);
            informe.SetParameterValue("direccion", factura.Cliente.Direccion);
            informe.SetParameterValue("tipoAlquiler", factura.Cliente.Alquiler.Concepto);
            informe.SetParameterValue("garaje", factura.Garaje.Nombre);
            informe.SetParameterValue("plaza", factura.Plaza);
            informe.SetParameterValue("baseImponible", factura.BaseImponible);
            informe.SetParameterValue("iva", factura.Iva);
            informe.SetParameterValue("totalFactura", factura.Total);
        }

        private void FrmInfFactGaraje_Load(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerDatosFacturaGarajePorId(IdFactura);

            ReportDocument informe = new ReportDocument();
            EstablecerParametrosInforme(informe, factura);            
            CrystalReportViewer.Refresh();
        }
    }
}
