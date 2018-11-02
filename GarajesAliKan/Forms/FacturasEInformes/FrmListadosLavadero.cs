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
using GarajesAliKan.DataSets;
using Microsoft.Reporting.WinForms;

namespace GarajesAliKan.Forms.FacturasEInformes
{
    partial class FrmListadosLavadero : Form
    {
        private List<FacturaLavadero> ListaFacturas;
        private DateTime Desde;
        private DateTime Hasta;

        public FrmListadosLavadero(List<FacturaLavadero> listaFacturas, DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            ListaFacturas = listaFacturas;
            Desde = desde;
            Hasta = hasta;
        }

        private void FrmListadosLavaderos_Load(object sender, EventArgs e)
        {            
            DtFacturasLavadero dtFacturasLavadero = new DtFacturasLavadero();
            foreach (FacturaLavadero factura in ListaFacturas)
            {
                dtFacturasLavadero.Tables["facturas"].Rows.Add(factura.Id, factura.Fecha, factura.Cliente.Nombre, factura.Cliente.Direccion, factura.Cliente.Nif,
                                                               factura.BaseImponible, factura.Iva, factura.Total);
            }
            ReportViewer.LocalReport.SetParameters(new ReportParameter("desde", Desde.ToString()));
            ReportViewer.LocalReport.SetParameters(new ReportParameter("hasta", Hasta.ToString()));

            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DtFacturasLavadero", dtFacturasLavadero.Tables["facturas"]));
            ReportViewer.RefreshReport();
        }
    }
}
