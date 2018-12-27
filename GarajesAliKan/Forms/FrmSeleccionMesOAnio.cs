using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using GarajesAliKan.Clases;

namespace GarajesAliKan.Forms
{
    public partial class FrmSeleccionMesOAnio : Form
    {
        public FrmSeleccionMesOAnio()
        {
            InitializeComponent();
        }

        private void FrmSeleccionMesOAnio_Load(object sender, EventArgs e)
        {
            List<string> mesesAnio = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.ToList<string>();         // Obtenemos los meses del año.         
            for (int i = 0; i < mesesAnio.Count; i++)
            {
                if (i == mesesAnio.Count - 1)      // La última posición de la lista está vacía.          
                    mesesAnio.RemoveAt(i);                
                else
                {
                    string mes = mesesAnio[i];
                    char[] letrasMes = mes.ToCharArray();
                    letrasMes[0] = char.ToUpper(mes[0]);
                    mesesAnio[i] = new string(letrasMes);
                }                
            }

            CbMeses.DataSource = mesesAnio;
            CbAnios.DataSource = FacturaRecibida.ObtenerAniosFechas();
        }

        private void RbMes_CheckedChanged(object sender, EventArgs e)
        {
            if (RbMes.Checked)
            {
                CbMeses.Enabled = true;
                CbAnios.Enabled = false;
            }
            else
            {
                CbAnios.Enabled = true;
                CbMeses.Enabled = false;
            }
        }

        private void BtnMostrarResultados_Click(object sender, EventArgs e)
        {
            FrmResultados frmResultados = null;

            if (RbMes.Checked)            
                frmResultados = new FrmResultados(CbMeses.SelectedIndex + 1, DateTime.Now.Year);                            
            else            
                frmResultados = new FrmResultados(0, (int)CbAnios.SelectedValue);            

            Close();
            frmResultados.ShowDialog();
        }
    }
}
