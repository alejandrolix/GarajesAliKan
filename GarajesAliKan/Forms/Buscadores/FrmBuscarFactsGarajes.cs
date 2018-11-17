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
    public partial class FrmBuscarFactsGarajes : Form
    {
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }

        public FrmBuscarFactsGarajes(int idCliente)
        {
            InitializeComponent();            
            IdCliente = idCliente;
        }

        public FrmBuscarFactsGarajes(DateTime fecha)
        {
            InitializeComponent();
            Fecha = fecha;
        }

        /// <summary>
        /// Carga las facturas encontradas a partir del Id de un cliente.
        /// </summary>
        /// <param name="cargarPorIdCliente">Indica si hay que buscar por el Id del cliente.</param>
        private void CargarFacturas(bool cargarPorIdCliente)
        {
            List<FacturaGaraje> facturas = null;
            if (cargarPorIdCliente)
                facturas = FacturaGaraje.ObtenerFacturasPorIdCliente(IdCliente);
            else
                facturas = FacturaGaraje.ObtenerFacturasPorFecha(Fecha);
            
            if (DgvFactsGarajes.Rows.Count >= 1)        // Si hubiesen filas en el DataGridView, las eliminamos.    
                DgvFactsGarajes.Rows.Clear();            

            foreach (FacturaGaraje factura in facturas)
            {
                int posicion = DgvFactsGarajes.Rows.Add();
                DgvFactsGarajes.Rows[posicion].Cells["numFactura"].Value = factura.Id;
                DgvFactsGarajes.Rows[posicion].Cells["fecha"].Value = factura.Fecha.ToShortDateString();
                DgvFactsGarajes.Rows[posicion].Cells["cliente"].Value = factura.Cliente.Nombre;
                DgvFactsGarajes.Rows[posicion].Cells["estaPagada"].Value = factura.EstaPagada is true ? "Sí" : "No";
                DgvFactsGarajes.Rows[posicion].Cells["concepto"].Value = factura.Alquiler.Concepto;
                DgvFactsGarajes.Rows[posicion].Cells["garaje"].Value = factura.Garaje.Nombre;
                DgvFactsGarajes.Rows[posicion].Cells["plaza"].Value = factura.Plaza;
                DgvFactsGarajes.Rows[posicion].Cells["baseImponible"].Value = factura.BaseImponible;
                DgvFactsGarajes.Rows[posicion].Cells["iva"].Value = factura.Iva;
                DgvFactsGarajes.Rows[posicion].Cells["totalFactura"].Value = factura.Total;
            }
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            if (IdCliente >= 1)            
                CargarFacturas(true);            
            else
                CargarFacturas(false);
            
            CompletarDetallesFactura(0);
        }

        private void DtFecha_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// Establece los detalles de la factura seleccionada a sus campos correspondientes.
        /// </summary>
        /// <param name="numFila">El número de la fila.</param>        
        private void CompletarDetallesFactura(int numFila)
        {
            DtFecha.Value = Convert.ToDateTime(DgvFactsGarajes.Rows[numFila].Cells[1].Value);
            CkBoxPagada.Checked = Convert.ToString(DgvFactsGarajes.Rows[numFila].Cells[3].Value) == "Sí" ? true : false;
            TxtBaseImponible.Text = Convert.ToString(DgvFactsGarajes.Rows[numFila].Cells[7].Value);
            TxtIva.Text = Convert.ToString(DgvFactsGarajes.Rows[numFila].Cells[8].Value);
            TxtTotalFactura.Text = Convert.ToString(DgvFactsGarajes.Rows[numFila].Cells[9].Value);
        }

        private void DgvFactsGarajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CompletarDetallesFactura(e.RowIndex);            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                FacturaGaraje factura = new FacturaGaraje();
                foreach (DataGridViewRow fila in DgvFactsGarajes.SelectedRows)                
                    factura.Id = Convert.ToInt32(fila.Cells[0].Value);                                    

                factura.Fecha = DtFecha.Value;
                factura.EstaPagada = CkBoxPagada.Checked;
                factura.BaseImponible = decimal.Parse(TxtBaseImponible.Text);
                factura.Iva = decimal.Parse(TxtIva.Text);
                factura.Total = decimal.Parse(TxtTotalFactura.Text);

                if (factura.Modificar())
                {
                    if (IdCliente >= 1)
                        CargarFacturas(true);
                    else
                        CargarFacturas(false);

                    CompletarDetallesFactura(0);
                    MessageBox.Show("Factura Actualizada", "Factura Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Ha habido un problema al actualizar la factura", "Factura no Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Los datos introducidos no son correctos", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
