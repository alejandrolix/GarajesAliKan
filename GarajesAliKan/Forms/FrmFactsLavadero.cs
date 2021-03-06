﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarajesAliKan.Clases;
using System.Windows.Forms;
using GarajesAliKan.Forms.Facturas;
using GarajesAliKan.Forms.Buscadores;

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
            if (FacturaLavadero.HayFacturas())
            {
                BindingSource.DataSource = FacturaLavadero.ObtenerFacturas();
                RellenarDatosFactura((FacturaLavadero)BindingSource.Current);
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
                CbNumsFacturas.DataSource = FacturaLavadero.ObtenerIdsFacturas();                            

            if (cargarFechas)            
                CbFechas.DataSource = FacturaLavadero.ObtenerFechas();            

            if (cargarClientes)
            {
                CbCliBuscar.DataSource = ClienteLavadero.ObtenerNombresYApellidos();
                CbCliBuscar.DisplayMember = "Nombre";
                CbCliBuscar.ValueMember = "Id";                
            }                        
        }

        /// <summary>
        /// Rellena los datos de la factura a su campo correspondiente.
        /// </summary>
        /// <param name="factura">Los datos de la factura.</param>
        private void RellenarDatosFactura(FacturaLavadero factura)
        {
            TxtNumFactura.Text = factura.Id.ToString();
            DtFecha.Value = factura.Fecha;                      
            CbClientes.Text = factura.Cliente.Nombre;
            TxtConcepto.Text = factura.Concepto;
            
            TxtBaseImponible.Text = factura.BaseImponible.ToString();
            TxtIva.Text = factura.Iva.ToString();
            TxtTotalFactura.Text = factura.Total.ToString();
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
            CbClientes.DataSource = ClienteGaraje.ObtenerNombresYApellidos();
            CbClientes.DisplayMember = "Nombre";
            CbClientes.ValueMember = "Id";

            HabilitarControles(true);
            TxtNumFactura.Focus();
            FacturaLavadero factura = (FacturaLavadero)BindingSource.Current;

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
            RellenarDatosFactura((FacturaLavadero)BindingSource.Current);
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
                FacturaLavadero factura = null;
                if (Convert.ToInt32(BtnAddFactura.Tag) == 1)                // Insertamos la nueva factura.
                {
                    factura = new FacturaLavadero();
                    factura.Id = int.Parse(TxtNumFactura.Text);
                    factura.Fecha = DtFecha.Value;
                    factura.Cliente.Id = ((ClienteLavadero)CbClientes.SelectedItem).Id;
                    factura.Concepto = TxtConcepto.Text;
                    factura.EstaPagada = CkBoxPagada.Checked;                    
                    factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                    factura.Iva = decimal.Parse(TxtIva.Text);
                    factura.Total = decimal.Parse(TxtTotalFactura.Text);

                    if (factura.Insertar())
                    {
                        MessageBox.Show("Factura guardada", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = FacturaLavadero.ObtenerFacturas();

                        int pos = ((List<FacturaLavadero>)BindingSource.DataSource).IndexOf(new FacturaLavadero(factura.Id));
                        BindingSource.Position = pos;

                        HabilitarControles(false);
                        CargarDatosComboBox(true, true, false);                        
                    }
                    else
                        MessageBox.Show("Ha habido un problema al guardar la factura", "Factura no Guardada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(BtnModificarFactura.Tag) == 1)             // Modificamos los datos de la factura.
                {
                    factura = new FacturaLavadero();
                    factura.Id = int.Parse(TxtNumFactura.Text);
                    factura.Fecha = DtFecha.Value;
                    factura.Concepto = TxtConcepto.Text;
                    factura.EstaPagada = CkBoxPagada.Checked;
                    factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                    factura.Iva = decimal.Parse(TxtIva.Text);
                    factura.Total = decimal.Parse(TxtTotalFactura.Text);

                    if (factura.Modificar())
                    {
                        MessageBox.Show("Factura modificada", "Factura Modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = FacturaLavadero.ObtenerFacturas();

                        int pos = ((List<FacturaLavadero>)BindingSource.DataSource).IndexOf(new FacturaLavadero(factura.Id));
                        BindingSource.Position = pos;

                        HabilitarControles(false);
                        CargarDatosComboBox(false, true, false);                        
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
                FacturaLavadero factura = (FacturaLavadero)BindingSource.Current;

                if (factura.Eliminar())
                {
                    MessageBox.Show("Factura eliminada", "Factura Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindingSource.DataSource = FacturaLavadero.ObtenerFacturas();
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
            FrmFactLavadero frmInfFactLavadero = new FrmFactLavadero(((FacturaLavadero)BindingSource.Current).Id);
            frmInfFactLavadero.ShowDialog();
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaLavadero)BindingSource.Current);
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaLavadero)BindingSource.Current);
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaLavadero)BindingSource.Current);
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            RellenarDatosFactura((FacturaLavadero)BindingSource.Current);
        }

        private void CbNumsFacturas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FacturaLavadero factura = FacturaLavadero.ObtenerFacturaPorId((int)CbNumsFacturas.SelectedItem);
            RellenarDatosFactura(factura);
        }

        private void CbFechas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FrmBuscarFactsRecibidas frmBuscarFactsLavadero = new FrmBuscarFactsRecibidas((DateTime)CbFechas.SelectedItem);
            frmBuscarFactsLavadero.ShowDialog();

            int posicion = BindingSource.Position;
            BindingSource.DataSource = FacturaLavadero.ObtenerFacturas();
            BindingSource.Position = posicion;
        }

        private void CbCliBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FrmBuscarFactsRecibidas frmBuscarFactsLavadero = new FrmBuscarFactsRecibidas(((ClienteLavadero)CbCliBuscar.SelectedItem).Id);
            frmBuscarFactsLavadero.ShowDialog();

            int posicion = BindingSource.Position;
            BindingSource.DataSource = FacturaLavadero.ObtenerFacturas();
            BindingSource.Position = posicion;
        }
    }
}
