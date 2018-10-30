using Microsoft.Reporting.WinForms;
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

namespace GarajesAliKan.Forms.FacturasEInformes
{
    public partial class FrmFactGarajes : Form
    {
        private DateTime Desde;
        private DateTime Hasta;

        public FrmFactGarajes(DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            Desde = desde;
            Hasta = hasta;
        }

        private void FrmFactGarajes_Load(object sender, EventArgs e)
        {
            List<FacturaGaraje> listaFacturas = FacturaGaraje.ObtenerFacturasPorFechasInforme(Desde, Hasta);
            DtFacturasGarajes dtFacturasGarajes = new DtFacturasGarajes();

            foreach (FacturaGaraje factura in listaFacturas)
            {
                dtFacturasGarajes.Tables["facturas"].Rows.Add(factura.Id, factura.Fecha, factura.Cliente.Nombre, factura.Cliente.Nif, factura.Cliente.Direccion, factura.Cliente.Garaje.Nombre,
                                                              factura.Cliente.Alquiler.BaseImponible, factura.Cliente.Alquiler.Iva, factura.Cliente.Alquiler.Total);
            }
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DtFacturasGarajes", dtFacturasGarajes.Tables["facturas"]));
            ReportViewer.LocalReport.SetParameters(new ReportParameter("desde", Desde.ToString()));
            ReportViewer.LocalReport.SetParameters(new ReportParameter("hasta", Hasta.ToString()));            
            ReportViewer.RefreshReport();
        }
    }
}
