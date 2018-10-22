using GarajesAliKan.Clases;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

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
            CargarDatosComboBox(true, true);
            if (Cliente.HayClientesGarajes())
            {
                BindingSource.DataSource = Cliente.ObtenerClientesGarajes();                
                RellenarDatosCliente((Cliente)BindingSource.Current);
            }
            else
            {
                MessageBox.Show("No hay clientes para mostrar. Introduzca uno.", "No hay Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnModificarCliente.Enabled = false;
                BtnEliminarCliente.Enabled = false;
            }
        }

        /// <summary>
        /// Carga los datos a los distintos ComboBox.        
        /// </summary>
        /// <param name="cargarConceptosYGarajes">Indica si hay que cargar los datos de conceptos y garajes.</param>
        /// <param name="cargarPlazas">Indica si que cargar los datos de las plazas.</param>
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
            {
                CbPlazas.DataSource = Plaza.ObtenerPlazas();
                CbPlazas.DisplayMember = "NombrePlaza";
                CbPlazas.ValueMember = "IdCliente";
            }

            CbApellidos.DataSource = Cliente.ObtenerApellidosClientesGarajes();
            CbApellidos.DisplayMember = "Apellidos";
            CbApellidos.ValueMember = "Id";
            CbNifs.DataSource = Cliente.ObtenerNifsClientesGarajes();
            CbNifs.DisplayMember = "Nif";
            CbNifs.ValueMember = "Id";
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            BtnAddCliente.Tag = 1;
            HabilitarControles(true);
            TxtNombre.Focus();
            Cliente cliente = (Cliente)BindingSource.Current;

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
                alquiler.IdTipoAlquiler = ((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler;
                alquiler.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                alquiler.Iva = decimal.Parse(TxtIva.Text);
                alquiler.Total = decimal.Parse(TxtTotal.Text);
                alquiler.Plaza = TxtPlaza.Text;
                alquiler.Llave = int.Parse(TxtLlave.Text);

                Vehiculo vehiculo = null;
                Cliente cliente = new Cliente();
                cliente.Nombre = TxtNombre.Text;
                cliente.Apellidos = TxtApellidos.Text;
                cliente.Nif = TxtNif.Text;
                cliente.Direccion = TxtDireccion.Text;
                cliente.Telefono = TxtTelefono.Text;
                cliente.Observaciones = TxtObservaciones.Text;
                cliente.Garaje = garaje;
                cliente.EsClienteGaraje = true;
                cliente.Alquiler = alquiler;

                if (TxtMarca.Text.Length != 0 && TxtModelo.Text.Length != 0 && TxtMatricula.Text.Length != 0 && TxtLlave.Text.Length != 0)      // Alquila una plaza de garaje.                       
                {
                    vehiculo = new Vehiculo(TxtMatricula.Text, TxtMarca.Text, TxtModelo.Text);                    
                    cliente.Vehiculo = vehiculo;                    
                }
                HabilitarControles(false);

                if (Convert.ToInt32(BtnAddCliente.Tag) == 1)        // Insertamos el cliente.
                {
                    if (cliente.Insertar())
                    {
                        if (alquiler.IdTipoAlquiler == 1)           // Vamos a alquilar una plaza de garaje.
                        {
                            if (vehiculo.Insertar())
                            {
                                alquiler.IdCliente = cliente.Id;
                                alquiler.IdVehiculo = vehiculo.Id;
                                if (alquiler.Insertar(garaje.Id))
                                {
                                    MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BindingSource.DataSource = Cliente.ObtenerClientesGarajes();                                    
                                    CargarDatosComboBox(false, true);

                                    int pos = ((List<Cliente>)BindingSource.DataSource).IndexOf(new Cliente(cliente.Id));       // Buscamos la posición del cliente insertado.
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
                        else
                        {
                            alquiler.IdCliente = cliente.Id;
                            if (alquiler.Insertar(garaje.Id))
                            {
                                MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindingSource.DataSource = Cliente.ObtenerClientesGarajes();                                
                                CargarDatosComboBox(false, true);

                                int pos = ((List<Cliente>)BindingSource.DataSource).IndexOf(new Cliente(cliente.Id));
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
                    cliente.Id = ((Cliente)BindingSource.Current).Id;
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
            bool hayApellidos = false;
            bool hayNif = false;
            bool hayDireccion = false;
            bool hayTelefono = false;
            bool hayPlaza = false;
            bool hayBaseImponible = false;
            bool hayIva = false;
            bool hayTotal = false;
            Regex exprRegTelefono = new Regex("^[0-9]{9}$");
            Regex exprRegNif = new Regex("^[0-9]{8}[A-Z]$");
            Regex exprRegMatricula = new Regex("^[0-9]{4} [A-Z]{3}$");

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
            else if (!exprRegNif.IsMatch(TxtNif.Text))
            {
                MessageBox.Show("Formato de N.I.F. incorrecto", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtNif.Clear();
                TxtNif.Focus();
            }
            else
                hayNif = true;

            if (TxtDireccion.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una dirección", "Dirección Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayDireccion = true;

            if (TxtTelefono.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un teléfono", "Teléfono Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!exprRegTelefono.IsMatch(TxtTelefono.Text))
            {
                MessageBox.Show("Formato de teléfono incorrecto", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtTelefono.Clear();
                TxtTelefono.Focus();
            }
            else
                hayTelefono = true;

            if (TxtMatricula.Text.Length == 0 && ((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler == 1 && Convert.ToInt32(BtnAddCliente.Tag) == 1)
            {
                MessageBox.Show("Tiene que introducir una matrícula", "Matrícula Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (TxtMarca.Text.Length == 0 && TxtModelo.Text.Length == 0 && TxtMatricula.Text.Length != 0 && ((Alquiler)CbConceptos.SelectedItem).IdTipoAlquiler == 1 && Convert.ToInt32(BtnAddCliente.Tag) == 1)
            {
                if (!exprRegMatricula.IsMatch(TxtMatricula.Text))
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
            RellenarDatosCliente((Cliente)BindingSource.Current);
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
                Cliente cliente = (Cliente)BindingSource.Current;
                if (CbConceptos.SelectedIndex == 0)         // Eliminamos la plaza de garaje.
                {                    
                    if (cliente.Alquiler.EliminarPorIdCliente(cliente.Id))
                        if (cliente.Vehiculo.Eliminar(cliente.Vehiculo.Id))
                            if (cliente.Eliminar())
                            {
                                MessageBox.Show("Cliente eliminado", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindingSource.DataSource = Cliente.ObtenerClientesGarajes();
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
                            BindingSource.DataSource = Cliente.ObtenerClientesGarajes();
                            HabilitarControles(false);                            
                            CargarDatosComboBox(false, true);
                            BindingSource.Position = BindingSource.Count - 1;
                        }
                        else
                            MessageBox.Show("Ha habido un problema al eliminar el cliente.", "Cliente no Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Ha habido un problema la plaza de trastero del cliente", "Plaza Trastero no Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CbPlazas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.ObtenerClienteGarajePorId(((Plaza)CbPlazas.SelectedItem).IdCliente);
            RellenarDatosCliente(cliente);
        }

        private void CbApellidos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.ObtenerClienteGarajePorId(((Cliente)CbApellidos.SelectedItem).Id);
            RellenarDatosCliente(cliente);
        }

        /// <summary>
        /// Rellena los datos del cliente buscado a sus TextBoxs;
        /// </summary>
        /// <param name="cliente">Los datos del cliente.</param>
        private void RellenarDatosCliente(Cliente cliente)
        {
            TxtNombre.Text = cliente.Nombre;
            TxtApellidos.Text = cliente.Apellidos;
            TxtNif.Text = cliente.Nif;
            TxtDireccion.Text = cliente.Direccion;
            TxtTelefono.Text = cliente.Telefono;
            TxtObservaciones.Text = cliente.Observaciones;
            TxtMarca.Text = cliente.Vehiculo.Marca;
            TxtModelo.Text = cliente.Vehiculo.Modelo;
            TxtMatricula.Text = cliente.Vehiculo.Matricula;
            TxtLlave.Text = cliente.Alquiler.Llave.ToString();
            TxtPlaza.Text = cliente.Alquiler.Plaza;
            CbConceptos.Text = cliente.Alquiler.Concepto;
            TxtBaseImponible.Text = cliente.Alquiler.BaseImponible.ToString();
            TxtIva.Text = cliente.Alquiler.Iva.ToString();
            TxtTotal.Text = cliente.Alquiler.Total.ToString();
            CbGarajes.Text = cliente.Garaje.Nombre;
        }

        private void CbNifs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.ObtenerClienteGarajePorId(((Cliente)CbNifs.SelectedItem).Id);
            RellenarDatosCliente(cliente);
        }

        private void BtnFacturarMes_Click(object sender, EventArgs e)
        {
            // Preguntar.
            // Implementar.
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
            RellenarDatosCliente((Cliente)BindingSource.Current);
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente((Cliente)BindingSource.Current);
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente((Cliente)BindingSource.Current);
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente((Cliente)BindingSource.Current);
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

        private void TxtPlaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == ' ' || char.IsControl(e.KeyChar))            
                e.Handled = false;            
            else
                e.Handled = true;
        }        
    }
}
