using Distribuciones;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SIMULACION_TP1
{
    public partial class Ejercicio__B : System.Windows.Forms.Form
    {
        int cantProyectos = 0;

        int a, c, m;
        double semilla, xiAnterior;


        private void cboSignificancia_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboDist1.SelectedIndex = 0;
        }

        public Ejercicio__B()
        {
            InitializeComponent();
            tablaVectorEstado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //SETEO INICIAL DE ACTIVIDADES
            comboDist1.SelectedIndex = 2;
            constante1_1.Text = "20";
            constante1_2.Text = "30";

            comboDist2.SelectedIndex = 2;
            constante2_1.Text = "30";
            constante2_2.Text = "50";

            comboDist3.SelectedIndex = 1;
            constante3_1.Text = "30";

            comboDist4.SelectedIndex = 2;
            constante4_1.Text = "10";
            constante4_2.Text = "30";

            comboDist5.SelectedIndex = 1;
            constante5_1.Text = "5";

            txt_m.Text = "918468";
            txt_a.Text = "5940215";
            txt_c.Text = "1951138";
            txt_semilla.Text = "584431597";

        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            var val1 = validaciones(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text);
            var val2 = validaciones(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text);
            var val3 = validaciones(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text);
            var val4 = validaciones(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text);
            var val5 = validaciones(comboDist5.SelectedIndex, constante5_1.Text, constante5_2.Text);
            if (int.Parse(txt_cantProy.Text) < 1)
            {
                MessageBox.Show("La cantidad de proyectos debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cantProy.Focus();
            }
  
            if(val1 && val2 && val3 && val4 && val5) Simular();
        }

        private double congruencialMixto(int a, int c, int m, double xi)
        {
            xiAnterior = ((a * xi) + c) % m; //Si es mixto

            return (xiAnterior + 0.5) / m; //(0;1)
        }


        private void Simular(int desde = 0, int hasta = 0)
        {
            tablaVectorEstado.Rows.Clear();
            Grafico.Series.Clear();

            m = int.Parse(txt_m.Text);
            a = int.Parse(txt_a.Text);
            c = int.Parse(txt_c.Text);
            semilla = double.Parse(txt_semilla.Text);
            xiAnterior = semilla;
            cantProyectos = int.Parse(txt_cantProy.Text);
            double T1, T2, T3, T4, T5;
            VectorEstado vectorEstado = new VectorEstado();
            VectorEstado vectorEstadoMasUno;

            //// Genera Grafico
            if (Grafico.Titles.Count == 0)
                Grafico.Titles.Add("Probabilidades intervalos");

            Series series = Grafico.Series.Add("Probabilidad");
            series.ChartType = SeriesChartType.Point;
            series.Points.Clear();
            Grafico.ChartAreas[0].AxisX.Title = "Intervalos";
            Grafico.ChartAreas[0].AxisY.Title = "Probabilidades";

            for (int i = 0; i < cantProyectos; i++)
            {
                List<double> lista = new List<double>();
                var numAleatorio1 = congruencialMixto(a, c, m, xiAnterior);
                T1 = GeneracionTiemposActividad(comboDist1.SelectedIndex, constante1_1.Text, constante1_2.Text, numAleatorio1);

                var numAleatorio2 = congruencialMixto(a, c, m, xiAnterior);
                T2 = GeneracionTiemposActividad(comboDist2.SelectedIndex, constante2_1.Text, constante2_2.Text, numAleatorio2);

                var numAleatorio3 = congruencialMixto(a, c, m, xiAnterior);
                T3 = GeneracionTiemposActividad(comboDist3.SelectedIndex, constante3_1.Text, constante3_2.Text, numAleatorio3);

                var numAleatorio4 = congruencialMixto(a, c, m, xiAnterior);
                T4 = GeneracionTiemposActividad(comboDist4.SelectedIndex, constante4_1.Text, constante4_2.Text, numAleatorio4);

                var numAleatorio5 = congruencialMixto(a, c, m, xiAnterior);
                T5 = GeneracionTiemposActividad(comboDist5.SelectedIndex, constante5_1.Text, constante5_2.Text, numAleatorio5);

                if (i == 0)
                {
                    

                    vectorEstado = new VectorEstado(i + 1, T1, T2, T3, T4, T5, 0, 0, double.PositiveInfinity, 0, 0, 0, 0, 0, 0, 0, lista, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    if (desde == 0 && hasta == 0)
                    {
                        tablaVectorEstado.Rows.Add(0.ToString());

                        tablaVectorEstado.Rows.Add(vectorEstado.nroProyecto.ToString(), Math.Round(numAleatorio1, 4).ToString(), Math.Round(numAleatorio2, 4).ToString(), Math.Round(numAleatorio3, 4).ToString(),
                                                   Math.Round(numAleatorio4, 4).ToString(), Math.Round(numAleatorio5, 4).ToString(), vectorEstado.T1.ToString(), vectorEstado.T2.ToString(), vectorEstado.T3.ToString(), vectorEstado.T4.ToString(),
                                                   vectorEstado.T5.ToString(), vectorEstado.DuracionEnsamble.ToString(), vectorEstado.AcumuladoEnsamble.ToString(), vectorEstado.PromedioDuracionEnsamble.ToString(),
                                                   vectorEstado.MaxDuracion.ToString(), vectorEstado.MinDuracion.ToString(), vectorEstado.CantTareasMenor45Dias.ToString(), vectorEstado.ProbCompletarEn45Dias.ToString(),
                                                   vectorEstado.Varianza.ToString(), vectorEstado.Desviacion.ToString(), vectorEstado.FechaNc90.ToString(), vectorEstado.C1.ToString(), vectorEstado.C2.ToString(),
                                                   vectorEstado.C3.ToString(), vectorEstado.CCritico.ToString(), vectorEstado.CCriticoString, vectorEstado.ProbA1Critico.ToString(), vectorEstado.ProbA2Critico.ToString(),
                                                   vectorEstado.ProbA3Critico.ToString(), vectorEstado.ProbA4Critico.ToString(), vectorEstado.ProbA5Critico.ToString(), vectorEstado.A1MasTardio.ToString(),
                                                   vectorEstado.A2MasTardio.ToString(), vectorEstado.A3MasTardio.ToString(), vectorEstado.A4MasTardio.ToString(), vectorEstado.A5MasTardio.ToString(),
                                                   vectorEstado.ProbIntervalo1.ToString(), vectorEstado.ProbIntervalo2.ToString(), vectorEstado.ProbIntervalo3.ToString(), vectorEstado.ProbIntervalo4.ToString(),
                                                   vectorEstado.ProbIntervalo5.ToString(), vectorEstado.ProbIntervalo6.ToString(), vectorEstado.ProbIntervalo7.ToString(), vectorEstado.ProbIntervalo8.ToString(),
                                                   vectorEstado.ProbIntervalo9.ToString(), vectorEstado.ProbIntervalo10.ToString(), vectorEstado.ProbIntervalo11.ToString(), vectorEstado.ProbIntervalo12.ToString(),
                                                   vectorEstado.ProbIntervalo13.ToString(), vectorEstado.ProbIntervalo14.ToString(), vectorEstado.ProbIntervalo15.ToString());
                    }
                }
                else
                {
                    vectorEstadoMasUno = new VectorEstado(i + 1, T1, T2, T3, T4, T5, vectorEstado.AcumuladoEnsamble, vectorEstado.MaxDuracion, vectorEstado.MinDuracion, vectorEstado.CantTareasMenor45Dias,
                                                vectorEstado.Varianza, vectorEstado.ProbA1Critico, vectorEstado.ProbA2Critico, vectorEstado.ProbA3Critico, vectorEstado.ProbA4Critico, vectorEstado.ProbA5Critico,
                                                vectorEstado.ListaIntervalos, vectorEstado.ProbIntervalo1, vectorEstado.ProbIntervalo2, vectorEstado.ProbIntervalo3, vectorEstado.ProbIntervalo4,
                                               vectorEstado.ProbIntervalo5, vectorEstado.ProbIntervalo6, vectorEstado.ProbIntervalo7, vectorEstado.ProbIntervalo8,
                                               vectorEstado.ProbIntervalo9, vectorEstado.ProbIntervalo10, vectorEstado.ProbIntervalo11, vectorEstado.ProbIntervalo12,
                                               vectorEstado.ProbIntervalo13, vectorEstado.ProbIntervalo14, vectorEstado.ProbIntervalo15);

                    var nroProyecto = vectorEstadoMasUno.nroProyecto.ToString();
                    var DuracionEnsamble = vectorEstadoMasUno.DuracionEnsamble.ToString();
                    var AcumuladoEnsamble = Math.Round(vectorEstadoMasUno.AcumuladoEnsamble, 4).ToString();
                    var PromedioDuracionEnsamble = Math.Round(vectorEstadoMasUno.PromedioDuracionEnsamble, 4).ToString();
                    var MaxDuracion = vectorEstadoMasUno.MaxDuracion.ToString();
                    var MinDuracion = vectorEstadoMasUno.MinDuracion.ToString();
                    var CantTareasMenor45Dias = vectorEstadoMasUno.CantTareasMenor45Dias.ToString();
                    var ProbCompletarEn45Dias = Math.Round(vectorEstadoMasUno.ProbCompletarEn45Dias, 4).ToString();
                    var Varianza = Math.Round(vectorEstadoMasUno.Varianza, 4).ToString();
                    var Desviacion = Math.Round(vectorEstadoMasUno.Desviacion, 4).ToString();
                    var FechaNc90 = Math.Round(vectorEstadoMasUno.FechaNc90, 4).ToString();
                    var C1 = Math.Round(vectorEstadoMasUno.C1, 4).ToString();
                    var C2 = Math.Round(vectorEstadoMasUno.C2, 4).ToString();
                    var C3 = Math.Round(vectorEstadoMasUno.C3, 4).ToString();
                    var CCritico = Math.Round(vectorEstadoMasUno.CCritico, 4).ToString();
                    var CCriticoString = vectorEstadoMasUno.CCriticoString;
                    var ProbA1Critico = Math.Round(vectorEstadoMasUno.ProbA1Critico, 4).ToString();
                    var ProbA2Critico = Math.Round(vectorEstadoMasUno.ProbA2Critico, 4).ToString();
                    var ProbA3Critico = Math.Round(vectorEstadoMasUno.ProbA3Critico, 4).ToString();
                    var ProbA4Critico = Math.Round(vectorEstadoMasUno.ProbA4Critico, 4).ToString();
                    var ProbA5Critico = Math.Round(vectorEstadoMasUno.ProbA5Critico, 4).ToString();
                    var A1MasTardio = Math.Round(vectorEstadoMasUno.A1MasTardio, 4).ToString();
                    var A2MasTardio = Math.Round(vectorEstadoMasUno.A2MasTardio, 4).ToString();
                    var A3MasTardio = Math.Round(vectorEstadoMasUno.A3MasTardio, 4).ToString();
                    var A4MasTardio = Math.Round(vectorEstadoMasUno.A4MasTardio, 4).ToString();
                    var A5MasTardio = Math.Round(vectorEstadoMasUno.A5MasTardio, 4).ToString();
                    var Intervalo1 = Math.Round(vectorEstadoMasUno.ProbIntervalo1, 4).ToString();
                    var Intervalo2 = Math.Round(vectorEstadoMasUno.ProbIntervalo2, 4).ToString();
                    var Intervalo3 = Math.Round(vectorEstadoMasUno.ProbIntervalo3, 4).ToString();
                    var Intervalo4 = Math.Round(vectorEstadoMasUno.ProbIntervalo4, 4).ToString();
                    var Intervalo5 = Math.Round(vectorEstadoMasUno.ProbIntervalo5, 4).ToString();
                    var Intervalo6 = Math.Round(vectorEstadoMasUno.ProbIntervalo6, 4).ToString();
                    var Intervalo7 = Math.Round(vectorEstadoMasUno.ProbIntervalo7, 4).ToString();
                    var Intervalo8 = Math.Round(vectorEstadoMasUno.ProbIntervalo8, 4).ToString();
                    var Intervalo9 = Math.Round(vectorEstadoMasUno.ProbIntervalo9, 4).ToString();
                    var Intervalo10 = Math.Round(vectorEstadoMasUno.ProbIntervalo10, 4).ToString();
                    var Intervalo11 = Math.Round(vectorEstadoMasUno.ProbIntervalo11, 4).ToString();
                    var Intervalo12 = Math.Round(vectorEstadoMasUno.ProbIntervalo12, 4).ToString();
                    var Intervalo13 = Math.Round(vectorEstadoMasUno.ProbIntervalo13, 4).ToString();
                    var Intervalo14 = Math.Round(vectorEstadoMasUno.ProbIntervalo14, 4).ToString();
                    var Intervalo15 = Math.Round(vectorEstadoMasUno.ProbIntervalo15, 4).ToString();


                    if ((desde != 0 && hasta != 0
                        && int.Parse(nroProyecto.ToString()) >= desde && int.Parse(nroProyecto.ToString()) <= hasta)
                        ||
                        (desde == 0 && hasta == 0
                        && (int.Parse(nroProyecto.ToString()) < 20 || int.Parse(nroProyecto.ToString()) % 10000 == 0)
                        ))
                    {
                        tablaVectorEstado.Rows.Add(nroProyecto, Math.Round(numAleatorio1, 4).ToString(), Math.Round(numAleatorio2, 4).ToString(), Math.Round(numAleatorio3, 4).ToString(),
                            Math.Round(numAleatorio4, 4).ToString(), Math.Round(numAleatorio5, 4).ToString(), T1, T2, T3, T4, T5, DuracionEnsamble, AcumuladoEnsamble, PromedioDuracionEnsamble, MaxDuracion,
                            MinDuracion, CantTareasMenor45Dias, ProbCompletarEn45Dias, Varianza, Desviacion, FechaNc90, C1, C2, C3, CCritico, CCriticoString,
                            ProbA1Critico, ProbA2Critico, ProbA3Critico, ProbA4Critico, ProbA5Critico, A1MasTardio, A2MasTardio, A3MasTardio, A4MasTardio, A5MasTardio,
                            Intervalo1, Intervalo2, Intervalo3, Intervalo4, Intervalo5, Intervalo6, Intervalo7, Intervalo8, Intervalo9, Intervalo10, Intervalo11,
                            Intervalo12, Intervalo13, Intervalo14, Intervalo15);
                    }

                    vectorEstado = vectorEstadoMasUno;
                }

                if (i == 15)
                {
                    for (int j = 0; j < vectorEstado.ListaIntervalos.Count; j++)
                    {
                        tablaVectorEstado.Columns[36 + j].HeaderText = Math.Round(vectorEstado.ListaIntervalos[j], 4).ToString();

                        //// Cargo los intervalos con sus respectivos valores
                        series.Points.AddXY(j, vectorEstado.ListaIntervalos[j]);
                    }
                }
            }
        }

        private double GeneracionTiemposActividad(int comboDistrSelectedIndex, string constante1, string constante2, double xi)
        {
            switch (comboDistrSelectedIndex)
            {
                case 0:
                    //Normal
                    return Distribucion.Normal(xi, double.Parse(constante1), double.Parse(constante2));
                case 1:
                    //Exponencial
                    return Distribucion.Exponencial(xi, double.Parse(constante1));
                case 2:
                    // uniforme 
                    return Distribucion.Uniforme(xi, double.Parse(constante1), double.Parse(constante2));
                default:
                    return -1;
            }
        }

        private bool validaciones(int comboDistrSelectedIndex, string constante1, string constante2)
        {
            switch (comboDistrSelectedIndex)
            {
                case 0:
                    //Normal
                    if (double.Parse(constante2) < 0)
                    {
                        MessageBox.Show("Desviación tiene que ser positivo en la distribución normal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                case 1:
                    //Exponencial
                    if (double.Parse(constante1) <= 0)
                    {
                        MessageBox.Show("Lambda tiene que ser positivo en la distribución exponencial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                case 2:
                    // uniforme 
                    if ((double.Parse(constante1) > double.Parse(constante2)) || (double.Parse(constante1) < 0) || (double.Parse(constante2) < 0))
                    {
                        MessageBox.Show("Desde debe ser menor que hasta y no se pueden ingresar valores negativos en la distribución uniforme.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                default:
                    return true;
            }
        }

        //Keypress
        private void txt_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void txt_k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void constante1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //    MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
        }
        private void constante2_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* if (char.IsDigit(e.KeyChar))
             {
                 e.Handled = false;
             }
             else if (char.IsControl(e.KeyChar))
             {
                 e.Handled = false;
             }
             else
             {
                 e.Handled = true;
                 MessageBox.Show("El caracter ingresado no es un número ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

             }*/
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist1.SelectedIndex)
            {
                case 0:
                    label10.Text = "Media";
                    label11.Text = "Desviación";
                    label10.Visible = true;
                    label11.Visible = true;
                    constante1_1.Visible = true;
                    constante1_2.Visible = true;
                    break;

                case 1:
                    label10.Text = "Lambda";
                    label10.Visible = true;
                    label11.Visible = false;
                    constante1_1.Visible = true;
                    constante1_2.Visible = false;
                    break;
                case 2:
                    label10.Text = "Desde";
                    label11.Text = "Hasta";
                    label10.Visible = true;
                    label11.Visible = true;
                    constante1_1.Visible = true;
                    constante1_2.Visible = true;
                    break;
                default:

                    label10.Visible = false;
                    label11.Visible = false;
                    constante1_1.Visible = false;
                    constante1_2.Visible = false;
                    break;
            }
        }

        private void comboDist3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist3.SelectedIndex)
            {
                case 0:
                    label23.Text = "Media";
                    label22.Text = "Desviación";
                    label23.Visible = true;
                    label22.Visible = true;
                    constante3_1.Visible = true;
                    constante3_2.Visible = true;
                    break;

                case 1:
                    label23.Text = "Lambda";
                    label23.Visible = true;
                    label22.Visible = false;
                    constante3_1.Visible = true;
                    constante3_2.Visible = false;
                    break;
                case 2:
                    label23.Text = "Desde";
                    label22.Text = "Hasta";
                    label23.Visible = true;
                    label22.Visible = true;
                    constante3_1.Visible = true;
                    constante3_2.Visible = true;
                    break;
                default:

                    label23.Visible = false;
                    label22.Visible = false;
                    constante3_1.Visible = false;
                    constante3_2.Visible = false;
                    break;
            }
        }

        private void comboDist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist2.SelectedIndex)
            {
                case 0:
                    label19.Text = "Media";
                    label18.Text = "Desviación";
                    label19.Visible = true;
                    label18.Visible = true;
                    constante2_1.Visible = true;
                    constante2_2.Visible = true;
                    break;

                case 1:
                    label19.Text = "Lambda";
                    label19.Visible = true;
                    label18.Visible = false;
                    constante2_1.Visible = true;
                    constante2_2.Visible = false;
                    break;
                case 2:
                    label19.Text = "Desde";
                    label18.Text = "Hasta";
                    label19.Visible = true;
                    label18.Visible = true;
                    constante2_1.Visible = true;
                    constante2_2.Visible = true;
                    break;
                default:

                    label19.Visible = false;
                    label18.Visible = false;
                    constante2_1.Visible = false;
                    constante2_2.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int desde = int.Parse(txtDesde.Text);
            int hasta = int.Parse(txtHasta.Text);

            if (desde < hasta)
            {
                Simular(desde, hasta);
            }
            else
            {
                MessageBox.Show("El valor DESDE es mayor a HASTA ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void comboDist4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist4.SelectedIndex)
            {
                case 0:
                    label27.Text = "Media";
                    label26.Text = "Desviación";
                    label27.Visible = true;
                    label26.Visible = true;
                    constante4_1.Visible = true;
                    constante4_2.Visible = true;
                    break;

                case 1:
                    label27.Text = "Lambda";
                    label27.Visible = true;
                    label26.Visible = false;
                    constante4_1.Visible = true;
                    constante4_2.Visible = false;
                    break;
                case 2:
                    label27.Text = "Desde";
                    label26.Text = "Hasta";
                    label27.Visible = true;
                    label26.Visible = true;
                    constante4_1.Visible = true;
                    constante4_2.Visible = true;
                    break;
                default:

                    label27.Visible = false;
                    label26.Visible = false;
                    constante4_1.Visible = false;
                    constante4_2.Visible = false;
                    break;
            }
        }

        private void comboDist5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboDist5.SelectedIndex)
            {
                case 0:
                    label31.Text = "Media";
                    label30.Text = "Desviación";
                    label31.Visible = true;
                    label30.Visible = true;
                    constante5_1.Visible = true;
                    constante5_2.Visible = true;
                    break;

                case 1:
                    label31.Text = "Lambda";
                    label31.Visible = true;
                    label30.Visible = false;
                    constante5_1.Visible = true;
                    constante5_2.Visible = false;
                    break;
                case 2:
                    label31.Text = "Desde";
                    label30.Text = "Hasta";
                    label31.Visible = true;
                    label30.Visible = true;
                    constante5_1.Visible = true;
                    constante5_2.Visible = true;
                    break;
                default:

                    label31.Visible = false;
                    label30.Visible = false;
                    constante5_1.Visible = false;
                    constante5_2.Visible = false;
                    break;
            }
        }

        private void Grafico_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_m_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_k_TextChanged(object sender, EventArgs e)
        {

        }

        private void constante1_TextChanged(object sender, EventArgs e)
        {

        }

        private void constante2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

