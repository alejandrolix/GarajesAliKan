using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            CbFechas.DataSource = Factura.ObtenerFechas();
            CbFechas.DisplayMember = "Fecha";
            CbFechas.ValueMember = "Id";
        }

        /// <summary>
        /// Carga los datos de las facturas en un DataTable.
        /// </summary>        
        private void CargarFacturasAlDataTable()
        {
            DataTable dtFacturas = new DataTable("facturas");
            dtFacturas.Columns.Add("id", typeof(int));
            dtFacturas.Columns.Add("fecha", typeof(DateTime));            
            dtFacturas.Columns.Add("nombre", typeof(string));            
            dtFacturas.Columns.Add("concepto", typeof(string));
            dtFacturas.Columns.Add("garaje", typeof(string));
            dtFacturas.Columns.Add("plaza", typeof(string));
            dtFacturas.Columns.Add("baseImponible", typeof(string));
            dtFacturas.Columns.Add("iva", typeof(string));
            dtFacturas.Columns.Add("totalFactura", typeof(string));
            dtFacturas.Columns.Add("estaPagada", typeof(bool));

            foreach (Factura factura in ListaFacturas)
            {
                dtFacturas.Rows.Add(factura.Id, factura.Fecha, factura.Cliente.Nombre, factura.Cliente.Alquiler.Concepto, factura.Garaje.Nombre, factura.Plaza, factura.BaseImponible.ToString(), 
                                    factura.Iva.ToString(), factura.Total.ToString(), factura.EstaPagada);
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
            CbClientes.Enabled = habilitar;
            //TxtNombre.Enabled = habilitar;
            //TxtApellidos.Enabled = habilitar;
            //TxtNif.Enabled = habilitar;

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
            HabilitarControles(false);
            LimpiarCampos();
            RellenarDatosFactura(ListaFacturas[BindingSource.Position]);
            RestaurarTagsBotones();
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
                if (Factura.EliminarPorId(int.Parse(TxtNumFactura.Text)))
                {
                    MessageBox.Show("Factura eliminada", "Factura Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaFacturas = Factura.ObtenerFacturasGarajes();
                    HabilitarControles(false);
                    CargarFacturasAlDataTable();
                    CargarDatosComboBox(false, false, false);
                    BindingSource.Position = ListaFacturas.Count - 1;
                }
                else
                    MessageBox.Show("Ha habido un problema al eliminar la factura", "Factura no Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                Factura factura = new Factura();
                factura.Id = int.Parse(TxtNumFactura.Text);
                factura.Fecha = DtFecha.Value;
                factura.Cliente.Id = ((Cliente)CbClientes.SelectedItem).Id;
                factura.EstaPagada = CkBoxPagada.Checked;
                factura.Cliente.Alquiler.IdTipoAlquiler = ((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler;
                factura.Garaje.Id = ((Garaje)CbGarajes.SelectedItem).Id;
                factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                factura.Iva = decimal.Parse(TxtIva.Text);
                factura.Total = decimal.Parse(TxtTotalFactura.Text);

                if (factura.Insertar())
                {

                }


                //Garaje garaje = new Garaje(((Garaje)CbGarajes.SelectedItem).Id, ((Garaje)CbGarajes.SelectedItem).Nombre);
                //Alquiler alquiler = null;
                //Vehiculo vehiculo = null;
                //Cliente cliente = null;

                //if (TxtMarca.Text.Length == 0 && TxtModelo.Text.Length == 0 && TxtMatricula.Text.Length == 0 && TxtLlave.Text.Length == 0)      // Si no hay datos del vehículo, alquila un trastero.                       
                //{
                //    alquiler = new Alquiler(((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler, decimal.Parse(TxtBaseImponible.Text), decimal.Parse(TxtIva.Text), decimal.Parse(TxtTotal.Text), TxtPlaza.Text, int.Parse(TxtLlave.Text));
                //    cliente = new Cliente(TxtNombre.Text, TxtApellidos.Text, TxtNif.Text, TxtDireccion.Text, TxtTelefono.Text, TxtObservaciones.Text, garaje, true, null, alquiler);
                //}
                //else
                //{
                //    alquiler = new Alquiler(((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler, decimal.Parse(TxtBaseImponible.Text), decimal.Parse(TxtIva.Text), decimal.Parse(TxtTotal.Text), TxtPlaza.Text, int.Parse(TxtLlave.Text));
                //    vehiculo = new Vehiculo(TxtMatricula.Text, TxtMarca.Text, TxtModelo.Text);
                //    cliente = new Cliente(TxtNombre.Text, TxtApellidos.Text, TxtNif.Text, TxtDireccion.Text, TxtTelefono.Text, TxtObservaciones.Text, garaje, true, vehiculo, alquiler);
                //}
                //HabilitarControles(false);

                //if (Convert.ToInt32(BtnAddCliente.Tag) == 1)        // Insertamos el cliente.
                //{
                //    if (cliente.Insertar())
                //    {
                //        if (alquiler.IdTipoAlquiler == 1)           // Vamos a alquilar una plaza de garaje.
                //        {
                //            if (vehiculo.Insertar())
                //            {
                //                alquiler.IdCliente = cliente.Id;
                //                alquiler.IdVehiculo = vehiculo.Id;

                //                if (alquiler.Insertar(garaje.Id))
                //                {
                //                    MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                    ListaClientes = Cliente.ObtenerClientesGarajes();
                //                    CargarClientesAlDataTable();
                //                    CargarDatosComboBox(false, true);

                //                    int pos = ListaClientes.IndexOf(new Cliente(cliente.Id));       // Buscamos la posición del cliente insertado.
                //                    BindingSource.Position = pos;

                //                    if (!BtnModificarCliente.Enabled && !BtnEliminarCliente.Enabled)
                //                    {
                //                        BtnModificarCliente.Enabled = true;
                //                        BtnEliminarCliente.Enabled = true;
                //                    }
                //                }
                //            }
                //            else
                //                MessageBox.Show("Ha habido un problema al insertar el vehículo", "Vehículo no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //        else
                //        {
                //            alquiler.IdCliente = cliente.Id;

                //            if (alquiler.Insertar(garaje.Id))
                //            {
                //                MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                ListaClientes = Cliente.ObtenerClientesGarajes();
                //                CargarClientesAlDataTable();
                //                CargarDatosComboBox(false, true);

                //                int pos = ListaClientes.IndexOf(new Cliente(cliente.Id));
                //                BindingSource.Position = pos;

                //                if (!BtnModificarCliente.Enabled && !BtnEliminarCliente.Enabled)
                //                {
                //                    BtnModificarCliente.Enabled = true;
                //                    BtnEliminarCliente.Enabled = true;
                //                }
                //            }
                //        }
                //    }
                //    else
                //        MessageBox.Show("Ha habido un problema al insertar el cliente", "Cliente no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else       // Modificamos los datos del cliente.       
                //{
                //    alquiler = new Alquiler(decimal.Parse(TxtBaseImponible.Text), decimal.Parse(TxtIva.Text), decimal.Parse(TxtTotal.Text));
                //    cliente = new Cliente(ListaClientes[BindingSource.Position].Id, TxtNombre.Text, TxtApellidos.Text, TxtNif.Text, TxtDireccion.Text, TxtTelefono.Text, TxtObservaciones.Text, alquiler);

                //    if (cliente.Modificar())
                //    {
                //        if (alquiler.Modificar(cliente.Id))
                //        {
                //            MessageBox.Show("Datos del cliente modificados", "Datos Modificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            CargarDatosComboBox(false, false);
                //        }
                //        else
                //            MessageBox.Show("Ha habido un problema al modificar los datos del alquiler del cliente", "Datos no Modificados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    else
                //        MessageBox.Show("Ha habido un problema al modificar los datos del cliente", "Datos no Modificados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
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
            Regex exprRegNif = new Regex("^[0-9]{8}[A-Z]$");

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
    }
}
