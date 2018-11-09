using GarajesAliKan.Clases;
using GarajesAliKan.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace GarajesAliKan.Forms.FacturasEInformes
{
    partial class FrmFacturasRecibidas : Form
    {
        private List<FacturaRecibida> ListaFacturas;
        private DateTime Desde;
        private DateTime Hasta;        

        public FrmFacturasRecibidas(List<FacturaRecibida> listaFacturas, DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            ListaFacturas = listaFacturas;
            Desde = desde;
            Hasta = hasta;
        }

        private void FrmFacturasRecibidas_Load(object sender, EventArgs e)
        {            
            DtFacturasRecibidas dtFacturasRecibidas = new DtFacturasRecibidas();

            foreach (FacturaRecibida factura in ListaFacturas)
            {
                dtFacturasRecibidas.Tables["facturas"].Rows.Add(factura.Id, factura.Fecha, factura.Proveedor.Empresa, factura.Proveedor.Cif, factura.Garaje.Nombre,
                                                                factura.BaseImponible, factura.Iva, factura.Total);
            }
            ReportViewer.LocalReport.SetParameters(new ReportParameter("desde", Desde.ToString()));
            ReportViewer.LocalReport.SetParameters(new ReportParameter("hasta", Hasta.ToString()));

            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DtFacturasRecibidas", dtFacturasRecibidas.Tables["facturas"]));
            ReportViewer.RefreshReport();
        }
    }
}
