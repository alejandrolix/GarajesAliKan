using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Clases;
using System.Text.RegularExpressions;

namespace GarajesAliKan.Forms
{
    public partial class FrmClientesLavadero : Form
    {
        private List<Cliente> ListaClientes;

        public FrmClientesLavadero()
        {
            InitializeComponent();
        }

        private void FrmClientesLavadero_Load(object sender, EventArgs e)
        {
            CargarDatosComboBox();
            if (Cliente.HayClientesLavadero())
            {
                ListaClientes = Cliente.ObtenerClientesLavadero();
                CargarClientesAlDataTable();
                RellenarDatosCliente(ListaClientes[0]);
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
        private void CargarDatosComboBox()
        {
            CbApellidos.DataSource = Cliente.ObtenerApellidosClientesLavadero();
            CbApellidos.DisplayMember = "Apellidos";
            CbApellidos.ValueMember = "Id";
            CbNifs.DataSource = Cliente.ObtenerNifsClientesLavadero();
            CbNifs.DisplayMember = "Nif";
            CbNifs.ValueMember = "Id";
        }

        /// <summary>
        /// Carga los clientes al DataTable.
        /// </summary>        
        private void CargarClientesAlDataTable()
        {
            DataTable dtClientes = new DataTable("clientes");
            dtClientes.Columns.Add("id", typeof(int));
            dtClientes.Columns.Add("nombre", typeof(string));
            dtClientes.Columns.Add("apellidos", typeof(string));
            dtClientes.Columns.Add("nif", typeof(string));
            dtClientes.Columns.Add("direccion", typeof(string));
            dtClientes.Columns.Add("telefono", typeof(string));

            foreach (Cliente cliente in ListaClientes)
            {
                dtClientes.Rows.Add(cliente.Id, cliente.Nombre, cliente.Apellidos, cliente.Nif, cliente.Direccion, cliente.Telefono);
            }
            BindingSource.DataSource = dtClientes;
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
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente(ListaClientes[BindingSource.Position]);
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente(ListaClientes[BindingSource.Position]);
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente(ListaClientes[BindingSource.Position]);
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            RellenarDatosCliente(ListaClientes[BindingSource.Position]);
        }

        private void TxtNif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            BtnAddCliente.Tag = 1;
            HabilitarControles(true);
            TxtNombre.Focus();

            if (ListaClientes != null)
                if (ListaClientes[0].Id != 0)
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
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                Cliente cliente = null;
                HabilitarControles(false);

                if (Convert.ToInt32(BtnAddCliente.Tag) == 1)            // Guardamos el cliente.
                {
                    cliente = new Cliente(TxtNombre.Text, TxtApellidos.Text, TxtDireccion.Text, TxtNif.Text, TxtTelefono.Text, false);
                    if (cliente.Insertar())
                    {
                        MessageBox.Show("Cliente Guardado", "Cliente Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListaClientes = Cliente.ObtenerClientesLavadero();
                        CargarClientesAlDataTable();

                        int pos = ListaClientes.IndexOf(new Cliente(cliente.Id));       // Buscamos la posición del cliente insertado.
                        BindingSource.Position = pos;

                        if (!BtnModificarCliente.Enabled && !BtnEliminarCliente.Enabled)
                        {
                            BtnModificarCliente.Enabled = true;
                            BtnEliminarCliente.Enabled = true;
                        }
                    }
                    else
                        MessageBox.Show("Ha habido un problema al insertar el cliente", "Cliente no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(BtnModificarCliente.Tag) == 1)             // Modificamos sus datos.
                {
                    cliente = new Cliente(ListaClientes[BindingSource.Position].Id, TxtNombre.Text, TxtApellidos.Text, TxtDireccion.Text, TxtNif.Text, TxtTelefono.Text);
                    if (cliente.Modificar())
                        MessageBox.Show("Datos del cliente modificados", "Datos Modificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Regex exprRegTelefono = new Regex("^[0-9]{9}$");
            Regex exprRegNif = new Regex("^[0-9]{8}[A-Z]$");

            if (TxtNombre.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un nombre", "Nombre Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayNombre = true;

            if (TxtApellidos.Text.Length == 0)
                MessageBox.Show("Tiene que introducir unos apellidos", "Apellidos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayApellidos = true;

            if (TxtDireccion.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una dirección", "Dirección Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayDireccion = true;

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

            return hayNombre && hayApellidos && hayNif && hayDireccion && hayTelefono;
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
                Cliente cliente = ListaClientes[BindingSource.Position];
                if (cliente.Eliminar())
                {
                    MessageBox.Show("Cliente eliminado", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaClientes = Cliente.ObtenerClientesLavadero();
                    HabilitarControles(false);
                    CargarClientesAlDataTable();
                    BindingSource.Position = ListaClientes.Count - 1;
                }
                else
                    MessageBox.Show("Ha habido un problema al eliminar el cliente", "Cliente no Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            LimpiarCampos();
            RellenarDatosCliente(ListaClientes[BindingSource.Position]);
            RestaurarTagsBotones();
        }

        private void CbApellidos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.ObtenerClienteLavaderoPorId(((Cliente)CbApellidos.SelectedItem).Id);
            RellenarDatosCliente(cliente);
        }

        private void CbNifs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.ObtenerClienteLavaderoPorId(((Cliente)CbNifs.SelectedItem).Id);
            RellenarDatosCliente(cliente);
        }
    }
}
