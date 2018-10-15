using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Forms.Informes;

namespace GarajesAliKan.Forms
{
    public partial class FrmListados : Form
    {
        public FrmListados()
        {
            InitializeComponent();
        }

        private void BtnImprimirClientes_Click(object sender, EventArgs e)
        {
            FrmInfClientesGarajes frmInfClientesGarajes = new FrmInfClientesGarajes();
            frmInfClientesGarajes.ShowDialog();
        }
    }
}
