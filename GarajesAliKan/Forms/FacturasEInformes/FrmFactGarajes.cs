using CrystalDecisions.CrystalReports.Engine;
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
            ReportDocument informe = new ReportDocument();
            informe.Load(@"..\..\..\Informes\InfFacturaGarajesListado.rpt");

            List<Factura> listaFacturas = Factura.ObtenerFacturasGarajesPorFechasInforme(Desde, Hasta);
            DtFacturasGarajes dtFacturasGarajes = new DtFacturasGarajes();

            foreach (Factura factura in listaFacturas)
            {
                dtFacturasGarajes.Tables["facturas"].Rows.Add(factura.Id, factura.Fecha, factura.Cliente.Nombre, factura.Cliente.Nif, factura.Cliente.Direccion, factura.Cliente.Garaje.Nombre,
                                                              factura.Cliente.Alquiler.BaseImponible, factura.Cliente.Alquiler.Iva, factura.Cliente.Alquiler.Total);
            }                       
            informe.SetDataSource(dtFacturasGarajes);
            informe.SetParameterValue("desde", Desde);
            informe.SetParameterValue("hasta", Hasta);
            CrystalReportViewer.ReportSource = informe;
        }
    }
}
