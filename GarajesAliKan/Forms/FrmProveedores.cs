using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarajesAliKan.Clases;

namespace GarajesAliKan.Forms
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            if (Proveedor.ExistenProveedores())
            {
                BindingSource.DataSource = Proveedor.ObtenerProveedores();
                RellenarDatosProveedor((Proveedor)BindingSource.Current);
            }
            else
            {
                MessageBox.Show("No hay proveedores para mostrar. Introduzca uno.", "No hay Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnModificarProveedor.Enabled = false;
                BtnEliminarProveedor.Enabled = false;
            }            
        }

        private void TxtCif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// Rellena los datos del proveedor a su campo correspondiente.
        /// </summary>
        /// <param name="proveedor">Los datos del proveedor.</param>
        private void RellenarDatosProveedor(Proveedor proveedor)
        {
            TxtEmpresa.Text = proveedor.Empresa;
            TxtCif.Text = proveedor.Cif;
            TxtConcepto.Text = proveedor.Concepto;
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            RellenarDatosProveedor((Proveedor)BindingSource.Current);
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            RellenarDatosProveedor((Proveedor)BindingSource.Current);
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            RellenarDatosProveedor((Proveedor)BindingSource.Current);
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            RellenarDatosProveedor((Proveedor)BindingSource.Current);
        }

        private void BtnAddProveedor_Click(object sender, EventArgs e)
        {
            BtnAddProveedor.Tag = 1;

            HabilitarControles(true);
            TxtEmpresa.Focus();
            Proveedor proveedor = (Proveedor)BindingSource.Current;

            if (proveedor != null)
                if (proveedor.Id != 0)
                    LimpiarCampos();
        }

        /// <summary>
        /// Habilita o deshabilita varios controles.
        /// </summary>
        /// <param name="habilitar">Indica si habilita o deshabilita varios controles.</param>
        private void HabilitarControles(bool habilitar)
        {
            BindingNavigator.Enabled = !habilitar;
            TxtEmpresa.Enabled = habilitar;
            TxtCif.Enabled = habilitar;
            TxtConcepto.Enabled = habilitar;

            PBotonesControl.Enabled = !habilitar;
            BtnGuardar.Enabled = habilitar;
            BtnCancelar.Enabled = habilitar;            
        }

        /// <summary>
        /// Limpia los campos dónde se van a introducir datos.
        /// </summary>
        private void LimpiarCampos()
        {
            TxtEmpresa.Clear();            
            TxtCif.Clear();
            TxtConcepto.Clear();            
        }

        private void BtnModificarProveedor_Click(object sender, EventArgs e)
        {
            BtnModificarProveedor.Tag = 1;            
            HabilitarControles(true);
        }

        private void BtnEliminarProveedor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar el proveedor?", "¿Eliminar Proveedor?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Proveedor proveedor = (Proveedor)BindingSource.Current;
                if (proveedor.Eliminar())
                {
                    MessageBox.Show("Proveedor eliminado", "Proveedor Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindingSource.DataSource = Proveedor.ObtenerProveedores();
                    HabilitarControles(false);                    
                    BindingSource.Position = BindingSource.Count - 1;
                }
                else
                    MessageBox.Show("Ha habido un problema al eliminar el proveedor", "Proveedor no Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            RestaurarTagsBotones();
            HabilitarControles(false);
            RellenarDatosProveedor((Proveedor)BindingSource.Current);
        }

        /// <summary>
        /// Restaura la propiedad "Tag" de los botones de "Añadir Cliente" y "Modificar Cliente".
        /// </summary>
        private void RestaurarTagsBotones()
        {
            if (Convert.ToInt32(BtnAddProveedor.Tag) == 1)
                BtnAddProveedor.Tag = null;

            if (Convert.ToInt32(BtnModificarProveedor.Tag) == 1)
                BtnModificarProveedor.Tag = null;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ComprobarDatosIntroducidos())
            {
                Proveedor proveedor = new Proveedor();
                proveedor.Empresa = TxtEmpresa.Text;
                proveedor.Cif = TxtCif.Text;
                proveedor.Concepto = TxtConcepto.Text;

                if (Convert.ToInt32(BtnAddProveedor.Tag) == 1)                // Insertamos el nuevo proveedor.
                {                                                           
                    if (proveedor.Insertar())
                    {
                        MessageBox.Show("Proveedor guardado", "Proveedor Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Proveedor.ObtenerProveedores();

                        int pos = ((List<Proveedor>)BindingSource.DataSource).IndexOf(new Proveedor(proveedor.Id));
                        BindingSource.Position = pos;

                        HabilitarControles(false);                                                
                    }
                    else
                        MessageBox.Show("Ha habido un problema al guardar el proveedor", "Proveedor no Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(BtnModificarProveedor.Tag) == 1)             // Modificamos los datos del proveedor.
                {
                    proveedor.Id = ((Proveedor)BindingSource.Current).Id;
                    if (proveedor.Modificar())
                    {
                        MessageBox.Show("Proveedor modificado", "Proveedor Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingSource.DataSource = Proveedor.ObtenerProveedores();

                        int pos = ((List<Proveedor>)BindingSource.DataSource).IndexOf(new Proveedor(proveedor.Id));
                        BindingSource.Position = pos;

                        HabilitarControles(false);                                                
                    }
                    else
                        MessageBox.Show("Ha habido un problema al modificar el proveedor", "Proveedor no Modificado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RestaurarTagsBotones();
        }

        /// <summary>
        /// Comprueba que los datos introducidos por el usuario sean correctos.
        /// </summary>
        /// <returns>Indica si los datos introducidos son correctos.</returns>        
        private bool ComprobarDatosIntroducidos()
        {
            bool hayEmpresa = false;
            bool hayCif = false;
            bool hayConcepto = false;
            Regex exprRegCif = new Regex("^[0-9]{8}[A-Z]{1}$");

            if (TxtEmpresa.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un nombre de empresa", "Nombre de Empresa Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayEmpresa = true;

            if (TxtCif.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un C.I.F.", "C.I.F. Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!exprRegCif.IsMatch(TxtCif.Text))
                MessageBox.Show("Formato de C.I.F. incorrecto", "Formato no Correcto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayCif = true;

            if (TxtConcepto.Text.Length == 0)
                MessageBox.Show("Tiene que introducir un concepto", "Concepto Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                hayConcepto = true;

            return hayEmpresa && hayCif && hayConcepto;
        }
    }
}
