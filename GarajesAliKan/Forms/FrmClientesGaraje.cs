using GarajesAliKan.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            List<Cliente> listaClientes = Cliente.ObtenerClientes();
            CargarDatosAlDataTable(listaClientes);
        }

        /// <summary>
        /// Carga los datos de los clientes en un DataTable.
        /// </summary>
        /// <param name="listaClientes">La lista de los clientes.</param>
        private void CargarDatosAlDataTable(List<Cliente> listaClientes)
        {
            DtClientes dtClientes = new DtClientes();
            for (int i = 0; i < listaClientes.Count; i++)
            {
                dtClientes.Tables["Clientes"].Rows.Add(listaClientes[i].Id, listaClientes[i].Nombre, listaClientes[i].Apellidos, listaClientes[i].Nif, listaClientes[i].Direccion, listaClientes[i].Telefono,
                    listaClientes[i].Garaje.Id, listaClientes[i].Garaje.SubId, listaClientes[i].Garaje.Nombre, listaClientes[i].Garaje.Llave,
                    listaClientes[i].Vehiculo.Id, listaClientes[i].Vehiculo.Matricula, listaClientes[i].Vehiculo.Marca, listaClientes[i].Vehiculo.Modelo, listaClientes[i].Vehiculo.Plaza,
                    listaClientes[i].TipoAlquiler.Id, listaClientes[i].TipoAlquiler.Concepto, listaClientes[i].TipoAlquiler.BaseImponible, listaClientes[i].TipoAlquiler.Iva, listaClientes[i].TipoAlquiler.Total,
                    listaClientes[i].Observaciones, listaClientes[i].EsClienteGaraje);
            }
            clientesBindingSource.DataSource = dtClientes.Tables["Clientes"];
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
    }
}
