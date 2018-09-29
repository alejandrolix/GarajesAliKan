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
                dtClientesGarajes.Tables["clientes"].Rows.Add(listaClientes[i].Nombre, listaClientes[i].Apellidos, listaClientes[i].Nif, listaClientes[i].Direccion, listaClientes[i].Telefono,
                    listaClientes[i].Garaje.Nombre, listaClientes[i].Llave,
                    listaClientes[i].Vehiculo.Matricula, listaClientes[i].Vehiculo.Marca, listaClientes[i].Vehiculo.Modelo, listaClientes[i].Vehiculo.Plaza,
                    listaClientes[i].TipoAlquiler.Concepto, listaClientes[i].Vehiculo.BaseImponible, listaClientes[i].Vehiculo.Iva, listaClientes[i].Vehiculo.Total, listaClientes[i].Observaciones);
            }
            clientesBindingSource.DataSource = dtClientesGarajes.Tables["clientes"];
        }

        private void ClientesBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (TxtBaseImponible.Text == "0")
            {
                TxtBaseImponible.Clear();
            }

            if (TxtIva.Text == "0")
            {
                TxtIva.Clear();
            }

            if (TxtTotal.Text == "0")
            {
                TxtTotal.Clear();
            }
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
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

            TxtMarca.Enabled = habilitar;
            TxtModelo.Enabled = habilitar;
            TxtMatricula.Enabled = habilitar;
            TxtLlave.Enabled = habilitar;
            TxtPlaza.Enabled = habilitar;

            CbConceptos.Enabled = habilitar;
            TxtBaseImponible.Enabled = habilitar;
            TxtIva.Enabled = habilitar;
            TxtTotal.Enabled = habilitar;
            CbGarajes.Enabled = habilitar;
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
                Garaje garaje = new Garaje(((Garaje)CbGarajes.SelectedItem).Id);
                Vehiculo vehiculo = new Vehiculo(TxtMatricula.Text, TxtMarca.Text, TxtModelo.Text, decimal.Parse(TxtBaseImponible.Text), decimal.Parse(TxtIva.Text), decimal.Parse(TxtTotal.Text), TxtPlaza.Text);
                TipoAlquiler tipoAlquiler = new TipoAlquiler(((TipoAlquiler)CbConceptos.SelectedItem).Id);

                Cliente cliente = new Cliente(TxtNombre.Text, TxtApellidos.Text, TxtNif.Text, TxtDireccion.Text, TxtTelefono.Text, garaje, TxtObservaciones.Text, int.Parse(TxtLlave.Text), true, vehiculo, tipoAlquiler);
                if (cliente.Insertar())
                {
                    if (tipoAlquiler.Id == 1)       // Si el concepto es "ALQUILER PLAZA DE GARAJE".
                        if (vehiculo.Insertar(cliente.Id))                    
                            MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                        else
                            MessageBox.Show("Ha habido un problema al insertar el vehículo", "Vehículo no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Ha habido un problema al insertar el cliente", "Cliente no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
            }
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
            bool hayMarca = false;
            bool hayModelo = false;
            bool hayMatricula = false;
            bool hayLlave = false;
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

            if (TxtMarca.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una marca del vehículo", "Marca Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayMarca = true;

            if (TxtModelo.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un modelo del vehículo", "Modelo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayModelo = true;

            if (TxtMatricula.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una matrícula del vehículo", "Matrícula Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayMatricula = true;

            if (TxtLlave.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un número de llave", "Llave Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayLlave = true;

            if (TxtPlaza.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una plaza", "Plaza Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayPlaza = true;

            if (TxtBaseImponible.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una base imponible", "Base Imponible Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayBaseImponible = true;

            if (TxtIva.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un I.V.A.", "I.V.A. Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                hayIva = true;

            if (TxtTotal.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un total", "Total Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayTotal = true;
                
            return hayNombre && hayApellidos && hayNif && hayDireccion && hayTelefono && hayMarca && hayModelo && hayMatricula && hayLlave && hayPlaza &&
                hayBaseImponible && hayIva && hayTotal;
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
            LimpiarCampos();
            HabilitarControles(false);
            TxtNombre.Text = ListaClientes[clientesBindingSource.Position].Nombre;
            TxtApellidos.Text = ListaClientes[clientesBindingSource.Position].Apellidos;
            TxtNif.Text = ListaClientes[clientesBindingSource.Position].Nif;
            TxtDireccion.Text = ListaClientes[clientesBindingSource.Position].Direccion;
            TxtTelefono.Text = ListaClientes[clientesBindingSource.Position].Telefono;
            TxtObservaciones.Text = ListaClientes[clientesBindingSource.Position].Observaciones;
            TxtMarca.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Marca;
            TxtModelo.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Modelo;
            TxtMatricula.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Matricula;
            TxtLlave.Text = ListaClientes[clientesBindingSource.Position].Llave.ToString();
            TxtPlaza.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Plaza;
            CbConceptos.Text = ListaClientes[clientesBindingSource.Position].TipoAlquiler.Concepto;
            TxtBaseImponible.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.BaseImponible.ToString();
            TxtIva.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Iva.ToString();
            TxtTotal.Text = ListaClientes[clientesBindingSource.Position].Vehiculo.Total.ToString();
            CbGarajes.Text = ListaClientes[clientesBindingSource.Position].Garaje.Nombre;
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

        private void TxtMatricula_Leave(object sender, EventArgs e)
        {
            Regex exprReg = new Regex("^[0-9]{4} [A-Z]{3}$");

            if (!exprReg.IsMatch(TxtMatricula.Text))
            {
                MessageBox.Show("Formato de matrícula incorrecto", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtMatricula.Clear();
                TxtMatricula.Focus();
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

        }
    }
}
