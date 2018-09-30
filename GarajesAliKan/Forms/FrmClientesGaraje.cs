using GarajesAliKan.Clases;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GarajesAliKan.Forms
{
    public partial class FrmClientesGaraje : Form
    {
        private List<Cliente> ListaClientes;

        public FrmClientesGaraje()
        {
            InitializeComponent();
        }

        private void FrmClientesGaraje_Load(object sender, EventArgs e)
        {
            if (Cliente.HayClientes())
            {
                ListaClientes = Cliente.ObtenerClientesGarajes();
                CargarDatosAlDataTable(ListaClientes);
            }

            CbConceptos.DataSource = TipoAlquiler.ObtenerConceptos();
            CbConceptos.DisplayMember = "Concepto";
            CbConceptos.ValueMember = "Id";
            CbGarajes.DataSource = Garaje.ObtenerGarajes();
            CbGarajes.DisplayMember = "Nombre";
            CbGarajes.ValueMember = "Id";
            CbPlazas.DataSource = Plaza.ObtenerPlazas();
            CbPlazas.DisplayMember = "NombrePlaza";
            CbPlazas.ValueMember = "IdCliente";
        }

        /// <summary>
        /// Carga los datos de los clientes en un DataTable.
        /// </summary>
        /// <param name="listaClientes">La lista de los clientes.</param>
        private void CargarDatosAlDataTable(List<Cliente> listaClientes)
        {
            DtClientesGarajes dtClientesGarajes = new DtClientesGarajes();
            for (int i = 0; i < listaClientes.Count; i++)
            {
                dtClientesGarajes.Tables["clientes"].Rows.Add(listaClientes[i].Id, listaClientes[i].Nombre, listaClientes[i].Apellidos, listaClientes[i].Nif, listaClientes[i].Direccion, listaClientes[i].Telefono,
                    listaClientes[i].Garaje.Nombre, listaClientes[i].AlquilerPorCliente.Llave,
                    listaClientes[i].Vehiculo.Matricula, listaClientes[i].Vehiculo.Marca, listaClientes[i].Vehiculo.Modelo, listaClientes[i].AlquilerPorCliente.Plaza,
                    listaClientes[i].TipoAlquiler.Concepto, listaClientes[i].AlquilerPorCliente.BaseImponible, listaClientes[i].AlquilerPorCliente.Iva, listaClientes[i].AlquilerPorCliente.Total, listaClientes[i].Observaciones);
            }
            clientesBindingSource.DataSource = dtClientesGarajes.Tables["clientes"];
        }

        private void ClientesBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (TxtLlave.Text == "0")
                TxtLlave.Clear();

            if (TxtBaseImponible.Text == "0")
                TxtBaseImponible.Clear();

            if (TxtIva.Text == "0")
                TxtIva.Clear();

            if (TxtTotal.Text == "0")
                TxtTotal.Clear();
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            BtnAddCliente.Tag = 1;
            HabilitarControles(true);
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
                TipoAlquiler tipoAlquiler = new TipoAlquiler(((TipoAlquiler)CbConceptos.SelectedItem).Id);
                AlquilerPorCliente alqPorCliente = null;
                Vehiculo vehiculo = null;
                Cliente cliente = null;

                if (TxtMarca.Text.Length == 0 && TxtModelo.Text.Length == 0 && TxtMatricula.Text.Length == 0 && TxtLlave.Text.Length == 0)      // Si no hay datos del vehículo, alquila un trastero.                       
                {
                    alqPorCliente = new AlquilerPorCliente(decimal.Parse(TxtBaseImponible.Text), decimal.Parse(TxtIva.Text), decimal.Parse(TxtTotal.Text), TxtPlaza.Text, 0);
                    cliente = new Cliente(TxtNombre.Text, TxtApellidos.Text, TxtNif.Text, TxtDireccion.Text, TxtTelefono.Text, TxtObservaciones.Text, garaje, true, null, tipoAlquiler, alqPorCliente);
                }
                else
                {
                    alqPorCliente = new AlquilerPorCliente(decimal.Parse(TxtBaseImponible.Text), decimal.Parse(TxtIva.Text), decimal.Parse(TxtTotal.Text), TxtPlaza.Text, int.Parse(TxtLlave.Text));
                    vehiculo = new Vehiculo(TxtMatricula.Text, TxtMarca.Text, TxtModelo.Text);
                    cliente = new Cliente(TxtNombre.Text, TxtApellidos.Text, TxtNif.Text, TxtDireccion.Text, TxtTelefono.Text, TxtObservaciones.Text, garaje, true, vehiculo, tipoAlquiler, alqPorCliente);
                }

                if (Convert.ToInt32(BtnAddCliente.Tag) == 1)        // Insertamos el cliente.
                {
                    if (cliente.Insertar())
                    {
                        if (tipoAlquiler.Id == 1)           // Vamos a alquilar una plaza de garaje.
                        {
                            if (vehiculo.Insertar())
                            {
                                alqPorCliente.IdCliente = cliente.Id;
                                alqPorCliente.IdVehiculo = vehiculo.Id;
                                alqPorCliente.IdTipoAlquiler = tipoAlquiler.Id;

                                if (alqPorCliente.Insertar(garaje.Id))
                                {
                                    MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ListaClientes = Cliente.ObtenerClientesGarajes();
                                    HabilitarControles(false);
                                    CargarDatosAlDataTable(ListaClientes);

                                    int pos = ListaClientes.IndexOf(new Cliente(cliente.Id));
                                    clientesBindingSource.Position = pos;
                                }
                            }
                            else
                                MessageBox.Show("Ha habido un problema al insertar el vehículo", "Vehículo no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            alqPorCliente.IdCliente = cliente.Id;
                            alqPorCliente.IdTipoAlquiler = tipoAlquiler.Id;

                            if (alqPorCliente.Insertar(garaje.Id))
                            {
                                MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ListaClientes = Cliente.ObtenerClientesGarajes();
                                HabilitarControles(false);
                                CargarDatosAlDataTable(ListaClientes);

                                int pos = ListaClientes.IndexOf(new Cliente(cliente.Id));
                                clientesBindingSource.Position = pos;
                            }
                        }
                    }
                    else
                        MessageBox.Show("Ha habido un problema al insertar el cliente", "Cliente no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else            // Modificamos los datos del cliente.       
                {
                    if (ComprobarDatosIntroducidos())
                    {
                        alqPorCliente = new AlquilerPorCliente(decimal.Parse(TxtBaseImponible.Text), decimal.Parse(TxtIva.Text), decimal.Parse(TxtTotal.Text));
                        cliente = new Cliente(ListaClientes[clientesBindingSource.Position].Id, TxtNombre.Text, TxtApellidos.Text, TxtNif.Text, TxtDireccion.Text, TxtTelefono.Text, TxtObservaciones.Text, alqPorCliente);

                        if (cliente.Modificar())
                        {
                            if (alqPorCliente.Modificar(cliente.Id))
                            {
                                MessageBox.Show("Datos del cliente modificados", "Datos Modificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Ha habido un problema al modificar los datos del alquiler del cliente", "Datos no Modificados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Ha habido un problema al modificar los datos del cliente", "Datos no Modificados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
            bool hayApellidos = false;
            bool hayNif = false;
            bool hayDireccion = false;
            bool hayTelefono = false;
            bool hayPlaza = false;
            bool hayBaseImponible = false;
            bool hayIva = false;
            bool hayTotal = false;

            if (TxtNombre.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un nombre", "Nombre Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayNombre = true;

            if (TxtApellidos.Text.Length == 0)
                MessageBox.Show("Tiene que introducir unos apellidos", "Apellidos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayApellidos = true;

            if (TxtNif.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un N.I.F.", "N.I.F. Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayNif = true;

            if (TxtDireccion.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una dirección", "Dirección Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayDireccion = true;

            if (TxtTelefono.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un teléfono", "Teléfono Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayTelefono = true;

            if (TxtMatricula.Text.Length == 0 && ((TipoAlquiler)CbConceptos.SelectedItem).Id == 1 && Convert.ToInt32(BtnAddCliente.Tag) == 1)
            {
                MessageBox.Show("Tiene que introducir una matrícula", "Matrícula Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TxtMarca.Text.Length == 0 && TxtModelo.Text.Length == 0 && TxtMatricula.Text.Length != 0 && ((TipoAlquiler)CbConceptos.SelectedItem).Id == 1 && Convert.ToInt32(BtnAddCliente.Tag) == 1)
            {
                Regex exprReg = new Regex("^[0-9]{4} [A-Z]{3}$");

                if (!exprReg.IsMatch(TxtMatricula.Text))
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

            return hayNombre && hayApellidos && hayNif && hayDireccion && hayTelefono && hayPlaza && hayBaseImponible &&
                hayIva && hayTotal;
        }

        private void CbConceptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;           // No escribe nada.
        }

        private void TxtBaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9)
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',')
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))         // Por ejemplo, la tecla de borrar.
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9)
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',')
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))         // Por ejemplo, la tecla de borrar.
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9)
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',')
                e.Handled = false;
            else if (char.IsControl(e.KeyChar))         // Por ejemplo, la tecla de borrar.
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);

            if (Convert.ToInt32(BtnModificarCliente.Tag) != 1)          // No se ha pulsado al botón "Modificar Cliente".
            {
                LimpiarCampos();
                TxtNombre.Text = ListaClientes[clientesBindingSource.Position].Nombre;
                TxtApellidos.Text = ListaClientes[clientesBindingSource.Position].Apellidos;
                TxtNif.Text = ListaClientes[clientesBindingSource.Position].Nif;
                TxtDireccion.Text = ListaClientes[clientesBindingSource.Position].Direccion;
                TxtTelefono.Text = ListaClientes[clientesBindingSource.Position].Telefono;
                TxtObservaciones.Text = ListaClientes[clientesBindingSource.Position].Observaciones;
                TxtMarca.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Marca;
                TxtModelo.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Modelo;
                TxtMatricula.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Matricula;
                TxtLlave.Text = ListaClientes[clientesBindingSource.Position].AlquilerPorCliente.Llave.ToString();
                TxtPlaza.Text = ListaClientes[clientesBindingSource.Position].AlquilerPorCliente.Plaza;
                CbConceptos.Text = ListaClientes[clientesBindingSource.Position].TipoAlquiler.Concepto;
                TxtBaseImponible.Text = ListaClientes[clientesBindingSource.Position].AlquilerPorCliente.BaseImponible.ToString();
                TxtIva.Text = ListaClientes[clientesBindingSource.Position].AlquilerPorCliente.Iva.ToString();
                TxtTotal.Text = ListaClientes[clientesBindingSource.Position].AlquilerPorCliente.Total.ToString();
                CbGarajes.Text = ListaClientes[clientesBindingSource.Position].Garaje.Nombre;
            }
            RestaurarTagsBotones();
        }

        private void TxtNif_Leave(object sender, EventArgs e)
        {
            Regex exprReg = new Regex("^[0-9]{8}[A-Z]$");

            if (!exprReg.IsMatch(TxtNif.Text))
            {
                MessageBox.Show("Formato de N.I.F. incorrecto", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNif.Clear();
                TxtNif.Focus();
            }
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            Regex exprReg = new Regex("^[0-9]{9}$");

            if (!exprReg.IsMatch(TxtTelefono.Text))
            {
                MessageBox.Show("Formato de teléfono incorrecto", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtTelefono.Clear();
                TxtTelefono.Focus();
            }
        }

        private void TxtLlave_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9)
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
            Cliente cliente = new Cliente(ListaClientes[clientesBindingSource.Position].Id);

            if (cliente.Eliminar())
                MessageBox.Show("Cliente eliminado", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ha habido un problema al eliminar el cliente", "Cliente no Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        

        private void CbPlazas_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            Cliente cliente = Cliente.ObtenerClientePorId(((Plaza)CbPlazas.SelectedItem).IdCliente);

            TxtNombre.Text = cliente.Nombre;
            TxtApellidos.Text = cliente.Apellidos;
            TxtNif.Text = cliente.Nif;
            TxtDireccion.Text = cliente.Direccion;
            TxtTelefono.Text = cliente.Telefono;
            TxtObservaciones.Text = cliente.Observaciones;
            TxtMarca.Text = cliente.Vehiculo.Marca;
            TxtModelo.Text = cliente.Vehiculo.Modelo;
            TxtMatricula.Text = cliente.Vehiculo.Matricula;
            TxtLlave.Text = cliente.AlquilerPorCliente.Llave.ToString();
            TxtPlaza.Text = cliente.AlquilerPorCliente.Plaza;
            CbConceptos.Text = cliente.TipoAlquiler.Concepto;
            TxtBaseImponible.Text = cliente.AlquilerPorCliente.BaseImponible.ToString();
            TxtIva.Text = cliente.AlquilerPorCliente.Iva.ToString();
            TxtTotal.Text = cliente.AlquilerPorCliente.Total.ToString();
            CbGarajes.Text = cliente.Garaje.Nombre;
        }
    }
}
