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

namespace GarajesAliKan.Forms.Buscadores
{
    public partial class FrmBuscarFactsRecibida : Form
    {
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }
        public int IdGaraje { get; set; }

        public FrmBuscarFactsRecibida(DateTime fecha)
        {
            InitializeComponent();
            Fecha = fecha;
        }

        public FrmBuscarFactsRecibida(int idProveedor, int idGaraje)
        {
            InitializeComponent();
            IdProveedor = idProveedor;
            IdGaraje = idGaraje;
        }

        private void FrmBuscarFactsRecibida_Load(object sender, EventArgs e)
        {
            CbProveedores.DataSource = Proveedor.ObtenerNombresEmpresas();
            CbProveedores.DisplayMember = "Empresa";
            CbProveedores.ValueMember = "Id";

            CargarFacturas();
            CompletarDetallesFactura(0);
        }

        /// <summary>
        /// Establece los detalles de la factura seleccionada a sus campos correspondientes.
        /// </summary>
        /// <param name="numFila">El número de la fila.</param>        
        private void CompletarDetallesFactura(int numFila)
        {
            DtFecha.Value = Convert.ToDateTime(DgvFactsRecibidas.Rows[numFila].Cells[1].Value);
            CbProveedores.Text = Convert.ToString(DgvFactsRecibidas.Rows[numFila].Cells[3].Value);            
            TxtBaseImponible.Text = Convert.ToString(DgvFactsRecibidas.Rows[numFila].Cells[4].Value);
            TxtIva.Text = Convert.ToString(DgvFactsRecibidas.Rows[numFila].Cells[5].Value);
            TxtTotalFactura.Text = Convert.ToString(DgvFactsRecibidas.Rows[numFila].Cells[6].Value);
        }

        /// <summary>
        /// Carga las facturas encontradas a partir del Id de un cliente.
        /// </summary>
        /// <param name="cargarPorIdCliente">Indica si hay que buscar por el Id del cliente.</param>
        private void CargarFacturas()
        {
            List<FacturaRecibida> facturas = null;
            if (IdProveedor >= 1)
                facturas = FacturaRecibida.ObtenerFacturasPorIdProveedor(IdProveedor);
            else
                facturas = FacturaRecibida.ObtenerFacturasPorIdGaraje(IdGaraje);

            if (DgvFactsRecibidas.Rows.Count >= 1)        // Si hubiesen filas en el DataGridView, las eliminamos.    
                DgvFactsRecibidas.Rows.Clear();

            foreach (FacturaRecibida factura in facturas)
            {
                int posicion = DgvFactsRecibidas.Rows.Add();
                DgvFactsRecibidas.Rows[posicion].Cells["numFactura"].Value = factura.Id;
                DgvFactsRecibidas.Rows[posicion].Cells["fecha"].Value = factura.Fecha.ToShortDateString();
                DgvFactsRecibidas.Rows[posicion].Cells["garaje"].Value = factura.Garaje.Nombre;                
                DgvFactsRecibidas.Rows[posicion].Cells["proveedor"].Value = factura.Proveedor.Empresa;
                DgvFactsRecibidas.Rows[posicion].Cells["baseImponible"].Value = factura.BaseImponible;
                DgvFactsRecibidas.Rows[posicion].Cells["iva"].Value = factura.Iva;
                DgvFactsRecibidas.Rows[posicion].Cells["totalFactura"].Value = factura.Total;
            }
        }

        private void DtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CbProveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void TxtTotalFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            int numPulsado = (int)char.GetNumericValue(e.KeyChar);

            if (numPulsado >= 0 && numPulsado <= 9 || char.IsControl(e.KeyChar))
                e.Handled = false;          // Escribe el número pulsado.                   
            else if (e.KeyChar == ',' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void DgvFactsRecibidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CompletarDetallesFactura(e.RowIndex);
        }

        /// <summary>
        /// Comprueba que los datos introducidos por el usuario sean correctos.
        /// </summary>
        /// <returns>Indica si los datos introducidos son correctos.</returns>        
        private bool ComprobarDatosIntroducidos()
        {
            bool hayBaseImponible = false;
            bool hayIva = false;
            bool hayTotal = false;

            if (TxtBaseImponible.Text.Length == 0)
                MessageBox.Show("Tiene que introducir una base imponible", "Base Imponible Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayBaseImponible = true;

            if (TxtIva.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un I.V.A.", "I.V.A. Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayIva = true;

            if (TxtTotalFactura.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un total", "Total Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayTotal = true;

            return hayBaseImponible && hayIva && hayTotal;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                FacturaRecibida factura = new FacturaRecibida();
                foreach (DataGridViewRow fila in DgvFactsRecibidas.SelectedRows)
                    factura.Id = Convert.ToInt32(fila.Cells[0].Value);

                factura.Fecha = DtFecha.Value;
                factura.Proveedor = new Proveedor();
                factura.Proveedor.Id = ((Proveedor)CbProveedores.SelectedItem).Id;
                factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                factura.Iva = decimal.Parse(TxtIva.Text);
                factura.Total = decimal.Parse(TxtTotalFactura.Text);

                if (factura.Modificar())
                {
                    CargarFacturas();
                    CompletarDetallesFactura(0);
                    MessageBox.Show("Factura Actualizada", "Factura Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Ha habido un problema al actualizar la factura", "Factura no Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Los datos introducidos no son correctos", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
