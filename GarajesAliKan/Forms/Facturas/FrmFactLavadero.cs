using GarajesAliKan.Clases;
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

namespace GarajesAliKan.Forms.Facturas
{
    public partial class FrmFactLavadero : Form
    {
        private int IdFactura;

        public FrmFactLavadero(int idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        /// <summary>
        /// Establece los datos al informe del garaje.
        /// </summary>        
        /// <param name="factura">Los datos de la factura.</param>
        private void EstablecerParametrosInforme(FacturaLavadero factura)
        {
            ReportParameterCollection listaParametros = new ReportParameterCollection();
            listaParametros.Add(new ReportParameter("numFactura", factura.Id.ToString()));
            listaParametros.Add(new ReportParameter("fecha", factura.Fecha.ToString()));
            listaParametros.Add(new ReportParameter("nombre", factura.Cliente.Nombre));
            listaParametros.Add(new ReportParameter("nif", factura.Cliente.Nif));
            listaParametros.Add(new ReportParameter("direccion", factura.Cliente.Direccion));
            listaParametros.Add(new ReportParameter("tipoAlquiler", factura.Concepto));            
            listaParametros.Add(new ReportParameter("baseImponible", factura.BaseImponible.ToString()));
            listaParametros.Add(new ReportParameter("iva", factura.Iva.ToString()));
            listaParametros.Add(new ReportParameter("totalFactura", factura.Total.ToString()));
            ReportViewer.LocalReport.SetParameters(listaParametros);
        }

        private void FrmInfFactLavadero_Load(object sender, EventArgs e)
        {
            FacturaLavadero factura = FacturaLavadero.ObtenerDatosFacturaPorIdParaInforme(IdFactura);                       
            EstablecerParametrosInforme(factura);
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.RefreshReport();
        }
    }
}
