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
    public partial class FrmResultados : Form
    {
        private int Mes { get; set; }
        private int Anio { get; set; }

        public FrmResultados(int mes, int anio)
        {
            InitializeComponent();
            Mes = mes;
            Anio = anio;
        }

        private void FrmResultados_Load(object sender, EventArgs e)
        {
            MostrarFechaInicioYFin();
            Dictionary<string, decimal[]> resultadosGarajes = new Dictionary<string, decimal[]>();            

            for (int i = 1; i <= 5; i++)
            {
                if (Mes >= 1)                
                    switch (i)
                    {
                        case 1:
                            resultadosGarajes.Add("GM", new decimal[2] {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("GM", Mes),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("GM", Mes)
                            });

                            TxtEmitidasGm.Text = resultadosGarajes["GM"][0].ToString();
                            TxtRecibidasGm.Text = resultadosGarajes["GM"][1].ToString();
                            TxtResultadoGm.Text = (resultadosGarajes["GM"][0] - resultadosGarajes["GM"][1]).ToString();
                            break;

                        case 2:
                            resultadosGarajes.Add("C2", new decimal[2]
                            {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("C2", Mes),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("C2", Mes)
                            });

                            TxtEmitidasC2.Text = resultadosGarajes["C2"][0].ToString();
                            TxtRecibidasC2.Text = resultadosGarajes["C2"][1].ToString();
                            TxtResultadoC2.Text = (resultadosGarajes["C2"][0] - resultadosGarajes["C2"][1]).ToString();
                            break;

                        case 3:
                            resultadosGarajes.Add("L", new decimal[2]
                            {
                                FacturaLavadero.ObtenerSumaBaseImponiblePorMes(Mes),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("L", Mes)
                            });

                            TxtEmitidasLv.Text = resultadosGarajes["L"][0].ToString();
                            TxtRecibidasLv.Text = resultadosGarajes["L"][1].ToString();
                            TxtResultadoLv.Text = (resultadosGarajes["L"][0] - resultadosGarajes["L"][1]).ToString();
                            break;

                        case 4:
                            resultadosGarajes.Add("IM", new decimal[2]
                            {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("IM", Mes),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("IM", Mes)
                            });

                            TxtEmitidasIm.Text = resultadosGarajes["IM"][0].ToString();
                            TxtRecibidasIm.Text = resultadosGarajes["IM"][1].ToString();
                            TxtResultadoIm.Text = (resultadosGarajes["IM"][0] - resultadosGarajes["IM"][1]).ToString();
                            break;

                        case 5:
                            resultadosGarajes.Add("C19", new decimal[2]
                            {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("C19", Mes),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYMes("C19", Mes)
                            });

                            TxtEmitidasC19.Text = resultadosGarajes["C19"][0].ToString();
                            TxtRecibidasC19.Text = resultadosGarajes["C19"][1].ToString();
                            TxtResultadoC19.Text = (resultadosGarajes["C19"][0] - resultadosGarajes["C19"][1]).ToString();
                            break;
                    }                                    
                else
                {
                    switch (i)
                    {
                        case 1:
                            resultadosGarajes.Add("GM", new decimal[2] {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("GM", Anio),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("GM", Anio)
                            });

                            TxtEmitidasGm.Text = resultadosGarajes["GM"][0].ToString();
                            TxtRecibidasGm.Text = resultadosGarajes["GM"][1].ToString();
                            TxtResultadoGm.Text = (resultadosGarajes["GM"][0] - resultadosGarajes["GM"][1]).ToString();
                            break;

                        case 2:
                            resultadosGarajes.Add("C2", new decimal[2]
                            {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("C2", Anio),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("C2", Anio)
                            });

                            TxtEmitidasC2.Text = resultadosGarajes["C2"][0].ToString();
                            TxtRecibidasC2.Text = resultadosGarajes["C2"][1].ToString();
                            TxtResultadoC2.Text = (resultadosGarajes["C2"][0] - resultadosGarajes["C2"][1]).ToString();
                            break;

                        case 3:
                            resultadosGarajes.Add("L", new decimal[2]
                            {
                                FacturaLavadero.ObtenerSumaBaseImponiblePorAnio(Anio),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("L", Anio)
                            });

                            TxtEmitidasLv.Text = resultadosGarajes["L"][0].ToString();
                            TxtRecibidasLv.Text = resultadosGarajes["L"][1].ToString();
                            TxtResultadoLv.Text = (resultadosGarajes["L"][0] - resultadosGarajes["L"][1]).ToString();
                            break;

                        case 4:
                            resultadosGarajes.Add("IM", new decimal[2]
                            {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("IM", Anio),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("IM", Anio)
                            });

                            TxtEmitidasIm.Text = resultadosGarajes["IM"][0].ToString();
                            TxtRecibidasIm.Text = resultadosGarajes["IM"][1].ToString();
                            TxtResultadoIm.Text = (resultadosGarajes["IM"][0] - resultadosGarajes["IM"][1]).ToString();
                            break;

                        case 5:
                            resultadosGarajes.Add("C19", new decimal[2]
                            {
                                FacturaGaraje.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("C19", Anio),
                                FacturaRecibida.ObtenerSumaBaseImponiblePorSubIdGarajeYAnio("C19", Anio)
                            });

                            TxtEmitidasC19.Text = resultadosGarajes["C19"][0].ToString();
                            TxtRecibidasC19.Text = resultadosGarajes["C19"][1].ToString();
                            TxtResultadoC19.Text = (resultadosGarajes["C19"][0] - resultadosGarajes["C19"][1]).ToString();
                            break;
                    }
                }
            }

            decimal totalFactsEmitidas = 0;
            decimal totalFactsRecibidas = 0;            
            foreach (KeyValuePair<string, decimal[]> resultado in resultadosGarajes)
            {
                totalFactsEmitidas += resultado.Value[0];
                totalFactsRecibidas += resultado.Value[1];
            }

            decimal totalFacts = totalFactsEmitidas - totalFactsRecibidas;
            TxtTotalEmitidas.Text = totalFactsEmitidas.ToString();
            TxtTotalRecibidas.Text = totalFactsRecibidas.ToString();
            TxtTotal.Text = totalFacts.ToString();
        }

        /// <summary>
        /// Muestra la fecha de inicio y fin a partir del mes o del año seleccionado.
        /// </summary>
        private void MostrarFechaInicioYFin()
        {
            if (Mes >= 1)        // Se ha seleccionado un mes.
            {
                StringBuilder cadena = null;
                if (Mes <= 9)       // El mes solo tiene un dígito.
                {
                    cadena = new StringBuilder();
                    cadena.Append("01/").Append("0").Append(Mes).Append("/").Append(Anio);

                    LFechaInicio.Text = cadena.ToString();
                    cadena.Length = 0;
                    cadena.Append(DateTime.DaysInMonth(Anio, Mes)).Append("/0").Append(Mes).Append("/").Append(Anio);
                    LFechaFin.Text = cadena.ToString();
                }
                else
                {
                    cadena = new StringBuilder();
                    cadena.Append("01/").Append(Mes).Append("/").Append(Anio);

                    LFechaInicio.Text = cadena.ToString();
                    cadena.Length = 0;
                    cadena.Append(DateTime.DaysInMonth(Anio, Mes)).Append("/").Append(Mes).Append("/").Append(Anio);
                    LFechaFin.Text = cadena.ToString();
                }
            }
            else        // Se ha seleccionado un año.
            {
                LFechaInicio.Text = "01/01/" + Anio;
                LFechaFin.Text = "31/12/" + Anio;
            }
        }
    }
}
