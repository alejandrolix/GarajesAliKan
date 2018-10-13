using GarajesAliKan.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarajesAliKan
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }        

        private void ClientesGarajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesGaraje frmClientesGaraje = new FrmClientesGaraje();
            frmClientesGaraje.ShowDialog();
        }

        private void ClientesLavaderoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientesLavadero frmClientesLavadero = new FrmClientesLavadero();
            frmClientesLavadero.ShowDialog();
        }

        private void FacturasGarajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactsGaraje frmFactsGaraje = new FrmFactsGaraje();
            frmFactsGaraje.ShowDialog();
        }

        private void FacturasLavaderoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactsLavadero frmFactsLavadero = new FrmFactsLavadero();
            frmFactsLavadero.ShowDialog();
        }

        private void FacturasRecibidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactsRecibida frmFactsRecibida = new FrmFactsRecibida();
            frmFactsRecibida.ShowDialog();
        }

        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores frmProveedores = new FrmProveedores();
            frmProveedores.ShowDialog();
        }
    }
}
