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

namespace GarajesAliKan.Forms.Facturas
{
    public partial class FrmFactTrastero : Form
    {
        private int IdCliente;

        public FrmFactTrastero(int idCliente)
        {
            InitializeComponent();
            IdCliente = idCliente;
        }

        /// <summary>
        /// Establece los datos al informe del garaje.
        /// </summary>        
        /// <param name="factura">Los datos de la factura.</param>
        /// <param name="numFactura">El número de la factura.</param>
        private void EstablecerParametrosInforme(FacturaGaraje factura, int numFactura)
        {
            ReportParameterCollection listaParametros = new ReportParameterCollection();
            listaParametros.Add(new ReportParameter("numFactura", numFactura.ToString()));
            listaParametros.Add(new ReportParameter("fecha", DateTime.Now.ToString("dd/MM/yyyy")));
            listaParametros.Add(new ReportParameter("nombre", factura.Cliente.Nombre));
            listaParametros.Add(new ReportParameter("nif", factura.Cliente.Nif));
            listaParametros.Add(new ReportParameter("direccion", factura.Cliente.Direccion));
            listaParametros.Add(new ReportParameter("telefono", factura.Cliente.Telefono));
            listaParametros.Add(new ReportParameter("plaza", factura.Alquiler.Plaza));
            listaParametros.Add(new ReportParameter("baseImponible", factura.Alquiler.BaseImponible.ToString()));
            listaParametros.Add(new ReportParameter("iva", factura.Alquiler.Iva.ToString()));
            listaParametros.Add(new ReportParameter("totalFactura", factura.Alquiler.Total.ToString()));
            ReportViewer.LocalReport.SetParameters(listaParametros);
        }

        private void FrmFactTrastero_Load(object sender, EventArgs e)
        {
            int numFactura = FacturaGaraje.ObtenerNumFactura();
            FacturaGaraje factura = FacturaGaraje.ObtenerClientePorIdParaFacturaTrastero(IdCliente);
            
            EstablecerParametrosInforme(factura, numFactura);
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.RefreshReport();
        }        
    }
}
