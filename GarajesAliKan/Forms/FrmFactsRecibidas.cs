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

namespace GarajesAliKan.Forms
{
    public partial class FrmFactsRecibidas : Form
    {
        public FrmFactsRecibidas()
        {
            InitializeComponent();
        }

        private void FrmFactsRecibida_Load(object sender, EventArgs e)
        {
            CargarDatosComboBox(true, true, true);
            if (Factura.HayFacturasRecibidas())
            {
                BindingSource.DataSource = Factura.ObtenerFacturasRecibidas();
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
        /// <param name="cargarFechas">Indica si hay que cargar las fechas.</param>
        /// <param name="cargarEmpresas">Indica si hay que cargar las empresas.</param>
        /// <param name="cargarGarajes">Indica si hay que cargar los garajes para buscar.</param>
        private void CargarDatosComboBox(bool cargarFechas, bool cargarEmpresas, bool cargarGarajes)
        {            
            if (cargarFechas)
                CbFechas.DataSource = Factura.ObtenerFechasRecibidas();

            if (cargarEmpresas)
            {
                CbEmpBuscar.DataSource = Proveedor.ObtenerNombresEmpresas();
                CbEmpBuscar.DisplayMember = "Empresa";
            }

            if (cargarGarajes)
            {
                CbGjBuscar.DataSource = Garaje.ObtenerGarajes();
                CbGjBuscar.DisplayMember = "Nombre";
                CbGjBuscar.ValueMember = "Id";
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
            CbGarajes.Text = factura.Cliente.Nombre;            
            CbEmpresas.Text = factura.Proveedor.Empresa;

            TxtBaseImponible.Text = factura.BaseImponible.ToString();
            TxtIva.Text = factura.Iva.ToString();
            TxtTotalFactura.Text = factura.Total.ToString();            
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

        private void CbGarajes_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CbFechas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbEmpresas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbGjBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnAddFactura_Click(object sender, EventArgs e)
        {
            BtnAddFactura.Tag = 1;
            CbGarajes.DataSource = Garaje.ObtenerGarajes();
            CbGarajes.DisplayMember = "Nombre";
            CbGarajes.ValueMember = "Id";

            CbEmpresas.DataSource = Proveedor.ObtenerNombresEmpresas();
            CbEmpresas.DisplayMember = "Empresa";
            CbEmpresas.ValueMember = "Id";

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
            CbGarajes.Enabled = habilitar;            
            CbEmpresas.Enabled = habilitar;

            TxtBaseImponible.Enabled = habilitar;
            TxtIva.Enabled = habilitar;            
            TxtTotalFactura.Enabled = habilitar;            

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
            TxtBaseImponible.Clear();
            TxtIva.Clear();
            TxtTotalFactura.Clear();
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
                Factura factura = new Factura(3);
                factura.Id = int.Parse(TxtNumFactura.Text);
                factura.Fecha = DtFecha.Value;
                factura.Proveedor.Id = ((Proveedor)CbEmpresas.SelectedItem).Id;
                factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                factura.Iva = decimal.Parse(TxtIva.Text);
                factura.Total = decimal.Parse(TxtTotalFactura.Text);

                if (Convert.ToInt32(BtnAddFactura.Tag) == 1)                // Insertamos la nueva factura.
                {                                        
                    factura.Garaje.Id = ((Garaje)CbGarajes.SelectedItem).Id;                                                            
                    if (factura.InsertarRecibida())
                    {
                        MessageBox.Show("Factura guardada", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Factura.ObtenerFacturasRecibidas();

                        int pos = ((List<Factura>)BindingSource.DataSource).IndexOf(new Factura(factura.Id));
                        BindingSource.Position = pos;

                        HabilitarControles(false);
                        CargarDatosComboBox(true, true, false);
                        BindingSource.Position = BindingSource.Count - 1;
                    }
                    else
                        MessageBox.Show("Ha habido un problema al guardar la factura", "Factura no Guardada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(BtnModificarFactura.Tag) == 1)             // Modificamos los datos de la factura.
                {                    
                    if (factura.ModificarRecibida())
                    {
                        MessageBox.Show("Factura modificada", "Factura Modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Factura.ObtenerFacturasRecibidas();

                        int pos = ((List<Factura>)BindingSource.DataSource).IndexOf(new Factura(factura.Id));
                        BindingSource.Position = pos;

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
            bool hayBaseImponible = false;
            bool hayIva = false;
            bool hayTotal = false;

            if (TxtNumFactura.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un número de factura", "Nº de Factura Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayNumFactura = true;            

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

            return hayNumFactura && hayBaseImponible && hayIva && hayTotal;
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

        private void CbFechas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Factura factura = Factura.ObtenerFacturaRecibidaPorFecha((DateTime)CbFechas.SelectedItem);
            RellenarDatosFactura(factura);
        }

        private void CbEmpresas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Preguntar.

            //Factura factura = Factura.ObtenerFacturaGarajePorFecha((string)CbEmpresas.SelectedItem);
            //RellenarDatosFactura(factura);
        }

        private void CbGjBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Preguntar.
        }

        private void CbEmpresas_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
