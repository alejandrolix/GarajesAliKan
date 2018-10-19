using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Forms.FacturasEInformes;
using GarajesAliKan.Forms.Informes;

namespace GarajesAliKan.Forms
{
    public partial class FrmListados : Form
    {
        public FrmListados()
        {
            InitializeComponent();
        }

        private void FrmListados_Load(object sender, EventArgs e)
        {
            DtFechaInicio.Value = DateTime.Now;
            DtFechaFin.Value = DateTime.Now;
        }

        private void BtnImprimirClientes_Click(object sender, EventArgs e)
        {
            FrmInfClientesGarajes frmInfClientesGarajes = new FrmInfClientesGarajes();
            frmInfClientesGarajes.ShowDialog();
        }

        private void BtnImprFactGaraje_Click(object sender, EventArgs e)
        {
            FrmFactGarajes frmFactGarajes = new FrmFactGarajes(DtFechaInicio.Value, DtFechaFin.Value);
            frmFactGarajes.ShowDialog();
        }

        private void BtnImprFactLavadero_Click(object sender, EventArgs e)
        {
            FrmListadosLavadero frmListadosLavadero = new FrmListadosLavadero();
            frmListadosLavadero.ShowDialog();
        }

        private void BtnImprFactRecibida_Click(object sender, EventArgs e)
        {
            FrmFacturasRecibidas frmFacturasRecibidas = new FrmFacturasRecibidas();
            frmFacturasRecibidas.ShowDialog();
        }
    }
}
