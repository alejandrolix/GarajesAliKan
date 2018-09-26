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
    public partial class FrmClientesGaraje : Form
    {        
        public FrmClientesGaraje()
        {
            InitializeComponent();
        }
        
        private void FrmClientesGaraje_Load(object sender, EventArgs e)
        {
            List<Cliente> listaClientes = Cliente.ObtenerClientes();            
            DtClientes dtClientes = new DtClientes();
            for (int i = 0; i < listaClientes.Count; i++)               // Añadimos los datos al DataTable.
            {
                dtClientes.Tables["Clientes"].Rows.Add(listaClientes[i].Id, listaClientes[i].Nombre, listaClientes[i].Apellidos, listaClientes[i].Nif,
                    listaClientes[i].Direccion, listaClientes[i].Telefono, listaClientes[i].Observaciones, listaClientes[i].LlaveMando, listaClientes[i].Garaje.Nombre);
            }
            clientesBindingSource.DataSource = dtClientes.Tables["Clientes"];
            CbGarajes.DataSource = Garaje.ObtenerGarajes();
            CbGarajes.DisplayMember = "Nombre";
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
        }

        /// <summary>
        /// Habilita varios controles.
        /// </summary>
        /// <param name="habilitar">Habilita o deshabilita los controles</param>
        private void HabilitarControles(bool habilitar)
        {
            TxtNombre.Enabled = habilitar;            
            TxtApellidos.Enabled = habilitar;            
            TxtNif.Enabled = habilitar;            
            TxtDireccion.Enabled = habilitar;            
            TxtTelefono.Enabled = habilitar;            
            CbGarajes.Enabled = habilitar;            
            TxtObservaciones.Enabled = habilitar;            
            TxtLlaveMando.Enabled = habilitar;            
            BindingNavigator.Enabled = !habilitar;
            BtnModificarCliente.Enabled = !habilitar;
            BtnEliminarCliente.Enabled = !habilitar;
            BtnGuardar.Enabled = habilitar;
            BtnCancelar.Enabled = habilitar;
        }

        /// <summary>
        /// Limpia varios campos.
        /// </summary>
        private void LimpiarCampos()
        {
            TxtNombre.Clear();
            TxtApellidos.Clear();
            TxtNif.Clear();
            TxtDireccion.Clear();
            TxtTelefono.Clear();
            CbGarajes.Text = "";
            TxtObservaciones.Clear();
            TxtLlaveMando.Clear();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
