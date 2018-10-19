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
    public partial class FrmFacturasRecibidas : Form
    {
        public FrmFacturasRecibidas()
        {
            InitializeComponent();
        }

        private void FrmFacturasRecibidas_Load(object sender, EventArgs e)
        {
            List<Factura> listaFacturas = Factura.ObtenerFacturasRecibidasInforme();
            DtFacturasRecibidas dtFacturasRecibidas = new DtFacturasRecibidas();

            foreach (Factura factura in listaFacturas)
            {
                dtFacturasRecibidas.Tables["facturas"].Rows.Add(factura.Id, factura.Fecha, factura.Proveedor.Empresa, factura.Proveedor.Cif, factura.Garaje.Nombre,
                                                                factura.BaseImponible, factura.Iva, factura.Total);
            }
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DtFacturasRecibidas", dtFacturasRecibidas.Tables["facturas"]));
            ReportViewer.RefreshReport();
        }
    }
}
