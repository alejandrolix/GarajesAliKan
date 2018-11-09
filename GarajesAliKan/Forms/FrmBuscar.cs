using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using GarajesAliKan.Clases;

namespace GarajesAliKan.Forms
{
    public partial class FrmBuscar : Form
    {
        private int NumFormulario;
        private int IdCliente;

        /// <param name="numFormulario">Número que indica de qué formulario viene</param>        
        public FrmBuscar(int numFormulario, int idCliente)
        {
            InitializeComponent();
            NumFormulario = numFormulario;
            IdCliente = idCliente;
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            switch (NumFormulario)
            {
                case 1:         // Viene del Form FrmClientesGaraje.
                    List<string> nombresColumnas = Foo.ObtenerNombresColumnasPorNombreTabla("clientesGarajes");
                    nombresColumnas.Remove("id");
                    nombresColumnas.Add("marca");
                    nombresColumnas.Add("modelo");
                    nombresColumnas.Add("matricula");
                    nombresColumnas.Add("llave");
                    nombresColumnas.Add("plaza");
                    nombresColumnas.Add("concepto");
                    nombresColumnas.Add("baseImponible");
                    nombresColumnas.Add("iva");
                    nombresColumnas.Add("total");
                    nombresColumnas.Add("garaje");

                    foreach (string columna in nombresColumnas)
                    {
                        DataGridView.Columns.Add(columna, columna);                        
                    }
                    ClienteGaraje cliente = ClienteGaraje.ObtenerClientePorId(IdCliente);
                    int posicion = DataGridView.Rows.Add();
                    DataGridView.Rows[posicion].Cells["nombre"].Value = cliente.Nombre;
                    DataGridView.Rows[posicion].Cells["apellidos"].Value = cliente.Apellidos;
                    DataGridView.Rows[posicion].Cells["nif"].Value = cliente.Nif;
                    DataGridView.Rows[posicion].Cells["direccion"].Value = cliente.Direccion;
                    DataGridView.Rows[posicion].Cells["telefono"].Value = cliente.Telefono;
                    DataGridView.Rows[posicion].Cells["observaciones"].Value = cliente.Observaciones;
                    DataGridView.Rows[posicion].Cells["marca"].Value = cliente.Vehiculo.Marca;
                    DataGridView.Rows[posicion].Cells["modelo"].Value = cliente.Vehiculo.Modelo;
                    DataGridView.Rows[posicion].Cells["matricula"].Value = cliente.Vehiculo.Matricula;
                    DataGridView.Rows[posicion].Cells["llave"].Value = cliente.Alquiler.Llave;
                    DataGridView.Rows[posicion].Cells["plaza"].Value = cliente.Alquiler.Plaza;
                    DataGridView.Rows[posicion].Cells["concepto"].Value = cliente.Alquiler.Concepto;
                    DataGridView.Rows[posicion].Cells["baseImponible"].Value = cliente.Alquiler.BaseImponible;
                    DataGridView.Rows[posicion].Cells["iva"].Value = cliente.Alquiler.Iva;
                    DataGridView.Rows[posicion].Cells["total"].Value = cliente.Alquiler.Total;
                    DataGridView.Rows[posicion].Cells["garaje"].Value = cliente.Garaje.Nombre;

                    break;
            }
        }
    }
}
