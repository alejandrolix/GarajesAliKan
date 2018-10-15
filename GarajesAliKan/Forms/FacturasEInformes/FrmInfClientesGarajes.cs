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

namespace GarajesAliKan.Forms.Informes
{
    public partial class FrmInfClientesGarajes : Form
    {
        public FrmInfClientesGarajes()
        {
            InitializeComponent();
        }

        private void FrmInfClientesGarajes_Load(object sender, EventArgs e)
        {
            ReportDocument informe = new ReportDocument();
            informe.Load(@"..\..\..\Informes\InfClientesGarajes.rpt");

            List<Cliente> listaClientes = Cliente.ObtenerClientesGarajesInforme();
            DtClientesGarajes dtClientesGarajes = new DtClientesGarajes();

            foreach (Cliente cliente in listaClientes)
            {
                dtClientesGarajes.Tables["clientes"].Rows.Add(cliente.Alquiler.Plaza, cliente.Nombre, cliente.Apellidos, cliente.Telefono, cliente.Alquiler.Total, cliente.Observaciones);
            }
            CrystalReportViewer.ReportSource = informe;
            informe.SetDataSource(dtClientesGarajes);            
            CrystalReportViewer.RefreshReport();
        }
    }
}
