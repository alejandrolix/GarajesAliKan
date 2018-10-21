﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Clases;
using GarajesAliKan.DataSets;
using Microsoft.Reporting.WinForms;

namespace GarajesAliKan.Forms.FacturasEInformes
{
    public partial class FrmListadosLavadero : Form
    {
        public FrmListadosLavadero()
        {
            InitializeComponent();
        }

        private void FrmListadosLavaderos_Load(object sender, EventArgs e)
        {
            List<Factura> listaFacturas = Factura.ObtenerFacturasLavaderoInforme();
            DtFacturasLavadero dtFacturasLavadero = new DtFacturasLavadero();

            foreach (Factura factura in listaFacturas)
            {
                dtFacturasLavadero.Tables["facturas"].Rows.Add(factura.Id, factura.Fecha, factura.Cliente.Nombre, factura.Cliente.Direccion, factura.Cliente.Nif,
                                                               factura.Cliente.Alquiler.BaseImponible, factura.Cliente.Alquiler.Iva, factura.Cliente.Alquiler.Total);
            }
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DtFacturasLavadero", dtFacturasLavadero.Tables["facturas"]));
            ReportViewer.RefreshReport();
        }
    }
}