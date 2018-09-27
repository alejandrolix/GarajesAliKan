using GarajesAliKan.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
                    listaClientes[i].Alquiler.Id, listaClientes[i].Alquiler.Concepto, listaClientes[i].Alquiler.BaseImponible, listaClientes[i].Alquiler.Iva, listaClientes[i].Alquiler.Total,
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
            TxtDireccion.Clear();;
            TxtTelefono.Clear();
            TxtObservaciones.Clear();

            TxtMarca.Clear();
            TxtModelo.Clear();
            TxtMatricula.Clear();
            TxtLlave.Clear();
            TxtPlaza.Clear();

            CbConceptos.Text = "";
            TxtBaseImponible.Clear();
            TxtIva.Clear();
            TxtTotal.Clear();
            CbGarajes.Text = "";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                // Guardar Cliente.
            }
        }

        /// <summary>
        /// Comprueba que los datos introducidos por el usuario sean correctos.
        /// </summary>
        /// <returns>Indica si los datos introducidos son correctos.</returns>        
        private bool ComprobarDatosIntroducidos()
        {
            bool datosCorrectos = false;

            if (TxtNombre.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un nombre", "Nombre Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else            
                datosCorrectos = true;

            if (TxtApellidos.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir unos apellidos", "Apellidos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else
                datosCorrectos = true;

            if (TxtNif.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un N.I.F.", "N.I.F. Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else
                datosCorrectos = true;

            if (TxtDireccion.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir una dirección", "Dirección Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else
                datosCorrectos = true;

            if (TxtTelefono.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un teléfono", "Teléfono Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else
                datosCorrectos = true;

            if (TxtMarca.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir una marca del vehículo", "Marca Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else            
                datosCorrectos = true;            

            if (TxtModelo.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un modelo del vehículo", "Modelo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else            
                datosCorrectos = true;                    

            if (TxtMatricula.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir una matrícula del vehículo", "Matrícula Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else            
                datosCorrectos = true;            

            if (TxtLlave.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un número de llave", "Llave Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else            
                datosCorrectos = true;            

            if (TxtPlaza.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir una plaza", "Plaza Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }
            else            
                datosCorrectos = true;            

            if (TxtBaseImponible.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir una base imponible", "Base Imponible Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }            
            else            
                datosCorrectos = true;            

            if (TxtIva.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un I.V.A.", "I.V.A. Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }            
            else            
                datosCorrectos = true;            

            if (TxtTotal.Text.Length == 0)
            {
                MessageBox.Show("Tiene que introducir un total", "Total Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datosCorrectos = false;
            }            
            else            
                datosCorrectos = true;            

            return datosCorrectos;
        }

        private void CbConceptos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;           // No escribe nada.
        }

        private void TxtBaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int) char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9)            
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',')            
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
            else
                e.Handled = true;
        }
    }
}
