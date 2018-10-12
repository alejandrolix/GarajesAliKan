﻿using System;
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
        public FrmFactsGaraje()
        {
            InitializeComponent();
        }

        private void FrmFactsGaraje_Load(object sender, EventArgs e)
        {
            CargarDatosComboBox(true, true, true);
            if (Factura.HayFacturasGarajes())
            {
                BindingSource.DataSource = Factura.ObtenerFacturasGarajes();                
                RellenarDatosFactura((Factura)BindingSource.Current);
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
                CbClientes.DataSource = Cliente.ObtenerNombresYApellidosGarajes();
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

            CbNumsFacturas.DataSource = Factura.ObtenerIdsFacturasGarajes();
            CbNifs.DataSource = Cliente.ObtenerNifsClientesGarajes();
            CbNifs.DisplayMember = "Nif";
            CbNifs.ValueMember = "Id";

            CbFechas.DataSource = Factura.ObtenerFechasGarajes();
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
            TxtNumFactura.Enabled = BtnModificarFactura.Tag is null ? habilitar : !habilitar;
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

        private void BtnEliminarFactura_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar la factura?", "¿Eliminar Factura?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Factura factura = (Factura)BindingSource.Current;

                if (factura.Eliminar())
                {
                    MessageBox.Show("Factura eliminada", "Factura Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindingSource.DataSource = Factura.ObtenerFacturasGarajes();
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
                Factura factura = null;
                if (Convert.ToInt32(BtnAddFactura.Tag) == 1)                // Insertamos la nueva factura.
                {
                    factura = new Factura(1);
                    factura.Id = int.Parse(TxtNumFactura.Text);
                    factura.Fecha = DtFecha.Value;
                    factura.Cliente.Id = ((Cliente)CbClientes.SelectedItem).Id;
                    factura.EstaPagada = CkBoxPagada.Checked;
                    factura.Cliente.Alquiler.IdTipoAlquiler = ((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler;
                    factura.Garaje.Id = ((Garaje)CbGarajes.SelectedItem).Id;
                    factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                    factura.Iva = decimal.Parse(TxtIva.Text);
                    factura.Total = decimal.Parse(TxtTotalFactura.Text);

                    if (factura.InsertarParaGaraje())
                    {
                        MessageBox.Show("Factura guardada", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Factura.ObtenerFacturasGarajes();
                        HabilitarControles(false);                        
                        CargarDatosComboBox(false, false, false);
                        BindingSource.Position = BindingSource.Count - 1;
                    }
                    else
                        MessageBox.Show("Ha habido un problema al guardar la factura", "Factura no Guardada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(BtnModificarFactura.Tag) == 1)             // Modificamos los datos de la factura.
                {
                    factura = new Factura(1);
                    factura.Id = int.Parse(TxtNumFactura.Text);
                    factura.Fecha = DtFecha.Value;
                    factura.EstaPagada = CkBoxPagada.Checked;
                    factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                    factura.Iva = decimal.Parse(TxtIva.Text);
                    factura.Total = decimal.Parse(TxtTotalFactura.Text);

                    if (factura.ModificarParaGaraje())
                    {
                        MessageBox.Show("Factura modificada", "Factura Modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Factura.ObtenerFacturasGarajes();
                        HabilitarControles(false);                        
                        CargarDatosComboBox(false, false, false);
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
            Factura factura = Factura.ObtenerFacturaGarajePorId((int)CbNumsFacturas.SelectedItem);
            RellenarDatosFactura(factura);
        }

        private void CbNifs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerFacturaGarajePorIdCliente(((Cliente)CbNifs.SelectedItem).Id);
            RellenarDatosFactura(factura);
        }

        private void CbFechas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerFacturaGarajePorFecha((DateTime)CbFechas.SelectedItem);
            RellenarDatosFactura(factura);
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
