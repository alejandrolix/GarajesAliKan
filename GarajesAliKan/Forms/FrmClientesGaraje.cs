using GarajesAliKan.Clases;
using GarajesAliKan.Forms.FacturasEInformes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;

namespace GarajesAliKan.Forms
{
    public partial class FrmClientesGaraje : Form
    {
        public FrmClientesGaraje()
        {
            InitializeComponent();
        }

        private void FrmClientesGaraje_Load(object sender, EventArgs e)
        {
            TtTelefono.SetToolTip(TxtTelefono, "Varios Teléfonos: 123456789 / 123456789 / 123456789");
            TtNif.SetToolTip(TxtNif, "DNI nacional: 12345678N\r\nDNI extranjero: X1234567N");            

            CargarDatosComboBox(true, true);
            if (ClienteGaraje.HayClientes())
            {
                BindingSource.DataSource = ClienteGaraje.ObtenerClientes();
                RellenarDatosCliente((ClienteGaraje)BindingSource.Current);
            }
            else
            {
                MessageBox.Show("No hay clientes para mostrar. Introduzca uno.", "No hay Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnModificarCliente.Enabled = false;
                BtnEliminarCliente.Enabled = false;
                BtnFacturarMes.Enabled = false;
            }
        }

        /// <summary>
        /// Carga los datos a los distintos ComboBox.        
        /// </summary>
        /// <param name="cargarConceptosYGarajes">Indica si hay que cargar los datos de conceptos y garajes.</param>
        /// <param name="cargarPlazas">Indica si hay que cargar los datos de las plazas.</param>
        private void CargarDatosComboBox(bool cargarConceptosYGarajes, bool cargarPlazas)
        {
            if (cargarConceptosYGarajes)
            {
                CbConceptos.DataSource = Alquiler.ObtenerConceptos();
                CbConceptos.DisplayMember = "Concepto";
                CbConceptos.ValueMember = "IdTipoAlquiler";
                CbGarajes.DataSource = Garaje.ObtenerGarajes();
                CbGarajes.DisplayMember = "Nombre";
                CbGarajes.ValueMember = "Id";
            }

            if (cargarPlazas)            
                CbPlazas.DataSource = Alquiler.ObtenerPlazas();                            

            CbApellidos.DataSource = ClienteGaraje.ObtenerApellidosClientes();
            CbApellidos.DisplayMember = "Apellidos";
            CbApellidos.ValueMember = "Id";
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            BtnAddCliente.Tag = 1;
            HabilitarControles(true);
            TxtNombre.Focus();
            ClienteGaraje cliente = (ClienteGaraje)BindingSource.Current;

            if (cliente != null)
                if (cliente.Id != 0)
                    LimpiarCampos();
        }

        /// <summary>
        /// Habilita o deshabilita varios controles.
        /// </summary>
        /// <param name="habilitar">Indica si habilita o deshabilita varios controles.</param>
        private void HabilitarControles(bool habilitar)
        {
            BindingNavigator.Enabled = !habilitar;
            TxtNombre.Enabled = habilitar;
            TxtApellidos.Enabled = habilitar;
            TxtNif.Enabled = habilitar;
            TxtDireccion.Enabled = habilitar;
            TxtTelefono.Enabled = habilitar;
            TxtObservaciones.Enabled = habilitar;

            if (BtnModificarCliente.Tag is null)
            {
                TxtMarca.Enabled = habilitar;
                TxtModelo.Enabled = habilitar;
                TxtMatricula.Enabled = habilitar;
                TxtLlave.Enabled = habilitar;
                TxtPlaza.Enabled = habilitar;
                CbConceptos.Enabled = habilitar;
                CbGarajes.Enabled = habilitar;
            }

            TxtBaseImponible.Enabled = habilitar;
            TxtIva.Enabled = habilitar;
            TxtTotal.Enabled = habilitar;
            PBtnsControl.Enabled = !habilitar;

            BtnGuardar.Enabled = habilitar;
            BtnCancelar.Enabled = habilitar;
            PBuscarPor.Enabled = !habilitar;
        }

        /// <summary>
        /// Limpia los campos dónde se van a introducir datos.
        /// </summary>
        private void LimpiarCampos()
        {
            TxtNombre.Clear();
            TxtApellidos.Clear();
            TxtNif.Clear();
            TxtDireccion.Clear(); ;
            TxtTelefono.Clear();
            TxtObservaciones.Clear();

            TxtMarca.Clear();
            TxtModelo.Clear();
            TxtMatricula.Clear();
            TxtLlave.Clear();
            TxtPlaza.Clear();

            TxtBaseImponible.Clear();
            TxtIva.Clear();
            TxtTotal.Clear();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                Garaje garaje = new Garaje(((Garaje)CbGarajes.SelectedItem).Id, ((Garaje)CbGarajes.SelectedItem).Nombre);
                Alquiler alquiler = new Alquiler();
                alquiler.BaseImponible = decimal.Parse(TxtBaseImponible.Text, CultureInfo.InvariantCulture.NumberFormat);
                alquiler.Iva = decimal.Parse(TxtIva.Text, CultureInfo.InvariantCulture.NumberFormat);
                alquiler.Total = decimal.Parse(TxtTotal.Text, CultureInfo.InvariantCulture.NumberFormat);
                alquiler.Plaza = TxtPlaza.Text;
                alquiler.Llave = int.Parse(TxtLlave.Text);
                alquiler.IdTipoAlquiler = ((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler;

                Vehiculo vehiculo = null;
                ClienteGaraje cliente = new ClienteGaraje();
                cliente.Nombre = TxtNombre.Text;
                cliente.Apellidos = cliente.Apellidos is null ? null : TxtApellidos.Text;
                cliente.Nif = cliente.Nif is null ? null : TxtNif.Text;
                cliente.Direccion = TxtDireccion.Text;
                cliente.Telefono = cliente.Telefono is null ? null : TxtTelefono.Text;
                cliente.Observaciones = TxtObservaciones.Text;
                cliente.Garaje = garaje;
                cliente.Alquiler = alquiler;

                if (CbConceptos.SelectedIndex == 0)      // Alquila una plaza de garaje.                       
                {
                    vehiculo = new Vehiculo(TxtMatricula.Text, TxtMarca.Text, TxtModelo.Text);
                    cliente.Vehiculo = vehiculo;
                }
                HabilitarControles(false);

                if (Convert.ToInt32(BtnAddCliente.Tag) == 1)        // Insertamos el cliente.
                {
                    if (cliente.Insertar())
                    {
                        if (CbConceptos.SelectedIndex == 0)           // Alquilamos una plaza de garaje.
                        {
                            alquiler.IdCliente = cliente.Id;
                            if (vehiculo.Insertar())
                            {
                                alquiler.IdVehiculo = vehiculo.Id;
                                if (alquiler.Insertar(garaje.Id))
                                {
                                    MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BindingSource.DataSource = ClienteGaraje.ObtenerClientes();
                                    CargarDatosComboBox(false, true);

                                    int pos = ((List<ClienteGaraje>)BindingSource.DataSource).IndexOf(new ClienteGaraje(cliente.Id));       // Buscamos la posición del cliente insertado.
                                    BindingSource.Position = pos;

                                    if (!BtnModificarCliente.Enabled && !BtnEliminarCliente.Enabled)
                                    {
                                        BtnModificarCliente.Enabled = true;
                                        BtnEliminarCliente.Enabled = true;
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Ha habido un problema al insertar el vehículo", "Vehículo no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else                // Alquilamos una plaza de trastero.
                        {
                            alquiler.IdCliente = cliente.Id;
                            if (alquiler.Insertar(garaje.Id))
                            {
                                MessageBox.Show("Trastero Guardado", "Trastero Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindingSource.DataSource = ClienteGaraje.ObtenerClientes();
                                CargarDatosComboBox(false, true);

                                int pos = ((List<ClienteGaraje>)BindingSource.DataSource).IndexOf(new ClienteGaraje(cliente.Id));
                                BindingSource.Position = pos;

                                if (!BtnModificarCliente.Enabled && !BtnEliminarCliente.Enabled)
                                {
                                    BtnModificarCliente.Enabled = true;
                                    BtnEliminarCliente.Enabled = true;
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Ha habido un problema al insertar el cliente", "Cliente no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else       // Modificamos los datos del cliente.       
                {
                    cliente.Id = ((ClienteGaraje)BindingSource.Current).Id;
                    if (cliente.Modificar())
                    {
                        if (alquiler.Modificar(cliente.Id))
                        {
                            MessageBox.Show("Datos del cliente modificados", "Datos Modificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatosComboBox(false, false);
                        }
                        else
                            MessageBox.Show("Ha habido un problema al modificar los datos del alquiler del cliente", "Datos no Modificados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Ha habido un problema al modificar los datos del cliente", "Datos no Modificados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RestaurarTagsBotones();
        }

        /// <summary>
        /// Restaura la propiedad "Tag" de los botones de "Añadir Cliente" y "Modificar Cliente".
        /// </summary>
        private void RestaurarTagsBotones()
        {
            if (Convert.ToInt32(BtnAddCliente.Tag) == 1)
                BtnAddCliente.Tag = null;

            if (Convert.ToInt32(BtnModificarCliente.Tag) == 1)
                BtnModificarCliente.Tag = null;
        }

        /// <summary>
        /// Comprueba que los datos introducidos por el usuario sean correctos.
        /// </summary>
        /// <returns>Indica si los datos introducidos son correctos.</returns>        
        private bool ComprobarDatosIntroducidos()
        {
            bool hayNombre = false;
            bool hayDireccion = false;
            bool hayPlaza = false;
            bool hayBaseImponible = false;
            bool hayIva = false;
            bool hayTotal = false;
            Regex exprRegTelefono = new Regex(@"^[0-9]{9}$|^[0-9]{9} \/ [0-9]{9} \/ [0-9]{9}$");
            Regex exprRegNif = new Regex(@"[0-9]{8}[A-Z]{1}$|^X[0-9]{7}[A-Z]{1}$");
            Regex exprRegMatricula = new Regex("^[0-9]{4} [A-Z]{3}$|^[A-Z]{1,2} [0-9]{4} [A-Z]{1,2}$|^[A-Z]{1} [0-9]{4} [A-Z]{1,3}$");

            if (TxtNombre.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un nombre", "Nombre Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayNombre = true;

            if (TxtDireccion.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una dirección", "Dirección Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayDireccion = true;

            if (CbConceptos.SelectedIndex == 0)
            {
                if (TxtMatricula.Text.Length == 0 && CbConceptos.SelectedIndex == 0 && Convert.ToInt32(BtnAddCliente.Tag) == 1)
                {
                    MessageBox.Show("Tiene que introducir una matrícula", "Matrícula Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!exprRegMatricula.IsMatch(TxtMatricula.Text))
                {
                    MessageBox.Show("Formato de matrícula incorrecto", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMatricula.Clear();
                    TxtMatricula.Focus();
                }
            }

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

            if (TxtTotal.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un total", "Total Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayTotal = true;

            return hayNombre && hayDireccion && hayPlaza && hayBaseImponible && hayIva && hayTotal;
        }

        private void CbConceptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;           // No escribe nada.
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

        private void TxtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            LimpiarCampos();
            RellenarDatosCliente((ClienteGaraje)BindingSource.Current);
            RestaurarTagsBotones();
        }

        private void TxtLlave_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.                   
            else
                e.Handled = true;
        }

        private void CbGarajes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnModificarCliente_Click(object sender, EventArgs e)
        {
            BtnModificarCliente.Tag = 1;
            HabilitarControles(true);
        }

        private void BtnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar el cliente?", "¿Eliminar Cliente?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClienteGaraje cliente = (ClienteGaraje)BindingSource.Current;
                if (CbConceptos.SelectedIndex == 0)         // Eliminamos la plaza de garaje.
                {
                    if (cliente.Alquiler.EliminarPorIdCliente(cliente.Id))
                        if (cliente.Vehiculo.Eliminar(cliente.Vehiculo.Id))
                            if (cliente.Eliminar())
                            {
                                MessageBox.Show("Cliente eliminado", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindingSource.DataSource = ClienteGaraje.ObtenerClientes();
                                HabilitarControles(false);
                                CargarDatosComboBox(false, true);
                                BindingSource.Position = BindingSource.Count - 1;
                            }
                            else
                                MessageBox.Show("Ha habido un problema al eliminar el cliente", "Cliente no Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Ha habido un problema el vehículo del cliente", "Vehículo no Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Ha habido un problema la plaza de garaje del cliente", "Plaza Garaje no Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else      // Eliminamos la plaza de trastero.
                {
                    if (cliente.Alquiler.EliminarPorIdCliente(cliente.Id))
                        if (cliente.Eliminar())
                        {
                            MessageBox.Show("Cliente eliminado", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindingSource.DataSource = ClienteGaraje.ObtenerClientes();
                            HabilitarControles(false);
                            CargarDatosComboBox(false, true);
                            BindingSource.Position = BindingSource.Count - 1;
                        }
                        else
                            MessageBox.Show("Ha habido un problema al eliminar el cliente.", "Cliente no Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Ha habido un problema al eliminara plaza de trastero del cliente", "Plaza Trastero no Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CbPlazas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pos = ((List<ClienteGaraje>)BindingSource.DataSource).FindIndex((cliente) => cliente.Alquiler.Plaza == (string)CbPlazas.SelectedValue);            
            BindingSource.Position = pos;
            RellenarDatosCliente(((List<ClienteGaraje>)BindingSource.DataSource)[pos]);
        }

        private void CbApellidos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pos = ((List<ClienteGaraje>)BindingSource.DataSource).IndexOf(new ClienteGaraje(((ClienteGaraje)CbApellidos.SelectedItem).Id));
            BindingSource.Position = pos;
            RellenarDatosCliente(((List<ClienteGaraje>)BindingSource.DataSource)[pos]);
        }

        /// <summary>
        /// Rellena los datos del cliente buscado a sus TextBoxs;
        /// </summary>
        /// <param name="cliente">Los datos del cliente.</param>
        private void RellenarDatosCliente(ClienteGaraje cliente)
        {
            TxtNombre.Text = cliente.Nombre;
            TxtApellidos.Text = cliente.Apellidos;
            TxtNif.Text = cliente.Nif;
            TxtDireccion.Text = cliente.Direccion;
            TxtTelefono.Text = cliente.Telefono;
            TxtObservaciones.Text = cliente.Observaciones;
            TxtMarca.Text = cliente.Vehiculo is null ? null : cliente.Vehiculo.Marca;
            TxtModelo.Text = cliente.Vehiculo is null ? null : cliente.Vehiculo.Modelo;
            TxtMatricula.Text = cliente.Vehiculo is null ? null : cliente.Vehiculo.Matricula;
            TxtLlave.Text = cliente.Alquiler.Llave.ToString();
            TxtPlaza.Text = cliente.Alquiler.Plaza;
            CbConceptos.Text = cliente.Alquiler.Concepto;
            TxtBaseImponible.Text = cliente.Alquiler.BaseImponible.ToString();
            TxtIva.Text = cliente.Alquiler.Iva.ToString();
            TxtTotal.Text = cliente.Alquiler.Total.ToString();
            CbGarajes.Text = cliente.Garaje.Nombre;
        }

        private void BtnFacturarMes_Click(object sender, EventArgs e)
        {
            int idCliente = ((ClienteGaraje)BindingSource.Current).Id;
            List<Alquiler> listaAlquileres = ClienteGaraje.ObtenerIdTipoAlquileresPorIdCliente(idCliente);
            foreach (Alquiler alquiler in listaAlquileres)
            {
                if (alquiler.IdTipoAlquiler == 1)           // Creamos una factura de una plaza de garaje.
                {
                    FrmFactClienteGaraje frmFactClienteGaraje = new FrmFactClienteGaraje(idCliente);
                    frmFactClienteGaraje.ShowDialog();
                }
                else           // Creamos una factura de una plaza de trastero.
                {

                }
            }
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.                   
            else
                e.Handled = true;
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente((ClienteGaraje)BindingSource.Current);
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente((ClienteGaraje)BindingSource.Current);
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente((ClienteGaraje)BindingSource.Current);
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente((ClienteGaraje)BindingSource.Current);
        }

        private void TxtNif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void CbPlazas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbNifs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbConceptos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbConceptos.SelectedIndex == 0)
            {
                if (!TxtMarca.Enabled && !TxtModelo.Enabled && !TxtMatricula.Enabled)
                {
                    TxtMarca.Enabled = true;
                    TxtModelo.Enabled = true;
                    TxtMatricula.Enabled = true;
                }
            }
            else
            {
                TxtMarca.Enabled = false;
                TxtModelo.Enabled = false;
                TxtMatricula.Enabled = false;
            }
        }

        private void TxtNif_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(BtnAddCliente.Tag) == 1)
                if (TxtNif.Text.Length == 9)
                    if (ClienteGaraje.ExisteClientePorNif(TxtNif.Text))
                    {
                        int idCliente = ClienteGaraje.ObtenerIdClientePorNif(TxtNif.Text);
                        ClienteGaraje cliente = ClienteGaraje.ObtenerDatosClientePorId(idCliente);

                        TxtNombre.Text = cliente.Nombre;
                        TxtApellidos.Text = cliente.Apellidos;
                        TxtDireccion.Text = cliente.Direccion;
                        TxtTelefono.Text = cliente.Telefono;
                        TxtObservaciones.Text = cliente.Observaciones;
                    }
                    else
                        MessageBox.Show("El N.I.F. introducido no existe", "Cliente no Existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
