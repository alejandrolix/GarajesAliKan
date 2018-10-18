using GarajesAliKan.Clases;
using GarajesAliKan.DataSets;
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
    public partial class FrmInfFactGaraje : Form
    {
        private int IdFactura;

        public FrmInfFactGaraje(int idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        /// <summary>
        /// Establece los datos al informe del garaje.
        /// </summary>
        /// <param name="informe">El informe para establecer los datos.</param>
        /// <param name="factura">Los datos de la factura.</param>
        private void EstablecerParametrosInforme(Factura factura)
        {
            ReportParameterCollection listaParametros = new ReportParameterCollection();
            listaParametros.Add(new ReportParameter("numFactura", factura.Id.ToString()));
            listaParametros.Add(new ReportParameter("fecha", factura.Fecha.ToString()));
            listaParametros.Add(new ReportParameter("nombre", "ALEJANDRO PONS ANTELO"));
            listaParametros.Add(new ReportParameter("nif", "53243167F"));
            listaParametros.Add(new ReportParameter("direccion", "C/ GARBINET, 97 3ºB"));
            listaParametros.Add(new ReportParameter("tipoAlquiler", "ALQUILER PLAZA DE GARAJE"));
            listaParametros.Add(new ReportParameter("garaje", "GONZALO MENGUAL"));
            listaParametros.Add(new ReportParameter("plaza", "GM 19"));
            listaParametros.Add(new ReportParameter("baseImponible", "19.40"));
            listaParametros.Add(new ReportParameter("iva", "11"));
            listaParametros.Add(new ReportParameter("totalFactura", "22.69"));
            ReportViewer.LocalReport.SetParameters(listaParametros);
        }

        private void FrmInfFactGaraje_Load(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerDatosFacturaGarajePorId(IdFactura);            
            EstablecerParametrosInforme(factura);            

            DtFacturasGarajes dtFacturasGarajes = new DtFacturasGarajes();
            dtFacturasGarajes.Tables["facturas"].Rows.Add(factura.Id);

            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DtFacturasGarajes", dtFacturasGarajes.Tables["facturas"]));
            ReportViewer.RefreshReport();            
        }
    }
}
