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

namespace GarajesAliKan.Forms.Informes
{
    public partial class FrmClientesGarajes : Form
    {
        public FrmClientesGarajes()
        {
            InitializeComponent();
        }

        private void FrmInfClientesGarajes_Load(object sender, EventArgs e)
        {
            List<ClienteGaraje> listaClientes = ClienteGaraje.ObtenerClientesParaInforme();            
            DtClientesGarajes dtClientesGarajes = new DtClientesGarajes();

            foreach (ClienteGaraje cliente in listaClientes)
            {
                // dtClientesGarajes.Tables["clientes"].Rows.Add(cliente.Alquiler.Plaza, cliente.Nombre, cliente.Apellidos, cliente.Telefono, cliente.Alquiler.Total, cliente.Observaciones);
            }
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DtClientesGarajes", dtClientesGarajes.Tables["clientes"]));
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.RefreshReport();
        }
    }
}
