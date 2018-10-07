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
    public partial class FrmFactsGaraje : Form
    {
        private List<Factura> ListaFacturas;

        public FrmFactsGaraje()
        {
            InitializeComponent();
        }

        private void FrmFactsGaraje_Load(object sender, EventArgs e)
        {
            CargarDatosComboBox(true, true, true);
            if (Factura.HayFacturasGarajes())
            {
                ListaFacturas = Factura.ObtenerFacturasGarajes();
            }            
        }

        private void DtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;             
        }

        /// <summary>
        /// Carga los datos a los distintos ComboBox.        
        /// </summary>
        /// <param name="cargarNumFacturas">Indica si hay que cargar los Ids de las facturas.</param>
        /// <param name="cargarNifs">Indica si hay que cargar los NIFs.</param>
        /// <param name="cargarFechas">Indica si hay que cargar las fechas.</param>
        private void CargarDatosComboBox(bool cargarNumFacturas, bool cargarNifs, bool cargarFechas)
        {
            if (cargarNumFacturas)
            {



                //CbConceptos.DataSource = Alquiler.ObtenerConceptos();
                //CbConceptos.DisplayMember = "Concepto";
                //CbConceptos.ValueMember = "IdTipoAlquiler";
                //CbGarajes.DataSource = Garaje.ObtenerGarajes();
                //CbGarajes.DisplayMember = "Nombre";
                //CbGarajes.ValueMember = "Id";
            }

            //if (cargarPlazas)
            //{
            //    CbPlazas.DataSource = Plaza.ObtenerPlazas();
            //    CbPlazas.DisplayMember = "NombrePlaza";
            //    CbPlazas.ValueMember = "IdCliente";
            //}

            //CbApellidos.DataSource = Cliente.ObtenerApellidosClientesGarajes();
            //CbApellidos.DisplayMember = "Apellidos";
            //CbApellidos.ValueMember = "Id";
            //CbNifs.DataSource = Cliente.ObtenerNifsClientesGarajes();
            //CbNifs.DisplayMember = "Nif";
            //CbNifs.ValueMember = "Id";
        }        
    }
}
