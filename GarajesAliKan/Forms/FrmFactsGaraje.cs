using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Clases;
using GarajesAliKan.Forms.Facturas;

namespace GarajesAliKan.Forms
{
    public partial class FrmFactsGaraje : Form
    {        
        public FrmFactsGaraje()
        {
            InitializeComponent();
        }

        private void FrmFactsGaraje_Load(object sender, EventArgs e)
        {            
            CargarDatosComboBox(true, true, true);
            if (FacturaGaraje.HayFacturas())
            {
                BindingSource.DataSource = FacturaGaraje.ObtenerFacturas();                
                RellenarDatosFactura((FacturaGaraje)BindingSource.Current);
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
        /// <param name="cargarNombresYApellidos">Indica si hay que cargar los nombres y apellidos de los clientes.</param>
        /// <param name="cargarConceptos">Indica si hay que cargar los conceptos.</param>
        /// <param name="cargarGarajes">Indica si hay que cargar los nombres de los garajes.</param>
        private void CargarDatosComboBox(bool cargarNombresYApellidos, bool cargarConceptos, bool cargarGarajes)
        {
            if (cargarNombresYApellidos)
            {
                CbClientes.DataSource = ClienteGaraje.ObtenerNombresYApellidos();
                CbClientes.DisplayMember = "Nombre";
                CbClientes.ValueMember = "Id";
            }

            if (cargarConceptos)
            {
                CbConceptos.DataSource = Alquiler.ObtenerConceptos();
                CbConceptos.DisplayMember = "Concepto";
                CbConceptos.ValueMember = "IdTipoAlquiler";
            }

            if (cargarGarajes)
            {
                CbGarajes.DataSource = Garaje.ObtenerGarajes();
                CbGarajes.DisplayMember = "Nombre";
                CbGarajes.ValueMember = "Id";
            }

            CbNumsFacturas.DataSource = FacturaGaraje.ObtenerIdsFacturas();
            CbNifs.DataSource = ClienteGaraje.ObtenerNifsClientes();
            CbNifs.DisplayMember = "Nif";
            CbNifs.ValueMember = "Id";

            CbFechas.DataSource = FacturaGaraje.ObtenerFechas();
        }

        /// <summary>
        /// Rellena los datos de la factura a su campo correspondiente.
        /// </summary>
        /// <param name="factura">Los datos de la factura.</param>
        private void RellenarDatosFactura(FacturaGaraje factura)
        {
            TxtNumFactura.Text = factura.Id.ToString();
            DtFecha.Value = factura.Fecha;
            CbClientes.Text = factura.Cliente.Nombre;

            CbConceptos.Text = factura.Alquiler.Concepto;
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
            FrmInfFactGaraje frmInfFactGaraje = new FrmInfFactGaraje(((FacturaGaraje)BindingSource.Current).Id);
            frmInfFactGaraje.ShowDialog();
        }

        private void BtnAddFactura_Click(object sender, EventArgs e)
        {
            BtnAddFactura.Tag = 1;
            HabilitarControles(true);
            TxtNumFactura.Focus();
            FacturaGaraje factura = (FacturaGaraje)BindingSource.Current;

            if (factura != null)
                if (factura.Id != 0)
                    LimpiarCampos();
        }

        /// <summary>
        /// Habilita o deshabilita varios controles.
        /// </summary>
        /// <param name="habilitar">Indica si habilita o deshabilita varios controles.</param>
        private void HabilitarControles(bool habilitar)
        {
            BindingNavigator.Enabled = !habilitar;
            TxtNumFactura.Enabled = Convert.ToInt32(BtnAddFactura.Tag) == 1;
            DtFecha.Enabled = habilitar;
            CbClientes.Enabled = BtnModificarFactura.Tag is null ? habilitar : !habilitar;

            TxtPlaza.Enabled = BtnModificarFactura.Tag is null ? habilitar : !habilitar;
            CbConceptos.Enabled = BtnModificarFactura.Tag is null ? habilitar : !habilitar;
            CbGarajes.Enabled = BtnModificarFactura.Tag is null ? habilitar : !habilitar;

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

        private void BtnModificarFactura_Click(object sender, EventArgs e)
        {
            BtnModificarFactura.Tag = 1;
            HabilitarControles(true);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {            
            RestaurarTagsBotones();
            HabilitarControles(false);
            RellenarDatosFactura((FacturaGaraje)BindingSource.Current);
        }

        /// <summary>
        /// Restaura la propiedad "Tag" de los botones de "Añadir Cliente" y "Modificar Cliente".
        /// </summary>
        private void RestaurarTagsBotones()
        {
            if (Convert.ToInt32(BtnAddFactura.Tag) == 1)
                BtnAddFactura.Tag = null;

            if (Convert.ToInt32(BtnModificarFactura.Tag) == 1)
                BtnModificarFactura.Tag = null;
        }

        private void BtnEliminarFactura_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar la factura?", "¿Eliminar Factura?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FacturaGaraje factura = (FacturaGaraje)BindingSource.Current;

                if (factura.Eliminar())
                {
                    MessageBox.Show("Factura eliminada", "Factura Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindingSource.DataSource = FacturaGaraje.ObtenerFacturas();
                    HabilitarControles(false);                    
                    CargarDatosComboBox(false, false, false);
                    BindingSource.Position = BindingSource.Count - 1;
                }
                else
                    MessageBox.Show("Ha habido un problema al eliminar la factura", "Factura no Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                FacturaGaraje factura = new FacturaGaraje();
                factura.Id = int.Parse(TxtNumFactura.Text);
                factura.Fecha = DtFecha.Value;
                factura.EstaPagada = CkBoxPagada.Checked;
                factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text, CultureInfo.InvariantCulture.NumberFormat);
                factura.Iva = decimal.Parse(TxtIva.Text, CultureInfo.InvariantCulture.NumberFormat);
                factura.Total = decimal.Parse(TxtTotalFactura.Text, CultureInfo.InvariantCulture.NumberFormat);

                if (Convert.ToInt32(BtnAddFactura.Tag) == 1)                // Insertamos la nueva factura.
                {                                        
                    factura.Cliente.Id = ((ClienteGaraje)CbClientes.SelectedItem).Id;                                        
                    factura.Garaje.Id = ((Garaje)CbGarajes.SelectedItem).Id;
                    factura.Cliente.Alquiler.IdTipoAlquiler = ((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler;

                    if (factura.Insertar())
                    {
                        MessageBox.Show("Factura guardada", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = FacturaGaraje.ObtenerFacturas();

                        int pos = ((List<FacturaGaraje>)BindingSource.DataSource).IndexOf(new FacturaGaraje(factura.Id));
                        BindingSource.Position = pos;

                        HabilitarControles(false);                        
                        CargarDatosComboBox(false, false, false);                        
                    }
                    else
                        MessageBox.Show("Ha habido un problema al guardar la factura", "Factura no Guardada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(BtnModificarFactura.Tag) == 1)             // Modificamos los datos de la factura.
                {
                    if (factura.Modificar())
                    {
                        MessageBox.Show("Factura modificada", "Factura Modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = FacturaGaraje.ObtenerFacturas();

                        int pos = ((List<FacturaGaraje>)BindingSource.DataSource).IndexOf(new FacturaGaraje(factura.Id));
                        BindingSource.Position = pos;

                        HabilitarControles(false);                        
                        CargarDatosComboBox(false, false, false);                        
                    }
                    else
                        MessageBox.Show("Ha habido un problema al modificar la factura", "Factura no Modificada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            RestaurarTagsBotones();
        }

        /// <summary>
        /// Comprueba que los datos introducidos por el usuario sean correctos.
        /// </summary>
        /// <returns>Indica si los datos introducidos son correctos.</returns>        
        private bool ComprobarDatosIntroducidos()
        {
            bool hayNumFactura = false;
            bool hayPlaza = false;
            bool hayBaseImponible = false;
            bool hayIva = false;
            bool hayTotal = false;            

            if (TxtNumFactura.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un número de factura", "Nº de Factura Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayNumFactura = true;

            if (TxtPlaza.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una plaza", "Plaza Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayPlaza = true;

            if (TxtBaseImponible.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una base imponible", "Base Imponible Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayBaseImponible = true;

            if (TxtIva.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un I.V.A.", "I.V.A. Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayIva = true;

            if (TxtTotalFactura.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un total", "Total Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayTotal = true;

            return hayNumFactura && hayPlaza && hayBaseImponible && hayIva && hayTotal;
        }

        private void CbClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtBaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtTotalFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtPlaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == ' ' || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaGaraje)BindingSource.Current);
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaGaraje)BindingSource.Current);
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaGaraje)BindingSource.Current);
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaGaraje)BindingSource.Current);
        }

        private void CbNumsFacturas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pos = ((List<FacturaGaraje>)BindingSource.DataSource).IndexOf(new FacturaGaraje((int)CbNumsFacturas.SelectedItem));
            BindingSource.Position = pos;
            RellenarDatosFactura(((List<FacturaGaraje>)BindingSource.DataSource)[pos]);
        }

        private void CbNifs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FrmBuscarFactsGarajes frmBuscarFactsGarajes = new FrmBuscarFactsGarajes(((ClienteGaraje)CbNifs.SelectedItem).Id);
            frmBuscarFactsGarajes.ShowDialog();

            int posicion = BindingSource.Position;
            BindingSource.DataSource = FacturaGaraje.ObtenerFacturas();            
            BindingSource.Position = posicion;
        }

        private void CbFechas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FrmBuscarFactsGarajes frmBuscarFactsGarajes = new FrmBuscarFactsGarajes((DateTime)CbFechas.SelectedItem);
            frmBuscarFactsGarajes.ShowDialog();

            int posicion = BindingSource.Position;
            BindingSource.DataSource = FacturaGaraje.ObtenerFacturas();
            BindingSource.Position = posicion;
        }

        private void TxtNumFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.
            else
                e.Handled = true;
        }
    }
}
