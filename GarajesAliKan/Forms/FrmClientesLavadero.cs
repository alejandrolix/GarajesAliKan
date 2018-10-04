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
                CargarClientesAlDataTable(ListaClientes);
                RellenarDatosCliente(ListaClientes[0]);
            }
            else
                MessageBox.Show("No hay clientes para mostrar. Introduzca uno.", "No hay Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Carga los datos a los distintos ComboBox.
        /// </summary>
        private void CargarDatosComboBox()
        {
            CbApellidos.DataSource = Cliente.ObtenerApellidos();
            CbApellidos.DisplayMember = "Apellidos";
            CbApellidos.ValueMember = "Id";
            CbNifs.DataSource = Cliente.ObtenerNifs();
            CbNifs.DisplayMember = "Nif";
            CbNifs.ValueMember = "Id";
        }

        /// <summary>
        /// Carga los clientes al DataTable.
        /// </summary>
        /// <param name="listaClientes"></param>
        private void CargarClientesAlDataTable(List<Cliente> listaClientes)
        {
            DataTable dtClientes = new DataTable("clientes");
            dtClientes.Columns.Add("id", typeof(int));
            dtClientes.Columns.Add("nombre", typeof(string));
            dtClientes.Columns.Add("apellidos", typeof(string));
            dtClientes.Columns.Add("nif", typeof(string));
            dtClientes.Columns.Add("direccion", typeof(string));
            dtClientes.Columns.Add("telefono", typeof(string));

            foreach (Cliente cliente in listaClientes)
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

            //if (BtnModificarCliente.Tag is null)
            //{
            //    TxtMarca.Enabled = habilitar;
            //    TxtModelo.Enabled = habilitar;
            //    TxtMatricula.Enabled = habilitar;
            //    TxtLlave.Enabled = habilitar;
            //    TxtPlaza.Enabled = habilitar;
            //    CbConceptos.Enabled = habilitar;
            //    CbGarajes.Enabled = habilitar;
            //}

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
            if (ListaClientes != null)
                if (ComprobarDatosIntroducidos())
                {

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

            return hayNombre && hayApellidos && hayNif && hayDireccion && hayTelefono;
        }
    }
}
