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
            FrmClientesGarajes frmInfClientesGarajes = new FrmClientesGarajes();
            frmInfClientesGarajes.ShowDialog();
        }

        private void BtnImprFactGaraje_Click(object sender, EventArgs e)
        {
            List<FacturaGaraje> listaFacturas = FacturaGaraje.ObtenerFacturasPorFechasInforme(DtFechaInicio.Value, DtFechaFin.Value);
            if (listaFacturas.Count == 0)            
                MessageBox.Show("No hay facturas de los garajes para mostrar a partir de la fecha de inicio y de fin escogidas", "No Existen Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            else
            {
                FrmFactGarajes frmFactGarajes = new FrmFactGarajes(listaFacturas, DtFechaInicio.Value, DtFechaFin.Value);
                frmFactGarajes.ShowDialog();
            }            
        }

        private void BtnImprFactLavadero_Click(object sender, EventArgs e)
        {
            List<FacturaLavadero> listaFacturas = FacturaLavadero.ObtenerFacturasPorFechasInforme(DtFechaInicio.Value, DtFechaFin.Value);
            if (listaFacturas.Count == 0)
                MessageBox.Show("No hay facturas del lavadero para mostrar a partir de la fecha de inicio y de fin escogidas", "No Existen Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                FrmListadosLavadero frmListadosLavadero = new FrmListadosLavadero(listaFacturas, DtFechaInicio.Value, DtFechaFin.Value);
                frmListadosLavadero.ShowDialog();
            }            
        }

        private void BtnImprFactRecibida_Click(object sender, EventArgs e)
        {
            List<FacturaRecibida> listaFacturas = FacturaRecibida.ObtenerFacturasPorFechasInforme(DtFechaInicio.Value, DtFechaFin.Value);
            if (listaFacturas.Count == 0)            
                MessageBox.Show("No hay facturas recibidas para mostrar a partir de la fecha de inicio y de fin escogidas", "No Existen Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            else
            {
                FrmFacturasRecibidas frmFacturasRecibidas = new FrmFacturasRecibidas(listaFacturas, DtFechaInicio.Value, DtFechaFin.Value);
                frmFacturasRecibidas.ShowDialog();
            }            
        }
    }
}
