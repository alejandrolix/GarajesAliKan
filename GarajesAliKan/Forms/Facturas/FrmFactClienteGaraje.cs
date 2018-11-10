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
using Microsoft.Reporting.WinForms;

namespace GarajesAliKan.Forms.FacturasEInformes
{
    public partial class FrmFactClienteGaraje : Form
    {
        private int IdCliente;

        public FrmFactClienteGaraje(int idCliente)
        {
            InitializeComponent();
            IdCliente = idCliente;
        }

        private void FrmFactClienteGaraje_Load(object sender, EventArgs e)
        {
            int numFactura = FacturaGaraje.ObtenerNumFactura();
            ClienteGaraje cliente = ClienteGaraje.ObtenerDatosClientePorIdParaFactura(IdCliente);

            ReportParameterCollection listaParametros = new ReportParameterCollection();
            listaParametros.Add(new ReportParameter("numFactura", numFactura.ToString()));
            listaParametros.Add(new ReportParameter("fecha", DateTime.Now.ToString()));
            listaParametros.Add(new ReportParameter("nombre", cliente.Nombre));
            listaParametros.Add(new ReportParameter("nif", cliente.Nif));
            listaParametros.Add(new ReportParameter("direccion", cliente.Direccion));
            listaParametros.Add(new ReportParameter("telefono", cliente.Telefono));
            listaParametros.Add(new ReportParameter("marca", cliente.Vehiculo.Marca));
            listaParametros.Add(new ReportParameter("modelo", cliente.Vehiculo.Modelo));
            listaParametros.Add(new ReportParameter("matricula", cliente.Vehiculo.Matricula));
            listaParametros.Add(new ReportParameter("baseImponible", cliente.Alquiler.BaseImponible.ToString()));
            listaParametros.Add(new ReportParameter("iva", cliente.Alquiler.Iva.ToString()));
            listaParametros.Add(new ReportParameter("totalFactura", cliente.Alquiler.Total.ToString()));

            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.SetParameters(listaParametros);
            ReportViewer.RefreshReport();
        }
    }
}
