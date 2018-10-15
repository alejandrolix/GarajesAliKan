using GarajesAliKan.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Forms.Facturas;

namespace GarajesAliKan.Forms
{
    public partial class FrmFactsLavadero : Form
    {
        public FrmFactsLavadero()
        {
            InitializeComponent();
        }

        private void FrmFactsLavadero_Load(object sender, EventArgs e)
        {            
            CargarDatosComboBox(true, true, true);
            if (Factura.HayFacturasLavadero())
            {
                BindingSource.DataSource = Factura.ObtenerFacturasLavadero();
                RellenarDatosFactura((Factura)BindingSource.Current);
            }
            else
            {
                MessageBox.Show("No hay facturas para mostrar. Introduzca una.", "No hay Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnModificarFactura.Enabled = false;
                BtnEliminarFactura.Enabled = false;
            }
        }

        /// <summary>
        /// Carga los datos a los distintos ComboBox.        
        /// </summary>
        /// <param name="cargarNumsFacturas">Indica si hay que cargar los Ids de las facturas.</param>
        /// <param name="cargarFechas">Indica si hay que cargar las fechas.</param>
        /// <param name="cargarClientes">Indica si hay que cargar los clientes de las facturas.</param>
        private void CargarDatosComboBox(bool cargarNumsFacturas, bool cargarFechas, bool cargarClientes)
        {
            if (cargarNumsFacturas)            
                CbNumsFacturas.DataSource = Factura.ObtenerIdsFacturasLavadero();                            

            if (cargarFechas)            
                CbFechas.DataSource = Factura.ObtenerFechasLavadero();            

            if (cargarClientes)
            {
                CbCliBuscar.DataSource = Cliente.ObtenerNombresYApellidosLavadero();
                CbCliBuscar.DisplayMember = "Nombre";
                CbCliBuscar.ValueMember = "Id";                
            }                        
        }

        /// <summary>
        /// Rellena los datos de la factura a su campo correspondiente.
        /// </summary>
        /// <param name="factura">Los datos de la factura.</param>
        private void RellenarDatosFactura(Factura factura)
        {
            TxtNumFactura.Text = factura.Id.ToString();
            DtFecha.Value = factura.Fecha;                      
            CbClientes.Text = factura.Cliente.Nombre;
            TxtConcepto.Text = factura.Cliente.Alquiler.Concepto;
            
            TxtBaseImponible.Text = factura.Cliente.Alquiler.BaseImponible.ToString();
            TxtIva.Text = factura.Cliente.Alquiler.Iva.ToString();
            TxtTotalFactura.Text = factura.Cliente.Alquiler.Total.ToString();
            CkBoxPagada.Checked = factura.EstaPagada;
        }

        private void TxtNumFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.
            else
                e.Handled = true;
        }

        private void DtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void CbNumsFacturas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbFechas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbCliBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnAddFactura_Click(object sender, EventArgs e)
        {
            BtnAddFactura.Tag = 1;
            CbClientes.DataSource = Cliente.ObtenerNombresYApellidosLavadero();
            CbClientes.DisplayMember = "Nombre";
            CbClientes.ValueMember = "Id";

            HabilitarControles(true);
            TxtNumFactura.Focus();
            Factura factura = (Factura)BindingSource.Current;

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
            TxtNumFactura.Enabled = habilitar;
            DtFecha.Enabled = habilitar;
            CbClientes.Enabled = BtnModificarFactura.Tag is null ? habilitar : !habilitar;
            TxtConcepto.Enabled = habilitar;

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
            TxtBaseImponible.Clear();
            TxtIva.Clear();
            TxtTotalFactura.Clear();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            RestaurarTagsBotones();
            HabilitarControles(false);
            RellenarDatosFactura((Factura)BindingSource.Current);
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                Factura factura = null;
                if (Convert.ToInt32(BtnAddFactura.Tag) == 1)                // Insertamos la nueva factura.
                {
                    factura = new Factura(2);
                    factura.Id = int.Parse(TxtNumFactura.Text);
                    factura.Fecha = DtFecha.Value;
                    factura.Cliente.Id = ((Cliente)CbClientes.SelectedItem).Id;
                    factura.Concepto = TxtConcepto.Text;
                    factura.EstaPagada = CkBoxPagada.Checked;                    
                    factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                    factura.Iva = decimal.Parse(TxtIva.Text);
                    factura.Total = decimal.Parse(TxtTotalFactura.Text);

                    if (factura.InsertarParaLavadero())
                    {
                        MessageBox.Show("Factura guardada", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Factura.ObtenerFacturasLavadero();
                        HabilitarControles(false);
                        CargarDatosComboBox(true, true, false);
                        BindingSource.Position = BindingSource.Count - 1;
                    }
                    else
                        MessageBox.Show("Ha habido un problema al guardar la factura", "Factura no Guardada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(BtnModificarFactura.Tag) == 1)             // Modificamos los datos de la factura.
                {
                    factura = new Factura(2);
                    factura.Id = int.Parse(TxtNumFactura.Text);
                    factura.Fecha = DtFecha.Value;
                    factura.Concepto = TxtConcepto.Text;
                    factura.EstaPagada = CkBoxPagada.Checked;
                    factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                    factura.Iva = decimal.Parse(TxtIva.Text);
                    factura.Total = decimal.Parse(TxtTotalFactura.Text);

                    if (factura.ModificarParaLavadero())
                    {
                        MessageBox.Show("Factura modificada", "Factura Modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Factura.ObtenerFacturasLavadero();
                        HabilitarControles(false);
                        CargarDatosComboBox(false, true, false);
                        BindingSource.Position = BindingSource.Count - 1;
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
            bool hayConcepto = false;
            bool hayBaseImponible = false;
            bool hayIva = false;
            bool hayTotal = false;            

            if (TxtNumFactura.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un número de factura", "Nº de Factura Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayNumFactura = true;

            if (TxtConcepto.Text.Length == 0)            
                MessageBox.Show("Tiene que introducir un concepto", "Concepto Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            else
                hayConcepto = true;

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

            return hayNumFactura && hayConcepto && hayBaseImponible && hayIva && hayTotal;
        }

        private void BtnModificarFactura_Click(object sender, EventArgs e)
        {
            BtnModificarFactura.Tag = 1;
            HabilitarControles(true);
        }

        private void BtnEliminarFactura_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar la factura?", "¿Eliminar Factura?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Factura factura = (Factura)BindingSource.Current;

                if (factura.Eliminar())
                {
                    MessageBox.Show("Factura eliminada", "Factura Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindingSource.DataSource = Factura.ObtenerFacturasLavadero();
                    HabilitarControles(false);
                    CargarDatosComboBox(true, true, false);
                    BindingSource.Position = BindingSource.Count - 1;
                }
                else
                    MessageBox.Show("Ha habido un problema al eliminar la factura", "Factura no Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImprimirFactura_Click(object sender, EventArgs e)
        {
            FrmInfFactLavadero frmInfFactLavadero = new FrmInfFactLavadero(((Factura)BindingSource.Current).Id);
            frmInfFactLavadero.ShowDialog();
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((Factura)BindingSource.Current);
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((Factura)BindingSource.Current);
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((Factura)BindingSource.Current);
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((Factura)BindingSource.Current);
        }

        private void CbNumsFacturas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerFacturaLavaderoPorId((int)CbNumsFacturas.SelectedItem);
            RellenarDatosFactura(factura);
        }

        private void CbFechas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerFacturaGarajePorFecha((DateTime)CbNumsFacturas.SelectedItem);
            RellenarDatosFactura(factura);
        }

        private void CbCliBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerFacturaLavaderoPorIdCliente(((Cliente)CbCliBuscar.SelectedItem).Id);
            RellenarDatosFactura(factura);
        }
    }
}
