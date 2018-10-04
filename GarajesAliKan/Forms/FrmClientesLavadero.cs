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
    }
}
