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

namespace GarajesAliKan.Forms
{
    public partial class FrmFactsGaraje : Form
    {
        private List<Factura> ListaFacturas;

        public FrmFactsGaraje()
        {
            InitializeComponent();
        }

        private void FrmFactsGaraje_Load(object sender, EventArgs e)
        {
            CargarDatosComboBox(true, true, true);
            if (Factura.HayFacturasGarajes())
            {
                ListaFacturas = Factura.ObtenerFacturasGarajes();
                CargarFacturasAlDataTable();
                RellenarDatosFactura(ListaFacturas[0]);
            }
            else
            {
                MessageBox.Show("No hay facturas para mostrar. Introduzca una.", "No hay Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnModificarFactura.Enabled = false;
                BtnEliminarFactura.Enabled = false;
            }                
        }

        private void DtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;             
        }

        /// <summary>
        /// Carga los datos a los distintos ComboBox.        
        /// </summary>
        /// <param name="cargarNumsFacturas">Indica si hay que cargar los Ids de las facturas.</param>
        /// <param name="cargarNifs">Indica si hay que cargar los NIFs.</param>
        /// <param name="cargarFechas">Indica si hay que cargar las fechas.</param>
        private void CargarDatosComboBox(bool cargarNumsFacturas, bool cargarNifs, bool cargarFechas)
        {
            if (cargarNumsFacturas)            
                CbNumsFacturas.DataSource = Factura.ObtenerIdsFacturasGarajes();            

            if (cargarNifs)
            {
                CbNifs.DataSource = Cliente.ObtenerNifsClientesGarajes();
                CbNifs.DisplayMember = "Nif";
                CbNifs.ValueMember = "Id";
            }

            if (cargarFechas)
            {
                CbFechas.DataSource = Factura.ObtenerFechas();
                CbFechas.DisplayMember = "Fecha";
                CbFechas.ValueMember = "Id";
            }
        }

        /// <summary>
        /// Carga los datos de las facturas en un DataTable.
        /// </summary>        
        private void CargarFacturasAlDataTable()
        {
            DataTable dtFacturas = new DataTable("facturas");
            dtFacturas.Columns.Add("id", typeof(int));
            dtFacturas.Columns.Add("fecha", typeof(DateTime));
            dtFacturas.Columns.Add("nif", typeof(string));
            dtFacturas.Columns.Add("nombre", typeof(string));
            dtFacturas.Columns.Add("apellidos", typeof(string));
            dtFacturas.Columns.Add("concepto", typeof(string));
            dtFacturas.Columns.Add("garaje", typeof(string));
            dtFacturas.Columns.Add("plaza", typeof(string));
            dtFacturas.Columns.Add("baseImponible", typeof(string));
            dtFacturas.Columns.Add("iva", typeof(string));
            dtFacturas.Columns.Add("totalFactura", typeof(string));
            dtFacturas.Columns.Add("estaPagada", typeof(bool));

            foreach (Factura factura in ListaFacturas)
            {
                dtFacturas.Rows.Add(factura.Id, factura.Fecha, factura.Cliente.Nif, factura.Cliente.Nombre, factura.Cliente.Apellidos, factura.Cliente.Alquiler.Concepto,
                    factura.Garaje.Nombre, factura.Plaza, factura.BaseImponible.ToString(), factura.Iva.ToString(), factura.Total.ToString(), factura.EstaPagada);
            }
            BindingSource.DataSource = dtFacturas;
        }

        /// <summary>
        /// Rellena los datos de la factura a su campo correspondiente.
        /// </summary>
        /// <param name="factura">Los datos de la factura.</param>
        private void RellenarDatosFactura(Factura factura)
        {
            TxtNumFactura.Text = factura.Id.ToString();
            DtFecha.Value = factura.Fecha;
            TxtNif.Text = factura.Cliente.Nif;
            TxtNombre.Text = factura.Cliente.Nombre;
            TxtApellidos.Text = factura.Cliente.Apellidos;
            CbConceptos.Text = factura.Cliente.Alquiler.Concepto;
            CbGarajes.Text = factura.Garaje.Nombre;
            TxtPlaza.Text = factura.Plaza;
            TxtBaseImponible.Text = factura.BaseImponible.ToString();
            TxtIva.Text = factura.Iva.ToString();
            TxtTotalFactura.Text = factura.Total.ToString();
            CkBoxPagada.Checked = factura.EstaPagada;
        }

        private void CbConceptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbGarajes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnImprimirFactura_Click(object sender, EventArgs e)
        {
            // Implementar.
        }

        private void BtnAddFactura_Click(object sender, EventArgs e)
        {
            BtnAddFactura.Tag = 1;
            HabilitarControles(true);
            TxtNombre.Focus();

            if (ListaFacturas != null)
                if (ListaFacturas[0].Id != 0)
                    LimpiarCampos();
        }

        /// <summary>
        /// Habilita o deshabilita varios controles.
        /// </summary>
        /// <param name="habilitar">Indica si habilita o deshabilita varios controles.</param>
        private void HabilitarControles(bool habilitar)
        {
            BindingNavigator.Enabled = !habilitar;
            TxtNumFactura.Enabled = habilitar;
            DtFecha.Enabled = habilitar;
            TxtNombre.Enabled = habilitar;
            TxtApellidos.Enabled = habilitar;
            TxtNif.Enabled = habilitar;

            if (BtnModificarFactura.Tag is null)
            {
                TxtPlaza.Enabled = habilitar;
                CbConceptos.Enabled = habilitar;
                CbGarajes.Enabled = habilitar;
            }

            TxtBaseImponible.Enabled = habilitar;
            TxtIva.Enabled = habilitar;
            CkBoxPagada.Enabled = habilitar;
            TxtTotalFactura.Enabled = habilitar;
            BtnImprimirFactura.Enabled = !habilitar;

            PBotonesControl.Enabled = !habilitar;
            BtnGuardar.Enabled = habilitar;
            BtnCancelar.Enabled = habilitar;
            PBuscarPor.Enabled = !habilitar;
        }

        /// <summary>
        /// Limpia los campos dónde se van a introducir datos.
        /// </summary>
        private void LimpiarCampos()
        {
            TxtNumFactura.Clear();
            DtFecha.Value = DateTime.Now;
            TxtNombre.Clear();
            TxtApellidos.Clear();
            TxtNif.Clear();

            CkBoxPagada.Checked = false;
            TxtPlaza.Clear();
            TxtBaseImponible.Clear();
            TxtIva.Clear();
            TxtTotalFactura.Clear();
        }

        private void CbNumsFacturas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbNifs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbFechas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
